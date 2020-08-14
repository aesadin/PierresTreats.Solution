using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTreats.Models;

namespace TheTreats.Cotrollers
{
  public class TreatsController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly TheTreatsContext _db;

    public TreatsController(UserManager<ApplicationUser> userManager, TheTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [Authorize]
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTreats); 
    }

    [Authorize]
    public ActionResult Create()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var thisUsersFlavors = _db.Flavors.Where(entry => entry.User.Id == userId);
      ViewBag.FlavorId = new SelectList(thisUsersFlavors, "FlavorId", "Name");
      return View(); 
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // if condition to the left of '?' is true, then get the value and save as userId variable
      var currentUser = await _userManager.FindByIdAsync(userId); // use user manager to grab user object by the user id that we created on the liine above.
      treat.User = currentUser;
      _db.Treats.Add(treat);
      if (FlavorId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats // defines treat object including all treats
        .Include(treat => treat.Flavors) // only look at the flavors part of the treat object
        .ThenInclude(join => join.Flavor) // only look for the flavor portion of treatflavor table
        .Include(treat => treat.User)
        .FirstOrDefault(treat => treat.TreatId == id); // grab the first treat Id that matches the int Id we passed as argument, if there is no Id then return null
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null ? userId == thisTreat.User.Id : false;    
      return View(thisTreat);
    }

    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treats => treats.TreatId == id);
      if (thisTreat == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name"); // thing that comes after ViewBag. is the name of your viewbag. Selectlist object takes 3 arguments: all the data that you want included, what value you want this clickable 'Name' to have, what you want displayed to user
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat, int FlavorId)
    {
      // var existingConnection = _db.FlavorTreat.FirstOrDefault(join => join.TreatId == treat.TreatId && join.FlavorId == FlavorId);

      // if (existingConnection != null)
      // {
      //   return RedirectToAction("Details", new {id = treat.TreatId});
      // }
      if (FlavorId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId }); // add to the FlavorTreat database a new instance of treatflavor with both the flavorId and the treatId from the treat object passed as argument
      }
      _db.Entry(treat).State = EntityState.Modified; // if we change an existing object, we will get errors unless we first change its entity state to modified, this is so the computer can keep track of modifications without changing the unique Ids of thes treats
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      
      Treat thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treats => treats.TreatId == id);
      if (thisTreat == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<ActionResult> AddFlavor(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treats => treats.TreatId == id);
      if (thisTreat == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      var existingConnection = _db.FlavorTreat.FirstOrDefault(join => join.TreatId == treat.TreatId && join.FlavorId == FlavorId);
      if (existingConnection != null)
      {
        return RedirectToAction("Details", new {id = treat.TreatId});
      }
      if (FlavorId != 0)
      {
      _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddIngredient(int id)
    {
      
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      ViewBag.Ingredients = _db.Ingredients;
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddIngredient(Treat treat, int IngredientId)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == treat.TreatId);
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == IngredientId);
      thisTreat.Ingredients.Add(thisIngredient);
      _db.SaveChanges();
      return View();
    }
  }
}
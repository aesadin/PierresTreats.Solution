using Microsoft.AspNetCore.Mvc;

namespace TheTreats.Controllers
{
  public class HomeController : Controller 
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    // [HttpPost]
    // public ActionResult Index(string searchOption, string searchString)
    // {
    //   if (searchOption == "flavors")
    //   {
    //     return RedirectToAction("Index", "Flavors", new {name = searchString});
    //   }
    //   else if (searchOption == "treats")
    //   {
    //     return RedirectToAction("Index", "Treats", new {name = searchString});
    //   }
    // } 
  }
}
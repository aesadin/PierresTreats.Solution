using Microsoft.AspNetCore.Identity;

namespace TheTreats.Models
{
    public class ApplicationUser : IdentityUser
    {
      public string Name { get; set; } 
    }
}

using Microsoft.AspNetCore.Identity;

namespace AdrianWoronaProject91511.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

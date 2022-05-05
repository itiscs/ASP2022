using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class MyUser:IdentityUser
    {
        public int Age { get; set; }
    }
}

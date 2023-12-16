
using Microsoft.AspNetCore.Identity;

namespace HernandezITELEC1C.Data
{
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? FirstName { get; internal set; }
        public string? Lastname { get; set;}
        public string? LastName { get; internal set; }
    }
}

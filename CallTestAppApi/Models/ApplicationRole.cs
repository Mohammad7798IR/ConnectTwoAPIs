using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CallTestAppApi.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        [Key]
        public string? Id { get; set; }


        public ICollection<ApplicationUserRole> userRoles { get; set; }
    }
}

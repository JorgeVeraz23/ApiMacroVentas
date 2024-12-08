using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MacroVentasEnterprise.Data
{
    public class ApplicationRole : IdentityRole
    {
        public bool Active { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserRegister { get; set; } = "SYSTEM";
        [Required]
        public DateTime DateRegister { get; set; }
        [MaxLength(100)]
        public string? UserModification { get; set; }
        [MaxLength(100)]
        public DateTime? DateModification { get; set; }
        [MaxLength(100)]
        public string? UserDelete { get; set; }
        public DateTime DateDelete { get; set; }
       
    }
}

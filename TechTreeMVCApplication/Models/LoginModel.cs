using System.ComponentModel.DataAnnotations;

namespace TechTreeMVCApplication.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Your email")]
        [StringLength(100, MinimumLength = 6)]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Your password")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string LoginInValid { get; set; }
    }
}

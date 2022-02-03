
using System.ComponentModel.DataAnnotations;

namespace WebAppi.Controllers
{
    public  class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string pass { get; set; }

       
    }
}

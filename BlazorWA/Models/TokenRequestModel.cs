using System.ComponentModel.DataAnnotations;

namespace BlazorWA.Models
{
    public class TokenRequestModel
    {

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

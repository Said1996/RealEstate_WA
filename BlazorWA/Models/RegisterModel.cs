using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorWA.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(150, ErrorMessage = "Maximum name length is 150.")]
        [MinLength(2, ErrorMessage = "Minimum name length is 2.")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

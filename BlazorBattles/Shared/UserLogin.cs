using System.ComponentModel.DataAnnotations;

namespace BlazorBattles.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter a username, you silly goose!")]
        public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}
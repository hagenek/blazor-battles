using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorBattles.Shared
{
    public class UserLogin
{
    [Required(ErrorMessage = "Please enter a username, you silly goose!")]
    public string Email { get; set; }
    [Required]
        public string Password { get; set; }    

}
}

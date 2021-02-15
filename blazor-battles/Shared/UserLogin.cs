using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace blazor_battles.Shared
{
    public class UserLogin
{
    [Required(ErrorMessage = "Please enter a username, you silly goose!")]
    public string Username { get; set; }
    [Required]
        public string Password { get; set; }    

}
}

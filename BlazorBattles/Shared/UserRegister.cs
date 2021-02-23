using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBattles.Shared
{
    public class UserRegister
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [StringLength(16, ErrorMessage = "Your username is too long (16 characters is max)")]
        public string Username { get; set; }

        public string Bio { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The passwords do not match. You silly goose!")]
        public string ConfirmPassword { get; set; }

        [Range(0, 1000, ErrorMessage = "Please chooes a number between 0 and 1000")]
        public int Bananas { get; set; } = 100;

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Only Confirmed users can play!")]
        public bool IsConfirmed { get; set; } = true;

        public string StartUnitId { get; set; }
    }
}
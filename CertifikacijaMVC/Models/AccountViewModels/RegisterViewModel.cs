using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi šifru")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }
        [Required]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }
        [Required]
        [Display(Name = "Broj lične karte")]
        public string BrojLicneKarte { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodenja { get; set; }
        [Required]
        [Display(Name = "Mjesto rođenja")]
        public string MjestoRodjenja { get; set; }
        [Required]
        [Display(Name = "Ime oca")]
        public string ImeOca { get; set; }
    }
}

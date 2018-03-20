using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class Rezultat
    {
        public int RezultatId { get; set; }
        [Display(Name = "Datum polaganja")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DatumPolaganja { get; set; }
        [Display(Name = "Broj pokušaja")]
        [Required]
        public int Pokusaj { get; set; }
        [Display(Name = "Broj bodova")]
        [Required]
        public int Bodovi { get; set; }
        public ApplicationUser User { get; set; }
        public TipPolaganja TipPolaganja { get; set; }
        public ICollection<Test> Testovi { get; set; }
    }
}

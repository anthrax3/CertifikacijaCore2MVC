using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class Pitanje
    {
        [Key]
        public int PitanjeId { get; set; }
        [Display(Name = "Tekst pitanja")]
        public string TekstPitanja { get; set; }
        public ICollection<Test> Testovi { get; set; }
        public ICollection<OdabirTipa> OdabirTipas { get; set; }
    }
}

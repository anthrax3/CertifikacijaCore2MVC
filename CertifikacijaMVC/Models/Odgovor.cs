using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class Odgovor
    {
        public int OdgovorId { get; set; }
        [Display(Name = "Tekst odgovora")]
        [Required]
        public string TekstOdgovora { get; set; }
        public Pitanje Pitanje { get; set; }
        public ICollection<Test> Testovi { get; set; }
        public ICollection<OdgNaPitanje> OdgNaPitanjes { get; set; }
    }
}

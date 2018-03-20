using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class OdgNaPitanje
    {
        [Key]
        public int OdgNaPitanjeId { get; set; }
        public int OdabirTipaId { get; set; }
        public int OdgovorId { get; set; }
        [Display(Name = "Tačno?")]
        [Required]
        public bool Tačno { get; set; }
        [Display(Name = "Tip odgovora")]
        [Required]
        public string TipOdgovora { get; set; }
        public OdabirTipa OdabirTipa { get; set; }
        public Odgovor Odgovor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class OdabirTipa
    {
        [Key]
        public int OdabirTipaId { get; set; }
        public int TipPolaganjaId { get; set; }
        public int PitanjeId { get; set; }
        public TipPolaganja TipPolaganja { get; set; }
        public Pitanje Pitanje { get; set; }
        public ICollection<OdgNaPitanje> OdgNaPitanjes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public int RezultatId { get; set; }
        public int PitanjeId { get; set; }
        public int OdgovorId { get; set; }
        public Rezultat Rezultat { get; set; }
        public Pitanje Pitanje { get; set; }
        public Odgovor Odgovor { get; set; }

    }
}

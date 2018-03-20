using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class Certifikat
    {
        public int CertifikatId { get; set; }
        [Display(Name = "Datum izdavanja")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DatumIzdavanja { get; set; }
        [Display(Name = "Djelovodni broj")]
        [Required]
        public string DjelovodniBroj { get; set; }
        public Rezultat Rezultat { get; set; }
    }
}

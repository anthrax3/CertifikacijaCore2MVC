using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CertifikacijaMVC.Models
{
    public class TipPolaganja
    {
        [Key]
        public int TipPolaganjaId { get; set; }
        [Display(Name = "Tip polaganja")]
        [Required]
        public string Tip { get; set; }
        [Display(Name = "Tip polaganja na engleskom")]
        [Required]
        public string TipEng { get; set; }
        public ICollection<OdabirTipa> OdabirTipas { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Model
{
    public class EvidenciaZamestnanca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvidenciaZamestnancaID { get; set; }

        public int ZamestnanecID { get; set; }

        public int PoziciaID { get; set; }

        public DateTime DatumNastupu { get; set; }

        public DateTime? DatumUkoncenia { get; set; }

        public float Plat { get; set; }

        [Required]
        public virtual Zamestnanec Zamestnanec { get; set; }

        [Required]
        public virtual Pozicia Pozicia { get; set; }
    }
}

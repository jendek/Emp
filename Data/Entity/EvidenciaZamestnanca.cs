using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Data.Entity
{
    public class EvidenciaZamestnanca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ZamestnanecId { get; set; }

        public int PoziciaId { get; set; }

        public DateTime DatumNastupu { get; set; }

        public DateTime? DatumUkoncenia { get; set; }

        public float Plat { get; set; }

        [Required]
        public Zamestnanec Zamestnanec { get; set; }

        [Required]
        public Pozicia Pozicia { get; set; }
    }
}

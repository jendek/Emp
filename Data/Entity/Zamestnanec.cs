using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Data.Entity
{
    public class Zamestnanec
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Meno { get; set; }

        [Required]
        public string Priezvisko { get; set; }

        public string Adresa { get; set; }

        public DateTime DatumNarodenia { get; set; }

        public ICollection<EvidenciaZamestnanca> EvidenciaZamestnanca { get; set; }

    }
}

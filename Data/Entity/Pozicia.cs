using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Data.Entity
{
    public class Pozicia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nazov { get; set; }

        public bool Vymazana { get; set; }

        public ICollection<EvidenciaZamestnanca> EvidenciaZamestnanca { get; set; }
    }
}

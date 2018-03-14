using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Model
{
    public class Pozicia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PoziciaID { get; set; }

        [Required]
        public string Nazov { get; set; }

        public bool Vymazana { get; set; }
    }
}

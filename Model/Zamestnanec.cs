using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Model
{
    public class Zamestnanec
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZamestnanecID { get; set; }

        [Required]
        public string Meno { get; set; }

        [Required]
        public string Priezvisko { get; set; }

        public string Adresa { get; set; }

        public DateTime DatumNarodenia { get; set; }
    }
}

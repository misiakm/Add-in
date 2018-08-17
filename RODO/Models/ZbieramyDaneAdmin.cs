using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Models
{
    public enum ZbieranieDanych
    {
        NieUstalono = 1,
        Tak = 2,
        Nie = 3
    }

    [Table("ZbieramyDaneAdmin")]
    public class ZbieramyDaneAdmin
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string ZbieramyDane { get; set; }

        [ForeignKey("ZbieramyDaneAdmin")]
        public ICollection<Arkusz> Arkusze { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Models
{
    public enum TypyAkcji
    {
        Select = 1,
        Update = 2,
        Delete = 3,
        Insert = 4
    }

    [Table("TypyAkcji")]
    public class TypAkcji
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Nazwa { get; set; }

        [ForeignKey("TypAkcji")]
        public virtual ICollection<Log> Logi { get; set; }
    }
}

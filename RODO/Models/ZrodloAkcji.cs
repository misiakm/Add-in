using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Models
{
    public enum Rodzaje
    {
        Uzytkownik = 1,
        Admin = 2,
        System = 3
    }

    [Table("ZrodlaAkcji")]
    public class ZrodloAkcji
    {
        [Key]
        public int ID { get; set; }

        [Required]
        
        public string Nazwa { get; set; }

        [ForeignKey("Zrodlo")]
        public virtual ICollection<Log> Logi { get; set; }
    }
}

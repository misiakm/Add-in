using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Models
{
    [Table("Logi")]
    public class Log
    {
        [Key]
        public int ID { get; set; }

        public int? Uzytkownik { get; set; }

        [Required]
        public int Arkusz { get; set; }

        [Required]
        
        public string NazwaArkusza { get; set; }

        [Required]
        
        public string NazwaPliku { get; set; }


        public string SciezkaPliku { get; set; }

        
        public string PrzedZmiana { get; set; }

        
        public string PoZmianie { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Zrodlo { get; set; }

        [Required]
        [DefaultValue(1)]
        public int TypAkcji { get; set; }

        [Required]
        public DateTime DataDodania { get; set; } = DateTime.Now;
    }
}

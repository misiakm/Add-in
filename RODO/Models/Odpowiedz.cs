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
    /// <summary>
    /// Przechowujemy każdą odpowiedź użytkownika
    /// </summary>
    [Table("Odpowiedzi")]
    public class Odpowiedz
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Arkusz { get; set; }

        [Required]
        
        public string NazwaArkusza { get; set; }

        public int? Uzytkownik { get; set; }

        
        public string Sciezka { get; set; }

        [Required]
        
        public string NazwaPliku { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool ZbieramyDane { get; set; }

        public int Rodzaj { get; set; }

        [Required]
        public DateTime DataDodania { get; set; } = DateTime.Now;
    }
}

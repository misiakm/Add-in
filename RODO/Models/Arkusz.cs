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
    [Table("Arkusze")]
    public class Arkusz
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string NazwaArkusza { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Klucz { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string BiezacaNazwaArkusz { get; set; }

        [Required]
        public int Plik { get; set; }

        [Required]
        public int Uzytkownik { get; set; }

        /// <summary>
        /// Informacja Od uzytkownika
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool ZbieramyDane { get; set; }

        public int ZbieramyDaneAdmin { get; set; }

        /// <summary>
        /// Informacja od Dodatku
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool ZbieramyDaneSystem { get; set; }

        [Required]
        public DateTime DataDodania { get; set; } = DateTime.Now;

        [ForeignKey("Arkusz")]
        public virtual ICollection<Log> Logi { get; set; }

        [ForeignKey("Arkusz")]
        public virtual ICollection<Odpowiedz> Odpowiedzi { get; set; }
    }
}

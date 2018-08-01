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
    [Table("Pliki")]
    public class Plik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string NazwaPliku { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string Sciezka { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string BiezacaNazwaPliku { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Klucz { get; set; }       

        /// <summary>
        /// Informacja kto poraz pierwszy skorzystał z pliku i zaznaczył jakąkolwiek odpowiedź
        /// </summary>
        public int? KtoDodal { get; set; }

        [Required]
        public DateTime DataDodania { get; set; } = DateTime.Now;

        

        [ForeignKey("Plik")]
        public virtual ICollection<Arkusz> Arkusze { get; set; }
    }
}

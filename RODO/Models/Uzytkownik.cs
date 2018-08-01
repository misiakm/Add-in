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
    /// Zabraniamy edycję. Jedyne co może być edytowalne to właściwość Aktywny
    /// </summary>
    [Table("Uzytkownicy")]
    public class Uzytkownik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string NazwaKomputera { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string NazwaUzytkownika { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Aktywny { get; set; }


        [Column(TypeName = "VARCHAR(MAX)")]
        public string Imie { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string Nazwisko { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string Haslo { get; set; }

        [Required]
        public DateTime DataDodania { get; set; } = DateTime.Now;

        /// <summary>
        /// Lista wszystkich dodanych plików przez użytkownika
        /// </summary>
        [ForeignKey("KtoDodal")]
        public virtual ICollection<Plik> DodanePliki { get; set; }

        /// <summary>
        /// Lista wszystkich udzielonych odpowiedzi przez użytkownika
        /// </summary>
        [ForeignKey("Uzytkownik")]
        public virtual ICollection<Odpowiedz> Odpowiedzi { get; set; }

        /// <summary>
        /// Lista logów wykonanych przez użytkownika
        /// </summary>
        [ForeignKey("Uzytkownik")]
        public virtual ICollection<Log> Logi { get; set; }

        [ForeignKey("Uzytkownik")]
        public virtual ICollection<Arkusz> DodaneArkusze { get; set; }

    }
}

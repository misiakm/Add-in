using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Models.Pomoc
{
    public class LogiPomoc
    {
        public LogiPomoc(string kluczArkusza, string nazwaArkusza, string kluczPliku, string nazwaPliku, string sciezkaPliku, TypyAkcji typAkcji, bool zbieramyDane)
        {
            KluczArkusza = kluczArkusza;
            KluczPliku = kluczPliku;
            TypAkcji = (int)typAkcji;
            ZbieramyDane = zbieramyDane;
            NazwaArkusz = nazwaArkusza;
            SciezkaPliku = sciezkaPliku;
            NazwaPliku = nazwaPliku;
            DataDodania = DateTime.Now;
        }

        public LogiPomoc(string kluczArkusza, string nazwaArkusza, string kluczPliku, string nazwaPliku, string sciezkaPliku, TypyAkcji typAkcji, bool zbieramyDane, string przedZmiana, string poZmianie)
            : this(kluczArkusza, nazwaArkusza, kluczPliku, nazwaPliku, sciezkaPliku, typAkcji, zbieramyDane)
        {
            PrzedZmiana = przedZmiana;
            PoZmianie = poZmianie;
        }

        public string KluczArkusza { get; set; }
        public string NazwaArkusz { get; set; }
        public string KluczPliku { get; set; }
        public string NazwaPliku { get; set; }
        public string SciezkaPliku { get; set; }
        public string PrzedZmiana { get; set; }
        public string PoZmianie { get; set; }
        public int TypAkcji { get; set; }
        public bool ZbieramyDane { get; set; }
        public DateTime DataDodania { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Models.Pomoc
{
    class ArkuszePomoc
    {
        public ArkuszePomoc() { }
        public ArkuszePomoc(string klucz, int ID)
        {
            KluczArkusza = klucz;
            IDArkusza = ID;
        }

        public string KluczArkusza { get; set; }

        public int IDArkusza { get; set; }
    }
}

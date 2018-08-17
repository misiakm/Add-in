using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Logika
{
    static class ChangeRibbon
    {
        public static Wstazka wstazka;

        public static void ZmienKarte(Worksheet sht)
        {
            wstazka.TabDaneOsobowe.Visible = DaneOsobowe.CzyZbieramyDane(sht);
        }

    }
}

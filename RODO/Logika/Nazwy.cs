using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace RODO.Logika
{
    public static class Nazwy
    {       

        /// <summary>
        /// Sprawdza czy w danym skoroszycie jest już przypisana jakaś nazwa
        /// </summary>
        internal static bool CzyJestWPliku(Workbook wbk)
        {
            return SprawdzCzyIstnieje(wbk, NazwaLokalna.Plik);
        }

        /// <summary>
        /// Sprawdza czy w danym arkuszu jest już przypisana jakaś nazwa
        /// </summary>
        internal static bool CzyJestWArkuszu(Worksheet sht)
        {
            return SprawdzCzyIstnieje(sht, NazwaLokalna.Arkusz);
        }

        internal static void Dodaj(Workbook Wbk)
        {
            Wbk.Names.Add(ZnajdzNazweLokalna(NazwaLokalna.Plik), Klucz.GenerujKod(Klucz.TypPliku.Skoroszyt), false);
            Baza.DodajPlik(Wbk);
        }

        internal static void Dodaj(Worksheet Sht, bool daneOsobowe)
        {
            Sht.Names.Add(ZnajdzNazweLokalna(NazwaLokalna.Arkusz), Klucz.GenerujKod(daneOsobowe ? Klucz.TypPliku.DaneOsobowe : Klucz.TypPliku.BezDanychOsobowych));
            Baza.DodajArkusz(Sht, daneOsobowe);
        }        

        public static void ZmienNazwe(Workbook wbk, string nowaNazwa)
        {
            ZmienNazwe(wbk, nowaNazwa, NazwaLokalna.Plik);
        }

        public static void ZmienNazwe(Worksheet sht, string nowaNazwa)
        {
            ZmienNazwe(sht, nowaNazwa, NazwaLokalna.Arkusz);
        }

        public static string ZnajdzNazwe(Workbook wbk)
        {
            return ZnajdzNazwe(wbk, NazwaLokalna.Plik);
        }

        internal static string ZnajdzNazwe(Worksheet sht)
        {
            return ZnajdzNazwe(sht, NazwaLokalna.Arkusz);
        }


        #region Wewnetrzne metody
        private static string ZnajdzNazwe(dynamic obj, NazwaLokalna nazwaLokalna)
        {
            foreach (Name n in obj.Names)
                if (n.NameLocal.Contains(ZnajdzNazweLokalna(nazwaLokalna)))
                    return n.RefersTo;

            return null;
        }

        private static string ZnajdzNazweLokalna(NazwaLokalna nazwa)
        {
            return new string[] { "ANT_Plik", "ANT_Arkusz" }[(int)nazwa];
        }

        private static bool SprawdzCzyIstnieje(dynamic wbk, NazwaLokalna nazwaLokalna)
        {
            try
            {
                foreach (Name n in wbk.Names)
                    if (n.NameLocal.Contains(ZnajdzNazweLokalna(nazwaLokalna)))
                        return true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return false;
        }

        private static void ZmienNazwe(dynamic obj, string nowaNazwa, NazwaLokalna nazwaLokalna)
        {
            foreach (Name n in obj.Names)
                if (n.NameLocal.Contains(ZnajdzNazweLokalna(nazwaLokalna)))
                    n.RefersTo = nowaNazwa;
        }

        enum NazwaLokalna
        {
            Plik,
            Arkusz
        }
        #endregion
    }
}

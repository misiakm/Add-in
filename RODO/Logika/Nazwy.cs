using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace RODO.Logika
{
    public class Nazwy : Klucz
    {       

        /// <summary>
        /// Sprawdza czy w danym skoroszycie jest już przypisana jakaś nazwa
        /// </summary>
        internal bool CzyJestWPliku(Workbook wbk)
        {
            return SprawdzCzyIstnieje(wbk, NazwaLokalna.Plik);
        }

        /// <summary>
        /// Sprawdza czy w danym arkuszu jest już przypisana jakaś nazwa
        /// </summary>
        internal bool CzyJestWArkuszu(Worksheet sht)
        {
            return SprawdzCzyIstnieje(sht, NazwaLokalna.Arkusz);
        }

        internal void Dodaj(Workbook Wbk)
        {
            Baza baza = new Baza();
            Wbk.Names.Add(ZnajdzNazweLokalna(NazwaLokalna.Plik), GenerujKod(TypPliku.Skoroszyt), false);
            baza.DodajPlik(Wbk);
        }

        internal void Dodaj(Worksheet Sht, bool daneOsobowe)
        {
            Baza baza = new Baza();
            Sht.Names.Add(ZnajdzNazweLokalna(NazwaLokalna.Arkusz), GenerujKod(daneOsobowe ? TypPliku.DaneOsobowe : TypPliku.BezDanychOsobowych));
            baza.DodajArkusz(Sht, daneOsobowe);
        }        

        protected void ZmienNazwe(Workbook wbk, string nowaNazwa)
        {
            ZmienNazwe(wbk, nowaNazwa, NazwaLokalna.Plik);
        }

        protected void ZmienNazwe(Worksheet sht, string nowaNazwa)
        {
            ZmienNazwe(sht, nowaNazwa, NazwaLokalna.Arkusz);
        }

        public string ZnajdzNazwe(Workbook wbk)
        {
            return ZnajdzNazwe(wbk, NazwaLokalna.Plik);
        }

        internal string ZnajdzNazwe(Worksheet sht)
        {
            return ZnajdzNazwe(sht, NazwaLokalna.Arkusz);
        }


        #region Wewnetrzne metody
        private string ZnajdzNazwe(dynamic obj, NazwaLokalna nazwaLokalna)
        {
            foreach (Name n in obj.Names)
                if (n.NameLocal.Contains(ZnajdzNazweLokalna(nazwaLokalna)))
                    return n.RefersTo;

            return null;
        }

        private string ZnajdzNazweLokalna(NazwaLokalna nazwa)
        {
            return new string[] { "ANT_Plik", "ANT_Arkusz" }[(int)nazwa];
        }

        private bool SprawdzCzyIstnieje(dynamic wbk, NazwaLokalna nazwaLokalna)
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

        private void ZmienNazwe(dynamic obj, string nowaNazwa, NazwaLokalna nazwaLokalna)
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

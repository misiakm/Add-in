using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RODO.Logika
{
    class DaneOsobowe : Nazwy
    {
        internal bool CzyZbieramyDane(Worksheet sht)
        {
            string klucz = ZnajdzNazwe(sht);
            Regex r = new Regex("DO_*");
            return r.Match(klucz).Success;
        }

        internal void Zmien(bool czyZbieramyDane, Worksheet sht, bool pominOdpowiedz = false)
        {
            Baza baza = new Baza();
            string klucz = ZnajdzNazwe(sht);
            string wartoscPoczatkowa = czyZbieramyDane ?  ZnajdzPoczatek(TypPliku.BezDanychOsobowych) : ZnajdzPoczatek(TypPliku.DaneOsobowe);
            string wartoscKoncowa = czyZbieramyDane ? ZnajdzPoczatek(TypPliku.DaneOsobowe) : ZnajdzPoczatek(TypPliku.BezDanychOsobowych);
            string NowyKlucz = klucz.Replace($"{wartoscPoczatkowa}_", $"{wartoscKoncowa}_");
            if (!pominOdpowiedz)
            {
                baza.DodajOdpowiedz(sht, czyZbieramyDane);
            } 
            baza.ZmienZbieranieDanych(sht, czyZbieramyDane, NowyKlucz);
            ZmienNazwe(sht, NowyKlucz);
            ChangeRibbon.ZmienKarte(sht);
        }
    }
}

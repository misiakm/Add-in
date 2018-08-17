using Microsoft.Office.Interop.Excel;
using RODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RODO.Logika
{
    static class DaneOsobowe
    {
        static RodoDbContext db = new RodoDbContext();

        internal static ZbieranieDanych CzyZbieramyDaneAdmin(Worksheet sht)
        {
            int IdArkusza = Baza.ZnajdzIDArkusza(sht);
            Arkusz arkusz = db.Arkusze.Find(IdArkusza);
            return (ZbieranieDanych)arkusz.ZbieramyDaneAdmin;
        }

        internal static bool CzyZbieramyDane(Worksheet sht)
        {
            string klucz = Nazwy.ZnajdzNazwe(sht);
            Regex r = new Regex("DO_*");
            return r.Match(klucz).Success;
        }

        internal static void Zmien(bool czyZbieramyDane, Worksheet sht, bool pominOdpowiedz = false)
        {
            string klucz = Nazwy.ZnajdzNazwe(sht);
            string wartoscPoczatkowa = czyZbieramyDane ?  Klucz.ZnajdzPoczatek(Klucz.TypPliku.BezDanychOsobowych) : Klucz.ZnajdzPoczatek(Klucz.TypPliku.DaneOsobowe);
            string wartoscKoncowa = czyZbieramyDane ? Klucz.ZnajdzPoczatek(Klucz.TypPliku.DaneOsobowe) : Klucz.ZnajdzPoczatek(Klucz.TypPliku.BezDanychOsobowych);
            string NowyKlucz = klucz.Replace($"{wartoscPoczatkowa}_", $"{wartoscKoncowa}_");
            if (!pominOdpowiedz)
            {
                Baza.DodajOdpowiedz(sht, czyZbieramyDane);
            } 
            Baza.ZmienZbieranieDanych(sht, czyZbieramyDane, NowyKlucz);
            Nazwy.ZmienNazwe(sht, NowyKlucz);
            ChangeRibbon.ZmienKarte(sht);
        }


    }
}

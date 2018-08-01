using Microsoft.Office.Interop.Excel;
using RODO.Models;
using RODO.Models.Pomoc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Logika
{
    class Baza : Nazwy
    {
        RodoDbContext db = new RodoDbContext();

        internal void DodajPlik(Workbook wbk)
        {
            Nazwy nazwy = new Nazwy();
            Plik plik = new Plik
            {
                Klucz = nazwy.ZnajdzNazwe(wbk),
                KtoDodal = Uzytkownicy.UzytkownikID,
                NazwaPliku = wbk.Name,
                Sciezka = wbk.Path                
            };
            db.Pliki.Add(plik);
            db.SaveChanges();
        }

        internal void DodajArkusz(Worksheet sht, bool zbieramyDane)
        {
            Nazwy nazwy = new Nazwy();
            Arkusz arkusz = new Arkusz
            {
                Klucz = nazwy.ZnajdzNazwe(sht),
                Plik = ZnajdzIDPliku(sht.Parent, nazwy),
                NazwaArkusza = sht.Name,
                Uzytkownik = (int)Uzytkownicy.UzytkownikID,
                ZbieramyDane = zbieramyDane
            };
            db.Arkusze.Add(arkusz);
            db.SaveChanges();
        }

        internal void DodajOdpowiedz(Worksheet sht, bool zbieramyDane)
        {
            Nazwy nazwy = new Nazwy();
            Workbook wbk = (Workbook)sht.Parent;
            Odpowiedz odpowiedz = new Odpowiedz
            {
                Arkusz = ZnajdzIDArkusza(sht, nazwy),
                NazwaPliku = wbk.Name,
                Rodzaj = (int)Rodzaje.Uzytkownik,
                Uzytkownik = Uzytkownicy.UzytkownikID,
                Sciezka = wbk.Path,
                ZbieramyDane = zbieramyDane,
                NazwaArkusza = sht.Name
            };
            db.Odpowiedzi.Add(odpowiedz);
            db.SaveChanges();
        }

        internal void DodajLogi(IList<LogiPomoc> logi)
        {
            IList<ArkuszePomoc> arkusze = new List<ArkuszePomoc>();
            foreach (LogiPomoc l in logi)
            {
                Log log = new Log
                {
                    DataDodania = l.DataDodania,
                    NazwaArkusza = l.NazwaArkusz,
                    NazwaPliku = l.NazwaPliku,
                    SciezkaPliku = l.SciezkaPliku,
                    TypAkcji = l.TypAkcji,
                    Uzytkownik = Uzytkownicy.UzytkownikID,
                    Zrodlo = (int)Rodzaje.Uzytkownik,
                    Arkusz = ZnajdzIDArkusza(ref arkusze, l.KluczArkusza),
                    PrzedZmiana = l.PrzedZmiana,
                    PoZmianie = l.PoZmianie
                };
                
                db.Logi.Add(log);
                GC.Collect();
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        internal void ZmienZbieranieDanych(Worksheet sht, bool zbieramyDane, string NowyKlucz)
        {
            string klucz = ZnajdzNazwe(sht);
            Arkusz arkusz = db.Arkusze.Where(x=> x.Klucz == klucz).FirstOrDefault();
            AktualizujArkusz(arkusz, zbieramyDane, NowyKlucz);
        }

        internal void ZmienZbieranieDanych(string staryKlucz, bool zbieramyDane, string nowyKlucz)
        {
            Arkusz arkusz = db.Arkusze.Where(x => x.Klucz == staryKlucz).FirstOrDefault();
            AktualizujArkusz(arkusz, zbieramyDane, nowyKlucz);
        }

        public static bool CzyJestPolaczenie()
        {
            RodoDbContext db = new RodoDbContext();
            return !db.Database.Exists();
        }

        #region Wewnętrzne metody

        private void AktualizujArkusz(Arkusz arkusz, bool zbieramyDane, string nowyKlucz)
        {
            if (arkusz != null)
            {
                arkusz.Klucz = nowyKlucz;
                arkusz.ZbieramyDane = zbieramyDane;
                db.Entry(arkusz).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        private int ZnajdzIDPliku(Workbook wbk, Nazwy nazwy)
        {
            string klucz = nazwy.ZnajdzNazwe(wbk);
            Plik plik = db.Pliki.Where(x => x.Klucz == klucz).FirstOrDefault();
            return plik.ID;
        }

        private int ZnajdzIDArkusza(Worksheet sht, Nazwy nazwy)
        {
            string klucz = nazwy.ZnajdzNazwe(sht);
            Arkusz arkusz = db.Arkusze.Where(x => x.Klucz == klucz).FirstOrDefault();
            return arkusz.ID;
        }

        private int ZnajdzIDArkusza(ref IList<ArkuszePomoc> arkusze, string klucz)
        {
            ArkuszePomoc arkuszPomoc = arkusze.Where(x => x.KluczArkusza == klucz).FirstOrDefault();
            if (arkuszPomoc != null)
            {
                return arkuszPomoc.IDArkusza;
            }
            else
            {
                Arkusz arkusz = db.Arkusze.Where(x => x.Klucz == klucz).FirstOrDefault();
                arkusze.Add(new ArkuszePomoc(klucz, arkusz.ID));
                return arkusz.ID;
            }
        }

        #endregion
    }
}

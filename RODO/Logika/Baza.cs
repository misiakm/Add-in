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
    static class Baza
    {
        static RodoDbContext db = new RodoDbContext();

        internal static void DodajPlik(Workbook wbk)
        {
            Plik plik = new Plik
            {
                Klucz = Nazwy.ZnajdzNazwe(wbk),
                KtoDodal = Uzytkownicy.UzytkownikID,
                NazwaPliku = wbk.Name,
                Sciezka = wbk.Path,
                BiezacaNazwaPliku = wbk.Name
            };
            db.Pliki.Add(plik);
            db.SaveChanges();
        }

        internal static void DodajArkusz(Worksheet sht, bool zbieramyDane)
        {
            Arkusz arkusz = new Arkusz
            {
                Klucz = Nazwy.ZnajdzNazwe(sht),
                Plik = ZnajdzIDPliku(sht.Parent),
                NazwaArkusza = sht.Name,
                Uzytkownik = (int)Uzytkownicy.UzytkownikID,
                ZbieramyDane = zbieramyDane,
                ZbieramyDaneAdmin = 1,
                BiezacaNazwaArkusza = sht.Name
            };
            db.Arkusze.Add(arkusz);
            db.SaveChanges();
        }

        internal static void DodajOdpowiedz(Worksheet sht, bool zbieramyDane)
        {
            Workbook wbk = (Workbook)sht.Parent;
            Odpowiedz odpowiedz = new Odpowiedz
            {
                Arkusz = ZnajdzIDArkusza(sht),
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

        internal static void DodajLogi(IList<LogiPomoc> logi)
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

        internal static void ZmienZbieranieDanych(Worksheet sht, bool zbieramyDane, string NowyKlucz)
        {
            string klucz = Nazwy.ZnajdzNazwe(sht);
            Arkusz arkusz = db.Arkusze.Where(x=> x.Klucz == klucz).FirstOrDefault();
            AktualizujArkusz(arkusz, zbieramyDane, NowyKlucz);
        }

        internal static void ZmienZbieranieDanych(string staryKlucz, bool zbieramyDane, string nowyKlucz)
        {
            Arkusz arkusz = db.Arkusze.Where(x => x.Klucz == staryKlucz).FirstOrDefault();
            AktualizujArkusz(arkusz, zbieramyDane, nowyKlucz);
        }

        internal static void UstawBiezacaNazwe(Worksheet sht)
        {
            int idArkusza = ZnajdzIDArkusza(sht);
            Arkusz arkusz = db.Arkusze.Find(idArkusza);
            if (arkusz != null)
            {
                arkusz.BiezacaNazwaArkusza = sht.Name;
                db.SaveChangesAsync();
            }
            
        }

        internal static void UstawBiezacaNazwe(Workbook wbk)
        {
            int idPliku = ZnajdzIDPliku(wbk);
            Plik plik = db.Pliki.Find(idPliku);
            if (plik != null)
            {
                plik.BiezacaNazwaPliku = wbk.Name;
                db.SaveChangesAsync();
            }
            foreach (Worksheet sht in wbk.Worksheets)
            {
                UstawBiezacaNazwe(sht);
            }
        }

        public static bool CzyJestPolaczenie()
        {
            RodoDbContext db = new RodoDbContext();
            return !db.Database.Exists();
        }

        public static int ZnajdzIDArkusza(Worksheet sht)
        {
            string klucz = Nazwy.ZnajdzNazwe(sht);
            Arkusz arkusz = db.Arkusze.Where(x => x.Klucz == klucz).FirstOrDefault();
            return arkusz.ID;
        }

        #region Wewnętrzne metody



        private static void AktualizujArkusz(Arkusz arkusz, bool zbieramyDane, string nowyKlucz)
        {
            if (arkusz != null)
            {
                arkusz.Klucz = nowyKlucz;
                arkusz.ZbieramyDane = zbieramyDane;
                db.Entry(arkusz).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        private static int ZnajdzIDPliku(Workbook wbk)
        {
            string klucz = Nazwy.ZnajdzNazwe(wbk);
            Plik plik = db.Pliki.Where(x => x.Klucz == klucz).FirstOrDefault();
            return plik.ID;
        }

        

        private static int ZnajdzIDArkusza(ref IList<ArkuszePomoc> arkusze, string klucz)
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

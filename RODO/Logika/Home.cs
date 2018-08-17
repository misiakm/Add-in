using Microsoft.Win32;
using RODO.Models;
using RODO.Models.Pomoc;
using RODO.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace RODO.Logika
{
    class Home
    {
        private static IList<LogiPomoc> logi = new List<LogiPomoc>();

        internal bool CzyStop(ref bool aktywny)
        {
            if (!aktywny)
                return true;
            if (Baza.CzyJestPolaczenie())
            {
                aktywny = false;
                return true;
            }
            Licencja.SprawdzLicencje(ref aktywny);
            if (!aktywny)
            {
                aktywny = false;
                return true;
            }
            Uzytkownicy.SprawdzUzytkownika(ref aktywny);
            if (!aktywny)
            {
                aktywny = false;
                return true;
            }


            return false;
        }

        

        internal void DodajPlikiIArkusze(object Sh)
        {
            bool zapisz = false;
            Excel.Worksheet Sht = (Excel.Worksheet)Sh;
            Excel.Workbook Wbk = Sht.Parent;
            DodajPlik(Wbk);
            DodajArkusze(ref zapisz, Wbk);
            if (zapisz)
                Wbk.Save();
        }

        internal void ZapiszLogi(Excel.Workbook wbk)
        {
            Baza.DodajLogi(logi.Where(x => x.ZbieramyDane == true && x.KluczPliku == Nazwy.ZnajdzNazwe(wbk)).ToList());
            foreach (var item in logi.Where(x => x.ZbieramyDane == true && x.KluczPliku == Nazwy.ZnajdzNazwe(wbk)).ToList())
            {
                logi.Remove(item);
            }
            Baza.UstawBiezacaNazwe(wbk);
        }

        internal void UstawWstazke(Excel.Worksheet activeSheet)
        {
            Wstazka.Sht = activeSheet;
        }

        internal void ZbierzLogSelect(object Sh)
        {
            Excel.Worksheet sht = (Excel.Worksheet)Sh;
            Excel.Workbook wbk = (Excel.Workbook)sht.Parent;
            if (DaneOsobowe.CzyZbieramyDane(sht))
            {
                if (CzyOstatni(sht, wbk))
                {
                    logi.Add(new LogiPomoc(Nazwy.ZnajdzNazwe(sht),sht.Name, Nazwy.ZnajdzNazwe(wbk), wbk.Name, wbk.Path, TypyAkcji.Select, true));
                }
            }
            else
            {
                if (CzyOstatniBrak())
                {
                    logi.Add(new LogiPomoc("BRAK", "BRAK", "BRAK", "BRAK", "BRAK", TypyAkcji.Select, false));
                }
            }
        }

        internal void SprawdzZbieranieDanych(Excel.Workbook wb)
        {
            RodoDbContext db = new RodoDbContext();
            foreach (Excel.Worksheet sht in wb.Worksheets)
            {
                string klucz = Nazwy.ZnajdzNazwe(sht);
                Arkusz arkusz = db.Arkusze.Where(x => x.Klucz == klucz).FirstOrDefault();
                if (arkusz != null)
                {
                    if (DaneOsobowe.CzyZbieramyDane(sht) != arkusz.ZbieramyDane)
                    {
                        DaneOsobowe.Zmien(arkusz.ZbieramyDane, sht, arkusz.ZbieramyDane);
                    }
                }                
            }
        }

        internal void ZbierzLogEdit(object Sh, TypyAkcji typ, string staraWartosc, string nowaWartosc)
        {
            Excel.Worksheet sht = (Excel.Worksheet)Sh;
            Excel.Workbook wbk = (Excel.Workbook)sht.Parent;
            if (DaneOsobowe.CzyZbieramyDane(sht))
            {
                logi.Add(new LogiPomoc(Nazwy.ZnajdzNazwe(sht), sht.Name, Nazwy.ZnajdzNazwe(wbk), wbk.Name, wbk.Path, typ, true, staraWartosc, nowaWartosc));
            }
        }

        #region Wewnetrzne metody

        private void DodajArkusze(ref bool zapisz, Excel.Workbook Wbk)
        {
            foreach (Excel.Worksheet Arkusz in Wbk.Worksheets)
            {
                if (!Nazwy.CzyJestWArkuszu(Arkusz))
                {
                    DodajArkusz(Arkusz);
                    zapisz = (Wbk.Path ?? "") != "";
                }
            }
        }

        private static void DodajArkusz(Excel.Worksheet Arkusz)
        {
            CzyOsobowe czyOsobowe = new CzyOsobowe();
            czyOsobowe.ZmienNapis(Arkusz.Name);
            czyOsobowe.Arkusz = Arkusz;
            czyOsobowe.ShowDialog();
        }

        private void DodajPlik(Excel.Workbook Wbk)
        {
            if (!Nazwy.CzyJestWPliku(Wbk))
                Nazwy.Dodaj(Wbk);


        }

        private static bool CzyOstatni(Excel.Worksheet sht, Excel.Workbook wbk)
        {
            try
            {
                LogiPomoc ostatni = logi.LastOrDefault();
                return (ostatni.KluczPliku != Nazwy.ZnajdzNazwe(wbk) && ostatni.KluczArkusza != Nazwy.ZnajdzNazwe(sht)) || logi.Count == 0;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        private bool CzyOstatniBrak()
        {
            try
            {
                LogiPomoc ostatni = logi.LastOrDefault();
                return (ostatni.KluczPliku != "BRAK");
            }
            catch (Exception e)
            {
                return true;
            }
        }

        #endregion
    }
}

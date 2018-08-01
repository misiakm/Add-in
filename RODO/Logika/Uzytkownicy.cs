using RODO.Models;
using RODO.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Logika
{
    class Uzytkownicy
    {
        private static int? uzytkownikID;

        static public int? UzytkownikID
        {
            get
            {
                if (uzytkownikID == null)
                {
                    RodoDbContext db = new RodoDbContext();
                    Uzytkownik uzytkownik = db.Uzytkownicy
                        .Where(x => x.NazwaUzytkownika == Environment.UserName && x.NazwaKomputera == Environment.MachineName && x.Aktywny == true)
                        .FirstOrDefault();

                    if (uzytkownik != null)
                        uzytkownikID = uzytkownik.ID;
                    
                }
                return uzytkownikID;
            }

            set
            {
                uzytkownikID = value;
            }
        }

        public static void SprawdzUzytkownika(ref bool aktywny)
        {
            if (UzytkownikID == null)
            {
                aktywny = false;
                new NieAktywny().Show();
            } else
            {
                aktywny = true;
            }
        }

        public static void SprawdzUzytkownika()
        {
            if (UzytkownikID == null)
            {
                new NieAktywny().Show();
            }
        }

    }
}

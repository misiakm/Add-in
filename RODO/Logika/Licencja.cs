using Microsoft.Win32;
using RODO.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Logika
{
    class Licencja
    {
        public static void SprawdzLicencje(ref bool aktywny)
        {
            if (DateTime.Now.Date > Rejestr.Data)
            {
                aktywny = false;
                new KoniecLicencji().Show();
            }
        }
    }
}

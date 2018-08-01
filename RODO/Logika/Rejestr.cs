using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Logika
{
    static class Rejestr
    {
        private const string klucz = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\AntheapRodo";

        private static DateTime data;
        public static DateTime Data
        {
            get
            {                
                const string nazwaWartosci = "Data";
                string wartoscDomyslna = DateTime.Now.Date.AddDays(-1).ToString();
                return DateTime.Parse(Registry.GetValue(klucz, nazwaWartosci, wartoscDomyslna).ToString());
            }
        }

        private static string sciezka;
        public static string Sciezka
        {
            get
            {
                const string nazwaWartosci = "Sciezka";
                return Registry.GetValue(klucz, nazwaWartosci,"").ToString();
            }
        }


    }
}

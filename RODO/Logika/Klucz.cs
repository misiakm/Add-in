using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RODO.Logika
{
    public static class Klucz
    {
        public enum TypPliku
        {
            Skoroszyt = 1,
            DaneOsobowe = 2,
            BezDanychOsobowych = 3
        }

        /// <summary>
        /// Generuje kod do arkusza i pliku
        /// </summary>
        public static string GenerujKod(TypPliku typ)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABDEFGHIJKLMNOPQRTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int dlugosc = 16;
            while (0 < dlugosc--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return $"{ZnajdzPoczatek(typ)}_{res.ToString()}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
        }

        public static string ZnajdzPoczatek(TypPliku typ)
        {
            switch (typ)
            {
                case TypPliku.Skoroszyt:
                    return "SK";
                case TypPliku.DaneOsobowe:
                    return "DO";
                case TypPliku.BezDanychOsobowych:
                    return "BD";
            }

            return "";
        }
    }
}

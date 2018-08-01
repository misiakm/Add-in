using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using RODO.Logika;
using RODO.UserForms;

namespace RODO
{
    public partial class Wstazka
    {
        public static Worksheet Sht { get; set; }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Process.Start("http://heap.pl");
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Informacja informacja = new Informacja(Sht);
            informacja.Show();
        }

        private void ArkuszZastrzezony_Click(object sender, RibbonControlEventArgs e)
        {
            ZmienStatus(true);
        }

        private void ArkuszWolny_Click(object sender, RibbonControlEventArgs e)
        {
            ZmienStatus(false);
        }

        private static void ZmienStatus(bool zbieramyDane)
        {
            DaneOsobowe dane = new DaneOsobowe();
            dane.Zmien(zbieramyDane, Sht);
            Informacja informacja = new Informacja(Sht);
            informacja.Show();
        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Przycisk!");
        }
    }
}

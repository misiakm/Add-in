using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using RODO.Logika;
using RODO.UserForms;
using RODO.Models;
using RODO.Models.Pomoc;
using System.Threading;


namespace RODO
{
    /// <summary>
    /// sdfg
    /// </summary>
    public partial class ThisAddIn
    {
        private static bool aktywny = true;
        Home home = new Home();
        private string StaraWartosc { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

            try
            {
                if (home.CzyStop(ref aktywny))
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.HelpLink);
            }
            Application.SheetSelectionChange += new Excel.AppEvents_SheetSelectionChangeEventHandler(OnSelection);
            Application.SheetChange += new Excel.AppEvents_SheetChangeEventHandler(OnChange);
            Application.SheetActivate += new Excel.AppEvents_SheetActivateEventHandler(OnSheetActivate);
            Application.WorkbookBeforeClose += new Excel.AppEvents_WorkbookBeforeCloseEventHandler(BeforeCloese);
            Application.WorkbookOpen += new Excel.AppEvents_WorkbookOpenEventHandler(OnOpen);
            Application.WorkbookAfterSave += new Excel.AppEvents_WorkbookAfterSaveEventHandler(AfterSave);
            
        }


        private void AfterSave(Excel.Workbook Wb, bool Success)
        {
            home.ZapiszLogi(Wb);
        }

        private void OnOpen(Excel.Workbook Wb)
        {
            if (home.CzyStop(ref aktywny))
                return;
            home.SprawdzZbieranieDanych(Wb);
            home.UstawWstazke(Wb.ActiveSheet);
            home.DodajPlikiIArkusze(Wb.ActiveSheet);
            home.ZbierzLogSelect(Wb.ActiveSheet);
            ChangeRibbon.ZmienKarte(Wb.ActiveSheet);
        }

        private void OnSheetActivate(object Sh)
        {
            if (home.CzyStop(ref aktywny))
                return;
            home.UstawWstazke((Excel.Worksheet)Sh);
            home.DodajPlikiIArkusze(Sh);
            home.ZbierzLogSelect(Sh);
            ChangeRibbon.ZmienKarte((Excel.Worksheet)Sh);
        }

        private void BeforeCloese(Excel.Workbook Wb, ref bool Cancel)
        {
            home.ZapiszLogi(Wb);
        }

        private void OnChange(object Sh, Excel.Range Target)
        {
            string wartosc = TworzWartosc(Target);
            if (StaraWartosc == wartosc)
            {
                return;
            }
            if (wartosc != "" && StaraWartosc == "")
            {
                zbierzLog(TypyAkcji.Insert);
            }
            else if (wartosc != "" && StaraWartosc != "")
            {
                zbierzLog(TypyAkcji.Update);
            }
            else if (wartosc == "" && StaraWartosc != "")
            {
                zbierzLog(TypyAkcji.Delete);
            }

            void zbierzLog(TypyAkcji typ)
            {
                home.ZbierzLogEdit(Sh, typ, StaraWartosc, wartosc);
            }
        }

        private void OnSelection(object Sh, Excel.Range Target)
        {
            if (home.CzyStop(ref aktywny))
                return;
            home.DodajPlikiIArkusze(Sh);
            home.ZbierzLogSelect(Sh);
            StaraWartosc = TworzWartosc(Target);
            ChangeRibbon.ZmienKarte((Excel.Worksheet)Sh);
        }

        private string TworzWartosc(Excel.Range Target)
        {
            string wartosc = "";
            if (Target.Count > 1)
            {
                foreach (var item in Target.Value)
                {
                    if (item != "" && item != null) wartosc += item + ";";
                }
                wartosc = wartosc.TrimEnd(';');
            }
            else
            {
                wartosc = Target.Value;
            }
            return wartosc;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Kod wygenerowany przez program VSTO

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

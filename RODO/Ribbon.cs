using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;

// TODO:  Wykonaj poniższe kroki, aby włączyć element wstążki (XML):

// 1: Skopiuj następujący blok kodu do klasy ThisAddin, ThisWorkbook lub ThisDocument.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Utwórz metody wywołania zwrotnego w obszarze „Wywołania zwrotne wstążki” tej klasy, aby obsługiwać
//    akcje użytkownika, takie jak kliknięcie przycisku. Uwaga: jeśli wyeksportowano tę wstążkę z Projektanta wstążek,
//    przenieś swój kod z procedur obsługi zdarzeń do metod wywołania zwrotnego i zmodyfikuj kod do działania z
//    z modelem programowania rozszerzalności wstążki (RibbonX).

// 3. Przypisz atrybuty do tagów formantów w pliku XML wstążki, aby zidentyfikować w swoim kodzie odpowiednie metody wywołania zwrotnego.  

// Aby uzyskać więcej informacji, zobacz dokumentację kodu XML wstążki w Pomocy programu Visual Studio Tools for Office.


namespace RODO
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon()
        {
        }

        #region Składowe interfejsu IRibbonExtensibility

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("RODO.Ribbon.xml");
        }

        #endregion

        #region Wywołania zwrotne wstążki
        //Tutaj możesz tworzyć metody wywołań zwrotnych. Aby uzyskać więcej informacji na temat dodawania metod wywołań zwrotnych, odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Pomocnicy

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}

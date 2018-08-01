using RODO.Logika;

namespace RODO
{
    partial class Wstazka : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Wstazka()
            : base(Globals.Factory.GetRibbonFactory())
        {
            ChangeRibbon.wstazka = this; 
            InitializeComponent();
        }

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.TabDaneOsobowe = this.Factory.CreateRibbonTab();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.ArkuszZastrzezony = this.Factory.CreateRibbonButton();
            this.ArkuszWolny = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group2.SuspendLayout();
            this.TabDaneOsobowe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "Antheap (RODO)";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.ArkuszZastrzezony);
            this.group1.Items.Add(this.ArkuszWolny);
            this.group1.Label = "Arkusz";
            this.group1.Name = "group1";
            // 
            // group3
            // 
            this.group3.Items.Add(this.button3);
            this.group3.Label = "Plik";
            this.group3.Name = "group3";
            this.group3.Visible = false;
            // 
            // group2
            // 
            this.group2.Items.Add(this.button2);
            this.group2.Label = "www.heap.pl";
            this.group2.Name = "group2";
            // 
            // TabDaneOsobowe
            // 
            this.TabDaneOsobowe.Label = "Dane osobowe";
            this.TabDaneOsobowe.Name = "TabDaneOsobowe";
            // 
            // button4
            // 
            this.button4.Label = "button4";
            this.button4.Name = "button4";
            this.button4.ShowImage = true;
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = global::RODO.Properties.Resources.Info__0033b5_128px;
            this.button1.Label = "Informacja o arkuszu";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // ArkuszZastrzezony
            // 
            this.ArkuszZastrzezony.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ArkuszZastrzezony.Image = global::RODO.Properties.Resources.Close__a80000_128px;
            this.ArkuszZastrzezony.Label = "Dane osobowe";
            this.ArkuszZastrzezony.Name = "ArkuszZastrzezony";
            this.ArkuszZastrzezony.ShowImage = true;
            this.ArkuszZastrzezony.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ArkuszZastrzezony_Click);
            // 
            // ArkuszWolny
            // 
            this.ArkuszWolny.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ArkuszWolny.Image = global::RODO.Properties.Resources.Checked__10bd00_128px;
            this.ArkuszWolny.Label = "Brak danych osobowych";
            this.ArkuszWolny.Name = "ArkuszWolny";
            this.ArkuszWolny.ShowImage = true;
            this.ArkuszWolny.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ArkuszWolny_Click);
            // 
            // button3
            // 
            this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button3.Image = global::RODO.Properties.Resources.Info__f08000_128px;
            this.button3.Label = "Informacje o pliku";
            this.button3.Name = "button3";
            this.button3.ShowImage = true;
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Image = global::RODO.Properties.Resources.AntHeap_sygnet_RGB;
            this.button2.Label = " Antheap";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // Wstazka
            // 
            this.Name = "Wstazka";
            // 
            // Wstazka.OfficeMenu
            // 
            this.OfficeMenu.Items.Add(this.button4);
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.TabDaneOsobowe);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.TabDaneOsobowe.ResumeLayout(false);
            this.TabDaneOsobowe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ArkuszZastrzezony;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ArkuszWolny;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        public Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabDaneOsobowe;
    }

    partial class ThisRibbonCollection
    {
        internal Wstazka Wstazka
        {
            get { return this.GetRibbon<Wstazka>(); }
        }
    }
}

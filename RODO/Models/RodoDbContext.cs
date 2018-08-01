namespace RODO.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Data.Entity.Infrastructure;
    using System.Data.Common;
    using RODO.Logika;
    using System.Windows.Forms;
    using System.Data;
    using Microsoft.Win32;

    public partial class RodoDbContext : DbContext
    {
        public RodoDbContext()
            : base(Cs(), true)
        {

        }
        //@"data source=DESKTOP-GFH20OM\SQLEXPRESS;Database=RODO_C_SHARP;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
        private static DbConnection Cs()
        {

            //var conn = DbProviderFactories.GetFactory("JetEntityFrameworkProvider").CreateConnection();
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OleDb.12.0;Data source=" + Path.Combine(Rejestr.Sciezka, "baza.accdb");
            ////MessageBox.Show(conn.ConnectionString);
            ////conn.ConnectionString = @"Provider=Microsoft.ACE.OleDb.12.0;Data source=E:\Test.accdb";
            ////conn.Open();
            //return conn;


            //string connStr = @"Provider=Microsoft.ACE.OleDb.16.0;Data source=" + Path.Combine(Rejestr.Sciezka, "baza.accdb");
            //string connStr = @"Provider=Microsoft.Jet.OleDb.4.0;Data source=E:\Test.accdb";
            //string providerName = null;
            //var csb = new DbConnectionStringBuilder { ConnectionString = connStr};

            //if (csb.ContainsKey("provider"))
            //{
            //    providerName = csb["provider"].ToString();
            //}
            //else
            //{
            //    //var css = ConfigurationManager
            //    //                  .ConnectionStrings
            //    //                  .Cast<ConnectionStringSettings>()
            //    //                  .FirstOrDefault(x => x.ConnectionString == connStr);
            //    //if (css != null) providerName = css.ProviderName;
            //}
            //providerName = "JetEntityFrameworkProvider";
            //if (providerName != null)
            //{
            //    var providerExists = DbProviderFactories
            //                                .GetFactoryClasses()
            //                                .Rows.Cast<DataRow>()
            //                                .Any(r => r[2].Equals(providerName));
            //    if (providerExists)
            //    {
            //        var factory = DbProviderFactories.GetFactory(providerName);
            //        var dbConnection = factory.CreateConnection();

            //        dbConnection.ConnectionString = connStr;
            //        return dbConnection;
            //    }
            //}
            //return null;


            const string klucz = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\AntheapRodo";
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = Registry.GetValue(klucz, "sciezka", "0").ToString(); ;
            return dbConnection;
        }

        public DbSet<Arkusz> Arkusze { get; set; }
        public DbSet<Log> Logi { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Plik> Pliki { get; set; }
        public DbSet<Odpowiedz> Odpowiedzi { get; set; }
        public DbSet<ZrodloAkcji> ZrodlaAkcji { get; set; }
        public DbSet<TypAkcji> TypyAkcji { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

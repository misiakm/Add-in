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
        private static DbConnection Cs()
        {
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

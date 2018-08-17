namespace RODO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RODO.Models.RodoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RODO.Models.RodoDbContext context)
        {
            context.ZrodlaAkcji.AddOrUpdate(x => x.ID,
                new Models.ZrodloAkcji() { ID = 1, Nazwa = "U¿ytkownik" },
                new Models.ZrodloAkcji() { ID = 2, Nazwa = "Admin" },
                new Models.ZrodloAkcji() { ID = 3, Nazwa = "System" }
                );

            context.ZbieramyDaneAdmin.AddOrUpdate(x => x.ID,
                new Models.ZbieramyDaneAdmin() { ID = 1, ZbieramyDane = "Domyœlne" },
                new Models.ZbieramyDaneAdmin() { ID = 2, ZbieramyDane = "Tak" },
                new Models.ZbieramyDaneAdmin() { ID = 3, ZbieramyDane = "Nie" }
                );

            context.TypyAkcji.AddOrUpdate(x => x.ID,
                new Models.TypAkcji() { ID = 1, Nazwa = "Select" },
                new Models.TypAkcji() { ID = 2, Nazwa = "Update" },
                new Models.TypAkcji() { ID = 3, Nazwa = "Delete" },
                new Models.TypAkcji() { ID = 4, Nazwa = "Insert" }
                );
        }
    }
}

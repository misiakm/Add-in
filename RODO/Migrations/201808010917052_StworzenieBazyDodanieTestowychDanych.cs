namespace RODO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StworzenieBazyDodanieTestowychDanych : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arkusze",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NazwaArkusza = c.String(nullable: false, unicode: false),
                        Klucz = c.String(nullable: false, unicode: false),
                        BiezacaNazwaArkusz = c.String(unicode: false),
                        Plik = c.Int(nullable: false),
                        Uzytkownik = c.Int(nullable: false),
                        ZbieramyDane = c.Boolean(nullable: false),
                        ZbieramyDaneAdmin = c.Int(nullable: false),
                        ZbieramyDaneSystem = c.Boolean(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pliki", t => t.Plik, cascadeDelete: true)
                .ForeignKey("dbo.Uzytkownicy", t => t.Uzytkownik, cascadeDelete: true)
                .ForeignKey("dbo.ZbieramyDaneAdmin", t => t.ZbieramyDaneAdmin, cascadeDelete: true)
                .Index(t => t.Plik)
                .Index(t => t.Uzytkownik)
                .Index(t => t.ZbieramyDaneAdmin);
            
            CreateTable(
                "dbo.Logi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Uzytkownik = c.Int(),
                        Arkusz = c.Int(nullable: false),
                        NazwaArkusza = c.String(nullable: false, unicode: false),
                        NazwaPliku = c.String(nullable: false, unicode: false),
                        SciezkaPliku = c.String(unicode: false),
                        PrzedZmiana = c.String(unicode: false),
                        PoZmianie = c.String(unicode: false),
                        Zrodlo = c.Int(nullable: false),
                        TypAkcji = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arkusze", t => t.Arkusz, cascadeDelete: true)
                .ForeignKey("dbo.TypyAkcji", t => t.TypAkcji, cascadeDelete: true)
                .ForeignKey("dbo.Uzytkownicy", t => t.Uzytkownik)
                .ForeignKey("dbo.ZrodlaAkcji", t => t.Zrodlo, cascadeDelete: true)
                .Index(t => t.Uzytkownik)
                .Index(t => t.Arkusz)
                .Index(t => t.Zrodlo)
                .Index(t => t.TypAkcji);
            
            CreateTable(
                "dbo.Odpowiedzi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Arkusz = c.Int(nullable: false),
                        NazwaArkusza = c.String(nullable: false, unicode: false),
                        Uzytkownik = c.Int(),
                        Sciezka = c.String(unicode: false),
                        NazwaPliku = c.String(nullable: false, unicode: false),
                        ZbieramyDane = c.Boolean(nullable: false),
                        Rodzaj = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arkusze", t => t.Arkusz, cascadeDelete: true)
                .ForeignKey("dbo.Uzytkownicy", t => t.Uzytkownik)
                .Index(t => t.Arkusz)
                .Index(t => t.Uzytkownik);
            
            CreateTable(
                "dbo.Pliki",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NazwaPliku = c.String(nullable: false, unicode: false),
                        Sciezka = c.String(unicode: false),
                        BiezacaNazwaPliku = c.String(nullable: false, unicode: false),
                        Klucz = c.String(nullable: false, unicode: false),
                        KtoDodal = c.Int(),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Uzytkownicy", t => t.KtoDodal)
                .Index(t => t.KtoDodal);
            
            CreateTable(
                "dbo.TypyAkcji",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Uzytkownicy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NazwaKomputera = c.String(nullable: false, unicode: false),
                        NazwaUzytkownika = c.String(nullable: false, unicode: false),
                        Aktywny = c.Boolean(nullable: false),
                        Imie = c.String(unicode: false),
                        Nazwisko = c.String(unicode: false),
                        Haslo = c.String(unicode: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZbieramyDaneAdmin",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ZbieramyDane = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZrodlaAkcji",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logi", "Zrodlo", "dbo.ZrodlaAkcji");
            DropForeignKey("dbo.Arkusze", "ZbieramyDaneAdmin", "dbo.ZbieramyDaneAdmin");
            DropForeignKey("dbo.Odpowiedzi", "Uzytkownik", "dbo.Uzytkownicy");
            DropForeignKey("dbo.Logi", "Uzytkownik", "dbo.Uzytkownicy");
            DropForeignKey("dbo.Pliki", "KtoDodal", "dbo.Uzytkownicy");
            DropForeignKey("dbo.Arkusze", "Uzytkownik", "dbo.Uzytkownicy");
            DropForeignKey("dbo.Logi", "TypAkcji", "dbo.TypyAkcji");
            DropForeignKey("dbo.Arkusze", "Plik", "dbo.Pliki");
            DropForeignKey("dbo.Odpowiedzi", "Arkusz", "dbo.Arkusze");
            DropForeignKey("dbo.Logi", "Arkusz", "dbo.Arkusze");
            DropIndex("dbo.Pliki", new[] { "KtoDodal" });
            DropIndex("dbo.Odpowiedzi", new[] { "Uzytkownik" });
            DropIndex("dbo.Odpowiedzi", new[] { "Arkusz" });
            DropIndex("dbo.Logi", new[] { "TypAkcji" });
            DropIndex("dbo.Logi", new[] { "Zrodlo" });
            DropIndex("dbo.Logi", new[] { "Arkusz" });
            DropIndex("dbo.Logi", new[] { "Uzytkownik" });
            DropIndex("dbo.Arkusze", new[] { "ZbieramyDaneAdmin" });
            DropIndex("dbo.Arkusze", new[] { "Uzytkownik" });
            DropIndex("dbo.Arkusze", new[] { "Plik" });
            DropTable("dbo.ZrodlaAkcji");
            DropTable("dbo.ZbieramyDaneAdmin");
            DropTable("dbo.Uzytkownicy");
            DropTable("dbo.TypyAkcji");
            DropTable("dbo.Pliki");
            DropTable("dbo.Odpowiedzi");
            DropTable("dbo.Logi");
            DropTable("dbo.Arkusze");
        }
    }
}

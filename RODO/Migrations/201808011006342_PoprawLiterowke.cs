namespace RODO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawLiterowke : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arkusze", "BiezacaNazwaArkusza", c => c.String(unicode: false));
            DropColumn("dbo.Arkusze", "BiezacaNazwaArkusz");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arkusze", "BiezacaNazwaArkusz", c => c.String(unicode: false));
            DropColumn("dbo.Arkusze", "BiezacaNazwaArkusza");
        }
    }
}

namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectorLengthInMinutesShortDescriptionToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Director", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "LengthInMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ShortDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ShortDescription");
            DropColumn("dbo.Movies", "LengthInMinutes");
            DropColumn("dbo.Movies", "Director");
        }
    }
}

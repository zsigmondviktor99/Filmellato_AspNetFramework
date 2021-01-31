namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityCardToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IdentityCard", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IdentityCard");
        }
    }
}

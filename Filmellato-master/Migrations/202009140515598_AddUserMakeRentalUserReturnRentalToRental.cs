namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserMakeRentalUserReturnRentalToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "UserMakeRental", c => c.String(nullable: false));
            AddColumn("dbo.Rentals", "UserReturnRental", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "UserReturnRental");
            DropColumn("dbo.Rentals", "UserMakeRental");
        }
    }
}

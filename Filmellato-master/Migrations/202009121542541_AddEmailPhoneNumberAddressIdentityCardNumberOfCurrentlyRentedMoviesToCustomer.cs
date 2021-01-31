namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailPhoneNumberAddressIdentityCardNumberOfCurrentlyRentedMoviesToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "IdentityCard", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "NumberOfCurrentlyRentedMovies", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NumberOfCurrentlyRentedMovies");
            DropColumn("dbo.Customers", "IdentityCard");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "Email");
        }
    }
}

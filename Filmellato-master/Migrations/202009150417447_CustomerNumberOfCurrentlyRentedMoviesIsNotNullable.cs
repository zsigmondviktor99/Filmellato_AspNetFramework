namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNumberOfCurrentlyRentedMoviesIsNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "NumberOfCurrentlyRentedMovies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NumberOfCurrentlyRentedMovies", c => c.Int());
        }
    }
}

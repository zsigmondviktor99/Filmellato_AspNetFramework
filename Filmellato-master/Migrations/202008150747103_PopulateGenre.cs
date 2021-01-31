namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreName) VALUES ('Vígjáték')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Akció')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Családi')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Romantikus')");
        }
        
        public override void Down()
        {
        }
    }
}

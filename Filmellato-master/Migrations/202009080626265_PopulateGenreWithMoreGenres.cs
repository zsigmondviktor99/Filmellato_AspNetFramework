namespace Filmellato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreWithMoreGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreName) VALUES ('Kaland')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Krimi')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Dráma')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Horror')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Thriller')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Politikai')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Science fiction')");
        }
        
        public override void Down()
        {
        }
    }
}

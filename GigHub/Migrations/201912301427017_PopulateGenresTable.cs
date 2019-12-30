namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Blues')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Metal')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4,5,6");
        }
    }
}

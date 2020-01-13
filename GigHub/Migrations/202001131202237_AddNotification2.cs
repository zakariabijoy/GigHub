namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Gig_Id", c => c.Int());
            CreateIndex("dbo.Notifications", "Gig_Id");
            AddForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs");
            DropIndex("dbo.Notifications", new[] { "Gig_Id" });
            DropColumn("dbo.Notifications", "Gig_Id");
        }
    }
}

namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Civilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Capacite = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UserID = c.Int(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: true)
                .Index(t => t.CivilityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "CivilityID", "dbo.Civilities");
            DropForeignKey("dbo.Rooms", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "CivilityID" });
            DropIndex("dbo.Rooms", new[] { "CategoryID" });
            DropIndex("dbo.Rooms", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Civilities");
            DropTable("dbo.Categories");
        }
    }
}

namespace Moshavit.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        IdMessage = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.IdMessage);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        IdSurvey = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Question = c.String(),
                        Yes = c.Int(nullable: false),
                        No = c.Int(nullable: false),
                        Avoid = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdSurvey);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        IsResident = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Token = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.VotedList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSurvey = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        VoteTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BabySitter",
                c => new
                    {
                        IdMessage = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMessage)
                .ForeignKey("dbo.Messages", t => t.IdMessage)
                .Index(t => t.IdMessage);
            
            CreateTable(
                "dbo.BulletinBoard",
                c => new
                    {
                        IdMessage = c.Int(nullable: false),
                        Description = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.IdMessage)
                .ForeignKey("dbo.Messages", t => t.IdMessage)
                .Index(t => t.IdMessage);
            
            CreateTable(
                "dbo.CarPull",
                c => new
                    {
                        IdMessage = c.Int(nullable: false),
                        From = c.String(),
                        To = c.String(),
                        PickUp = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMessage)
                .ForeignKey("dbo.Messages", t => t.IdMessage)
                .Index(t => t.IdMessage);
            
            CreateTable(
                "dbo.GiveAndTake",
                c => new
                    {
                        IdMessage = c.Int(nullable: false),
                        Description = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                    })
                .PrimaryKey(t => t.IdMessage)
                .ForeignKey("dbo.Messages", t => t.IdMessage)
                .Index(t => t.IdMessage);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiveAndTake", "IdMessage", "dbo.Messages");
            DropForeignKey("dbo.CarPull", "IdMessage", "dbo.Messages");
            DropForeignKey("dbo.BulletinBoard", "IdMessage", "dbo.Messages");
            DropForeignKey("dbo.BabySitter", "IdMessage", "dbo.Messages");
            DropIndex("dbo.GiveAndTake", new[] { "IdMessage" });
            DropIndex("dbo.CarPull", new[] { "IdMessage" });
            DropIndex("dbo.BulletinBoard", new[] { "IdMessage" });
            DropIndex("dbo.BabySitter", new[] { "IdMessage" });
            DropTable("dbo.GiveAndTake");
            DropTable("dbo.CarPull");
            DropTable("dbo.BulletinBoard");
            DropTable("dbo.BabySitter");
            DropTable("dbo.VotedList");
            DropTable("dbo.Users");
            DropTable("dbo.Survey");
            DropTable("dbo.Messages");
        }
    }
}

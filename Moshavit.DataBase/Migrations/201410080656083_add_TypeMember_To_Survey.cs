namespace Moshavit.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_TypeMember_To_Survey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BabySitter", "IdMessage", "dbo.Messages");
            DropForeignKey("dbo.BulletinBoard", "IdMessage", "dbo.Messages");
            DropForeignKey("dbo.CarPull", "IdMessage", "dbo.Messages");
            DropForeignKey("dbo.GiveAndTake", "IdMessage", "dbo.Messages");
            DropIndex("dbo.BabySitter", new[] { "IdMessage" });
            DropIndex("dbo.BulletinBoard", new[] { "IdMessage" });
            DropIndex("dbo.CarPull", new[] { "IdMessage" });
            DropIndex("dbo.GiveAndTake", new[] { "IdMessage" });
            AddColumn("dbo.Survey", "TypeMember", c => c.Int(nullable: false));
            CreateIndex("dbo.BabySitter", "IdMessage");
            CreateIndex("dbo.BulletinBoard", "IdMessage");
            CreateIndex("dbo.CarPull", "IdMessage");
            CreateIndex("dbo.GiveAndTake", "IdMessage");
            AddForeignKey("dbo.BabySitter", "IdMessage", "dbo.Messages", "IdMessage");
            AddForeignKey("dbo.BulletinBoard", "IdMessage", "dbo.Messages", "IdMessage");
            AddForeignKey("dbo.CarPull", "IdMessage", "dbo.Messages", "IdMessage");
            AddForeignKey("dbo.GiveAndTake", "IdMessage", "dbo.Messages", "IdMessage");
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
            DropColumn("dbo.Survey", "TypeMember");
            CreateIndex("dbo.GiveAndTake", "IdMessage");
            CreateIndex("dbo.CarPull", "IdMessage");
            CreateIndex("dbo.BulletinBoard", "IdMessage");
            CreateIndex("dbo.BabySitter", "IdMessage");
            AddForeignKey("dbo.GiveAndTake", "IdMessage", "dbo.Messages", "IdMessage");
            AddForeignKey("dbo.CarPull", "IdMessage", "dbo.Messages", "IdMessage");
            AddForeignKey("dbo.BulletinBoard", "IdMessage", "dbo.Messages", "IdMessage");
            AddForeignKey("dbo.BabySitter", "IdMessage", "dbo.Messages", "IdMessage");
        }
    }
}

namespace Moshavit.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Email_Template : DbMigration
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
            CreateTable(
                "dbo.EmailTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.EmailTemplate");
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

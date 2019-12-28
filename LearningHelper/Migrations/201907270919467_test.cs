namespace LearningHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChatBoxes", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.ChatBoxes", "User1_Id", "dbo.Users");
            DropIndex("dbo.ChatBoxes", new[] { "User_Id2" });
            DropIndex("dbo.ChatBoxes", new[] { "User1_Id" });
            RenameColumn(table: "dbo.ChatBoxes", name: "User_Id2", newName: "ReceiverId");
            RenameColumn(table: "dbo.ChatBoxes", name: "User1_Id", newName: "SenderId");
            AlterColumn("dbo.ChatBoxes", "ReceiverId", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatBoxes", "SenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChatBoxes", "SenderId");
            CreateIndex("dbo.ChatBoxes", "ReceiverId");
            AddForeignKey("dbo.ChatBoxes", "ReceiverId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChatBoxes", "SenderId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.ChatBoxes", "Sender");
            DropColumn("dbo.ChatBoxes", "Receiver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChatBoxes", "Receiver", c => c.Int(nullable: false));
            AddColumn("dbo.ChatBoxes", "Sender", c => c.Int(nullable: false));
            DropForeignKey("dbo.ChatBoxes", "SenderId", "dbo.Users");
            DropForeignKey("dbo.ChatBoxes", "ReceiverId", "dbo.Users");
            DropIndex("dbo.ChatBoxes", new[] { "ReceiverId" });
            DropIndex("dbo.ChatBoxes", new[] { "SenderId" });
            AlterColumn("dbo.ChatBoxes", "SenderId", c => c.Int());
            AlterColumn("dbo.ChatBoxes", "ReceiverId", c => c.Int());
            RenameColumn(table: "dbo.ChatBoxes", name: "SenderId", newName: "User1_Id");
            RenameColumn(table: "dbo.ChatBoxes", name: "ReceiverId", newName: "User_Id2");
            CreateIndex("dbo.ChatBoxes", "User1_Id");
            CreateIndex("dbo.ChatBoxes", "User_Id2");
            AddForeignKey("dbo.ChatBoxes", "User1_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.ChatBoxes", "User_Id2", "dbo.Users", "Id");
        }
    }
}

namespace limingallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPostModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_UserId");
            DropColumn("dbo.Posts", "UsersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UsersId", c => c.String());
            RenameIndex(table: "dbo.Posts", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "User_Id");
        }
    }
}

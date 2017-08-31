namespace limingallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPostUserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "UsersId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "UsersId", c => c.Int(nullable: false));
        }
    }
}

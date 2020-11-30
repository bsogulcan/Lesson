namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VideoContentLogs", name: "VideoContent_Id", newName: "VideoContentId");
            RenameIndex(table: "dbo.VideoContentLogs", name: "IX_VideoContent_Id", newName: "IX_VideoContentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VideoContentLogs", name: "IX_VideoContentId", newName: "IX_VideoContent_Id");
            RenameColumn(table: "dbo.VideoContentLogs", name: "VideoContentId", newName: "VideoContent_Id");
        }
    }
}

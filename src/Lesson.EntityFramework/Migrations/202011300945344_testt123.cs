namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testt123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoContentLogs", "VideoContentId", "dbo.VideoContents");
            DropIndex("dbo.VideoContentLogs", new[] { "VideoContentId" });
            AlterColumn("dbo.VideoContentLogs", "VideoContentId", c => c.Int(nullable: false));
            CreateIndex("dbo.VideoContentLogs", "VideoContentId");
            AddForeignKey("dbo.VideoContentLogs", "VideoContentId", "dbo.VideoContents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoContentLogs", "VideoContentId", "dbo.VideoContents");
            DropIndex("dbo.VideoContentLogs", new[] { "VideoContentId" });
            AlterColumn("dbo.VideoContentLogs", "VideoContentId", c => c.Int());
            CreateIndex("dbo.VideoContentLogs", "VideoContentId");
            AddForeignKey("dbo.VideoContentLogs", "VideoContentId", "dbo.VideoContents", "Id");
        }
    }
}

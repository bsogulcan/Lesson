namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHomeworksAndVideoContentReleations1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoContents", "HomeworkId", "dbo.Homework");
            DropIndex("dbo.VideoContents", new[] { "HomeworkId" });
            AddColumn("dbo.Homework", "VideoContent_Id", c => c.Int());
            AlterColumn("dbo.VideoContents", "HomeworkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Homework", "VideoContent_Id");
            AddForeignKey("dbo.Homework", "VideoContent_Id", "dbo.VideoContents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "VideoContent_Id", "dbo.VideoContents");
            DropIndex("dbo.Homework", new[] { "VideoContent_Id" });
            AlterColumn("dbo.VideoContents", "HomeworkId", c => c.Int());
            DropColumn("dbo.Homework", "VideoContent_Id");
            CreateIndex("dbo.VideoContents", "HomeworkId");
            AddForeignKey("dbo.VideoContents", "HomeworkId", "dbo.Homework", "Id");
        }
    }
}

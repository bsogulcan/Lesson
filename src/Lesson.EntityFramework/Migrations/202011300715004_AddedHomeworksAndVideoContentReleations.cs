namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHomeworksAndVideoContentReleations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoContents", "HomeworkId", c => c.Int());
            CreateIndex("dbo.VideoContents", "HomeworkId");
            AddForeignKey("dbo.VideoContents", "HomeworkId", "dbo.Homework", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoContents", "HomeworkId", "dbo.Homework");
            DropIndex("dbo.VideoContents", new[] { "HomeworkId" });
            DropColumn("dbo.VideoContents", "HomeworkId");
        }
    }
}

namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testt11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Homework", "VideoContent_Id", "dbo.VideoContents");
            DropIndex("dbo.Homework", new[] { "VideoContent_Id" });
            DropColumn("dbo.Homework", "VideoContent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Homework", "VideoContent_Id", c => c.Int());
            CreateIndex("dbo.Homework", "VideoContent_Id");
            AddForeignKey("dbo.Homework", "VideoContent_Id", "dbo.VideoContents", "Id");
        }
    }
}

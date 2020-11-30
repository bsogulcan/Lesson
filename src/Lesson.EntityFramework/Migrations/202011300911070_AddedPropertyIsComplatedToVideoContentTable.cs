namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertyIsComplatedToVideoContentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoContentLogs", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoContentLogs", "IsCompleted");
        }
    }
}

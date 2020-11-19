namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimeLimitOnExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Examinations", "TimeLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Examinations", "TimeLimit");
        }
    }
}

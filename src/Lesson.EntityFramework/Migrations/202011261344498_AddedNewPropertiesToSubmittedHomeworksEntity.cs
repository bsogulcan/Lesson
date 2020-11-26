namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToSubmittedHomeworksEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubmittedHomeworks", "Name", c => c.String());
            AddColumn("dbo.SubmittedHomeworks", "Type", c => c.String());
            AddColumn("dbo.SubmittedHomeworks", "Size", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubmittedHomeworks", "Size");
            DropColumn("dbo.SubmittedHomeworks", "Type");
            DropColumn("dbo.SubmittedHomeworks", "Name");
        }
    }
}

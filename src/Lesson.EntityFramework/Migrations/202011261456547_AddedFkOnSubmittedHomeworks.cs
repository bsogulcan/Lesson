namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFkOnSubmittedHomeworks : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SubmittedHomeworks", name: "Homework_Id", newName: "HomeworkId");
            RenameIndex(table: "dbo.SubmittedHomeworks", name: "IX_Homework_Id", newName: "IX_HomeworkId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SubmittedHomeworks", name: "IX_HomeworkId", newName: "IX_Homework_Id");
            RenameColumn(table: "dbo.SubmittedHomeworks", name: "HomeworkId", newName: "Homework_Id");
        }
    }
}

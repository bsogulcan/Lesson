namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedExaminationEntity2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "StudentId", newName: "UserId");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_StudentId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_UserId", newName: "IX_StudentId");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "UserId", newName: "StudentId");
        }
    }
}

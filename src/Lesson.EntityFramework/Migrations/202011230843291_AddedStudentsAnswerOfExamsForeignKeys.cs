namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentsAnswerOfExamsForeignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "Examination_Id", newName: "ExaminationId");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "ExaminationQuestion_Id", newName: "ExaminationQuestionId");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "ExaminationQuestionAnswer_Id", newName: "ExaminationQuestionAnswerId");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_Examination_Id", newName: "IX_ExaminationId");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_ExaminationQuestion_Id", newName: "IX_ExaminationQuestionId");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_ExaminationQuestionAnswer_Id", newName: "IX_ExaminationQuestionAnswerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_ExaminationQuestionAnswerId", newName: "IX_ExaminationQuestionAnswer_Id");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_ExaminationQuestionId", newName: "IX_ExaminationQuestion_Id");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_ExaminationId", newName: "IX_Examination_Id");
            RenameIndex(table: "dbo.StudentsAnswerOfExams", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "ExaminationQuestionAnswerId", newName: "ExaminationQuestionAnswer_Id");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "ExaminationQuestionId", newName: "ExaminationQuestion_Id");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "ExaminationId", newName: "Examination_Id");
        }
    }
}

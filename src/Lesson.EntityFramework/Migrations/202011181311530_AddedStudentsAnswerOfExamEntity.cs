namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentsAnswerOfExamEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentsAnswerOfExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Examination_Id = c.Int(),
                        ExaminationQuestion_Id = c.Int(),
                        ExaminationQuestionAnswer_Id = c.Int(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id)
                .ForeignKey("dbo.ExaminationQuestions", t => t.ExaminationQuestion_Id)
                .ForeignKey("dbo.ExaminationQuestionAnswers", t => t.ExaminationQuestionAnswer_Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.Examination_Id)
                .Index(t => t.ExaminationQuestion_Id)
                .Index(t => t.ExaminationQuestionAnswer_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsAnswerOfExams", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.StudentsAnswerOfExams", "ExaminationQuestionAnswer_Id", "dbo.ExaminationQuestionAnswers");
            DropForeignKey("dbo.StudentsAnswerOfExams", "ExaminationQuestion_Id", "dbo.ExaminationQuestions");
            DropForeignKey("dbo.StudentsAnswerOfExams", "Examination_Id", "dbo.Examinations");
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "User_Id" });
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "ExaminationQuestionAnswer_Id" });
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "ExaminationQuestion_Id" });
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "Examination_Id" });
            DropTable("dbo.StudentsAnswerOfExams");
        }
    }
}

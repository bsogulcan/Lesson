namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedExaminationEntity1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentsAnswerOfExams", "StudentId", "dbo.AbpUsers");
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "StudentId" });
            AlterColumn("dbo.StudentsAnswerOfExams", "StudentId", c => c.Long());
            CreateIndex("dbo.StudentsAnswerOfExams", "StudentId");
            AddForeignKey("dbo.StudentsAnswerOfExams", "StudentId", "dbo.AbpUsers", "Id");
            DropColumn("dbo.Examinations", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Examinations", "StudentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentsAnswerOfExams", "StudentId", "dbo.AbpUsers");
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "StudentId" });
            AlterColumn("dbo.StudentsAnswerOfExams", "StudentId", c => c.Long(nullable: false));
            CreateIndex("dbo.StudentsAnswerOfExams", "StudentId");
            AddForeignKey("dbo.StudentsAnswerOfExams", "StudentId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
    }
}

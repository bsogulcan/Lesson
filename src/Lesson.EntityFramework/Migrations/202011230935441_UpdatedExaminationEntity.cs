namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedExaminationEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentsAnswerOfExams", "UserId", "dbo.AbpUsers");
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "UserId" });
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "UserId", newName: "StudentId");
            AddColumn("dbo.Examinations", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentsAnswerOfExams", "StudentId", c => c.Long(nullable: false));
            CreateIndex("dbo.StudentsAnswerOfExams", "StudentId");
            AddForeignKey("dbo.StudentsAnswerOfExams", "StudentId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsAnswerOfExams", "StudentId", "dbo.AbpUsers");
            DropIndex("dbo.StudentsAnswerOfExams", new[] { "StudentId" });
            AlterColumn("dbo.StudentsAnswerOfExams", "StudentId", c => c.Long());
            DropColumn("dbo.Examinations", "StudentId");
            RenameColumn(table: "dbo.StudentsAnswerOfExams", name: "StudentId", newName: "UserId");
            CreateIndex("dbo.StudentsAnswerOfExams", "UserId");
            AddForeignKey("dbo.StudentsAnswerOfExams", "UserId", "dbo.AbpUsers", "Id");
        }
    }
}

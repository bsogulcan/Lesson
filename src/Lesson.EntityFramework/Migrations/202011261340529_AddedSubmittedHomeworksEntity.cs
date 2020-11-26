namespace Lesson.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubmittedHomeworksEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmittedHomeworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        File = c.Binary(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Homework_Id = c.Int(),
                        User_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SubmittedHomeworks_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Homework", t => t.Homework_Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Homework_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubmittedHomeworks", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.SubmittedHomeworks", "Homework_Id", "dbo.Homework");
            DropIndex("dbo.SubmittedHomeworks", new[] { "User_Id" });
            DropIndex("dbo.SubmittedHomeworks", new[] { "Homework_Id" });
            DropIndex("dbo.SubmittedHomeworks", new[] { "IsDeleted" });
            DropTable("dbo.SubmittedHomeworks",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SubmittedHomeworks_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

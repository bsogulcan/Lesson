namespace Lesson.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVideoContentLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoContentLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Log = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        User_Id = c.Long(),
                        VideoContent_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_VideoContentLog_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .ForeignKey("dbo.VideoContents", t => t.VideoContent_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.User_Id)
                .Index(t => t.VideoContent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoContentLogs", "VideoContent_Id", "dbo.VideoContents");
            DropForeignKey("dbo.VideoContentLogs", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.VideoContentLogs", new[] { "VideoContent_Id" });
            DropIndex("dbo.VideoContentLogs", new[] { "User_Id" });
            DropIndex("dbo.VideoContentLogs", new[] { "IsDeleted" });
            DropTable("dbo.VideoContentLogs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_VideoContentLog_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

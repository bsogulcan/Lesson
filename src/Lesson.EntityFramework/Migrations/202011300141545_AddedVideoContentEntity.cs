namespace Lesson.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVideoContentEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Summary = c.String(),
                        Content = c.Binary(),
                        VideoSize = c.Int(nullable: false),
                        VideoName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_VideoContent_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.VideoContents", new[] { "IsDeleted" });
            DropTable("dbo.VideoContents",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_VideoContent_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToLessonOfClassRoom : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LessonOfClassRooms", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.LessonOfClassRooms", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LessonOfClassRooms", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.LessonOfClassRooms", name: "UserId", newName: "User_Id");
        }
    }
}

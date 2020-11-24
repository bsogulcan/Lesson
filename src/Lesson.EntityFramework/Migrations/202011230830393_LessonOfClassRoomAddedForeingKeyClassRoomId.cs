namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LessonOfClassRoomAddedForeingKeyClassRoomId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LessonOfClassRooms", name: "ClassRoom_Id", newName: "ClassRoomId");
            RenameIndex(table: "dbo.LessonOfClassRooms", name: "IX_ClassRoom_Id", newName: "IX_ClassRoomId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LessonOfClassRooms", name: "IX_ClassRoomId", newName: "IX_ClassRoom_Id");
            RenameColumn(table: "dbo.LessonOfClassRooms", name: "ClassRoomId", newName: "ClassRoom_Id");
        }
    }
}

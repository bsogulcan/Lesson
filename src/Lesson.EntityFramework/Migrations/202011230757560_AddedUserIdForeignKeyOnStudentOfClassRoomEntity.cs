namespace Lesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdForeignKeyOnStudentOfClassRoomEntity : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentOfClassRooms", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.StudentOfClassRooms", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentOfClassRooms", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.StudentOfClassRooms", name: "UserId", newName: "User_Id");
        }
    }
}

(function () {
    $(function () {
        var _$modal = $('#ClassRoomCreateModal');
        var _$form = _$modal.find('form');
         
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var role = _$form.serializeFormToObject();

            abp.services.app.classRoom.create(role).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new role!
            });
        });

        $('.edit-class_room').click(function (e) {
            var classRoomId = $(this).attr("data-classRoom-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'ClassRooms/EditModal?id=' + classRoomId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#ClassRoomEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $('.delete-class_room').click(function () {
            var roleId = $(this).attr("data-role-id");
            var roleName = $(this).attr('data-role-name');

            abp.message.confirm(
                "Remove class room which name is '" + roleName + "'?", "Are you sure?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        abp.services.app.classRoom.delete({
                            id: roleId
                        }).done(function () {
                            location.reload(true);  
                        });
                    }
                }
            );
        });
        
        $('.class_room_students1').click(function (e) { 
            var classId = $(this).attr("data-classRoom-id");
            e.preventDefault();
            
            abp.ajax({
                url: abp.appPath + 'ClassRooms/Students?classRoomId='+classId,
                type: 'GET',
                dataType: 'html',
                success: function (content) { 
                    console.log("Clicked");
                },
                error: function (e) { }
            });
        });
    })
})();
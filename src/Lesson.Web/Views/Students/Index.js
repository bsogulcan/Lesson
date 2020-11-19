(function () {
    $(function () {
        var _$modal = $('#CreateModal');
        var _$form = _$modal.find('form');
         
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var studentOfClassRoom = _$form.serializeFormToObject();

            abp.services.app.studentOfClassRoom.create(studentOfClassRoom).done(function () {
                _$modal.modal('hide');
                location.reload(true); 
            });
        });


        var _$classRoomCombobox = $('#ClassRoomCombobox1');

        _$classRoomCombobox.change(function() {
            location.href = '/Tasks?state=' + _$classRoomCombobox.val();
        });
 

        $('.delete-studentOfClass').click(function () {
            var roleId = $(this).attr("data-role-id");
            var roleName = $(this).attr('data-role-name');

            abp.message.confirm(
                "Remove '"+roleName+"' from class?", "Are you sure?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        abp.services.app.studentOfClassRoom.delete({
                            id: roleId
                        }).done(function () {
                            location.reload(true);  
                        });
                    }
                }
            );
        });
        
        
    })
})();
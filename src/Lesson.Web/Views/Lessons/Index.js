(function () {
    $(function () {
        var _$modal = $('#CreateModal');
        var _$form = _$modal.find('form');
         
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var formModal = _$form.serializeFormToObject();

            abp.services.app.lesson.create(formModal).done(function () {
                _$modal.modal('hide');
                location.reload(true); 
            });
        }); 

        $('.delete-lesson').click(function () {
            var roleId = $(this).attr("data-lesson-id");
            var roleName = $(this).attr('data-lesson-name');

            abp.message.confirm(
                "Removing Lesson", "Are you sure?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        abp.services.app.lesson.delete({
                            id: roleId
                        }).done(function () {
                            location.reload(true);  
                        });
                    }
                }
            );
        });


        $('.edit-lesson').click(function (e) {
            var classRoomId = $(this).attr("data-lesson-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Lessons/EditModal?id=' + classRoomId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#EditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        
        
    })
})();
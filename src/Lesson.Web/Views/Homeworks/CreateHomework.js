(function () {
    $(function () {  
        var _$form = $('form[name=InsertHomeWork]');

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
 
            var formModel = _$form.serializeFormToObject();

            abp.ajax({
                url: abp.appPath + 'Homeworks/InsertHomeWorkAsync',
                type: 'POST',
                data: JSON.stringify(formModel),
                success: function (content) {
                    // console.log(content);
                    document.location.href=abp.appPath + 'Homeworks/Index'; 
                },
                }); 
        }); 

        abp.event.on('abp.notifications.received', function (userNotification) {
            console.log(userNotification);
        });
        
    })
})();


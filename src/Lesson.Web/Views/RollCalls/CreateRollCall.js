// (function ($) {
  
//     var _$form = $('form[name=CreateNewRollCall]');

//     function SelectedIndexChanged() {

//         if (!_$form.valid()) {
//             return;
//         }

//         var role = _$form.serializeFormToObject();  

//         abp.ui.setBusy(_$form);

//         abp.ajax({
//             url: abp.appPath + 'RollCalls/GetLessonsOfClass',
//             type: 'POST',
//             dataType: 'html',
//             success: function (content) {  
//             },
//             error: function (e) { }
//         });
//     }

// })(jQuery);

$(document).ready(function()  
    {  
        var _$form = $('form[name=CreateNewRollCall]');
        $("#ddClass").on("change", function()  
        {    
            $.ajax(  
            {  
                url: abp.appPath + 'RollCalls/GetLessonsOfClass',  
                type: 'POST',  
                data: '{"ClassRoomId":"'+$("#ddClass").val()+'"}',  
                contentType: 'application/json; charset=utf-8',  
                success: function(data)  
                {  
                    $("#partialDiv").html(data);  
                },  
                error: function()  
                {  
                    alert("error");  
                }  
            });  
        });  
    });
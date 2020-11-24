﻿(function () {
    $(function () {  
        var _$form = $('form[name=InsertHomeWork]');

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
            var formModel = _$form.serializeFormToObject();

            var homeWork={
                Summary:document.getElementById("Summary").value,
                Description:document.getElementById("Description").value,
                LessonId:document.getElementById("lessonsDropDown").value,
                ClassRoomId:document.getElementById("classRoomDropDown").value,
                Deadline:document.getElementById("Deadline").value
            };

            console.log(homeWork);

            abp.ajax({
                url: abp.appPath + 'Homeworks/InsertHomeWorkAsync',
                type: 'POST',
                data: JSON.stringify(homeWork),
                success: function (content) {
                    // console.log(content);
                    document.location.href=abp.appPath + 'Homeworks/Index'; 
                },
                }); 
        }); 


        $("#classRoomDropDown").change(function(){
            var selectedVal=$(this).val();
            console.log(selectedVal);
            var lessonsDropDownDiv=document.getElementsByClassName('filter-option pull-left')[1];
           
            abp.services.app.lessonOfClassRoom.getListLessonsOfClassRoomById(selectedVal).done(function (content) {
                if(content.length>0){
                    lessonsDropDownDiv.innerHTML=content[0]["lesson"].name;
                }else {
                    lessonsDropDownDiv.innerHTML="Select Lesson";
                } 

                var targetDiv = document.getElementsByClassName("dropdown-menu open")[1].getElementsByClassName("dropdown-menu inner")[0]; 
                targetDiv.innerHTML='';
                
                $("#lessonsDropDown").innerHTML='';

                document.querySelector("#lessonsDropDown").innerHTML='';
  
                for(var index=0;index<content.length;index++){
                    
                   $("#lessonsDropDown").append("<option value='"+content[index]["lesson"].id+"'>"+content[index]["lesson"].name+"</option>");
                    var node = document.createElement("LI");
                    node.setAttribute("data-original-index",index);
                    var textnode = document.createElement("A");
                    textnode.role="Option";
                    var span= document.createElement("SPAN");  
                    span.className="text"; 
                    span.appendChild(document.createTextNode(content[index]["lesson"].name));

                    textnode.appendChild(span);       
                    node.appendChild(textnode);     
                    targetDiv.appendChild(node);  
                } 

            }).always(function () { 
            }); 
         });
        
    })
})();


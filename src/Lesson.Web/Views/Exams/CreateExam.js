(function () {
    $(function () {  
        var _$form = $('form[name=CreateExam]');
 

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
 
            var formModel = _$form.serializeArray();
            quesntions = document.querySelectorAll("[name^=Question]");
             
            var exam={
                Name:$("#examName").val(),
                ClassRoomId:$("#classRoomDropDown").val(),
                LessonId:$("#lessonsDropDown").val(),
                StartDate:$("#StartDate").val(),
                EndDate:$("#EndDate").val(),
                TimeLimit:$("#timeLimit").val(),
                Questions:[]
            };
 
            for (var objectIndex = 0; objectIndex < quesntions.length; objectIndex++) {
                
                answerList = document.querySelectorAll("[name^=Answer"+objectIndex+"]"); 
                boolList = document.querySelectorAll("[name^=ig_checkbox"+objectIndex+"]"); 
                
                var question={
                    Question:quesntions[objectIndex].value,
                    Answers:[]
                }
    
                
                for (var answerIndex=0;answerIndex<answerList.length;answerIndex++){   
                    var answer={
                        Answer:answerList[answerIndex].value,
                        Status:boolList[answerIndex].checked
                    }  
                    question.Answers.push(answer); 
                }   
                
                exam.Questions.push(question); 
            }
            console.log(exam);  
            
            abp.ajax({
                url: '/Exams/InsertExamAsync',
                data: JSON.stringify(exam)
            }).done(function(data) {
                if(data.success){
                    abp.notify.success('Created new exam.');
                    window.location.href = "/Exams";
                }
            });
            
        });     

        $("#classRoomDropDown").change(function(){
            var selectedVal=$(this).val();
            var lessonsDropDownDiv=document.getElementsByClassName('filter-option pull-left')[1];
           
            abp.services.app.lessonOfClassRoom.getListLessonsOfClassRoomById(selectedVal).done(function (content) {
                if(content.length>0){
                    lessonsDropDownDiv.innerHTML=content[0]["lesson"].name;
                }else {
                    lessonsDropDownDiv.innerHTML="Select Lesson";
                } 

                var targetDiv = document.getElementsByClassName("dropdown-menu open")[1].getElementsByClassName("dropdown-menu inner")[0];;
                targetDiv.innerHTML='';
                $("#lessonsDropDown").innerHTML='';

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


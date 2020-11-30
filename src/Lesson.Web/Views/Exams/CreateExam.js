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

function AddAnswer(button){
    var questionIndex=button.getAttribute("questionIndex");
    var collapseName="collapseOne_"+(parseInt(questionIndex)+1);
    var collapseDiv=document.querySelector("#"+collapseName+" > div > div > div > div.body");
    var answerIndex=collapseDiv.childElementCount-1;
    const div = document.createElement('div'); 
    div.className = 'input-group';
    
    console.log(answerIndex);

    div.innerHTML = `
        <span class="input-group-addon">
        <input type="checkbox" class="filled-in" id="ig_checkbox`+questionIndex+` `+answerIndex+`" name="ig_checkbox`+questionIndex+` 0">
        <label for="ig_checkbox`+questionIndex+` `+answerIndex+`"></label>
        </span>
        <div class="form-line">
        <input class="form-control" id="Answer`+questionIndex+`_`+answerIndex+`" name="Answer`+questionIndex+` `+answerIndex+`" placeholder="Answer?" type="text" value="">
        </div> 
    `;  
    collapseDiv.appendChild(div)
}

function AddQuestion(button){
    var questionsDiv=document.querySelector("#accordion_1");
    var questionIndex=questionsDiv.childElementCount+1;
    var _questionIndex=questionsDiv.childElementCount;
    const div = document.createElement('div'); 
    div.className = 'panel panel-col-green';

    div.innerHTML = `
    <div class="panel-heading" role="tab" id="headingOne_`+questionIndex+`">
                                        <h4 class="panel-title">
                                            <a role="button" data-toggle="collapse" data-parent="#accordion_1" href="#collapseOne_`+questionIndex+`" aria-expanded="true" aria-controls="collapseOne_`+questionIndex+`" class="">
                                                Questions #`+questionIndex+`
                                            </a>
                                        </h4>

                                    </div>
                                    <div id="collapseOne_`+questionIndex+`" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne_1" aria-expanded="true" style="">
                                        <div>
                                            <div>
                                                <div>
                                                    <div class="header">
                                                        <h2>
                                                            <textarea class="form-control no-resize" cols="20" id="Question`+questionIndex+`" name="Question`+questionIndex+`" placeholder="Question?" rows="2"></textarea>
                                                        </h2>
                                                    </div>
                                                    
                                                    <div class="body">
                                                        <button type="button" onclick="AddAnswer(this)" questionindex="`+_questionIndex+`" class="btn btn-primary waves-effect pull-right">
                                                            <i class="material-icons">add</i>
                                                        </button>
                                                            <div class="input-group ">
                                                                <span class="input-group-addon">
                                                                    <input type="checkbox" class="filled-in" id="ig_checkbox`+_questionIndex+` 0" name="ig_checkbox`+_questionIndex+` 0">
                                                                    <label for="ig_checkbox`+_questionIndex+` 0"></label>
                                                                </span>
                                                                <div class="form-line">
                                                                    <input class="form-control" id="Answer`+_questionIndex+`_0" name="Answer`+_questionIndex+` 0" placeholder="Answer?" type="text" value="">
                                                                </div>

                                                            </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
`;  
    questionsDiv.appendChild(div)


}
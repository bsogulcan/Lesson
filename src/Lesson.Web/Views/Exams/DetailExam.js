(function () {
    $(function () {  
        var _$form = $('form[name=DetailExam]'); 
    })
})();

var examStarted=false;

function StartExam(){ 
    var examTimeLimit=document.getElementById('lblTimeLimit').textContent;
    document.getElementById('divQuestions').style.display = "block";
    document.getElementById('divStartButton').style.display = "none";

    examStarted=true; 
    
    var countDownDate = new Date(); 
    countDownDate.setMinutes( countDownDate.getMinutes() + parseInt(examTimeLimit) );

    countDownDate=countDownDate.getTime();  
    var x = setInterval(function() {
        
        var now = new Date().getTime();  
        var distance = countDownDate - now;
  
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
       
        document.getElementById('lblTimeLimit').textContent = minutes + "Minute " + seconds + "Secons ";
       
        if (distance < 0) {
          clearInterval(x); 
          FinishExam();
        }
      }, 1000); 
}

function FinishExam(){  

    var studentsAnswerOfExam=[];

    var quesntions = document.querySelectorAll("[name^=Question]"); 
    for (var objectIndex = 0; objectIndex < quesntions.length; objectIndex++) {
        var answerList = document.querySelectorAll("[name^=radioLbl"+objectIndex+"]"); 
        var boolList = document.querySelectorAll("[id^=radio"+objectIndex+"]");   
        for(var index=0;index<boolList.length;index++){
            if (boolList[index].checked){
                var answerDetail={
                    UserId:0,
                    ExaminationId:boolList[index].getAttribute("examId"),
                    ExaminationQuestionId:boolList[index].getAttribute("questionId"),
                    ExaminationQuestionAnswerId:boolList[index].getAttribute("answerId")
                } 
                studentsAnswerOfExam.push(answerDetail);
            }
        }
    } 
    
    abp.ajax({
        url: '/Exams/InsertStudentsAnswer',
        data: JSON.stringify(studentsAnswerOfExam)
    }).done(function(data) {
        if(data.success){
            abp.notify.success('Finished Exam.');
            window.location.href = "/Home";
        }
    });
     
}
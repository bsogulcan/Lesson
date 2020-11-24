function updateStudentStatus(_this) {
    var selectedType = $(_this).val(); 
    var rollCallDetailId= $(_this).attr('rollCallDetailId'); 
    var rollCallId= $(_this).attr('rollCallId'); 
  
    var changedDiv=document.getElementById("div "+rollCallDetailId);
    // $('#div 15').removeClass();
    changedDiv.removeAttribute("class");
    changedDiv.setAttribute("class","header bg-"+(selectedType==0?"green":selectedType==1?"red":"cyan"));
    $.ajax(  
        {  
            url: abp.appPath + 'RollCalls/UpdateStudentRollCallStatus',  
            type: 'POST',  
            data: '{"RollCallType":"'+selectedType+'","RollCallId":"'+rollCallId+'","RollCallDetailId":"'+rollCallDetailId+'"}',  
            contentType: 'application/json; charset=utf-8',  
            success: function(data)  
            {  
                
            },  
            error: function()  
            {   
            }  
        });  

        // window.location.reload();

}
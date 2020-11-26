(function () {
    $(function () {
       
        FilePond.registerPlugin(FilePondPluginFileEncode);

        const inputElement = document.querySelector('input[type="file"]');
        // $('#mypond').filepond({
        //     allowMultiple: true
        // });
        const pond = FilePond.create(inputElement);
 
        $('#mypond').on('FilePond:addfile', function(e) {
            console.log('file added event', e);
        });

        $('#btnSaveHomework').click(function () {
           var pondEntity=pond.getFiles(); 

           var uploadedFileBase64=pondEntity[0].getFileEncodeBase64String();
         
           var createSubmittedHomeworkInput={
            Name:pondEntity[0].filename,
            Type:pondEntity[0].fileType,
            Size:pondEntity[0].fileSize,
            HomeworkId:$('#btnSaveHomework').attr("homeWorkId"), 
            FileBase64:uploadedFileBase64
           };

           abp.ajax({
            url: '/Homeworks/SubmiteHomework',
            data: JSON.stringify(createSubmittedHomeworkInput)
            }).done(function(data) {
                if(data.success){
                    abp.notify.success('Uploaded homework.'); 
                }
            });
    

        });
    })
})();


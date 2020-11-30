(function () {
    $(function () {
       
        FilePond.registerPlugin(FilePondPluginFileEncode);

        const inputElement = document.querySelector('input[type="file"]');
        // $('#mypond').filepond({
        //     allowMultiple: true
        // });
        const pond = FilePond.create(inputElement);
 

        var options = {
            
        };
        
        var player = videojs('my-player', options, function onPlayerReady() {
        
            this.controlBar.progressControl.disable()

            this.on('ended', function () { 
                abp.services.app.videoContentLog.create({
                    Log:"Video Completed",
                    VideoContentId:$('#my-player').attr("videoId"),
                    IsCompleted:true
                });
                console.log('Video Finished');
            });
        
            var lastTime = 0; 
            this.on("timeupdate", function (event) {
                var currentTime = this.currentTime();
                if (currentTime - lastTime > 5) {
                    console.log("Video " + lastTime + " Saniyesinden" + currentTime + " Saniyesine atladı.");
                }
                lastTime = this.currentTime();
            });
        });



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


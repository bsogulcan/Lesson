(function () {
    $(function () {

         FilePond.registerPlugin(FilePondPluginFileEncode);

         const inputElement = document.querySelector('input[type="file"]'); 
         const pond = FilePond.create(inputElement);

         $('#mypond').on('FilePond:addfile', function (e) {
             console.log('file added event', e);
         });


        const toBase64 = file => new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result);
            reader.onerror = error => reject(error);
        });


        $('#btnSaveVideoContent').click(function () {
              
              
          
             var pondEntity = pond.getFiles();
             var uploadedFileBase64 = pondEntity[0].getFileEncodeBase64String();
             var test = pondEntity[0].getFileEncodeDataURL();  

             var createVideoContentInput = {
                 Summary: $('#Summary').val(),   
                 VideoSize: pondEntity[0].fileSize, 
                 FileBase64:uploadedFileBase64
             };

            console.log(createVideoContentInput.FileBase64);
             abp.ajax({
                 url: '/VideoContent/InsertVideoContentAsync',
                 data: JSON.stringify(createVideoContentInput)
             }).done(function (data) {
                 if (data.success) {
                     document.location.href=abp.appPath + 'VideoContent/Index'; 
                 }
             });


        });
    })
})();


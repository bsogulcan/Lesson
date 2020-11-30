(function () {
    $(function () {

        var options = {
            
        };
        
        var player = videojs('my-player', options, function onPlayerReady() {
        
            this.controlBar.progressControl.disable()

            this.on('ended', function () {
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

    })
})();




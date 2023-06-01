$(document).ready(function(){

    $('#alert-tor').hide();
    $('#div-tor').mouseover(function(){
        $('#alert-tor').show();
    });
    $('#div-tor').mouseout(function(){
        $('#alert-tor').hide();
    });

//  $('.btn-install').click(function(){
//      $.get('./install.sh', this.value, function(data){
//          console.log(data);
//      });
//  });
//
//  $('.btn-remove').click(function(e){
//      e.preventDefault();
//      $.get('./remove.sh', this.value, function(data){
//          if(data=='ok'){
//            console.log(true);
//          } else{
//            console.log(false);
//          }
//      });
//  });

    $('#btnlight').click(function(){

        $.get('./themes.sh', 'light', function(){
            location.reload(true);
        });
    });

    $('#btnmix').click(function(){

        $.get('./themes.sh', 'mix', function(){
            location.reload(true);
        });
    });

    $('#btndark').click(function(){

        $.get('./themes.sh', 'dark', function(){
            location.reload(true);
        });
    });

    $('#customSwitch1').on('change',function(){

        $.get('./autostart.sh');
    });

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

});

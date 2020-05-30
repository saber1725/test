 var str = $("#txtCheckBoxCate").val(); /*sqldata value*/
   $(".txtinput").each(function(){
        var x = $(this).val(); /*checkbox value*/
        var pattern = new RegExp(x);
        if(pattern.test(str)){
            $(this).prop("checked",true);
        }
    })
/*將勾選分類存進input表單  [httppost]*/
 function categoryCheckBox(){
        var txt ="";
       $(".txtinput").each(function(){
            if(this.checked){
                txt=txt+this.value+",";
                $("#txtCheckBoxCate").val(txt);
            }
        })
    }
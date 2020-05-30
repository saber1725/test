function previewImage(){
       var fReader =new FileReader();
       if(document.getElementById("upload_img").files[0]!=null){
           var name =document.getElementById("upload_img").files[0].name;
           fReader.readAsDataURL(document.getElementById("upload_img").files[0]);
           //console.log(name)  //--選取圖片名稱
           fReader.onload = function(fevent){
               document.getElementById("show_img").src=fevent.target.result;
           }
           //console.log(document.getElementById("show_img").src)
       }
       else{
               document.getElementById("show_img").src=""; //---choosefile {取消} 預覽為空
       }
   }
   document.getElementById("upload_img").addEventListener("change",previewImage);
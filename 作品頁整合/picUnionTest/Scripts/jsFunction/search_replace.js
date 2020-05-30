/*Example below*/
/*<span>@Html.ActionLink("搜尋", "w搜尋作品", "WorkSpace", new { keyword = "x" }, new { @Class = "link" })</span>@*set actionlink htmlattribute==>class*@*/


/*jQuery replace keyword value by input value*/
$(function(){
    $(".link").click(function(){ /*Element target tag*/
        var txtValue =$("#search").val(); /*Element where value extract*/
        this.href =this.href.replace("x",txtValue);
    });
});


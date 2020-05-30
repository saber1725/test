$(function () {
    let slideNum = 0; //目前顯示的index
    let slideCount = $(".slides li").length;
    let lastIndex = slideCount - 1; //最後一個索引index
    //console.log(slideCount);

    $(".dot li").eq(0).css("background", "white"); //選到的反白
    $(".dot li").mouseenter(function () { // 讀取白點的index
        console.log($(this).index());
        slideNum = $(this).index(); //白點依據index套用反白
        //this = $(".dot li").eq(slideNum)
        show();
    });

    //利用 slideNum 控制class="slides"
    function show() {
        $(".dot li").eq(slideNum).css("background", "#fff").siblings().css("background", "transparent");
        let move = -500 * slideNum;
        $("ul.slides").css("left", move);
    }

    //arrow.prev
    $('#prevSlide').click(function prev() {
        slideNum--;
        if (slideNum < 0) slideNum = lastIndex;
        show();
    });

    //arrow.prev
    $('#nextSlide').click(function next() {
        slideNum++;
        if (slideNum > lastIndex) slideNum = 0;
        show();
    });

    var duration = 3000;
    function run() {
        myAutorun = setInterval(autoShow, duration)
    }

    function autoShow() {
        slideNum++;
        if (slideNum > lastIndex) slideNum = 0;
        show();
    }
    run()

    function stopRun() {
        clearInterval(myAutorun);
    }

    $(document).ready(function () {
        $("div.wrapper").mouseenter(function () {
            stopRun()
            console.log(event.type);
        });
        $("div.wrapper").mouseleave(function () {
            run()
            console.log(event.type);
        });
    })
})

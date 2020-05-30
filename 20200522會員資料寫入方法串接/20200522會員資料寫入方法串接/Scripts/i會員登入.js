document.getElementById('pass').placeholder = "  請輸入密碼";
//document.getElementById("pass").onblur = checkuser;
document.getElementById("pass").size = "60";
document.getElementById("pass").autocomplete = "off";
document.getElementById("pass").style.fontSize = "16px";
document.getElementById("pass").style.fontFamily = "微軟正黑體";

document.getElementById('mail').placeholder = "  請輸入有效的 Email";
//document.getElementById("mail").onblur = checkuser;
document.getElementById("mail").size = "60";
document.getElementById("mail").autocomplete = "off";
document.getElementById("mail").style.fontSize = "16px";
document.getElementById("mail").style.fontFamily = "微軟正黑體";

document.getElementById('pass1').placeholder = "  請再次輸入密碼";
//document.getElementById("mail").onblur = checkuser;
document.getElementById("pass1").size = "60";
document.getElementById("pass1").autocomplete = "off";
document.getElementById("pass1").style.fontSize = "16px";
document.getElementById("pass1").style.fontFamily = "微軟正黑體";

document.getElementById('Name').placeholder = "  請輸入真實的中文姓名";
document.getElementById("Name").onblur = checkuser;
document.getElementById("Name").size = "60";
document.getElementById("Name").autocomplete = "off";
document.getElementById("Name").style.fontSize = "16px";
document.getElementById("Name").style.fontFamily = "微軟正黑體";
function checkuser() {
    var re = /^[\u4E00-\u9FA5]+$/;
    let theuser = document.querySelector("#Name");
    let Username = theuser.value;
    let spanname = document.querySelector("#Name1");
    let Thespan = Username.length;

    if (Username != "") {
        if (Thespan >= 2) {
            if (re.test(Username)) {
                spanname.innerHTML = "正確！";
            }
            else {
                spanname.innerHTML = "輸入必須為中文字！";
            }
        }
        else {
            spanname.innerHTML = "至少輸入兩個字！";
        }
    }
    else {
        spanname.innerHTML = "姓名必須填寫！";
    }
}

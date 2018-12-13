var name = document.getElementById("nameRegister");
var pass = document.getElementById("PasswordRegister");
var repass = document.getElementById("RePasswordRegister");
function them() {
    if (pass.value.length < 5) {
        alert("mật khẩu không được dưới 5 ký tự");
        pass.focus();
        return false;
    }
    if (repass.value != pass.value) {
        alert("Mật khẩu và xác nhận mật khẩu không giống nhau!");
        repass.focus();
        return false;
    }
    return true;
}
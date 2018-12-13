var name = document.getElementById("nameRegister");
var pass = document.getElementById("PasswordRegister");

function check() {
    if (pass.value.length < 5) {
        alert("mật khẩu không được dưới 5 ký tự");
        pass.focus();
        return false;
    }
    return true;
}
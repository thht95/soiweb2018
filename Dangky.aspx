<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Dangky.aspx.cs" Inherits="BTLweb.Dangky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Theme/js/Dangky.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" method="post" onsubmit="return (them())">
        <h1>Đăng ký tài khoản</h1>
        <div id="ndcontent">
            <h4><asp:Label ID="lbloi" runat="server"></asp:Label></h4>
            <h4>Tài khoản</h4>
            <input type="text" id="nameRegister" name="nameRegister" placeholder="Your Name" required="required"/>
            <h4>mail</h4>
            <input type="email" id="emailRegister" name="emailRegister" placeholder="Your Mail" required="required"/>
            <h4>Mật khẩu</h4>
             <input type="password" id="PasswordRegister" name="PasswordRegister" placeholder="Password" />
            <h4>Nhập lại mật khẩu đi</h4>
            <input type="password" id="RePasswordRegister" name="RePasswordRegister" placeholder="Confirm Password"/>
            <br /><br />
            <asp:Button runat="server" ID="btndangky" Text="Đăng ký"  OnClick="btndangky_Click" />
            &nbsp;&nbsp;
            <input type="reset" name="reset" id="reset" value="Đặt lại" />
        </div>
    </form>






















    <script type="text/javascript">
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
    </script>
</asp:Content>

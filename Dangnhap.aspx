<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Dangnhap.aspx.cs" Inherits="BTLweb.Dangnhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #nameRegister {
            width: 200px;
        }
        #PasswordRegister {
            width: 200px;
        }
        
    </style>
    <script type="text/javascript" src="Theme/js/Dangnhap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" method="post" onsubmit="return (check())">
        <h1>Đăng nhập</h1>
    <div id="ndcontent">
        <h4><asp:Label ID="lbloi" runat="server"></asp:Label></h4>
        <h4>Tài khoản   <input ID="nameRegister" name="nameRegister" placeholder="Your Name" required="required"/></h4>
        
        <h4>Mật khẩu    <input type="password" ID="PasswordRegister" name="PasswordRegister" placeholder="Password" required="required" /></h4>
        <asp:Button runat="server" ID="btndangnhap" Text="Đăng nhập" OnClick="btndangnhap_Click" />
        &nbsp;&nbsp;
        <input type="reset" name="reset" id="reset" value="Đặt lại" />
    </div>
    </form>
</asp:Content>

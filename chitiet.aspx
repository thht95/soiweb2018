<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="BTLweb.chitiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="rptBlog">
        <ItemTemplate>
            <h1><%# Eval("noiDung") %></h1>
        </ItemTemplate>
    </asp:Repeater>
    <div id="ndcontent">
        <asp:Repeater ID="rptNoidung" runat="server">
            <ItemTemplate>
                <h2 style="font-weight:bold; color:royalblue; text-align:center"><%# Eval("tieuDe") %></h2>
                <p style="text-align:right;">
                    cập nhật: <%# Eval("ngayDang","{0:MMMM d, yyyy}")%> <br />
                    <%--Số lần xem:<%# Eval("lanXem") %>--%>
                </p>
                <%# Eval("noiDung") %>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
      <asp:Button runat="server" ID="btnMark" Text="Đánh dấu"> </asp:Button>
    </div>
</asp:Content>

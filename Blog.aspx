<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="BTLweb.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="rptTieude">
        <ItemTemplate>
            <h1><%# Eval("noiDung") %></h1>
        </ItemTemplate>
    </asp:Repeater>
    <div id="ndcontent">
        <ul class="dsBlog">
            <asp:Repeater runat="server" ID="rptBlog">
                <ItemTemplate>
                        <li><a href="chitiet.aspx?idblog=<%# Eval("IDBlog") %>&id=<%# Eval("ID") %>">
                            <p style="text-align:center"><img src="<%# Eval("sAnh") %>" style="width:100%;" /></p>
                            <p><%# Eval("tieuDe") %></p></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
     </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BTLweb.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><b>Các blog liên quan</b></h1>
    <asp:Label Text="text" runat="server" ID="lblThongBao" />
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

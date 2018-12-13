<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BTLweb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Blog mới nhất</h1>
    <div id="ndcontent">
        <ul class="dsBlog">
            <asp:Repeater runat="server" ID="rptChitiet">
                <ItemTemplate>
                        <li><a href="chitiet.aspx?idblog=<%# Eval("IDBlog") %>&id=<%# Eval("ID") %>">
                            <p style="text-align:center"><img src="<%# Eval("sAnh") %>" style="width:100%;" /></p>
                            <p><%# Eval("tieuDe") %></p></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
     </div>
</asp:Content>

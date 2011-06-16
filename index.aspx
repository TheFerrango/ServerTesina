<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Record traini</title>
    <link rel="stylesheet" type="text/css" href="style.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <div id="logo">
            <h1>
                <a href="#">Traini alianti</a></h1>
            <p>
                Visualizzazione record relativi ai traini degli alianti</p>
        </div>
        <!-- end #logo -->
        <div id="menu">
            <ul>
                <li class="first"><a href="index.aspx">Home</a></li>
                <li><a href="#">Su di noi</a></li>
                <li><a href="#">Contattaci</a></li>
            </ul>
        </div>
        <!-- end #menu -->
    </div>
    <!-- end #header -->
    <div id="page">
        <div id="content">
            <div class="post">
                <h2 class="title">
                    &nbsp;<asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                </h2>
                <p class="byline">
                    <asp:Label ID="lblSubTitle" runat="server" Text="Label"></asp:Label>
                </p>
                <div class="entry">
                    <p>
                    </p>
                </div>
            </div>
        </div>
        <!-- end #content -->
        <div id="sidebar">
            <ul>
                <li id="search">
                    <h2>
                        Search</h2>
                    <fieldset>
                        <input type="text" id="s" name="s" value="" />
                        <input type="submit" id="x" value="Search" />
                    </fieldset>
                </li>
                <li>
                    <h2>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </h2>
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink0" runat="server" Text="Visualizza l'elenco dei piloti trainatori"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=0"></asp:HyperLink>
                            <asp:Label ID="lblUsr" Text="Login name:" runat="server"></asp:Label></li>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Visualizza l'elenco dei piloti degli alianti"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=1"></asp:HyperLink>
                            <asp:TextBox ID="usrName" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="Visualizza l'elenco degli istruttori"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=2"></asp:HyperLink>
                            <asp:Label ID="lblPass" Text="Password:" runat="server"></asp:Label></li>
                        <li>
                            <asp:HyperLink ID="HyperLink3" runat="server" Text="Visualizza l'elenco dei veicoli trainanti"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=3"></asp:HyperLink>
                            <asp:TextBox ID="usrPass" TextMode="Password" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:HyperLink ID="HyperLink4" runat="server" Text="Visualizza l'elenco degli alianti"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=4"></asp:HyperLink>
                            <asp:Button ID="lgnButt" Text="LogIn" CausesValidation="true" runat="server" OnClick="lgnButt_Click"
                                PostBackUrl="~/index.aspx" /></li>
                        <li>
                            <asp:HyperLink ID="HyperLink5" runat="server" Text="Visualizza l'elenco dei traini"
                                NavigateUrl="~/visualizzaTraini.aspx"></asp:HyperLink></li>
                    </ul>
                    <ul>
                        <li>
                            <asp:Label ID="lblErr" runat="server" Visible="false" ForeColor="Red" Text="Login errato"></asp:Label></li>
                    </ul>
                </li>
            </ul>
        </div>
        <!-- end #sidebar -->
        <div style="clear: both;">
            &nbsp;</div>
    </div>
    <!-- end #page -->
    <div id="footer">
        <p>
            © 2011. Tutti i diritti riservati. Lorenzo Lotto</p>
    </div>
    <!-- end #footer -->
    </form>
</body>
</html>

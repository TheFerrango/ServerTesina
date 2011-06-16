<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aggiungiElemento.aspx.cs" Inherits="aggiungiElemento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
	<div id="logo">
		<h1><a href="#">Traini alianti</a></h1>
		<p>Visualizzazione record relativi ai traini degli alianti</p>
	</div>
	<!-- end #logo -->
	<div id="menu">
		<ul>
			<li class="first"><a href="index.aspx">Home</a></li>
			<li><a href="#">Su di noi</a></li>
			<li><a href="#">Visualizza Stralci</a></li>
		</ul>
	</div>
	<!-- end #menu -->
</div>
<!-- end #header -->
<div id="page">
	<div id="content">
		<div class="post">
			<h2 class="title">&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </h2>
			<p class="byline">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
            <br />
            <p class="byline">
                <asp:Button ID="Button1" runat="server" Text="Button" />
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </p>

			<div class="entry">
				<p>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                        EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="90%">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </p>
			</div>
		</div>
	</div>
	<!-- end #content -->
	<div id="sidebar">
			<ul>
				<li id="search">
					<h2>Search</h2>
					
						<fieldset>
						<input type="text" id="s" name="s" value="" />
						<input type="submit" id="x" value="Search" />
						</fieldset>
					
				</li>
				<li>
					<h2>Link rapidi</h2>
					<ul>
						<li>
                            <asp:HyperLink ID="HyperLink0" runat="server" Text="Visualizza l'elenco dei piloti trainatori"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=0"></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Visualizza l'elenco dei piloti degli alianti"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=1"></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="Visualizza l'elenco degli istruttori"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=2"></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink3" runat="server" Text="Visualizza l'elenco dei veicoli trainanti"
                                NavigateUrl="~/visualizzaVari.aspx?tblInd=3"></asp:HyperLink></li>
                        
                    </ul>
    </div>
	<!-- end #sidebar -->
	<div style="clear: both;">&nbsp;</div>
</div>
<!-- end #page -->
<div id="footer">
	<p>© 2011. Tutti i diritti riservati. Lorenzo Lotto</p>
</div>
<!-- end #footer -->
    </form>
</body>
</html>

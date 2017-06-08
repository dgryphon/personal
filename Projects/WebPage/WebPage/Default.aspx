<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebPage._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script runat="server">
    Sub Page_Load()
        DateOut.Text = String.Format("(0:D)", Now)
        timeout.Text = String.Format("(0:T)", Now)
        BrowserOut.Text = Request.Browser.Browser
    End Sub
    
</script>

<head runat="server">
    <title>Assignment 1-1</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Assignment 1-1</h3>
    <div>
    
        <p> Today is <asp:Label ID = "DateOut" runat="server" /></p>
        <p> The Time is <asp:Label ID="timeout" runat="server" /> </p>
        <p> My Browser is <asp:Label ID = "BrowserOut" runat="server" /> </p>
            
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWallyWorld._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <h1>
        Upload a File</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;
        <asp:Button ID="btnAttach" runat="server" Height="22px" 
            onclick="btnAttach_Click" Text="Attach" Width="84px" />
    
    </div>
    <p>
        <asp:Label ID="lblResult" runat="server" Height="300px" Width="300px"></asp:Label>
    </p>
    </form>
</body>
</html>

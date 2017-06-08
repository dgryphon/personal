<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WallyWorld._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            <b>Upload a picture<br />
            </b>
        </h1>
        <p>
            <asp:CheckBox ID="cbNSFW" runat="server" />
            Not safe for work (NSFW)</p>
&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;
        <asp:Button ID="btnAttach" runat="server" Height="23px" style="margin-top: 7px" 
            Text="Attach" Width="81px" />
        <br />
        <br />
        <asp:Label ID="lblResult" runat="server" Height="300px" Width="300px"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>

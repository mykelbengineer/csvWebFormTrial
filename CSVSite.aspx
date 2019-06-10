<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSVSite.aspx.cs" Inherits="WebApplication1.CSVSite" %>

<!DOCTYPE html>

<script runat="server">

    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My CSV Upload Website</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUploader" runat ="server" />
            <br />
            <br />
            <asp:Button ID="UploadButton" runat ="server" Text="Upload" OnClick ="UploadButton_Click" /><br />
            <br />
            <br />
            <asp:Button ID="UpdateGrid" runat ="server" Text="Update Grid" OnClick ="Update_Grid" /><br />
            <br />
            <br />
            <asp:DataGrid ID="dt" runat="server" OnUpdateCommand="Update_Grid" /><br />
            <br />
            <br />
            <asp:Label ID="Label1" runat ="server" ></asp:Label>
        </div>
    </form>
</body>
</html>

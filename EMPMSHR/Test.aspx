<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EMPMSHR.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script>
        function ss()
        {
            var Txt = '[{"ID":"12","Name":"Shujaat","Age": "34"},{"ID":"12","Name":"Shujaat","Age": "34"}]';
            var Myobj = JSON.parse(Txt);
        }
    </script>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="box.aspx.cs" Inherits="box" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
/*
 *     r     g      b      y     p
       1     2      33     44    5
      11     22     3       4    5
                                 5
*/
        .b1 {
            border-left-color:#000000;
            border-top-color:#000000;
            border-right-color:#000000;
            border-bottom-color:red;
        }
        .b2 {
            border-left-color:#000000;
            border-top-color:#000000;
            border-bottom-color:#000000;
            border-right-color:red;
        }
        .b3 {
            border-bottom-color:#000000;
            border-right-color:#000000;
            border-left-color:red;
            border-top-color:red;
        }
        .b4 {
            border-left-color:#000000;
            border-top-color:#000000;
            border-right-color:#000000;
            border-bottom-color:green;
        }
        .b5 {
            border-left-color:#000000;
            border-bottom-color:#000000;
            border-top-color:green;
            border-right-color:green;
        }
        .b6 {
            border-top-color:#000000;
            border-bottom-color:#000000;
            border-right-color:#000000;
            border-left-color:green;
        }
        .b7 {
            border-left-color:#000000;
            border-top-color:#000000;
            border-bottom-color:#000000;
            border-right-color:blue;
        }
        .b8 {
            border-bottom-color:blue;
            border-top-color:#000000;
            border-right-color:#000000;
            border-left-color:blue;
        }
        .b9 {
            border-left-color:#000000;
            border-bottom-color:#000000;
            border-right-color:#000000;
            border-top-color:blue;
        }
        .b10 {
            border-left-color:#000000;
            border-top-color:#000000;
            border-bottom-color:yellow;
            border-right-color:yellow;
        }
        .b11 {
            border-left-color:yellow;
            border-top-color:#000000;
            border-right-color:#000000;
            border-bottom-color:#000000;
        }
        .b12 {
            border-left-color:#000000;
            border-bottom-color:#000000;
            border-right-color:#000000;
            border-top-color:yellow;
        }
        .btn {
            border-style:solid;
            border-width:2px;
             Font-Size:        10px;
                Width:             20px;
                Height:            20px;
                Padding:           0px;
                Margin:          0px;
                Margin-bottom:          -1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <img src="q.gif" width="250px"/>
    <div>
    2^n x 2^n Boxes
        <br />
   n = <asp:TextBox ID="n_txt" Text="4" runat="server"></asp:TextBox> &nbsp; <asp:Button ID="create_btn" runat="server" Text="Create" OnClick="create_btn_Click" />
        <br />
        <asp:Panel ID="Box_pnl" runat="server">
        </asp:Panel>
        <asp:Panel ID="Box_pnl2" runat="server">
        </asp:Panel>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Donate.aspx.cs" Inherits="Donate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"      >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            width: 254px;
        }
    </style>
</head>
<body  style="height:350px; width:250px;">
    <form id="form1" runat="server">
    <div style="height:409px; width:250px;">
    
    
    
    
    <a href="#" onclick="javascript:window.close(); ">Close</a>
    
    
    
    <h1> Donate Credits       </h1> 
    
    
    
      <h2>  <p>    Donation Amount :      <asp:TextBox  runat="server"  id="donateAmount"></asp:TextBox> </p>  </h2>
   
    
   
    
    
    
    
    
    
    <h1> Donate Credits       </h1> 
    
    
    
    <h2>  50 cents per credit </h2> 
    
     <h2>      your total credits are :   <asp:Label   runat="server"  id="lblTotCredits"></asp:Label>    <asp:Label  runat="server"  id="lblTotCreditsf"></asp:Label>  </h2>
    
    
    <p>  Enter number of credits  &nbsp   <input type="text" runat="server"  id="txtCredits" />   </p>
    
     <p>  Total Donation   &nbsp   <input type="text" runat="server"  style="border:solid 2px white;" id="txtCreditsPrice" />   </p>
    
       <p>   &nbsp<asp:Button runat="server"  Text="Donate"  id="btnCreditsPrice" OnClick="addCredits" CommandName="addCredits" /></p>
     <p>   &nbsp<asp:Button runat="server"  Text="Return" id="btnRtrnCreditsPrice" OnClick="addCredits" CommandName="rtrnCredits" /></p>
    
    
    </div>
    </form>
</body>
</html>

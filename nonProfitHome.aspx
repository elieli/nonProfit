<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nonProfitHome.aspx.cs"  MasterPageFile="~/Site.master"            Inherits="nonProfitHome" %>


            <%@ Register src="org_Products.ascx" tagname="orgProducts" tagprefix="uc1" %>



           




            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">


    <form id="form1"   >
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
     
  <div id="home_page">
    <div id="banner"> <img src="imgs/banner01.jpg" alt="" /> </div>
    <div id="auction_row">
      <h2>Ongoing Auctions</h2>
     
     
     <div style=" clear:left; float:left;">  
          <uc1:orgProducts ID="orgProducts2" runat="server" />
      </div>
     
      <%--<ul>
      
        
      
      
    
      
    
      
      
      
      
        <li><img src="imgs/thumb01.jpg" alt="" />
          <h3>Ipod Touch 4th Generation + Protective Case</h3>
          <p class="timer">1:02:03</p>
          <p class="price">$24.23</p>
          <a href="#" class="btn"></a> </li>
          <li><img src="imgs/thumb02.jpg" alt="" />
          <h3>Ipod Touch 4th Generation + Protective Case</h3>
          <p class="timer">1:02:03</p>
          <p class="price">$24.23</p>
          <a href="#" class="btn"></a> </li>
          <li><img src="imgs/thumb03.jpg" alt="" />
          <h3>Ipod Touch 4th Generation + Protective Case</h3>
          <p class="timer">1:02:03</p>
          <p class="price">$24.23</p>
          <a href="#" class="btn"></a> </li>
          <li><img src="imgs/thumb04.jpg" alt="" />
          <h3>Ipod Touch 4th Generation + Protective Case</h3>
          <p class="timer">1:02:03</p>
          <p class="price">$24.23</p>
          <a href="#" class="btn"></a> </li>
      </ul>--%>
    </div>
<%--  </div>--%>
  
  <%--<div id="footer">
  <p><a href="#"><img src="imgs/f_icon01.gif" alt="" /></a><a href="#"><img src="imgs/t_icon01.gif" alt="" /></a></p>
  <ul>
  <li class="bg_none"><a href="#">About Us</a></li>
   <li><a href="#">Policies </a></li>
   <li><a href="#">Site Map  </a></li>
   <li><a href="#">Orders &amp; Returns</a></li>
   <li><a href="#">Register </a></li>
   <li><a href="#">Feedback</a></li>
  </ul>
  <p>&copy; 2011-2012 Nonprofit Inc. All rights reserved. Designated trademarks and brands are the property of their respective owners. Use of this websites<br  />constitutes acceptance of the Nonprofit Inc. <a href="#">User Agreement</a> and <a href="#">Privacy Policy</a>. </p>
  </div>
</div>
    --%>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
     
      
      
      
      
    
    
    </form></asp:Content>
<%--</body>
</html>--%>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
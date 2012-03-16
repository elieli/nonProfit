<%@ Control Language="C#" AutoEventWireup="true"    CodeFile="orgProducts.ascx.cs"              Inherits="orgItems" %>

 
 <%@ Register src="pageing.ascx" tagname="pageing1" tagprefix="uc1" %>
 
<link rel="stylesheet" type="text/css" href="css/style.css"  />


 <style type="text/css" >
           .pageLinks {font: bold x-small Verdana, Arial, sans-serif;}
</style>

 
    <%--
    
    	<div  runat="server" id="dvPageing">
    <uc1:pageing1 ID="pageing1" runat="server" />
    
    
    </div>--%>
    
  <%--      <hr />--%>
        
 
<%-- <asp:Repeater runat="server"   OnItemDataBound="OnDataBinding_rptBreadCrumbs" ID="rptBreadCrumbs">
 <ItemTemplate>
 <div style="width:100px;  top:30px; display:inline; height:inherit;"> 
 
 
 <asp:LinkButton    runat="server" CssClass="pageLinks"

              id="FirstPage"   Text='<%# DataBinder.Eval(Container.DataItem, 
                                              "catname") %>'

        OnCommand="BreadCrumbLink_Click" CommandName='<%# DataBinder.Eval(Container.DataItem, 
                                              "catid") %>'>
 ></asp:LinkButton>  
 
 </div>
 </ItemTemplate>
 </asp:Repeater>--%>
 
 <br />
 
      
      
      
      
      
      
      
      
      
      
      
          <%--<div class="prodcts_row">
        <ul class="products">
          <li class="first">
            <div class="img_box"><img src="images/thumb05.jpg" alt="" />
              <div  class="social_icons"><img src="images/like.gif" alt="" /></div>
              <h3>Ipod Touch 4th Genera-<br />
                tion + Protective Case</h3>
              <p class="timer">1:02:03</p>
              <p class="price">$24.23</p>
              <a href="#" class="btn"></a> </div>
          </li>--%>
      
      
      
       <%-- <div id="auction_row">--%>
    <%-- <div id="auction_div">--%>
     <%-- <h2>Ongoing Auctions</h2>--%>
     
     
  <%--   <div style="width:100px; height:10px; border-top:10px;  " >&nbsp</div>--%>
     
          <div class="prodcts_row">
     <%--   <ul class="products">--%>
  <asp:DataList ID="dtalstItems" CssClass="prodcts_row"  OnItemDataBound="rptProductList_OnItemDataBound"    
     RepeatColumns="4" runat="server" RepeatDirection="Horizontal" RepeatLayout="table" >
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
 
   <ItemStyle   CssClass=""     />
<%-- <SeparatorStyle CssClass="auction_row  Width="16px" Height="17" BorderWidth="10" />
--%>       
   
   <ItemTemplate  >
   
   
   
   
   
   
   <%-- <div class="img_box"><img src="images/thumb06.jpg" alt="" />
              <div  class="social_icons"><img src="images/like.gif" alt="" /></div>
              <h3>Ipod Touch 4th Genera-<br />
                tion + Protective Case</h3>
              <p class="timer">1:02:03</p>
              <p class="price">$24.23</p>
              <a href="#" class="btn"></a> </div>--%>
   
   
   
    <div class="products" >
                   
   
<%--   <div class="prodcts_row">--%>
      
 
  <%-- <div id="auction_row">--%>
     <div class="img_box">
     <%-- <h2>Ongoing Auctions</h2>--%>
    <img src=" " id="imgItem"     runat="server" alt="" />
        <div  class="social_icons"> </div> 
<%-- <img src="imgs/thumb01.jpg" alt="" />--%>  
        
          <%-- <div  class="social_icons"><img src="" alt="" /></div>--%>
        
          <h3 id="title" runat="server">    <span>    <%#DataBinder.Eval(Container.DataItem, "Title")%> </span>  </h3>
          
          
         <%-- Ipod Touch 4th Generation + Protective Case--%>
         <%--  <em   id="dvcountboxCover"  class="spn_cover"></em> --%>
             <p  id="countbox"          class="timer">
      
          
           </p>  
          <p class="price"  id="dvusername">&nbsp </p>
             <p class="price"  id="dvprice"> </p>
          <p ><a runat="server" id="anchorProfile"    class="btn"   ></a>  </p>   
      
          <p  class="btn" visible="false"  runat="server"  id="dvwatch"> <a  class="btn"  runat="server" id="btnwatch" value="Watch" >   </a> </p>
                    
    
   </div>
    
<%--   </div>--%>
   
 
   </div>
   
   
   
  
   
   
   
   
   
   
    
       
         <p id="dvlive" runat="server" style=" visibility:hidden;" >    </p>   
                  
   
   
   
   
     <div id="dvauctionid" runat="server" style=" visibility:hidden;" >
      </div>
      <div id="amounter" runat="server" style="    visibility:hidden;" >
      
      </div> 
      
      <div id="counter" runat="server" style="  visibility:hidden;" >
      
      </div>
      
    
      
  
    
   
    
    
  
  </ItemTemplate>
     
     
     
     
     
    
   
  
   
    
    
    </asp:DataList>
      
      <%-- </ul>--%><%--</div>--%>
       
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
       
    
<%--    </form>--%><%--</asp:Content>--%>
<%--</body>
</html>--%>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
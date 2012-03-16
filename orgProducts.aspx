<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orgProducts.aspx.cs"  MasterPageFile="Site.master"            Inherits="orgProducts" %>

 

            <%@ Register src="category.ascx" tagname="category" tagprefix="uc2" %>
           <%@ Register src="orgProducts.ascx" tagname="orgProducts" tagprefix="uc1" %> 

 
 <%@ Register src="pageing.ascx" tagname="pageing1" tagprefix="uc3" %>
 




            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server"> 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
 <ContentTemplate> 
  
<%-- <div  runat="server" visible="false"  > 
    Item Search   <asp:TextBox runat="server"   Width="100" ID="txtItemSearch"></asp:TextBox>
    
    &nbsp   &nbsp 
        <asp:Button runat="server"  Text="Item Search" OnClick="itemSearch" ID="TextBox1"></asp:Button>
    
       &nbsp   &nbsp 
    
          <asp:DropDownList runat="server" ID="drplstOrgs" AutoPostBack="true" OnSelectedIndexChanged="refreshOrgs" >
    
    </asp:DropDownList>
    
    
    
       </div>--%>
       
       
       
       
       
    <form id="form1"   >
    
    
    
    
    
    
    
    
    
    
    
    
   <%-- <div id="layout">--%>
  <%--<div id="header"> <a class="logo" href="#"><img src="images/logo.gif" alt="" /></a>
    <div class="search_sec">
      <ul>
        <li>
          <input type="text" value="Search Products" name="" class="search" />
        </li>
        <li>
          <input type="text" value="Search Within An Organization" name="" class="select" />
          <a href="#" class="select_btn"></a></li>
      </ul>
    </div>
    <p class="top_row"><strong>Welcome</strong>, <a href="#">Red Cross</a>!  (Not Red Cross? <a href="#">Click Here</a>)</p>
    <div class="menu">
      <ul>
        <li class="first"><a href="#"><span>How It Works</span></a></li>
        <li><a href="#"><span>Account </span></a></li>
        <li><a href="#"><span>My <em>22</em> Credits </span></a></li>
        <li class="auction"><a href="#">My &nbsp;   10 &nbsp; Current Auctions</a></li>
      </ul>
    </div>
  </div>--%>
  
  
  
  
  <div id="body_container">
   
      
   
   
    <div id="left_container"> 
    
      <div class="read_cross">
                <img id="dvLogo"  src=""    alt=""   runat="server" />  
      
       <img src="imgs/cross.gif" alt="" />      
      <a    href="#"   onclick= "window.open('Donate.aspx', 'width=350   height=250' );   "                 class="denote"></a>
       <a href="#" class="about_org">About this Organization</a>
        </div>
     
     
     
    
       <div class="sorting_sec">
          <asp:Button class="top_row" ID="btnBack" Text="Back to Orgnazation"    runat="server" OnClick="refresho" />	
                <asp:ImageButton ID="btnAll" runat="server" class="top_row" OnClick="showResults" Text="All" />
                <asp:ImageButton ID="btnLocked" runat="server" class="top_row"  OnClick="showResults"      Text="Locked" />
                <asp:ImageButton ID="btnLive" runat="server" class="top_row"  OnClick="showResults"  Text="Live" />
            </div>
    page
    
    
    
    
      <div class="sorting_sec">
        <h3>Sorting Options</h3>
        <p>(Refine Your Search)</p>
        <h4>CATEGORY</h4>
        <ul>
          <li class="check"><a href="#">Computers &amp; Electronics</a></li>
          <li><a href="#">Furniture</a></li>
          <li><a href="#">Jewelry</a></li>
          <li><a href="#">Antiques &amp; Collectibles</a></li>
          <li><a href="#">Clothing</a></li>
        </ul>
        <h4>CONDITION</h4>
        <ul>
          <li class="check"><a href="#">New</a></li>
          <li><a href="#">Refurbished</a></li>
          <li class="check"><a href="#">Factory Certified</a></li>
        </ul>
        <h4>SHOW</h4>
        <ul>
          <li class="check"><a href="#">All Items</a></li>
          <li><a href="#">Live Auctions</a></li>
          <li><a href="#">Locked Auctions</a></li>
          <li><a href="#">My Current Bids</a></li>
          <li><a href="#">My Purchased Items </a></li>
        </ul>
      <%--  <a class="btn" href="#">--%>
          <h4>
         <asp:ImageButton ID="Button1" runat="server" Text ="showResults"  CssClass="btn"   ImageUrl="imgs/show_results.gif"  OnClick="showResults" />    
     </h4>
      <%--  <img src="imgs/show_results.gif" alt="" />--%>
        
      <%--  </a> --%>
      
      </div>
      
      
      
      
       
                   <uc2:category ID="category1" runat="server" />
       
       
       
       
       
       
    </div>
    
    
    
    
    <div id="right_container">
    
    <div class="top_row">
     <asp:Repeater runat="server"   OnItemDataBound="OnDataBinding_rptBreadCrumbs" ID="rptBreadCrumbs">
 <ItemTemplate>
<%-- <div style="width:100px;  top:30px; display:inline; height:inherit;"> 
 --%>
  <ul class="links"><li>
 <asp:LinkButton    runat="server" CssClass="links"

              id="FirstPage"   Text='<%# DataBinder.Eval(Container.DataItem, 
                                              "catname") %>'

        OnCommand="BreadCrumbLink_Click" CommandName='<%# DataBinder.Eval(Container.DataItem, 
                                              "catid") %>'>
 ></asp:LinkButton>  
 </li></ul>
<%-- </div>--%>
 </ItemTemplate>
 </asp:Repeater>
     </div>
    
    
    
    
    
     <div class="top_row">
        <ul class="links">
          <%--<li class="first"><a href="#">AMERICAN RED CROSS</a></li>
          <li><a href="#">AUCTIONS</a></li>
          <li><a href="#">IPOD TOUCH</a></li>--%>
        </ul>
        <p>You have   <a     href="#" onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');"  > <%=credits%>  </a>  available credits. (<a href="#" onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');">Purchase Credits</a>) </p>
      </div>
     
      <div class="title_row">
       <%-- <h2>  Ipod Touch Auctions</h2>--%>
            <h2 ><span id="catHeader" runat="server"> <%=category %>  </span> </h2>
        <a href="#" class="read_all">Browse All Red Cross Items ></a>
       
       
       </div>
    
    	 
    <uc3:pageing1 ID="pageing1" runat="server" /> 
    
    <div     style=" text-align:center;    "      >          
    <asp:DropDownList runat="server" ID="drplstSort" AutoPostBack="true" OnSelectedIndexChanged="refreshSort" >
    <asp:ListItem Selected="True" Value="endTime desc"  Text="Items Ending Soonest"></asp:ListItem>   
        <asp:ListItem  Value="startBidPrice"  Text="Lowest Price Range"></asp:ListItem>
            <asp:ListItem   Value="startBidPrice desc"  Text="Highest Price Range"></asp:ListItem>       
    </asp:DropDownList>
    </div>
   
   
   
    <div>
        <uc1:orgProducts ID="orgProducts2" runat="server" /> 
      
         </div>
     <%-- <div class="top_row">
        <ul class="links">
          <li class="first"><a href="#">AMERICAN RED CROSS</a></li>
          <li><a href="#">AUCTIONS</a></li>
          <li><a href="#">IPOD TOUCH</a></li>
        </ul>
        <p>You have   <a     href="#" onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');"  > <%=credits%>  </a>  available credits. (<a href="#" onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');">Purchase Credits</a>) </p>
      </div>
     
      <div class="title_row">
        <h2>Ipod Touch Auctions</h2>
        <a href="#" class="read_all">Browse All Red Cross Items ></a>
       --%>
       
       
       
       
       
       
       <%--
        <ul class="nav">
          <li><a href="#">< Previous</a></li>
          <li class="active"><a href="#">1</a></li>
          <li><a href="#">2 </a></li>
          <li><a href="#">3 </a></li>
          <li><a href="#">4 </a></li>
          <li><a href="#">5 </a></li>
          <li><a href="#">6 </a></li>
          <li><a href="#">7 </a></li>
          <li><a href="#">8 </a></li>
          <li><a href="#">Next ></a></li>
        </ul>
        <div class="select_row"> <a href="#" class="select">12 items per page</a></div>
      </div>
      <div class="prodcts_row">
      
       <%--<div class="title_row">
          <ul class="nav">
            <li><a href="#">< Previous</a></li>
            <li class="active"><a href="#">1</a></li>
            <li><a href="#">2 </a></li>
            <li><a href="#">3 </a></li>
            <li><a href="#">4 </a></li>
            <li><a href="#">5 </a></li>
            <li><a href="#">6 </a></li>
            <li><a href="#">7 </a></li>
            <li><a href="#">8 </a></li>
            <li><a href="#">Next ></a></li>
          </ul>
        </div> 
      </div>--%>
      
      
      <%--<div class="prodcts_row">
        <ul class="products">
        --%>
        
      
      
    
      
      
      
      
      
      
      
      
      
   <%--   </ul></div>--%>
      
      
      
  <%--  </div>--%>
  </div>
  
  
  
  
  <%--
  
  <div id="footer">
    <p><a href="#"><img src="imgs/f_icon01.gif" alt="" /></a><a href="#"><img src="imgs/t_icon01.gif" alt="" /></a></p>
    <ul>
      <li class="bg_none"><a href="#">About Us</a></li>
      <li><a href="#">Policies </a></li>
      <li><a href="#">Site Map </a></li>
      <li><a href="#">Orders &amp; Returns</a></li>
      <li><a href="#">Register </a></li>
      <li><a href="#">Feedback</a></li>
    </ul>
    <p>&copy; 2011-2012 Nonprofit Inc. All rights reserved. Designated trademarks and brands are the property of their respective owners. Use of this websites<br  />
      constitutes acceptance of the Nonprofit Inc. <a href="#">User Agreement</a> and <a href="#">Privacy Policy</a>. </p>
  </div>--%>
</div>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    <%--
    
    
    <div  style="">
    
    
      
       
    
    <div  style="position:relative;"> 
    
    
    --%>
        		
					 							
					 							
					 							
             <%--   <asp:Button  ID="btnBack" Text="Back to Orgnazation"  runat="server" OnClick="refresho" />						 
        --%>
        	 <%--<div style= " padding-left:20px; float:left; ">
        	 <asp:Button runat="server" ID="btnMatch" OnClick= "chgsts"  Text="View"/>
        	 
        	 </div>
        --%>
        
    <%--
                <asp:Button ID="btnAll" runat="server" OnClick="showResults" Text="All" />
                <asp:Button ID="btnLocked" runat="server"   OnClick="showResults"      Text="Locked" />
                <asp:Button ID="btnLive" runat="server"  OnClick="showResults"  Text="Live" />
        --%>
   <%--     
        </div>
        
        
        
        <hr />
        --%>
      <%--  <asp:Button  id="btnCnfApprove"    runat="server" OnClick="approveOrg"   Text="Confirm Approve"  />
       
          
    <div  style= " text-align:left;  float:left; ">  
            <asp:Label runat="server" ID="lblsts" Text="Org status"></asp:Label><br />
        <asp:DropDownList   ID="drplstEmailSts"    OnSelectedIndexChanged="chgsts" runat="server">
        <asp:ListItem  runat="server" Text="Pending" Value="pending"></asp:ListItem>  
         <asp:ListItem   runat="server" Text="Approved" Value="approved"></asp:ListItem> 
          <asp:ListItem   runat="server" Text="Canceled" Value="canceled"></asp:ListItem> 
           <asp:ListItem   runat="server"  Selected="True" Text="All"  ></asp:ListItem>
        </asp:DropDownList>
        
         </div> --%>
    
      
    
     
   
   
   
    <%--<div     style=" text-align:center;    "      >          
    <asp:DropDownList runat="server" ID="drplstSort" AutoPostBack="true" OnSelectedIndexChanged="refreshSort" >
    <asp:ListItem Selected="True" Value="endTime desc"  Text="Items Ending Soonest"></asp:ListItem>   
        <asp:ListItem  Value="startBidPrice"  Text="Lowest Price Range"></asp:ListItem>
            <asp:ListItem   Value="startBidPrice desc"  Text="Highest Price Range"></asp:ListItem>       
    </asp:DropDownList>
    </div> 
   
   <div style="border:solid 4px white;">    
       
   
        <div     style="float:left; "   runat="server"    >
         
               
      
        
        
        
        
    <%--      
      
        <div     style="float:left;"    runat="server"      >
               
               <div style="float:left;" >
                <br />
    <div> <%-- <asp:button ID="Button1" runat="server" Text ="showResults" OnClick="showResults" />       </div>
    <br /><%--
                   <uc2:category ID="category1" runat="server" /> 
               
               </div>
               
               
               
                 <div   style="float:left;" >   
               
               
             <%--   <uc1:orgProducts ID="orgProducts2" runat="server" />- 
          
           </div>  
          
   
        
        
        
        
           </div>   
               </div>   
        
          <hr />--%>
        
        
  <%--  <div   style= " clear:left; " > 
         <h4>     <span  style="border-top:solid 0px pink;" >    <%= SubGmachTitle     %>           </span>
         
         
         
  
        
          </h4> 
        
  
        </div>--%>
     <%-- </div> --%>
<%--</div>
      --%>
      
         
      
       
      
      
     <%--  </div>   </div> --%>
      
    <script type="text/javascript" >

      //  capture();
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    </script>
    </form> </ContentTemplate> </asp:UpdatePanel>
</asp:Content>
<%--</body>
</html>--%>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orgHome.aspx.cs"    MasterPageFile="Site.master"            Inherits="orgHome" %>

 
 


            <%@ Register src="org_Products.ascx" tagname="orgProducts" tagprefix="uc1" %>







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
    
    
    
    
    
    
    
    
     <div id="body_container">
     
     
     
    <div id="left_container">
    
        <asp:Button  ID="btnBack" Text="Back to Orgnazation"  runat="server" OnClick="refresho" />						 
    
    
    
      <div class="read_cross"> 
                             <img id="dvLogo"  style="width:142px;"  src=""    alt=""   runat="server" />            
    <%--  <img src="imgs/cross.gif" alt="" /> --%>
    <a href="#"    onclick= "window.open('Donate.aspx', 'width=350   height=250' );   "                    class="denote"></a> 
    </div>
    
    
    
      <div class="address_box">      
       
       
        <p id="dvAddress">
        
        American Red Cross National Headquarters<br />
          2025 East Street, NW<br />
          Washington, DC 20006 <br />
          <br />
          1 800 RED CROSS <a href="www.redcross.org">www.redcross.org</a></p>
        <img src="imgs/thumb09.jpg" alt="" /> 
        </div>
        
        
        
        
           <div id="dvdVideo"   style="height:50px; width:60px;"  onclick="loadVideo(this);"     oninit="loadVideo(this);"  >  </div>          
                
        
              <div   style=" height:37px; width:25px;" id="Div2"> <a  href="comment.aspx?type=comment" >Add Org Comments </a> </div>
     
            
        
              <div   style=" height:37px; width:25px;" id="Div3"> <a  href="comment.aspx?type=complaint" >File Complaint </a> </div>
     
          <div   style=" height:37px; width:25px;" id="Div4"> <a  href="comment.aspx?type=complaint" >Put me on your Reminder list for new items </a> </div>
          
          	<asp:HiddenField runat="server" ID="hdnvdo" />
					 					
             <input type="hidden"  runat="server" id="hdnVideo" />
          
     <div runat="server"  visible="false" style=" height:137px; width:125px;" id="dvKnow"> </div>
   
        
        
        
    </div>
    
    
    
    
    
    
    <div id="right_container">
      <div class="top_row">
        <ul class="links">
          <li class="first"><a href="#"> NON PROFITS </a></li>
          <li><a href="#">AMERICAN RED CROSS</a></li>
        </ul>
      </div>
      <div class="title_row">
        <h2>American Red Cross</h2>
      </div>
      <div class="about_us">
        <p>Since its founding in 1881 by visionary leader Clara Barton, the American Red Cross has been the nation's premier emergency response organization. As part of a worldwide movement that offers neutral humanitarian care to the victims of war, the American Red Cross distinguishes itself by also aiding victims of devastating natural disasters. Over the years, the organization has expanded its services, always with the aim of preventing and relieving suffering.</p>
        <p>Today, in addition to domestic disaster relief, the American Red Cross offers compassionate services in five other areas: community services that help the needy; support and comfort for military members and their families; the collection, processing and distribution of lifesaving blood and blood products; educational programs that promote health and safety; and international relief and development programs.</p>
        <p>The American Red Cross is where people mobilize to help their neighbors—across the street, across the country, and across the world—in emergencies. Each year, in communities large and small, victims of some 70,000 disasters turn to neighbors familiar and new—the more than half a million volunteers and 35,000 employees of the Red Cross. Through nearly 700 locally supported chapters, more than 15 million people gain the skills they need to prepare for and respond to emergencies in their homes, communities and world.</p>
        <p>Some four million people give blood—the gift of life—through the Red Cross, making it the largest supplier of blood and blood products in the United States. And the Red Cross helps thousands of U.S. service members separated from their families by military duty stay connected. As part of the International Red Cross and Red Crescent Movement, a global network of 186 national societies, the Red Cross helps restore hope and dignity to the world's most vulnerable people.</p>
        <p>An average of 91 cents of every dollar the Red Cross spends is invested in humanitarian services and programs. The Red Cross is not a government agency; it relies on donations of time, money, and blood to do its work.</p>
        <p>The American National Red Cross is headquartered in Washington, Gail J. McGovern is President and CEO, and Bonnie McElveen-Hunter is Chairman of the Board of Governors.</p>
        <p>Read more about the American Red Cross at <a href=" http://www.redcross.org">http://www.redcross.org</a>.</p>
      </div>
    </div>
  
  
  
  
  
    <div id="home_page" >
      <div id="auction_row" class="border_none">
        <h2>Ongoing Auctions</h2>
       
       <div   style="float:left;" >   
               
               
                <uc1:orgProducts ID="orgProducts2" runat="server" />
          
           </div>  
       
       
       <%-- <ul>
          <li><img src="images/thumb01.jpg" alt="" />
            <h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
          <li><img src="images/thumb02.jpg" alt="" />
            <h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
          <li><img src="images/thumb03.jpg" alt="" />
            <h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
          <li><img src="images/thumb04.jpg" alt="" />
            <h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
        </ul>--%>
      
      
      
      
      
      
      </div>
    </div>
  </div>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
   <%-- 
    
    <div  style=" margin-left:3%; margin-right:5%;">
    
    
      
       
    
    <div  style="position:relative; border:solid 3px black; "> 
    
    
     
    
        	<asp:LinkButton  Text="Products Page" runat="server"  PostBackUrl="~/orgProducts.aspx"></asp:LinkButton>
    
    
    
        		<%--<asp:HiddenField runat="server" ID="hdnvdo" />--%>
					 					
					 							
					 
					 							
					 							
            <%--    <asp:Button  ID="btnBack" Text="Back to Orgnazation"  runat="server" OnClick="refresho" />						 --%>
        
        	 <%--<div style= " padding-left:20px; float:left; ">
        	 <asp:Button runat="server" ID="btnMatch" OnClick= "chgsts"  Text="View"/>
        	 
        	 </div>
        
        
    
                </div>
        
        
        
        <hr />
        
      <%--  <asp:Button  id="btnCnfApprove"    runat="server" OnClick="approveOrg"   Text="Confirm Approve"  />
       
          
    <div  style= " text-align:left;  float:left; ">  
            <asp:Label runat="server" ID="lblsts" Text="Org status"></asp:Label><br />
        <asp:DropDownList   ID="drplstEmailSts"    OnSelectedIndexChanged="chgsts" runat="server">
        <asp:ListItem  runat="server" Text="Pending" Value="pending"></asp:ListItem>  
         <asp:ListItem   runat="server" Text="Approved" Value="approved"></asp:ListItem> 
          <asp:ListItem   runat="server" Text="Canceled" Value="canceled"></asp:ListItem> 
           <asp:ListItem   runat="server"  Selected="True" Text="All"  ></asp:ListItem>
        </asp:DropDownList>
        
         </div>  
    
      
    
     
   
   
   
    <div     style=" text-align:center;    "      >
          
    </div>
   
   
   
   
 <%--  side sectio 
   
   <div    style="float:left; height: 617px; width:131px; border:solid 5px black;"   
            runat="server"   >
      
     
      
      
    
      
                <input type="hidden"  runat="server" id="hdnVideo" />
                --%>
                
					 					
                <%--
                             <img id="dvLogo"   style="height:50px; width:60px;"   runat="server" />            --%>
                           
      
                 <%--  <div id="dvdVideo"   style="height:50px; width:60px;"  onclick="loadVideo(this);"     oninit="loadVideo(this);"  >            
                   </div>--%>
                        
                           
            
                 <%--  <div id="dvDonate"   style="height:20px; width:60px;"   runat="server"  >            
                   </div>
                        
                           <div id="dvAddress"    style="height:50px; width:60px;"   runat="server"  >            
                             </div>
            --%>
        
        <%--
              <div   style=" height:37px; width:25px;" id="Div2"> <a  href="comment.aspx?type=comment" >Add Org Comments </a> </div>
     
            
        
              <div   style=" height:37px; width:25px;" id="Div3"> <a  href="comment.aspx?type=complaint" >File Complaint </a> </div>
     
          <div   style=" height:37px; width:25px;" id="Div4"> <a  href="comment.aspx?type=complaint" >Put me on your Reminder list for new items </a> </div>
          
          
          
          
     <div runat="server"  style=" height:137px; width:125px;" id="dvKnow"> </div>
     --%>
            
            
            
           <%-- </div>
   
   
   
   
   
    
               </div>   
        
          <hr />
        
        
     
      </div> --%>
<%--</div>
      --%>
      
         
       
      
      
   
       
      
      
  <%--     </div>  --%>
      
    <script type="text/javascript" >

      //  capture();








     ////   var dvVideo = document.getElementById('dvVideo');
     /////   window.onload(loadVideo('dvVideo'));
    
    
    
    
    
    
    </script>
    
    
     <script type="text/javascript">
         function loadVideo(dvVideo) {



             alert('yes'+ dvVideo);
             
             var hdnVideo = document.getElementById('<%=hdnVideo.ClientID%>');

             //// var dvVideo = document.getElementById('dvVideo');

             var newdiv = document.createElement('div');
             alert('hdnVideo' + hdnVideo);
             var flash = "<object width='55' height='144'>  <embed src='" + "images/" + unescape(hdnVideo.value) + "' type='application/x-shockwave-flash' width='225' height='444'></embed></object>";
             alert(flash);

             // var images = "images/" + fileLoads;

             newdiv.innerHTML = unescape(flash);

             ///alert(newdiv);

             dvVideo.appendChild(newdiv);


             alert(dvVideo.innerHTML);







         }
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
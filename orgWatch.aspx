<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orgWatch.aspx.cs"  MasterPageFile="Site.master"            Inherits="orgWatch" %>

 

        


            <%@ Register src="shoppingCart.ascx" tagname="shoppingCart" tagprefix="uc1" %>







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
    <div  style=" margin-left:3%; margin-right:5%;">
    
    
      
       
   <%-- 
    <div  style="position:relative;"> 
    
    
    
        		
					 							
					 							
					 							
                <asp:Button  ID="btnBack" Text="Back to Orgnazation"  runat="server" OnClick="refresho" />						 
        
        	 <%--<div style= " padding-left:20px; float:left; ">
        	 <asp:Button runat="server" ID="btnMatch" OnClick= "chgsts"  Text="View"/>
        	 
        	 </div>
         
        
    
                <asp:Button ID="btnAll" runat="server" OnClick="showResults" Text="All" />
                <asp:Button ID="btnLocked" runat="server"   OnClick="showResults"      Text="Locked" />
                <asp:Button ID="btnLive" runat="server"  OnClick="showResults"  Text="Live" />
        
        
        </div>--%>
        
        
        
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
        
         </div> --%>
    
      
    
     
   
   
   
    <div     style=" text-align:center;    "      >
          
    <asp:DropDownList runat="server" ID="drplstSort" AutoPostBack="true" OnSelectedIndexChanged="refreshSort" >
    <asp:ListItem Selected="True" Value="endTime desc"  Text="Items Ending Soonest"></asp:ListItem>   
        <asp:ListItem  Value="startBidPrice"  Text="Lowest Price Range"></asp:ListItem>
            <asp:ListItem   Value="startBidPrice desc"  Text="Highest Price Range"></asp:ListItem>
            
   <%--  <asp:ListItem Selected="True" Value=""  Text="Items Ending Soonest"></asp:ListItem>--%>
     
    </asp:DropDownList>
    </div>
   
   <div style="border:solid 4px white;">    
       
   
        <div     style="float:left; "   runat="server"    >
         
               
      
        
        
        
        
          
      
        <div     style="float:left;"    runat="server"      >
               
               <div style="float:left;" >
                <br />
    <div>  <asp:button ID="Button1" runat="server" Text ="showResults" OnClick="showResults" />        </div>
    <br />
              <%--     <uc2:category ID="category1" runat="server" />--%>
               
               </div>
               
               
               
                 <div   style="float:left;" >   
               
               
                <uc1:shoppingCart ID="shoppingCart2" runat="server" />
          
           </div>  
          
   
        
        
        
        
           </div>   
               </div>   
        
          <hr />
        
        
    <div   style= " clear:left; " > 
         <h4>     <span  style="border-top:solid 0px pink;" >    <%= SubGmachTitle     %>           </span>
         
         
         
  
        
          </h4> 
        
  
        </div>
      </div> 
<%--</div>
      --%>
      
         
       
      
      
    
      
       </div>  
      
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
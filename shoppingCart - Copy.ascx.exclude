<%@ Control Language="C#" AutoEventWireup="true"    CodeFile="shoppingCart.ascx.cs"              Inherits="shoppingCart" %>


 <%@ Register src="pageing.ascx" tagname="pageing1" tagprefix="uc1" %>


 <style type="text/css" >
           .pageLinks {font: bold x-small Verdana, Arial, sans-serif;}
</style>


  <%--  <form id="form1"   >--%>
    
    
    	<div  runat="server" id="dvPageing">
    <uc1:pageing1 ID="pageing1" runat="server" />
    
    
    </div>
    
    
    <div  style=" margin-left:3%; margin-right:5%;">
    
    
    
    <div  style="position:relative;"> 
    
    
    
        		
					 							
						 
        
        	 <%--<div style= " padding-left:20px; float:left; ">
        	 <asp:Button runat="server" ID="btnMatch" OnClick= "chgsts"  Text="View"/>
        	 
        	 </div>
        --%>
        
        
        </div>
        
        
        
        <hr />
        
       <%-- <asp:Button  id="btnCnfApprove"    runat="server" OnClick="approveOrg"   Text="Confirm Approve"  />--%>
       
          
   <%-- <div  style= " text-align:left;  float:left; ">  
            <asp:Label runat="server" ID="lblsts" Text="Org status"></asp:Label><br />
        <asp:DropDownList   ID="drplstEmailSts"    OnSelectedIndexChanged="chgsts" runat="server">
        <asp:ListItem  runat="server" Text="Pending" Value="pending"></asp:ListItem>  
         <asp:ListItem   runat="server" Text="Approved" Value="approved"></asp:ListItem> 
          <asp:ListItem   runat="server" Text="Canceled" Value="canceled"></asp:ListItem> 
           <asp:ListItem   runat="server"  Selected="True" Text="All"  ></asp:ListItem>
        </asp:DropDownList>
        
         </div> --%>
        <hr />
        
        
    <div   style= " clear:left; " > 
         <h4>     <span  style="border-top:solid 0px pink;" >    <%= SubGmachTitle     %>           </span>
         
         
         
  
        
          </h4> 
        
   
    
      </div> </div>  
      
      
      
      
      
      
      
      
      
      
 
 
 <br />
 
 <asp:Repeater runat="server"   OnItemDataBound="OnDataBinding_rptBreadCrumbs" ID="rptBreadCrumbs">
 <ItemTemplate>
 <div style="width:100px;  top:30px; display:inline; height:inherit;"> <%# Eval("catname") %> > </div>
 </ItemTemplate>
 </asp:Repeater>
 
 <br />
      
  <asp:DataList ID="dtalstItems"  OnItemDataBound="rptProductList_OnItemDataBound"    
     RepeatColumns="4" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" >
   
   
 
   <ItemStyle   Width="220px"    />
 <SeparatorStyle Width="16px" Height="17" BorderWidth="10" />
       
   
   <ItemTemplate>
     <div id="dvauctionid" runat="server" style="  visibility:hidden;" >
      </div>
      <div id="amounter" runat="server" style="  visibility:hidden;" >
      
      </div>
      
      <div id="counter" runat="server" style="  visibility:hidden;" >
      
      </div>
      
       <div  id="dvusername"  runat="server"   >   </div>
  <br />  <br /> 
  <div  id="dvprice"   runat="server"  >   </div>
    
    
    
     
   
     <div  id="amount" style="font-size:  15pt; color: Red; font-family: Arial Black;
                                                                            display: inline">
                    </div>
    </div>
    
    
    
         <div> <a runat="server" id="anchorProfile"    >  
    
                <span> &nbsp   &nbsp    <%#DataBinder.Eval(Container.DataItem, "itemAuctionID")%>
                 </span>      </a> 
        </div>
  
  
    <div>
  
    
    
    
    
               
                  <%-- <div >
                    <input type="button" runat="server" id="btnwatch" value="Watch"  />
                     </div--%>>
                    
    
    
     </div>
    
    
   
    <%-- <div  >
    <asp:Label runat="server" id="id" Text='<%#DataBinder.Eval(Container.DataItem, "orgID") %>'></asp:Label>
     <%#DataBinder.Eval(Container.DataItem, "orgID")%>
   

      <%# Eval("title")%> 
  
      <a   href=''>     </a> 
   
    </div>--%>
      <div  id="dv_Emil"  style="float:left; " runat="server"> 
       <p runat="server" id="title"     >  
     <%--   <a href='orgProduct.aspx?   <%# Eval(Container.DataItem, "itemida")%>  ' > --%> 
                  <span>    <%#DataBinder.Eval(Container.DataItem, "Title")%> </span>  </p> 
    
    <p   style=" margin-left:-40px;    vertical-align:text-top; text-align:left; ">
       <div  id="Div1" style="float:left;"   runat="server">
 <%--   <img  src="Images/contact/submit_button.jpg" alt="" id="Img1" /> --%>
  
 
 <img  src='' width="150" alt="" id="imgItem" runat="server" />
 
 
   
    </div>
  
  <%-- <%# Eval("orgDescription")%>'  runat="server" />--%>
   
  <%--  <%#DataBinder.Eval(Container.DataItem, "auctionType")%>  
    --%>
  
  
  <br />  <br /> 
   <div style=" font-size:small;">
  
  <p> Current Price: &nbsp   &nbsp <%#DataBinder.Eval(Container.DataItem, "price")%>  <br /> 
    
    
                        Ends: &nbsp   &nbsp  <%#DataBinder.Eval(Container.DataItem, "endTime")%>  </p>   
    </div>
  
    
   
    
    
      </div>
  </ItemTemplate>
     
     
     
     
     
    
   
  
   
    
    
    </asp:DataList>
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
       
    
<%--    </form>--%></asp:Content>
<%--</body>
</html>--%>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
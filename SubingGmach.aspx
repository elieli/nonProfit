<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubingGmach.aspx.cs"  MasterPageFile="Site.master"            Inherits="SubingGmach" %>




            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">


    <form id="form1"   >
    <div  style=" margin-left:3%; margin-right:5%;">
    
    
    
    <div  style="position:relative;"> 
    
    
    
        		
					 							
						 
        
        	 <%--<div style= " padding-left:20px; float:left; ">
        	 <asp:Button runat="server" ID="btnMatch" OnClick= "chgsts"  Text="View"/>
        	 
        	 </div>
        --%>
        
        
        </div>
        
        
        
        <hr />
        
        <asp:Button  id="btnCnfApprove"    runat="server" OnClick="approveOrg"   Text="Confirm Approve"  />
       
          
    <div  style= " text-align:left;  float:left; ">  
            <asp:Label runat="server" ID="lblsts" Text="Org status"></asp:Label><br />
        <asp:DropDownList   ID="drplstEmailSts"    OnSelectedIndexChanged="chgsts" runat="server">
        <asp:ListItem  runat="server" Text="Pending" Value="pending"></asp:ListItem>  
         <asp:ListItem   runat="server" Text="Approved" Value="approved"></asp:ListItem> 
          <asp:ListItem   runat="server" Text="Canceled" Value="canceled"></asp:ListItem> 
           <asp:ListItem   runat="server"  Selected="True" Text="All"  ></asp:ListItem>
        </asp:DropDownList>
        
         </div> 
        <hr />
        
        
    <div   style= " clear:left; " > 
         <h4>     <span  style="border-top:solid 3px pink;" >   <%= SubGmachTitle     %>          </span>
         
         
         
  
        
          </h4> 
        
  
    <asp:GridView ID="grdvSubGmach" OnRowDataBound="SubGmachBind"   OnRowCancelingEdit="emailsub" OnRowUpdating="RowUpdating"   OnRowUpdated="Row_Updating"   OnSelectedIndexChanging="indexchange"  OnRowDeleting="Delete"  OnRowEditing="Edit"  OnRowCommand="RowCommand" runat="server" 
   
  
   
     ForeColor="#333333" GridLines="None" ShowFooter="True" Caption= ' <h4>     <span  style="border-top:solid 3px pink;" >                </span> </h4>      '
            CaptionAlign="Top">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />  
    <Columns>
          
         
         
         
         
                     
           
                
    <asp:CommandField   ButtonType="Link" HeaderText=""   ShowDeleteButton="false"   ShowEditButton="true"  ItemStyle-Width="35"   DeleteText="Delete"       NewText="NewText"  SelectText="SelectText" CancelText="Cancel" EditText="Edit"/>
   
     <asp:CommandField   ButtonType="Link" HeaderText=""    SelectText="Confirm"  ShowSelectButton="true"  ItemStyle-Width="35"    />
  
<%--   <asp:ButtonField Text="Confirm Approval"  ButtonType="Image"    />
--%>    
  <%--  <asp:BoundField DataField="id" SortExpression="" HeaderText="   ID     "    ReadOnly="true"   ItemStyle-Width="135"  />
  --%> 
     
     
      
     
     <asp:TemplateField HeaderText="ID">
   
   <ItemTemplate> <asp:Label runat="server" id="id" Text='<%#DataBinder.Eval(Container.DataItem, "orgID") %>'></asp:Label>
     <%#DataBinder.Eval(Container.DataItem, "orgID")%>
   </ItemTemplate>
   
    <EditItemTemplate >
   <div >
   
  
     
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
     
     
     
     
     
     
     <asp:TemplateField HeaderText="Approve/Cancel">
   
   <ItemTemplate>
   
 
   
       <asp:CheckBox ID="chkStatus"  runat="server" />
     
     <asp:Label    ID="lblSts"   Text=  '<%#DataBinder.Eval(Container.DataItem, "orgStatus") %>'  runat="server"  > </asp:Label>
     
   <%-- <asp:DropDownList   ID="drplstSts"    runat="server">
         <asp:ListItem  runat="server" Text="Pending" Value="pending"></asp:ListItem>  
         <asp:ListItem   runat="server" Text="Approved" Value="approved"></asp:ListItem> 
          <asp:ListItem   runat="server" Text="Canceled" Value="canceled"></asp:ListItem> 
           <asp:ListItem   runat="server"  Selected="True" Text="All"  ></asp:ListItem>
        </asp:DropDownList>--%>
   
    
      </ItemTemplate>
     </asp:TemplateField>
     
      
     
     
     <asp:TemplateField HeaderText="Org Title">
      <ItemTemplate>
  <%#DataBinder.Eval(Container.DataItem, "orgTitle")%>
   
   </ItemTemplate>
     
    <EditItemTemplate >
   <div  id="dv_Emil" runat="server">
    <asp:TextBox id="orgTitle"     Text='<%# Eval("orgTitle")%>'  runat="server" />
   </div>
   </EditItemTemplate>
     </asp:TemplateField>
   
   
    
     
     
      
   
   
  
     
     
      <asp:TemplateField HeaderText="org Functionality">
   
   <ItemTemplate>
   
     <asp:Label     Text='<%# Eval("orgFucnionality")%>'  runat="server" />
   
     
   </ItemTemplate>
   
    <EditItemTemplate >
   <div   runat="server">
   
    <asp:TextBox id="orgFunct"     Text='<%# Eval("orgFucnionality")%>'  runat="server" />
     
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
     
     
     
     
     
      <asp:TemplateField HeaderText="Monday">
   
   <ItemTemplate>
    <asp:Label ID="orgDesc_"  Enabled="false"    Text='<%# Eval("orgDescription")%>'  runat="server" />
   
   
   </ItemTemplate>
   
    <EditItemTemplate >
   <div  id="d1" runat="server">
   
       <asp:TextBox id="orgDesc"     Text='<%# Eval("orgDescription")%>'  runat="server" />
  
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
     
      
     
     
      <asp:TemplateField HeaderText="Tuesday">
   
   <ItemTemplate>
   
    <asp:TextBox id="orgTaxID_"     Text='<%# Eval("org_TaxID")%>'  runat="server" />
   
    
   </ItemTemplate>
   
    <EditItemTemplate >
   <div  id="d2" runat="server">
   
     <asp:TextBox id="orgTaxID"     Text='<%# Eval("org_TaxID")%>'  runat="server" />
    
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
    
      
     
     
      <asp:TemplateField HeaderText="wednesday">
   
   <ItemTemplate>
   
      <asp:TextBox id="orgEmail_"     Text='<%# Eval("org_email")%>'  runat="server" />
 
     
   </ItemTemplate>
   
    <EditItemTemplate >
   <div  id="d3" runat="server">
   
      <asp:TextBox id="orgEmail"     Text='<%# Eval("org_email")%>'  runat="server" />
   
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
 
    
     
     
     
      <asp:TemplateField HeaderText="Thursday">
   
   <ItemTemplate>
   
    <asp:TextBox id="orgPaypal_"     Text='<%# Eval("org_paypalAccount")%>'  runat="server" />
   
    
   </ItemTemplate>
   
    <EditItemTemplate >
   <div  id="d5" runat="server">
   
      <asp:TextBox id="orgPaypal"     Text='<%# Eval("org_paypalAccount")%>'  runat="server" />
   
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
 
    
     
      <asp:TemplateField HeaderText="Friday">
   
   <ItemTemplate>
   
      <asp:TextBox id="orgLogo_"     Text='<%# Eval("orgLogo")%>'  runat="server" />
 
    
   </ItemTemplate>
   
    <EditItemTemplate >
   <div  id="f6" runat="server">
   
      <asp:TextBox id="orgLogo"     Text='<%# Eval("orgLogo")%>'  runat="server" />
   
   
    </div>
   </EditItemTemplate>
     </asp:TemplateField>
     
     
    
 
 
     
    
 
 
 
 
 
 
 
 
   
 
 
 
  
 
 
 
 
 
 
 
 
 
 
 
 
 
  
         
  
   
   
   
   
   
   
   
   
   
   
   
     
     
     
     
     
     
     
     
   
   
   
    
    
    
    
    
    
    
    
    
    
   
   
   
   
    </Columns>
   
    
    
   
    
    </asp:GridView>
    
      </div> </div>   
    
    </form></asp:Content>
<%--</body>
</html>--%>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
﻿<%@ Page Language="C#" AutoEventWireup="true"         CodeFile="OrgForm.aspx.cs" Inherits="OrgForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>   <link rel="stylesheet type='text/css' href='App_Themes/professional.css'" />
</head>
<body>
    <form id="form1" runat="server">
      <div style=" top:0px; left:0px; margin-left:40px;margin-top:40px;">
    
    </div>
    <asp:ListView ID="ListView1" runat="server" style="margin-top: 36px">
    </asp:ListView>
   
   
         
         <h4>     <span  style="border-top:solid 3px pink;" >   <%= SubGmachTitle     %>          </span> </h4> 
  
    <asp:GridView ID="grdvSubGmach"      runat="server" 
   
     ForeColor="#333333" GridLines="None" ShowFooter="True" Caption= ' <h4>    <span  style="border-top:solid 3px pink;" >         </span> </h4>      '
            CaptionAlign="Top">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />  
   
    <Columns>
    
    
           
                
   <%-- <asp:CommandField   ButtonType="Link" HeaderText="Email"  ShowDeleteButton="true"  ShowEditButton="true"  ItemStyle-Width="35"   DeleteText="Delete"    NewText="NewText"  SelectText="SelectText" CancelText="Cancel" EditText="Edit"/>
   --%>
    
    <asp:BoundField DataField="id" SortExpression="" HeaderText="   ID     "       ItemStyle-Width="135"  />
     <asp:BoundField DataField="subStatus" SortExpression="" HeaderText="Status" ItemStyle-Width="135"  />
  <asp:BoundField DataField="subType" SortExpression="" HeaderText="Type"  ItemStyle-Width="135"  >
    <ItemStyle HorizontalAlign="Center"   Width="35px"/></asp:BoundField>
    
 
   <asp:CheckBoxField DataField="sunday" ReadOnly="true"   HeaderText="       Sunday          "  ItemStyle-Width="135"  />
      <asp:CheckBoxField DataField="monday"  ReadOnly="true"   HeaderText="          Monday           "   ItemStyle-Width="135"            />
        <asp:CheckBoxField DataField="tuesday" ReadOnly="true"   HeaderText="          Tuesday          " ItemStyle-Width="135"  />
      <asp:CheckBoxField DataField="wednesday"  ReadOnly="true"  HeaderText="Wednesday" ItemStyle-Width="135"  />
        <asp:CheckBoxField DataField="thursday" ReadOnly="true"   HeaderText="Thursday" ItemStyle-Width="135"  />
         <asp:CheckBoxField DataField="friday" ReadOnly="true"   HeaderText="Friday" ItemStyle-Width="135"  />
         
           
      <asp:CheckBoxField DataField="morning" ReadOnly="true"   HeaderText="morning"  />
        <asp:CheckBoxField DataField="afternoon" ReadOnly="true"   HeaderText="afternoon"  />
         <asp:CheckBoxField DataField="evening"  ReadOnly="true"  HeaderText="evening"   ItemStyle-Width="65"  />
          <%-- <asp:BoundField DataField="sep" SortExpression=""  ItemStyle-Width="165"       />--%>
 
 
  <asp:BoundField DataField="name" SortExpression="" HeaderText="   Name     "       ItemStyle-Width="135"  />
     <asp:BoundField DataField="tel" SortExpression="" HeaderText="   Telephone     "       ItemStyle-Width="135"  />
 <asp:BoundField DataField="email" SortExpression="" HeaderText="   Email     "       ItemStyle-Width="135"  />
 <asp:BoundField DataField="avail_request" SortExpression="" HeaderText="   avail_request     "       ItemStyle-Width="135"  />

 
 <%--  <asp:CheckBoxField DataField="reqsunday" ReadOnly="true"   HeaderText="Sunday"  ItemStyle-Width="35"  />
      <asp:CheckBoxField DataField="reqmonday"  ReadOnly="true"   HeaderText="Monday"  />
        <asp:CheckBoxField DataField="reqtuesday" ReadOnly="true"   HeaderText="Tuesday"  />
      <asp:CheckBoxField DataField="reqwednesday"  ReadOnly="true"  HeaderText="Wednesday"  />
        <asp:CheckBoxField DataField="reqthursday" ReadOnly="true"   HeaderText="Thursday"  />
         <asp:CheckBoxField DataField="reqfriday" ReadOnly="true"   HeaderText="Friday"  />        
           
      <asp:CheckBoxField DataField="reqmorning" ReadOnly="true"   HeaderText="morning"  />
        <asp:CheckBoxField DataField="reqafternoon" ReadOnly="true"   HeaderText="afternoon"  />
         <asp:CheckBoxField DataField="reqevening"  ReadOnly="true"  HeaderText="evening"  />--%>
         
         
 
   <asp:TemplateField>
   <ItemTemplate>
   <%--<a href="mailto:<%#Eval("email") %>"> click</a>--%>
    <a href="#"   onclick= "window.open('Sendemail.aspx?prm=<%#Eval("prm")%>&id=<%#Eval("id")%>&sunday=<%#Eval("sunday") %>&monday=<%#Eval("monday") %>&tuesday=<%#Eval("tuesday") %>&wednesday=<%#Eval("wednesday")%>&thursday=<%#Eval("thursday")%>&friday=<%#Eval("friday")%>&morning=<%#Eval("morning")%>&afternoon=<%#Eval("afternoon")%>&evening=<%#Eval("evening") %>&subtype=<%#Eval("subtype")%>&email=<%#Eval("email") %>&reqemail=<%#Eval("reqemail") %>','','scrollbars=no,menubar=no,height=560,width=560,resizable=no,toolbar=no,location=no,status=no');">Send Email</a>
   <%--<asp:Button OnClick="editGrid" runat="server" Text="Email" CommandName="Email" CommandArgument="Email" OnClientClick=""   ID="EmailMatch" />--%>
  
   </ItemTemplate>
   
   <EditItemTemplate >
   <div  id="dvEmil" runat="server">
<%-- <asp:TextBox Columns="13" Rows="8"   Height="10" runat="server" id="txtemail" ></asp:TextBox>
--%>   <textarea id="txt_email" rows="30" cols="30" runat="server"></textarea>
    <br />
  <%--  <asp:Button id="btnEmail"  OnClick="email" runat="server"/>
--%>   
   </div>
   </EditItemTemplate>
    </asp:TemplateField>
   
   
  <%-- <asp:TemplateField>
   <ItemTemplate>
  <a href="#"   onclick= "window.open('Sendemail.aspx?id=<%#Eval("id") %>&email=<%#Eval("email") %>&reqemail=<%#Eval("reqemail") %>    ','','scrollbars=no,menubar=no,height=660,width=860,resizable=no,toolbar=no,location=no,status=no');">View Detail</a>
   <%--<asp:Button OnClick="editGrid" runat="server" Text="Email" CommandName="Email" CommandArgument="Email" OnClientClick=""   ID="EmailMatch" /> 
  
   </ItemTemplate>
   
   
   </asp:TemplateField>--%>
   
   
    </Columns>
   
    
    
   
    
    </asp:GridView>
   
   
   
   
   
   
    </form>
</body>
</html>

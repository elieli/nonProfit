<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testter.aspx.cs"    MasterPageFile="Site.master"         Inherits="testter" %>

<%@ Register src="pageing.ascx" tagname="pageing" tagprefix="uc1" %>
   <%@ Register src="orgProducts.ascx" tagname="orgProducts" tagprefix="uc2" %> 
   
   
            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server"> 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
 <ContentTemplate> 
 
 
 
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">--%>
    <div>
    
    </div>
    
    
 
        <uc2:orgProducts ID="orgProducts2" runat="server" /> 
      
    
    
    <uc1:pageing ID="pageing1" runat="server" />
    </form></ContentTemplate> </asp:UpdatePanel>
</asp:Content>
<%--</body>
</html>
--%>
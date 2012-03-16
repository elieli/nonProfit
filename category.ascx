<%@ Control Language="C#" AutoEventWireup="true" CodeFile="category.ascx.cs" Inherits="categoryProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     
    
    
    
</head>
<body>--%>


 
     <style type="text/css">
    .catlstbx {float:left ; width:250px; height:200px; padding-right:50px; }
    button {
    padding-right: 10px;
}
 
button {
    background: none repeat scroll 0 0 transparent;
    border: 0 none;
    margin: 0;
    overflow: visible;
    padding: 0;
    text-indent: inherit;
    vertical-align: middle;
    width: auto;
}
    </style>





    <form id="form1"  >
  
    
   
  
    
    <%--  <div>
    
    <div><input type="text" title="Enter a UPC, ISBN, or keywords that describe your item." autocomplete="off" aria-owns="results" role="combobox" aria-expanded="false" aria-autocomplete="list" class="posRelat" value="baby" name="keywords" id="keywords"><input type="hidden" value="" tabindex="-1" name="keywords1" id="keywords1"><input type="hidden" value="" tabindex="-1" name="acKeywords" id="acKeywords"><input type="submit" title="Search" value="Search" name="aidZ4" id="aidZ4"></div><div aria-hidden="true" style="display: none;" class="clgAutoCmplLyr" id="lyrCatalogAutoComplete"><div role="listbox" class="results" id="results"><div style="display: none;" id="suggLyr"></div><div id="kwResultSet"></div><div class="vertDiv" id="vertDiv"></div><div id="resultSet"></div>
    
    <div></div><div id="nav" class="nav"><a id="lnkSeeMoreProd" href="javascript:{}">See all matching products</a></div></div></div>
    <div role="status" aria-relevant="text" aria-atomic="true" aria-live="assertive" class="g-hdn" id="ariaSugLyr"></div><div style="display: none;" class="idtHrz"></div><script language="JavaScript" type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
</script>  --%>   


<%--</div><div class="idtTopSm help">
		For example: Amethyst gemstone rings</div></div></div> --%>
       
    
    
    
    
  <%--  
    <div>
    
     
     
     </div>
    --%>
    
    
    
    
    
    
    
     
    
    <div   style="float:left; width:150px; "  class="idt">
      <br />
     <br />
  <%--<div>  <asp:button runat="server" Text ="showResults" OnClick="showResults" />        </div> --%>
   
   
   
   
   
    <br />    <br />
     <div style="float:left; width:150px;  font-style:oblique;" ><strong> Price Range      </strong> 
        </div>  
  <div>Lowest &nbsp  <asp:TextBox  runat="server" ID="txtPriceStart"   >  </asp:TextBox> 
  <asp:RegularExpressionValidator  runat="server"   ValidationExpression="^\d*$" Text="must be numeric"  ControlToValidate="txtPriceStart" ></asp:RegularExpressionValidator> 
     </div>   
     
     
     <div>      
   Highest  &nbsp  <asp:TextBox  runat="server" ID="txtPriceEnd"   >  </asp:TextBox> 
   </div>
   
<%--   </div>--%>
      
    <div style=" padding-top:20px;  font-style:oblique;width:150px;"> 
    <asp:Button runat="server" OnClick="refreshCat"  Text="Refresh Categories" /> 
      </div>
 <%--   <div><asp:TextBox runat="server" ID="txtSearch"></asp:TextBox> </div>--%>
    
    
    
    
    
   
 
      <div><p runat="server" ID="catSelect"></p> 
                <asp:ListBox ID="lstcat" DataTextField="Category"  DataValueField="catID"      AutoPostBack="true"
                 OnSelectedIndexChanged="subCat" style=" float:left ; width:150px; height:300px;  "  runat="server"> </asp:ListBox>   
    
    
  
    <%--
    <div> <asp:ListBox ID="lstcatsub1" DataTextField="Category"  Visible="false"  DataValueField="catID" AutoPostBack="true" OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; padding-right:50px;   height:300px;"  runat="server"> </asp:ListBox>   </div>
    
    
      
    <div> <asp:ListBox ID="lstcatsub2" DataTextField="Category"   Visible="false"  DataValueField="catID" AutoPostBack="true" OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; padding-right:50px; height:300px;  "  runat="server"> </asp:ListBox>   </div>
    
   
          
    <div> <asp:ListBox ID="lstcatsub3" DataTextField="Category"   Visible="false"  DataValueField="catID" AutoPostBack="true" OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; height:300px; padding-right:50px;   "  runat="server"> </asp:ListBox>   </div>
    --%>
        
        
        
        
        </div>
        
        
        
        
     
        
        </div>
      
         
         
          
     
    <script language="JavaScript" type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
</script>





 
    
   
    </form>
<%--</body>
</html>
--%>
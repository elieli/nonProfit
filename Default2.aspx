<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     
    
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
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    
    
    <div><div><div class="idtHrz"><div><div class="verSpc"> </div>Enter a UPC, ISBN, or keywords that describe your item.</div>
    <div><div><input type="text" title="Enter a UPC, ISBN, or keywords that describe your item." autocomplete="off" aria-owns="results" role="combobox" aria-expanded="false" aria-autocomplete="list" class="posRelat" value="baby" name="keywords" id="keywords"><input type="hidden" value="" tabindex="-1" name="keywords1" id="keywords1"><input type="hidden" value="" tabindex="-1" name="acKeywords" id="acKeywords"><input type="submit" title="Search" value="Search" name="aidZ4" id="aidZ4"></div><div aria-hidden="true" style="display: none;" class="clgAutoCmplLyr" id="lyrCatalogAutoComplete"><div role="listbox" class="results" id="results"><div style="display: none;" id="suggLyr"></div><div id="kwResultSet"></div><div class="vertDiv" id="vertDiv"></div><div id="resultSet"></div><div></div><div id="nav" class="nav"><a id="lnkSeeMoreProd" href="javascript:{}">See all matching products</a></div></div></div>
    <div role="status" aria-relevant="text" aria-atomic="true" aria-live="assertive" class="g-hdn" id="ariaSugLyr"></div><div style="display: none;" class="idtHrz"></div><script language="JavaScript" type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   (function() {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       var c = ebay.oDocument.addConfig(new EbayConfig('Selling.Catalog.AutoComplete')); c.sSearchBtn = 'pfsrch'; c.sTxtName = 'keywords'; c.sLyrName = 'lyrCatalogAutoComplete'; c.sHdnACKywd = 'acKeywords'; c.sSuggLyr = 'suggLyr'; c.sResultsName = 'results'; c.sResultSetName = 'resultSet'; c.sKwResultSetName = 'kwResultSet'; c.sVertDiv = 'vertDiv'; c.sKwResLyrIdPrefix = 'keySug_'; c.sActiveClass = 'activeTag'; c.sPassiveClass = 'passiveTag'; c.sARIALyrName = 'ariaSugLyr'; c.sARIAMsg = 'Suggestions are available. Use up and down arrow keys to select suggestions.'; c.iNumFetchSizeAc = 3; c.mtchKwHTML = '&lt;div style=\'padding: 5px 10px;border-bottom:1px solid #CCC;\'&gt;Suggested keywords&lt;/div&gt;'; c.mtchAcHTML = '&lt;div style=\'padding:5px 0 5px 15px;border-bottom:1px solid #CCC;\'&gt;Suggested products&lt;/div&gt;'; c.iNumFetchSizeKw = 5; c.sSTBaseUrl = 'http://cgi5.ebay.com/ws/eBayISAPI.dll?MfcISAPICommand=Syi3GetSellerTags&amp;siteId=0&amp;catId=0&amp;actionId=4&amp;originalValue='; c.sSuggText = '&lt;i&gt;Showing results for &lt;b&gt;&lt;#1#&gt; &lt;/b&gt;(instead of &lt;#2#&gt;)&lt;/i&gt;'; c.sDividerHTML1 = '&lt;div&gt;&lt;div style=\'border-bottom: 1px solid #ccc;\' height=\'1px\' width=\'100%\'&gt;&amp;nbsp;&lt;/div&gt;&lt;/div&gt;'; c.sDividerHTML2 = '&lt;div style=\'padding-bottom: 15px;\'&gt;&lt;div style=\'border-bottom: 1px solid #ccc;\' height=\'1px\' width=\'100%\'&gt;&amp;nbsp;&lt;/div&gt;&lt;/div&gt;'; c.sAJAXUrl = 'http://autocomplete.ebay.com/jsonp/services/search/AutoCompleteQueryService/v1?X-EBAY-SOA-SERVICE-NAME=AutoCompleteQueryService&amp;X-EBAY-SOA-OPERATION-NAME=queryDictionary&amp;X-EBAY-SOA-RESPONSE-DATA-FORMAT=JSON&amp;fetchSize=21&amp;dictionaryName=USProducts&amp;queryTerm='; c.sKwAJAXUrl = 'http://autocomplete.ebay.com/jsonp/services/search/AutoCompleteQueryService/v1?X-EBAY-SOA-SERVICE-NAME=AutoCompleteQueryService&amp;X-EBAY-SOA-OPERATION-NAME=queryDictionary&amp;X-EBAY-SOA-RESPONSE-DATA-FORMAT=JSON&amp;fetchSize=11&amp;dictionaryName=USKeywords&amp;queryTerm=&lt;#1#&gt;'; c.iTimer = 50; c.sProductUrl = 'http://cgi5.ebay.com/ws/eBayISAPI.dll?NewListing&amp;itemid=&amp;sid=113059918410&amp;cpg=4&amp;js=1&amp;aid=4&amp;keywords=&lt;#1#&gt;&amp;ac=&lt;#2#&gt;&amp;acdo=&lt;#3#&gt;'; c.sNavName = 'nav'; c.sSeeMoreProdLnk = 'lnkSeeMoreProd'; c.sSeeMoreProdUrl = 'http://cgi5.ebay.com/ws/eBayISAPI.dll?NewListing&amp;itemid=&amp;sid=113059918410&amp;cpg=4&amp;js=1&amp;aid=305&amp;SearchString=&lt;#1#&gt;&amp;MetaCategory=&lt;#2#&gt;'; c.sBegHTML = '&lt;ul&gt;'; c.sEndHTML = '&lt;/ul&gt;'; c.iNumResForScroll = 6; c.bKwON = true; c.bAcON = true; c.bWithPhotos = true; c.sCtnHTML = '&lt;div id="&lt;#1#&gt;" style="padding-bottom:10px;" class="wp"&gt;&lt;a href="&lt;#2#&gt;"&gt;&lt;#3#&gt;&lt;#4#&gt;&lt;/a&gt;&lt;/div&gt;'; c.sImgHTML = '&lt;img src="&lt;#1#&gt;" width="35" height="35" class="mgnRgt" border="0" align="left" alt="Stock photo" /&gt;'; c.sImgPHHTML = '&lt;div class="defImg"&gt;NO IMAGE&lt;/div&gt;';
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   })();
</script></div><div class="idtTopSm help">
		For example: Amethyst gemstone rings</div></div></div></div>
    
       
    
    
    
    
    
    <div><ul role="tablist" class="tab"><li class="inactive" role="presentation"> </span></li>
    
    
    <li class="active" aria-selected="true" role="presentation"><span><a role="tab" id="browsecatlink" href="#">Browse categories</a></span></li></ul><div aria-labelledby="browsecatlink" role="tabpanel" class="secTab"><div class="idt"><label for="fcat">Categories</label>
    
    
    
 
    
    <div class="catlstbx"> <asp:ListBox ID="lstcat" DataTextField="Category"  DataValueField="catID" AutoPostBack="true"     OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; height:300px; padding-right:50px;  "  runat="server"> </asp:ListBox>   </div>
    
    
    
    <div> <asp:ListBox ID="lstcatsub1" DataTextField="Category"  Visible="false"  DataValueField="catID" AutoPostBack="true" OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; padding-right:50px;   height:300px;"  runat="server"> </asp:ListBox>   </div>
    
    
      
    <div> <asp:ListBox ID="lstcatsub2" DataTextField="Category"   Visible="false"  DataValueField="catID" AutoPostBack="true" OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; padding-right:50px; height:300px;  "  runat="server"> </asp:ListBox>   </div>
    
   
          
    <div> <asp:ListBox ID="lstcatsub3" DataTextField="Category"   Visible="false"  DataValueField="catID" AutoPostBack="true" OnSelectedIndexChanged="subCat" style=" float:left ; width:200px; height:300px; padding-right:50px;   "  runat="server"> </asp:ListBox>   </div>
    
        
        
        
    <div class="catlstbx"  id="catlstbx" runat="server" visible="false">    <table class="broCatSel" cellspacing="0" border="0">
<tbody>
<tr>
<td colpsan="2">
<img height="6" width="1" alt=" " src=" "/>
</td>
</tr>
<tr>
<td width="42" valign="top">
<img height="1" width="10" alt=" " src=" "/>
<a class="g-hdn" href="javascript:{}">Success</a>
<img border="0" align="top" alt="Success" src=" "/>
</td>
<td class="vieItmPreBoxCon" valign="top">
You've selected a category. Click
<b>Continue</b>
.
</td>
</tr>
</tbody>
</table></div> 
        
        
        
        <div>
        <span id="aidZ1_btnFrm" class="btn">
<span id="aidZ1_btnLbl" class="btn">Continue</span>
</span>
        
       <asp:button runat="server" id="aidZ1" class="btnMain" aria-disabled="false"   OnClick="catProd"   Text="Continue" role="button" type="submit" name="aidZ1">

</asp:button> 
         </div>
         
         
         
          
    
    <div aria-atomic="true" aria-relevant="text" aria-live="assertive" class="g-hdn" id="ariabrowse">You have selected a category. Click Continue</div></div><div id="categories_fldSet" class="idtHrz"><div></div>
   
    <script language="JavaScript" type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
</script></div>
 

<div class="idtHrz"><div class="fl"><div class="verSpc"> </div><div style="visibility: visible;" id="catlayerTitle"><b>Categories you have selected</b></div></div>
<div class="fr"><div class="verSpc"> </div><label for="pcat"><b class="g-hdn">Enter </b>Category number:</label>
<input type="text" maxlength="10" size="7" autocomplete="off" value="" name="pcat" id="pcat"></div><div class="clr"></div></div>
<div class="idtHrz"><div aria-relevant="all" aria-atomic="true" aria-live="assertive" style="visibility: visible;" id="catlayer_inpGrp">

<b class="g-hdn">Categories you have selected</b><ul class="lst"  ><li     >  <input  type="text"  style="border-style:none;"   runat="server" id="lisub"  />

Books &gt; Accessories &gt; Book Covers | <a target="_blank" href="#">See sample listings<b class="g-hdn"> - opens in a new window or tab</b></a> | <a onclick="return ebay.oDocument._getControl(&quot;catlayer_inpGrp&quot;).removeSelection(&quot;45113&quot;);" name="remove_cat_anchor_45113" href="#">Remove</a></li><a onclick="return ebay.oDocument._getControl(&quot;catlayer_inpGrp&quot;).resetBrowsePanel(&quot;45113&quot;,false);" name="cat_anchor_2nd" href="#">Add a second category and reach more buyers.</a> (<a target="_blank" name="addfescatlink2nd" id="addfescatlink2nd" href="http://pages.ebay.com/help/sell/contextual/inframe/listing-two-categories.html">Fees apply<b class="g-hdn"> - opens in a new window or tab</b></a>)</ul></div><input type="hidden" value="45113" tabindex="-1" name="cat1" id="cat1"><input type="hidden" value="" tabindex="-1" name="cat2" id="cat2"><div style="display: none; visibility: hidden;" id="carAdMessage_inpGrp"><table cellspacing="0" cellpadding="0" border="0" summary=""><tbody><tr id="carAdMessage_row_1"><td valign="top"><div id="carAdMessage_inp"><div class="idtTop"><b>You will now be sent to eBay's "Sell Your Vehicle" form. </b><div class="hlpFrm" id="_help">
								This specially designed form makes it quick and easy to place your vehicle on eBay. It includes helpful tips and features to attract buyers and to create a professional look for your listing. Click <b>Save and continue</b> below to get started.</div></div><div class="idtTop">
								If you prefer to use the standard "Sell Your Item" form instead of the "Sell Your Vehicle" form, <a name="carAdSYILink" id="carAdSYILink" href="#">click here</a></div></div></td></tr></tbody></table></div></div></div></div>
    
    
    </div>
    </form>
</body>
</html>

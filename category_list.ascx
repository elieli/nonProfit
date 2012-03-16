<%@ Reference Page="~/indexNew.aspx" %>
<%@ Control Language="c#" Inherits="Shof.modules.category_list" CodeFile="category_list.ascx.cs" %>



<table cellspacing=0 cellpadding=0 width=128 border=0>
  <tr>
    <td valign=top align=right width="100%" colspan=4 
      ><IMG height=5 src="../main/img/sep_h3.gif" width=128 ></td></tr>
  
  <tr>
    <td valign=middle align=center background="" colspan=4 height=46 
    style="HEIGHT: 46px"><form id=frmSearch action=index.aspx?page=search method=post 
  ><INPUT class=box id=txtSearch 
      onblur="if (this.value == '') {this.value = 'Catalog Search ';}" 
      style="BACKGROUND-COLOR: #94bed4; TEXT-ALIGN: right" 
      onfocus="if (this.value == 'Catalog Search ') {this.value = '';}" 
      maxLength=50 size=17 value="<%= SearchParameter%>" name=txtSearch 
      > &nbsp;<INPUT class=box type=submit value=&nbsp;Go!&nbsp; name=submit></form> 
    </td></tr>
  <tr>
    <td valign=top align=right background="" colspan=4 
      style="HEIGHT: 1px"><IMG height=2 src="../main/img/sep_h1.gif" width=128 ></td></tr><asp:repeater id=rptCategoryList OnItemDataBound="rptCategoryList_OnItemDataBound" Runat="server">
		<ItemTemplate>
			<tr id="main_tr" runat="server">
				<td valign="top" align="right" background="" style="BORDER-LEFT: #4D94B8 1px solid;"><img src="../main/img/spacer.gif" width="5" height="1"></td>
				<td align="right" class="top" width="115" background=""><img src="../main/img/spacer.gif" width="1" height="2" border="0" alt=""><br/>
					<a id="aCat" runat="server" class="category"></a>
					<br/>
					<img src="../main/img/spacer.gif" width="1" height="2" border="0" alt=""></td>
				<td background=""><img src="../main/img/spacer.gif" width="5" height="1" border="0" alt=""></td>
				<td background="" style="BORDER-RIGHT: #94BED4 1px solid;"><img src="../main/img/spacer.gif" width="3" height="1" border="0" alt=""></td>
			</tr>
			<tr>
				<td valign="top" align="right" colspan="4" background=""><img src="../main/img/sep_h1.gif" width="128" height="2"></td>
			</tr>
			<asp:Repeater id="rptCategoryList2" Runat="server" OnItemDataBound="rptCategoryList2_OnItemDataBound">
				<headerTemplate>
				</headerTemplate>
				<ItemTemplate>
					<tr id="main_tr" runat="server">
						<td valign="top" align="right" background="" style="BORDER-LEFT: #4D94B8 1px solid;"><img src="../main/img/spacer.gif" width="5" height="1"></td>
						<td align="right" class="top" width="115" background=""><img src="../main/img/spacer.gif" width="1" height="2" border="0" alt=""><br/>
							<a id="aCat2" runat="server" class="category2"></a>
							<br/>
							<img src="../main/img/spacer.gif" width="1" height="2" border="0" alt=""></td>
						<td background=""><img src="../main/img/spacer.gif" width="5" height="1" border="0" alt=""></td>
						<td background="" style="BORDER-RIGHT: #94BED4 1px solid;"><img src="../main/img/spacer.gif" width="3" height="1" border="0" alt=""></td>
					</tr>
					<tr>
						<td valign="top" align="right" colspan="4" background=""><img src="../main/img/sep_h1.gif" width="128" height="2"></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
				</FooterTemplate>
			</asp:Repeater>
		</ItemTemplate>
	</asp:repeater><tr><td colspan=4 align=center>
	<a href="?page=orderhistory">
	<IMG border=0 align=middle  alt="Order History" src="img\orderHist.gif"></a>
</td></tr>
</table>

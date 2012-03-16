<%@ Reference Page="~/indexNew.aspx" %>
<%@ Control Language="c#" Inherits="checkout" CodeFile="checkout.ascx.cs" %>
<%@ Import Namespace="Lib" %>
<meta content="False" name="vs_showGrid"/>
<style type="text/css">.nwidth { WIDTH: 184px }
	.nswidth { WIDTH: 184px }
	.fmark { COLOR: red }
	</style>
<asp:panel id="Itemspanel" runat="server">
	<asp:panel id="billing" runat="server">
		<div style="FONT-WEIGHT: bold; FONT-SIZE: 100%; MARGIN-BOTTOM: 5px; COLOR: #505050; MARGIN-RIGHT: 5px"
			align="right">BILLING INFORMATION</div>
		<table cellspacing="1" cellpadding="1" width="97%" align="center" border="0">
			<tr>
				<td class="text" colspan="3"><span class="fmark">*</span>
					- required field
				</td>
			</tr>
			<tr>
				<td align="center" colspan="3">
					<hr color="#006496" noShade SIZE="1"/>
					<div align="center">
						<asp:Label id="lblPayMethod" runat="server" Visible="False" ForeColor="Red" EnableViewState="False"></asp:Label></div>
					<div align="center">
						<asp:ValidationSummary id="vldsm" runat="server" DisplayMode="List" align="center"></asp:ValidationSummary></div>
				</td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145" height="57">First Name
				</td>
				<td class="fmark" width="3" height="57">*
				</td>
				<td class="ftext" height="57">
					<asp:textbox id="firstName" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorFirstName" runat="server" errormessage="First Name Required"
						controltovalidate="firstName" Display="Dynamic"><br/>Please enter your first name</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Last Name
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:textbox id="lastName" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorLastName" runat="server" errormessage="Last Name Required"
						controltovalidate="lastName" Display="Dynamic"><br/>Please enter your last name</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Company (Mosad)&nbsp;</td>
				<td class="fmark" width="3">&nbsp;*</td>
				<td class="ftext">
					<asp:textbox id="company" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:RequiredFieldValidator id="rqvldBillCompanyName" runat="server" Display="Dynamic" ControlToValidate="company"
						ErrorMessage="Company Required">Please Enter Your Mosad</asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Address Line 1
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:textbox id="address1" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorAddressLine1" runat="server" errormessage="Address Required"
						controltovalidate="address1"><br/>Please enter your address</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Address Line 2
				</td>
				<td class="fmark" width="3">&nbsp;</td>
				<td class="ftext">
					<asp:textbox id="address2" runat="server" cssclass="nwidth"></asp:textbox></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Town/City
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:textbox id="town" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorTownCity" runat="server" errormessage="Town or City Required"
						controltovalidate="town" enableclientscript="False"><br/>Please enter your town/city</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145" height="26">State&nbsp;</td>
				<td class="fmark" width="3" height="26">&nbsp;</td>
				<td class="ftext" height="26">
					<asp:TextBox id="state" runat="server" CssClass="nswidth"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Postal/Zip Code
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:textbox id="postcode" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorPostalZipCode" runat="server" errormessage="Postal or Zip Code Required"
						controltovalidate="postcode" Display="Dynamic"><br/>Please enter your postal/zip code</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Country
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:dropdownlist id="country" runat="server" cssclass="nswidth"></asp:dropdownlist>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorCountry" runat="server" errormessage="Country Required"
						controltovalidate="country" Display="Dynamic" enableclientscript="False"><br/>Please select your country</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Phone
				</td>
				<td class="fmark" width="3">*&nbsp;</td>
				<td class="ftext">
					<asp:textbox id="phoneNumber" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:RequiredFieldValidator id="rqvldPhone" runat="server" Display="Dynamic" ControlToValidate="phoneNumber"
						ErrorMessage="Phone Number Required">Please Enter Your Phone Number</asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Fax
				</td>
				<td class="fmark" width="3">&nbsp;</td>
				<td class="ftext">
					<asp:textbox id="faxNumber" runat="server" cssclass="nwidth"></asp:textbox></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Email
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:textbox id="email" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorEmail" runat="server" errormessage="Email Required" controltovalidate="email"
						Display="Dynamic" enableclientscript="False"><br/>Please enter your email</asp:requiredfieldvalidator>
					<asp:regularexpressionvalidator id="RegularExpressionValidatorEmail" runat="server" errormessage="Email Needs to be Correct "
						controltovalidate="email" Display="Dynamic" enableclientscript="False" validationexpression="\S+@\S+\.\S{2,3}"><br/>Please enter correct email</asp:regularexpressionvalidator></td>
			</tr>
			<SCRIPT language="javascript"> 			
function PayM()
{
	drpDwn = document.getElementById("<%Response.Write(PayementMethod.ClientID);%>");

	var CT;
	var CN;
	var Exp;
	var divider;
	CT = document.getElementById("CardType").style;
	CN = document.getElementById("CardNum").style;
	Exp = document.getElementById("Expire").style;
	divider = document.getElementById('PayMdivider').style;
	if( drpDwn.value == '2' )
	{
		CT.display = 'none';
		CN.display = 'none';
		Exp.display = 'none';
		divider.display = 'none';
		PayNote.InnerHtml = "No Surcharge<br/>Payment must be received before shipping.";
	}
	else
	{
		CT.display = '';
		CN.display = '';
		Exp.display = '';
		divider.display = '';
		PayNote.InnerHtml = "A Credit Card Surcharge will apply. <br/> (2% for Visa, Master Card & Discover. 3% for Amex).";
	}
}
			</SCRIPT>
			<tr>
				<td colspan="3" height="33">
					<hr color="#006496" noShade SIZE="1">
				</td>
			</tr>
			<tr>
				<td valign="middle" align="right" height="49">Payment Method
				</td>
				<td class="fmark" width="3">*
				</td>
				<td height="49">
					<P><SELECT class="nswidth" id="PayementMethod" onchange="PayM()" name="PayementMethod" runat="server">
							<OPTION value="" selected>Select Payment Method</OPTION>
							<OPTION value="1">Credit Card</OPTION>
							<OPTION value="2">Cash Checks</OPTION>
						</SELECT>
						<asp:RequiredFieldValidator id="rfvldPayMethod" runat="server" Display="Dynamic" ControlToValidate="PayementMethod"
							ErrorMessage="Must Select a Payment Method" Height="11px"></asp:RequiredFieldValidator></P>
				</td>
			</tr>
			<tr>
				<td id="PayNote" align="center" colspan="3"></td>
			</tr>
			<tr>
				<td id="PayMdivider" colspan="3">
					<hr color="#006496" noShade SIZE="1">
				</td>
			</tr>
			<TR id="CardType">
				<td class="ftext" align="right" width="145" height="32">Credit Card
				</td>
				<td class="fmark" width="3" height="32">*
				</td>
				<td class="ftext" height="32">
					<asp:dropdownlist id="creditCard" runat="server" cssclass="nswidth">
						<asp:listitem value="">--- Select ---</asp:listitem>
						<asp:listitem value="VISA">Visa</asp:listitem>
						<asp:listitem value="MC">Master Card</asp:listitem>
						<asp:listitem value="AMEX">Amex</asp:listitem>
						<asp:listitem value="DISCOVER">Discover</asp:listitem>
					</asp:dropdownlist>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorCreditCard" runat="server" errormessage="Credit Card Required"
						controltovalidate="creditCard" enableclientscript="False"><br/>Please select credit card</asp:requiredfieldvalidator></td>
			</tr>
			<TR id="CardNum">
				<td class="ftext" align="right" width="145">Card Number
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:textbox id="cardNumber" runat="server" cssclass="nwidth" maxlength="20"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidatorCardNumber" runat="server" errormessage="Credit Card Number Required"
						controltovalidate="cardNumber" enableclientscript="False"><br/>Please enter valid credit number</asp:requiredfieldvalidator>
					<asp:customvalidator id="CustomValidatorCardNumber" runat="server" errormessage="Incorrrect Credit Card Number"
						controltovalidate="cardNumber" enableclientscript="False" enableviewstate="False"><br/>Card number does not match card type selected, please check!</asp:customvalidator></td>
			</tr>
			<TR id="Expire">
				<td class="ftext" align="right" width="145">Expiry Date
				</td>
				<td class="fmark" width="3">*
				</td>
				<td class="ftext">
					<asp:dropdownlist id="month" runat="server"></asp:dropdownlist>
					<asp:dropdownlist id="year" runat="server"></asp:dropdownlist>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorExpDateMonth" runat="server" errormessage="Month Required"
						controltovalidate="month" enableclientscript="False"><br/>Please select month</asp:requiredfieldvalidator>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorExpDateYear" runat="server" errormessage="Year Required"
						controltovalidate="year" enableclientscript="False"><br/>Please select year</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145"><a onclick="x=window.open('cvv.htm','newWindow1','menubar=no,status=no,scrollbars=no,resizable=yes,width=600,height=480')"
						href="#">CVV/CID</a></td>
				<td class="fmark" width="3"></td>
				<td class="ftext">
					<asp:TextBox id="txtbCvv" runat="server" CssClass="nwidth"></asp:TextBox>
					<asp:RegularExpressionValidator id="regexvldCVV" runat="server" ControlToValidate="txtbCvv" ErrorMessage="CVV/CID Is Not Valid"
						ValidationExpression="^([0-9]{3,4})$">Not a CVV/CID</asp:RegularExpressionValidator></td>
			</tr>
			<tr>
				<td colspan="3">
					<hr color="#006496" noShade SIZE="1">
				</td>
			</tr>
			<tr>
				<td class="ftext" valign="top" align="right" width="145">
					<asp:checkbox id="sameAsBilling" runat="server" checked="true"></asp:checkbox></td>
				<td class="fmark" width="3">&nbsp;</td>
				<td class="ftext">Save yourself some time!<br/>
					Check this box if your shipping address is the same as your billing address.
				</td>
			</tr>
			<SCRIPT language="javascript">
			PayM();
			</SCRIPT>
			<tr>
				<td class="ftext" valign="top" align="right" width="145">
					<asp:checkbox id="saveDetails" runat="server" checked="true"></asp:checkbox></td>
				<td class="fmark" width="3">&nbsp;</td>
				<td class="ftext">Save your personal details for further entries.
				</td>
			</tr>
		</table>
		<div style="MARGIN-TOP: 4px" align="center"><a href=".?page=cart"><IMG height="27" alt="Back" src="img/btn-back.gif" width="58" border="0"></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:imagebutton id="goToNext" runat="server" imageurl="img/btn-next.gif" alternatetext="Next" width="58px"
				height="27px"></asp:imagebutton><br/>
		</div>
	</asp:panel>
	<asp:panel id="shipping" runat="server" visible="false">
		<div style="FONT-WEIGHT: bold; FONT-SIZE: 100%; MARGIN-BOTTOM: 5px; COLOR: #505050; MARGIN-RIGHT: 5px"
			align="right">SHIPPING INFORMATION</div>
		<div style="MARGIN: 5px" align="center">
			<asp:ValidationSummary id="vldsShipping" runat="server" DisplayMode="List" align="center" Width="499px"></asp:ValidationSummary></div>
		<div style="MARGIN: 5px" align="center">
			<asp:label id="lblShippingError" runat="server" enableviewstate="False" visible="False" forecolor="red">Shipping Error</asp:label></div>
		<table cellspacing="1" cellpadding="1" width="97%" align="center" border="0">
			<tr>
				<td class="text" colspan="3"><span class="mark">*</span>
					- required field
				</td>
			</tr>
			<tr>
				<td colspan="3">
					<hr color="#006496" noShade SIZE="1">
				</td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">First Name
				</td>
				<td class="fmark" width="5">*
				</td>
				<td class="ftext">
					<asp:textbox id="firstName00" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorFirstName00" runat="server" Visible="False" errormessage="First Name Required"
						controltovalidate="firstName00"><br/>Please enter your first name</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Last Name
				</td>
				<td class="fmark">*
				</td>
				<td class="ftext">
					<asp:textbox id="lastName00" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorLastName00" runat="server" errormessage="Last Name Required"
						controltovalidate="lastName00"><br/>Please enter your last name</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Company
				</td>
				<td class="fmark">&nbsp;</td>
				<td class="ftext">
					<asp:textbox id="company00" runat="server" cssclass="nwidth"></asp:textbox></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Address Line 1
				</td>
				<td class="fmark">*
				</td>
				<td class="ftext">
					<asp:textbox id="address100" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorAddressLine100" runat="server" errormessage="Addres Required"
						controltovalidate="address100"><br/>Please enter your address</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Address Line 2
				</td>
				<td class="fmark">&nbsp;</td>
				<td class="ftext">
					<asp:textbox id="address200" runat="server" cssclass="nwidth"></asp:textbox></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Town/City
				</td>
				<td class="fmark">*
				</td>
				<td class="ftext">
					<asp:textbox id="town00" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorTownCity00" runat="server" errormessage="Town or City Required"
						controltovalidate="town00"><br/>Please enter your town/city</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">State&nbsp;</td>
				<td class="fmark">&nbsp;</td>
				<td class="ftext">
					<asp:TextBox id="state00" runat="server" CssClass="nswidth"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145">Postal/Zip Code
				</td>
				<td class="fmark">*
				</td>
				<td class="ftext">
					<asp:textbox id="postcode00" runat="server" cssclass="nwidth"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorPostalZipCode00" runat="server" Visible="False" errormessage="Postal or Zip Code Required"
						controltovalidate="postcode00"><br/>Please enter your postal/zip code</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" align="right" width="145" height="55">Country
				</td>
				<td class="fmark" height="55">*
				</td>
				<td class="ftext" height="55">
					<asp:dropdownlist id="country00" runat="server" cssclass="nswidth"></asp:dropdownlist>
					<asp:requiredfieldvalidator id="RequiredfieldvalidatorCountry00" runat="server" errormessage="Country Required"
						controltovalidate="country00" enableclientscript="False" Height="16px" Width="152px"><br/>Please enter your country</asp:requiredfieldvalidator></td>
			</tr>
			<tr>
				<td class="ftext" valign="bottom" align="right" width="145" height="45">Shipping 
					Method
				</td>
				<td class="fmark" valign="bottom" height="45">*
				</td>
				<td class="ftext" height="45">
					<P>If you choose 'Other' please define your preferred shipping method in field 
						below, shipping charges will be added after order is received. You will be 
						contacted regarding the other shipping arrangements.</P>
					<P>
						<asp:dropdownlist id="ddlUPSShipServ" runat="server" cssclass="nswidth" onchange="EnableShippingComment()"></asp:dropdownlist></P>
				</td>
			</tr>
			<SCRIPT language="javascript">
function EnableShippingComment()
{
drpDwn = document.getElementById("<%=ddlUPSShipServ.ClientID.ToString()%>");
txtComment = document.getElementById("<%=txtShippingComment.ClientID%>");
if( drpDwn.value == 'other' ) 
{
	//txtComment.disabled = false;
	txtComment.value = '';
	document.getElementById('ShippingCommentTitle').InnerHtml= "Shipping Method";
}
else
{	
	//txtComment.disabled = false;
	document.getElementById('ShippingCommentTitle').InnerHtml= "Shipping Comment:";
}
}


			</SCRIPT>
			<tr>
				<td class="ftext" align="right" width="145">
					<div id="ShippingCommentTitle">Shipping Comment:</div>
				</td>
				<td class="fmark">&nbsp;
				</td>
				<td class="ftext"><br/>
					<asp:textbox id="txtShippingComment" runat="server" cssclass="nwidth" enabled="True" textmode="MultiLine"
						rows="3"></asp:textbox></td>
			</tr>
		</table>
		<div style="MARGIN-TOP: 4px" align="center">
			<asp:imagebutton id="goToBack00" runat="server" imageurl="img/btn-back.gif" alternatetext="Back"
				width="58px" height="27px"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:imagebutton id="goToNext00" runat="server" imageurl="img/btn-next.gif" alternatetext="Next"
				width="58px" height="27px" causesvalidation="True"></asp:imagebutton><br/>
		</div>
	</asp:panel>
	<asp:panel id="confirmation" runat="server" visible="false">
		<div style="FONT-WEIGHT: bold; FONT-SIZE: 100%; MARGIN-BOTTOM: 5px; COLOR: #505050; MARGIN-RIGHT: 5px"
			align="right">CONFIRMATION</div>
		<table cellspacing="0" cellpadding="0" width="97%" align="center" border="0">
			<tr>
				<td bgcolor="#006496">
					<table cellspacing="1" cellpadding="2" width="100%" align="center" border="0">
						<tr>
							<td class="head" valign="middle" bgcolor="#ffffff" colspan="2" height="30">
								<div style="PADDING-LEFT: 8px"><span id="spanItemsCount" runat="server">1</span>
									items in your shopping cart:</div>
							</td>
							<td class="head" valign="middle" align="center" bgcolor="#ffffff">Price</td>
							<td class="head" valign="middle" align="center" bgcolor="#ffffff">Personalize</td>
							<td class="head" valign="middle" align="center" bgcolor="#ffffff">Quantity</td>
							<td class="head" valign="middle" align="center" bgcolor="#ffffff">Total</td>
						</tr>
						<asp:repeater id="rptProductList" runat="server" onitemdatabound="rptProductList_OnItemDataBound">
							<itemtemplate>
								<tr height="24">
									<td bgcolor="#ffffff" valign="middle"><a id="aImghref" runat="server"><img id="imgList" runat="server" border="0"></a>
									</td>
									<td bgcolor="#ffffff" width="70%" valign="middle"><div class="smallProduct">
											<div class="prodhead"><a id="aProductName" runat="server"></a></div>
										</div>
									</td>
									<td bgcolor="#ffffff" width="10%" valign="middle"><span id="spanProductPrice" runat="server" class="number">$</span>
									</td>
									<td bgcolor="#ffffff" width="5%" valign="middle" align="center"><div class="cartdata"><span id="spanPersonalize" runat="server"></span></div>
									</td>
									<td bgcolor="#ffffff" width="5%" valign="middle" align="center"><div class="cartdata"><span class="number" id="spanQuantity" runat="server"></span></div>
									</td>
									<td bgcolor="#ffffff" valign="middle" width="10%"><span id="spanProductTotalPrice" runat="server" class="number">$</span></td>
								</tr>
							</itemtemplate>
							<separatortemplate>
							</separatortemplate>
						</asp:repeater>
						<tr>
							<td valign="middle" align="right" bgcolor="#ffffff" colspan="5"><STRONG>Sub-Total</STRONG></td>
							<td valign="middle" width="20%" bgcolor="#ffffff">
								<asp:Label id="lblSubTotal" runat="server" Visible="true"></asp:Label></td>
						</tr>
						<TR class="even" id="trShippingCharges" height="24" runat="server">
							<td valign="middle" align="right" bgcolor="#ffffff" colspan="5">
								<div class="info"><b>Shipping Charges (<%= ddlUPSShipServ.SelectedItem.Text%>):</b>&nbsp;</div>
							</td>
							<td valign="middle" width="20%" bgcolor="#ffffff"><span class="number" id="spanShippingCharges" runat="server">$</span>
							</td>
						</tr>
						<TR class="even" height="24">
							<td valign="middle" align="right" bgcolor="#ffffff" colspan="5">
								<div class="info"><b>Credit Card Surcharge:</b>&nbsp;</div>
							</td>
							<td valign="middle" width="20%" bgcolor="#ffffff"><span class="number" id="spanCCSurcharge" runat="server">$</span>
							</td>
						</tr>
						<TR class="even" height="24">
							<td valign="middle" align="right" bgcolor="#ffffff" colspan="5">
								<div class="info"><b>Total:</b>&nbsp;</div>
							</td>
							<td valign="middle" width="20%" bgcolor="#ffffff"><span class="number" id="spanTotalPrice" runat="server"></span></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<br/>
		<asp:panel id="confBilling" runat="server">
			<hr color="#006496" noShade SIZE="1">
			<div style="FONT-WEIGHT: bold; FONT-SIZE: 100%; MARGIN-BOTTOM: 5px; COLOR: #505050; MARGIN-RIGHT: 5px"
				align="right">BILLING<%=confShipping.Visible?"":" AND SHIPPING"%>
				INFORMATION</div>
			<table cellspacing="1" cellpadding="2" width="100%" align="center" border="0">
				<TR id="ccardDisp">
					<td class="ftext" align="left" width="145">Credit Card</td>
					<td class="ftext"><%=creditCard.SelectedItem.Text%></td>
				</tr>
				<TR id="cNumberDisp">
					<td class="ftext" align="left">Card Number</td>
					<td class="ftext"><%=lib.ShowCreditNumber(cardNumber.Text)%></td>
				</tr>
				<TR id="expDisp">
					<td class="ftext" align="left" height="20">Expiry Date</td>
					<td class="ftext" height="20"><%=month.SelectedItem.Text%>&nbsp;<%=year.SelectedItem.Text%></td>
				</tr>
				<TR id="cash">
					<td align="center" colspan="2" height="75"><STRONG>Paying by Cash or Check</STRONG><br/>
						No Credit card surcharge
					</td>
				</tr>
				<SCRIPT language="javascript">
				var TR1 = document.getElementById("ccardDisp").style;
				var TR2 = document.getElementById("cNumberDisp").style;
				var TR3 = document.getElementById("expDisp").style;
				var TR4 = document.getElementById("cash").style;
				if(<%=PayementMethod.Value%> == 2)
				{
					TR1.display = 'none';
					TR2.display = 'none';
					TR3.display = 'none'; 
					TR4.display = '';
				}
				else
				{
					TR1.display = '';
					TR2.display = '';
					TR3.display = ''; 
					TR4.display = 'none';
				}
				</SCRIPT>
				<tr>
					<td class="ftext" align="left" width="145">First Name</td>
					<td class="ftext"><%=firstName.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Last Name</td>
					<td class="ftext"><%=lastName.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Company</td>
					<td class="ftext"><%=company.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Address Line 1</td>
					<td class="ftext"><%=address1.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Address Line 2</td>
					<td class="ftext"><%=address2.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Town/City</td>
					<td class="ftext"><%=town.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">State</td>
					<td class="ftext"><%=state.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Postal/Zip Code</td>
					<td class="ftext"><%=postcode.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Country</td>
					<td class="ftext"><%=country.SelectedItem.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Phone</td>
					<td class="ftext"><%=phoneNumber.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Fax</td>
					<td class="ftext"><%=faxNumber.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Email</td>
					<td class="ftext"><%=email.Text%></td>
				</tr>
			</table>
		</asp:panel>
		<asp:panel id="confShipping" runat="server">
			<hr color="#006496" noShade SIZE="1">
			<div style="FONT-WEIGHT: bold; FONT-SIZE: 100%; MARGIN-BOTTOM: 5px; COLOR: #505050; MARGIN-RIGHT: 5px"
				align="right">SHIPPING INFORMATION</div>
			<div style="MARGIN: 5px" align="center">
				<asp:label id="lblUPSAddrVaildationResult" runat="server" enableviewstate="False" visible="False"
					forecolor="red">UPS Address Validation Result</asp:label></div>
			<table cellspacing="1" cellpadding="2" width="100%" align="center" border="0">
				<tr>
					<td class="ftext" align="left" width="145">First Name</td>
					<td class="ftext"><%=firstName00.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Last Name</td>
					<td class="ftext"><%=lastName00.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Company</td>
					<td class="ftext"><%=company00.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Address Line 1</td>
					<td class="ftext"><%=address100.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Address Line 2</td>
					<td class="ftext"><%=address200.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Town/City</td>
					<td class="ftext"><%=town00.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left" height="16">State</td>
					<td class="ftext" height="16"><%=state00.Text%>&nbsp;</td>
				</tr>
				<tr>
					<td class="ftext" align="left">Postal/Zip Code</td>
					<td class="ftext"><%=postcode00.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Country</td>
					<td class="ftext"><%=country00.SelectedItem.Text%></td>
				</tr>
				<tr>
					<td class="ftext" align="left">Shipment Service</td>
					<td class="ftext"><%= (ddlUPSShipServ.SelectedValue == "other")? txtShippingComment.Text : ddlUPSShipServ.SelectedItem.Text%></td>
				</tr>
			</table>
		</asp:panel>
		<hr color="#006496" noShade SIZE="1">
		<div style="MARGIN-TOP: 4px" align="center">
			<asp:imagebutton id="goToBack01" runat="server" imageurl="img/btn-back.gif" alternatetext="Back"
				width="58px" height="27px"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:imagebutton id="goToNext01" runat="server" imageurl="img/btn-submit.gif" alternatetext="Submit"
				width="58px" height="27px"></asp:imagebutton><br/>
		</div>
	</asp:panel>
	<asp:panel id="thankyou" runat="server" visible="False">
		<br/>
		<div class="h2" align="center"><b><FONT size="4">THANK YOU</FONT></b></div>
		<br/>
		<div class="text" align="center">Order Reference No.: <B class="number">
				<%=orderId%>
			</b>
			<br/>
			<br/>
			<STRONG>Your order has been received.<br/>
				Please save your order reference number for all future communication with
				<span id="spanThankNameSite" runat="server">the Shluchim 
Office</span>. </STRONG>
		</div>
		<div class="text" align="center">&nbsp;</div>
		<div class="text" align="center"><FONT color="#cc6666"><STRONG>When paying by cash/check 
					payment must be recived prior to shipping/pickup<br/>
				</STRONG></FONT>
		</div>
		<div class="text" align="center">
			<asp:panel id="pnPersonalizeOrder" runat="server" Height="60px" visible="false">
				<br/>
				<div align="center">don't forget to <a id="aPersonalizeOrder" runat="server">personalize 
						your order</a>.</div>
				<br/>
			</asp:panel></div>
		<div class="text" align="center"><br/>
			<a id="aPrintOrder" href="#" runat="server">Print Order</a>
		</div>
	</asp:panel>
</asp:panel><asp:panel id="NoItemspanel" runat="server" Height="74px" visible="False">
	<table cellspacing="0" cellpadding="0" align="center" border="0">
		<tr>
			<td><FONT size="4"><STRONG>No items in your shopping cart</STRONG></FONT></td>
		</tr>
		<tr>
			<td><br/>
				<div align="center"><IMG src="img/Shoppin%20Cart%20with%20so1.jpg">
				</div>
				<br/>
				<div align="center"><a 
      href="<%=Request.UrlReferrer.AbsoluteUri%>"><STRONG>Continue Shopping</STRONG></a></div>
			</td>
		</tr>
	</table>
</asp:panel>

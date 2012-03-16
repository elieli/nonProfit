<%@ Control Language="c#" Inherits="Shof.modules.forgotpass" CodeFile="forgotpass.ascx.cs" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td background="img/center_bg.gif" class="ppath"><a href="." class="link1">Home</a> &gt; <a href=".?page=login" class="link1">
				Login</a> &gt; <a id="spanPathNameCat" href=".?page=forgotpass" runat="server" class="link1">
				Forgot your password?</a></td>
	</tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td class="pcenterin">
			<div style="MARGIN: 10px" align="center">If you have forgotten your password, 
				please enter your email address and your Password will be e-mailed to you.</div>
			<table cellspacing="1" cellpadding="2" width="90%" align="center" border="0">
				<TR>
					<td class="text" colspan="3"><span class="mark">*</span> - required field
					</td>
				</tr>
				<TR>
					<td class="ftext" align="right" width="145">EMail
					</td>
					<td class="fmark" width="5">*</td>
					<td class="ftext"><asp:textbox id="txtEMail" runat="server" CssClass="nwidth"></asp:textbox><asp:requiredfieldvalidator id="txtEMailValidator" runat="server" EnableClientScript="False" ControlToValidate="txtEMail"
							ErrorMessage="RequiredFieldValidator" Enabled="True"><br/>Please enter email</asp:requiredfieldvalidator>
						<asp:RegularExpressionValidator id="txtEMailExpressionValidator" runat="server" ErrorMessage="RegularExpressionValidator"
							ControlToValidate="txtEMail" EnableClientScript="False" ValidationExpression="\S+@\S+\.\S{2,3}"><br/>Please enter correct email</asp:RegularExpressionValidator></td>
				</tr>
			</table>
			<div style="MARGIN-TOP: 4px" align="center">
				<asp:ImageButton id="btnForgotpass" runat="server" Height="17" Width="65" ImageUrl="img/btn_submit.gif"
					AlternateText="Submit"></asp:ImageButton><br/>
			</div>
		</td>
	</tr>
</table>

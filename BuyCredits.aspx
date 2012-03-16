<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyCredits.aspx.cs" Inherits="BuyCredits" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"      >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            width: 254px;
        }
    </style>
</head>
<body  style="height:350px; width:650px;">
    <form id="form1" runat="server">
    <div style="height:353px; width:650px;">
    
    
    
    
    <a href="#" onclick="javascript:window.close(); ">Close</a>
   <div style=" text-align:center"> <asp:Label ID="lblmsg" 
            runat="server" Text="Label"></asp:Label></div>
    
    <h1> Buy Credits       </h1> 
    
    
    
    <h2>  50 cents per credit </h2> 
    
     <h2>      your total credits are :   
         <asp:Label ID="lbltotcredits" runat="server"  ></asp:Label>   <%--<asp:Label  runat="server"  id="lblTotCredits"></asp:Label> --%> </h2>
    
    
    <p>  Enter number of credits  &nbsp   <input type="text" runat="server"  id="txtCredits" />   </p>
    
     <p>  Total Price   &nbsp   <input type="text" runat="server"  style="border:solid 2px white;" id="txtCreditsPrice" />   </p>
    
       <p>   &nbsp<asp:Button runat="server"  Text="Buy"  id="btnCreditsPrice" OnClick="addCredits" CommandName="addCredits" /></p>
     <p>   &nbsp<asp:Button runat="server"  Text="Return" id="btnRtrnCreditsPrice" 
             OnClick="addCredits" CommandName="rtrnCredits" Width="66px" /></p>
    
    
    
    
    
    
    
    
    
<div id="paybtg_form" runat="server"  class="paybtg_form">
<h2>Payment Information</h2>
<%--<asp:Panel ID="CreditCardPanel" runat="server" CssClass="mscCreditCardInfo mscPaymentSection">
 --%>
<div  id="tblCreditCardForm" runat="server"   style="position:relative;" class="form_table_pay">



                <asp:RadioButton  ID="ckCardInfo"   runat="server" AutoPostBack="true" GroupName="PaymentSection"
                     Checked="true" />Pay with credit card
 <br />
<asp:RadioButton ID="ckPayPal" runat="server" AutoPostBack="true" GroupName="PaymentSection"
                    />Pay with PayPal    &nbsp    &nbsp     &nbsp   <asp:Image ID="iqPayPalImg" ImageUrl= "App_Themes/YekaTheme/images/PayPal_logo.gif"  runat="server" SkinID="iqPayPalLogo"   Width="50px" Height="33px" />&nbsp;&nbsp;&nbsp;
                     
                <br />


                 <%--<asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" GroupName="PaymentSection"
                    OnCheckedChanged="Check_Clicked" Checked="true" />Pay with credit card--%>
              <%--  <br />--%>
                <span class="ErrorMessage">
                    </span><br />
  
    <h3 id="CreditCardHeader" runat="server">
                    <label id="lblCardInfo" runat="server" visible="false">
                        Credit Card Information</label>
                </h3>
            
  <%--
                <asp:RadioButton  ID="ckCardInfo"   runat="server" AutoPostBack="true" GroupName="PaymentSection"
                    OnCheckedChanged="Check_Clicked" Checked="true" />Pay with credit card
 <br />--%>
          </div>
          
           
    
                     

<div class="form_table_row_pay">
<div class="form_table_pay_row1"><p>  Credit Card Type:</p></div>
<div class="form_table_pay_row2">
    <asp:DropDownList ID="cmbPaymentType"  runat="server" onchange="javascript:updateCVVInstructions(this.value);" Width="155" > 
  <asp:ListItem>Visa</asp:ListItem>
   <asp:ListItem>Discover</asp:ListItem>
    <asp:ListItem>American Express</asp:ListItem>
   
   
    </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbPaymentType"
                                                        ErrorMessage="required" ValidationGroup="vgShip" /> </div>
</div>



   
                                


<div class="form_table_row_pay">
<div class="form_table_pay_row1"><p>Name on the Card:</p></div>
<div class="form_table_pay_row2"> <asp:TextBox ID="txtCardName" runat="server" MaxLength="50" AutoCompleteType="Disabled"
                                    Width="155" />
                                <asp:RequiredFieldValidator ID="vldCardName" runat="server" ControlToValidate="txtCardName"
                                    ErrorMessage="Name on card is required." /></div>
</div>

 

     
                                
<div class="form_table_paysep"><p>&nbsp;</p></div>
<div class="form_table_row_pay">
<div class="form_table_pay_row1"><p>Card Number:</p></div>
<div class="form_table_pay_row2"><asp:TextBox ID="txtCardNumber" runat="server" MaxLength="25" AutoCompleteType="Disabled"
                                   Width="155" />                                 
                                <asp:RequiredFieldValidator ID="vldCreditCard" runat="server" ControlToValidate="txtCardNumber"
                                    ErrorMessage="Card Number is required." />

</div>
</div>

<div class="form_table_paysep"><p>&nbsp;</p></div>
<div class="form_table_row_pay">
<div class="form_table_pay_row1"><p>Expiration:</p></div>
<div class="form_table_pay_row2"><asp:DropDownList ID="cmbCardExpMonth" runat="server">
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="1">Jan - 1</asp:ListItem>
                                    <asp:ListItem Value="2">Feb - 2</asp:ListItem>
                                    <asp:ListItem Value="3">Mar - 3</asp:ListItem>
                                    <asp:ListItem Value="4">April - 4</asp:ListItem>
                                    <asp:ListItem Value="5">May - 5</asp:ListItem>
                                    <asp:ListItem Value="6">June - 6</asp:ListItem>
                                    <asp:ListItem Value="7">July - 7</asp:ListItem>
                                    <asp:ListItem Value="8">Aug - 8</asp:ListItem>
                                    <asp:ListItem Value="9">Sept - 9</asp:ListItem>
                                    <asp:ListItem Value="10">Oct - 10</asp:ListItem>
                                    <asp:ListItem Value="11">Nov - 11</asp:ListItem>
                                    <asp:ListItem Value="12">Dec - 12</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;<asp:DropDownList ID="cmbCardExpYear" runat="server" />
                              <asp:RequiredFieldValidator ID="vldCardMonth" runat="server" ControlToValidate="cmbCardExpMonth"
                                    ErrorMessage="Month is required." />
                                <asp:RequiredFieldValidator ID="vldCardYear" runat="server" ControlToValidate="cmbCardExpYear"
                                    ErrorMessage="Year is required." />
                               <%-- <asp:CustomValidator ID="vldCardExpiration" runat="server" ControlToValidate="cmbCardExpYear"
                                    ErrorMessage="You have entered an invalid expiration date." OnServerValidate="CreditCardDate_Validation" />--%></div>
</div>



<div class="form_table_paysep"><p>&nbsp;</p></div>
<div class="form_table_row_pay">
<div class="form_table_pay_row1"><p>CVV:</p></div>
<div class="form_table_pay_row2"><asp:TextBox ID="txtCardCVV2" runat="server" MaxLength="5" AutoCompleteType="Disabled"
                                                Width="53" />
                                            <asp:RequiredFieldValidator ID="vldVerification" runat="server" ControlToValidate="txtCardCVV2"
                                                ErrorMessage="Card Verification required." />
                                        
                                            <a href="javascript:openCVV2Help();" style="color: Black;" title="On the back of your card, find the last 3 digits">
                                                <img id="Img2" runat="server" alt="On the back of your card, find the last 3 digits" src="~/mainstreet/images/cv_mini.gif"
                                                    align="top" border="0" /></a> <a href="javascript:openCVV2Help();" style="color: Black;" title="On the back of your card, find the last 3 digits">
                                            </a>
                                         
                                               <asp:Label ID="lblCVVInstruction" runat="server" Visible="false" ToolTip="On the back of your card, find the last 3 digits">(On the back of your card, find the last 3 digits)</asp:Label><br />
                             
</div>
                      
</div>

    
    
    
    <div id="dvmsg" runat="server">                          </div>
    
    
    
    
    </div>
    
    
    </div>
    </form>
</body>
</html>

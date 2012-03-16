<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" viewStateEncryptionMode ="Never"
  CodeFile="DefaultForm.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
    
    
       
    
<style type="text/css">
 
body,td,th {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	color: #000000;
	line-height: 20px;
}
body {
	background-color: #fcdc2a;
	margin-left: 0px;
	margin-top: 10px;
	margin-right: 0px;
	margin-bottom: 0px;
}
a:link {
	color: #FE6700;
	text-decoration: underline;
}
a:visited {
	text-decoration: underline;
	color: #FE6700;
}
a:hover {
	text-decoration: none;
	color: #FE6700;
}
a:active {
	text-decoration: underline;
	color: #FE6700;
}
a.topMenu:link, a.topMenu:active, a.topMenu:visited,a.topMenu:hover{
	color: #FFFFFF;
	text-decoration: none;
	font-size: 11px;
	font-weight: bold;
	text-transform: uppercase;
}
.verdana11 {	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 11px;
	font-style: normal;
	font-weight: normal;
	color: #747474;
}
.titleOrange {font-size: 23px; color: #FE6700; font-family: "Trebuchet MS";}
.titleResults {
	font-size: 15px;
	font-weight: bold;
	color: #FE6700;
}



#overlay {
	background-color:#c0c0c0;    
    width: 100%;
	bottom:0px;
    min-height: 100%;
    position: absolute;
    top: 0;
    left: 0;
	visibility:hidden;
    z-index: 0;
	margin-bottom:-755px;
    filter:alpha(opacity=0.25);
    -moz-opacity:0.7;
    text-align: center;
}
 

#overlay_panel {position:relative;
	background-color: #FFFFFF;
	background-repeat:repeat;
	border:3px;
	border-color: #fcdc2a;
	filter: alpha(opacity=100);
	height:250px;
	left:0;
	margin: 0px 40% -200px 42.5%;
	-moz-opacity: 1.0;
	opacity: 1.0;
	right:0;
	vertical-align:50px;
	width: 270px;
}
 
#overlay_panels {
	background-color:#ffffff; 
	background-repeat:repeat;
	border:3px;
	border-color: #fcdc2a;
	filter: alpha(opacity=100);
	height:280px;
	left:0;
	margin: 0px 40% -200px  42.5%;
	-moz-opacity: 1.0;
	opacity: 1.0;
	right:0;
	vertical-align:3em;
    width: 270px;
}

#overlaypanel { left:0; right:0; top:0;bottom:0;  
   margin: 900px  35% -200px 35% ;vertical-align:550px;
    width: 350px;height:250px;border:4px ; border-color:blue;
  background-color: #FFFFFF;position:absolute; z-index:2000;
	}

 


html, body {
    height: 100%;
    width: 100%;
    margin: 0;
    padding: 0;
}
.style1 {font-size: 18px}
.style1 {font-size: 18px}
.style1 {font-size: 10px}
.style1 {font-size: 10px}




 
</style>
    
    
    
    
    
    
    
    
    
</head>
<body>










 








        
                        
                        
                        <form method="post"  runat="server" id="frmDownLoadSong"  action="SubingForm.aspx">
  
                      <table width="400" border="0" align="center" cellpadding="0" cellspacing="0">
					  <%--  <form action="donate.asp?formSent=1" method="post">--%>
						
						
						
						<tr>
                             <td height="28">Form Type: </td>
							  <td height="28" class="titleResults"><img src="images/arrowOrange.gif" width="10" height="10" align="absmiddle" /> 
							 <select> 
							 	  <option value="availability">Availability</option>
							    <option value="request">Request</option>
							 
							 </select>
							 <%-- <input type="radio"  name="subType" id="subType" value="Availability"  />
							  	  <input type="radio"  name="subType" id="Radio1" value="Request"  />--%>
							  
							  </td>
							  <td height="28">&nbsp;</td>
							</tr>
							
							
							
							
						<tr>
                                <td height="28">Days Available: </td>
							  <td height="28" class="titleResults"> 
							 Sunday <input type="checkbox" name="sunday" id="sunday" value="Sunday"   />
							   Monday    <input type="checkbox" name="monday" id="Checkbox1" value="Monday"  />
							   tuesday   <input type="checkbox" name="tuesday" id="Checkbox2" value="Tuesday"  />
							    Wednesday    <input type="checkbox" name="wednesday" id="Checkbox3" value="Wednesday"  />
							     Thursday <input type="checkbox" name="thursday" id="Checkbox4" value="Thursday"  />
							      Frinday<input type="checkbox" name="frinday" id="Checkbox5" value="Frinday"  />
							    
							    
							    
							    
							  </td>
							  <td height="28">&nbsp;</td>
							</tr>
					

 		
								
						<tr>
                                <td height="28">Part of Day Available: </td>
							  <td height="28" class="titleResults"> 
							  <input type="checkbox" name="morning" id="Checkbox6" value="Morning"   />
							     <input type="checkbox" name="afternoon" id="Checkbox7" value="Afternoon"  />
							    <input type="checkbox" name="evening" id="Checkbox8" value="Evening"  />
							  					    
							    
							    
							  </td>
							  <td height="28">&nbsp;</td>
							</tr>
							
							
							
							
							
							
							
							
							<tr>

							  <td height="28" class="titleResults"><img src="images/arrowOrange.gif" width="10" height="10" align="absmiddle" /> Contact Information </td>
							  <td height="28">&nbsp;</td>
							</tr>
							<tr bgcolor="#F8F8F8">
							  <td height="28">Sub Type: </td>
							  <td height="28">
							  
							  <select>
							  <option value="preschool">preschool</option>
							    <option value="elementary">elementary</option>
							      <option value="high school">high school</option>
							      <option value="Office Work">Office Work</option>
							      <option value="Lubavitch School">Lubavitch School</option>
							      <option value="Talmud T/Day">Talmud T/Day</option>
							      	      <option value="School">School</option>
							      	      <option value="Shluchim Online S">Shluchim Online S</option>
							      	      <option value="Home school">Home school</option>
							         <option value="hebrew school">hebrew school</option>
							         <option value="tutoring">tutoring</option>
							             <option value="working for shluchim">working for shluchim</option>
							             <option value="Volunteer ">Volunteer </option>
							         
							         
							  </select>
							  
							  
						<%--	  <input name="firstname" type="text" class="verdana11" id="firstname" />--%></td>
							</tr>
 
							<tr bgcolor="#F8F8F8">
							  <td height="28">Last Name: </td>
							  <td height="28"><input name="lastname" type="text" class="verdana11" id="lastname" /></td>
							</tr>
							<tr bgcolor="#F8F8F8">
							  <td height="28">Address:</td>
							  <td height="28"><input name="address" type="text" class="verdana11" id="address" /></td>
							</tr>

							<tr bgcolor="#F8F8F8">
							  <td height="28">City:</td>
							  <td height="28"><input name="city" type="text" class="verdana11" id="city" /></td>
							</tr>
							<tr bgcolor="#F8F8F8">
							  <td height="28">State:</td>
							  <td height="28"><input name="state" type="text" class="verdana11" id="state" /></td>
							</tr>

							<tr bgcolor="#F8F8F8">
							  <td height="28">Zip Code: </td>
							  <td height="28"><input name="zipcode" type="text" class="verdana11" id="zipcode" /></td>
							</tr>
							<tr bgcolor="#F8F8F8">
							  <td height="28">Phone</td>
							  <td height="28"><input name="tel" type="text" class="verdana11" id="tel" /></td>
							</tr>

							<tr bgcolor="#F8F8F8">
							  <td height="28">Email address: </td>
							  <td height="28"><input name="email" type="text" class="verdana11" id="email" /></td>
							</tr>
							<tr>
							  <td height="28">&nbsp;</td>
							  <td height="28">&nbsp;</td>
							</tr>

							<%--<tr>
							  <td height="28" class="titleResults"><img src="images/arrowOrange.gif" width="10" height="10" align="absmiddle" /> Method of Payment </td>
							  <td height="28">&nbsp;</td>
							</tr>--%>
							<%--<tr bgcolor="#F8F8F8">
							  <td height="28">Card Type:</td>
							  <td height="28"><select name="cardtype" class="verdana11" id="cardtype">

								<option>Select Method</option>
								<option value="Visa">Visa</option>
								<option value="Amex">American Express</option>
								<option value="MasterCard">MasterCard</option>
								<option value="Discover">Discover</option>
							  </select></td>
							</tr>
							<tr bgcolor="#F8F8F8">

							  <td height="28">Card Number: </td>
							  <td height="28"><input name="cardnumber" type="text" class="verdana11" id="cardnumber" /></td>
							</tr>
							<tr bgcolor="#F8F8F8">
							  <td height="28">Expiration Date: </td>
							  <td height="28"><input name="expdate" type="text" class="verdana11" id="expdate" /></td>
							</tr>
							<tr bgcolor="#F8F8F8">

							  <td height="28">CVV Security Code: </td>
							  <td height="28"><input name="cvv" type="text" class="verdana11" id="cvv"" /></td>
							</tr>
							<tr>
							  <td height="28">&nbsp;</td>
							  <td height="28">&nbsp;</td>
							</tr>--%>
						<%--	<tr bgcolor="#F8F8F8">

							  <td height="28">How did you hear about the Friendship Circle Song?</td>
							  <td height="28"><select name="heard" class="verdana11" id="heard">
								<option selected="selected">Select One</option>
								<option value="Local Chapter">Local Chapter</option>
								<option value="Friend">Friend</option>
								<option value="Composer">Moshe Hecht</option>

								<option value="Search Engine">Search Engine</option>
                                <option value="Other">Other</option>
																				  </select></td>
							</tr> --%>
							<tr>
							  <td height="28">&nbsp;</td>
							  <td height="28">&nbsp;</td>
							</tr>

							<tr>
							  <td height="28">&nbsp;</td>
							  <td height="28">  <input id="amount"  name="amonunt" type="hidden"  value="5"  runat="server" /> 


 
	  				         <input id="hdnInput"  type="hidden"     runat="server" /> 
                       

<input id="prefexi"  name="prefex" type="hidden"  value='<asp:Literal   runat="server" ID="prefex"></asp:Literal>'   /> 


 <input   type="submit"  value="Submit" name="Submit" 
                                                        id="Submit" />
                                                        
<%-- <input  runat="server" type="submit" onclick="javascript:return vld(this.form)" value="Submit" name="Submit" 
                                                        id="Submit1" />--%>
                                                         </td>
							</tr>
							
							
							  					
						

                      </table></form>
						
		</body>		
		</html>			 





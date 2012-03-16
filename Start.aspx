 <%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" viewStateEncryptionMode ="Never"
  CodeFile="Start.aspx.cs" Inherits="Start" %>
  
  
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
    
    
<script src="Javascript.js" type="text/javascript"></script>
       
    
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










 








        
                        
                        
                        <form   runat="server" id="frmDownLoadSong"  style=" padding:5px; border:solid 3px pink;"  >
                <div style=" padding-top:20px; ">&nbsp</div>
                      <table width="400" border="0" align="center" cellpadding="5" cellspacing="5">
			 			
						
						
						 
									
									<tr><td> <hr style="color:Yellow;" /></td>   <td height="28" class="titleResults">&nbsp;   Organization Form &nbsp; </td>              </tr>
																										
							
						 
					 
							
							

							
							
							
						
						
						
						
						
						
							
							
							 
	<tr>
							  <td height="28"> </td>
							  <td height="28"></td>
							</tr>
							 <tr bgcolor="#F8F8F8">
							  <td height="28">Org Title: </td>
							  <td height="28"><input name="OrgTitle" size="100" type="text" class="verdana11" id="firstname" /></td>
							</tr>
							
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org Funactionality: </td>
							  <td height="28"><input name="orgFucnionality" type="text"  size="100" class="verdana11" id="orgFucnionality" /></td>
							</tr>
                            <tr bgcolor="#F8F8F8">
							  <td height="28">Org Description: </td>
							  <td height="28"><input name="orgDescription"    size="50"      type="text" class="verdana11" id="orgDescription" /></td>
							</tr>
							<!--<tr bgcolor="#F8F8F8">
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
							</tr>-->
						

							<tr bgcolor="#F8F8F8">
							  <td height="28">Email address: </td>
							  <td height="28"><input name="orgEmail"  size="50"    type="text" class="verdana11" id="orgEmail" /></td>
							</tr>
						
						
						
						
							<tr bgcolor="#F8F8F8">
							  <td height="28">TaxID</td>
							  <td height="28"><input name="orgTaxID"   size="50"      type="text" class="verdana11" id="orgTaxID" /></td>
							</tr>
						
						
							<tr bgcolor="#F8F8F8">
							  <td height="28">PayPal  Account</td>
							  <td height="28"><input name="orgPayPalAccount"  size="50"   type="text" class="verdana11" id="orgPayPalAccount" /></td>
							</tr>
						
						
						
							<tr>
							  <td height="28">&nbsp;</td>
							  <td height="28">&nbsp;</td>
							</tr>

							 
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org Logo</td>
							  <td height="28"><input name="orgLogo"  size="50"   type="text" class="verdana11" id="orgLogo" /></td>
							</tr>
						
						
						
						
							<tr>
							  <td height="28">&nbsp;  <input name="buttonLogo"  size="50"   type="file" class="verdana11" id="buttonLogo" /></td>
							  <td height="28">&nbsp;   
							 
						<%--	    <input name="ConfirmImg" value="Confirm"  type="submit" id="ConfirmImg" style="background-image:url('images/right.gif');" runat="server" />
						--%>	    		 
							    		 
							    		   <asp:Button ID="ConfirmImg"      runat="server"     Text="Submit" /> 
							   <asp:Button      runat="server"  OnClick="OnSaveClick" Text="Confirm Image" /> 
</td>
							</tr>









							<tr>
							 
  <td height="28">&nbsp;
 
	  				         <input id="hdnInput"  type="hidden"     runat="server" /> 
                       

 


 <input   type="submit"  value="Submit" name="Submit"  onclick="javascript:return vld(this.form);"
                                                        id="Submit" />
                                                         
                                                         </td>
							</tr>
							
							
							  					
						

                      </table></form>
                      
                      
                      <script language="javascript" type="text/javascript">
                      
                      
                       function vld(form) {
                           var msg = '';   							      
 	                               var checkboxtst =0;
 	                                  var partdaytst =0; 
 	                                  var checkbox  =   form.getElementsByTagName('input')  ;
 	                                 
 	                                  for (var i = 0; i <= form.getElementsByTagName("input").length - 1; i++) {

 	                                     

 	                                      var id =  checkbox[i].id ;
 	                                      var type = checkbox[i].type;
 	                                      var name = checkbox[i].name;

 	                                      var value = checkbox[i].value;



 	                                      if (name == 'Org_Name' && value == '') { msg += 'invalid Organization name  \n'; }
 	                                      if (name == 'orgFucnionality' && value == '') { msg += 'invalid Organization Fucnionality  \n'; }
 	                                      if (name == 'org_email' && value == '') { msg += 'invalid  email address   \n'; }

 	                                      if (name == 'org_TaxID' && value == '') { msg += 'invalid Organization Tax ID  \n'; }
 	                                      if (name == 'org_PayPalAccount' && value == '') { msg += 'invalid PayPalAccount  \n'; }
 	                                      if (name == 'orgDescription' && value == '') { msg += 'invalid Description  \n'; }
 	                                       
 	                                       	                                      
 	                                      
 	                           
        	                   
        	                   if (checkbox[i].name == 'email' && checkbox[i].value != '') {
        	                       var rex = /\w+@+\w+\.+/;
        	                       var test = rex.test(checkbox[i].value);
        	                       if (test == false) { msg += 'invalid email address  \n'; }

        	                   }


                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
                        	   
        	               }
        	               
                        	 
	  
	             if (msg != ''  && msg!=null)
	             { alert(msg); return false; } 
			 	               
		 	                  		 	      
		 	        return true;		 	     
		 	  



                }
                
                
                
                
                
                      
                      </script>
                      
                      
                      
						
		</body>		
		</html>			 





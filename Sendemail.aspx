<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sendemail.aspx.cs" Inherits="Sendemail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="frmContact"   method="post" action="Sendemail.aspx"  runat="server">
    
    
    
    <div style=" top:0px; left:0px; margin-left:40px;margin-top:40px;">
    
    
    
    
    
    
    
    
    
    
    
     
    
    
    
    
    
    
    
    
    
    <asp:DropDownList runat="server" id="drplstEmil">
    </asp:DropDownList>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    <table width="376"  border="0" cellpadding="0" cellspacing="0" style="border-left:solid 5px pink;" >
                <%--<tr style="  background-image:url(images/contact/R8C2.jpg)">
                  <td width="307" height="29" style="  background-image:url(images/contact/R8C3.jpg)"><input  id="name"  name="name" type="text"       value=""   style=" border:solid 2px white;  width:100px;" /> </td>
                  <td width="69" height="29" style="  background-image:url(images/contact/R8C3B.jpg)"></td>
                </tr>
                <tr>
                  <td width="307" height="45" style="  background-image:url(images/contact/R9C3.jpg)"></td>
                  <td width="69" height="45" style="  background-image:url(images/contact/R9C3B.jpg)"></td>
                </tr>
                <tr>
                  <td width="307" height="29" style="  background-image:url(images/contact/R10C3.jpg)"><input  id="email"  name="email" type="text"  value=""          style=" border:solid 2px white;  width:100px; " /> </td>
                  <td width="69" height="29" style="  background-image:url(images/contact/R10C3B.jpg)"></td>
                </tr>--%>
                <tr><%--  <td width="307" height="44" style="  background-image:url(images/contact/R9C2.jpg)"></td>--%>
                  <td width="307" height="44" style="  background-image:url(images/contact/R11C3.jpg)"></td>
                  <td width="69" height="44" style="  background-image:url(images/contact/R11C3B.jpg)"></td>
                </tr>
                <tr><%--<td width="307" height="44" style="  background-image:url(images/contact/R9C2.jpg)"></td>--%> 
                  <td width="307" height="239" style="  background-image:url(images/contact/R12C3.jpg)" valign="top">
                  
                
                  <textarea     cols="80" rows="100"    id="message"  name="message" runat="server"  style=" border:solid 2px white;   width:235px; height:235px"   />  </td>
                  <td width="69" height="239" style="  background-image:url(images/contact/R12C3B.jpg)"></td>
                </tr>
                <tr><%--<td width="307" height="44" style="  background-image:url(images/contact/R9C2.jpg)"></td>--%>
                  <td width="307" height="19" style="  background-image:url(images/contact/R13C3.jpg)"></td>
                  <td width="69" height="19" style="  background-image:url(images/contact/R13C3B.jpg)"></td>
                </tr>
                <tr>
                <td width="307" height="35" >
                  <asp:ImageButton id="btnSend" onclick="sendEmail" Width="60" Height="50" ImageUrl= "images/contact/R14C3.jpg"  Text="Submit Email" SkinID="email"   runat="server"   /> 
                </td>
                
                <%--  <td width="307" height="35" style="  background-image:url(images/contact/R14C3.jpg)">
                 <!-- <a href="mailto:info@systemoriginal.com">-->
                  <a href="javascript:return submitform(this.form)"  > 
                 
               <asp:ImageButton id="btnSend" onclick="sendEmail"  Text="Submit Email" SkinID="email"   runat="server"   /> 
               
     <%--        <input type="submit" name="submit"   onclick="javascript:return vld(this.form)"  />--%>
               
             <%--  <a href="#">  <img    onclick="javascript:return vld(this.form)"  id="sbm"  src="images/contact/submit_button.jpg"  alt="" style="  width:91px; height:35px; " width="91" height="35"  border="0" align="right"/> </a> 
             
               
               
               </td>--%>
                  <td width="69" height="35" style="  background-image:url(images/contact/R14C3B.jpg)"></td>
                </tr>
                <tr>
                  <td width="307" height="73" style="  background-image:url(images/contact/R15C3.jpg)"></td>
                  <td width="69" height="73" style="  background-image:url(images/contact/R15C3B.jpg)"></td>
                </tr>
              </table>        
 
    
    
    
  
    
    
    
    
    
    
    
    
    
    
    
    
    
    </div>
    </form>
    
    
    <script type="text/javascript">
     
  	 function vld(form)	  
  	 	 
		  {	var  msg = '';
		      var frmContact = document.getElementById("frmContact");
		      var message = frmContact.getElementsByTagName("input").item("message");

		      if (message.value == '' || message.value == null)    
        	           {     msg  +=   input.name  +  ' was left blank   \n'      ;}
		
 	 //  alert('yes');   alert(frmContact);  alert(frmContact.getElementsByTagName("input").length);
 	  
// 	  	 var donate =  document.getElementById("donate") ;
//		  	 if (donate.value=='Download Song') return ;
	
//		  
//		 	  
//	    	for ( var gg=0;  gg  <=    frmContact.getElementsByTagName("input").length-1 ; gg++  )
//            {		  var input  =    frmContact.getElementsByTagName("input").item(gg) ;
// 
// 
//  	        if ((input.value == '' || input.value == null)  && input.type!='hidden'   )  
//        	           {     msg  +=   input.name  +  ' was left blank   \n'      ;}

//   

//            if (input.name=='email'         && input.value!=''  )
//             {var  rex = /\w+@+\w+\.+/  ;
//             var test = rex.test(input.value);
//             if (test==false)   {     msg  +=    'invalid email address  \n'      ;}
//  
//             }   


//                }
                
               
                 
		 	 if (msg != ''  && msg!=null) 
		 	  {   alert(msg);    return false;           } 
			 	     else		 	     
			 	     
		 	      {
		 	      
		 	       
		 	         sndmsg();

//		 	         __doPostBack();

//		 	         window.location.reload(); 
		 	           
		 	         frmContact.submit();
                       
		 	         return true; } 	
		 	   
		 	    
		 	   		 }  
		 	   		 
		 	   		 
		</script> 	   		 
    
    
    
    
    
    
    
    
    
    
    
</body>
</html>

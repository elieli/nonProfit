<%@ Page Language="C#" AutoEventWireup="true"         CodeFile="OrgForm.aspx.cs" Inherits="OrgForm" %>

    <script type="text/javascript" src="javascript/jquery-1.2.3.js" ></script> 
<%--
            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
           <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server"> 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
  <ContentTemplate>  MasterPageFile="Site.master"      --%>
  
<%-- <div  runat="server" visible="false"  > 
    Item Search   <asp:TextBox runat="server"   Width="100" ID="txtItemSearch"></asp:TextBox>
    
    &nbsp   &nbsp 
        <asp:Button runat="server"  Text="Item Search" OnClick="itemSearch" ID="TextBox1"></asp:Button>
    
       &nbsp   &nbsp 
     
    
    
    
       </div>--%>
       
     <%--   <script src='javascript/jquery-1.2.3.js'  type="text/javascript"></script>--%>
       
       
<html  xmlns="http://www.w3.org/1999/xhtml" style=" height:160px; width:600px;"  >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body style=" height:160px; width:600px;"  >
       
      <form  method="post"  action="OrgForm.aspx"  runat="server"   id="frmDownLoadSong" 
      style=" background-color:Aqua; padding:5px; border:solid 3px pink;"  >
    <div  style=" margin-left:3%; margin-right:5%;">
    
    
      
       
    
    <div  style="position:relative;"> 
    
    
    
        		
					 
        
        
        </div>
        
        
        
        <hr />
        
      <%--  <asp:Button  id="btnCnfApprove"    runat="server" OnClick="approveOrg"   Text="Confirm Approve"  />
       
          
    <div  style= " text-align:left;  float:left; ">  
            <asp:Label runat="server" ID="lblsts" Text="Org status"></asp:Label><br />
        <asp:DropDownList   ID="drplstEmailSts"    OnSelectedIndexChanged="chgsts" runat="server">
        <asp:ListItem  runat="server" Text="Pending" Value="pending"></asp:ListItem>  
         <asp:ListItem   runat="server" Text="Approved" Value="approved"></asp:ListItem> 
          <asp:ListItem   runat="server" Text="Canceled" Value="canceled"></asp:ListItem> 
           <asp:ListItem   runat="server"  Selected="True" Text="All"  ></asp:ListItem>
        </asp:DropDownList>
        
         </div> --%>
    
      
    
     
   
   
   
    
   
   <div style=" ">    
       
   
        <div id="Div1"     style="float:left; "   runat="server"    >
         
               
      
        
        			<p  style="float:left" >General Information </p><p  id="clickmeupg" style="float:right" >+</p> <p  id="clickmedng" style="float:right" >-</p> </div><div  id="Div3">
			
        
        
          
      
        <div id="Div2"     style="float:left;"    runat="server"      >
               
               <div style="float:left;" >
                <br />
    
               
               </div>
               
               
               
                 <div   style="float:left;" >   
               
               
          <%--      <uc1:orgProducts ID="orgProducts2" runat="server" />--%>
          
           </div>  
          
   
        
        
        
        
           </div>   
               </div>   
        
          <hr />
        
        
    <div   style= " clear:left; " > 
         <h4>     <span  style="border-top:solid 0px pink;" >    <%= SubGmachTitle     %>           </span>
         
         
         
  
        
          </h4> 
        
  
        </div>
      </div> 
<%--</div>
      --%>
      
         
       
       
                     
                <div style=" padding-top:20px;"  id="dvgeneral">&nbsp       
                      <table width="400" border="0" align="center" cellpadding="5" cellspacing="5">
			 			
						
						
						 
									
									<tr><td> <hr style="" /></td>   <td height="28" class="titleResults">&nbsp;   Organization Form &nbsp; </td>              </tr>
																										
							
						 
					 
							
							

							
							
							
						
						
						
						
						
						
							
							
							 
	<tr>
							  <td height="28"> </td>
							  <td height="28"></td>
							</tr>
							 
							 
							 <tr bgcolor="#F8F8F8">
							  <td height="28">Org Title </td>
							    <td height="28">Upload Org Logo </td>
							</tr>
							
							
							 
							 <tr bgcolor="#F8F8F8">
							
							  							  <td height="28"><input name="OrgTitle" runat="server" size="100" type="text" class="verdana11" id="OrgTitle" /></td>

							  <td height="28">
							   <input name="buttonLogo" runat="server"  size="50"  onchange="javascript:chgCenterImage('File1','imgCenter');"  type="file" class="verdana11" id="File1" />
							  </td>
							</tr>
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org Logo</td><%-- <asp:Image  Width="120" Height="120" runat="server" ID="Image1" />--%>
							  <td height="28"><input name="orgLogo"  size="50"   runat="server" type="text" runat="server"
							   class="verdana11" id="orgLogo" /></td>
							</tr>
						
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Address:</td>
							  <td height="28">
							 <%--  <input name="buttonLogo"    size="50"  onchange="javascript:chgCenterImage('buttonLogo','imgCenter');"  type="file" class="verdana11" id="File2" />
					--%>	  </td>
							</tr>							
							<tr bgcolor="#F8F8F8">
							  <td height="28"><input name="orgAddress"    size="50"  runat="server"     type="text" class="verdana11" id="Text2" /></td>
							  <td height="28">
							  </td>
							</tr>
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">City:</td>
							  <td height="28">
							 <%--  <input name="buttonLogo"    value="Upload Org Video" size="50"  onchange="javascript:chgCenterImage('buttonLogo','imgCenter');"  type="file" class="verdana11" id="File3" />
						--%>  </td>
							</tr>							
							<tr bgcolor="#F8F8F8">
							  <td height="28"><input name="orgCity"    size="50"  runat="server"     type="text" class="verdana11" id="Text3" /></td>
							  <td height="28">
							  </td>
							</tr>
							
							
							
								
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">State:</td>
							  <td height="28">
							<%--   <input name="buttonLogo"  value="Upload Org Video" size="50"  onchange="javascript:chgCenterImage('buttonLogo','imgCenter');"  type="file" class="verdana11" id="File4" />
						--%>  </td>
							</tr>							
							<tr bgcolor="#F8F8F8">
							  <td height="28">
							  
							  
							 <asp:DropDownList runat="server" ID="drplstStates"> 
							 
							 
							 <asp:ListItem> </asp:ListItem>
							 <asp:ListItem>  Alabama  </asp:ListItem>
							  					<asp:ListItem >  	Alaska 	 </asp:ListItem>
							  					<asp:ListItem>  	Arizona 	  </asp:ListItem>
							  					<asp:ListItem> 	Arkansas </asp:ListItem>
							  				
							  				
							  				<asp:ListItem> 	California 	  </asp:ListItem>
							  				<asp:ListItem> 	  	Colorado 	  </asp:ListItem>
							  				<asp:ListItem> 	 	Connecticut 	 </asp:ListItem>
							  				<asp:ListItem>  	Delaware </asp:ListItem>
							  			
							  			
							  				<asp:ListItem> 	Florida 	 </asp:ListItem>							  			
							  					<asp:ListItem>  	Georgia 	 </asp:ListItem>
							  					<asp:ListItem>  	Hawaii  </asp:ListItem>							  			
							  					<asp:ListItem> 	 	Idaho</asp:ListItem>
							  			
							  				<asp:ListItem> Illinois  </asp:ListItem>							  			
							  				<asp:ListItem>  	Indiana 	 </asp:ListItem>
							  				<asp:ListItem>  	Iowa 	 </asp:ListItem>
							  				<asp:ListItem>   	Kansas</asp:ListItem>
							  			
							  				<asp:ListItem> Kentucky 	 </asp:ListItem>							  			
							  				<asp:ListItem>  	Louisiana  </asp:ListItem>
							  				<asp:ListItem>  	Maine 	 </asp:ListItem>							  			
							  				<asp:ListItem>  	Maryland</asp:ListItem>
							  			
							  				<asp:ListItem> Massachusetts 	 </asp:ListItem>
							  			<asp:ListItem>  	Michigan 	 </asp:ListItem>
							  			<asp:ListItem>  	Minnesota 	 </asp:ListItem>							  			
							  			<asp:ListItem>  	Mississippi</asp:ListItem>
							  			
							  			
							  			<asp:ListItem> Missouri 	 </asp:ListItem>							  			
							  			<asp:ListItem>  	Montana  </asp:ListItem>
							  			<asp:ListItem>  	Nebraska 	 </asp:ListItem>
							  			<asp:ListItem> 	Nevada</asp:ListItem>
							  			
							  				<asp:ListItem> New Hampshire </asp:ListItem>							  			
							  				<asp:ListItem>  	New Jersey  </asp:ListItem>							  			
							  				<asp:ListItem>   	New Mexico  </asp:ListItem>							  			
							  				<asp:ListItem>  	New York</asp:ListItem>
							  			
							  				<asp:ListItem>North Carolina  </asp:ListItem>
							  				<asp:ListItem>  	North Dakota  </asp:ListItem>
							  					<asp:ListItem> 	Ohio 	 </asp:ListItem>
							  						<asp:ListItem> 	Oklahoma</asp:ListItem>
							  					
							  					<asp:ListItem>Oregon 	 	 </asp:ListItem>
							  					<asp:ListItem> 	Pennsylvania  	 </asp:ListItem>
							  					<asp:ListItem>  	Rhode Island 	 </asp:ListItem>
							  					<asp:ListItem>  	South Carolina</asp:ListItem>
							  					
							  					
							  							<asp:ListItem> South Dakota 	 </asp:ListItem>							  					
							  							<asp:ListItem>  	Tennessee </asp:ListItem>							  					
							  							<asp:ListItem>  	Texas 	 </asp:ListItem>							  					
							  							<asp:ListItem> 	Utah</asp:ListItem>
							  							
							  						<asp:ListItem> Vermont 	 </asp:ListItem>							  					
							  						<asp:ListItem>   	Virginia 	 </asp:ListItem>
							  						<asp:ListItem>  	Washington  </asp:ListItem>
							  						<asp:ListItem>  	West Virginia  </asp:ListItem>
							  						<asp:ListItem>    Wisconsin  </asp:ListItem>
							  						<asp:ListItem>  	Wyoming</asp:ListItem>				  					
							  					
							 
							 </asp:DropDownList>
							  <%--<select   name="orgDescription"    size="50"  runat="server"     class="verdana11" id="orgDescription"  >
							  				
							  					
							  				
							  					</Select> 
--%>

							  
							  
							  
							  
							  
							  
							  <td height="28">
							  </td>
							</tr>
							
							
							
							
							
									
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Zip:</td>
							  <td height="28">
						 		  </td>
							</tr>							
							<tr bgcolor="#F8F8F8">
							  <td height="28"><input name="orgZip"    size="50"  runat="server"     type="text" class="verdana11" id="Text5" /></td>
							  <td height="28">
							  </td>
							</tr>
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Phone:</td>
							  <td height="28">
						 		  </td>
							</tr>							
							<tr bgcolor="#F8F8F8">
							  <td height="28"><input name="orgPhone"    size="50"  runat="server"     type="text" class="verdana11" id="Text6" /></td>
							  <td height="28">
							  </td>
							</tr>
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="20">Email address: </td>
							  <td height="20"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">
							 
							  <td height="28"><input name="orgEmail"  size="50"   runat="server"  type="text" class="verdana11" id="orgEmail" /></td>
							 <td height="28"> </td>
							 </tr>
						
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="20">Facebook URL: </td>
							  <td height="20"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">
							 
							  <td height="28"><input name="orgFacebook"  size="50"   runat="server"  type="text" class="verdana11" id="Text8" /></td>
							 <td height="28"> </td>
							 </tr>
						
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Twitter URL: </td>
							  <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">
							
							  <td height="28"><input name="orgTwitter"  size="50"   runat="server"  type="text" class="verdana11" id="Text9" /></td>
							  <td height="28"> </td>
														
							</tr>
						
						
						
						
						
						
						
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Twitter URL: </td>
							  <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">
						
							  <td height="28"><input name="orgTwitter"  size="50"   runat="server"  type="text" class="verdana11" id="Text10" /></td>
							
											  <td height="28"> </td>				
							</tr>
						
						
						
						<script type="text/javascript" >
						    function saveknow(youknow) {
						        know = document.getElementById(youknow);
						        
						       var hdnOrgKnow = document.getElementById('<%=hdnOrgKnow.ClientID %>');
						       alert('know.value' + know);
						       if (hdnOrgKnow == '') { hdnOrgKnow.value = know.value; }
						       else {
						           know.value = '~' + know.value;
						           hdnOrgKnow.value += know.value;
						           know.value = '';
						           alert(know.value);
						           alert(hdnOrgKnow.value);
						        }  
						     }
						</script>
						
						
						
						
							<tr bgcolor="#F8F8F8">
							 <%-- <td height="28"> </td>--%>
							 
							 <input type="hidden" id="hdnOrgKnow" runat="server" />
							  <td height="228" colspan="2"><textarea name="txtaraOrgKnow"  size="550"  rows="10" cols="115"  runat="server"   type="text" class="verdana11" id="txtaraOrgKnow"  > </textarea>
							  <input type="button" value="Enter Org Fuction and Press" id="btnOrgKnow" onclick="saveknow('txtaraOrgKnow');" /> </td></tr></table>
							  
							  <div style="width:100%; height:15px; border:solid black 2px;" >
						<p  style="float:left" >Personal Information </p><p  id="clickmedn" style="float:right; font-size:larger; background-color:Fuchsia;" >+</p> <p  id="clickmeup" style="float:right; font-size:larger; background-color:Fuchsia; " >-</p> </div><div  id="info">
							
						<%--	</table>--%>
							
							   </div>
							<table>
							
							
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org Description:
							     </td><input name="orgDesc"    size="50"  runat="server"     type="text" class="verdana11" id="orgDescription" /> 
							 <%--<td height="28">--%>
							
							  <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">
						
							  <td height="28">
							  <input name="orgFucnionality" type="text"  runat="server" size="100" class="verdana11" id="orgFucnionality" />
							  </td> 									 
							  <td height="28"> </td>
							  </tr>
							
							
							
							
							 
							 
							<tr bgcolor="#F8F8F8">
							<td height="28">TaxID</td>
							    <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">						
							  <td height="28">
				             <input name="orgTaxID"   size="50"     runat="server"  type="text" class="verdana11" id="orgTaxID" /></td> 		
							<td height="28"></td>
							</tr>
							
							
							 
							
							 
							<tr bgcolor="#F8F8F8">
							<td height="28">Orginaztion  User ID</td>
							    <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">						
							  <td height="28">
				            <input name="Password"  size="50"  type="password" runat="server"   class="verdana11" id="orgUserid" />
				            </td> 		
							<td height="28"></td>
							</tr>
							
							
							
							<tr bgcolor="#F8F8F8">
							<td height="28">Orginaztion  Password</td>
							    <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">						
							  <td height="28">
				            <input name="Password"  size="50"  type="password" runat="server"   class="verdana11" id="orgPassword" />
				            </td> 		
							<td height="28"></td>
							</tr>
							
							
							
							<tr bgcolor="#F8F8F8">
							<td height="28">PayPal  Account</td>
							    <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">						
							  <td height="28">
				            <input name="orgPayPalAccount"  size="50"  runat="server"  type="text" class="verdana11" id="orgPayPalAccount_" />
				            </td> 		
							<td height="28"></td>
							</tr>
							
							
							
							
							
							
							
							
							
							
							
							
							<%--
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org Funactionality:</tr><tr bgcolor="#F8F8F8">
							   
							  </td>
							
		
							
							</tr>--%>
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
							<tr bgcolor="#F8F8F8"><td>
                    <div id="dvFlashCenter"    > 
                                        
                    </div>
                    
                     <input id="dvFlashCentertxt" runat="server"  style="visibility:hidden;"   type="text"   /> 
                                        
                 
                    
                     
                     <input id="dvimgCentertxt"  style="visibility:hidden;" runat="server" type="text"  /> 
                                        
                  
                    
 <%-- <input  ID="Button1"    type="button"  name="btnLoadImg"  runat="server"  onclick="javascript:OpenPopup();"  value ="Load Video" />--%>
							     <a href="#"   onclick= "window.open('Gallery.aspx?type=flash&id=dvFlashCenter&idd=flashCenter', 'list' , 'width=550  , height=650' );   "     >
							     <span style=" background-image:url( Images/rzdo29.jpg    ); border:solid black 1px; height:50px; width:50px;" ><strong>Load Video</strong> </span></a>
    <%-- <input name="buttonLogo" runat="server"  size="50"  onchange="javascript:chgCenterVideo('buttonLogo','dvFlashCenter');"  type="file" class="verdana11" id="File2" />
--%>
						 <%-- dvFlashCenter.InnerHtml = "<object width='525' height='844'>  <embed src='" + "images/" + xml_list.ardonateImgNumber[pointer] + "' type='application/x-shockwave-flash' width='525' height='844'></embed></object>";
--%>
						
						
						
							 <%--  <td height="28">Org Logo</td><asp:Image  Width="120" Height="120" runat="server" ID="imgCenter_" />
							  <td height="28"><input name="orgLogo"  size="50"   runat="server" type="text" class="verdana11" id="orgLogo" /></td></tr><tr>
							  <td height="28">&nbsp; <input name="buttonLogo" runat="server"  size="50"  onchange="javascript:chgCenterImage('buttonLogo','imgCenter');"  type="file" class="verdana11" id="buttonLogo" /></td><td height="28">&nbsp; <%--	    <input name="ConfirmImg" value="Confirm"  type="submit" id="ConfirmImg" style="background-image:url('images/right.gif');" runat="server" />--%>
					 
						<img  id="imgCenter"  height="25"  width="25"    alt="" style= " border:solid brown 3px;     height:550px; width:500px;  "   src=""       /> 
						
						
						<img  id="flashCenter"   height="25"  width="25"    alt="" style= " visibility:hidden; border:solid brown 3px;     height:0px; width:0px;  "   src=""       /> 
					
						
						11
						<%--
						<asp:Button ID="ConfirmImg"   OnClientClick="javascript:return vld(this.form);"  OnClick="Process"    runat="server"     Text="Submit" />
						--%>
						
						<input type="submit" onclick= "javascript:return  copytxt('true');"   value="Submit" />
						
						 
							   <input  ID="btnLoadImg"    type="button"  name="btnLoadImg"  runat="server"  onclick="javascript:OpenPopup();"  value ="Load Image" />
							     <a href="#"   onclick= "window.open('Gallery.aspx?type=image&id=imgCenter&idd=flashCenter', 'list' , 'width=550  , height=650' );     "     ><span style=" background-image:url( Images/rzdo29.jpg    ); border:solid black 1px; height:50px; width:50px;" ><strong>  Image</strong></span></a>
     <input name="buttonLogo" runat="server"  size="50"  onchange="javascript:chgCenterImage('buttonLogo','imgCenter');"  type="file" class="verdana11" id="buttonLogo" />
     </td><td height="28">&nbsp; <%--	    <input name="ConfirmImg" value="Confirm"  type="submit" id="ConfirmImg" style="background-image:url('images/right.gif');" runat="server" />
							    </td></tr><tr>
							
  <td height="28">&nbsp; <input id="hdnInput"  type="hidden"     runat="server" /> 
                       
</td> </tr>

 
</table>
<%--
 <input   type="submit"  value="Submit" name="Submit"  onclick="javascript:return vld(this.form);"
                                                        id="Submit" />--%> 
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        </td></tr></table></div></div></form>
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        <script language="javascript" type="text/javascript">
                                                            
                                
                                
                                function copytxt(imageFlash) {alert('yes');

//                                                                if (imageFlash=='true') {


                                        var dvFlashCenter = document.getElementById('dvFlashCenter');

                                        if (dvFlashCenter) {
                                            var dvFlashCentertxt = document.getElementById('<%=dvFlashCentertxt.ClientID %>');


                                            dvFlashCentertxt.value = dvFlashCenter.innerHTML;

                                            var dvFlashC = unescape(dvFlashCentertxt.value.substring(dvFlashCentertxt.value.indexOf('src'), dvFlashCentertxt.value.length));
                                            var flashCenter = document.getElementById('flashCenter');
                                            dvFlashCentertxt.value = flashCenter.src;
                                            ///alert(dvFlashC);
                                            
                                           //alert(dvFlashCentertxt.value +'dvFlashCenter.innerHTML');
                                             
                                        }
                                                  //                                                                } else {
                                

                                        var dvimgCentertxt = document.getElementById('<%=dvimgCentertxt.ClientID %>');
                                        if (dvFlashCenter) {
                                            var imgCenter = document.getElementById('imgCenter');
                                            // alert(imgCenter); alert(imgCenter.src);
                                            dvimgCentertxt.value = imgCenter.src;
                                            //alert(dvimgCentertxt.value + "imgCenter");
                                        }
                                        /// __doPostBack('btnSave');

                                        return true;
                                    }
//                                                            }


                          function chgCenterImage(fileLoad, imgTop) {



                              var fileLoads = document.getElementById(fileLoad);
                              var imgTops = document.getElementById(imgTop);

                              ///alert(fileLoads + '    imgTops.src  ' + imgTops);
                             //// forcePost(fileLoads.value);


                             //alert(fileLoads.value + '               ' + imgTops);
                             imgTops.src = 'images/' + fileLoads.value;

                           
                              //   alert(imgTops.src + '               ' + imgTops);

                          }





                          function chgCenterVideo(fileLoad, imgTop) {





                              var fileLoads = document.getElementById(fileLoad);
                              var imgTops = document.getElementById(imgTop);

                              //alert(fileLoads + '    imgTops.src  ' + imgTops);
                              //// forcePost(fileLoads.value);


                              //alert(fileLoads.value + '               ' + imgTops);
                             // imgTops.src = 'images/' + fileLoads.value;


                              imgTops.InnerHtml = "<object width='225' height='444'>  <embed src='" + "images/" + unescape(fileLoad) + "' type='application/x-shockwave-flash' width='525' height='844'></embed></object>";

                                alert(imgTops.src + '               ' + imgTops);

                          }











  

                          function OpenPopup() {

                             //// //alert('stop1');
                             
                             var win = new window
                              win.open("Gallery.aspx", "List",  "scrollbars=no,resizable=no,width=400,height=280");


                              window.open('Gallery.aspx', 'List', 'width=350  , height=250'); 
                           
                            //  alert('stop2');
                              return false;
                              //alert('stop3');
                          }





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


                $('#clickme').click(function() {
                    $('#book').fadeOut('slow', function() {
                        // Animation complete.
                    });
                });
                
                
                
                $('#clickme').click(function() {
                $('#book').fadeIn('slow', function() {
                        // Animation complete
                    });
                });





                $('#clickmeup').click(function() {
                    $('#info').slideUp('slow', function() {
                        // Animation complete.
                    });
                });



                $('#clickmedn').click(function() {
                    $('#info').slideDown('slow', function() {
                        // Animation complete.
                    });
                });




                $( '#clickmeupg').click(function() {
                $('#dvgeneral').slideUp('slow', function() {
                        // Animation complete.
                    });
                });



                $( '#clickmedng').click(function() {
                $('#dvgeneral').slideDown('slow', function() {
                        // Animation complete.
                    });
                });












                $('#clickme').click(function() {
                    $('#book').animate({
                        opacity: 0.25,
                        left: '+=50',
                        height: 'toggle'
                    }, 5000, function() {
                        // Animation complete.
                    });
                });




                
                
                $('li').animate({
                    opacity: .5,
                    height: '50%'
                },
{
    step: function(now, fx) {
        var data = fx.elem.id + ' ' + fx.prop + ': ' + now;
        $('body').append('<div>' + data + '</div>');
    }
});
                      
                      </script>
                      
                      
                      
                      
                      
                      
                      
                      </body>
                      
                     <%-- </ContentTemplate></asp:UpdatePanel>
                      
                      
                      
                      </asp:Content><%--
 
<!DOCTYPE html>
<html>
<head>
  <style>
div {
background-color:#bca;
width:100px;
border:1px solid green;
}
</style>
  <script src="http://code.jquery.com/jquery-latest.js"></script>
</head>
<body>
  <button id="go">&raquo; Run</button>

<div id="block">Hello!</div>
<script>

    /* Using multiple unit types within one animation. */

    $("#go").click(function() {
        $("#block").animate({
            width: "70%",
            opacity: 0.4,
            marginLeft: "0.6in",
            fontSize: "3em",
            borderWidth: "10px"
        }, 1500);
    });
</script>

</body>
</html>

<!DOCTYPE html>
<html>
<head>
  <style>
div {
  position:absolute;
  background-color:#abc;
  left:50px;
  width:90px;
  height:90px;
  margin:5px;
}
</style>
  <script src="http://code.jquery.com/jquery-latest.js"></script>
</head>
<body>
  <button id="left">&laquo;</button> <button id="right">&raquo;</button>
<div class="block"></div>

<script>
    $("#right").click(function() {
        $(".block").animate({ "left": "+=50px" }, "slow");
    });

    $("#left").click(function() {
        $(".block").animate({ "left": "-=50px" }, "slow");
    });

</script>

</body>
</html>--%>
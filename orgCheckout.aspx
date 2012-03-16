<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orgCheckout.aspx.cs"    MasterPageFile="Site.master"            Inherits="orgCheckout" %>

 
 


            <%@ Register src="orgProducts.ascx" tagname="orgProducts" tagprefix="uc1" %>







            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
  <ContentTemplate> 
  
<%-- <div  runat="server" visible="false"  > 
    Item Search   <asp:TextBox runat="server"   Width="100" ID="txtItemSearch"></asp:TextBox>
    
    &nbsp   &nbsp 
        <asp:Button runat="server"  Text="Item Search" OnClick="itemSearch" ID="TextBox1"></asp:Button>
    
       &nbsp   &nbsp 
    
          <asp:DropDownList runat="server" ID="drplstOrgs" AutoPostBack="true" OnSelectedIndexChanged="refreshOrgs" >
    
    </asp:DropDownList>
    
    
    
       </div>--%>
       
       
       
       
       
    <form id="form1"   >
    <div  style=" margin-left:3%; margin-right:5%;">
    
    
      
       
    
    <div  style="position:relative; border:solid 3px black; "> 
    
    
     
    <%--
        	<asp:LinkButton  Text="Products Page" runat="server"  PostBackUrl="~/orgProducts.aspx"></asp:LinkButton>
    --%>
    
    
        		<asp:HiddenField runat="server" ID="hdnvdo" />
					 					
					 							
					 
				 
        	 <%--<div style= " padding-left:20px; float:left; ">
        	 <asp:Button runat="server" ID="btnMatch" OnClick= "chgsts"  Text="View"/>
        	 
        	 </div>
        --%>
        
    
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
    
      
    
     
   
   
   
    <div     style=" text-align:center;    "      >
          
    </div>
   
   
   
   
 <%--  side section--%>
   
   <div    style="float:left; height: 617px; width:131px; border:solid 5px black;"   
            runat="server"   >
      
     
      
      
    
      
                <input type="hidden"  runat="server" id="hdnVideo" />
                
                
					 					
                
                             <img id="dvLogo"   style="height:50px; width:60px;"   runat="server" />            
                           
      
                   <div id="dvdVideo"   style="height:50px; width:60px;"  onclick="loadVideo(this);"     oninit="loadVideo(this);"  >            
                   </div>
                        
                           
            
                   <div id="dvDonate"   style="height:20px; width:60px;"   runat="server"  >            
                   </div>
                        
                           <div id="dvAddress"    style="height:50px; width:60px;"   runat="server"  >            
                             </div>
            
            
            
     
     <div runat="server"  style=" height:137px; width:125px;" id="dvKnow"> </div>
     
            
            
            
            </div>
   
   
   
   
   
   <div style="border:solid 4px white;">    
       
   
        <div     style="float:left; height: 617px; margin-left:10px; border:solid 3px pink; width: 1017px;"     runat="server"    >
         
               
      
        
        
        
        
          
      
        <div     style="float:left;"    runat="server"      >
               
               <div style="float:left;" >
                <br />
    <div>        </div>
    <br />
              <%--     <uc2:category ID="category1" runat="server" />--%>
               
               </div>
               
               
               
                 <div   style="float:left;" >   
               
               
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
                
       
    
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
							  <td height="28">Org  CurrentBidPrice</td><%-- <asp:Image  Width="120" Height="120" runat="server" ID="Image1" />--%>
							  <td height="28"><input name="orgLogo"  size="50"   runat="server" type="text" runat="server"
							   class="verdana11" id="lblCurrentBidPrice" /></td>
							</tr>
							
							
								
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org   ProductTitles</td><%-- <asp:Image  Width="120" Height="120" runat="server" ID="Image1" />--%>
							  <td height="28"><input name="orgLogo"  size="50"   runat="server" type="text" runat="server"
							   class="verdana11" id="lblProductTitles" /></td>
							</tr>
							
							
							
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org    Handling</td><%-- <asp:Image  Width="120" Height="120" runat="server" ID="Image1" />--%>
							  <td height="28"><input name="orgLogo"  size="50"   runat="server" type="text" runat="server"
							   class="verdana11" id="lblHandling" /></td>
							</tr>
							
         	
							<tr bgcolor="#F8F8F8">
							  <td height="28">Org    Shipping</td><%-- <asp:Image  Width="120" Height="120" runat="server" ID="Image1" />--%>
							  <td height="28"><input name="orgLogo"  size="50"   runat="server" type="text" runat="server"
							   class="verdana11" id="lblShipping" /></td>
							</tr
							
							
							
							
							 
							
							
							
							
							
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
							  
							  
                                                 
                                                   <img id="imgMediumImage" style=" border:solid  0px pink;" src='<%=MediumImageUrl %>' alt='<%=ImageDesc %>'  height="439"/></a>
                                                   
							  
							  
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
							<td height="28">Orginaztion  Password</td>
							    <td height="28"> </td>
							</tr>
							
							<tr bgcolor="#F8F8F8">						
							  <td height="28">
				            <input name="Password"  size="50"  type="password" runat="server"   class="verdana11" id="orgPayPalAccount" />
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
                    
                    
                    <asp:Button ID="btnCheckout" runat="server" OnClick="checkout"  Text="Submit Checkout" />
                                        
                   
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
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        </td></tr></table></div>
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
              
    
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
      
         
       
      
      
      
  <asp:DataList AlternatingItemStyle-BackColor="AntiqueWhite" ID="DataList1"  Visible="false"    RepeatColumns="4" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" >
   
   
 
   <ItemStyle   Width="190px"    />
 <SeparatorStyle Width="6px" Height="7px" />
       
   
   <ItemTemplate>
   
   
      <div style="border:solid 10px white;" >
   
   
    <%-- <div  >
    <asp:Label runat="server" id="id" Text='<%#DataBinder.Eval(Container.DataItem, "orgID") %>'></asp:Label>
     <%#DataBinder.Eval(Container.DataItem, "orgID")%>
   

      <%# Eval("title")%> 
  
      <a   href=''>     </a> 
   
    </div>--%>
      <div  id="dv_Emil"  style="float:left; " runat="server"> 
      
      <%--  <a href='orgProduct.aspx? '+'  <%# Eval(Container.DataItem, "itemida")%>+  ' >  --%>
  <%#DataBinder.Eval(Container.DataItem, "Title")%>  </a> 
    
    <p   style=" margin-left:-40px;    vertical-align:text-top; text-align:left; ">
       <div  id="Div1" style="float:left;"   runat="server">
 <%--   <img  src="Images/contact/submit_button.jpg" alt="" id="Img1" /> --%>
  
  
 <a href='orgProfile.aspx'>  <img  src='' alt="" id="imgItem" runat="server" /></a> 
 
 
   
    </div>
  
  <%-- <%# Eval("orgDescription")%>'  runat="server" />--%>
   
    <%#DataBinder.Eval(Container.DataItem, "auctionType")%>  
    
   </p>
    
   
    
    
      </div>
  </ItemTemplate>
     
     
     
     
     
    
   
  
   
    
    
    </asp:DataList>
       
      
      
       </div>  
      
    <script type="text/javascript" >

      //  capture();








     ////   var dvVideo = document.getElementById('dvVideo');
     /////   window.onload(loadVideo('dvVideo'));
    
    
    
    
    
    
    </script>
    
    
     <script type="text/javascript">
         function loadVideo(dvVideo) {



             alert('yes'+ dvVideo);
             
             var hdnVideo = document.getElementById('<%=hdnVideo.ClientID%>');

             //// var dvVideo = document.getElementById('dvVideo');

             var newdiv = document.createElement('div');
             alert('hdnVideo' + hdnVideo);
             var flash = "<object width='55' height='144'>  <embed src='" + "images/" + unescape(hdnVideo.value) + "' type='application/x-shockwave-flash' width='225' height='444'></embed></object>";
             alert(flash);

             // var images = "images/" + fileLoads;

             newdiv.innerHTML = unescape(flash);

             ///alert(newdiv);

             dvVideo.appendChild(newdiv);


             alert(dvVideo.innerHTML);







         }
      </script>
    
    </form> </ContentTemplate> </asp:UpdatePanel>
</asp:Content>
<%--</body>
</html>--%>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
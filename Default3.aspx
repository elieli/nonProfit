<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<%@ Register Assembly="rjs.web.webcontrol.popcalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     <script type="text/javascript" src="javascript/jquery-1.2.3.js" ></script> 
<script type="text/javascript">
   

    $(document).ready(function() {
    filldrplist();
})


function chgdt(fdt, tdt) {

    ///alert(fdt + 'fdt, tdt' + tdt);
    if (fdt != null  &&  document.getElementById(tdt)!=null)
     {
        var doc = document.getElementById(tdt);
    if ( doc!=null)
        {doc.value = fdt.value;}
     }   
 

    ///alert(document.getElementById(tdt).value + 'document.getElementById(tdt).value' + fdt.value);
      
  }
    
    
    
   </script>
   
   
    <link  rel="Stylesheet"   href="StyleSheet.css" />
</head>
<body ">
    <form id="form1"  action="Default3.aspx"  method="post"  runat="server" style=" margin-left:100px; left:100px; padding:50px;"  >
    
    
    
    
    
    
    
     
                    
                     
                     <input id="dvimgCentertxt1"  type="text"  style=" visibility:hidden;" runat="server" /> 
                                             
                     <input id="dvimgCentertxt2"  type="text"  style=" visibility:hidden;" runat="server" /> 
                                            
                     <input id="dvimgCentertxt3"  type="text"  style=" visibility:hidden;" runat="server" /> 
                                             
                     <input id="dvimgCentertxt4"  type="text"  style=" visibility:hidden;" runat="server" /> 
                                        
               
                
               
               
    
                     <%--
                     <div id="dvimgCentertxt2"  style=" visibility:hidden;" runat="server" > 
                                        
                    </div>
    
    
                     
                     <div id="dvimgCentertxt3"  style=" visibility:hidden;" runat="server" > 
                                        
                    </div>
    
                     
                     <div id="dvimgCentertxt4"  style=" visibility:hidden;" runat="server" > 
                                        
                    </div>
    
    --%>
    
    
    
    
    
    
    
    
    <input type="hidden" value="EasyLister" name="MfcISAPICommand" id="MfcISAPICommand"/>
    <input type="hidden" value="114545176712" name="sid" id="sid"/>
    
    
     
				
				
				
				
				
				
				
				
				
				<h1> Organization  </h1><h2>   <asp:Label runat="server" ID="lblorgstitle"></asp:Label>      </h2>  
				
				 
				
				
				
				Category selected:
				<strong>        <asp:Label id="lblbreadcrumbs" runat="server"></asp:Label>      </strong>
				
				&nbsp;
			 	
				<div>	<strong>   Title :   <input   id="txtTitle"   type="text" runat="server"/>       </strong></div> 
			
			
			
				<div>	<strong>   Description :     <textarea  id="txtareaDesc"  rows="10"  cols="140" Text="" runat="server"></textarea>      </strong></div> 
			
			
			
				<div>	<strong>   Shipping Fee :     <input   id="shipFee1"   type="text" runat="server"/>     </strong></div> 
			
			
		
			
			
			
			
			
			
			
			
		<strong> 	Title:</strong>
				<input id="title" maxlength="80" name="title" runat="server"   size="70"     type="text" value=""/>
			
			
			
			
			
			
				 <input type="hidden" value="163014" name="cat1" id="cat1"/><div class="sec"><a name="secHdr2_anch"></a><div id="catHd" class="secHead"><div><h2>Bring your item to life with pictures</h2></div></div><table cellspacing="10" cellpadding="0" border="0" class="tipsTable"><tbody><tr valign="top"><td><div id="picBox">
											Good News! Gallery Plus is <span class="feePromo">free</span> for this category.
										
										
										
									 <div class="picFrm picFrmIE6" id="picFrm1">
										
										
											  <img  id="imgCenter1"  onchange=" copytxt(this, 1);  "   alt="" 
                                                  style= " border:solid brown 3px;     height:107px; width:172px;  "   
                                                  src=""       />    
							  
									</div>	<div style="display: none; visibility: hidden;" class="picTxt" id="picFrmTxt">
					Your Gallery Picture
				</div><div style="background-color: rgb(254, 203, 0);" class="picwell" id="picWellLyr1">
				
			<a  href="#"  onclick="window.open('Gallery.aspx?type=image&id=imgCenter1&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=500,height=180');  "    >
			<img alt="Add a photo" class="camIcon" src=" " id="picWell1"/>
				 
					 </a>	
					 
					 
					   <input  ID="btnLoadImg"    type="button"  name="btnLoadImg"  runat="server" onclick="window.open('Gallery.aspx?type=image&id=imgCenter1&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280'); "    value ="Load Image" /> 
				
				
				</div>
				 	
				 	
				 	
				 	
				 	
				 	
				 	
				 	
				 	
				 	
										 <div class="picFrm picFrmIE6" id="Div2">
										
										
											  <img  id="imgCenter2"    onchange=" copytxt(this, 1);"    alt="" 
                                                  style= " border:solid brown 3px;     height:98px; width:175px;  "   
                                                  src=""       />    
							  
									</div>	<div style="display: none; visibility: hidden;" class="picTxt" id="Div3">
					Your Gallery Picture
				</div><div style="background-color: rgb(254, 203, 0);" class="picwell" id="Div4">
				
			<a  href="#"  onclick="window.open('Gallery.aspx?type=image&id=imgCenter2&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280');"     >
			<img alt="Add a photo" class="camIcon" src=" " id="Img2"/>
				 
					 </a>	
					 
					 
					   <input  ID="Button1"    type="button"  name="btnLoadImg2"  runat="server"  onclick="window.open('Gallery.aspx?type=image&id=imgCenter2&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280')"   value ="Load Image" /> 
				
				
				</div>
				 	
						
						
				<div>
            <input style="float:left;"  id="Text1" value="Items Included" type="text" />	
            <input style="float:left;"  id="Button4" type="button" onclick="additem();" value="Items Included button" />
						<br />
            <select id="Select1">
                <option></option>
            </select>
						
					 </div>			
						
						
						
						
						
						
						
						
						
						
										 <div class="picFrm picFrmIE6" id="Div6">
										
										
											  <img  id="imgCenter3"     alt=""  onchange=" copytxt(this, 1);"  
                                                  style= " border:solid brown 3px;     height:114px; width:180px;  "   
                                                  src=""       />    
							  
									</div>	<div style="display: none; visibility: hidden;" class="picTxt" id="Div7">
					Your Gallery Picture
				</div><div style="background-color: rgb(254, 203, 0);" class="picwell" id="Div8">
				
			<a  href="#"  onclick="window.open('Gallery.aspx?type=image&id=imgCenter3&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280');"    >
			<img alt="Add a photo" class="camIcon" src=" " id="Img4"/>
				 
					 </a>	
					 
					 
					   <input  ID="Button2"    type="button"  name="btnLoadImg3"  runat="server"  onclick="window.open('Gallery.aspx?type=image&id=imgCenter3&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280');"  value ="Load Image" /> 
				
				
				</div>
				 	
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
						
										<div id="Div9"><div class="picFrm picFrmIE6" id="Div10">
										
										
											  <img  id="imgCenter4"     alt="" onchange=" copytxt'this, 1);"  
                                                  style= " border:solid brown 3px;     height:122px; width:184px;  "   
                                                  src=""       />    
							  
									</div>	<div style="display: none; visibility: hidden;" class="picTxt" id="Div11">
					Your Gallery Picture
				</div><div style="background-color: rgb(254, 203, 0);" class="picwell" id="Div12">
				
			<a  href="#"  onclick="window.open('Gallery.aspx?type=image&id=imgCenter4&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280'); "   >
			<img alt="Add a photo" class="camIcon" src=" " id="Img6"/>
				 
					 </a>	
					 
						<img  id="flashCenter"   height="0"  width="0"    alt="" style= " visibility:hidden; border:solid brown 3px;     height:0px; width:0px;  "   src=""       /> 
					
					 
					   <input  ID="Button3"    type="button"  name="btnLoadImg4"  runat="server" onclick="window.open('Gallery.aspx?type=image&id=imgCenter4&idd=flashCenter', 'List', 'scrollbars=no,resizable=no,width=400,height=280'); "   value ="Load Image" /> 
				
				
				</div>
				 				
						
						
						
						
				 
					
										<label for="duration" id="Label1">&nbsp;Starting Date&nbsp;</label>&nbsp;
					
					
					<div> 
					 &nbsp; Start Date 
					 <asp:TextBox runat="server" onchange="chgdt(this,'startDate');"  ID="txtstartDate"> </asp:TextBox> 
		<input type="text" style="visibility:hidden;" runat="server" ID="startDate"/>  

					<rjs:PopCalendar id="PopCalendar1" runat="server" Control="txtstartDate" 
BorderWidth="" Fade="1" Language="" SelectedDate="" StartAt="Sunday" 
Format="m d yyyy" Separator="/" 
Move="True"></rjs:PopCalendar> 			
Time


<input runat="server"  value="1"  style="visibility:hidden;" id="sdrphours1" />
<select ID="drphours1"  onchange="chgdt(this,'sdrphours1');"  ></select>
<%--
<select ID="drpHour_" runat="server">
<option>1</option>
<option>2</option>
<option>3</option>
<option>4</option>
<option>5</option>
<option>6</option>
<option>7</option>
<option>8</option>
<option>9</option>
<option>10</option>
<option>11</option>
<option>12</option> 
</select>--%>
<%--
<asp:DropDownList ID="drpHour" runat="server">
    <asp:ListItem>1</asp:ListItem>
    <asp:ListItem>2</asp:ListItem>
    <asp:ListItem>3</asp:ListItem>
    <asp:ListItem>4</asp:ListItem>
    <asp:ListItem>5</asp:ListItem>
    <asp:ListItem>6</asp:ListItem>
    <asp:ListItem>7</asp:ListItem>
    <asp:ListItem>8</asp:ListItem>
    <asp:ListItem>9</asp:ListItem>
    <asp:ListItem>10</asp:ListItem>
    <asp:ListItem>11</asp:ListItem>
    <asp:ListItem>12</asp:ListItem>
    <asp:ListItem></asp:ListItem>
</asp:DropDownList>--%><strong>:</strong>




<input runat="server"  value="0"  style="visibility:hidden;" id="sdrpminutes1" />
<select ID="drpminutes1"   onchange="chgdt(this,'sdrpminutes1');"  ></select>
<%--<asp:DropDownList ID="drpMinute" runat="server">
</asp:DropDownList>&nbsp;<asp:DropDownList ID="drpdMode" runat="server">
    <asp:ListItem>AM</asp:ListItem>
    <asp:ListItem>PM</asp:ListItem>
    <asp:ListItem></asp:ListItem>
</asp:DropDownList>--%>
 <input   runat="server"  style="visibility:hidden;" id="SdrpdMode1" />
 <select onchange="chgdt(this,'SdrpdMode1');"   ID="Select3" >
    <option>AM</option>
    <option>PM</option>
    
</select>

</div>
<div><br />
                                             
 <input type="text" runat="server" style="visibility:hidden;" ID="DateTime2"/>  
					
					&nbsp; End Date <asp:TextBox runat="server"  onchange="chgdt(this,'DateTime2');"  ID="txtDateTime2">
					 </asp:TextBox>
					
                                            
					 
					<rjs:PopCalendar id="popcalDate" runat="server" Control="txtDateTime2" 
BorderWidth="" Fade="1" Language="" SelectedDate="" StartAt="Sunday" 
Format="m d yyyy" Separator="/" 
Move="True"></rjs:PopCalendar> 

Time


<input runat="server"  value="0"  style="visibility:hidden;" id="sdrphours2" />
<select ID="drphours2"  onchange="chgdt(this,'sdrphours2');"  ></select>
<%--
<select ID="" style="visibility:hidden;" runat="server"></select>--%>
<%--<asp:DropDownList ID="drpHour2" runat="server">
    <asp:ListItem>1</asp:ListItem>
    <asp:ListItem>2</asp:ListItem>
    <asp:ListItem>3</asp:ListItem>
    <asp:ListItem>4</asp:ListItem>
    <asp:ListItem>5</asp:ListItem>
    <asp:ListItem>6</asp:ListItem>
    <asp:ListItem>7</asp:ListItem>
    <asp:ListItem>8</asp:ListItem>
    <asp:ListItem>9</asp:ListItem>
    <asp:ListItem>10</asp:ListItem>
    <asp:ListItem>11</asp:ListItem>
    <asp:ListItem>12</asp:ListItem>
    <asp:ListItem></asp:ListItem>
</asp:DropDownList>--%><strong>:</strong>



<input runat="server" value="0"  style="visibility:hidden;" id="sdrpminutes2" />
<select ID="drpminutes2"  onchange="chgdt(this,'sdrpminutes2');"  ></select>

 

<%--
<asp:DropDownList ID="drpMinute2" runat="server"> 
 </asp:DropDownList>--%>&nbsp;
 <input   runat="server"  style="visibility:hidden;" id="sdrpdMode2" />
 <select onchange="chgdt(this,'sdrpdMode2');"   ID="drpdMode2" >
    <option>AM</option>
    <option>PM</option>
    
</select>






<br />




					<a name="duration_anch"></a><select  name="duration" runat="server" id="duration"><option  runat="server"  value="1">1 day</option><option  runat="server" value="3">3 days</option><option  runat="server" value="5">5 days</option><option runat="server"  selected="" value="7">7 days</option><option runat="server"  value="10">10 days</option></select>&nbsp;
					
				</div>	
					
				<div>Model:	<input type ="text" runat="server" size="55"  id="txtModel"/>
				</div>
					
						
				<div>Make:	<input type ="text" size="23"  runat="server" id="txtMake"/>
				</div>
					
					
					 
					
					
					
					<a class="helpBtn" href="#" name="priceHlp" id="priceHlp"><img border="0" align="absmiddle" title="Help on Price" alt="Help on Price" src=" "></a></div><div></div>
					
					
					
					 
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
<input runat="server"  value="1" style="visibility:hidden;" id="handlingTime" />
 
							
							
					 <div> </div>
							
							
							<div id="HandlingTimeEnabled"><div><label for="shipsWithinDays" id="">Handling Time</label>&nbsp;
				<a name="shipsWithinDays_anch"></a><select             onchange="chgdt(this,'handlingTime');"                  name="shipsWithinDays" runat="server"     id="shipsWithinDays"><option runat="server" value="0">Select a handling time</option><option runat="server" value="1">1 business day</option><option runat="server" value="2">2 business days</option><option runat="server" selected="" value="3">3 business days</option> </select>&nbsp;
						<a class="helpBtn" href="#" name="handlingtimeHlp" id="handlingtimeHlp"><img border="0" align="absmiddle" title="Help on Handling time" alt="Help on Handling time" src=" "></a></div><div></div></div>
						
						
						
					 
						
						 	 
						 
						 
						 
						 
						 
						 
						 
				 		 <input type="hidden" id="itemsIncluded" />
						 
						 
						 
						 
						 	
						
						
						
						<%--</form>--%>
    
    
    
      
    
    <div>
   <input   type="submit"    onclick= "javascript:return  copytxt('','true');"  /> 
    
<%--  <asp:Button runat="server" id="btnCnfrmItem"  OnClick="CnfrmItem" /> </div> --%>
    
    
    
    
    
    
    
    
      </form>
    
    
    
    
   <%-- </div>--%>
  
</span>
  
</body>

<script type="text/javascript">
    function OpenPopup() {

        ////alert('stop1');

        var win = new window
        window.open("Gallery.aspx", "List", "scrollbars=no,resizable=no,width=400,height=280");
        //  alert('stop2');
        return false;
        //alert('stop3');
    }





    function additem() {
        alert('additem');

        var Text1 = document.getElementById('Text1');


        var Select1 = document.getElementById('Select1');
        var itemsIncluded = document.getElementById('itemsIncluded');

      var option = document.createElement("option");
       option.nodeValue = Text1.value;
        alert('additem' );
        Select1.options.add(option );
       
       alert('additem' +Select1.options[0]);
        itemsIncluded.value += Text1.value == "" ? Text1.value : ',' + Text1.value;

        alert('additem' + Select1.options[0]);
    }
 
 
 
 
 



    function filldrplist( ) {
        //var select = document.getElementById('=drpminutes1.ClienID ');
        var select = document.getElementById('drpminutes1');
        for (var x = 0; x <= 60; x++) {
            select.options[select.options.length] = new Option(x, x);
          }

         var select2 = document.getElementById('drpminutes2');
         for (var j = 0; j <= 60; j++) {
              select2.options[select2.options.length] = new Option(j, j);
          }


          var select3 = document.getElementById('drphours1');
          for (var u = 1; u <= 12; u++) {
              select3.options[select3.options.length] = new Option(u, u);
          }

         var select4 = document.getElementById('drphours2');
          for (var z = 1; z <= 12; z++) {
              select4.options[select4.options.length] = new Option(z, z);
          }



    }
    












    function copytxt( dv,number) {

     //   alert('copytxt' + dv + number);

        var dvimgCentertxt1; var dvimgCentertxt2; var dvimgCentertxt3; var dvimgCentertxt4;
//            switch (number) {
//                case 1:
                    dvimgCentertxt1 = document.getElementById('<%= dvimgCentertxt1.ClientID %>');

                    var imgCenter = document.getElementById('imgCenter1');
                    dvimgCentertxt1.value = imgCenter == null || imgCenter.src.indexOf('aspx', 0) != -1 ? '' : unescape(imgCenter.src);

//                    break;
//                case 2:
                    dvimgCentertxt2 = document.getElementById('<%= dvimgCentertxt2.ClientID %>');

                    imgCenter = document.getElementById('imgCenter2');
                    dvimgCentertxt2.value = imgCenter == null || imgCenter.src.indexOf('aspx' ) != -1 ? '' : unescape(imgCenter.src);
                    
                    
//                    break;
//                case3:
                    dvimgCentertxt3 = document.getElementById('<%= dvimgCentertxt3.ClientID %>');
                   imgCenter = document.getElementById('imgCenter3');
                   dvimgCentertxt3.value = imgCenter == null || imgCenter.src.indexOf('aspx' ) != -1 ? '' : unescape(imgCenter.src);
                    
                    
//                    break;
//                case 4:
                    dvimgCentertxt4 = document.getElementById('<%= dvimgCentertxt4.ClientID %>');

                    imgCenter = document.getElementById('imgCenter4');
                    dvimgCentertxt4.value = imgCenter == null || imgCenter.src.indexOf('aspx') != -1 ? '' : unescape(imgCenter.src);
                    
//                    break;
                    
//            }



                    var drphour1 = document.getElementById('drphour1');
                    var tdt = 'sdrphour1';
                    chgdt(drphour1, tdt);


                    var drphour1 = document.getElementById('drphour2');
                    var tdt = 'sdrphour2';
                    chgdt(drphour1, tdt);

                    var drpminute1 = document.getElementById('drpminute1');
                    var tdt = 'sdrpminute1';
                    chgdt(drpminute1, tdt);

                    var drpminute2 = document.getElementById('drpminute2');
                    var tdt = 'sdrpminute2';
                    chgdt(drpminute2, tdt);


//            var imgCenter = document.getElementById('imgCenter1');
//            dvimgCentertxt.value = unescape( imgCenter.src);

            ///alert(imgCenter.src + '   imgCenter'  );
            ////alert(dvimgCentertxt1.value + '   imgCenter');
            
             
        return true;
    }
 </script>
                         
                      
                      
</html>

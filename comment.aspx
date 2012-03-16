<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false"  CodeFile="comment.aspx.cs" Inherits="comment" %>
 <%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>- 
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%> <%-- overlay.style.zIndex=100;   overlay.style.opacity=0.8;    overlay.filters.alpha.opacity=80  ;  
margin-bottom:-755px; background-color: #FFFFFF;    --%> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
  <link rel="Stylesheet" target="DailySteals.css" src='DailySteals.css' />
        
        <style type="text/css">
   
   
   
   
   
   

#panel1 {float:left;
	 
	  height:400px;  width:400px;
	}
   
   
   
   
   
   
   
   
   

#####overlay {
	background-color:#c0c0c0;    
    width: 100%;
	bottom:0px;
    min-height: 100%;
    position: absolute;
    top: 0;
    left: 0;
	 
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
 
	left:0;
 vertical-align:middle;
	-moz-opacity: 1.0;
	opacity: 1.0;
	right:0;
	vertical-align:50px;
	 
}
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
  
   

#panel 
{
	position:relative;  background:transparent; 
	
	background-repeat:repeat;
	border:3px;
	border-color: #fcdc2a;
	filter: alpha(opacity=100);
	height:10%;
	left:0;
	margin:  50px 0px 0px 0px;
	-moz-opacity: 1.0;
	opacity: 1.0;
	right:0;
	vertical-align:50px;
	width: 10%;
} 








   	.mytable{}
  .mytable td {
border:0 none;
padding:6px;
text-align:left;
}
.mytable th {
border-bottom:2px solid #F68C26;
font-size:16px;
font-weight:bold;
padding:6px;
text-align:left;
}
.mytable input, .button {
}
.orderConfDetails .mytable td {
padding:2px 6px;
}
 
  
.fancyzoomBox {
position:absolute;
z-index:99999;
} 
</style>
</head>
<body   onload="javascript:load();"  style="width:500px;  height:350px;   background-color:White;">
  
  
      
          
 
 <%--
    <form id="form1" action ="comment.aspx" method="post"   style="width:500px; background-color:White; height:350px;" runat="server">
   --%>   
      
    <form id="form2"   style="width:500px; left:0px; margin-left:50px; top:0px; margin-top:50px; background-color:White; height:350px;" runat="server">
      
      
      
      <div style=" position:absolute;"  id="dvNew" 
      
      
    <input id="hdnauid" type="hidden" runat="server" />
        <div  style=" width:50px;  display:inline; float:left;" > 
           <input id="itemsearch"  type="text" readonly="readonly"   /> 
        </div>
  
       <div  style=" width:50px;  display:inline; float:left;" > 
       
     <asp:TextBox runat="server"   Width="400" ID="txtItemSearch" 
            style="margin-top: 0px"></asp:TextBox> &nbsp   &nbsp   
       &nbsp   &nbsp    </div>
    &nbsp   &nbsp 
    
    
     
      <div  id="dvCatsGen"  runat="server"  style="  border:solid black 2px;   position:absolute; visibility:hidden;          
           background-color:White; z-index:100; width:700px; height:auto" >
      
          <a style=" float:right;" href="#" onclick="javascript:closedvCatsGen(); " > Close </a> 
          <%--<asp:ListBox  ID="grdvCatGeneral"  AutoPostBack="true"      OnSelectedIndexChanged="items_Search"  runat="server" >
    
      </asp:ListBox>  --%> 
     
      
      
       <asp:GridView  ID="grdvCatGeneral" runat="server"  OnSorting="sortOrders"     OnRowDataBound="grdvCatGeneral_OnItemDataBound"  
             OnSelectedIndexChanged="items_Search"    
             ForeColor="#333333" GridLines="None" ShowFooter="false" Caption= ' <h4>     <span  style="border-top:solid 3px pink;" >     </span> </h4>      '
            CaptionAlign="Top">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />     
  
   
 
   
   <Columns>
 
     <asp:TemplateField    >
  
     <ItemTemplate>
       <div id="dvlst"  runat="server">   
       
     <%--  <asp:LinkButton  id="lnklst"   runat="server"></asp:LinkButton>--%>
         </div>
     
      </ItemTemplate>
     </asp:TemplateField>
        </Columns></asp:GridView>
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      </div>
      
      <div  
               style=" text-align:center; vertical-align:text-bottom; width:163px;  float:left; height: 43px;" > 
     
     
          <asp:Button runat="server"  Text="Search" OnClick="catSearch"   ID="Button1" 
              BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Width="88px"></asp:Button>
        
    
       
       
       
        </div>
       
      
      
      
      
      
      
      
      
      
      
     <div id="overlay"  >
 
<%--   <div style="width:100%; height:50%;  padding:140px;  "  > </div>
--%>	 
    <div id="overlay_panel"  style="  border:8px;   border-style:solid; background-color:white;">
	<div id="panel1" style="  position:relative;  left:0px; margin-left:20px; width:auto; height:auto   ">
   <%--     test<input type="button" value="btnTest" />--%>
     
      
   
      
      
       
      
      
      
      
      
      
      
    
       <table class="mytable"  style="visibility:hidden;" id="tblPost"  >
    <tr  ><th colspan="3">Post A Comment</th> <th><span onclick="javascript:javascript:history.go(-1);">X</span></th></tr>

         
        <tr>

            <td>
                Subject:</td>
            <td>
                <input name="txtTitle" type="text" maxlength="255"    ID="txtTitle" runat="server" style="width:200px;" />
            </td>
            <td>
                <span id="" style="color:Red;">required</span>
            </td>

        </tr>
        <tr>
            <td>
               Comment: </td>
            <td>
            
            <asp:TextBox ID="txtmsg" runat="server" Rows="50"  Width="100" ></asp:TextBox>
               
      
      <div id="dvPreview" runat="server" style="   "> 
      </div>
      
                <div  id="dvFCKeditor" runat="server"  >
               <FCKeditorV2:FCKeditor ID="HTMLEmailEdit" runat="server" BasePath="~/FCKeditor/" Height="350px">
                            </FCKeditorV2:FCKeditor> 
            </div>  
                &nbsp;</td>

        </tr>
      <%--  <tr>
            <td>
                Your Location (optional):</td>
            <td> &nbsp; &nbsp;
                City:
                <input name="txtCity" type="text" id="txtCity" />
                &nbsp;&nbsp;&nbsp; State:
                <input name="txtState" type="text" id="txtState" style="width:50px;" />

            </td>
            <td>
                &nbsp;</td>
        </tr>--%>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <input type="submit"  value="Post Comment"      onclick="javascript:return vld(this.form)"  ID="comment_" name="comment_"  runat="server"  class="blueButton" />


           <asp:Button   value="Submit Message"  class="blueButton" OnClick="SendMessage"   runat="server" style="margin: 0 2px;" />
    
                <button  value="Cancel"  class="blueButton" style="margin: 0 2px;" onclick="javascript:history.go(-1)">
                    cancel
                </button>
                
                   <button class="blueButton" id="btnPreview" type="submit"  runat="server" onclick="javascript:__doPostBack('btnPrevieww', 'ddd')" style="margin:2px;"  >
                    preview
                </button><%--<asp:Button  runat="server" id="btnPrevieww" Visible="false" OnClick="preView" />--%>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    <tr><th colspan="3"> </th></tr>
        
    </table>
    

      </div>   
      
      
       </div>
      </div>
      
      
      
      
      
   
      
      
      
      
      
      
      
      
      
      
         
      <div style=" padding-top:10px; " > 
        
        <div      style=" border:solid black 10px; "       ><input  id="btnNew" type="button" value="Send New Message"  onclick="sendnew();" /> </div>
        
        
        
        
        
        
         <asp:ListBox  ID="lstvCatGeneral"  AutoPostBack="true"      OnSelectedIndexChanged="items_Search"  runat="server" >
    
      </asp:ListBox>   
     
  <asp:GridView  ID="dtalstItems" runat="server"  OnSorting="sortOrders"    OnRowDataBound="rptProductList_OnItemDataBound"  
   
     ForeColor="#333333" GridLines="None" ShowFooter="True" Caption= ' <h4>     <span  style="border-top:solid 3px pink;" >     </span> </h4>      '
            CaptionAlign="Top">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />     
  
   
 
   
   <Columns>
  
     <asp:TemplateField    HeaderText="ID">
   
     <ItemTemplate>
        <div> 
     <div id="dvauctionid" runat="server" style="  float:left; " >
      </div>
   
      
       <div  id="dvusername"  runat="server"  style="  float:left; " >   </div>
 
  <div  id="dvprice"   runat="server" style="  float:left; " >   </div>
    
    
    
     
   
     <div  id="amount" style="font-size:  15pt; font:left; color: Red; font-family: Arial Black;
                                                                            display: inline">
                    </div>
    </div>
    
    
    
        <%-- <div> <a runat="server" id="anchorProfile"    >  
    
                <span> &nbsp   &nbsp <strong>Checkout</strong>   <%#DataBinder.Eval(Container.DataItem, "item_AuctionID")%>
                 </span>      </a> 
        </div>--%>
  
  
    
     
       </ItemTemplate>
    </asp:TemplateField  >
   
  
     
     
     <asp:TemplateField HeaderText="ID">
   
     <ItemTemplate>
  
      <div  id="dv_Emil"  style="float:left; " runat="server"> 
       <p runat="server" id="title"     >  
     <%--   <a href='orgProduct.aspx?   <%# Eval(Container.DataItem, "itemida")%>  ' > --%> 
                  <span></span>  </p> 
    
    <p   style=" margin-left:-40px;    vertical-align:text-top; text-align:left; ">
       <div  id="Div1" style="float:left;"   runat="server">
 <%--   <img  src="Images/contact/submit_button.jpg" alt="" id="Img1" /> --%>
  
 
<%-- <img  src='' width="150" alt="" id="imgItem" runat="server" />--%>
 
 
   
    </div></div>
  
  <%-- <%# Eval("orgDescription")%>'  runat="server" />--%>
   
  <%--  <%#DataBinder.Eval(Container.DataItem, "auctionType")%>  
    --%>
  
  <%--
  <br />  <br /> --%>
  
  
       </ItemTemplate>
    </asp:TemplateField  >
   
  
       
    <asp:TemplateField HeaderText="ID">
   <ItemTemplate>
  
  
  <%-- <div style=" font-size:small;">--%>
  
 <%-- <p> Current Price: &nbsp   &nbsp <%#DataBinder.Eval(Container.DataItem, "price")%>  <br /> 
    
    
                        Ends: &nbsp   &nbsp  <%#DataBinder.Eval(Container.DataItem, "endTime")%>  </p>   --%>
   
  
     <div style=" font-size:small;float:left;   "  runat="server" id="currentBidPrice" >
    
    
    </div>
    
    
    
  
       </ItemTemplate>
    </asp:TemplateField  >
   
  
       
    <asp:TemplateField HeaderText="Messahe">
   <ItemTemplate>
  
    
  
     <div style=" font-size:small;float:left;  width:200px;  "  runat="server" id="forumMessage" >
    
    
    </div>
    
    
  
  
       </ItemTemplate>
    </asp:TemplateField  >
   
  
       
    <asp:TemplateField HeaderText="forumdate">
   <ItemTemplate>
  
     <div style=" font-size:small;float:left;   "  runat="server" id="forumdate" >
    
    
    </div>
    
    
  
       </ItemTemplate>
    </asp:TemplateField  >
   
  
       
    <asp:TemplateField HeaderText="Customer">
   <ItemTemplate>
  
    
  
     <div style=" font-size:small;float:left;   "  runat="server" id="buyer_name" >
    
    
    </div>
    
    
       </ItemTemplate>
    </asp:TemplateField  >
   
  
       
    <asp:TemplateField HeaderText="Organization">
   <ItemTemplate>
  
    
  
     <div style=" font-size:small;float:left;   "  runat="server" id="org_title" >
    
    
    </div>
    
    
       </ItemTemplate>
    </asp:TemplateField  >
   
  
       
    <asp:TemplateField HeaderText="Status">
   <ItemTemplate>
  
     <div style=" font-size:small;   "  runat="server" id="bidcount" >
    
    
    </div>
    
   
    
    
      </div>
  </ItemTemplate>
     
       </asp:TemplateField>
     
     
      </Columns>
    
   
  </asp:GridView>
   
      </div>
      
  
      
      
      
      
          </div>
      
      
      
      
      <%-- 
      
      <div  style=" position:relative; margin-top:0px; background-color:White; margin-left:0px;">
  
    <div  style=" position:relative; margin-top:10px; margin-left:15px;">
    
    
     <%--<input  type="text" ID="txtTo" runat="server"  />  
  
    To<br /--%> 
 
  <%--  <input  type="text" ID="lblTo" runat="server"         />--%>
     
    
    <%-- <div style=" border:solid 3px #c0c0c0; ">
  
    <input  type="text"  ID="lblTitle" runat="server"  />
      </div>
     <b>Title</b><br /><br /> 
    
    <div style=" height:150px; width:200px; border:solid 3px #c0c0c0; ">
    <%--<textarea id="txtcomment"  cols="50" rows="30" runat="server"/>  
   --%> <%--<FCKeditorV2:FCKeditor ID="HTMLEmailEdit" runat="server" BasePath="~/FCKeditor/" Height="350px">
                            </FCKeditorV2:FCKeditor>
   
    </div>
     <b> Comment</b><br /><br />
    
    
    <div style="background-color:Green; border:grooved 2px white;"  >
     <input style="background-color:Green; border:grooved 2px white;"  type="submit"  onclick="javascript:return vld(this.form)" value="Post" ID="comment" name="comment"  runat="server"  /> </div>
     </div></div>--%>  
    </form>
    
    

<script  type="text/javascript">

    
    function sendnew( ) {
        var dvNew = document.getElementById('dvNew');
        dvNew.style.visibility = dvNew.style.visibility == 'visible' ? 'hidden' : 'visible';
    } 
           
           
           
           
    function  validateKeyPress(rowIndex,auid,title) {

       // alert('GEVALD');


        var tblPost = document.getElementById('tblPost');
       
        tblPost.style.visibility = 'visible';
    var  dvCatsGen=  document.getElementById('dvCatsGen');
 //   alert('dvCatsGen' + dvCatsGen);
    dvCatsGen.style.visibility = 'hidden';

    var hdnauid = document.getElementById('<%=hdnauid.ClientID%>');
  //  alert('hdnauid' + hdnauid);
  
    hdnauid.value = auid;

    var itemsearch = document.getElementById('itemsearch');

  //  alert('itemsearch' + itemsearch);
  
    itemsearch.value = title;
    
    
    
              

        closedvCatsGen()
        
        
        //keycode 37 isn't the up or down key, but you get the idea
        //also make sure that the logic here is browser compatible
        //        if (window.event.keyCode == 37) {
     // javascript:__doPostBack('grdvCatGeneral', rowIndex);
        //        }
    }

    











function load()	  
  	 	 
   {    // alert('lets');
//         	 var overlay =  document.getElementById("overlay") ; 
// var overlay_panel =  document.getElementById("overlay_panel") ; 
//overlay_panel.style.height="100px" ; overlay.style.visibility="visible" ;
//     overlay.style.zIndex=100;   overlay.style.opacity=0.8;    overlay.filters.alpha.opacity=80  ;  
      



//		var div = document.getElementsByTagName('div');//  mscDeployBanner
//		alert(div);
//		  var len = div.length;alert(len);
//		var   lastdiv = div[len-1];alert(lastdiv);
//		 lastdiv.style.display='none';
		 }



	function	 closedvCatsGen() {

	  var  dvCatsGen= document.getElementById('dvCatsGen');
	  dvCatsGen.style.visibility = 'hidden';
}


  	 function vld(form)	  
  	 	 
		  {
		 
		 
		  	var  msg = ''; 
 	   
for ( var gg=0;  gg  <=    form.getElementsByTagName("input").length-1 ; gg++  )
            {		  var input  =    form.getElementsByTagName("input").item(gg) ;
     
 	 
 
 
  	if ((input.value == '' || input.value == null)  && input.type!='hidden'  &&  input.name!='txtState'  &&  input.name!='txtCity'  )  
        	   {     msg  +=   input.name  +  ' was left blank   \n'      ;}
  var  rex = /<|>/g   ;



 
 var test = rex.test(input.value);
 if (test==true)   {     msg  += input.name  +  ' < > maynot be used \n'      ;}
  
   }
   
   if (msg!=''){alert(msg);}
                }

</script>

    
</body>
</html>

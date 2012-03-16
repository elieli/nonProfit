<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Galleryfrm.aspx.cs" Inherits="Galleryfrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html  xmlns="http://www.w3.org/1999/xhtml" style=" height:160px; width:600px;"  >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style=" height:160px; width:600px;"  >
    <%--<form id="form1" style=" height:160px; width:600px; margin-top:100px;  margin-left:100px; "  >
  <%--  <div>--%>
    
    
   
    
    
    <%--
    
    
    <table>
						
							<tr>
							  <td height="28">&nbsp;  <input name="fileLoad" runat="server"   size="50"    type="file" class="verdana11" id="fileLoad" /></td>
							  <td height="28">&nbsp;   
			--%>				
							
							
							 <%-- <asp:Button ID="Button3"     OnClientClick="javascript:showImage();"    runat="server"   Text="Upload Image" /> 
							--%>
							
			<%--				
							
							   <input ID="Button2"      onclick="javascript:showImage();"        value="Upload Image" /> 
</td><td>
		
					<%-- 
							   <asp:Button ID="Button1"  OnClientClick="javascript:GetRowValue();"    runat="server"    Text="Confirm Image" /> --%>
<%--</td>
							</tr>
 </table>
    
    
    
     
    <div style=" height:100px; width:100px">
    GEVALD
    <img id="img"   />
    </div>
    --%>
    
    
    
      <%-- <asp:LinkButton runat="Server" ID="btnSave" style="  visibility:hidden; " Text="Save" OnClick="OnSaveClick" />
    --%>
    
    <%--
           <div id="dvtest"> <div id="dvsavefile" runat="server"> </div> </div> 
    
    
    <div id="dvVideo">
   <%-- "<object width='525' height='844'>  <embed src='" + "images/"    "' type='application/x-shockwave-flash' width='525' height='844'></embed></object>
 
    </div>
    
    
    
    </div>--%>
<%--  </form>--%>
</body>
<script type="text/javascript" language="javascript">








    function showImage() {
        alert('    showImage.src  ');

         



        var fileLoads = document.getElementById('fileLoad').value;



        var dvVideo = document.getElementById('dvVideo');
       
        var newdiv = document.createElement('div');

        var flash = "<object width='525' height='844'>  <embed src='" + "~/images/" + fileLoads + "' type='application/x-shockwave-flash' width='525' height='844'></embed></object>";



        newdiv.innerHTML = flash;

        alert(newdiv);
        dvVideo.appendChild(newdiv);









        alert(dvVideo.InnerHTML);
        return;
        


     ///   var dvsavefile = unescape(document.getElementById('dvtest').innerHTML.substring(document.getElementById('dvtest').innerHTML.indexOf('>'), document.getElementById('dvtest').innerHTML.indexOf('</div>'))) ;



      ///  alert('  stop1' + unescape(dvsavefile)  );

        var images = unescape( '~/images/'+fileLoads);


        var img = document.getElementById('img');
        alert(img+'    img  ');


        img.src = unescape(images);

        alert(img.src + 'img.src');

        alert('  stop1');
        
        
        var imgTops = window.opener.document.getElementById('imgCenter'); //window.opener.document.forms[0].getElementById('imgCenter');
        imgTops.src = unescape(images);

 // messages.path = "Images/";

    

        alert(imgTops.src + 'imgTops.srcfinal');
       //// __doPostBack('btnSave' );
    }



















    function GetRowValue()
 {
    alert( '    imgTops.src  '  );

    // hardcoded value used to minimize the code.

    // ControlID can instead be passed as query string to the popup window
//    buttonLogo
//    window.opener.document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value = val;
    



    var fileLoads = document.getElementById('fileLoad').value;


    var dvsavefile = document.getElementById('dvtest').innerHTML.substring(document.getElementById('dvtest').innerHTML.indexOf('>'),document.getElementById('dvtest').innerHTML.indexOf('</div>')    )         ;

    var dvtest = document.getElementById('dvtest'); ///.innerHTML.substring(document.getElementById('dvtest').innerHTML.indexOf('>'), document.getElementById('dvtest').innerHTML.indexOf('</div>'));


    alert('  stop1' + dvsavefile + 'fileLoads' + fileLoads);

    var images = dvsavefile ;


  var img = document.getElementById('img');
  img.src = unescape(images);

  alert(img.src + 'img.src');
 
    alert( '  stop1');
    var imgTops = window.opener.document.getElementById('imgCenter'); //window.opener.document.forms[0].getElementById('imgCenter');

//    alert(fileLoads + '    imgTops.src  ' + imgTops);
//    //// forcePost(fileLoads.value);

    var dvFlashCenter = window.opener.document.getElementById('dvFlashCenter');
    dvFlashCenter = dvtest;
    alert(dvtest.innerHTML + "dvtest.innerHTML");
    alert(dvFlashCenter.innerHTML+"dvtest.innerHTML"); 
    
    alert(dvsavefile + '  stop2');


//    alert(fileLoads.value + '               ' + imgTops);
    imgTops.src = dvsavefile.unescapeHtml();
 ///   dvFlashCenter.innerHTML = unescape(dvsavefile);
    alert(imgTops.src+'  stop2');




  window.close();

}

String.prototype.unescapeHtml = function() {
    var temp = document.createElement("div");
    temp.innerHTML = this;
    var result = temp.childNodes[0].nodeValue;
    temp.removeChild(temp.firstChild);
    return result;
} 


</script>

 


</html>

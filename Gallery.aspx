<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html  xmlns="http://www.w3.org/1999/xhtml" style=" height:160px; width:600px;"  >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style=" height:160px; width:600px;"  >
    <form id="form1" style=" height:160px; width:600px; margin-top:100px;  margin-left:100px; "  method="post" action="Gallery.aspx" runat="server">
    <div>
    
    
    <input   type="hidden" runat="server"  id="test" value="tester" />
    
    
    
    
    
    
    
    
    <table>
						
							<tr>
							  <td height="28">&nbsp;  <input name="fileLoad" runat="server"   onchange="displayImage();"  size="50"    type="file" class="verdana11" id="fileLoad" /></td>
							  <td height="28">&nbsp;   
							
							
							
							 <%-- <asp:Button ID="Button3"     OnClientClick="javascript:showImage();"    runat="server"   Text="Upload Image" /> 
							--%>
							
							
							
							   <input ID="Button2"    type="submit"    onclick="javascript:showImage();"        value="Upload Image" /> 
</td><td>
		
					 
						<%--	   <asp:Button ID="Button1"  OnClientClick="javascript:GetRowValue();"    runat="server"    Text="Confirm Image" /> --%>
							</tr>
 </table>
    
    
    
     
    <div style=" height:100px; width:100px">
 
    <img id="img"   width="50"  />
    </div>
    
    
    
    
       <asp:LinkButton runat="Server" ID="btnSave" style="  visibility:hidden; " Text="Save" OnClick="OnSaveClick" />
    
    
    
           <div id="dvtest"> <div id="dvsavefile" runat="server"> </div> </div> 
    
    
    <div id="dvVideo">
   <%-- "<object width='525' height='844'>  <embed src='" + "images/"    "' type='application/x-shockwave-flash' width='525' height='844'></embed></object>
  --%>  
    </div>
    
    
    
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">






    function displayImage() {

        //alert('gevald');
        var search = document.location.search;

        var sar = search.split('&');

        var id = sar[1].split('=');
        var idd = sar[2].split('=');
        alert(id);

        var fileLoads = document.getElementById('fileLoad').value;



        if (sar[0] == '?type=flash') {
            var dvVideo = document.getElementById('dvVideo');

            var newdiv = document.createElement('div');

            var flash = "<object width='225' height='444'>  <embed src='" + "~'/images/" + fileLoads + "' type='application/x-shockwave-flash' width='225' height='444'></embed></object>";

            var images = "~/images/" + fileLoads;


            newdiv.innerHTML = flash;


            dvVideo.appendChild(newdiv);
            dvFlashCenter.appendChild(newdiv);


        }

        else {

            var images = unescape('<%=ResolveUrl("~/images")%>'  + '/'+ fileLoads);
//                            alert('images'+images);
            var img = document.getElementById('img');

            img.src = unescape(images);




        }
    }



    function showImage() {
        //alert('    showImage.src  ');


       var search  = document.location.search ;

       var sar = search.split('&');

       var id = sar[1].split('='); 
       var idd = sar[2].split('=');
       //alert(id);
//        var search = searcha.substring('type=', 'flash');

        var fileLoads = document.getElementById('fileLoad').value;

        var str1 = id[0] + "txt";
        //alert(search);
 
        if (sar[0] == '?type=flash')
{
        var dvVideo = document.getElementById('dvVideo');
       
        var newdiv = document.createElement('div');

        var flash = "<object width='225' height='444'>  <embed src= '~/images/'   + fileLoads +  ' type='application/x-shockwave-flash' width='225' height='444'></embed></object>";

        var images =  '<%=ResolveUrl("~/images/")%>'  + fileLoads;
      /// var dvFlashCenter = window.opener.document.getElementById('dvFlashCenter');


        var dvFlashCenter = window.opener.document.getElementById(id[1]);

        var flashCenter = window.opener.document.getElementById(idd[1]); //window.opener.document.forms[0].getElementById('imgCenter');

        //        
        //        imgCentertxt.innerHTML=images;

        ///  alert('  imgCentertxt.innerHTML  '+imgCentertxt.innerHTML);

        flashCenter.src = unescape(images);
     ///   dvFlashCentertxt.innerHTML=flash;
        
        
        newdiv.innerHTML = flash;

        ///alert(newdiv);
        ///alert(dvFlashCenter + '   dvFlashCenter');
        
        dvVideo.appendChild(newdiv);
           dvFlashCenter.appendChild(newdiv);
        
        
}

else{




 



       // alert(dvVideo.InnerHTML);
     
        


     ///   var dvsavefile = unescape(document.getElementById('dvtest').innerHTML.substring(document.getElementById('dvtest').innerHTML.indexOf('>'), document.getElementById('dvtest').innerHTML.indexOf('</div>'))) ;



      ///  alert('  stop1' + unescape(dvsavefile)  );

        var images = unescape( '~/images/'+fileLoads);


        var img = document.getElementById('img');
    


        img.src = unescape(images);
 

        //alert('  stop1');


        var imgTops = window.opener.document.getElementById(id[1]); //window.opener.document.forms[0].getElementById('imgCenter');
 
//        
//        imgCentertxt.innerHTML=images;

        ////alert('  iimgTops  ' + imgTops);
       
        imgTops.src = unescape(images);
        //alert('  imgTops.src   ' + imgTops.src);
 // messages.path = "Images/";

    

        //alert(imgTops.src + 'imgTops.srcfinal');
       //// __doPostBack('btnSave' );
    }



}
















    function GetRowValue()
 {
    //alert( '    imgTops.src  '  );

    // hardcoded value used to minimize the code.

    // ControlID can instead be passed as query string to the popup window
//    buttonLogo
//    window.opener.document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value = val;
    



    var fileLoads = document.getElementById('fileLoad').value;


    var dvsavefile = document.getElementById('dvtest').innerHTML.substring(document.getElementById('dvtest').innerHTML.indexOf('>'),document.getElementById('dvtest').innerHTML.indexOf('</div>')    )         ;

    var dvtest = document.getElementById('dvtest'); ///.innerHTML.substring(document.getElementById('dvtest').innerHTML.indexOf('>'), document.getElementById('dvtest').innerHTML.indexOf('</div>'));


    //alert('  stop1' + dvsavefile + 'fileLoads' + fileLoads);

    var images = dvsavefile ;


  var img = document.getElementById('img');
  img.src = unescape(images);

  //alert(img.src + 'img.src');
 
    //alert( '  stop1');
    var imgTops = window.opener.document.getElementById('imgCenter'); //window.opener.document.forms[0].getElementById('imgCenter');

//    alert(fileLoads + '    imgTops.src  ' + imgTops);
//    //// forcePost(fileLoads.value);

    var dvFlashCenter = window.opener.document.getElementById('dvFlashCenter');
    dvFlashCenter = dvtest;
    //alert(dvtest.innerHTML + "dvtest.innerHTML");
    //alert(dvFlashCenter.innerHTML+"dvtest.innerHTML"); 
    
    //alert(dvsavefile + '  stop2');


//    alert(fileLoads.value + '               ' + imgTops);
    imgTops.src = dvsavefile.unescapeHtml();
 ///   dvFlashCenter.innerHTML = unescape(dvsavefile);
    //alert(imgTops.src+'  stop2');




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

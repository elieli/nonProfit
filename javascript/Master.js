function showReport(id,n){
    var howManyOptions=n;
	for (i = 1; i <= howManyOptions; i++) {
		document.getElementById("info"+i).style.display=(i!=id)?"none":"block";
		var _currStyle = document.getElementById("tab"+i).style;
		_currStyle.color=(i!=id)?"#9c6":"#eee";
		_currStyle.backgroundColor=(i!=id)?"#eee":"#9c6";
		_currStyle.borderBottom=(i!=id)?"1px solid #5d7b9d":"1px solid #9c6";
	}
}

function showHide(ids,n){
  var patt=new RegExp("^on");
  var _ids=new Array();
  _ids=ids.split(",");
  for (i=0;i<_ids.length;i++){
    _id=document.getElementById(_ids[i]);
 	var clss=_id.attributes["class"].value;
    _id.style.display=(!patt.test(clss))?"block":"none";
    _id.attributes["class"].value=(patt.test(clss))?clss.substring(3):"on "+clss;
    if(n){
        var lbl=document.getElementById("lbl_"+_ids[i]);
        lbl.innerHTML=(lbl.innerHTML.match('Hide'))?lbl.innerHTML.replace(/Hide/,'Show'):lbl.innerHTML.replace(/Show/,'Hide');
        //alert(lbl.innerHTML)
    }
  }
}

// Form's validation
function valForm() {
   if (typeof Page_Validators != "undefined"){
    var msg = "";
//Registration	
if (location.pathname.match('Registration')) {
	var inputs=[];
	var textarea=[];
	inputs=document.getElementsByTagName("input");
	textarea=document.getElementsByTagName("textarea");
	var patt=new RegExp("^[a-zA-Z0-9_@\\s\.-\/,]{0,100}$");
	//var patt2=new RegExp("^[a-zA-Z0-9_@\\s\.-\/,\\:]{0,100}$");
	for(i=0;i<inputs.length;i++){
		var _val=inputs[i].attributes["type"].value;
		if((_val=="text")&&!patt.test(inputs[i].value)) msg+="text field ("+inputs[i].value+")\n";
		//if(_val=="file"&&!patt2.test(inputs[i].value)) msg+="text field ("+inputs[i].value+")\n";
	}
	for(i=0;i<textarea.length;i++){
		if(!patt.test(textarea[i].value)) msg+="textarea ("+textarea[i].value+")\n";
	}
	msg=(msg)?"Max Value Length 100 char!\n\tOR\nCheck for special chars in\n"+msg:"";
}
    for (i=0;i<Page_Validators.length;i++) {
        var chkD = Page_Validators[i].style.display;
        msg += (Page_Validators[i].innerHTML&&Page_Validators[i].style.display!="none"&&chkD.length)?Page_Validators[i].innerHTML+"\n" : "";
    }
    if (msg) {
       alert(msg);
       return false; }
    else
       return confirm('Do you want to \nSave the changes?');    
 }
}

function TabNav (id,last){
    var prvs=(id>1)?'<span class="TabNav" onclick="showReport('+(id-1)+','+last+')" title="Previous Tab">&laquo;&nbsp;Back</span>':'';
    //var pipe = (last||id==1)?'':'&nbsp;|&nbsp;';
    var nxt=(id<last)?'<span class="TabNav" onclick="showReport('+(id+1)+','+last+')" title="Next Tab">Next&nbsp;&raquo;</span>':'';
    document.write(prvs+nxt);
}

function content(id,d) {
	var content=(d<1)?id.parentNode.lastChild:id.parentNode.parentNode.lastChild;
	content.style.display=(d<1)?"block":"none";
}

/**Show and Hide Bar Content **/
                function setCookie(name,value,days) {
                    if (days) {
                        var date = new Date();
                        date.setTime(date.getTime()+(days*24*60*60*1000));
                        var expires = ";expires="+date.toGMTString();
                    } else {
                        expires = "";
                    }
                    document.cookie = name+"="+value+expires+";path=/";
                }
                function readCookie(name) {
                    var needle = name + "=";
                    var cookieArray = document.cookie.split(';');
                    for(var i=0;i <cookieArray.length;i++) { 
                        var pair = cookieArray[i];
                        while (pair.charAt(0)==' ') {
                            pair = pair.substring(1, pair.length);
                        }
                        if (pair.indexOf(needle) == 0) {
                            return pair.substring(needle.length, pair.length);
                        }
                   }
                   return null;
                }
                
                function showHideBox(d,e,names,w,h) {
				  	                //alert(h);
				  	                
                    var names = names.split(',');
                    var name=names[0];	
                    var name1=names[1];			  	                
		    var lyrName=document.getElementById(name);
                    var top = 0, left = 0; 
  	                if (!e) { e = window.event; } 
  	                var myTarget = e.currentTarget; 
  	                if (!myTarget) { 
   		                myTarget = e.srcElement; 
  	                } else if (myTarget == "undefined") { 
   		                myTarget = e.srcElement; 
  	                } 
  	                while(myTarget!= document.body) {
					 if (!myTarget.offsetTop) break;
                     top += myTarget.offsetTop; 
                     left += myTarget.offsetLeft; 
                     myTarget = myTarget.offsetParent; 
  	                } 
					
					
					if(h){
	   				    var bar=document.getElementById(name+"_bar").attributes["class"];
		    		    bar.value=(bar.value.match('none'))?bar.value.substring(5):"none "+bar.value;
						clssNone=bar.value;
					} else {
						h=0;
						clssNone="none";
					}
					
					if(d!="none"||!clssNone.match('none')){
						closeLayer(name);
						lyrName_style_display="none";
						if (name1) {
						    var Element = document.getElementById(name1)
						    if (Element)
						        Element.style.display = "none";
						}    
						setCookie(name1,"",-2)
					}else{
					 	openLayer(w,h,name);
						lyrName_style_display="block";
	                	lyrName.style.left=80+left+"px";
	                	lyrName.style.top=top+"px";
					}
					
	                //attd.style.display=(d<0)?:;	                
  	                var cV=lyrName.style.left+","+lyrName.style.top+","+lyrName_style_display;
                    setCookie(name,cV)
                }	
			
var c=0
var t
function openLayer(w,h,dd) {
  d1=document.getElementById(dd).style;
  d2=document.getElementById(dd+'_in').style;
  d2.overflow="hidden";
  d1.display=d2.display='block';
  if (c<w) {
	c=c+25;
	d1.width=d2.width=c+"px";
	d1.height=d2.height=c*(h/w)+"px";
	str="openLayer("+w+","+h+",'"+dd+"')";
	t=setTimeout(str,25);
  } else { 
	clearTimeout(t);
	d1.height=d2.height='auto';
  }
  //alert(d1.height)
}
function closeLayer(dd) {
  d1=document.getElementById(dd).style;
  d2=document.getElementById(dd+'_in').style;
  if (c>0) {
	c=c-25;
	d1.height=d2.height=c+"px";
	t=setTimeout("closeLayer('"+dd+"')",25);
  } else { 
	d1.display=d2.display='none';
	clearTimeout(t); 
  }
}
/** END Show and Hide Bar Content **/

function showReqFld(){   
   
   var MsgControl =parent.document.getElementById('spnStat')
   if (MsgControl)
      var pBlk = MsgControl.InnerHTML;    
      
    if(MsgControl) // pBlk.match("Edit")) 
    {
       // Do nothing if client validation is not active
      if (typeof Page_Validators != "undefined")         
      {
        for (i=0;i<Page_Validators.length;i++) {
            if(Page_Validators[i].innerHTML.match('Required'))Page_Validators[i].style.display="block";
        }    
      }
    }
    
    var Loading = parent.document.getElementById('loading');
    if (Loading)
        Loading.style.display="none";
}


var toggledDisplay = new Object();

function ToggleDisplay(bDisplayed)
{
  if(!document.getElementById || ToggleDisplay.arguments.length < 2) return;
  var displayed = new Object();
	  displayed['true'] = 'block';
	  displayed['false'] = 'none';
  for(var i = 1; i < ToggleDisplay.arguments.length; i++)
  {
	oDisplay = document.getElementById(ToggleDisplay.arguments[i]);
	if(oDisplay)
	{
	  oDisplay.style.display = displayed[bDisplayed];
	  // mozilla is the only browser out of the lot that can't get this right.  so, if we're
	  // setting an object's display style to block, we gotta reload any images contained
	  // within that block.  mozilla won't do it for you like every other browser that
	  // supports the functionality of changing the display style dynamically.
	  // begin crap browser hack
	  if(bDisplayed)
	  {
		oImages = oDisplay.getElementsByTagName('IMG');
		for(var j = 0; j < oImages.length; j++)
		  oImages[j].src = oImages[j].src;
	  }
	  // end mozilla, err, crap browser hack
	   if(typeof toggledDisplay[ToggleDisplay.arguments[i]] != 'undefined')
		toggledDisplay[ToggleDisplay.arguments[i]] = !bDisplayed;
	}
  }
}

function HideElement(what)
{
var x = document.getElementById(what);
if (x)  x.style.display = 'none' ;
 }
 
 function ShowElement(what)
{

var x = document.getElementById(what);
if (x) x.style.display ='block'; 
 } 
 
 //Sets a value of a textbox 
  function SetValue(what, ValueToSet)
{
    var x = document.getElementById(what);
    if (x) x.value = ValueToSet ; 
 } 
 
  //Checks if a value was selected in a listbox/dropdownlist
  function CheckSelected(what, msg)
{
	var x = document.getElementById(what);
	if (x) {		
		try
		{
	if (x.selectedIndex < 0) {
		  alert(msg);
		return false ;}	  
		else return true;   
   }
	catch(err)
  {
	 txt="There was an error on this page.\n\n";
	 txt+="Error description: " + err.description + "\n\n";
	 txt+="Click OK to continue.\n\n";
	 alert(txt);
  }
}
} 

function IsUserAnAdmin () {
var loWMIService = GetObject("Winmgmts:{impersonationlevel=impersonate}!//./root/cimv2");
var lcQuery = "Select * from Win32_Group Where LocalAccount = True and Name = 'Administrators'";
var loGroups = loWMIService.ExecQuery(lcQuery);
var llIsAdmin = false;
var loGropEnum = new Enumerator(loGroups);
for (; !loGropEnum.atEnd(); loGropEnum.moveNext()) 
{
	llIsAdmin = true;
}
if (llIsAdmin)
	//WScript.Echo("User is an Admin");
	alert("User is an Admin") ;
else	
	//WScript.Echo("User is NOT an Admin");
	alert("User is not an Admin") ;
return llsAdmin ;	
}
//-----------------------------------------------------------------------------
// Change DataType of absSpouse when gender changes
function changeDataType(ClientID)
 {
  var gender = document.getElementById(ClientID);
  if (gender) 
    { gender = gender.options[gender.selectedIndex].value; // M or F
      var type = (gender =='M')?"Mother":"Father";  
      var SpouseID = ClientID.replace(/GenInfoRegular_ddlGender/i,"asbSpouse")
      var Spouse = asbGetObj(SpouseID);
      if (Spouse)
          Spouse.msDataType = type;   
     }
  }
//------------------------------------------------------------------------------------------------
// Functions that used to call either InsertPerson or PeopleV to show (insert) parents information
function openCreateID(pid, UserControlName)
{
	var pid=document.getElementById(pid).firstChild.id;
	var _ids=new Array();
  	_ids=pid.split("_");
	var _id="";
  	for (i=0;i<_ids.length-1;i++)
  	{
		_id+=_ids[i]+"_";
	}
	_id=_id.substring(0,_id.length-1);
	
	var qNames=new Array("Address1","Address2","City","State","Zip","Email","ScreenName","HomePhone","CellPhone");
       
	var q="?ptype=N&perid=0&pid=" + pid;
	if (UserControlName!=undefined)	            
	   var Prefix = _id + "_" + UserControlName + "_txt";
	else
	   var Prefix = _id + "_" ;  
	
	for (i=0;i<qNames.length;i++) 
	{	    
	   q+="&" + qNames[i]+"=" + document.getElementById(Prefix+qNames[i]).value;
	}	
	    
	var url="InsertPerson.aspx"+encodeURI(q);
	var WinRef=window.open(url,'test','scrollbars=no,menubar=no,height=350,width=730,resizable=no,toolbar=no,location=no,status=no');
	
	WinRef.focus();
}

// Open form with the existing information
function openPeopleID(pid){
	var x=window.open('PeopleV.aspx?perid='+pid,'openPeopleID','scrollbars=yes,width=770,menubar=no,resizable=yes,toolbar=no,location=no,status=no');
	x.focus();
}

function insertContactInfo(ls,UserControlName) {
//ls = location.search
if (ls.match('pid=')) {
	var formID="PeopleNoneForm_"; // we need the full name here
	var ls=ls.substring(1,ls.length);
	var _q_ls=new Array();
	_q_ls=ls.split("&");
	//start from 3 because first three queries not from "Contact Info"
	for (i=3;i<_q_ls.length-1;i++){
		var _q=new Array();
		_q=_q_ls[i].split("=");
                if (UserControlName)
	                document.getElementById(formID+ UserControlName + "_txt"+_q[0]).value=decodeURI(_q[1]); 
                else 
			document.getElementById(formID+_q[0]).value=decodeURI(_q[1]);
	}
 }
}

//Input the IDs of the IFRAMES you wish to dynamically resize to match its content height:
//Separate each ID with a comma. Examples: [\"myframe1\", \"myframe2\"] or [\"myframe\"] or [] for none:
var iframeids=["myframe"]
//Should script hide iframe from browsers that don't support this script (non IE5+/NS6+ browsers. Recommended):
var iframehide="yes"
var getFFVersion=navigator.userAgent.substring(navigator.userAgent.indexOf("Firefox")).split("/")[1]
var FFextraHeight=parseFloat(getFFVersion)>=0.1? 16 : 0 //extra height in px to add to iframe in FireFox 1.0+ browsers
            
function resizeCaller() {
	var dyniframe=new Array()
	for (i=0; i<iframeids.length; i++){
		if (document.getElementById)
		resizeIframe(iframeids[i])
		//reveal iframe for lower end browsers? (see var above):
		if ((document.all || document.getElementById) && iframehide=="no"){
			var tempobj=document.all? document.all[iframeids[i]] : document.getElementById(iframeids[i])
			tempobj.style.display="block"
		}
	}
}
            
function resizeIframe(frameid){
	var currentfr=document.getElementById(frameid)
	if (currentfr && !window.opera){
		currentfr.style.display="block"
		if (currentfr.contentDocument && currentfr.contentDocument.body.offsetHeight) //ns6 syntax
			currentfr.height = currentfr.contentDocument.body.offsetHeight+FFextraHeight;
		else if (currentfr.Document && currentfr.Document.body.scrollHeight) //ie5+ syntax
			currentfr.height = currentfr.Document.body.scrollHeight;
		if (currentfr.addEventListener)
			currentfr.addEventListener("load", readjustIframe, false)
		else if (currentfr.attachEvent){
			currentfr.detachEvent("onload", readjustIframe) // Bug fix line
			currentfr.attachEvent("onload", readjustIframe)
		}
	}
}
            
function readjustIframe(loadevt) {
	var crossevt=(window.event)? event : loadevt
	var iframeroot=(crossevt.currentTarget)? crossevt.currentTarget : crossevt.srcElement
	if (iframeroot)
	resizeIframe(iframeroot.id);
}
            
function loadintoIframe(iframeid, url){
	if (document.getElementById)
	document.getElementById(iframeid).src=url
}
            
if (window.addEventListener)
window.addEventListener("load", resizeCaller, false)
else if (window.attachEvent)
window.attachEvent("onload", resizeCaller)
else
window.onload=resizeCaller

/** Preview Image **/
var maxSize=90240;
//var defaultPic="../images/id_card.gif";
var outImage="picresult";
var uploadImage=outImage+"myPic";
var fileTypes=["bmp","gif","png","jpg","jpeg"];
var _myPic;
var globalPic;
var _img;
function writeImage(pic) {
	  
var source=pic.value;
var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
for (var i=0; i<fileTypes.length; i++) if (fileTypes[i]==ext) break;
if (i<fileTypes.length) {
    var _ua=new Array();
    _ua=navigator.userAgent.split(" ");
    var _uaBrowser = _ua[(_ua.length-1)].split("/")[0];
	if(_uaBrowser.match("Firefox")){
	    _ver=_ua[(_ua.length-1)].split("/")[1].split(".")[0];
	    if(_ver<3) {
	        clearImage();
	        alert("You are using Firefox version "+_ver+".\nThis Feature is only available for Version 3 and higher")
	    } else {
  		    _myPic=pic.files.item(0);
            var data = _myPic.getAsDataURL();
		    _img = (_myPic.fileSize>maxSize)?tooBig(_myPic.fileSize):previewImage('data:' + data);	    
	    }
	} else {
		globalPic=new Image();
		globalPic.src=source;
		setTimeout("isSize()",500);
		_img = (globalPic.fileSize>maxSize)?tooBig(globalPic.fileSize):previewImage(globalPic.src);
	}	
  } else {
    clearFU();
    //document.getElementById(uploadImage).firstChild.value = "";
  	alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n"+fileTypes.join(", "));
  }	  

}
function isSize(){return;}
function clearFU() {
    var emptyFU = new Array();
    emptyFU=document.getElementById(uploadImage).innerHTML.split('value="');
    if(emptyFU.length>1){
        var emptyFUend = emptyFU[1].split('"')[1];
        document.getElementById(uploadImage).innerHTML=emptyFU[0]+" value=\"\" "+emptyFUend;
    } else {
        document.getElementById(uploadImage).firstChild.value = "";
    }
    return;
}
function tooBig (size) {
    clearFU();
	//document.getElementById(uploadImage).firstChild.value = "";
	alert("File is too large!\nPlease use no more than "+(maxSize/1024)+" kB.\n(File size: "+size+" bytes)");			
}
function previewImage (src){
//alert(document.getElementById(outImage).parentNode.firstChild.id)
	//document.getElementById(outImage).src = document.getElementById(outImage+'h').value = src; 
	document.getElementById(outImage).src = src; 
	document.getElementById(outImage).parentNode.style.display="block";
	//alert(document.getElementById(outImage).parentNode.firstChild.value);
	//document.getElementById(outImage).readOnly=true;
}
function clearImage(){
	//document.getElementById(outImage).src = document.getElementById(outImage+'h').value = "";
	clearFU();
	document.getElementById(outImage).src = "";  
	document.getElementById(outImage).parentNode.style.display="none";
	//document.getElementById(outImage).readOnly=true;
}




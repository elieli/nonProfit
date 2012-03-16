// Adds Persistance to script.aculo.us
  
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
         
       function getCookie(name) {
    var dc = document.cookie;
    var prefix = name + "=";
    var begin = dc.indexOf("; " + prefix);
    if (begin == -1) {
        begin = dc.indexOf(prefix);
        if (begin != 0) return null;
    } else {
        begin += 2;
    }
    var end = document.cookie.indexOf(";", begin);
    if (end == -1) {
        end = dc.length;
    }
    return unescape(dc.substring(begin + prefix.length, end));
}

function ToggleElem(Element)
{
    var El = $(Element);
    if(El.style.display != 'none')
    {
        setCookie(Element,'invisible');
        new Effect.toggle($(Element),'blind');
    }
    else
    {
        setCookie(Element,'visible');
        new Effect.toggle($(Element),'blind');
    }
}

function InitVisible(IDs)
{
   		boxIds = IDs.split(';');
   
  		for (i = 0; i <boxIds.length; i++) 
  		{
    		if (boxIds[i]) 
    		{
      			cookieValue = getCookie(boxIds[i]);
      			if (cookieValue != null && cookieValue.valueOf() == 'invisible') 
      			{        
        			Element.hide(boxIds[i]);        
      			}
      			else
      			{
        			Element.show(boxIds[i]);
      			}
    		}      
  		}    
}
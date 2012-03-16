<%@ Page Language="C#" AutoEventWireup="true" CodeFile="simpleTester.aspx.cs" Inherits="simpleTester" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
    <script type="text/javascript">
   window.onload= "javascript:GetCount()";



   location.querystring = (function() {

       // The return is a collection of key/value pairs
       alert('here');
       var queryStringDictionary = {};

       // Gets the query string, starts with '?'

       var querystring = unescape(location.search);

       // document.location.search is empty if no query string

       if (!querystring) {
           return {};
       }

       // Remove the '?' via substring(1)

       querystring = querystring.substring(1);

       // '&' seperates key/value pairs

       var pairs = querystring.split("&");

       // Load the key/values of the return collection

       for (var i = 0; i < pairs.length; i++) {
           var keyValuePair = pairs[i].split("=");
           queryStringDictionary[keyValuePair[0]] = keyValuePair[1];
       }

       // Return the key/value pairs concatenated

       queryStringDictionary.toString = function() {

           if (queryStringDictionary.length == 0) {
               return "";
           }

           var toString = "?";

           for (var key in queryStringDictionary) {
               toString += key + "=" + queryStringDictionary[key];
           }

           return toString;
       };

       // Return the key/value dictionary

       return queryStringDictionary;
   })();

      </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div onmouseover="javascript:GetCount();";>
    
    <input type="text" id="id" />
      <input type="text" id="name" />
      
    </div>
    </form>
    
    
    
    
    <script type="text/javascript">




        function GetCount()
        
         {
        
            alert(window.location.querystring.toString() + "  window.location.querystring");

            for (var key in location.querystring) {
                alert(key + "=" + location.querystring[key]);
            }

            var id = document.getElementById("id");
            var name = document.getElementById("name");



            alert(id + "="  + id.value + '         name =' + name.value ) ;
           
           
            
        }
</script>
    
    
</body>





</html>

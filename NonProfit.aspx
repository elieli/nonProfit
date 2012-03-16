<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="NonProfit.aspx.cs" Inherits="NonProfit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  >
    <title>Untitled Page</title>
    
    
    
    <script type="text/javascript">

        alert('STEP0');
        window.onload = function()
        {
            ajax({
        url: "XML/changeText", type: "xml" 
        });
    }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <input type="button" onclick='javascript: ajax({
        url: "XML/changeText", type: "xml" 
        });;'  value='CLICK' />
    
    
    </div>
    </form>









<script type="text/javascript" >

        function ajax(options) {


            options = {

                type: options.type || "POST",
                url: options.url || "",
                timeout: options.timeout || 5000,
                data: options.data || ""
            };


            alert('step1');
            var xml = new XMLHttpRequest();


            xml.open(options.type, options.url, true);

            alert('step2');
            xml.onreadystatechange = function() {
                if (xml.readyState == 4) {
                    alert('step3');
                    if (httpS(xml)) { httpData(xml, options.type); alert('step4'); }

                }


            }
            alert('step5');

        xml.send;

        alert('step6');
        







        function httpData(r, type) {





            var ct = r.getResponseHeader("content-type");


            var data = !type && ct && ct.indexOf("xml") >= 0;

            data = type == "xml" || data ? r.responseXML : r.responseText;



            return data;



        }





        function httpS(r) {


            try {

                return !r.status && location.protocol == "file:" || r.status >= 200 && r.status < 300 || r.status == 304;

            } catch (e) { }

            return false;



        }
            
            
            
            }
            
            
                     
            </script>
           
            
         


 

 


 



</body>




</html>

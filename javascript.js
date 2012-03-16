
 
  	 function vld(form)	  
  	 	 
		  {	var  msg = ''; 
 	   
 	  
 	  	 var donate =  document.getElementById("donate") ;
  	 
 	  
		  	 if (donate.value=='Download Song') return ;
	
		  
			for ( var  i=0;  i  <=    form.getElementsByTagName("select").length-1 ; i++  )
	{	 var slct  =   form.getElementsByTagName("select").item(i) ;	  
         	if ((slct.value == '' || slct.value == null )   )  
        	   {     msg  +=   slct.name  +  ' was left blank   \n'      ;}
     		}
		 	  
	    	for ( var gg=0;  gg  <=    form.getElementsByTagName("input").length-1 ; gg++  )
            {		  var input  =    form.getElementsByTagName("input").item(gg) ;
     
 	 
 
 
  	if ((input.value == '' || input.value == null)  && input.type!='hidden'   )  
        	   {     msg  +=   input.name  +  ' was left blank   \n'      ;}

   
   
   

if (input.name=='email'         && input.value!=''  )
 {var  rex = /\w+@+\w+\.+/  ;
 var test = rex.test(input.value);
 if (test==false)   {     msg  +=    'invalid email address  \n'      ;}
  
                }



if (input.name=='expdate' && input.value!=''   )
 {var  rex = /^(0[1-9]|1[012])[- /.]((21|20)\d\d|([0-9]9|[1-9][0-9]))$/  ;
 var test = rex.test(input.value);
 if (test==false)   {     msg  +=   'invalid exp. date, please use this format: mm/yy    \n'      ;}
  
                }



if (input.name=='phone'       && input.value!=''  )
 {var  rex = /[1-9]\d{2,2}[- .]\d{3,3}[- .]\d{4,4}/   ;
 var test = rex.test(input.value);
 if (test==false)   {     msg  +=  'invalid phone number, please use this format: 999 999 9999    \n'      ;}
  
                }

                

if (input.name=='cvv'        && input.value!=''  )
 {var  rex = /^\d{3,4}$/   ;
 var test = rex.test(input.value);
 if (test==false)   {     msg  +=    'invalid CVV number  \n'      ;}
  
                }



           

if (input.name=='cardnumber'        && input.value!=''  )
 {

//var  rex = /\d{14,23}/   ;
 //var test = rex.test(input.value);
 if (Mod10(input.value)==false)   {     msg  +=  'invalid card number, please remove any spaces and try again  \n'      ;}
  
                }














                }
                
                 
		 	 if (msg != ''  && msg!=null) 
		 	  {   alert(msg);  return false;           } 
			 	     else
		 	      {		 	   
		 	      
		 	      
		 	      // prc()	;
		 	      
		 	        return true;
		 	      
		 	     
		 	   } 	
		 	   
		 	    
		 	   		 }  
		 	   		 
		 	   	 
		 	   		 
		 	   		 
		 	   		 
		 	   		 
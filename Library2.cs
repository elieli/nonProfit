 
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web.SessionState;
using  System.Xml;
using System.Data.SqlClient;
using  System.Xml.Serialization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class downloads_Library2  
{


    const String most_populars = "Most Popular";


    const String most_talked_abouts = "Most Talked About";
    const String today_on_downloads = "Featured Downloads";
    const String supported_formats = "Supported formats :";
    const String choose_file = "Choose Your File To Upload :";
    const String all_popular_downloads = "All popular downloads";
    const String advansed_search = "<img src=\"img/ight_arrow.gif\" alt=\"Advanced Search\" width=\"25\" height=\"25\" border=\"0\" />";
    const String Search_txt = "Search";
    const String News_txt = "News";
    const String All_News = "All news...";

    const String Just_In = "Just In";
    const String all_Just_In = "All just in...";
    const String Subscribe_txt = "Subscribe";
    const String more_downloads = "MORE DOWNLOADS";
    const String User_Opinions_txt = "User Opinions";
    const String All_User_Opinions_txt = "All User Opinions";
    const String Average_User_Rating_txt = "Average User Rating";
    const String You_rate = "Rate this topic";
    const String Opinions_txt = "Opinions";
    const String keywords_txt = "Key Words";

    const String ok_txt = "&nbsp;<img src=\"downloads/img/ok.gif\"  alt=\"Enabled\" border=\"0\"  align=\"baseline\" /> &nbsp;";
    const String Recommended_txt = "&nbsp;<img src=\"downloads/img/refresh.gif\" alt=\"Recommended\"  border=\"0\"  align=\"baseline\"/>&nbsp;";
    const String bigfurture_txt = "&nbsp;<img src=\"downloads/img/furture.gif\" alt=\"Featured\"  border=\"0\" align=\"baseline\"/>&nbsp;";
    const String Smallfurture_txt = "&nbsp;<img src=\"downloads/img/txt.gif\" alt=\"Small featured\"   border=\"0\" align=\"baseline\"/>&nbsp;";
    const String Deletefile_txt = "&nbsp;<img src=\"downloads/img/delete.gif\"  alt=\"delete file\"  border=\"0\" align=\"baseline\"/>&nbsp;";

    const String All_Recommended_txt = "All recommended";
    const String New_releases_txt = "Newest releases";
    const String navbar_arrow = "<img src=\"main/img/arrow_path.gif\"  alt=\"alt\"  width=\"12\" height=\"6\"   border=\"0\" />";
    const String Register_txt = "Register new user";
    const String search_title_txt = "Search results";
    const String search_find_txt = "Search yielded";
    const String search_notfind_txt = "<b>Suggestions:<br/>Check your spelling.<br/>Try different or fewer keywords.<br/><\b>";


    const String user_name_alert = "Enter user name please.";
    const String comments_alert = "Enter your comments please.";
    const String filename_alert = "Enter file name please.";
    const String description_alert = "Enter description for file please. ";
    const String upload_file_alert = "Upload file please.";
    const String upload_file_format_alert = "You choose file with unsupported format.\n Please select file with supported format.";


    const String vote_confirm = "Thanks for your vote !!!";
    const String Register_confirm = "You is registered. Congratulate!!!";
    const String Register_not_denied = "User with this name is present. Enter another name...";
    const String error_login_txt = "Your login or password is incorrect. Or your account is not activated.";


    const String header_image = "img\bg1.gif";
    const String header_bg = "#e6e6e6";
    const String header_bg_lines = "#72932f";


    const String date_added = "Date";
    const String user_name_txt = "Author";
    const String file_name = "Name";
    const String user_rating = "Rating";
    const String size_txt = "#Files";
    const String downloads_txt = "Downloads";
    const String Availability_txt = "Availability";
    const String description_txt = "Description";
    const String Format_file = "Format";
    const String added_by = "Added by";
    const String vote_table_txt = "Vote categories";
    const String user_set_rating = "User rating";
    const String Reviews_txt = "Reviews";
    const String Image_txt = "Image";
 

  

SqlConnection MyConnection  ;
SqlDataAdapter MyCommand  ;
SqlDataAdapter MyCommand1 ;
DataSet ds  ;
DataSet ds0 ;
DataSet ds1 ;
DataSet ds2 ;
DataSet ds3 ;
DataSet ds4 ;
String temps;
int Page;
String Sort;
int i,j;
String endlist,beginlist;

const String PageTitle = " Shluchim Office "; 



    public    String  generateMenu1(String string_)
    {
	XmlDocument doc = new  XmlDocument();
	 XmlNodeList   nodelist ;//= XmlNodeList;
	   XmlNode       node ;// = XmlNode;
       XmlNode  root1;
        int i, id;
            XmlAttributeCollection attrColl;// = XmlAttributeCollection;
			String   imgname, imgw, imgh, over_img;
			string_ = "";
	       doc.Load(Path.GetFullPath("/xml/tree.xml"));
			root1 = doc.DocumentElement;
			for (i = 0 ;  i<=  root1.ChildNodes.Count - 1 ; i++) {
			 attrColl = root1.ChildNodes.Item(i).Attributes;
             id = Convert.ToInt32(attrColl.GetNamedItem("id").Value);
			   if (id!=600)  {// then
			     try{
				   imgname = Convert.ToString( attrColl.GetNamedItem("text").Value) ;
				   imgw =  Convert.ToString(attrColl.GetNamedItem("imgw").Value);
                   imgh = Convert.ToString(attrColl.GetNamedItem("imgh").Value);
                   string_ = string_ + "<td nowrap width=\"1/%\"  valign=\"middle\">";
			       string_ = string_ + "<div id=\"anchor_\" + id  +  \"\"  class=\"anchor_div\"></div>";
					   string_ = string_ + "<a onmouseout=\"hide_menu();MM_swapImgRestore(); \" onmouseover=\"hide_menus();show_menu('m_" + id + "','anchor_" + id + "'); \"\" href=\"/main/inside.asp?id=\"  + id + \"\" class=\"menuTop>\" + imgname + \"\" </a></td>";
				   if((i!=root1.ChildNodes.Count - 1) &&  (  imgname!="Catalog") ) { //then
					   string_ = string_ + "<td width=\"1%\" valign=\"middle\"><font color=\"#CCCCCC\">&nbsp;&nbsp;|&nbsp;&nbsp;</font></td>";
                   } } // end if
				 catch{}
               //end try  
}//  end if
    }//	next
    return  string_;
           }//end public String

    public String  generateMenu2(String string_1)     {
		XmlDocument  doc  =  new  XmlDocument();
	 ///  XmlNodeList    nodelist  =  new XmlNodeList();
	      XmlNode  node ;//= XmlNode;

          XmlNode root1;
          Int32 i, j, id;
          XmlNode      childs ;
        String str;
	XmlAttributeCollection attrColl ;//As XmlAttributeCollection
		XmlAttributeCollection  attrColl2 ;//As XmlAttributeCollection
			String string_, imgname, imgw, imgh;
			string_ = "";
			string_1 = "";
            int k   ;
			k = 0;
	        doc.Load(Path.GetFullPath("/xml/tree.xml"));
			root1 = doc.DocumentElement;
		 for (i = 0;  i<=root1.ChildNodes.Count - 1; i++   ) {
			 attrColl = root1.ChildNodes.Item(i).Attributes;
			   id = Convert.ToInt32(attrColl.GetNamedItem("id").Value);
			   if(id!=600 )   { 
				 str = "(\\element)[@id=" + id +  "]";
					childs = doc.DocumentElement.SelectSingleNode(str);
					for (j = 0; j <=  childs.ChildNodes.Count - 1 ; j++ )         {
					  attrColl2 = childs.ChildNodes.Item(j).Attributes;
					  try{
					    if (attrColl2.GetNamedItem("visible").Value!="false" ) {
                            string_ = string_ + "<tr onmouseout=\"hide_menu();MM_swapImgRestore(); \" onmouseover=\"show_menu('m_" + id + "','anchor_" + id + "') \"><td><a href=\"#\" class=\"submenu\"><img src=\"img/spacer.gif\" width=\"3\" height=\"17\" border=\"0\" alt=\"\"  ><\a><\td><td nowrap><a class=\"submenu\"  href=\"/main/inside.asp?id=/" + Convert.ToString(attrColl2.GetNamedItem("id").Value) + ">" + Convert.ToString(attrColl2.GetNamedItem("text").Value) + "<\a><\td><td align=\"right\"><a href=\"#\"><img src=\"img/spacer.gif/\" width=\"3\" height=\"17\" border=\"0\" alt=\"\">      <\a><\td><\tr>";
						  k=k+1;
						} 
                      }
					  catch{}
					  // end try
               } // next j
               } // end if
			   string_ = "<div id=\"m_\" + id + \"\"     class=\"menu\" style=\"top:130px; visibility: hidden; position: absolute; z-index:99;  \"> <table cellpadding=\"2\" cellspacing=\"0\" border=\"0\" bgcolor=\"#006699\"><tr><td><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#5580AA\">" +  string_; 
			   string_ = string_ + "</table></td></tr></table></div>";
               
			   if (k==0)  { // then
			      string_ = "<div id=\"m_\" + id + \"\"  style=\"visibility: hidden; position: absolute; z-index:99;\"></div>";
               } //  end if
               k=0;
			   string_1 = string_1 + string_;
			   string_ = "";
    } //next i
	       return string_1;
                      } //end public String
	 

  public String  generateMenu3( String string_) {
    	 XmlDocument doc  = new XmlDocument() ; //=   XmlDocument();
	     XmlNodeList nodelist ;//=XmlNodeList;
	      XmlNode      node ; //= XmlNode;
          XmlNode root1;
          		String        j, id, childs, str;
	    XmlAttributeCollection attrColl ; //= XmlAttributeCollection;
	    XmlAttributeCollection attrColl2 ; //= XmlAttributeCollection;
		String  string_1, imgname, imgw, imgh;
			string_ = "";
			string_1 = "";
			
	        doc.Load( Path.GetFullPath("/xml/")+"tree.xml");
			root1 = doc.DocumentElement;
			for (int i = 0;  i<=  root1.ChildNodes.Count - 1 ;  i ++ ) {
			 attrColl = root1.ChildNodes.Item(i).Attributes;
			   id = Convert.ToString(attrColl.GetNamedItem("id").Value);
			   string_ = "names[names.length] = 'm_'" +id + "';" + string_ ;
               } //next i
               return  string_;
           }
    //end public String

	 
	 
     public static int GelListOfFormatsFiles(int id   , String   rtrn_str) 
     { 
	     String return_string;
		// String  MyConnection_, MyCommand_, DS2_, ii;
         int ii=0;
		 return_string = "";
         SqlConnection MyConnection_ =new  SqlConnection( getpath());
         SqlDataAdapter MyCommand_ = new SqlDataAdapter("select formcomment, ower from tblfilespath left join tblformats on tblfilespath.idformat=tblformats.idformat where tblfilespath.idf="+(Convert.ToString(id))+" group by formcomment, ower", MyConnection_);
	DataSet	 Ds2_  =new DataSet() ;
		 MyCommand_.Fill(Ds2_, "listformats");
		 if (Ds2_.Tables["listformats"].Rows.Count!=0) { // then
		    for (ii=0 ; ii<= Ds2_.Tables["listformats"].Rows.Count-1; ii++) {
            ////////        string path = System.Web.HttpContext.Current.Request.ApplicationPath + imagePath;
            ////////path = System.Web.HttpContext.Current.Request.MapPath(path);

                if (File.Exists(System.Web.HttpContext.Current.Request.MapPath("/downloads/img" + "/" + Ds2_.Tables["listformats"].Rows[ii]["formcomment"] + ".gif")))
                { //then
				  return_string = return_string + "<img alt=\"\" + Ds2_.Tables('listformats').Rows[ii).Item('ower') + \"\" src=\"downloads/img\" + Ds2_.Tables('listformats').Rows[ii).Item('formcomment') + \".gif>\" + \"/>"  +  " </br> "  ;
				} else{
				  return_string = return_string + "." + Ds2_.Tables["listformats"].Rows[ii]["formcomment"];
				} //end if
                }//next
                }//end if
		 Ds2_.Clear();
		 return_string = "<center>" + return_string +  "<" + "\" +  'center>'"  ;
         return ii;// return_string;
         }// end public String


     public  String funarrows_grid(String sortorder, String  string_)   {
	     String prefix; 
	     if (sortorder.IndexOf("desc",0) ==0 )   { //then
		    
             prefix = "<img hspace=\"2\" vspace=\"1\" align=\"texttop\" src=\"img/arrdown.gif\" alt=\"\" width=\"12\" height=\"12\" border=\"0\">";
         }	 else{ 
		      prefix = "<img hspace=\"2\" vspace=\"1\" align=\"texttop\" src=\"img/arrup.gif\" alt=\"\" width=\"12\" height=\"12\" border=\"0\">";
     
          } // end if
		 sortorder =    (sortorder.Trim() );
		 sortorder =   (sortorder.Substring(0, sortorder.IndexOf(" ",0))) ;
	     if (sortorder=="originates" &&  string_=="Originates") { // then
	  return prefix;
		 }//end if
         if (sortorder == "dt" && string_ == "Date")
         { // then
		  return prefix;
		 }//nd if
	     if (sortorder=="download" &&  string_==downloads_txt) { // then
	  return prefix;
         }// end if
	     if     (sortorder=="fabout" && string_==file_name)   { // then
	    return prefix;
		 }//end if
	     if (sortorder=="quantity" && string_==size_txt) { // then
		   // return prefix;
		 } //end if
	     if (sortorder=="total" &&  string_==user_rating)  {// then
		    return prefix;
         }// end if
         return prefix;
     }// end public String

	 public String SendMailfunction( String  send_strings, String message_, String message_2){
         
                     ////myMail = Server.CreateObject("CDONTS.NewMail");
                     ////myMail.BodyFormat = 0;
                     ////myMail.MailFormat = 0;
                     ////myMail.From = "eschusterman@shluchim.org";
                     ////myMail.To = "eschusterman@shluchim.org";
                     ////myMail.Bcc = "manager@d3dm.com;shluchim@d3dm.com";
                     ////myMail.Subject = message_;
                     ////myMail.Body = message_2 + "<br/><br/><br/>" +  send_strings;



           System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
                   
                    System.Net.Mail.MailMessage MMessage = new System.Net.Mail.MailMessage(
                 "eschusterman@shluchim.org", "eschusterman@shluchim.org",  message_,  message_2 + "<br/><br/><br/>" +  send_strings);
                    return "";
                }// end public String

  

//////////      public void ReturnFromLogining()  { 	 Response.Write(Convert.ToString(Request["pagesreturn"])   );
//////////                    //	  select case Request["pathreturn")
//////////switch (Request["pathreturn"]) {
//////////                              case "main":
//////////                                 if (Request["id"]!="" ) { //then
//////////                                 Response.Write("/main/inside.asp?id=" +  Convert.ToString(Request["id"])   ) ;
//////////                                 break;
//////////                             }
//////////                             else
//////////                             {
//////////                                 Response.Write("/main/default.asp");
//////////                                 break;
//////////      } //end if
//////////                              case "forum":
//////////                                  Response.Write(Request["pagesreturn"]+"?TopicID="+Request["TopicID"]+"&ForumID="+Request["ForumID"]+"+catid="+Request["catid"]);
//////////                                  break;
    
//////////    case "downloads":
//////////                                  Response.Write(Request["pagesreturn"]+"?idc="+Request["idc"]+"+idf="+Request["idf"]+"+modde="+Request["modde"]+"+stxt="+ Request["stxt"]);

//////////                                  break;
//////////    default:
//////////        Response.Write("\registration\register.aspx"); break;
//////////      }//		  end select
//////////      } //end public String
     



      public String ReturnFromLogining_function(String zzz){
	                   						 // return Convert.ToString(Request["pagesreturn"));
		//				  select case Request["pathreturn")
	
          
          
        ////////  switch(Convert.ToString(Request["pathreturn"]) ) {	
        ////////    case "main":
        ////////                         if (Request["id"]!="") { //then
        ////////                          zzz = ("/main/inside.asp?id="+ Convert.ToString(Request["id"]));
        ////////} else{
        ////////                          zzz = ("/main/default.asp");
        ////////}//					 end if
        ////////    case "forum":
        ////////                          zzz = (Request["pagesreturn"]+"?TopicID=" + Request["TopicID"]+ "ForumID=" +Request["ForumID"] +"catid="+Request["catid"]);
        ////////    case "downloads":
        ////////                          zzz = (Request["pagesreturn"]+"?idc=" + Request["idc"]+"+idf="+Request["idf"]+"modde="+Request["modde"]+"stxt="+ Request["stxt"]);
        ////////            default:   
        ////////                          zzz = ("/registration/register.aspx");
        ////////} //		  end select
          return zzz			  ;
	  }//End public String



      public String approveding (String idf, Boolean flag){
          SqlConnection MyConnection = new SqlConnection(Path.GetFullPath(getpath()))  ;
          SqlDataAdapter MyCommand =new SqlDataAdapter("select * from tblFilesPath where idf=" + Convert.ToString(idf), MyConnection);
          DataSet Ds4 = new DataSet();
	           MyCommand.Fill(Ds4, "tblFilesPath");
			String fname,fname1;
			String fname2, fname3;
          Boolean temps;
			   bool sts=false;
			   for (int p=0 ;  p<= Ds4.Tables["tblFilesPath"].Rows.Count-1; p++) {
			       fname= Path.GetFullPath("pending\files") +  "/" + Convert.ToString(Ds4.Tables["tblFilesPath"].Rows[p]["diskname"]).Replace("admin/","");
			       fname1=Path.GetFullPath("approved\files") +  "/" + Convert.ToString(Ds4.Tables["tblFilesPath"].Rows[p]["diskname"]).Replace("admin/","");
				   if (flag==false )  { //then
					   temps = movedTo(fname,fname1);}
				   else{
					   temps = DeleteFile(fname  );
} //end if
} //next p
			   Ds4.Clear() ;
     	       MyCommand = new  System.Data.SqlClient.SqlDataAdapter(SqlStringFiles("FilesByIDF","",idf,""), MyConnection);
	           Ds4 = new   DataSet();
	           MyCommand.Fill(Ds4, "tblFilesPath");
		       fname=      Path.GetFullPath("pending/img") + "/" +     Convert.ToString(Ds4.Tables["tblFilesPath"].Rows[0]["imagename"]).Replace("admin/","")  ;
		       fname1= Path.GetFullPath("approved/img") +"/" +   Convert.ToString(Ds4.Tables["tblFilesPath"].Rows[0]["imagename"]).Replace("admin/","");
			       fname2= Path.GetFullPath("pending/img") + "/s" + Convert.ToString(Ds4.Tables["tblFilesPath"].Rows[0]["imagename"]).Replace("admin/","");
			       fname3=Path.GetFullPath("approved/img") + "/s" +Convert.ToString(Ds4.Tables["tblFilesPath"].Rows[0]["imagename"]).Replace("admin/","");
				   if (flag==false ) { // then
					   temps = movedTo(fname,fname1);
					   temps = movedTo(fname2,fname3);
                   }   else{
					   temps = DeleteFile(fname);
					   temps = DeleteFile(fname2);
					   
                   }//  end if
			   Ds4.Clear();
               return "";
           }//  end public String



//////////public String Getdate1() {
//////////  String wd_name, daynow, monthnow, yearnow;
//////////    wd_name = WeekdayName(Weekday(now));
//////////    daynow = day(now);
//////////    monthnow = monthname(month(now));
//////////    yearnow = year(now);
//////////    return wd_name+", "+monthnow+" "+daynow+", "+yearnow;
//////////}//end public String

////////public  String GetHDate(String sep)
////////{ if (Session["hebrewdate"]!="")  { // then
     
////////       return Convert.ToString( Session["hebrewdate"]) ;
////////} 	else  {
////////      try{
////////    ////Object objHTTP;
////////    ////    objHTTP =    CreateObject("MSXML2.XMLHTTP") ;

////////        System.Type oType = System.Type.GetTypeFromProgID("MSXML2.XMLHTTP");
////////        Object objHTTP = System.Activator.CreateInstance(oType);
 
////////        String wd_name, daynow, monthnow, yearnow, mymatches,hebrewdate,strPOStdata,resulttext ;
////////        daynow = Convert.ToString(DateTime.Now.Day);
////////        monthnow = Convert.ToString(DateTime.Now.Month);
////////        yearnow = Convert.ToString(DateTime.Now.Year);
////////        daynow = "http:\\www.hebcal.com/converter/?gd="+daynow+"&gm="+monthnow+"&gy="+yearnow;
////////        //////////objHTTP.open ("GET", daynow , False);
////////        //////////objHTTP.setRequestheader ("Content-Type", "text/xml");
////////        //////////objHTTP.send( server.URLEncode(strPOStdata) ) ;
////////        //////////    if( objHTTP.status=200) { // Then 
////////        //////////        resulttext = objHTTP.ResponseText;
////////        //////////        resulttext =  resulttext.Replace(resulttext.Substring(0,resulttext.IndexOf("<b>",0))+2),"");
////////        //////////        resulttext = left(resulttext,instr(resulttext,"<\b>")-1);
////////        //////////        Session["hebrewdate"] = Convert.ToString(resulttext);
////////        //////////        } //end if
////////        //////////return resulttext;
////////      }
////////      catch (  Exception Exp) {} 
////////           Session["hebrewdate"] = "";
//////// // End try
////////           return "";
////////       }//end if
////////} //end public String
	  
   public static  String   getpath( )  {
	    return "server=shof.d3dm.com;uid=shluchim;pwd=050504;database=shof_downloads;";
   } //end public String
   
   public String getpathForum() {
	     return "server=(local);uid=shluchim;pwd=050504;database=forum;";
   }//end public String

   public String  getpathtologin(){
      return "server=(local);uid=haim770;pwd=bz43kolih;database=clil;";
   }//end public String

      public Boolean  movedTo(String fname, String fname1){
   		FileInfo fi =  new  FileInfo(fname);
   		FileInfo fo =       new FileInfo (fname1) ;
				   if (fi.Exists) { // Then
				      if ( fo.Exists) {//Then
					     DeleteFile(fname1);
                      }// end if
					  fi.MoveTo(fname1);
				   }//end if
				   return true;
	  }//end public String

      public bool  FileExist(String fname){
          FileInfo fi = new FileInfo(fname);
				   if (fi.Exists)  {// Then
				      return true;
                   }//  end if
				   return false;
	  } //end public String
	  
      public Boolean  DeleteFile(String fname){
   			FileInfo fi = new   FileInfo(fname);
				   if (fi.Exists) {// Then
					  fi.Delete();
                     return true;
      }//  end if
				   return false ;
	  }// end public String

   public String   sizer(Int32 size, ref String str){
  //	String str;
	  if (size<1000) { //hen
	     str = Convert.ToString(size/1000)+" kb" ;
	  }//end if
	  if (size>1000 &&  size<1000000) { // then
 
          str = Convert.ToString(size/1000)+" kb" ;
	  }//end if
	  if (size>1000000) { // then
          str = Convert.ToString((size/100000) / 10 )+ " Mb";
	  }//end if
      return str;
      }//d public String
   public String  getRequest(int a) {
     if  (Convert.ToString(a) ==""){// then
		  return "0";
     } else{
		  return Convert.ToString(a) ;
     }//end if 
     }//end public String


   public String  getRequestString(int a){
     if (Convert.ToString(a) =="" )  { //then
		  return "";
} else
{
    return Convert.ToString(a);
}//    end if 
   }// end public String
   
   public String CountFiles( int value_,  String string_){
       switch (value_) {
           case 0:
	    return "<span class=\"whitetext\"><font face=georgia>"+string_+"</font></span>&nbsp;&nbsp;&nbsp;";
           case 1:
	    return "<span class=\"whitetext\"><font face=georgia>"+"1 file found"+"</font></span>&nbsp;&nbsp;&nbsp;";
       } //end select  	
	    return "<span class=\"whitetext\"><font face=georgia>"+" "+value_+" files found"+"</font></span>&nbsp;&nbsp;&nbsp;";
   } //end public String

   public String  CountText(int   value_,    String        string_,    String       string2_){
       switch (value_) {
           case 0:
	    return "<span class=\"redNote\">"+string_+"</span>&nbsp;&nbsp;&nbsp;";
           case 1:
	    return "<span class=\"redNote\">"+"1 "+string2_+" found."+"</span>&nbsp;&nbsp;&nbsp;";
       }//end select  	
	    return "<span class=\"redNote\">"+" "+value_+" " +string2_+ " found."+"</span>&nbsp;&nbsp;&nbsp;";
   }// end public String

   public String  CountOpinions(  int         value_,     String        string_) {
     switch (value_) {
        //select value_
         case 0:
	    return "<span class=\"whitetext\">"+string_+"</span>&nbsp;&nbsp;&nbsp;";
         case 1:
	    return "<span class=\"whitetext\">"+"1 opinion found."+"</span>&nbsp;&nbsp;&nbsp;";
}  // end select  	
	    return "<span class=\"whitetext\">"+""+value_+" opinions found."+"</span>&nbsp;&nbsp;&nbsp;";
}   // end public String
   


   public String  arRows(int page,int  count,  int        path) { 
     if ((path==1) &&   ( (page==1)  || ( page==0)) )   { // then
		  ////return "<a class=\"whitetext\" href=\"javascript:\"><img src=\"downloads\arrowBegin.gif\" border=0 align=\"middle\" alt=\"Go to beginning\"><\a>" + "&nbsp;<a href=\"javascript:\"><img src=\"downloads/arrowPrev.gif/\" border=0 align=\"middle\" alt=/"/" Previous page/"/" ><\a>&nbsp;"	;
}   else {
		  return "<a class=\"whitetext\" href=\"javascript:Go_(1)\"><img src=\"/downloads/arrowBegin.gif\" border=0 align=\"middle\" alt=\"Go to beginning\"><\a>" + "&nbsp;<a class=\"whitetext\" href=\"javascript:Go_(2)\"><img src=\"/downloads/arrowPrev.gif\" border=0 align=\"middle\" alt=\"Previous page\"><\a>&nbsp;"	;
} //end if
     // end if
	 if ( (path==2)  &&    (page==count)  ) { 
		    return "&nbsp;<a class=\"whitetext\" href=\"javascript:\"><img src=\"/downloads/arrowNext.gif\"  border=0 align=\"middle\" alt=\"Next page\"><\a>" +  "&nbsp;<a class=\"whitetext\" href=\"javascript:\"><img  src=\"/downloads/arrowEnd.gif\" border=0 align=\"middle\" alt=\"Go to End\"><\a>"	;
} else
{		    return "&nbsp;<a class=\"whitetext\" href=\"javascript:Go_(3)\"><img src=\"/downloads/arrowNext.gif\" border=0 align=\"middle\" alt=\"Next page\"><\a>" + "&nbsp;<a class=\"whitetext\" href=\"javascript:Go_(4)\"><img src=\"/downloads/arrowEnd.gif\"  border=0 align=\"middle\" alt=\"Go to End\"><\a>";	
}//		 end if
}//	 end if
  //end public String
   
   public int  Countdownloads(String idf ) {
      SqlConnection MyConnection = new  SqlConnection(getpath() );
       SqlDataAdapter  MyCommand = new SqlDataAdapter(SqlStringFiles("FilesWithFormatByIDF", "", idf, ""), MyConnection);
       DataSet Ds1 = new DataSet();
       	MyCommand.Fill(Ds1, "tblfilespath")		;
	int count=0;
		for (int i=0; i<= Ds1.Tables["tblfilespath"].Rows.Count-1  ; i++)  {
		//	count=count+Ds1.Tables["tblfilespath"].Rows[i]["Download"];
            count += count;
   }//	next
		return count;
   } //end public String
   
   public String     AlignerCenter(int a){
     return "<p align=\"center\">" +  a.ToString() + "</p>";
   }//end public String

   public String AlignerRight(int a){
     return "<p align=\"right\">" + a.ToString() + "</p>";
   }//end public String
   
   ////////////public String  GetRate(String idf,int oid, int b){
   ////////////         String gaston;
   ////////////         SqlDataAdapter MyCommand = new System.Data.SqlClient.SqlDataAdapter("select tblRateCat.ratename, tblRateFile.ball as rate, tblRateFile.ido  from tblRateCat left join tblRateFile on tblRateCat.rcid=tblRateFile.rcid where idf=" + Convert.ToString(idf) + " and ido=" + Convert.ToString(oid), MyConnection);
   //////////// DataSet Ds1 = new  DataSet();
   ////////////             MyCommand.Fill(Ds1, "tblRateCat")	;
   ////////////         gaston="<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"150\">";	
   ////////////         for (int j=0 ;  j<= Ds1.Tables["tblRateCat"].Rows.Count-1 ; j++){
   ////////////           gaston = gaston +  "<tr><td nowrap> "+ Ds1.Tables["tblRateCat"].Rows[j]["ratename"].ToString()  +  "<\td><td width=\"100%\"       align=\"right\">" + "<img src=\"\" + Convert.ToString(b) + \"img/dot_\" + Convert.ToString(Ds1.Tables('tblRateCat').Rows[j).Item('rate')) + \".gif\"  border=\"0\"   + \">\"  +  " /" </td> </tr> /"  ;
   ////////////         }// next j			
   ////////////         gaston = gaston+"<\table>"	;
   ////////////         Ds1.Clear();
   ////////////         return gaston;
   ////////////} //end public String
   


   public String AddSpacerImage(int x,int  y, int border){
     return "<img src=\"img\transparent.gif\" alt=\"\" width=\"\" + Convert.ToString(x) +  \"\" height=\"\" + Convert.ToString(y) + \"\" border=\"\" + Convert.ToString(border) + \"\">";
   } //end public String

    public String AddFormat(String name, int border)
    {
     return "<img src=\"img/" +  name +  ".gif\" alt=\"\"  width=\"\"  height=\"\"  border=\"\" + Convert.ToString(border) +    \">" ;
   }  //end public String

    public String voteHand(int a, int b)
    {
            if ( a==0 ) { //then
                return "<img src=\" + Convert.ToString(b) + \"img/ttd.gif\" alt=\"\" width=\"14\" height=\"17\" border=\"0\">";
            } //end if
            if (a>0) { // then
                return "<img src=\" + Convert.ToString(b) + \"img/ttu.gif\" alt=\"\" width=\"14\" height=\"17\" border=\"0\">";
        }//    end if
        return "";
    }// end public String

   public String voteListHand(int a,int b){
            if ( a<0 ) {// then
                return "<img src=\" + Convert.ToString(b) + \"img\ttd.gif\" alt=\"\" width=\"14\" height=\"17\" border=\"0\">";
            } //end if
            if (a>0 ) { 
                return "<img src=\"\" + Convert.ToString(b) + \"img\ttu.gif\" alt=\"\" width=\"14\" height=\"17\" border=\"0\">";
            } //end if
            return "no votes";
   }// end public String


   public int  CountofPages(int countofrows,int onpagefilescount){
       if (countofrows>onpagefilescount)  { // then
         if   ((countofrows/onpagefilescount)-(countofrows/onpagefilescount)==0) {// then
           return  (countofrows/onpagefilescount);
        } else
         {  return  (countofrows/onpagefilescount)+1;
         } //end if
      } else{
         return 1;
       } //end if 
         return 0;
   }//end public String

  public void DiapazonList (int Page,int countofrows,int onpagecount){
      int beginlist = 0; int endlist;
      
      if (Page==0 ||  Page==1 ) { //then
           beginlist=0;
           if (countofrows<onpagecount-1) { // then
               endlist=countofrows-1;
           } else{
               endlist=onpagecount-1;		     
           } //end if	   
         }else{
           beginlist=(Page-1)*onpagecount;
           if (countofrows<beginlist+onpagecount-1) { // then
               endlist=countofrows-1;
          } else{
               endlist=beginlist+onpagecount-1		;     
        }//  end if	   
         }//end if
  }//end public String 


  public String SqlStringOpinions(String Proc,String idf,String sort) {
      switch (Proc) { 
     case  "OpinionsTop2byIDF":
          return "select TOP 2 * from tblopinions where idf="+Convert.ToString(idf)+" order by oid desc";
     case "OpinionsAllbyIDF":	
          return "select * from tblopinions where idf="+Convert.ToString(idf)+" order by oid desc";
     case "OpinionsAllbyIDFandSort":	
          return "select * from tblopinions where idf="+Convert.ToString(idf)+" order by "+Convert.ToString(sort);
     case "OpinionsTop5MostPopular"	:  
          return "select distinct top 5 count(vote) as vote , tblFiles.idf, tblFiles.fabout, min(tblmost.idc) as idc from tblFiles left join tblOpinions on tblFiles.idf=tblOpinions.idf left join tblmost on tblFiles.idf=tblmost.idf where tblFiles.approved=1 group by tblFiles.idf, tblFiles.fabout order by vote desc";
     case "OpinionsByIDF_maxVote"	 : 
          return "select count(vote) as vote from tblOpinions where vote=1 and idf="+Convert.ToString(idf);
     case "OpinionsByIDFAll"	  :
          return "select count(vote) as vote from tblOpinions where idf="+Convert.ToString(idf);
        
  } //End Select 

  return "";
} //End public String

  public String SqlStringCategories(String Proc, String idc) {
      switch (Proc) { //Select Proc
     case "CategoriesByChild":
          return "Select * from tblCategories where child="+Convert.ToString(idc); 
     case "CategoriesByIDC":
          return "Select * from tblCategories where idc="+Convert.ToString(idc) ;
       
  } //End Select 
  return "";
}// End public String

 public String SqlStringFiles(String Proc,String idc,String idf, String sort) {
   //Select Proc
       switch (Proc) {
     case "FilesByIDF":
       //   return "select tblstyles.name as broshure_name, * from tblfiles left join tblStyles on tblfiles.id_style=tblStyles.id_style  where idf="+Convert.ToString(idf);
     case "FilesByIDCandApprovedonlyCount":
          return "Select  count(*) as quantityfiles from tblFiles left join tblmost on tblFiles.idf=tblmost.idf where tblFiles.approved=1 and tblmost.idc="+Convert.ToString(idc);
    case "FilesByIDCandApproved":
          return "Select  tblmost.idc, tblstyles.name , tblfiles.color, tblfiles.imagename, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.dt, tblfiles.username, tblfiles.recommended, tblfiles.descript, tblfiles.idf, tblfiles.fabout, count(tblfilespath.idfiles) as quantity, sum(tblfilespath.download) as download, sum(tblfilespath.size) as size, total = (select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=1)-(select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=0) from tblFiles  left join tblStyles on tblfiles.id_style=tblStyles.id_style left join tblfilespath on tblfiles.idf=tblfilespath.idf left join tblmost on tblFiles.idf=tblmost.idf where tblmost.idc="+Convert.ToString(idc)+" AND tblFiles.approved=1 group by tblmost.idc ,tblfiles.imagename, tblstyles.name , tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates, tblfiles.descript, tblfiles.recommended, tblfiles.username, tblfiles.idf, tblfiles.fabout, tblfiles.dt order by "+Convert.ToString(sort);
     case "FilesTop5andApproved":
         return "select distinct top 5 tblFiles.idf, tblFiles.fabout,tblFiles.dt,  min(tblmost.idc) as idc from tblfiles left join tblmost on tblFiles.idf=tblmost.idf where tblFiles.approved=1 group by tblFiles.idf, tblFiles.fabout,tblFiles.dt order by tblFiles.dt desc";
     case "FilesRecommended":
          return "Select distinct  min(tblmost.idc) as idc, tblfiles.imagename, tblstyles.name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.dt, tblfiles.username, tblfiles.recommended, tblfiles.descript, tblfiles.idf, tblfiles.fabout, quantity=(select count(*) from tblfilespath where tblfilespath.idf=tblfiles.idf), download=(select sum(tblfilespath.download) from tblfilespath where tblfilespath.idf=tblfiles.idf), size = (select sum(tblfilespath.size) from tblfilespath where tblfilespath.idf=tblfiles.idf), total = (select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=1)-(select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=0) from tblFiles left join tblStyles on tblfiles.id_style=tblStyles.id_style left join tblfilespath on tblfiles.idf=tblfilespath.idf left join tblmost on tblFiles.idf=tblmost.idf where tblfiles.recommended=1 AND tblFiles.approved=1 group by tblStyles.name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.descript, tblfiles.recommended, tblfiles.idf, tblfiles.username, tblfiles.fabout, tblfiles.imagename, tblfiles.dt order by "+Convert.ToString(sort);
      case "FilesReleases":
          return "Select distinct top 20 min(tblmost.idc) as idc, tblfiles.imagename, tblstyles.name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.dt, tblfiles.username, tblfiles.recommended, tblfiles.descript, tblfiles.idf, tblfiles.fabout, count(tblfilespath.idfiles) as quantity, sum(tblfilespath.download) as download, sum(tblfilespath.size) as size, total = (select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=1)-(select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=0) from tblFiles left join tblStyles on tblfiles.id_style=tblStyles.id_style left join tblfilespath on tblfiles.idf=tblfilespath.idf left join tblmost on tblFiles.idf=tblmost.idf where tblFiles.approved=1 group by tblStyles.name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.descript, tblfiles.recommended, tblfiles.idf, tblfiles.username, tblfiles.fabout, tblfiles.imagename, tblfiles.dt order by tblfiles.dt desc, tblfiles.fabout" ;
     case "FilesWithFormatByIDF":
         //// return "select tblfilespath.idf, tblfilespath.copyright, tblfilespath.size,tblfilespath.download, tblfilespath.idfiles, tblfilespath.diskname,tblfilespath.opis, tblfilespath.fname, tblformats.formcomment,tblformats.idformat,tblformats.ower from tblfilespath left join tblformats on tblfilespath.idformat=tblformats.idformat where idf="+Convert.ToString(idf)	;	  
     case "FilesWithKeywords":
         return "";    ////  return "select tblstyles.name as broshure_name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates, tblfiles.idf, tblfiles.fabout, tblfiles.imagename, tblfiles.descript, tblfiles.dt, tblfiles.username , tblfiles.kw as keywords from tblfiles left join tblStyles on tblfiles.id_style=tblStyles.id_style where idf="+Convert.ToString(idf)	;	  
    } //End Select 
    return "";
}//End public String

  public String  SqlStringSearch(String Proc, String stxt,String sort, String in_string){
      switch (Proc) {
          case "FilesByOrder":
	 	  String []  splitedStr =null ,splitedSql=null;
		  splitedStr=in_string.Split(' ')  ;
		  for (int  i=0;  i<=  splitedStr.GetUpperBound(0)  ; i++) {
		  //	splitedSql=splitedSql+" AND ((tblfiles.fabout Like('%"+splitedStr[i].Replace("'","''")+"%') or tblfiles.descript Like('%"+splitedStr[i].Replace("'","''")+"%') or tblfiles.username Like('%"+splitedStr(i).Replace("'","''")+"%')) or tblFiles.idf in ("+in_string+")) ";
		  } //next
	      return "Select distinct min(tblmost.idc) as idc,tblfiles.imagename, tblStyles.name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.dt, tblfiles.username, tblfiles.recommended, tblfiles.descript, tblfiles.idf, tblfiles.fabout, quantity = (select count(*) from tblfilespath where tblfilespath.idf=tblfiles.idf) , download=(select sum(tblfilespath.download) from tblfilespath where tblfilespath.idf=tblfiles.idf) , sum(tblfilespath.size) as size, total = (select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=1)-(select count(tblOpinions.vote) from tblOpinions where tblOpinions.idf=tblfiles.idf And tblOpinions.vote=0) from tblFiles LEFT JOIN tblMost AS m ON (tblFiles.idf=m.idf) LEFT JOIN tblCategories AS c ON (m.idc=c.idc) left join tblmost on tblFiles.idf=tblmost.idf  left join tblStyles on tblfiles.id_style=tblStyles.id_style  left join tblfilespath on tblfiles.idf=tblfilespath.idf where ((tblfiles.fabout Like('%"+stxt.Replace("'","''")+"%') or tblfiles.descript Like('%"+stxt.Replace("'","''")+"%') or tblfiles.username Like('%"+stxt.Replace("'","''")+"%')) or tblFiles.idf in ("+in_string+"))"+ splitedSql+" AND tblFiles.approved=1 AND (c.idc IS NOT NULL) group by  tblStyles.name, tblfiles.color, tblfiles.dimension, tblfiles.date_used, tblfiles.originates,  tblfiles.descript, tblfiles.username, tblfiles.recommended, tblfiles.idf, tblfiles.fabout, tblfiles.imagename,  tblfiles.dt order by "+Convert.ToString(sort);
          } //End Select 
          return "";
      } //End public String
  


  public String SqlStringRate(String Proc,String idc,String idf,String sort) {
          switch (Proc) {
	 case "AverageRateByIDF":
	      return "select tblRateCat.ratename, AVG(tblRateFile.ball) as rate from tblRateCat left join tblRateFile on tblRateCat.rcid=tblRateFile.rcid where idf="+Convert.ToString(idf)+" Group by ratename,idf";
	 case "GetRateList":
		  return "select * from tblRateCat where disabled=0 order by rcid";
	 case "GetFullRateList"	:  
	      return "select * from tblRateCat order by rcid";
          return "";
  } //End Select 
  return "";
} //End public String
  
  public String SqlStringKeywords(String Proc,String idw) {
      switch (Proc) {
	 case "GetAllKeywords":
	      return "Select * from tblKeywords order by keywords";
	 case "GetKeywordsByText":	  
	      return "Select * from tblKeywords where keywords='"+ Convert.ToString(idw.Replace("'","''"))+"'";
          return "";
  }//End Select 
  return "";
}// End public String
  
  public String SqlStringLogin( String Proc,String username,String password){
     switch (Proc) {
         case "GetUser":
	      return "Select * from tblAuthor where active=1 and author_email='"+Convert.ToString(username)+"' and password='"+Convert.ToString(password)+"'" ;
         case  "GetUserByID":
		  return "Select * from tblAuthor where author_id="+Convert.ToString(username);
    
  }
	//End Select  
            ////switch ( tmpEl01.Name)
            ////    {
            ////        case "title" : title = tmpEl01.InnerText; break;
            ////        case "module" : centerModuleUrl = tmpEl01.InnerText; break;
            ////        case "import" : import = tmpEl01.InnerText; break;
            ////        case "javascript" : javascript = tmpEl01.InnerText; break;
            ////        case "onLoad" : onLoad = tmpEl01.InnerText; break;
            ////    }

  return "";
} //End public String

  public String SqlStringFormats(String Proc,String idf) {
    switch (Proc) 
    {   	 case "GetAllFormats" :	   return "select * from tblFormats";break; } 
      //End Select 
return "";
}//End public String
  
  public String usp_Top5Popular(){
    return "select distinct top 5 tblfiles.idf, tblfiles.fabout,  download = (select sum(tblfilespath.download) from tblfilespath where tblfilespath.idf=tblfiles.idf) , min(tblmost.idc) as idc from tblfiles left join tblmost on tblfiles.idf=tblmost.idf left join tblfilesPath on tblfiles.idf=tblfilesPath.idf where tblFiles.approved=1 group by tblfiles.fabout, tblfiles.idf order by download desc";
  }//end public String
  
  
   public String prepearSQL(String str) {
       str = str.Replace("'","''");
       str = str.Replace("","&quot;");
	   return str;
   } //end public String
  
 




















}

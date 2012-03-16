 
 

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using Microsoft.Office.InfoPath;
using Microsoft.Office.Interop.Outlook;
using System.ComponentModel;

using OutLook = Microsoft.Office.Interop.Outlook; 

//using Microsoft.DirectX ;
 //using   WMPLib;
//using System.Runtime.InteropServices;
 
 //using Microsoft.DirectX.AudioVideoPlayback ;
//using Microsoft.DirectX.Direct3D ;
using System.Media;


public partial class SubingForm : System.Web.UI.Page
{

    Referrer r = new Referrer();
    String[] qry;
    String id = "";
    String prm = "";
   public  String SubGmachTitle = "";

        protected void Page_PreRender(object sender, EventArgs e)
        {

            



            OutLook._Application outlookObj = new OutLook.Application();
             
            
  
 //Button btnPlaySong =  (Button) this.form.FindControl("btnPlaySong");
        //Song.rr  = Request.PhysicalApplicationPath.ToString(); 
 

 
           
    

  
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            Process();

           // Response.Redirect("default.htm");
       
        }




    



        //process the form
        private void Process()
        {
            String url = Server.UrlDecode(Request.QueryString.ToString());



            if  (  url!="" )

            {

            //mail.ID = "";
            // mail.email = "";
            // mail.reqemail = "";
          qry = new String[0];

            qry = url.ToString().Split('&');


            if (qry != null && qry.Length > 0 && qry.ToString() != string.Empty)
            {
                id = qry[0] != null ? qry[0].ToString() : "";//                                  qry.ToString().IndexOf("id=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("id=") + 3, qry.Length - 3);
            
                prm = qry[1] != null  ? qry[1].ToString() : "";//                  .IndexOf("prm=") == -1 ? "0" : qry[0].Substring(qry[0].ToString().IndexOf("=") + 4, qry.Length - 4);
              
         if ( prm!="")   prm= prm.Substring(prm.IndexOf("=")+1,(prm.Length-prm.IndexOf("="))-1  ) ;
         if (id != "") id = id.Substring(id.IndexOf("=") + 1, (id.Length - id.IndexOf("=")) - 1);

            }
            if (prm == "4")
            {
                SubGmachTitle="View Matches for Sub " + id ;
                prm = "6";
            }
            if (prm == "5") 
            {
                SubGmachTitle = "View Matches for Principal " + id;
                prm = "7";
            }

            if (prm == "8")
            {
                SubGmachTitle = "View Matches for Principal and Subs " + id;
              
            }




        }


            if (prm == "6" || prm == "7" || prm == "8")
            {
                UpdateDonate();
            }
            else { Update_Donate(); }
           
          
 
        }

      







     









    protected void UpdateDonate()
    {


        //mails.id = qry[1].ToString().IndexOf("id=") == -1 ? "0" : qry[1].Substring(qry[1].ToString().IndexOf("id=") + 3, qry[1].Length - 3);

        if (mails.prm=="8")
        {

        mails.sunday = qry[2].ToString().IndexOf("sunday=") == -1 ? "0" : qry[2].Substring(qry[2].ToString().IndexOf("sunday=") + 7, qry[2].Length - 7);
        mails.monday = qry[3].ToString().IndexOf("monday=") == -1 ? "0" : qry[3].Substring(qry[3].ToString().IndexOf("monday=") + 7, qry[3].Length - 7);
        mails.tuesday = qry[4].ToString().IndexOf("tuesday=") == -1 ? "0" : qry[4].Substring(qry[4].ToString().IndexOf("tuesday=") + 8, qry[4].Length - 8);
        mails.wednesday = qry[5].ToString().IndexOf("wednesday=") == -1 ? "0" : qry[5].Substring(qry[5].ToString().IndexOf("wednesday=") + 10, qry[5].Length - 10);
        mails.thursday = qry[6].ToString().IndexOf("thursday=") == -1 ? "0" : qry[6].Substring(qry[6].ToString().IndexOf("thursday=") + 9, qry[6].Length - 9);
        mails.friday = qry[7].ToString().IndexOf("friday=") == -1 ? "0" : qry[7].Substring(qry[7].ToString().IndexOf("friday=") + 7, qry[7].Length - 7);
        mails.morning = qry[8].ToString().IndexOf("morning=") == -1 ? "0" : qry[8].Substring(qry[8].ToString().IndexOf("morning=") + 8, qry[8].Length - 8);
        mails.afternoon = qry[9].ToString().IndexOf("afternoon=") == -1 ? "0" : qry[9].Substring(qry[9].ToString().IndexOf("afternoon=") + 10, qry[9].Length - 10);


        mails.evening = qry[10].ToString().IndexOf("evening=") == -1 ? "0" : qry[10].Substring(qry[10].ToString().IndexOf("evening=") + 8, qry[10].Length - 8);
        mails.subtype = qry[11].ToString().IndexOf("subtype=") == -1 ? "0" : qry[11].Substring(qry[11].ToString().IndexOf("subtype=") + 8, qry[11].Length - 8);
          
       
        }


        String email = (String)Request.Form["email"] == null ? "0" : "1";         // (String)Request.Form["email"] == null ? Request.Form["email"].ToString() : Request.Form["email"].ToString();
        String subtype =     (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        //String firstName = (String)Request.Form["firstName"] == null ? Request.Form["First Name"].ToString() : Request.Form["firstName"].ToString();
        //String lastName = (String)Request.Form["lastName"] == null ? Request.Form["Last Name"].ToString() : Request.Form["lastName"].ToString();
        String tel = (String)Request.Form["tel"] == null ? "0" : "1";// (String)Request.Form["tel"] == null ? Request.Form["tel"].ToString() : Request.Form["tel"].ToString();





        String sunday = mails.sunday;//     qry[2] != null ? qry[2].ToString() : "0";  // (String)Request.Form["sunday"] == null ? "0" : "1";
        String monday = mails.monday;//    qry[3] != null ? qry[3].ToString() : "0";
        String tuesday = mails.tuesday;//     qry[4] != null ? qry[4].ToString() : "0";
        String wednesday = mails.wednesday;//     qry[5] != null ? qry[5].ToString() : "0";  //Request.Form["wednesday"].ToString() : Request.Form["wednesday"].ToString();
        String thursday = mails.thursday;//     qry[6] != null ? qry[6].ToString() : "0";  //Request.Form["thursday"].ToString() : Request.Form["thursday"].ToString();
        String friday = mails.friday;//     qry[7] != null ? qry[7].ToString() : "0";  //Request.Form["friday"].ToString() : Request.Form["friday"].ToString();
        String morning = mails.morning;//    qry[8] != null ? qry[8].ToString() : "0"; ///       Request.Form["morning"].ToString() : Request.Form["morning"].ToString();
        String afternoon = mails.afternoon;//     qry[9] != null ? qry[9].ToString() : "0";  // Request.Form["afternoon"].ToString() : Request.Form["afternoon"].ToString();
        String evening = mails.evening;//     qry[10] != null ? qry[10].ToString() : "0";    // Request.Form["evening"].ToString() : Request.Form["evening"].ToString();
        String subType = mails.subtype;//    qry[11] != null ? qry[11].ToString() : "0"; // (String)Request.Form["subType"] == null ? Request.Form["subType"].ToString() : Request.Form["subType"].ToString();

      // String prm =  mails.prm;   // "i";


        String avail_request = Request.Form["avail_request"];





      //  String id = "0";
        int Site = (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
        String status = "pending";


        DataSet ds = new DataSet();
        status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;

        string commandText = "getMatches";






        ds = r.getMatches(commandText, prm, id, morning, afternoon, evening,
          sunday, monday, tuesday, wednesday, thursday, friday,
          subType, avail_request, email, status);





        ds.Tables[0].Columns.Add("prm");

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            dr["prm"] = prm;

        }








        grdvSubGmach.AutoGenerateColumns = false;
        grdvSubGmach.DataSource = ds;
        grdvSubGmach.CellPadding = 9;
        grdvSubGmach.Columns[3].ItemStyle.Width = 230;

        grdvSubGmach.DataBind();

 



    }



    

    protected void Update_Donate()
    {



        //String id = "";
        //String prm = "";
        //    String qry = Server.UrlDecode(Request.QueryString.ToString());

        //if (qry != null && qry.Length > 0 && qry.ToString() != string.Empty)
        //{
        //    prm = qry.ToString().IndexOf("prm=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("prm=") + 4, qry.Length - 4);
        //    id = qry.ToString().IndexOf("id=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("id=") + 3, qry.Length - 3);
        //}



        String email = (String)Request.Form["email"] == null ? "0" :  (String)   Request.Form["email"].ToString();
        String subtype = (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String firstName = (String)Request.Form["firstName"] == null ? (String)Request.Form["First Name"].ToString() : (String)Request.Form["firstName"].ToString();
        String lastName = (String)Request.Form["lastName"] == null ? (String)Request.Form["Last Name"].ToString() : (String)Request.Form["lastName"].ToString();
         String tel = (String)Request.Form["tel"] == null ? (String)Request.Form["tel"].ToString() : (String)Request.Form["tel"].ToString();





         String sunday = (String)Request.Form["sunday"] == null ? "0" : (String)Request.Form["sunday"].ToString() == "on" ? "1" : "0";
         String monday = (String)Request.Form["monday"] == null ? "0" : (String)Request.Form["monday"].ToString() == "on" ? "1" : "0";
         String tuesday = (String)Request.Form["tuesday"] == null ? "0" : (String)Request.Form["tuesday"].ToString() == "on" ? "1" : "0";
        String wednesday = (String)Request.Form["wednesday"] == null ? "0" : (String)Request.Form["wednesday"].ToString() == "on" ? "1" : "0";
        String thursday = (String)Request.Form["thursday"] == null ? "0" : (String)Request.Form["thursday"].ToString() == "on" ? "1" : "0";
        String friday = (String)Request.Form["friday"] == null ? "0" : (String)Request.Form["friday"].ToString() == "on" ? "1" : "0";
        String morning = (String)Request.Form["morning"] == null ? "0" : (String)Request.Form["morning"].ToString() == "on" ? "1" : "0";
        String afternoon = (String)Request.Form["afternoon"] == null ?  "0": (String) Request.Form["afternoon"].ToString() == "on" ? "1" :"0"   ;
        String evening = (String)Request.Form["evening"] == null ? "0" : (String)Request.Form["evening"].ToString() == "on" ? "1" : "0";
        String subType = (String)Request.Form["subType"] == null ? "0" :  (String)Request.Form["subType"] == null ? Request.Form["subType"].ToString() : Request.Form["subType"].ToString();

     String prm =    "i";


        String avail_request = Request.Form["avail_request"];





      //  String id = "0";
        int Site = (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
        String status = "pending";


        DataSet ds = new DataSet();
        //status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;
        string commandText = "setMatches";

        r.setMatches(commandText, prm, id, morning, afternoon, evening,
          sunday, monday, tuesday, wednesday, thursday, friday,
          subType, avail_request, email,firstName,lastName,tel, status);
      //  grdvSubGmach.AutoGenerateColumns = false;

 

 
     //   Console => Environment.Exit(0)
// Forms => Form.Close() 
       // Application.Exit(); 
       // this.close();


        this.Response.ClearContent();
        this.Response.Write(@"<html>
<head>
<script type='text/javascript' language='javascript'>
<!--
top.close();
// -->
</script>
</head>
<body />
</html>");
        this.Response.End();




    }
      













}








     
     


     




   








 






















































































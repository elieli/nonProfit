 
 

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
using System.ComponentModel;
 

//using Microsoft.DirectX ;
 //using   WMPLib;
//using System.Runtime.InteropServices;
 
 //using Microsoft.DirectX.AudioVideoPlayback ;
//using Microsoft.DirectX.Direct3D ;
using System.Media;


public partial class BuyersForm : System.Web.UI.Page
{

    Referrer r = new Referrer();
    String[] qry;
    String id = ""; int idd = 0;
    String prm = "";
   public  String SubGmachTitle = "";

        protected void Page_PreRender(object sender, EventArgs e)
        {

            
              

 
           
    

  
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.btnLoadImg.Attributes.Add("onclick", "javascript:return OpenPopup()");

            }
            if (!IsPostBack) { return; }


          

         //   Process();

           // Response.Redirect("default.htm");
       
        }




    // private void Process()

       

        //process the form
        protected void Process(object sender, EventArgs e)
   
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
                ////UpdateDonate();
            }
            else { Update_Donate(); }
           
          
 
        }

      







     









     






        //grdvSubGmach.AutoGenerateColumns = false;
        //grdvSubGmach.DataSource = ds;
        //grdvSubGmach.CellPadding = 9;
        //grdvSubGmach.Columns[3].ItemStyle.Width = 230;

        //grdvSubGmach.DataBind();














        protected void OnSaveClick(object sender, EventArgs e)
        {

           

            //HtmlInputFile fileLoadimgTop = (HtmlInputFile)this.FindControl("fileLoadimgTop");

            //HtmlInputFile fileLoadimgTop1 = (HtmlInputFile)this.FindControl("fileLoadimgTop1");

            //HtmlInputFile fileLoadimgTop2 = (HtmlInputFile)this.FindControl("fileLoadimgTop2");


            String path = Server.MapPath("\\images");


            HtmlInputFile fileLoad = (HtmlInputFile)this.FindControl("buttonLogo");


            messages.filePost(fileLoad, path);


            //messages.filePost(fileLoadimgTop1);
            //messages.filePost(fileLoadimgTop2);





        }



    protected void OnSaveClick(String file)
    {
        file = "images/" + file;

     ///   HtmlInputFile buttonLogo = (HtmlInputFile)    file;

      //  HtmlInputFile buttonLogo = (HtmlInputFile)this.FindControl("buttonLogo");

        
      //  messages.filePost(buttonLogo);

 




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



        String buyer_email =  ((HtmlInputControl)this.FindControl("orgEmail")).Value  ;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
       // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String buyer_Name = ((HtmlInputControl)this.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();
        String orgFunct = ((HtmlInputControl)this.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
        String orgDesc = ((HtmlInputControl)this.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
        String orgTaxID = ((HtmlInputControl)this.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

        String buyer_paypalAccount = ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();

        String buttonLogo = ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = "pending";// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();


        String password = ((HtmlInputControl)this.FindControl("password")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        

      //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

        //if (ConfirmImg!=null) 
        //{
        //    OnSaveClick(buttonLogo);
        //    return;

        //}



 
     String prm =    "N";


     //   String avail_request = Request.Form["avail_request"];



      int  buyer_CreditCardInfoID=0;
        

      int  buyer_BillingAddressID=0;

      int   buyer_ShippingAddressID=0;
        int  Credits=0;

      //  String id = "0";
      //  int Site = (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
     //   String status = "pending";


        DataSet ds = new DataSet();
        //status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;
        string commandText = "get_Buyers";

    r.setBuyers(commandText, prm, idd ,
		 buyer_Name  ,
		  buyer_email   ,	
          buyer_paypalAccount,
		 buyer_CreditCardInfoID  ,
	  buyer_BillingAddressID    ,
	  buyer_ShippingAddressID   ,
      Credits, password
	);
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








     
     


     




   








 






















































































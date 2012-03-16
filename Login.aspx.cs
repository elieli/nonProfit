using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class LoginAuth : System.Web.UI.Page
{

 Referrer r = new Referrer();

    protected void Page_Load(object sender, EventArgs e)
    {



        if (custs() == null) 
        {
            BLCustomer cust = new BLCustomer(0);

                    custs_ = cust;
        }



        
            

        string qry = Request.QueryString !=null  && Request.QueryString.Count>0 ?   Request.QueryString[0].ToString():  "" ;
        
       Session["qry"]=qry;
      // if (qry.IndexOf("In") == -1)
      // {  BLCustomer.signedinorgid = 0;
      //  BLCustomer.buyerID = 0;


      //     BLCustomer.CustName="";

      //     BLCustomer.signedinorgname = "";
        
      //Response_End(sender, e);
      // }



       // if (BLCustomer.signedinorgid == 0 && BLCustomer.buyerID == 0)
       //{

     
       HtmlContainerControl dvheader = (HtmlContainerControl)this.FindControl("dvheader");

       dvheader.InnerHtml = qry + "s Log in";

        ////}
        ////else
        ////{
        ////    if (qry.IndexOf("not") == -1 ) dvheader.InnerHtml = "You are allready loged in Please log out first";

        ////    else { dvheader.InnerHtml = qry + "s Log in"; }

        ////}






    }

  //  buyerID	buyer_Name	buyer_email	buyer_paypalAccount	buyer_CreditCardInfoID	buyer_BillingAddressID	buyer_ShippingAddressID	buyerSessionID	buyerCreated	buyerSaveInfo	Credits




    protected void Update_DonateBuyer()
    {



        //String id = "";
        //String prm = "";
        //    String qry = Server.UrlDecode(Request.QueryString.ToString());

        //if (qry != null && qry.Length > 0 && qry.ToString() != string.Empty)
        //{
        //    prm = qry.ToString().IndexOf("prm=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("prm=") + 4, qry.Length - 4);
        //    id = qry.ToString().IndexOf("id=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("id=") + 3, qry.Length - 3);
        //}



        String buyer_email = txtLoginEmail.Text      ;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
        // String subtype = "";//  ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String buyer_Name = "";//  ((HtmlInputControl)this.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();
        String orgFunct = "";//  ((HtmlInputControl)this.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
        String orgDesc = "";// ((HtmlInputControl)this.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
        String orgTaxID = "";// ((HtmlInputControl)this.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

        String buyer_paypalAccount = "";// ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = "";//  ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();

        String buttonLogo = "";//  ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = "pending";// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();


        String password = txtLoginPassword.Text;// ((HtmlInputControl)this.FindControl("password")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();


        //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

        //if (ConfirmImg!=null) 
        //{
        //    OnSaveClick(buttonLogo);
        //    return;

        //}




        String prm = "P";


        //   String avail_request = Request.Form["avail_request"];



        int buyer_CreditCardInfoID = 0;


        int buyer_BillingAddressID = 0;

        int buyer_ShippingAddressID = 0;
        int Credits = 0;

        //  String id = "0";
        //  int Site = (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
        //   String status = "pending";


        DataSet ds = new DataSet();
        //status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;
        string commandText = "get_Buyers";
        int idd = 0;

     ds =   r.getBuyers(commandText, prm, idd,
             buyer_Name,
              buyer_email,
              password,
             buyer_CreditCardInfoID,
          buyer_BillingAddressID,
          buyer_ShippingAddressID,
          Credits 
        );
        //  grdvSubGmach.AutoGenerateColumns = false;


        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            int buyerID = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
          if (custs() == null)
         //// if   (  Session["nonProfit"] == null)
            
            {



                BLCustomer cust = new BLCustomer(buyerID);
              ///////////  Session["nonProfit"] = cust;
                custs_ = cust;
            }
            else { 
                custs().ID = buyerID;

                custs_ = custs();
               /// ((BLCustomer)Session["nonProfit"]).ID = buyerID;
            }




            dvmsg.InnerHtml = "you are now Log in ";
        }
        else
        {
            HtmlContainerControl dvmsg = (HtmlContainerControl)this.FindControl("dvmsg");

            dvmsg.InnerHtml = " Log in failed email & password not found";

        }

    }





    protected void Update_DonateOrg( )
    {



        //String id = "";
        //String prm = "";
        //    String qry = Server.UrlDecode(Request.QueryString.ToString());

        //if (qry != null && qry.Length > 0 && qry.ToString() != string.Empty)
        //{
        //    prm = qry.ToString().IndexOf("prm=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("prm=") + 4, qry.Length - 4);
        //    id = qry.ToString().IndexOf("id=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("id=") + 3, qry.Length - 3);
        //}

        string file = messages.image;


        //ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
        //   HtmlForm frm = (HtmlForm)MainContent.FindControl("form1");

        String orgEmail = txtLoginEmail.Text;//  ((HtmlInputControl)MainContent.FindControl("orgEmail")).Value;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
        // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String orgTitle = "";//  ((HtmlInputControl)MainContent.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();

        String orgFunct = "";//  ((HtmlInputControl)MainContent.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
        String orgDesc = "";// ((HtmlInputControl)MainContent.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
        String orgTaxID = "";// ((HtmlInputControl)MainContent.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

        String orgPaypal =  txtLoginPassword.Text ;//  ((HtmlInputControl)MainContent.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = "";//  ((HtmlInputControl)MainContent.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
        String orgVideo = "";
        String buttonLogo = "";// ((HtmlInputControl)MainContent.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = "pending";// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();




        //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

        //if (ConfirmImg!=null) 
        //{
        //    OnSaveClick(buttonLogo);
        //    return;

        //}




        String prm = "P";


        //   String avail_request = Request.Form["avail_request"];

        int idd = 0;



        //  String id = "0";
        //  int Site = (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
        //   String status = "pending";


        DataSet ds = new DataSet();
        //status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;
        string commandText = "get_Orgs";

        ds = r.getOrgs(commandText, prm, idd,
         orgTitle,
         orgFunct,
         orgDesc,
     orgTaxID,
     orgEmail,
     orgPaypal,
     orgLogo,
     orgStatus,   orgVideo 
     
    );
        //  grdvSubGmach.AutoGenerateColumns = false;

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            int orgID = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());










            if (custs() == null)




            /// if (Session["nonProfit"] == null)
            {



                BLCustomer cust = new BLCustomer(0);

                // Session["nonProfit"] = cust;

                custs_ = cust;
            }


            custs().signedinorgid = orgID;
            custs_ = custs();
           //messages.cust.Organization.ID = orgID;
            dvmsg.InnerHtml = "you are now Loged in ";
        }
        else
        {
            HtmlContainerControl dvmsg = (HtmlContainerControl)this.FindControl("dvmsg");

            dvmsg.InnerHtml =  " Log in failed email & password not found";

        }
    }
    






    protected void login(Object sender,  EventArgs e)
    {
    //  string  MessageLogin="";

    //Logins.password = txtLoginPassword.Text;
    //Logins.userid = txtLoginEmail.Text;
    //switch (Logins.password)
    //{
    //    case "tzally123":
    //        messages.buyerID = 6;

    //        break;
    //    case "zalman123":
    //        messages.buyerID = 1;

    //        break;

    //    case "eli123":
    //        messages.buyerID = 2;

    //        break;

    //    default:


    //        BLCustomer cust = new BLCustomer(messages.buyerID);

    //        messages.cust = cust;


        //        break;



        custs().signedinorgid = 0;
        custs().buyerID = 0;


         
     //       if (  dvheader.InnerHtml != "You are allready loged in Please log out first")


         

  



     //{

        
        String buyer_email = txtLoginEmail.Text      ; 
        String password = txtLoginPassword.Text;




        //if (Session["qry"].ToString().IndexOf("not") != -1) 
        //         {
                    if (custs().buyerID  != 0) {custs().buyerID   = 0;}

                    else
                    {
                         if (custs().signedinorgid  != 0)custs().signedinorgid   = 0;
                    }

                 //}
                 //else{


        String prm = "P";


        //   String avail_request = Request.Form["avail_request"];

        int idd = 0;



        //  String id = "0";
        //  int Site = (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
        //   String status = "pending";


        DataSet ds = new DataSet();
        //status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;
        string commandText = "get_Logins";

     ds=    r.getLogins(commandText, prm, buyer_email,password  );



     if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)

     {
         if (ds.Tables[0].Rows[0]["buyerid"] != null &&   ds.Tables[0].Rows[0]["buyerid"].ToString() != "")
         {
            ////////////////////// Update_DonateBuyer();

                          
              int buyerID = Convert.ToInt16(ds.Tables[0].Rows[0]["buyerid"].ToString());
            if (Application["cust"] == null)
            {
                

                BLCustomer cust = new BLCustomer(buyerID);
                custs().CustName = ds.Tables[0].Rows[0]["buyer_name"].ToString();

                
                Application["cust"] = cust;
                
                

               //////// messages.cust = cust;
            }
            else 
            {
                 custs().ID = buyerID; 
                custs().CustName = ds.Tables[0].Rows[0]["buyer_name"].ToString();

                custs_ = custs();

            }




            dvmsg.InnerHtml = "you are now Logged in ";
        }











              
             //else
             //{
             //    HtmlContainerControl dvmsg = (HtmlContainerControl)this.FindControl("dvmsg");

             //    dvmsg.InnerHtml = " Log in failed email & password not found";

             //}





 
         else {

             if (ds.Tables[0].Rows[0]["orgid"] != null)
             {
                 
                 
                 
                 
                 
                 int orgID = Convert.ToInt16(ds.Tables[0].Rows[0]["orgid"].ToString());
                 string org_title = ds.Tables[0].Rows[0][1].ToString();
                 
                 custs().signedinorgname = org_title; 
                
                 
                 
                 if (messages.cust == null)
                 {
                     BLCustomer cust = new BLCustomer(0);
                  
                     messages.cust = cust;
                 }
                 custs().signedInorgID = orgID;
                 custs().signedinorgname = org_title;





                 custs_ = custs();


                
 


                  

                 // messages.cust.Organization.ID = orgID;
                 dvmsg.InnerHtml = "you are now Loged in ";


             }
                 
                 
                /// Update_DonateOrg(); 
             }
         //}
        Response_End(sender,e);
     //}
    }


    }

    protected void  Response_End(object sender, EventArgs e )
    {

        BLItem.raiseMenu(sender, e);

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







    public BLItems items()
    { 

            return (BLItems)((BLCustomer)Application["cust"]).Organization.Orgitems;
        
    }



    public BLOrganization orgs ()
    {  
        return (BLOrganization)((BLCustomer)Application["cust"]).Organization;
         

    }




    public BLCustomer custs ()
    {
         
            return ((BLCustomer)Application["cust"]);
         

    }




    public BLItem item()
    {
        return ((BLCustomer)Application["cust"]).Organization.Orgitems.Item;
    }
















    //public BLItems items
    //{
    //    get
    //    {

    //        return (BLItems)((BLCustomer)Application["cust"]).Organization.Orgitems;
    //    }
    //    set
    //    {
    //        ((BLCustomer)Application["cust"]).Organization.Orgitems = value;
    //    }
    //}



    //public BLOrganization orgs
    //{
    //    get
    //    {

    //        return (BLOrganization)((BLCustomer)Application["cust"]).Organization;
    //    }
    //    set
    //    {
    //        ((BLCustomer)Application["cust"]).Organization = value;



    //    }

    //}




    public BLCustomer custs_
    {
        
        set
        {
            (Application["cust"]) = value;
        }

    }



     
























}



        //}

  ///  if (Session["qry"].ToString() == "buyer")

    ////////////////    if (Session["qry"].ToString() == "login")

    ////////////////{




    ////////////////    Update_DonateBuyer();
    
    ////////////////}
    ////////////////else {
        
    ////////////////    Update_DonateOrg(); }



  ///  String response = Request.UrlReferrer.ToString();

   // Response.Redirect("orgProducts.aspx");
   /// Response.Redirect(response);
////////    this.Response.ClearContent();
////////    this.Response.Write(@"<html>
////////    <head>
////////    <script type='text/javascript' language='javascript'>
////////    <!--
////////    top.close();
////////    // -->
////////    </script>
////////    </head>
////////    <body />
////////    </html>");


////////        this.Response.End();


       

 
 

 

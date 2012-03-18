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

        string qry = Request.QueryString != null && Request.QueryString.Count > 0 ? Request.QueryString[0].ToString() : "";

        Session["qry"] = qry;
 
        HtmlContainerControl dvheader = (HtmlContainerControl)this.FindControl("dvheader");

        dvheader.InnerHtml = qry + "s Log in";

    }

 
    protected void Update_DonateBuyer()
    {

        String buyer_email = txtLoginEmail.Text;
        String buyer_Name = "";
        String orgFunct = "";
        String orgDesc = "";
        String orgTaxID = "";

        String buyer_paypalAccount = "";// ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = "";//  ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();

        String buttonLogo = "";//  ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = "pending";// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();


        String password = txtLoginPassword.Text;// ((HtmlInputControl)this.FindControl("password")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();


        String prm = "P";


        int buyer_CreditCardInfoID = 0;


        int buyer_BillingAddressID = 0;

        int buyer_ShippingAddressID = 0;
        int Credits = 0;

       

        DataSet ds = new DataSet();
       
        string commandText = "get_Buyers";
        int idd = 0;

        ds = r.getBuyers(commandText, prm, idd,
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
            else
            {
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





    protected void Update_DonateOrg()
    {

        string file = messages.image;


        String orgEmail = txtLoginEmail.Text;//  ((HtmlInputControl)MainContent.FindControl("orgEmail")).Value;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
        // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String orgTitle = "";//  ((HtmlInputControl)MainContent.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();

        String orgFunct = "";//  ((HtmlInputControl)MainContent.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
        String orgDesc = "";// ((HtmlInputControl)MainContent.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
        String orgTaxID = "";// ((HtmlInputControl)MainContent.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

        String orgPaypal = txtLoginPassword.Text;//  ((HtmlInputControl)MainContent.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = "";//  ((HtmlInputControl)MainContent.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
        String orgVideo = "";
        String buttonLogo = "";// ((HtmlInputControl)MainContent.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = "pending";// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();

        String prm = "P";


        //   String avail_request = Request.Form["avail_request"];

        int idd = 0;

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
     orgStatus, orgVideo

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

            dvmsg.InnerHtml = " Log in failed email & password not found";

        }
    }







    protected void login(Object sender, EventArgs e)
    {

        custs().signedinorgid = 0;
        custs().buyerID = 0;

        String buyer_email = txtLoginEmail.Text;
        String password = txtLoginPassword.Text;

        if (custs().buyerID != 0) { custs().buyerID = 0; }

        else
        {
            if (custs().signedinorgid != 0) custs().signedinorgid = 0;
        }


        String prm = "P";


        //   String avail_request = Request.Form["avail_request"];

        int idd = 0;


        DataSet ds = new DataSet();
        //status = "";// drplstEmailSts.SelectedValue == "All" ? String.Empty : drplstEmailSts.SelectedValue;
        string commandText = "get_Logins";

        ds = r.getLogins(commandText, prm, buyer_email, password);



        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var strBuyerId = ds.Tables[0].Rows[0]["buyerid"].ToString();
            if (!string.IsNullOrEmpty(strBuyerId))
            {
                int buyerID = int.Parse(strBuyerId);
                if (Session["cust"] == null)
                {


                    BLCustomer cust = new BLCustomer(buyerID);
                    custs().CustName = ds.Tables[0].Rows[0]["buyer_name"].ToString();


                    Session["cust"] = cust;



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

            else
            {

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
            Response_End(sender, e);
            //}
        }


    }

    protected void Response_End(object sender, EventArgs e)
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

        return (BLItems)((BLCustomer)Session["cust"]).Organization.Orgitems;

    }



    public BLOrganization orgs()
    {
        return (BLOrganization)((BLCustomer)Session["cust"]).Organization;


    }




    public BLCustomer custs()
    {

        return ((BLCustomer)Session["cust"]);


    }




    public BLItem item()
    {
        return ((BLCustomer)Session["cust"]).Organization.Orgitems.Item;
    }








    public BLCustomer custs_
    {

        set
        {
            (Session["cust"]) = value;
        }

    }


}


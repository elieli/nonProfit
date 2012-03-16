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

public partial class simpleLoginPageBtn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnBidNow_Click();

    }






    protected void btnBidNow_Click()
    {
        custs().signedinorgid = 0;
        custs().buyerID = 0;


        custs().CustName = "";

        custs().signedinorgname = "";


      ///  custs_ = custs();
        (Application["cust"]) = custs();

        Response_End( );

    }








    protected void Response_End( )
    {

       // BLItem.raiseMenu(sender, e);

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



    public BLOrganization orgs()
    {
        return (BLOrganization)((BLCustomer)Application["cust"]).Organization;
    }




    public BLCustomer custs()
    {
        return ((BLCustomer)Application["cust"]);
    }




    public BLItem item()
    {
        return ((BLCustomer)Application["cust"]).Organization.Orgitems.Item;
    }




    public BLCustomer custs_
    {
         

        set
        {
            (Application["cust"]) = value;
        }

    }






}


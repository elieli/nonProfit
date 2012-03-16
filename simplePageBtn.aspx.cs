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

public partial class simplePageBtn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnBidNow_Click();

    }


    protected void btnBidNow_Click()
    {
       


        string prm = "X";

        int auctionid = items().AuctionID;// messages.auctionID;
        int buyerid = custs().ID ;

  /// DataSet     ds = items().Item.UpdateItems(prm, "get_Items", messages.auctionID);

        ///DateTime bid = ((BLCustomer)messages.cust).Organization.Orgitems.Item.UpdateItems(prm, "get_Bids", auctionid);
        DateTime bid = item().UpdateItems(prm, "get_Bids", auctionid, buyerid);


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

















}


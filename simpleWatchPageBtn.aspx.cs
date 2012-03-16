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

public partial class simpleWatchPageBtn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnBidNow_Click();

    }


    protected void btnBidNow_Click()
    {int  amount =0;
    int amt = 0;
        int auctionid = 0;
        int buyerid = custs().ID;// messages.cust.ID;


           if (Request.QueryString != null && Request.QueryString.Count>=1) 
             {

                 string query1 = ""; string query2 = "";  

                
                         query1 = Request.QueryString[0] != null ? Request.QueryString[0] : "";
                      /////   query2 = Request.QueryString[1] != null ? Request.QueryString[1] : "";


                         Int32.TryParse(query1, out auctionid);
                      ///   if (!string.IsNullOrEmpty(query2) && Int32.TryParse(query2, out amt)) { amount = amt; }
                      ///   

                         items().AuctionID = auctionid;
                         items().buyerID = custs().ID;
           }








        string commandName="get_watch";
        auctionid=0;
        int orgID=0;
        int buyerID=0;



        string prm = "I";
             
      ////  int auctionid = items().auctionID;


  /// DataSet     ds = items().Item.UpdateItems(prm, "get_Items", messages.auctionID);

       /// DateTime bid = ((BLCustomer)messages.cust).Organization.Orgitems.Item.UpdateItems(prm, "get_Bids", auctionid);



      ////  ((BLCustomer)messages.cust).Organization.Orgitems.Item.UpdateSponsors(auctionid, amount, buyerid);

     ////   BLItems.setWatch(commandName, prm, auctionid, orgID, buyerID);
       ///////// BLItems.setWatch(items() );

        items().setWatch(items());

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


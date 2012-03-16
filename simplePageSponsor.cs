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

public partial class simplePage : System.Web.UI.Page
{
    Referrer r = new Referrer();
    protected void Page_Load(object sender, EventArgs e)
    {
        string qry = Request.QueryString !=null  && Request.QueryString.Count>0 ?   Request.QueryString[0].ToString():  "" ;
        DataSet ds = new DataSet();
        String parm="Z";
             string commandtext="get_Items";
             int id = custs().ID;// 0;
        int orgid=0;
        int catid=0;
        int itemid =0;
        string status="";
        String auctiontype ="";
        int auctionid=     qry==null || qry == "" ?   0 :    (int) Convert.ToInt16 ( qry ) ;
        try
        {
        if (auctionid>0) {
        
       ///  ds= BLItem.GetAuctionItemt( item(), parm,   commandtext,   id,   orgid,   catid,   itemid,   status,   auctiontype,   auctionid);

         ds = item().GetAuctionItemt(item(), parm, commandtext, id, orgid, catid, itemid, status, auctiontype, auctionid);

         
        DataRow dr = ds.Tables[0].Rows[0];

        String Live =  dr["Live"].ToString();
        
            DateTime dtFuture = Convert.ToDateTime(dr["endTime"]);

            DateTime dtNow = new DateTime();
            // dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);
            dtNow = DateTime.Now;
            TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
            ts = dtFuture.Subtract(dtNow);
            long amountTime = (long)ts.TotalMilliseconds;
            HtmlContainerControl amount = (HtmlContainerControl)this.FindControl("amount");
            amount.InnerText = amountTime.ToString();// messages.amount_.ToString();
            // return amount;

      String buyerName = dr["buyer_name"].ToString();

      String currentbidPrice = dr["currentbidPrice"].ToString();


      String Credits = dr["Credits"].ToString();

      

        HtmlContainerControl buyer = (HtmlContainerControl)this.FindControl("buyer");
        buyer.InnerText = buyerName == null ? "" : buyerName.ToString();


        HtmlContainerControl price = (HtmlContainerControl)this.FindControl("price");
        price.InnerText = currentbidPrice.ToString();   //messages.currentBidAmount.ToString();



        HtmlContainerControl credits = (HtmlContainerControl)this.FindControl("credits");
        credits.InnerText = Credits.ToString();   //messages.currentBidAmount.ToString();



        HtmlContainerControl live = (HtmlContainerControl)this.FindControl("live");
        live.InnerText = Live.ToString();   //messages.currentBidAmount.ToString();


        
        } 
        }
        catch (Exception) { }
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

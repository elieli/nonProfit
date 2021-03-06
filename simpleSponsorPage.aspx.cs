﻿using System;
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

public partial class simpleSponsorPage : System.Web.UI.Page
{
    Referrer r = new Referrer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (custs() == null)
        {
            BLCustomer cust = new BLCustomer(0);
            Application["cust"] = cust;


        }
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
        
         ///ds= BLItem.GetAuctionItemt( item(), parm,   commandtext,   id,   orgid,   catid,   itemid,   status,   auctiontype,   auctionid);
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


      

        HtmlContainerControl buyer = (HtmlContainerControl)this.FindControl("buyer");
        buyer.InnerText = buyerName == null ? "" : buyerName.ToString();


        HtmlContainerControl price = (HtmlContainerControl)this.FindControl("price");
        price.InnerText = currentbidPrice.ToString();   //messages.currentBidAmount.ToString();

        HtmlContainerControl live = (HtmlContainerControl)this.FindControl("live");
        live.InnerText = Live.ToString();   //messages.currentBidAmount.ToString();
        } 
        }
        catch (Exception) { }


        DataSet dss = new DataSet();
        //  DataTable dt = new DataTable();
        // dt = ds.Tables[0];
       /// dss = bidst("T",auctionid);
        dss = bidst("B", auctionid);
        }




    protected DataSet bidst(string prm, int auid)
    {
        int orgid = orgs().orgID; ;
        int catid =  item().catID; ;
        int itemid = item().ID; ;
        string bidtype = messages.bidtype;
        int buyerid = custs().ID; ;
        DateTime biddate = DateTime.Now;
        Decimal bidamount = 0;// txtBidamount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtBidamount.Text);
        int credits = 3;
        int fee_per_bid = 0;
        int auctionid = auid;// messages.auctionID;
        String soldFixedBid = "";
        //string prm = "B";

        if (bidtype == "penny")
        {
            if (credits > 0) { bidamount = credits / 2 ; }
        }
        //string prm = "X";


        //if (messages.bidTimeLeft <= 0)
        //{
        //    if (bidamount == 0)
        //    {
        //        prm = "C";
        //        trOutofStock.Visible = true;
        //    }
        //    else { prm = "Z"; }

        //}

        //Decimal bid = UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);

        //prm = "B";


        UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);

        DataSet ds = new DataSet();


        String commandName = "get_Bids";
        String auctionType = "penny";

        int itemAuctionID = item().auctionID; ;
        int buyerID = custs().ID;

        ds = r.get_BidsLog(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);

        return ds;


    }



    protected DataSet UpdateItems(String parm, string commandtext, int id, int buyerID, DateTime biddate, Decimal bidamount, int credits, String soldFixedBid, int fee_per_bid)
    { // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = item().catID;            // 0;
        String location = "";
        String orgPaypal = "";
        String description = "";
        String condition = "";
        //String shippngCost = status; 
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = commandtext;

        String prm = parm;
        String auctionType = messages.bidtype;

        //  int credits = 3;

        int itemAuctionID = id;
        // status = "";
        Decimal bid = 0;
        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
         

                ds.Tables.Clear();
                ds = r.get_BidsLog(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);


        String   clogName="";

        foreach(DataRow row in ds.Tables[0].Rows )
        {
            clogName+=row["buyer_name"].ToString()+"," +row["bidprice"].ToString() +"&";
        }

        HtmlContainerControl bidlog = (HtmlContainerControl)this.FindControl("bidlog");
        bidlog.InnerText = clogName.ToString();   //messages.currentBidAmount.ToString();




        String sponsorLog="";

        
        HtmlContainerControl sponsors = (HtmlContainerControl)this.FindControl("sponsors");
        bidlog.InnerText = clogName.ToString();  

           DataSet dsSponsor = new DataSet();

        dsSponsor=items().Item.Sponsors;
         foreach(DataRow row in dsSponsor.Tables[0].Rows )
        {
            sponsorLog += row["buyer_name"].ToString() + "," + row["buyer_email"].ToString() + "," + row["sponsored"].ToString() + "&";
        }

         sponsors.InnerText = sponsorLog.ToString();  




        return ds;







           
     



            //if(  dtaset.Tables.Count>0  &&    dtaset.Tables[0].Rows.Count>0)
            ////lblHighestBidder.Text = dtaset.Tables[0].Rows[dtaset.Tables[0].Rows.Count-1].ItemArray[9].ToString();




       // }
        //return bid;
    }

    protected void rptData(Object sender, RepeaterItemEventArgs e)
    {


        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:

                DataRowView dtRow = (DataRowView)e.Item.DataItem;
                //hdnIndex = (HtmlInputHidden)e.Item.FindControl("hdnIndex");



                //style = dtRow[2].ToString().Substring(dtRow[2].ToString().IndexOf(':') + 1, dtRow[2].ToString().IndexOf(';') - dtRow[2].ToString().IndexOf(':') - 1);
                ///// style = " " + style + " ; display:block; border:solid 2px black; width:12px; height:12px;";

                //HtmlContainerControl vv = (HtmlContainerControl)e.Item.FindControl("vv");
                //hdnIndex.Value = e.Item.ItemIndex.ToString();///
                //index = e.Item.ItemIndex;
                //vv.Attributes.Add("onmouseover", "setvalue(" + index + ")");
                //vv.Style.Add("background-color", style);
                break;


        }


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

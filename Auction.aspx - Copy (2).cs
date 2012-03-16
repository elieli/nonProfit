/////*
////=====================================================
////' Project:      JomaDeals.com
////' Programmer:   Derek/Valentin
////' File:         default.aspx.cs
////' Description:  
////' Created:		07/09/09
////' Last Updated: 11/16/09
////'
////'=====================================================
////*/
/////*
////=====================================================
////' Project:      JomaDeals.com
////' Programmer:   Eli Barber
////' File:         default.aspx.cs
////' Description:  Redesign and revision of website
////' Created:		12/09/10
////' Last Updated: 12/09/10
////'
////'=====================================================
////*/
using System;
using System.Threading;

using System.Collections;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

//using MainStreet.BusinessFlow.SDK;
//using MainStreet.BusinessFlow.SDK.Web;
//using MainStreet.BusinessFlow.SDK.Ws;

using System.Configuration;


public partial class Auction : System.Web.UI.Page
{
    public String buyer_names;
    Decimal credits_ = 0;

    public int BuyerID;
    DataSet dtaset = new DataSet();
    protected string style;
    ProductDetails p;
    DataTable dtItemDetail;
    protected String Sdomain ="";//    ConfigurationManager.AppSettings["Landing"].ToString().ToLower();
    String WebsiteUrl =  "";// ConfigurationManager.AppSettings["WebsiteUrl"].ToString().ToLower();
      
    Referrer r = new Referrer();
    public int index = 0; bool InDebugMode = false;
    public int auction_id;
    public string org_name;

    protected String ProductTitle; protected String Link;
    public string knowtxt = "";
    public string knowtxt_ = "";
    protected string relLink;
    protected string PriceFormated1;
    protected string ProductURL1;
       protected string  ImageLogoURL1;
       protected string CompanyName1;


       protected string PriceFormated2;
       protected string ProductURL2;
       protected string ImageLogoURL2;
       protected string CompanyName2;
     
    static string prefix = ""; 
   
    protected string reprow;
    protected string Message = "";
    protected string MediumImageWidth = "";
    protected string MediumImageHeight = "";
    protected string ImageDesc = "";
    protected string CompareSaveText = "";
    protected string BrowseCollectionBanner = "";
    protected string ImageUrl1; 
    protected string ImageUrls;
            protected string          Link1  ;
            protected string ImageTitle2; 
    protected string ImageTitle;
            protected string ImageUrl2;
            protected string Link2;
            protected string ImageTitle1; HtmlInputHidden hdnIndex;

    public string ProductTitles
    {
        get
        {
            try
            {
                return "";// PrgFunctions.TryCastString(ViewState["ProductTitle"]);
            }
            catch
            {
                return "";
            }
        }
        set
        {
            ViewState["ProductTitle"] = value;
        }
    }

    #region "Properties"
    //*Properties


    private string m_MediumImageUrl;
    public string MediumImageUrl
    {
        get
        {
            try
            {
                return m_MediumImageUrl;// PrgFunctions.TryCastString(ViewState["MediumImageUrl"].ToString());
            }
            catch
            {
                return "";
            }
        }
        set
        {
            m_MediumImageUrl = value;

            ViewState["MediumImageUrl"] = value;
        }
    }


    public string LinkToFullImage
    {
        get
        {
            try
            {
                return "";// PrgFunctions.TryCastString(ViewState["LinkToFullImage"].ToString());
            }
            catch
            {
                return "";
            }
        }
        set
        {
            ViewState["LinkToFullImage"] = value;
        }
    }


    public decimal SpecialItemCost
    {
        get
        {
            return 0;// PrgFunctions.TryCastDecimal(Application[prefix + "SpecialItemCost"]);
        }
        set
        {
            Application[prefix + "SpecialItemCost"] = value;
        }
    }


    public int FreeShipping
    {
        get
        {
            return 0;// PrgFunctions.TryCastInt(Application[prefix + "FreeShipping"]);
        }
        set
        {
            Application[prefix + "FreeShipping"] = value;
        }
    }


    public string DisplayVariationGuid
    {
        get
        {
            try
            {
                
                return "";// PrgFunctions(.TryCastString(ViewState["DisplayVariationGuid"]);
            }
            catch
            {
                return "";
            }
        }
        set
        {
            ViewState["DisplayVariationGuid"] = value;
        }
    }
    #endregion





















    private ProductDetails getDetails()
    {
        bool outOfDate = false;

        //Get the current date time
        DateTime dt = DateTime.Now;
        outOfDate = true;
        
        //Application init/null
      if ((Application == null) || (Application[prefix + "DateTimeCached"] == null) || (Convert.ToDateTime(Application[prefix + "DateTimeCached"]).Date != dt.Date) || (Application[prefix + "Product"] == null))
        outOfDate = true;

       

        if (outOfDate)
        {
            //Added in to ensure child item was not reloaded
            DisplayVariationGuid = "";

            Application.Lock();

         

            // Retrieve deals for today 
 
            string commandName = "v_getDeals";
            string dealDate = "";
            string site = prefix;
            string opt = "6";
            string title = "";
            string status = "";
            string itemcode = "";
            string eventid = "";

            DataSet ds = new DataSet();// r.GetDeals(commandName, dealDate, site, eventid, itemcode, title, status, opt);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                itemcode =  ds.Tables[0].Rows[0][0].ToString();
                SpecialItemCost = (decimal)ds.Tables[0].Rows[0][1];
                FreeShipping = (int)ds.Tables[0].Rows[0][2];
             Session["id"]=  (int)ds.Tables[0].Rows[0][3];



                //if (FreeShipping == 1)
                //{
                //    freeship.Visible = true;
                //}
                //else { freeship.Visible = false; }


            }

            //Get the product details
           ////////////// Application[prefix + "Product"] = new ProductDetails(itemcode);
            Application[prefix + "DateTimeCached"] = DateTime.Now.Date;

            Application.UnLock();
          }

            return (ProductDetails)Application[prefix + "Product"];
        
    }






        protected void lvDisplayVariations_OnItemDataBound(object sender, DataListItemEventArgs e)
        {   
           
            switch (e.Item.ItemType)
            {
                case  ListItemType.Item:
                case ListItemType.AlternatingItem:

                    DataRowView dtRow =  (DataRowView) e.Item.DataItem;
                    hdnIndex = (HtmlInputHidden)e.Item.FindControl("hdnIndex");



                    style = dtRow[2].ToString().Substring(dtRow[2].ToString().IndexOf(':')+1, dtRow[2].ToString().IndexOf(';') - dtRow[2].ToString().IndexOf(':') -1);
                   /// style = " " + style + " ; display:block; border:solid 2px black; width:12px; height:12px;";

                      HtmlContainerControl vv = (HtmlContainerControl)e.Item.FindControl("vv");
                    hdnIndex.Value =  e.Item.ItemIndex.ToString();///
                    index  = e.Item.ItemIndex ;
                    vv.Attributes.Add("onmouseover", "setvalue(" + index + ")");
                    vv.Style.Add("background-color", style);
                    break;


            }


    }






    // roll over images to change big image 

    protected void otherView(object sender, CommandEventArgs e)
    {

       goto skip;


     DataTable  dtimagesThumb =(DataTable) Session["dtimagesThumb"] ;  


        DataTable dtimagesThumb3 = new DataTable();
        dtimagesThumb3 = dtimagesThumb.Clone();

        DataSet dst = new DataSet();
        dst.Tables.Add("dtimagesThumb3");
       
        int cntrow = 0; int cntrows = 3;
        if (e.CommandArgument.ToString() == "right" && dtimagesThumb.Rows.Count > 3)
            cntrows = dtimagesThumb.Rows.Count - 3;
        

        foreach (DataRow rows_ in dtimagesThumb.Rows)
        {
            if ((cntrow >= cntrows && e.CommandArgument.ToString() == "right") || (cntrow < cntrows && e.CommandArgument.ToString() == "left"))
              

            dtimagesThumb3.ImportRow(rows_);
           
            cntrow += 1;
        }

        iqimagesThumb.DataSource = dtimagesThumb3;
        iqimagesThumb.DataBind();
    skip: ;
    }


    protected override void OnInit(EventArgs e)
    {
    }



    protected   void bidsLog(Object sender,   EventArgs e)
    {
        int orgid = messages.cust.Organization.ID;// Convert.ToInt16(messages.orgID);
        int catid = messages.blitem.catID;// Convert.ToInt16(messages.catID);
        int itemid = messages.blitem.ID;// Convert.ToInt16(messages.itemID);
        string bidtype = messages.bidtype;
        int buyerid = messages.cust.ID;// mes
    
        
        
        
         
       
        DateTime biddate = DateTime.Now;
        ///////////////////Decimal bidamount = txtBidamount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtBidamount.Text);
        int credits = 3;
        int fee_per_bid = 0;
        int auctionid = messages.auctionID;
        String soldFixedBid = "";
        string prm = "B";

        //////if (bidtype == "penny")
        //////{
        //////    if (credits > 0) { bidamount = credits * 5; }
        //////}
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

        prm = "B";


        //UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);

        DataSet ds = new DataSet();
        ds = dtaset;

    
    }

   


    protected DataSet bidst(string prm)
    {
        int orgid = messages.cust.Organization.ID; ;
        int catid = messages.blitem.catID; ;
        int itemid = messages.blitem.ID; ;
        string bidtype = messages.bidtype;
        int buyerid = messages.cust.ID; ;
        DateTime biddate = DateTime.Now;
        Decimal bidamount = txtBidamount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtBidamount.Text);
        int credits = 3;
        int fee_per_bid = 0;
        int auctionid = messages.auctionID;
        String soldFixedBid = "";
        //string prm = "B";

        if (bidtype == "penny")
        {
            if (credits > 0) { bidamount = credits * 5; }
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

        int itemAuctionID = messages.blitem.auctionID; ;
        int buyerID = messages.cust.ID;

        ds = r.get_BidsLog(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);

        return ds;


    }



    protected   Decimal  UpdateItems(String parm, string commandtext, int id, int buyerID, DateTime biddate, Decimal bidamount, int credits, String soldFixedBid, int fee_per_bid)
    { // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = messages.blitem.catID;            // 0;
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
        //   string commandName;

        //   DateTime biddate;
         
        //    string commandName, string prm,   int itemAuctionID, int buyerID, int storeID,
        //int quantity, int quantityAllocated, int shipping, Decimal startBidPrice, Decimal currentBidPrice, int soldAmount,
        //int buyitNow, int percentAllocated, int amountAllocated, int soldFixedBid, string condition, int returnDays,
        //String returnPolicy, DateTime startTime, DateTime endTime, DateTime soldTime, string paypalEmail, int handlingTime, String auctiontype, int credits,
        //string imgPath
        if (prm == "X" || prm == "C" || prm == "Z")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            bid = r.get_Bids(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);
        }
            else
            
        {
            if (prm == "S" || prm == "B"   )
         
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            {

                dtaset.Tables.Clear();
                dtaset = r.get_BidsLog(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);





        }


            //lstCreditLog.DataSource = dtaset.Tables[0];

            //lstCreditLog.DataBind();



            //if(  dtaset.Tables.Count>0  &&    dtaset.Tables[0].Rows.Count>0)
            ////lblHighestBidder.Text = dtaset.Tables[0].Rows[dtaset.Tables[0].Rows.Count-1].ItemArray[9].ToString();


         

         }
        return bid;
    }

    protected void rptData(Object sender ,  RepeaterItemEventArgs e)
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

    



    protected DataSet UpdateDonate(String parm, string commandtext, int id, int orgid, int catid, int itemid, string status, String auctiontype, int auctionid )
    {

      //  int itemid = 0;
        // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        ////  catid = messages.blitem.catID;
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


        int credits = 1;


        status = "";

        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
        //   string commandName;

        if (prm == "S" || prm == "Z")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm, itemid, orgid, catid, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype,auctionid  
     );







        }




        return ds;
    }





    protected override void OnPreRender(EventArgs e)
    {
         
    }




    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:

                DataRowView dtRow = (DataRowView)e.Item.DataItem;
                //hdnIndex = (HtmlInputHidden)e.Item.FindControl("hdnIndex");

                int length = dtRow.Row[10].ToString().Trim().Length;



              /////////////  dtRow.Row[10] = dtRow.Row[10].ToString().Trim().Substring(0, length>=11 ? 11 : length);

 
                break;

                //totalCreditsUsed,
                //        totalBidAmount
						
        }

    }





    protected void build(string prm, string soldFixedBid)
    {
        HtmlContainerControl trOutofStock = (HtmlContainerControl)UpdatePanel1.FindControl("trOutofStock");
       //////// trOutofStock.Visible = false;

        DataTable dt = new DataTable();
      //  String soldFixedBid = "bid";

        int orgid = messages.cust.Organization.ID;// Convert.ToInt16(messages.orgID);
        int catid = messages.blitem.catID;// Convert.ToInt16(messages.catID);
        int itemid = messages.blitem.ID;// Convert.ToInt16(messages.itemID);
        string bidtype = messages.bidtype;
        int buyerid = messages.cust.ID;// messages.buyerID;
        DateTime biddate = DateTime.Now;
        Decimal bidamount = txtBidamount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtBidamount.Text);
        int credits = 1;
        int fee_per_bid = 0;
        int auctionid = messages.auctionID;


        if (bidtype == "penny")
        {
            if (credits > 0) { bidamount = credits * 1; }
        }
        //string prm = "X";


        ////////////if (messages.bidTimeLeft <= 0)
        ////////////{
        ////////////    if (bidamount == 0)
        ////////////    {
        ////////////        prm = "C"; 
        ////////////        trOutofStock.Visible = true;
        ////////////    }
        ////////////    else { prm = "Z"; }

        ////////////}

        Decimal bid = UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);



        //////prm = "E";
        //////Decimal credtsowned = UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);



        //////messages.credits  = Convert.ToInt32( credtsowned) ;


       






        ////lblCurrentBidPrice.Text = bid.ToString();



        //////////if (prm == "C")
        //////////{


        //////////    txtBidamount.Visible = false;//.Text = bid.ToString();

        //////////  //  btnBuyNow.Visible = false;
        //////////    lblCurrentBidPrice.Text = "0";// lblCurrentBidPrice = bid.ToString();
        //////////    btnBidder.Visible = false;
        //////////}

        if (prm == "Z" || prm == "X")
        {

            prm = "Z";
            txtBidamount.Visible= false;//.Text = bid.ToString();

            //btnBuyNow.Visible = false;
         //////////////////   lblCurrentBidPrice.Text = bid.ToString();
            //btnBidder.Visible = false;


            //prm = "X";
            DataSet ds = new DataSet();



           /// ds = UpdateDonate(prm, "get_Items", 0, catid, orgid, itemid, "", bidtype,messages.auctionID);

            ds = BLItem.GetAuctionItemt(prm, "get_Items", 0, catid, orgid, itemid, "", bidtype, messages.auctionID);

            dt = ds.Tables[0];


            DataRow dr = dt.Rows[0];

            bidValues(dr);
        }
    }







    protected void bidValues(DataRow dr)
    {
        DataSet ds = new DataSet();
      //  DataTable dt = new DataTable();
       // dt = ds.Tables[0];
        ds = bidst("T");








        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)  
        {
      

        DataRow dtr = ds.Tables[0].Rows[0];

        Decimal Tbidamount = dtr["bidamount"].ToString() == string.Empty ? 0 : Convert.ToDecimal(String.Format("{0:d}"  ,dtr["bidamount"].ToString()));

        int Tcredits = dtr["credits"].ToString() == string.Empty ? 0 : Convert.ToInt16(dtr["credits"].ToString());


        lblCreditsUsed.Text = Tcredits.ToString();
        lblMoneySpent.Text =String.Format("{0:d}", Tbidamount.ToString());
       // lblMoneySpent.Text = String.Format("{0:d}", MoneySpent.ToString());
       // lblCreditsUsed.Text = credits.ToString();
                                   
        }
        
        
               

        DateTime startTime = Convert.ToDateTime(dr["startTime"].ToString());
     //   DateTime endDate = Convert.ToDateTime(dr["endDate"].ToString());
        DateTime soldTime = Convert.ToDateTime(dr["soldTime"].ToString());
        int buyitNow = dr["buyitNow"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["buyitNow"].ToString());
        String shipping  = dr["shipping"].ToString() == string.Empty ? "0" : dr["shipping"].ToString();
        int handlingTime = dr["handlingTime"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["handlingTime"].ToString());
        DateTime endTime = Convert.ToDateTime(dr["endTime"].ToString());
        ////DateTime endTime1 = Convert.ToDateTime(dr["endTime1"].ToString());
        ////DateTime endTime2 = Convert.ToDateTime(dr["endTime2"].ToString());
        ////DateTime endTime3 = Convert.ToDateTime(dr["endTime1"].ToString());







        String startBidPrice = dr["startBidPrice"].ToString() == string.Empty ? "0" : dr["startBidPrice"].ToString();
        String currentBidPrice = dr["currentBidPrice"].ToString() == string.Empty ? "0" : dr["currentBidPrice"].ToString();
        String title = dr["title"].ToString();
        String buyer_name = dr["buyer_name"].ToString();
  
        
        String condition = dr["condition"].ToString();
        String itemStatus = dr["itemStatus"].ToString();
        String auctiontype = dr["auctiontype"].ToString();


        Decimal fixedprice = dr["fixedprice"].ToString() == string.Empty ? 0 : Convert.ToDecimal(String.Format("{0:d}", dr["fixedprice"].ToString()));

        lblCartPrice.Text = String.Format("{0:d}", currentBidPrice.ToString());
      
        
        
        
        
        
        
        ///lblHighestBidder.Text = buyer_name;


        int credits = dr["credits"] == null  || dr["credits"].ToString() == ""  ? 0 :   Convert.ToInt16(dr["credits"].ToString() ) ;
        int buyerid = dr["buyerid"] == null || dr["buyerid"].ToString() == "" ? 0 : Convert.ToInt16(dr["buyerid"].ToString());
     
      
        
        
        
        
        
        //messages.credits=credits ;

       decimal  MoneySpent = Convert.ToDecimal( (credits * .60) );

        
      //  String itemStatus = dr["itemStatus"].ToString();

        Decimal soldAmount =  Convert.ToDecimal(  String.Format("{0:c}"  ,dr["soldAmount"].ToString() ) );



        int returnDays = dr["returnDays"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["returnDays"].ToString());
        int quantity = dr["quantity"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["quantity"].ToString());

      //  messages.bidEndTime =   endTime ;





        lblSold.Text = "";
        DateTime dtNow = new DateTime();


        dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);

        DateTime dtFuture = new DateTime();//  (messages.bidEndTime.Year, messages.bidEndTime.Month, messages.bidEndTime.Day, messages.bidEndTime.Minute, messages.bidEndTime.Second, messages.bidEndTime.Millisecond);//        dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

        dtFuture = messages.bidEndTime;

        TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
        ts = dtFuture.Subtract(dtNow);
        long amount = (long)ts.TotalMilliseconds;

        messages.bidTimeLeft = amount;

        amount = messages.amount_;

        if (amount <= 0)
        {
            //btnBidder.Visible = false;
            if (buyerid == 0)
            { lblSold.Text = "Canceled"; }
            else { lblSold.Text = "Sold"; }
        }
        else 
        
        { 
            //if(credits==0)
            if (((BLCustomer)messages.cust).Credits <= 0)

            {
               // btnBidder.Enabled = false;
                lblSold.Text = "out of credits please buy more";
            }
            //btnBidder.Visible = true; 
        
        }


                       



      //  lblCondition.Text = condition;
       // lblCurrentBidPrice.Text =    String.Format( Double.Parse(currentBidPrice).ToString(), "$0,00.00");
       
       // lblProductTitles.Text = title;
       ///// lblStartBidPrice.Text = String.Format( startBidPrice, "$0,00.00") ;
       // lblHandling.Text = handlingTime.ToString();

        lblShipping.Text = shipping;

      ///  lblReturndays.Text = returnDays.ToString();

        //lblAuctiontype.Text = auctiontype;


       // String[] img = { dr["imgPath1"].ToString(), dr["imgPath2"].ToString(), dr["imgPath3"].ToString(), dr["imgPath4"].ToString() };// new String[5];
      

        String[] img = { dr["img1"].ToString(), dr["img2"].ToString(), dr["img3"].ToString(), dr["img4"].ToString() };// new String[5];
        DataTable  dt = new DataTable(  );
       

            dt=getimages(  img    );

            iqimagesThumb.DataSource = dt;

            iqimagesThumb.DataBind();





         /////////////   lblDonated.Text =  messages.donatecount.ToString();


    }





    // get_Bids(string commandName, string prm, int itemAuctionID, int buyerID, DateTime biddate,
    // decimal bidamount,  int credits,
    //    string soldFixedBid, int fee_per_bid, string auctionType)
    //{





    protected void Page_Load(object sender, EventArgs e)
     {







         string qry = Request.QueryString != null && Request.QueryString.Count > 0 ? Request.QueryString[0].ToString() : "";
      
         int auctionid_ = qry == null || qry == "" ? 0 : (int)Convert.ToInt16(qry);

         auction_id = auctionid_;

      

         items().Item.auctionID = auctionid_;
         org_name = BLOrganization.orgTitle;


         if (messages.orgs_.ID == null || messages.orgs_.ID == 0) 
         {
             items().GetOrgbyAuctionID(auctionid_);
         
         }
       




       //  DateTime amount_;

       //  Auction a = new Auction();
       //  //#region "Landing"
       //long amounter;
       //Thread oThread = new Thread(new ThreadStart( this.timeing()));

         //// Start the thread
         //oThread.Start();

         //// Spin for a while waiting for the started thread to become
         //// alive:
         //while (!oThread.IsAlive) ;

         //// Put the Main thread to sleep for 1 millisecond to allow oThread
         //// to do some work:
         //Thread.Sleep(1);

         //// Request that oThread be stopped
         //oThread.Abort();



         buyer_names = BLCustomer.CustName;// dr["buyer_name"].ToString();
         BuyerID = BLCustomer.buyerID;
         int buyerid = BuyerID;// messages.cust.ID;
         string commandName = "get_Credits";
         string prm = "E";


         ////////Decimal credits_ = r.get_Credits(commandName, prm, buyerid, 0);




         ////////((BLCustomer)messages.cust).Credits = r.get_Credits(commandName, prm, buyerid, 0);

         int credits_ = messages.credits ;
        
        
        
        //string  prm = "E";



        //Decimal credtsowned = r.get_Bids("get_Bids", prm, messages.auctionID, messages.buyerID, DateTime.Today, 0, 0, "", 0, "");



       /////////// messages.credits = Convert.ToInt32(credits_);

         bidsLog( sender,     e);


      //   items().rowlimit = 4;


         int catid = 0;

         int orgid = messages.orgs_.ID;// Convert.ToInt16(drplstOrgs.SelectedValue.ToString());

         orgid = messages.orgs_.ID;//  12;
         messages.itemID = messages.orgs_.Orgitems.Item.ID;
         catid = messages.orgs_.Orgitems.CatID;// 12;




         DataView dv;
         DataSet dss = new DataSet();


         //  categoryProduct
        
       ////// dss =  messages.getItems("S", "get_Items", 0, catid, orgid, "");
   // dss = messages.getItems("Q", "get_Items", 0, catid, orgid, "");
         dss = BLItems.GetItemsList("V", "get_Items", 0, orgid, catid, "");



         dv = new DataView(dss.Tables[0]);

         int rowLimit = 4;

         // dv.RowFilter = "";


         ///   dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();



         //  return dataTable;



         ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

         DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");

     
        ////////////HtmlContainerControl dvPageing = (HtmlContainerControl)(MainContent.FindControl("dvPageing");
  

        /// HtmlContainerControl dvPageing = (HtmlContainerControl)(MainContent.FindControl("orgProducts2")).FindControl("dvPageing");
        //////// dvPageing.Visible = false;


         ////////////////////UserControl category1 = (UserControl)Page.FindControl("category1");
         ////////////////////DataList catlstbx = (DataList)category1.FindControl("catlstbx");


         ////////////////////TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");
         ////////////////////TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

         //String txtPriceStarts = txtPriceStart.Text;
         //String txtPriceEnds = txtPriceEnd.Text;
         ////String filter = catlstbx.SelectedItem.ToString() + " "; ;

         ////dv.RowFilter = filter;
         ////dv.RowFilter = filter + "'cartPrice' >  txtPriceStarts and 'cartPrice' < txtPriceEnds ";

         //UserControl uc = (UserControl)this.FindControl("orgProducts2");

         //DataList dtalstItems = (DataList)uc.FindControl("dtalstItems");



         DataTable dataTable = dv.ToTable();







         DataTable datatable = new DataTable();
         datatable = dataTable.Clone();




         for (int x = 0; x < 4   ; x++)
         {
             //if (x < page || x > page + rowLimit)
             //{

             datatable.ImportRow(dataTable.Rows[x]);

             ////////// dataTable.Rows[x].Delete();
             //}
         }








         ////while (dataTable.Rows.Count > rowLimit)
         ////    dataTable.Rows[dataTable.Rows.Count - 1].Delete();

         ///   dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();



         //  return dataTable;



         dtalstItems.DataSource = datatable;// ds;

         dtalstItems.DataBind();










        

        
        
        ////int credits = messages.credits ;

       ///  ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
         ////////HtmlGenericControl pOtherViews = (HtmlGenericControl)MainContent.FindControl("pOtherViews");
         ////////pOtherViews.InnerHtml = "you have a total of " + credits_ + " credits ";


         HtmlTextArea txtarKnow = (HtmlTextArea)MainContent.FindControl("txtarKnow");
    
         txtarKnow.Value = messages.orgs_.Know;









         if (!IsPostBack)
         {




             
     
        //HtmlContainerControl hdnTimer = (HtmlContainerControl)this.FindControl("hdnTimer.ClientID");

        //HtmlContainerControl hdnTimer1 = (HtmlContainerControl)this.FindControl("hdnTimer1");

        //HtmlContainerControl hdnTimer2 = (HtmlContainerControl)this.FindControl("hdnTimer2");

        //HtmlContainerControl hdnTimer3 = (HtmlContainerControl)this.FindControl("hdnTimer3");

        //HtmlContainerControl dvAuction = (HtmlContainerControl)this.FindControl("dvAuction");

        //HtmlContainerControl dvBuyer = (HtmlContainerControl)MainContent.FindControl("dvBuyer");
        //HtmlContainerControl hdnamount = (HtmlContainerControl)this.FindControl("hdnamount");

        //if (hdnTimer != null)
        //{
        //    //dvAuction.InnerHtml = messages.orgs_.Orgitems.Item.auctionID.ToString();



        //    //dvBuyer.InnerHtml = messages.cust.ID.ToString();
        //    hdnamount.InnerText = messages.amount_.ToString();




        //    hdnTimer.InnerHtml = messages.amount_.ToString();
            //hdnTimer1.InnerHtml =  messages.amount1.ToString();
            //hdnTimer2.InnerHtml =  messages.amount2.ToString();

            //hdnTimer3.InnerHtml =  messages.amount3.ToString();






        //}


             int aid = 0;
             int id = 0; int cid = 0;

             if (Request.QueryString != null && Request.QueryString.Count>=1) 
             {

                 string query1 = ""; string query2 = ""; string query3 = "";


                 switch (Request.QueryString.Count)
                 {
                     case 1:
                         query1 = Request.QueryString[0] != null ? Request.QueryString[0] : "";
                         break;

                     case 2:
                       query1 = Request.QueryString[0] != null ? Request.QueryString[0] : "";
                    
                        query2 = Request.QueryString[1] != null ? Request.QueryString[1] : "";
                         break;

                     case 3:
                         query1 = Request.QueryString[0] != null ? Request.QueryString[0] : "";

                          query2 = Request.QueryString[1] != null ? Request.QueryString[1] : "";
                         query3 = Request.QueryString[2] != null ? Request.QueryString[2] : "";
                         break;
                 }

            
             
           



             if (!string.IsNullOrEmpty(query1) && Int32.TryParse(query1, out aid))
             {
                 ((BLCustomer)messages.cust).Organization.Orgitems.Item.auctionID = aid;
         
                // messages.auctionID = Request.QueryString[0] != null && Request.QueryString.ToString() != "" ? Convert.ToInt16(Request.QueryString[0].ToString()) : 0;
              
             }

             if (!string.IsNullOrEmpty(query2) && Int32.TryParse(query2, out cid))
             {
                /// messages.itemID = Request.QueryString[1] != null && Request.QueryString[1].ToString() != "" ? Convert.ToInt16(Request.QueryString[1].ToString()) : 0;

                 /// ((BLCustomer)messages.cust).Organization.Orgitems = new BLItems();
                 ((BLCustomer)messages.cust).Organization.Orgitems.Item.catID = cid;

             }
             if (!string.IsNullOrEmpty(query3) && Int32.TryParse(query3, out id))
             {
                 ///messages.itemID = Request.QueryString[1] != null && Request.QueryString[1].ToString() != "" ? Convert.ToInt16(Request.QueryString[1].ToString()) : 0;

                 /// ((BLCustomer)messages.cust).Organization.Orgitems = new BLItems();
                 ((BLCustomer)messages.cust).Organization.Orgitems.Item.ID = id;

             }
             }
  


             messages.bidtype = "penny";
             ///////////////////////messages.buyerID = 6;
          //   messages.auctionID = 2;

             messages.orgLogo = "images/RZD029.jpg";
            




             /////// load();
             /////////// loadChildInformation();
             ///////////// Session["init"] = "init";

         }



         DataTable dt = new DataTable();

         DataSet ds = new DataSet();


        HtmlButton btnPreview = (HtmlButton)this.FindControl("btnPreview");


        orgid = messages.cust.Organization.ID;// Convert.ToInt16(messages.orgID);
       catid = messages.blitem.catID;// Convert.ToInt16(messages.catID);
    int   itemids = messages.blitem.ID;// Convert.ToInt16(messages.itemID);
          buyerid = messages.cust.ID;// mes
    




         
        string bidtype = messages.bidtype;

      /////////////////  int auctionid = messages.orgs_.Orgitems.auctionID;


        ds = UpdateDonate("Z", "get_Items", 0, catid, orgid, itemids, "", bidtype, auction_id);

        if (ds.Tables.Count>0)
        {

        
        dt =  ds.Tables[0];


        DataRow dr = dt.Rows.Count > 0 ? dt.Rows[0] : null;

        if (dr != null) bidValues(dr);
        }

    }











    // checks if landing page wasspecified in back end then goes first time to that page else goes to watches
    //private string GetLandingFromXml()
    //{ 
    //    string Landing;
    //    XmlDocument xDoc = new XmlDocument();
    //    string XmlFilePath = Request.MapPath("~\\XML\\changeText.xml");
    //    xDoc.Load(XmlFilePath);

    //    XmlNode xn = xDoc.SelectSingleNode("JomaExl/changeText/landing");
    //    Landing = xn.InnerText;


    //    DateTime landingdate;

    //    TimeSpan tsd = TimeSpan.FromDays(2);



    //    xn = xDoc.SelectSingleNode("JomaExl/changeText/landingdate");
    //    landingdate = Convert.ToDateTime(xn.InnerText);

    //    if (landingdate < DateTime.Today.Add(-tsd))
    //    {

    //        xn = xDoc.SelectSingleNode("JomaExl/changeText/landingdefault");
    //        Landing = xn.InnerText;


    //    }
        

    //       xn = null;
    //    xDoc = null;
    //    return Landing;
    //}

    //protected DataTable getAttributes(ProductDetails p)
    //{
    //    DataTable dt = new DataTable();
    //    dt.Columns.Add(new DataColumn("attribute_description"));
    //    dt.Columns.Add(new DataColumn("attribute_label"));
    //    dt.Columns.Add(new DataColumn("attribute_value"));

        

    //    DataView dv = p.GetAttributesView();

    //    if ((dv != null) && (dv.Count > 0))
    //    {
    //        DataRow dr = null;
    //        string val = "";

    //        foreach (DataRowView drv in dv)
    //        {
    //            val = "";
    //            dr = dt.NewRow();

    //            val = PrgFunctions.TryCastString(drv["attribute_value"]);

    //            if (val.Length > 0)
    //            {
    //                dr["attribute_label"] = PrgFunctions.TryCastString(drv["attribute_label"]) + ":";
    //                dr["attribute_value"] = val;
    //                dr["attribute_description"] = PrgFunctions.TryCastString(drv["attribute_description"]);

    //                dt.Rows.Add(dr);
    //            }
    //        }
    //    }

    //    return dt;
    //}


    protected DataTable getCompareSave(ProductDetails p)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("ImageLogoURL"));
        dt.Columns.Add(new DataColumn("Price"));
        dt.Columns.Add(new DataColumn("PriceFormated"));
        dt.Columns.Add(new DataColumn("CompanyName"));
        dt.Columns.Add(new DataColumn("ProductUrl"));

        

        //DataRow drItem = p.GetItemRow();

        //for (int i = 1; i <= 5; i++)
        //{
        //    DataRow drNew = dt.NewRow();

        //    if (!PrgFunctions.IsNullOrEmpty(drItem["CompareAndSaveLink" + i.ToString()]))
        //    {
        //        drNew["ProductUrl"] = drItem["CompareAndSaveLink" + i.ToString()];
        //    }
        //    else
        //    {
        //        drNew["ProductUrl"] = "";
        //    }

        //    if (!PrgFunctions.IsNullOrEmpty(drItem["CompareAndSaveIcon" + i.ToString()]))
        //    {
        //        drNew["ImageLogoURL"] = drItem["CompareAndSaveIcon" + i.ToString()].ToString().TrimStart('/');
        //    }
        //    else
        //    {
        //        drNew["ImageLogoURL"] = "";
        //    }

        //    if (!PrgFunctions.IsNullOrEmpty(drItem["CompareAndSavePrice" + i.ToString()]))
        //    {
        //        drNew["Price"] = drItem["CompareAndSavePrice" + i.ToString()];
        //    }
        //    else
        //    {
        //        drNew["Price"] = "";
        //    }

        //    if (!PrgFunctions.IsNullOrEmpty(drItem["CompareAndSaveName" + i.ToString()]))
        //    {
        //        drNew["CompanyName"] = drItem["CompareAndSaveName" + i.ToString()];
        //    }
        //    else
        //    {
        //        drNew["CompanyName"] = "";
        //    }

        //    if (!string.IsNullOrEmpty(drNew["Price"].ToString()))
        //    {
        //        if (drNew["CompanyName"].ToString().Length > 30)
        //        {
        //            drNew["CompanyName"] =
        //                drNew["CompanyName"].ToString().Substring(0, drNew["CompanyName"].ToString().Length / 4).ToString();
        //        } 
        //        dt.Rows.Add(drNew);
        //    }
        //}

        return dt;
    }





















    private DataTable getItemDetail(ProductDetails p)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("Price"));
        dt.Columns.Add(new DataColumn("Retail"));
        dt.Columns.Add(new DataColumn("Title"));
        dt.Columns.Add(new DataColumn("Description"));
        dt.Columns.Add(new DataColumn("AboutBrand"));
        dt.Columns.Add(new DataColumn("ItemDetail"));
        dt.Columns.Add(new DataColumn("ImageUrlThumb"));
        dt.Columns.Add(new DataColumn("ImageUrlZoom"));

        dt.Columns.Add(new DataColumn("ImageUrlMain"));
        dt.Columns.Add(new DataColumn("ImageUrlMainWidth"));
        dt.Columns.Add(new DataColumn("ImageUrlMainHeight"));

        dt.Columns.Add(new DataColumn("ImageUrlFull"));
        dt.Columns.Add(new DataColumn("ImageUrlFullWidth"));
        dt.Columns.Add(new DataColumn("ImageUrlFullHeight"));

        DataRow dr;

        dr = dt.NewRow();

     //   dr["Retail"] = p.GetRetailPrice();
        dr["Price"] = SpecialItemCost;
    //    dr["Title"] = p.GetTitle();

        //Get the brand
        string brand = "";// p.GetStringFieldOrAttribute("Brand");

        //Converted from choice value guid to its label
        object result = null;// BusinessFlow.WebServices.LookupTables[LookupTables.AttributeValues].TranslateToLabel(brand, "");

        if (result != null)
            brand = result.ToString();

        if (brand.Length != 0)
        {
            //dr["AboutBrand"] ="Rolex is considered to be one of the most prolific Swiss wristwatch manufacturing companies in the world. With their sheer elegance and uncompromising attention to detail, Rolex is the largest luxury watch brand worldwide, producing around 200 watches per day. Since its inception in 1905, Rolex has exuded an aura of unsurpassed urbanity. Unveiled in 1945, the Rolex Oyster Perpetual Datejust was the first wristwatch to display the date and boast a Cyclops magnifying lens. Similarly, the Rolex Oyster Perpetual Cosmograph Daytona, introduced 1988, is designed for measuring elapsed time and calculating average speed with artistic precision. Rolex, an eclectic company, had the maritime adventurer in mind when it created the Oyster Perpetual Submariner with water resistance at depths of 300 meters. All Rolex watches, whether the Rolex Air-King, Rolex Pearlmaster, Rolex Explorer, Rolex Day-Date, Rolex Oyster Perpetual Milgauss, Rolex GMT-Master II, Rolex Yacht-Master, Rolex Oyster Perpetual or Rolex Sea-Dweller, are exceptional investments. The Rolex watch is a pathway to a timeless tradition.";
            PrgFunctions f = new PrgFunctions();// ((MainStreet.BusinessFlow.SDK.Web.BusinessFlowWebContext)BusinessFlow.Context);
            //dr["AboutBrand"] = f.GetGlobalChoiceValueDescription("BrandDescriptions", brand);
        }

        //dr["ItemDetail"] = "Rolex is considered to be one of the most prolific Swiss wristwatch manufacturing companies in the world. With their sheer elegance and uncompromising attention to detail, Rolex is the largest luxury watch brand worldwide, producing around 200 watches per day. Since its inception in 1905, Rolex has exuded an aura of unsurpassed urbanity. Unveiled in 1945, the Rolex Oyster Perpetual Datejust was the first wristwatch to display the date and boast a Cyclops magnifying lens. Similarly, the Rolex Oyster Perpetual Cosmograph Daytona, introduced 1988, is designed for measuring elapsed time and calculating average speed with artistic precision. Rolex, an eclectic company, had the maritime adventurer in mind when it created the Oyster Perpetual Submariner with water resistance at depths of 300 meters. All Rolex watches, whether the Rolex Air-King, Rolex Pearlmaster, Rolex Explorer, Rolex Day-Date, Rolex Oyster Perpetual Milgauss, Rolex GMT-Master II, Rolex Yacht-Master, Rolex Oyster Perpetual or Rolex Sea-Dweller, are exceptional investments. The Rolex watch is a pathway to a timeless tradition.";
        //dr["ItemDetail"] = p.GetDescription(this.Page);

        //Get the main(medium) image
        DataTable dtItemimages = new DataTable();// p.GetItemimagesTable();
        DataRow[] drRows = dtItemimages.Select("item_image_type_id=1");

        if (drRows.Length > 0)
        {
            //Get the Main display images
          //  dr["ImageUrlMain"] = BusinessFlow.Settings.Pages.images.get_UrlByImage(new Guid(drRows[0]["image_guid"].ToString()), MainStreet.BusinessFlow.SDK.Ws.imagesize.Medium).ToString();
            dr["ImageUrlMainWidth"] = drRows[0]["image_med_width"].ToString();
            dr["ImageUrlMainHeight"] = drRows[0]["image_med_height"].ToString();

            //Get the full image
           // dr["ImageUrlFull"] = BusinessFlow.Settings.Pages.images.get_UrlByImage(new Guid(drRows[0]["image_guid"].ToString()), MainStreet.BusinessFlow.SDK.Ws.imagesize.Full).ToString();
            dr["ImageUrlFullWidth"] = drRows[0]["image_full_width"].ToString();
            dr["ImageUrlFullHeight"] = drRows[0]["image_full_height"].ToString();
        }
        else
        {
            dr["ImageUrlMain"] = "";
            dr["ImageUrlMainWidth"] = "";
            dr["ImageUrlMainHeight"] = "";

            dr["ImageUrlFull"] = "";
            dr["ImageUrlFullWidth"] = "";
            dr["ImageUrlFullHeight"] = "";
        }

        dt.Rows.Add(dr);

        return dt;
    }





                                 
                                  






    private DataTable getimages(String []  img    )
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("id"));
        dt.Columns.Add(new DataColumn("img"));
        dt.Columns.Add(new DataColumn("Title"));
       
       // dt.Columns.Add(new DataColumn("ImageUrlThumb"));
        dt.Columns.Add(new DataColumn("ThumbImageUrl"));
          dt.Columns.Add(new DataColumn("ImageDesc"));

        dt.Columns.Add(new DataColumn("ImageUrlZoom"));


         dt.Columns.Add(new DataColumn("MediumImageUrl"));
    //  dt.Columns.Add(new DataColumn("ImageUrlMain"));
        dt.Columns.Add(new DataColumn("ImageUrlMainWidth"));
        dt.Columns.Add(new DataColumn("ImageUrlMainHeight"));



         dt.Columns.Add(new DataColumn("FullImageUrl"));
       // dt.Columns.Add(new DataColumn("ImageUrlFull"));
        dt.Columns.Add(new DataColumn("ImageUrlFullWidth"));
        dt.Columns.Add(new DataColumn("ImageUrlFullHeight"));

        DataRow dr = null;


        for (int y = 0; y < img.Length; y++ )
        {

       
        dr = dt.NewRow();
        dr["id"] = 0;
        dr["img"] = "images/" + img[y];
        dr["ThumbImageUrl"] =      "images/"+ img[y];
        dr["MediumImageUrl"] = "images/" + img[y];
        dr["FullImageUrl"] = "images/" + img[y];

        dt.Rows.Add(dr);


        if (y == 0) MediumImageUrl = dr["MediumImageUrl"].ToString();
        }

       
      

        return dt;
    }





    protected   void timeing( )
    {

    }



    protected void time(long amount)
    {


        messages.bidTimeLeft = amount;

        /////////////////////// lblDay.Text = dtNow.ToString("ddd, MMMM dd, yyyy");

        string code = @"<script language=""javascript"" type=""text/javascript"">
           
             
             amount=" + amount + @";

             window.onload=GetCount() ;
         document.onload = GetCount();

           
                GetCount() ;

            
            
             </script>";





  






        ClientScriptManager csm = Page.ClientScript;
      

        csm.RegisterStartupScript(Page.GetType(), "timer" + amount, code, true);

 


    }











































    protected void btnBidNow_Click(object sender, EventArgs e)
    {

      //  txtBidamount

       

        //DataSet ds = new DataSet();
        //messages.orgID = 12;
        //messages.itemID = 10;
        //messages.catID = 18;
        //messages.bidtype = "standard";
        //messages.buyerID = 2;










        //Code for the Countdown timer
        //Code for the Countdown timer
       
        DateTime dtFuture = new DateTime();//  (messages.bidEndTime.Year, messages.bidEndTime.Month, messages.bidEndTime.Day, messages.bidEndTime.Minute, messages.bidEndTime.Second, messages.bidEndTime.Millisecond);//        dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
        


        dtFuture = messages.bidEndTime;


        //TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
        //ts = dtFuture.Subtract(dtNow);
        // amount = (long)ts.TotalMilliseconds;


       long amount = calcdatespan(dtFuture);

        //////////////////////if (amount <= 378488)
        //////////////////////{

        //////////////////////    switch (messages.bidlevel)
        //////////////////////    {
        //////////////////////        case 0:

        //////////////////////            messages.bidlevel = 1;

        //////////////////////            messages.bidEndTime = messages.bidEndTime1;

                   
        //////////////////////            break;
        //////////////////////        case 1:

        //////////////////////            messages.bidlevel = 2;

        //////////////////////            messages.bidEndTime = messages.bidEndTime2;
                   
        //////////////////////            break;

        //////////////////////        case 2:

        //////////////////////            messages.bidlevel = 3;

        //////////////////////            messages.bidEndTime = messages.bidEndTime3;
                    
        //////////////////////            break;
        //////////////////////        case 3:



        //////////////////////            break;
        //////////////////////    }

            

         time( amount);
        ////////////////////////}































        String cmd = ((ImageButton)sender).CommandName;


        String  soldFixedBid = cmd == "bid" ? "bid" : "buynow";


        build("X", soldFixedBid);




    }





    protected long calcdatespan(DateTime dtFuture)
    {
        DateTime dtNow = new DateTime();
        // dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);
        dtNow = DateTime.Now;
        TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
        ts = dtFuture.Subtract(dtNow);
       long amount = (long)ts.TotalMilliseconds;

        return amount;
    }




    protected void btnBuyNow_Click(object sender, EventArgs e)
    {
        int quantity = 1;

        try
        {
            
            if (quantity < 1)
                return;

            //STI 07/15/09: Custom code
            if (quantity > 10)
            {
                quantity = 10;
                return;
            }
        }
        catch
        {
            return;
        }

        //customization
        /*
        string promotionGuid = PrgFunctions.TryCastString(BusinessFlow.DefaultCart.Data.OrderRow["promotion_guid"]);
        string promotionCode = BusinessFlow.DefaultCart.Data.OrderRow["order_promotion_cd"].ToString();
        string promotionDescription = BusinessFlow.DefaultCart.Data.OrderRow["order_promotion_description"].ToString();

        BusinessFlow.DefaultCart.Clear();
        
        //Load up the customer information because, default cart clears everything
        if (BusinessFlow.Identity.IsAuthenticated)
            BusinessFlow.DefaultCart.LoadCustomerInfo(BusinessFlow.Identity.CustomerGuid);
        */

       // BusinessFlow.DefaultCart.PersistTimeout = new TimeSpan(0, 30, 0);

        p = getDetails();
        //if (p.IsLoaded())
        //{
            //customization: Adjust the quantity based on the control, do not add items to the cart
            PrgFunctions f = new PrgFunctions();
          //////////////  f.RemoveItemFromCart(new Guid(p.GetItemGuid()));


          /////////////////  BusinessFlow.DefaultCart.AddItem(new Guid(p.GetItemGuid()), quantity, null, SpecialItemCost);

            /*
            if (promotionGuid.Length != 0)
            {
                BusinessFlow.DefaultCart.Data.OrderRow["promotion_guid"] = PrgFunctions.TryCastGuid(promotionGuid);
                BusinessFlow.DefaultCart.Data.OrderRow["order_promotion_cd"] = promotionCode;
                BusinessFlow.DefaultCart.Data.OrderRow["order_promotion_description"] = promotionDescription;
            }
            */

            DisplayVariationGuid = "";
       

            Session["prefex"] = "block";

          

            Response.Redirect("checkout/checkout_step1.aspx");
  
        //}
    }



    protected void iqAttributeGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }


    protected void iqAttributeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            string tooltip = "";// PrgFunctions.TryCastString(drv["attribute_description"].ToString());

            for (int colIndex = 0; colIndex < e.Row.Cells.Count; colIndex++)
            {
                if (tooltip.Length > 0)
                    e.Row.Cells[colIndex].Attributes.Add("title", tooltip);
            }
        }
    }

 

    protected void lvItemCommand(object sender,EventArgs e)
    {
        if ("ChangeVariation" == "ChangeVariation")
        {
        }
    }





    //protected void lvDisplayVariationsItemCommand(int indx)
    //{
    //       DataRowView drr = (DataRowView)lvDisplayVariations.Items[indx].DataItem;
    //    string ItemGuid= drr["ItemGuid"].ToString();


    //        updateChildItemInformation(ItemGuid);

    //        //Update the dropdown list
          
    //        //ddDisplayVariations.ClearSelection();
    //        //foreach (ListItem li in ddDisplayVariations.Items)
    //        //{
    //        //    if (String.Compare(li.Value, DisplayVariationGuid, true) == 0)
    //        //    {
    //        //        li.Selected = true;
    //        //    }
    //        //    else
    //        //    {
    //        //        li.Selected = false;
    //        //    }
    //        //}
         
    //}





    // rolling over colors auto changes...
    protected void lvDisplayVariations_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ChangeVariation")
        {
            updateChildItemInformation(e.CommandArgument.ToString());

            //Update the dropdown list
            ////ddDisplayVariations.SelectedIndex = 0;
            ////ddDisplayVariations.ClearSelection();
            ////foreach (ListItem li in ddDisplayVariations.Items)
            ////{
            ////    if (String.Compare(li.Value, DisplayVariationGuid, true) == 0)
            ////    {
            ////        li.Selected = true;
            ////    }
            ////    else
            ////    {
            ////        li.Selected = false;
            ////    }
            ////}
        }
    }


    private void updateChildItemInformation(string itemGuid)
    {
        if (itemGuid.Length == 0)
            return;

        DisplayVariationGuid = itemGuid;
        //load();
        loadChildInformation();
    }



    private void loadChildInformation()
    {
      ////  compareOther();


        if (DisplayVariationGuid.Length == 0)
            return;

        //Load up the product info
       p = new ProductDetails(new Guid(DisplayVariationGuid));

        //Read the images from the harddisk instead of the image manager
        PrgFunctions f = new PrgFunctions();
        string productimagesPath = "";// PrgFunctions.TryCastString(f.GetAppSettings("productimagesPath"));

        if (!productimagesPath.EndsWith("\\"))
            productimagesPath += "\\";

        string manufacturerId = "";// p.GetStringFieldOrAttribute("ManufactuerItem").ToLower();





        //Set the main image
        DataTable dtItemimages= new DataTable();// = p.GetItemimagesTable();
        DataRow[] drRows = dtItemimages.Select("item_image_type_id=1");

        if (drRows.Length > 0)
        {
            MediumImageWidth = Unit.Parse(drRows[0]["image_med_width"].ToString()).ToString();
            MediumImageHeight = Unit.Parse(drRows[0]["image_med_height"].ToString()).ToString();
        }

       // ImageDesc = p.GetTitle();
        ProductTitle = ImageDesc;

        //customization: override the image urls to use higher qualities ones
         LinkToFullImage = ResolveUrl("Productimages/Full/" + manufacturerId + "_1.jpg");
        MediumImageUrl = ResolveUrl("Productimages/Medium/" + manufacturerId + "_1.jpg");
       
        
        
        //Load up thumbnails
        string itemTag = "";// p.GetStringFieldOrAttribute("item_tag").ToLower();
      




        DataTable dtimagesThumb = new DataTable();//=   p.GetimagesTableWithUrls();//p.GetimagesTableWithUrlsFromHarddisk(this.Page)
        //HtmlContainerControl body_partone_11 = (HtmlContainerControl)this.FindControl("body_partone_1");
        //HtmlControl pOtherViews = (HtmlControl)body_partone_11.FindControl("pOtherViews");
        //pOtherViews.Visible = true;
        //if (dtimagesThumb.Rows.Count==0) 
        //{
          
        //    pOtherViews.Visible = false;
        //}




        for (int i = 0; i < dtimagesThumb.Rows.Count && i <3; i++)
            dtimagesThumb.Rows[i]["ImageDesc"] = itemTag + " " + (i + 1).ToString();



        
        DataTable dtimagesThumb3 = new DataTable();

        dtimagesThumb3 = dtimagesThumb.Clone();
 

        DataSet dst = new DataSet();
        dst.Tables.Add("dtimagesThumb3");

        DataView dv = new DataView();

        dv = dst.Tables[0].DefaultView;



        int cntrows = 0;
        foreach (DataRow rows_ in dtimagesThumb.Rows)
        {

            if (cntrows <= 2)
            {
                dtimagesThumb3.ImportRow(rows_);
                cntrows += 1;
            }

        }

        // checks to see if count more that 3 (images) then displays right/left buttons
        //if (dtimagesThumb.Rows.Count <= 3)
        //{
        //    ImgBtnOvleft.Visible = false;
        //    ImgBtnOvright.Visible = false;
        //}
        //else
        //{
        //    ImgBtnOvleft.Visible = true;
        //    ImgBtnOvright.Visible = true;
        //}


        //iqimagesThumb.DataSource = dtimagesThumb3;
        //iqimagesThumb.DataBind();


        Session["dtimagesThumb"] = dtimagesThumb;





        int q = 0;// p.GetActualQuantityOnHand();

        if (q > 0)
        {
            
        }
        else
        {
            
        }
    }


    protected void ddDisplayVariations_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if ((ddDisplayVariations.SelectedValue != "") && (ddDisplayVariations.SelectedValue != "- Select color -"))
        //{
        //    updateChildItemInformation(ddDisplayVariations.SelectedValue);
        //}
    }


    //protected void btnBuyNowChild_Click(object sender, EventArgs e)
    //{
    //    if ((ddDisplayVariations.SelectedValue != "") && (ddDisplayVariations.SelectedValue != "- Select color -"))
    //    {
             
    //        int quantity = 1;

    //        try
    //        {
                

    //            if (quantity < 1)
    //                return;

    //            //STI 07/15/09: Custom code
    //            if (quantity > 10)
    //            {
    //                quantity = 10;
    //                return;
    //            }
    //        }
    //        catch
    //        {
    //            return;
    //        }

    //       //// BusinessFlow.DefaultCart.PersistTimeout = new TimeSpan(0, 30, 0);

    //        Guid gg = new Guid();
    //        p = new ProductDetails(gg);// (PrgFunctions.TryCastGuid(ddDisplayVariations.SelectedValue));
         
            
    //            //customization: Adjust the quantity based on the control, do not add items to the cart
    //            PrgFunctions f = new PrgFunctions();
    //          /////////////  f.RemoveItemFromCart(new Guid(p.GetItemGuid()));

    //           ///////////// BusinessFlow.DefaultCart.AddItem(new Guid(p.GetItemGuid()), quantity, null, SpecialItemCost);

    //            DisplayVariationGuid = "";

    //            Session["cartHolder"] = true;
    //            Response.Redirect( "checkout/checkout_step1.aspx");
  
                
             
    //    }
    //}
}
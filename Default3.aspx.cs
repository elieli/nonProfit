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

public partial class Default3 : System.Web.UI.Page
{
    Referrer r = new Referrer();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (custs() == null)
        {
            BLCustomer cust = new BLCustomer(0);
            Application["cust"] = cust;


        }

        //if(messages.orgs_.ID==0)   
        if (custs().signedInorgID == 0)
        {
            Response.Redirect("Login.aspx?login=org");
        }



   ////     messages.navigate += new EventHandler(NavigationLink_Click);



        try
        {
            lblbreadcrumbs.Text = String.Join(" ", messages.arCats).ToString();
        }
        catch(Exception){}
        //for(int x =0 ;x<=60;x++)
        //{
             
        //    //drpMinute.Items.Add(x.ToString());
        //    //drpMinute2.Items.Add(x.ToString());

        //}

        DateTime dtt= DateTime.Now  ;

        if (IsPostBack==true)        
        {
            CnfrmItem(  sender,   e);

         ///   DataSet ds = UpdateDonate("S", "get_Items", 0, 0, 0, dtt, dtt, "","","","","");
        }
    }


    protected void CnfrmItem(object sender, EventArgs e)
    {


        
            //  if (messages.orgs_.ID == 0)
                  if (custs().signedInorgID == 0)
        {
            Response.Redirect("Login.aspx?login=org");
        }



        String  drpdMode1 = (String)Request.Form["sdrpdMode1"] == null ? "" : (String)Request.Form["sdrpdMode1"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
     
        String  drpdMode2 = (String)Request.Form["sdrpdMode2"] == null ? "" : (String)Request.Form["sdrpdMode2"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
      
        String drphour1 = (String)Request.Form["sdrphours1"] == null ? "" : (String)Request.Form["sdrphours1"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
          String drpminute1 = (String)Request.Form["sdrpminutes1"] == null ? "" : (String)Request.Form["sdrpminutes1"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
        String startDate = (String)Request.Form["startDate"] == null ? "" : (String)Request.Form["startDate"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();



        String drphour2 = (String)Request.Form["sdrphours2"] == null ? "" :  (String)Request.Form["sdrphours2"].ToString() ; //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
        String drpminute2 = (String)Request.Form["sdrpminutes2"] == null ? "" : (String)Request.Form["sdrpminutes2"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
        String DateTime2 = (String)Request.Form["DateTime2"] == null ? "" : (String)Request.Form["DateTime2"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
      
        int hour1 = drphour1!="" ? Convert.ToInt16(drphour1):0;

        if (drpdMode1 == "PM")
        {
            hour1 += 12;
        }



        int minute1 = drpminute1!="" ? Convert.ToInt16(drpminute1) : 0;
        DateTime dt1 = Convert.ToDateTime(startDate);

        int hour2 = drphour2!="" ? Convert.ToInt16(drphour2):0;

        if (drpdMode2 == "PM")
        {
            hour2 += 12;
        }


        int minute2 =drpminute2!="" ?  Convert.ToInt16(drpminute2):0;
        DateTime dt2 = Convert.ToDateTime(DateTime2);

        //int hour1 = Convert.ToInt16(drpHour.SelectedValue);
        //int minute1 = Convert.ToInt16(drpMinute.SelectedValue);
        dt1 = dt1.AddHours(hour1);
        dt1 = dt1.AddMinutes(minute1);



     //   DateTime dt = Convert.ToDateTime(txtstartDate.Value);

     //   int   hour1 =   Convert.ToInt16 (drpHour.SelectedValue);
     //   int minute1 = Convert.ToInt16(drpMinute.SelectedValue);
     //  dt= dt.AddHours(hour1);
     //dt=  dt.AddMinutes(minute1);


      //  dt.AddMinutes(Convert.ToInt16(drpMinute.SelectedValue));

//     DateTime s = ...;
//TimeSpan ts = new TimeSpan(10, 30, 0);
//s = s.Date + ts;



        //////////DateTime dt2 = Convert.ToDateTime(txtbDateTime2.Text );


        //////////int hour2 = Convert.ToInt16(drpHour.SelectedValue);
        //////////int minute2 = Convert.ToInt16(drpMinute.SelectedValue);
      dt2=  dt2.AddHours(hour2);
      dt2=  dt2.AddMinutes(minute2);

        //dt2.AddHours(Convert.ToDouble(drpHour2.SelectedValue));

        //dt2.AddMinutes(Convert.ToDouble(drpMinute2.SelectedValue));



      String imgCenter1 = (String)Request.Form["dvimgCentertxt1"] == null ? "" : (String)Request.Form["dvimgCentertxt1"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
     string    orgLogo1 = imgCenter1.Substring(imgCenter1.LastIndexOf("/")+1  , imgCenter1.Length  - (imgCenter1.LastIndexOf("/")+1));




     String imgCenter2 = (String)Request.Form["dvimgCentertxt2"] == null ? "" : (String)Request.Form["dvimgCentertxt2"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
     string orgLogo2 = imgCenter2.Substring(imgCenter2.LastIndexOf("/") + 1, imgCenter2.Length - (imgCenter2.LastIndexOf("/") + 1));



     String imgCenter3 = (String)Request.Form["dvimgCentertxt3"] == null ? "" : (String)Request.Form["dvimgCentertxt3"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
     string orgLogo3 = imgCenter3.Substring(imgCenter3.LastIndexOf("/") + 1, imgCenter3.Length - (imgCenter3.LastIndexOf("/") + 1));


     String imgCenter4 = (String)Request.Form["dvimgCentertxt4"] == null ? "" : (String)Request.Form["dvimgCentertxt4"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
     string orgLogo4 = imgCenter4.Substring(imgCenter4.LastIndexOf("/") + 1, imgCenter4.Length - (imgCenter4.LastIndexOf("/") + 1));



     string itemsIncluded = (String)Request.Form["itemsIncluded"] == null ? "" : (String)Request.Form["itemsIncluded"].ToString();


        //String imgCentertxt1= ((HtmlContainerControl) this.FindControl("dvimgCentertxt1")).InnerHtml;
        //String imgCentertxt2 = ((HtmlContainerControl)this.FindControl("dvimgCentertxt2")).InnerHtml;;
        //String imgCentertxt3 = ((HtmlContainerControl)this.FindControl("dvimgCentertxt3")).InnerHtml;;
        //String imgCentertxt4 = ((HtmlContainerControl)this.FindControl("dvimgCentertxt4")).InnerHtml;;



     int orgid = custs().signedInorgID;

       /// int orgid = messages.orgs_.o.ID;

        int catid =  items().CatID ; 


        ///////////////////UpdateDonate("N", "getItems", 0, orgid, catid, "");

        UpdateDonate("N", "set_Items", 0, orgid, catid, dt1, dt2, "", orgLogo1, orgLogo2, orgLogo3, orgLogo4, itemsIncluded);

    
    }
    

     //orgid      ,
     // location    ,
     // description    ,
     // quantity     , 	 
     //shippngCost     ,
     // condition   ,
     // title   ,
     //catID    ,
     // startDate    ,
     // endDate   ,
     //soldDate    

    protected DataSet UpdateDonate(String parm, string commandtext, int id, int orgid, int catid, DateTime dt1, DateTime dt2, string status, string imgCentertxt1, string imgCentertxt2, string imgCentertxt3, string imgCentertxt4, string  itemsIncluded)
    {

        int itemid=0;
       // int orgid=0;  
        int shippngCost=0;   
      //  int orgid = 0;  
        String title = ""; 
        int quantity = 0; 
       // int catID = 0;  
        String location = "";  
        String orgPaypal = ""; 
        String description = "";  
          String condition = "";  
        //String shippngCost = status; 
          DateTime startDate = dt1;// DateTime.Today;
          DateTime endDate = dt2;// DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = commandtext;
        
        String prm = parm;
        


       
        status = "";

        DataSet ds = new DataSet();
        
        string commandText = commandtext;
        commandName = commandtext; 
     //   string commandName;
        String auctiontype = ""; 
        if (prm == "S")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,custs().ID, itemid, orgid, catid, location,
     description,   quantity,   shippngCost,   condition,   title, 
          startDate,   endDate,   soldDate ,auctiontype,0
     );



        }
        else
        {
     ////////////////       r.setItems("getItems", prm, itemid, orgid, catID, location,
     ////////////////description,   quantity,   shippngCost,   condition,   title,    
     ////////////////     startDate,   endDate,   soldDate  
     ////////////////        );
          
 int itemAuctionID=catid;
 int buyerID = messages.cust.signedInorgID;//.ID;
            int storeID=0;
     
            int quantityAllocated=0; 
            int shipping=0; 
            Decimal  startBidPrice=0      ;
            //Decimal currentBidPrice = 0;
  int  soldAmount =0   ;
            int percentAllocated =0  
      ;int amountAllocated   =0  ;
            int  soldFixedBid=0   ;

            DateTime startTime = dt1;// DateTime.Today; 
            DateTime endTime = dt2;// DateTime.Today ; 
            DateTime soldTime=  DateTime.Today ;















			
			
           // txtTitle

              ///  txtareaDesc



          //  String buyitNow_ = ((HtmlInputText)this.FindControl("buyitNow")).Value != String.Empty ? ((HtmlInputText)this.FindControl("buyitNow")).Value : "0";


            int buyitNow = 0;// Convert.ToInt16(buyitNow_);


             title  = ((HtmlInputText)this.FindControl("title")).Value ;

             description =         ((HtmlTextArea)this.FindControl("txtareaDesc")).Value ;

          ///  String lyrAddPic1 = ((HtmlGenericControl)this.FindControl("lyrAddPic1")).InnerText ;

       ///     String startPrice = ((HtmlInputText)this.FindControl("startPrice")).Value;


            
                   String shipsWithinDays = ((HtmlSelect)this.FindControl("shipsWithinDays")).Value;

            //String duration = ((HtmlSelect)this.FindControl("duration")).Value;

            //String returnsAccepted = ((HtmlInputCheckBox)this.FindControl("returnsAccepted")).Value;
                
            
            //String itemReturnedWithin = ((HtmlInputHidden)this.FindControl("itemReturnedWithin")).Value;

            //String binCheck = ((HtmlInputCheckBox)this.FindControl("binCheck")).Value;


            //String binPrice = ((HtmlInputText)this.FindControl("binPrice")).Value;

               String txtTitle = (String)Request.Form["txtTitle"] == null ? "" : (String)Request.Form["txtTitle"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
  
		//	      String txtTitle = (String)Request.Form["txtTitle"] == null ? "" : (String)Request.Form["txtTitle"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
               String shipFee = (String)Request.Form["shipFee1"] == null ? "" : (String)Request.Form["shipFee1"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
               String txtareaDesc = (String)Request.Form["txtareaDesc"] == null ? "" : (String)Request.Form["txtareaDesc"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();

        String handlingTime1 = (String)Request.Form["handlingTime"] == null ? "" : (String)Request.Form["handlingTime"].ToString(); //  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();




        condition = txtTitle;


        String shipFee1 = shipFee;// ((HtmlInputText)this.FindControl("shipFee1")).Value;


             String paypalEmail = "";// ((HtmlInputText)this.FindControl("paypalEmail")).Value;




             Decimal currentBidPrice = 0;//'' startBidPrice;

             string returnPolicy = description;// returnsAccepted;

       // int returnDays = (int)Convert.ToInt16(itemReturnedWithin.Substring(itemReturnedWithin.LastIndexOf('_')+1, 1));
      String handlingTime =  handlingTime1 ;


          String shipfee = shipFee1.Trim() != String.Empty   ? shipFee1 : "0";


          quantity = 1;

          int returnDays = 0;

          shipping = (int)Convert.ToInt16(shipFee1);
             

          string imgPath = imgCentertxt1;//lyrAddPic1;
          ///  startBidPrice = startPrice.Trim() != String.Empty ? Convert.ToDecimal(startPrice) : 0  ;


 //@opt varchar(1),
 //    @itemID   int	  , 
 //    @itemAuctionID   int      ,
 //    @buyerID int,
 //     @storeID int,
 
	 
 //    @quantity int   ,
 //    @quantityAllocated int,
 //    @shipping int  ,
 //    @startBidPrice int  ,	 
 //    @currentBidPrice int ,
 //    @soldAmount  int   ,
 //    @percentAllocated  int   ,
 //    @amountAllocated   int   ,
 //    @soldFixedBid varchar (10)  ,	  
	 
 //    @condition varchar (50)  ,
 //       @returnDays int,
 //       @returnPolicy   varchar (250),
 //    @startTime datetime   ,
 //    @endTime datetime   ,
 //    @soldTime datetime  , 
 //     @payPalemail varchar(50) ,
 //    @handlingTime  int, 
 //    @imgPath  varchar(80) 


    //     String   returnPolicy= returnPolicy;

       

            
    //orgid      ,
    // location    ,
    // description  ,
    // quantity    ,
    // quantityHold    ,
    // quantityToShipped     ,
    // quantityInStore    ,
    // quantityInPennybid    ,
    // quantityInAuction     ,
    // quantitySold    ,
    // shippingCost   ,
    // condition    ,
    // title  ,
    // catID   ,
    // startDate    ,
    // endDate    ,
    // soldDate  



        String command= "get_itemMaster";



        itemid=   r.set_Items(command , prm, itemid, itemAuctionID, buyerID, storeID,
     quantity, quantityAllocated, shipping, startBidPrice, currentBidPrice, soldAmount,
     buyitNow, percentAllocated, amountAllocated, soldFixedBid, condition, returnDays,
     returnPolicy, startTime, endTime, soldTime, paypalEmail, handlingTime,
     imgPath, auctiontype, imgCentertxt1, imgCentertxt2, imgCentertxt3, imgCentertxt4, itemsIncluded);
    









            r.set_Items(commandName, prm, itemid, itemAuctionID, buyerID, storeID,
          quantity, quantityAllocated, shipping, startBidPrice,  currentBidPrice,     soldAmount,
          buyitNow, percentAllocated, amountAllocated, soldFixedBid,         "", returnDays,
          returnPolicy, startTime, endTime, soldTime,paypalEmail, handlingTime,
          imgPath, auctiontype, imgCentertxt1, imgCentertxt2, imgCentertxt3, imgCentertxt4, itemsIncluded);
    





        };




        ///  prm = mails.prm;
        //////ds.Tables[0].Columns.Add("prm");

        //////foreach (DataRow dr in ds.Tables[0].Rows)
        //////{
        //////    dr["prm"] = prm;

        //////}

        if (ds.Tables.Count > 0)
        {
            //grdvSubGmach.AutoGenerateColumns = false;
            //grdvSubGmach.DataSource = ds;
            //grdvSubGmach.CellPadding = 9;
            //grdvSubGmach.Columns[3].ItemStyle.Width = 230;

            //grdvSubGmach.DataBind();

            //grdvSubGmach.Columns[grdvSubGmach.Columns.Count - 1].Visible = false;

            return ds;
            //lstcat.DataSource = ds;
            //lstcat.DataBind();
        }

        else
        {
            //grdvSubGmach.DataSource = null;
            //grdvSubGmach.CellPadding = 9;
            //grdvSubGmach.Columns[3].ItemStyle.Width = 230;

            //grdvSubGmach.DataBind();
            return null;
        }
        //for (int i = 0; i <= grdvSubGmach.Columns.Count-1; i++ )
        //{
        //    if ((mails.prm == "2" || mails.prm == "8") && i < 3 || (mails.prm == "2" || mails.prm == "8") && i > 12)
        //    { grdvSubGmach.Columns[i].Visible = false; }
        //    if ((mails.prm == "2" || mails.prm == "8") && i == 16) 
        //    { grdvSubGmach.Columns[i].Visible = true; }


        //    if (mails.prm == "8" && i == grdvSubGmach.Columns.Count - 1)
        //    { grdvSubGmach.Columns[i].Visible = true; }

        //}



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

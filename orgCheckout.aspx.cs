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

public partial class orgCheckout : System.Web.UI.Page
{
    protected string ImageDesc = "";

    public string filters = "";


    DataSet ds;
    DataTable dataTable;
      

   
    Referrer r = new Referrer();
    public String SubGmachTitle = "";


    //BLItems items = (BLItems)messages.cust.Organization.Orgitems;
    BLOrganization org  = ((BLOrganization)messages.cust.Organization) ;
    BLCustomer cust = ((BLCustomer)messages.cust);

    

    protected void ListChanged(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int origid = Convert.ToInt16(org.ID);


        ////if (origid == 0)
        ////{
        ////    Response.Redirect("NonProfitHome.aspx");

        ////}





        string qry = Request.QueryString != null && Request.QueryString.Count > 0 ? Request.QueryString[0].ToString() : "";

        int auctionid_ = qry == null || qry == "" ? 0 : (int)Convert.ToInt16(qry);
        items().AuctionID = auctionid_;












        if (messages.cust.ID == 0) { return; }





        for (int x = 2012; x < 2020; x++)
        {
            cmbCardExpYear.Items.Add(x.ToString());
        }
      




        if(!IsPostBack)
        {
            items().Live = "";
        }

         filters = items().Live;

    //////////////////////////////////////////////////   messages.navigate  += new EventHandler(NavigationLink_Click);






        ////////if (messages.cust == null)
        ////////{

        ////////    while ((Logins.password != "tzally123" && Logins.password != "zalman123" && Logins.password != "zalman123" && Logins.password != "zalman123") &&
        ////////     (Logins.userid != "tzally123" && Logins.userid != "zalman123" && Logins.userid != "zalman123" && Logins.userid != "zalman123"))
        ////////    {
        ////////        Response.Redirect("Login.aspx");
        ////////    };
        ////////    // Logins.userid = txtLoginEmail.Text;


        ////////    ///////// item_Search();

        ////////    /////////////////// refreshOrgs(sender, e);



        ////////}

      
        //if(!IsPostBack)
        
        //{

        
        string status ="approved";





        BLCustomer cst = (BLCustomer)custs();

        //DataSet ds = BLOrganization.GetOrgList(ref  cst, "S", "get_Orgs", origid, status);


        DataSet ds = orgs().GetOrgList(ref  cst, "S", "get_Orgs", origid, status);





              //////////drplstOrgs.DataSource = ds;
              //////////drplstOrgs.DataValueField = "orgID";
              //////////drplstOrgs.DataTextField=  "orgTitle";
              //////////drplstOrgs.DataBind();


              //////////drplstOrgs.Items.Insert(0, "All Orginazations");











        int buyerid = custs().ID;// messages.buyerID;
              string commandName = "get_Credits";
              string prm = "E";


              //////Decimal credits_ = r.get_Credits(commandName, prm, buyerid, 0);

               


              //////messages.credits = Convert.ToInt16(credits_);
       

       

        //HtmlContainerControl dvLogo=(HtmlContainerControl) this.FindControl("dvLogo");
        //HtmlInputHidden hdnVideo = (HtmlInputHidden)this.FindControl("hdnVideo");

        if (dvLogo != null && hdnVideo != null)
        {
            dvLogo.Src = "images/"+ messages.orgs_.Logo;

            hdnVideo.Value =   messages.orgs_.Video;

            dvKnow.InnerHtml = messages.orgs_.Know;
        }

      






              int catid = 0;

              int orgid = orgs().ID;// Convert.ToInt16(drplstOrgs.SelectedValue.ToString());

           //   orgid = messages.orgs_.ID;//  12;
              messages.itemID = orgs().Orgitems.Item.ID;
            //////////  catid = messages.orgs_.Orgitems.CatID;// 12;




              DataView dv;
              DataSet dss = new DataSet();


              //  categoryProduct

              ////// dss =  messages.getItems("S", "get_Items", 0, catid, orgid, "");
              // dss = messages.getItems("Q", "get_Items", 0, catid, orgid, "");

             /// BLCustomer cst = (BLCustomer)custs();

              dss = items().GetItemsList(ref cst, "V", "get_Items", 0, orgid, catid, "");
              custs_ = cst;



              dv = new DataView(dss.Tables[0]);

              int rowLimit = 4;

              // dv.RowFilter = "";


              ///   dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();



              //  return dataTable;



              ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

              ////////////////DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");


              ////////////////HtmlContainerControl dvPageing = (HtmlContainerControl)(MainContent.FindControl("orgProducts2")).FindControl("dvPageing");
              ////////////////dvPageing.Visible = false;
         


              ////////////////DataTable dataTable = dv.ToTable();

              ////////////////DataTable datatable = new DataTable();
              ////////////////datatable = dataTable.Clone();


              ////////////////if (dataTable.Rows.Count>0)
              ////////////////{

              ////////////////for (int x = 0; x < 4; x++)
              ////////////////{ 
              ////////////////    datatable.ImportRow(dataTable.Rows[x]);

                   
              ////////////////}
              ////////////////}
         

              ////////////////dtalstItems.DataSource = datatable;// ds;

              ////////////////dtalstItems.DataBind();









   /////////  itemSearch(  sender,   e);

      

        DataSet dst = new DataSet();

        dst = UpdateDonate("C", "get_Items", buyerid, catid, orgid, "");

   


    }


    //@opt varchar(1), 
    //        @itemID  INT, 
    //        @catID  int ,
    //    @orgID  int 


    protected void chgsts( object sender , EventArgs e)
    {

        int orgid = Convert.ToInt16(messages.orgID);
        int catid = Convert.ToInt16(messages.catID);


        UpdateDonate("S",  "get_Items",0, catid, orgid,"");
        
    }




    protected void itemSearch(Object sender, EventArgs e)
    {

        items().pager = 0;
          /////items().rowlimit = 10 ;
     

        string sortr = "";

      //////////  if (messages.dvorgProducts != null)
      //////////       sortr = messages.dvorgProducts.Sort.ToString() ;

      //////////  String sorter = drplstSort.SelectedValue.ToString();

      //////////if (  messages.dvorgProducts!=null)
      //////////  messages.dvorgProducts.Sort =    sorter ;

    // orgItems   obj = new orgItems();

        //foreach (Control c in Page.Controls)

        //{
        //    string nm = c.ID;
        //    foreach (Control cc in c.Controls)
        //    {
        //        string nmc = cc.ID;

        //        foreach (Control ccc in cc.Controls)
        //        {
        //            string nmcc = ccc.ID;



        //        }

        //    }
        //}
      ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
      DropDownList drplstOrgs = (DropDownList)MainContent.FindControl("drplstOrgs");
      DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
      //     UserControl category1 = (UserControl)MainContent.FindControl("category1");

       
      //     ListBox lstcat = (ListBox)(MainContent.FindControl("category1")).FindControl("lstcat");
       

      //TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");

      //TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

      //Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

      //Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;

       
        //[get_Categories]


        //    @opt varchar(1),  
        //    @catID  int ,
        //    @catName varchar(50


   


      ////////////////////if (lstcat != null && lstcat.SelectedValue.ToString().Trim() !="") 
      ////////////////////{
      ////////////////////    messages.catID = Convert.ToInt16( lstcat.SelectedValue.ToString());

      //////////////////// ((BLCustomer)messages.cust).Organization.Orgitems.CatID=   Convert.ToInt16(lstcat.SelectedValue.ToString());
      ////////////////////}


      //if (lstcat != null)
      //{
      //    messages.orgID = drplstOrgs.SelectedValue.ToString() == "" ? 0 : Convert.ToInt16(drplstOrgs.SelectedValue.ToString() == "");

      //}


      int orgid =  ((BLCustomer) messages.cust).Organization.ID;
      int catid = ((BLCustomer)messages.cust).Organization.Orgitems.CatID; /// messages.catID;

      DataSet ds = new DataSet();

      String param = "";


   ///   ds =            messages.UpdateDonate("I", "get_Items", 0, catid, orgid, txtItemSearch.Text.Trim());

      if (((BLCustomer)messages.cust).Organization.Orgitems.Items == null || ((BLCustomer)messages.cust).Organization.Orgitems.Items.Tables.Count == 0 || ((BLCustomer)messages.cust).Organization.Orgitems.Items.Tables[0].Rows.Count == 0)
      { param = "Q"; }
      else { param = "J"; }


      BLCustomer cst = (BLCustomer)custs();

      ds = items().GetItemsList(ref cst, param, "get_Items", 0, orgid, catid, "");

      custs_ = cst;


        if (ds!=null)

        {
      //DataView dv = new DataView((DataTable)dtalstItems.DataSource);
      DataView dv = new DataView(ds.Tables[0]);

     /////////////// items().rowlimit = items().rowlimit == 0 ? 15 : items().rowlimit;
      items().rowlimit = items().rowlimit == 0 ? 16 : items().rowlimit;

      items().pager = items().pager == 0 ? 1 : items().pager;

        



     int rowLimit = items().rowlimit;
     int page = items().pager * rowLimit;
    ///////////  items().pager += 1;





      if (ds.Tables.Count > 0)
      {

 




          //////if (PriceEnd > 0 && PriceEnd > PriceStart ||  ( filters != null && filters != ""))
          //////{
          //////    if (PriceEnd > 0 && PriceEnd > PriceStart && ( filters != null && filters != ""))
          //////    {
          //////        dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd + " and " + filters;
          //////    }
          //////    else
          //////    {
          //////        if (PriceEnd > 0 && PriceEnd > PriceStart)
          //////        {
          //////            dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd;
          //////        }
          //////        else { dv.RowFilter = filters; }
          //////    }
          //////}



        ///  dv.Sort = drplstSort.SelectedValue.ToString();

          /// ((BLCustomer)messages.cust).Organization.Orgitems.ItemsDV = dv;

          DataTable dataTable = dv.ToTable();

          messages.orgs_.Orgitems.dataTable = dataTable;


          int totPages = dataTable.Rows.Count / rowLimit;
          int totPagesRem = dataTable.Rows.Count % rowLimit;
 


          //////BLItems.rempage = totPagesRem;

          //////BLItems.totpage = totPagesRem > 0 && dataTable.Rows.Count >= rowLimit ? totPages + 1 : totPages;

          ////////////////////////    int totPagesRemAll = messages.DataTable.Rows.Count % rowLimit;




          //////UserControl pageing1 = (UserControl)(MainContent.FindControl("orgProducts2")).FindControl("pageing1");

          //////Label CurrentPage = (Label)pageing1.FindControl("CurrentPage");

          //////Label TotalPages = (Label)pageing1.FindControl("TotalPages");



          //////DropDownList drplstCPage = (DropDownList)pageing1.FindControl("drplstCPage");




          //////CurrentPage.Text = items().pager.ToString();


          //////TotalPages.Text = totPages.ToString();


          //////totPages = totPagesRem > 0 && dataTable.Rows.Count>0 ? totPages + 1 : totPages;

          //////drplstCPage.Items.Clear();
          //////for (int pg = 1; pg <= totPages; pg++)
          //////{
          //////    ListItem pages = new ListItem();
          //////    pages.Value = pg.ToString();

          //////    drplstCPage.Items.Add(pages);

          //////}

      //////////////////////////////////////////////////////////////////    drplstCPage.SelectedIndex = items().pager - 1;

          ////if (dataTable.Rows.Count > 0)
          ////{

          ////    //////////////////  messages.DataTable = dataTable;
          ////    //////if (ds.Tables[0].Rows.Count>0)
          ////    //////    messages.DataTable = dataTable;

          ////    if (dataTable.Rows.Count > page)
          ////    {



          ////        dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
          ////        //while (dataTable.Rows.Count > rowLimit)
          ////        //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();
          ////    }
          ////}
              DataView dvv = new DataView();
              dataTable.TableName = "table1";

              dvv.Table = dataTable;
              dtalstItems.DataSource = dvv;// dataTable; /// messages.dvorgProducts;
              dtalstItems.DataBind();


        
      }
      }
    }







   // LiveTimeReset

     






    protected DataSet getOrgs(String parm, string commandtext, int id, string status)
    {



        String orgEmail = ""; // ((HtmlInputControl)this.FindControl("orgEmail")).Value;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
        // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String orgTitle = ""; //  ((HtmlInputControl)this.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();
        String orgFunct = ""; //  ((HtmlInputControl)this.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
        String orgDesc = ""; // ((HtmlInputControl)this.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
        String orgTaxID = ""; //  ((HtmlInputControl)this.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

        String orgPaypal = ""; //  ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = ""; //  ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();

        // String buttonLogo = ""; //  ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = status;// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();



        //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

        //if (ConfirmImg!=null) 
        //{
        //    OnSaveClick(buttonLogo);
        //    return;

        //}





        orgStatus = status;// drplstEmailSts.SelectedValue.ToString();







        String prm = parm;






        //}

        // int id = 0;
        /// int Site = 0;// (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
        // String status = "pending";
        status = "";
        string orgVideo = "";

        DataSet ds = new DataSet();
        //if (prm!="2")  status = drplstEmailSts.SelectedValue=="All" ? String.Empty : drplstEmailSts.SelectedValue  ;
        //if (prm == "8") prm = "2";
        string commandText =commandtext;// "get_Orgs";



        if (prm == "S")
        {
            //orgStatus = ""; //drplstEmailSts.SelectedValue.ToString();
            ds = r.getOrgs(commandText,
         prm,
         id,
      orgTitle,
      orgFunct,
      orgDesc,
  orgTaxID,
  orgEmail,
  orgPaypal,
  orgLogo,
  orgStatus,orgVideo);

        }

        return ds;
    }















    protected void refresho(Object sender, EventArgs e)
    {


        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");



         Button btnBack = (Button)(MainContent.FindControl("btnBack"));







      



        BLCustomer cust = (BLCustomer)messages.cust;



        cust.Organization = cust.Organizationhld;

        if (messages.cust.Organizationhlder > 0)

        { btnBack.Visible = true; }
        else { btnBack.Visible = false; }


      //  ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
        DropDownList drplstOrgs = (DropDownList)Page.Master.FindControl("drplstOrgs");

        string idx = cust.Organization.ID.ToString();

        if (cust.Organization.ID == 0)
        { drplstOrgs.Items[0].Selected = true; }
        else
        {
            drplstOrgs.Items.FindByValue(idx).Selected = true;
        }


        ////drplstOrgs.SelectedValue = cust.Organization.ID.ToString();

       ////// cust.Organization = cust.Organizationhld;


        ///cust.Organization.ID = messages.orgID;



        itemSearch(sender, e);





    }




































    protected void refreshOrgs(Object sender, EventArgs e)
    {

        filters = items().Live;


      //////  messages.orgID = drplstOrgs.SelectedValue.IndexOf("All") == -1 ? Convert.ToInt16(drplstOrgs.SelectedValue) : messages.orgID;

        itemSearch( sender,   e);

        return;

















      DataView dv;
        DataSet ds = new DataSet();
        

      //  categoryProduct
        int catid = 0;

        int orgid = 0;// Convert.ToInt16(drplstOrgs.SelectedValue.ToString());

        ds = getItems("Q", "get_Items", custs().ID, catid, orgid, "");




           dv =                new DataView(ds.Tables[0]);
            
        int rowLimit = 4;

       // dv.RowFilter = "";
         

     ///   dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();


         
        //  return dataTable;
        UserControl category1 = (UserControl)Page.FindControl("category1");
        DataList catlstbx = (DataList)category1.FindControl("catlstbx");


        TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");
        TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

        //String txtPriceStarts = txtPriceStart.Text;
        //String txtPriceEnds = txtPriceEnd.Text;
        String filter = catlstbx.SelectedItem.ToString() + " " ;;

        dv.RowFilter = filter;
        dv.RowFilter = filter + "'currentBidPrice' >  txtPriceStarts and 'currentBidPrice' < txtPriceEnds ";




        UserControl uc = (UserControl)this.FindControl("orgProducts2");

        DataList dtalstItems = (DataList)uc.FindControl("dtalstItems");




        Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != ""  ? Convert.ToDecimal( txtPriceStart.Text ) : 0;

        Decimal   PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;

        


        DataTable dataTable = dv.ToTable();

        while (dataTable.Rows.Count > rowLimit)
            dataTable.Rows[dataTable.Rows.Count - 1].Delete();
        dtalstItems.DataSource = dataTable;// ds;

        dtalstItems.DataBind();








        string sortr = "";

        ////if (messages.dvorgProducts != null)
             sortr = messages.dvorgProducts.Sort.ToString() ;

       //// String sorter = drplstSort.SelectedValue.ToString();

      //if (  messages.dvorgProducts!=null)
     ////   messages.dvorgProducts.Sort =    sorter ;


    }







    public void checkout(object sender , EventArgs e)
    {
        string commandName = "get_orders";
        string prm="I";
        int auctionid =  items().AuctionID ;
        int orgid =   orgs().orgID;



        int buyerid = custs().buyerID;  

        int ordr_CreditCardInfoID=0; 
        int ordr_BillingAddressID=0;
                        int ordr_ShippingAddressID=0; 
        string ordr_Status="Ordered";
        String ordr_Type="P";

      ///  DataSet ds = new DataSet();

        BLOrders.GetOrdersList(commandName, prm, auctionid, orgid, buyerid, ordr_CreditCardInfoID, ordr_BillingAddressID,
                          ordr_ShippingAddressID, ordr_Status,                           ordr_Type            );



    }




    public DataSet getItems(String parm, string commandtext, int buyerid , int orgid, int catid, string status)
    {

        int itemid = 0;
        // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = 0;
        String location = "";
        // String orgPaypal = "";
        String description = "";
        String condition = "";
        //String shippngCost = status; 
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = commandtext;

        String prm = parm;



        String auctiontype = "";
        status = "";

        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
        //   string commandName;

        if (prm == "S" || prm == "Q")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,buyerid, itemid, orgid, catID, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype, 0
     );
        }




        return ds;
    }



      




    protected void load()
    {


        if (!IsPostBack)
        {


            mails.prm =  "2";
            String qry = Server.UrlDecode(Request.QueryString.ToString());



            if (qry != null && qry.Length > 0 && qry.ToString() != string.Empty)
            {
                mails.prm = qry.ToString().IndexOf("prm=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("prm=") + 4, qry.Length - 4);

            }




            if (mails.prm != "2" && (Logins.password != "itty" || Logins.userid != "itty"))
            { return; }


            if (mails.prm == "2" && (Logins.password == "itty" || Logins.userid == "itty"))
            {
                mails.prm = "8";
            }


            //if (mails.prm != "2") { drplstEmailSts.Visible = true; lblsts.Visible = true; }
            //else { drplstEmailSts.Visible = false; lblsts.Visible = false; }



            SubGmachTitle = "View Orgs ";
            if (mails.prm == "4")
            {
                SubGmachTitle = "View Orgs ";
               
            }
            if (mails.prm == "5")
            {
                SubGmachTitle = "View Principals "  ;
             
            }

          /////////////  UpdateDonate("S", "get_Orgs", 0, drplstEmailSts.SelectedValue.ToString());
            int orgid = Convert.ToInt16(messages.orgID);
            int catid = Convert.ToInt16(messages.catID);


            UpdateDonate("S",   "get_Items",0, catid, orgid, "");



            //if (mails.prm =="1")
            //{
            //    Update_Donate();
            //}



          
        }
    }

    protected void email(Object sender,  EventArgs e)
    {
       /// GridViewRow row = ((GridView)sender).Rows[e.RowIndex];

       /// HtmlContainerControl dvEmil = (HtmlContainerControl)row.FindControl("dvEmil");

      ///  HtmlTextArea txtemail = (HtmlTextArea)dvEmil.FindControl("txtemail");

    }



    protected void orgssub(Object sender, GridViewCommandEventArgs  e)
    {
        //grdvSubGmach.EditIndex = -1;
       // grdvSubGmach.DataBind();
      
        
        //@opt varchar(1), 
        //    @itemID  INT, 
        //    @catID  int ,
        //@orgID  int 
        int orgid = Convert.ToInt16( messages.orgID);
        int catid = Convert.ToInt16(messages.catID);

        UpdateDonate("S", "get_Items", 0, catid, orgid, "");
       ////////// UpdateDonate("A", "set_Orgs", 0, "pending");
        try
        {
            //GridViewRow row = ((GridView)sender).Rows[e.RowIndex];



            //HtmlContainerControl dvEmil = (HtmlContainerControl)row.FindControl("dvEmil");

            //HtmlTextArea txtemail = (HtmlTextArea)dvEmil.FindControl("txt_email");
            //TextBox txtEmail = (TextBox)dvEmil.FindControl("txtemail");
        }
        catch { }

    }



    protected void emailsub(Object sender, GridViewCancelEditEventArgs e)
    {
        //grdvSubGmach.EditIndex = -1;
        //grdvSubGmach.DataBind();
      // UpdateDonate("S", "get_Orgs",0);


        int orgid = Convert.ToInt16(messages.orgID);
        int catid = Convert.ToInt16(messages.catID);

        UpdateDonate("S",   "get_Items",0, catid, orgid, "");
      ///////  UpdateDonate("S", "get_Orgs",0,"pending");
        try
        {
            //GridViewRow row = ((GridView)sender).Rows[e.RowIndex];



            //HtmlContainerControl dvEmil = (HtmlContainerControl)row.FindControl("dvEmil");

            //HtmlTextArea txtemail = (HtmlTextArea)dvEmil.FindControl("txt_email");
            //TextBox txtEmail = (TextBox)dvEmil.FindControl("txtemail");
        }
        catch { }

        }


     
 protected DataSet UpdateDonate(String parm, string commandtext, int buyerid, int orgid, int catid, string status)
    {

        int itemid=0;
       // int orgid=0;  
        int shippngCost=0;   
      //  int orgid = 0;  
        String title = ""; 
        int quantity = 0; 
        int catID = 0;  
        String location = "";  
        String orgPaypal = ""; 
        String description = "";  
          String condition = "";  
        //String shippngCost = status; 
        DateTime startDate = DateTime.Today ;
        DateTime endDate = DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = commandtext;
        
        String prm = parm;



        String auctiontype = "";
        status = "";

        DataSet ds = new DataSet();
        
        string commandText = commandtext;
        commandName = commandtext; 
     //   string commandName;

        if (prm == "S")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,buyerid, itemid, orgid, catID, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype,0
     );
        }




        return ds;
    }

    protected void SubGmachBind(Object sender,   GridViewRowEventArgs e)
    {

        switch  ( e.Row.RowType)
        { 
            


          

            case  DataControlRowType.DataRow:

                if (e.Row.RowState > 0 && DataControlRowState.Selected > 0)
                {
              //      e.Row.Attributes.Add("onClick", "javascript:return confirm('Are you sure that you want to delete this record?')");
                }
                


             //   if (e.Row.RowState > 0  && DataControlRowState.Edit > 0  ) 
             //{
             //    e.Row.Attributes.Add("onfocus", "javascript:return confirm('Are you sure that you want to delete this record?')");
             //}
          
                int y = e.Row.RowIndex;
                if (mails.prm == "2")
                {
                    //////////////e.Row.Cells[17].Controls[0].Visible = false;
                    //////////////e.Row.Cells[16].Controls[0].Visible = true;
                }
            break;
            //case DataControlRowType.DataRow:

            //if (mails.prm != "2")
            //{
            //   // e.Row.Cells[1].Controls[0].Attributes.Add("onclick", "document.getElementById('" + Label2.ClientID + "').innerHTML='Thank you';");
                

            //    e.Row.Cells[16].Controls[0].Visible = true;
            //}
            //break;
        
        
        }
              
     }



    protected void approveOrg(Object sender,  EventArgs e)
    {

   //     DataSet ds = (DataSet)   ((GridView) grdvSubGmach).DataSource;
   //     int id = 0;
   //     bool cb = false;

   //     foreach (GridViewRow dr in grdvSubGmach.Rows)
   //     {

   //         foreach (TableCell cc in dr.Cells)
   //         {
   //             if (cc.FindControl("id") != null)
   //             {
   //                   id = (int)Convert.ToInt16(((Label)(cc.FindControl("id"))).Text);
   //               cb = ((CheckBox)dr.Cells[3].FindControl("chkStatus")).Checked;
   //                   break;
   //             }
                  
   //         }


   ////   cb=       ( (CheckBox) dr.Cells[3].FindControl("chkStatus")).Checked  ;



   //     // id =(int) Convert.ToInt16(  ( (Label) (       dr.Cells[2].FindControl("id"))).Text)  ;


   //         if
   //             (cb==true    )


   //            //////// UpdateDonate("A", "set_Orgs", id , "approved");

   //         {
            

           

   //         //}
            
   //         }

   //         }
     


    }








    protected void Edit(Object sender, GridViewEditEventArgs e)
    {
      //  UpdateDonate("S", "get_Orgs", 0, "pending");
         //grdvSubGmach.EditIndex = e.NewEditIndex;

         //grdvSubGmach.DataBind();


     }












    protected void Delete(Object sender, GridViewDeleteEventArgs e)
    {

        //String email = (String)Request.Form["email"] == null ? "0" : "1";         // (String)Request.Form["email"] == null ? Request.Form["email"].ToString() : Request.Form["email"].ToString();
        //String subtype = (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        ////String firstName = (String)Request.Form["firstName"] == null ? Request.Form["First Name"].ToString() : Request.Form["firstName"].ToString();
        ////String lastName = (String)Request.Form["lastName"] == null ? Request.Form["Last Name"].ToString() : Request.Form["lastName"].ToString();
        //String tel = (String)Request.Form["tel"] == null ? "0" : "1";// (String)Request.Form["tel"] == null ? Request.Form["tel"].ToString() : Request.Form["tel"].ToString();





        //String sunday = (String)Request.Form["sunday"] == null ? "0" : "1";
        //String monday = (String)Request.Form["monday"] == null ? "0" : "1";
        //String tuesday = (String)Request.Form["tuesday"] == null ? "0" : "1";
        //String wednesday = (String)Request.Form["wednesday"] == null ? "0" : "1"; //Request.Form["wednesday"].ToString() : Request.Form["wednesday"].ToString();
        //String thursday = (String)Request.Form["thursday"] == null ? "0" : "1";  //Request.Form["thursday"].ToString() : Request.Form["thursday"].ToString();
        //String friday = (String)Request.Form["friday"] == null ? "0" : "1";  //Request.Form["friday"].ToString() : Request.Form["friday"].ToString();
        //String morning = (String)Request.Form["morning"] == null ? "0" : "1"; ///       Request.Form["morning"].ToString() : Request.Form["morning"].ToString();
        //String afternoon = (String)Request.Form["afternoon"] == null ? "0" : "1"; // Request.Form["afternoon"].ToString() : Request.Form["afternoon"].ToString();
        //String evening = (String)Request.Form["evening"] == null ? "0" : "1";      // Request.Form["evening"].ToString() : Request.Form["evening"].ToString();
        //String subType = (String)Request.Form["subType"] == null ? "0" : "1";// (String)Request.Form["subType"] == null ? Request.Form["subType"].ToString() : Request.Form["subType"].ToString();

        //String prm = "d";


        //String avail_request = Request.Form["avail_request"];





        GridViewRow row = ((GridView)sender).Rows[e.RowIndex];//row.Cells[13].Controls[0]

        ////LiteralControl ltEmil = (LiteralControl)row.Cells[22].Controls[0];

        ////TextBox ID = (TextBox)row.Cells[1].Controls[0];
        string id = "";// ID.Text;

       
        ////HtmlContainerControl dvEmail = (HtmlContainerControl)ltEmil.FindControl("dvEmail");

        ////////////////////  HtmlTextArea txtemail = (HtmlTextArea)ltEmil.FindControl("txtemail");
        ////TextBox txtemailfff = (TextBox)ltEmil.FindControl("txtemail");



        //HtmlTextArea txtemaillllll = (HtmlTextArea)ltEmil.FindControl("txt_email");


        string status = "";







     
       //  grdvSubGmach.EditIndex = e.NewEditIndex;
        string firstName = "";
        string lastName = "";


         string commandText = "setMatches";

         //r.setMatches(commandText, prm, id, morning, afternoon, evening,
         //  sunday, monday, tuesday, wednesday, thursday, friday,
         //  subType, avail_request, email, firstName, lastName, tel, status);
         //grdvSubGmach.AutoGenerateColumns = false;

         ///UpdateDonate("S", "get_Orgs", 0, "pending");

     }

    






    protected void RowDataBound(Object sender, GridViewRowEventArgs e)
    {
   //      e.Row..DataItem;
   //      GridViewRow row = ((GridView)sender).Rows[e.RowIndex];

   //      HtmlContainerControl dvEmil = (HtmlContainerControl)row.FindControl("dvEmil");

   //HtmlTextArea    txtemail =  ( HtmlTextArea)  dvEmil.FindControl("txtemail");



     //    HtmlContainerControl hh = (HtmlContainerControl)e.NewValues[9];

         //int i = e.NewSelectedIndex;dvEmil

        //grdvSubGmach.EditIndex = e..Row.DataItemIndex;
       /// grdvSubGmach.DataBind();

     }



    protected void editGrid(Object sender,  EventArgs e)
         
     {

         }












    protected void RowUpdating(Object sender, GridViewUpdateEventArgs e)
    {


        GridViewRow row = ((GridView)sender).Rows[e.RowIndex];//row.Cells[13].Controls[0]
        String id = ((Label)row.FindControl("id")).Text;

        String status = ((DropDownList)row.FindControl("drplstSts")).SelectedValue;

        String subType = ((DropDownList)row.FindControl("drpsub_Type")).SelectedValue;
     
        String sunday = ((CheckBox)row.FindControl("sunday_")).Checked.ToString();
        String monday = ((CheckBox)row.FindControl("monday_")).Checked.ToString();

        String tuesday = ((CheckBox)row.FindControl("tuesday_")).Checked.ToString();
        String wednesday = ((CheckBox)row.FindControl("wednesday_")).Checked.ToString();
        String thursday = ((CheckBox)row.FindControl("thursday_")).Checked.ToString();
        String friday = ((CheckBox)row.FindControl("friday_")).Checked.ToString();

        String morning = ((CheckBox)row.FindControl("morning_")).Checked.ToString();
        String afternoon = ((CheckBox)row.FindControl("afternoon_")).Checked.ToString();
        String evening = ((CheckBox)row.FindControl("evening_")).Checked.ToString();

        String email = ((TextBox)row.FindControl("email")).Text;
        String firstname = ((TextBox)row.FindControl("firstname")).Text;
        String lastname = ((TextBox)row.FindControl("lastname")).Text;

        String tel = ((TextBox)row.FindControl("tel")).Text;
        


       /// int yyy = drplstSts.SelectedIndex;


        
        ////   LiteralControl ltEmil = (LiteralControl)row.Cells[22].Controls[0];
        ////  HtmlContainerControl  dvEmail=(HtmlContainerControl) ltEmil.FindControl("dvEmail");

        ////////////////////  HtmlTextArea txtemail = (HtmlTextArea)ltEmil.FindControl("txtemail");
        ////  TextBox txtemailfff = (TextBox)ltEmil.FindControl("txtemail");



        ////  HtmlTextArea txtemaillllll = (HtmlTextArea)ltEmil.FindControl("txt_email");


        /// UpdateDonate("S", "get_Orgs",0);
        //    HtmlContainerControl hh = (HtmlContainerControl)e.NewValues[9];

        //int i = e.NewSelectedIndex;dvEmil

        //grdvSubGmach.EditIndex = e..Row.DataItemIndex;
        /// grdvSubGmach.DataBind();
        /// 
















        for (int y = 0; y <= row.Cells.Count; y++)
           
        
        {
   //         string n = e.OldValues.Count.Cells[y].Controls[0].ID;
        }

 
        ;
        //////String subType = e.NewValues[0].ToString();
        //////String prm = "u";


        String avail_request = "";





        // GridViewRow row = ((GridView)sender).Rows[e.RowIndex];//row.Cells[13].Controls[0]

        ////LiteralControl ltEmil = (LiteralControl)row.Cells[22].Controls[0];

        ////TextBox ID = (TextBox)row.Cells[1].Controls[0];
        ////string id = ID.Text;


        ////HtmlContainerControl dvEmail = (HtmlContainerControl)ltEmil.FindControl("dvEmail");

        ////////////////////  HtmlTextArea txtemail = (HtmlTextArea)ltEmil.FindControl("txtemail");
        ////TextBox txtemailfff = (TextBox)ltEmil.FindControl("txtemail");



        //HtmlTextArea txtemaillllll = (HtmlTextArea)ltEmil.FindControl("txt_email");


        ////string status = e.NewValues[0].ToString(); ;





        string prm = "u";


        //////  grdvSubGmach.EditIndex = e.NewEditIndex;
        //////string firstName = "";
        //////string lastName = "";


        string commandText = "setMatches";

        //r.setMatches(commandText, prm, id, morning, afternoon, evening,
        //  sunday, monday, tuesday, wednesday, thursday, friday,
        //  subType, avail_request, email, firstname, lastname, tel, status);
        //////grdvSubGmach.AutoGenerateColumns = false;

        //////////UpdateDonate("S", "get_Orgs", 0, "pending");

        //////grdvSubGmach.EditIndex = -1;


        //////grdvSubGmach.DataBind();



    }










        

    protected void Row_Updating(Object sender, GridViewUpdatedEventArgs  e)
         
     {
        

        // GridViewRow row = ((GridView)sender).Rows[e.RowIndex];//row.Cells[13].Controls[0]

      ////   LiteralControl ltEmil = (LiteralControl)row.Cells[22].Controls[0];
      ////  HtmlContainerControl  dvEmail=(HtmlContainerControl) ltEmil.FindControl("dvEmail");

      ////////////////////  HtmlTextArea txtemail = (HtmlTextArea)ltEmil.FindControl("txtemail");
      ////  TextBox txtemailfff = (TextBox)ltEmil.FindControl("txtemail");



      ////  HtmlTextArea txtemaillllll = (HtmlTextArea)ltEmil.FindControl("txt_email");


       /// UpdateDonate("S", "get_Orgs",0);
     //    HtmlContainerControl hh = (HtmlContainerControl)e.NewValues[9];

         //int i = e.NewSelectedIndex;dvEmil

        //grdvSubGmach.EditIndex = e..Row.DataItemIndex;
       /// grdvSubGmach.DataBind();
       /// 























            String id =e.OldValues[0].ToString()   ;
         String email =e.NewValues[0].ToString()   ;
         String subtype =e.NewValues[0].ToString() ;
         String firstName = e.NewValues[0].ToString()  ;
         String lastName =e.NewValues[0].ToString() ;
         String tel = e.NewValues[0].ToString() ;




         String sunday = e.NewValues[0].ToString() ;
         String monday = e.NewValues[0].ToString() ;
         String tuesday = e.NewValues[0].ToString() ;
         String wednesday = e.NewValues[0].ToString() ;
         String thursday = e.NewValues[0].ToString() ;
         String friday =  e.NewValues[0].ToString() ;
         String morning =  e.NewValues[0].ToString() ;
         String afternoon =  e.NewValues[0].ToString() ;
         String evening =  e.NewValues[0].ToString() ;
         String subType =  e.NewValues[0].ToString() ;
         String prm = "u";


         String avail_request = e.OldValues[0].ToString() ;





        // GridViewRow row = ((GridView)sender).Rows[e.RowIndex];//row.Cells[13].Controls[0]

         ////LiteralControl ltEmil = (LiteralControl)row.Cells[22].Controls[0];

         ////TextBox ID = (TextBox)row.Cells[1].Controls[0];
         ////string id = ID.Text;


         ////HtmlContainerControl dvEmail = (HtmlContainerControl)ltEmil.FindControl("dvEmail");

         ////////////////////  HtmlTextArea txtemail = (HtmlTextArea)ltEmil.FindControl("txtemail");
         ////TextBox txtemailfff = (TextBox)ltEmil.FindControl("txtemail");



         //HtmlTextArea txtemaillllll = (HtmlTextArea)ltEmil.FindControl("txt_email");


         string status =   e.NewValues[0].ToString() ;;








         //  grdvSubGmach.EditIndex = e.NewEditIndex;
         //string firstName = "";
         //string lastName = "";


         string commandText = "setMatches";

         //r.setMatches(commandText, prm, id, morning, afternoon, evening,
         //  sunday, monday, tuesday, wednesday, thursday, friday,
         //  subType, avail_request, email, firstName, lastName, tel, status);
         ////grdvSubGmach.AutoGenerateColumns = false;

         ///UpdateDonate("S", "get_Orgs", 0, "pending");


























     }


    protected void RowCommand(Object sender, GridViewCommandEventArgs e)
         
     {


        

        //int i = e.NewSelectedIndex;

        //grdvSubGmach.EditIndex = e..Row.DataItemIndex;
      //////////  grdvSubGmach.DataBind();

     }




    protected void indexchange(Object sender,  GridViewSelectEventArgs e)
    {


    String id=    ((GridView)sender).Rows[e.NewSelectedIndex].Cells[2].ToString(); 

        //int i = e.NewSelectedIndex;

        //////grdvSubGmach.EditIndex = e.NewSelectedIndex ;
        //////grdvSubGmach.DataBind();

    }

 


    protected void build(string prm, string soldFixedBid)
    {
       // HtmlContainerControl trOutofStock = (HtmlContainerControl)UpdatePanel1.FindControl("trOutofStock");
        //////// trOutofStock.Visible = false;

        DataTable dt = new DataTable();
        //  String soldFixedBid = "bid";

        int orgid = messages.cust.Organization.ID;// Convert.ToInt16(messages.orgID);
        int catid = messages.blitem.catID;// Convert.ToInt16(messages.catID);
        int itemid = messages.blitem.ID;// Convert.ToInt16(messages.itemID);
        string bidtype = messages.bidtype;
        int buyerid = messages.cust.ID;// messages.buyerID;
        DateTime biddate = DateTime.Now;
     //   Decimal bidamount = txtBidamount.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtBidamount.Text);
        int credits = 1;
        int fee_per_bid = 0;
        int auctionid = messages.auctionID;


        if (bidtype == "penny")
        {
         //   if (credits > 0) { bidamount = credits * 1; }
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

      //  Decimal bid = UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);



        //////prm = "E";
        //////Decimal credtsowned = UpdateItems(prm, "get_Bids", auctionid, buyerid, biddate, bidamount, credits, soldFixedBid, fee_per_bid);



        //////messages.credits  = Convert.ToInt32( credtsowned) ;









      ///  lblCurrentBidPrice.Text = bid.ToString();



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
         //   txtBidamount.Visible = false;//.Text = bid.ToString();

            //btnBuyNow.Visible = false;
         //   lblCurrentBidPrice.Text = bid.ToString();
            //btnBidder.Visible = false;


            //prm = "X";
            DataSet ds = new DataSet();



            /// ds = UpdateDonate(prm, "get_Items", 0, catid, orgid, itemid, "", bidtype,messages.auctionID);

           // ds = BLItem.GetAuctionItemt(item(), prm, "get_Items", custs().ID, catid, orgid, itemid, "", bidtype,  items().AuctionID);
            ds = item().GetAuctionItemt(item(), prm, "get_Items", custs().ID, catid, orgid, itemid, "", bidtype, items().AuctionID);

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
       // ds = bidst("T");








        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {


            DataRow dtr = ds.Tables[0].Rows[0];

            Decimal Tbidamount = dtr["bidamount"].ToString() == string.Empty ? 0 : Convert.ToDecimal(String.Format("{0:d}", dtr["bidamount"].ToString()));

            int Tcredits = dtr["credits"].ToString() == string.Empty ? 0 : Convert.ToInt16(dtr["credits"].ToString());


            //lblCreditsUsed.Text = Tcredits.ToString();
            //lblMoneySpent.Text = String.Format("{0:d}", Tbidamount.ToString());
            // lblMoneySpent.Text = String.Format("{0:d}", MoneySpent.ToString());
            // lblCreditsUsed.Text = credits.ToString();

        }




        DateTime startTime = Convert.ToDateTime(dr["startTime"].ToString());
        //   DateTime endDate = Convert.ToDateTime(dr["endDate"].ToString());
        DateTime soldTime = Convert.ToDateTime(dr["soldTime"].ToString());
        int buyitNow = dr["buyitNow"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["buyitNow"].ToString());
        String shipping = dr["shipping"].ToString() == string.Empty ? "0" : dr["shipping"].ToString();
        String handlingTime = dr["handlingTime"].ToString() == string.Empty ? "" :   dr["handlingTime"].ToString();
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

       // lblCartPrice.Text = String.Format("{0:d}", currentBidPrice.ToString());







        ///lblHighestBidder.Text = buyer_name;


        int credits = dr["credits"] == null || dr["credits"].ToString() == "" ? 0 : Convert.ToInt16(dr["credits"].ToString());
        int buyerid = dr["buyerid"] == null || dr["buyerid"].ToString() == "" ? 0 : Convert.ToInt16(dr["buyerid"].ToString());







        //messages.credits=credits ;

        decimal MoneySpent = Convert.ToDecimal((credits * .50));


        //  String itemStatus = dr["itemStatus"].ToString();

        Decimal soldAmount = Convert.ToDecimal(String.Format("{0:c}", dr["soldAmount"].ToString()));



        int returnDays = dr["returnDays"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["returnDays"].ToString());
        int quantity = dr["quantity"].ToString() == string.Empty ? 0 : Convert.ToInt16(dr["quantity"].ToString());

        //  messages.bidEndTime =   endTime ;





      //  lblSold.Text = "";
        DateTime dtNow = new DateTime();


        dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);

        DateTime dtFuture = new DateTime();//  (messages.bidEndTime.Year, messages.bidEndTime.Month, messages.bidEndTime.Day, messages.bidEndTime.Minute, messages.bidEndTime.Second, messages.bidEndTime.Millisecond);//        dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

     ////////////////////////////////////   dtFuture = messages.bidEndTime;

        TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
        ts = dtFuture.Subtract(dtNow);
        long amount = (long)ts.TotalMilliseconds;

       /////////////// messages.bidTimeLeft = amount;

        amount = messages.amount_;

        if (amount <= 0)
        {
            //btnBidder.Visible = false;
            //if (buyerid == 0)
            //{ lblSold.Text = "Canceled"; }
            //else { lblSold.Text = "Sold"; }
        }
        else
        {
            //if(credits==0)
            if (custs().Credits <= 0)
            {
                // btnBidder.Enabled = false;
              ////  lblSold.Text = "out of credits please buy more";
            }
            //btnBidder.Visible = true; 

        }



               

        //  lblCondition.Text = condition;
        lblCurrentBidPrice.Value = String.Format(Double.Parse(currentBidPrice).ToString(), "$0,00.00");

        lblProductTitles.Value = title;
        /// lblStartBidPrice.Text = String.Format( startBidPrice, "$0,00.00") ;
        lblHandling.Value = handlingTime.ToString();

        lblShipping.Value = shipping;

        ///  lblReturndays.Text = returnDays.ToString();

        //lblAuctiontype.Text = auctiontype;


        // String[] img = { dr["imgPath1"].ToString(), dr["imgPath2"].ToString(), dr["imgPath3"].ToString(), dr["imgPath4"].ToString() };// new String[5];


        String[] img = { dr["img1"].ToString(), dr["img2"].ToString(), dr["img3"].ToString(), dr["img4"].ToString() };// new String[5];
        DataTable dt = new DataTable();


       dt = getImages(img);

        //iqImagesThumb.DataSource = dt;

        //iqImagesThumb.DataBind();





        //lblDonated.Text = messages.donatecount.ToString();


    }








    private DataTable getImages(String[] img)
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


        for (int y = 0; y < img.Length; y++)
        {


            dr = dt.NewRow();
            dr["id"] = 0;
            dr["img"] = "Images/" + img[y];
            dr["ThumbImageUrl"] = "Images/" + img[y];
            dr["MediumImageUrl"] = "Images/" + img[y];
            dr["FullImageUrl"] = "Images/" + img[y];

            dt.Rows.Add(dr);


            if (y == 0) MediumImageUrl = dr["MediumImageUrl"].ToString();
        }




        return dt;
    }





    protected void CheckoutProscessing(object sender , EventArgs e)
    {
        CreditCardProscessing(12);




    }




    


    protected void CreditCardProscessing(int credits)
    {
        Decimal tot = Convert.ToDecimal(credits * .60);

        string dblDonationAmount = tot.ToString();
      ////  lblmsg.Text = "";


        CrediCardProscessing CardPro = new CrediCardProscessing();
        CardPro.FirstName = "Eli";// this.tbFirstName.Text;
        CardPro.LastName = "Barber";// this.tbLastName.Text;
        CardPro.Address = "672 Crown St.";//this.tbAddress.Text;
        CardPro.City = "Bklyn";//txtbCity.Text;
        CardPro.State = "NY";// txtbState.Text;
        CardPro.ZIP = "11213";// this.tbPostalCode.Text;
        CardPro.Country = "US";//this.ddlCountry.SelectedValue;
        CardPro.CardNumber = this.txtCardNumber.Text;
        CardPro.Expiration = this.cmbCardExpMonth.SelectedValue + "/" + this.cmbCardExpYear.SelectedValue;
        CardPro.CVV = this.txtCardCVV2.Text;
        CardPro.CustomerIP = Request.UserHostAddress;


        Trace.Write("Amount", dblDonationAmount);

        CardPro.Amount = Double.Parse(dblDonationAmount, System.Globalization.NumberStyles.Currency);
        bool ProsPassed = CardPro.SubmitPayment("Donation to Friendshipcircle");
       /// lblmsg.Text =  CardPro.ErrorMessage;
        if (ProsPassed)
        {
            string bodytext = "Proscess Result Information\n--------------\n" +
                  "Authorization Code: " + CardPro.AuthorizationCode + "\n" +
                  "Transaction ID: " + CardPro.TransactionID + "\n";
            string ltrlResults = "<div style=\"color:#1C405E;\">You Have Successfully Donated to The Friendship " +
                 "Circle<br/>Authorization Code: " + CardPro.AuthorizationCode +
                 "<br/>Transaction ID: " + CardPro.TransactionID + @"<h2>Thank You</h2>Thank you for your support in assisting the Friendship Circle to continue supporting children with special needs, giving them and volunteers alike, a meaningful experience at our Ferber-Kaufman LifeTown at the Meer Family Friendship Center.  

 <div style=""font-size:smaller;"">Your contribution towards the Friendship Circle is tax deductible. 

Please print this page for your tax deductible receipt. 
</div></div>";



        }

    }
























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





 
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

public partial class orgProducts : System.Web.UI.Page
{


    public string filters = "";

    public  decimal credits   ;
    public string category;

    DataSet ds;
    DataTable dataTable;
      

   
    Referrer r = new Referrer();
    public String SubGmachTitle = "";


    //BLItems items = (BLItems)messages.cust.Organization.Orgitems;
    //BLOrganization org  = ((BLOrganization)messages.cust.Organization) ;
    //BLCustomer cust = ((BLCustomer)messages.cust);

    

    protected void ListChanged(object sender, EventArgs e)
    {

    }



    protected void OnDataBinding_rptBreadCrumbs(object sender, RepeaterItemEventArgs e)
    {


        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:

                DataRowView dtRow = (DataRowView)e.Item.DataItem;

                category = dtRow[1].ToString();
        
                ///  dtRow[0] = dtRow[0] + ">";
                break;

        }




    }





    protected void BreadCrumbLink_Click(Object sender, EventArgs e)
    {
        String dir = ((LinkButton)sender).CommandName.ToString();

 
        pagestatus.dir = dir;
       
        items().CatID = Convert.ToInt16(dir); 
        BLItems.raise(sender, e); 
    }




















    protected void Page_Load(object sender, EventArgs e)
    {


        rptBreadCrumbs.DataSource = items().CatbreadCrumbs;
        rptBreadCrumbs.DataBind();
      

        ///credits=BLOrganization.getCredits;
        credits = custs().Credits;




        if (custs().Organizationhlder > 0)

        { btnBack.Visible = true; }
        else { btnBack.Visible = false; }

        //if (IsPostBack)
        //{
        //    HtmlGenericControl catHeader = (HtmlGenericControl)this.FindControl("catHeader");
        //    catHeader.InnerHtml = category;
        //}




        if(!IsPostBack)
        {
            items().Live = "";
        }

         filters = items().Live;

         //ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
         //UserControl category1 = (UserControl)MainContent.FindControl("category1");



      ///////////////////////   BLItems.navigateCat += new EventHandler( itemSearch);






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
        int origid =   Convert.ToInt16(orgs().orgID);


        BLCustomer cst = (BLCustomer)custs();

        DataSet ds = orgs().GetOrgList(ref cst, "S", "get_Orgs", origid, status);

        custs_ = cst;






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



















     itemSearch(  sender,   e);

       /// load();
       /// 

       ///////////////////////////// loads();
            //////////////}

        int catid = 0;
        int orgid = messages.orgID;

        DataSet dst = new DataSet();

        dst = UpdateDonate("C", "get_Items", custs().ID, catid, orgid, "");

   


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

    protected void itemSearch1(Object sender, EventArgs e)
    {
        String dir = ((LinkButton)sender).CommandName.ToString();

        messages.orgs_.Orgitems.CatID = Convert.ToInt16( dir);

        itemSearch(sender, e);
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
           UserControl category1 = (UserControl)MainContent.FindControl("category1");

           ListBox lstcat = (ListBox)(MainContent.FindControl("category1")).FindControl("lstcat");
       

      TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");

      TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

      Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

      Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;

       
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


      int orgid =   orgs().orgID;// ((BLCustomer)messages.cust).Organization.ID;
      int catid =  orgs().Orgitems.CatID;       // ((BLCustomer)messages.cust).Organization.Orgitems.CatID; /// messages.catID;

      DataSet ds = new DataSet();

      String param = "";


   ///   ds =            messages.UpdateDonate("I", "get_Items", 0, catid, orgid, txtItemSearch.Text.Trim());

      if (items() == null || orgs().Orgitems.Items ==null  || orgs().Orgitems.Items.Tables.Count == 0 || orgs().Orgitems.Items.Tables[0].Rows.Count == 0)    
      
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

 




          if (PriceEnd > 0 && PriceEnd > PriceStart ||  ( filters != null && filters != ""))
          {
              if (PriceEnd > 0 && PriceEnd > PriceStart && ( filters != null && filters != ""))
              {
                  dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd + " and " + filters;
              }
              else
              {
                  if (PriceEnd > 0 && PriceEnd > PriceStart)
                  {
                      dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd;
                  }
                  else { dv.RowFilter = filters; }
              }
          }



          dv.Sort = drplstSort.SelectedValue.ToString();

          /// ((BLCustomer)messages.cust).Organization.Orgitems.ItemsDV = dv;

          DataTable dataTable = dv.ToTable();

          items().dataTable = dataTable;




          int totPages = dataTable.Rows.Count / rowLimit;
          int totPagesRem = dataTable.Rows.Count % rowLimit;
 


          items().rempage = totPagesRem;

          items().totpage = totPagesRem > 0 && dataTable.Rows.Count >= rowLimit ? totPages + 1 : totPages;

          //////////////////    int totPagesRemAll = messages.DataTable.Rows.Count % rowLimit;




          UserControl pageing1 = (UserControl)MainContent.FindControl("pageing1");

      /////////////////////////////    Label CurrentPage = (Label)pageing1.FindControl("CurrentPage");

          Label TotalPages = (Label)pageing1.FindControl("TotalPages");



          DropDownList drplstCPage = (DropDownList)pageing1.FindControl("drplstCPage");




          ////////////////////CurrentPage.Text = items().pager.ToString();


          TotalPages.Text = totPages.ToString();


          totPages = totPagesRem > 0 && dataTable.Rows.Count>0 ? totPages + 1 : totPages;

          drplstCPage.Items.Clear();
          for (int pg = 1; pg <= totPages; pg++)
          {
              ListItem pages = new ListItem();
              pages.Value = pg.ToString();

              drplstCPage.Items.Add(pages);

          }

      //////////////////////////////////////////////////////////////////    drplstCPage.SelectedIndex = items().pager - 1;

          if (dataTable.Rows.Count > 0)
          {

              //////////////////  messages.DataTable = dataTable;
              //////if (ds.Tables[0].Rows.Count>0)
              //////    messages.DataTable = dataTable;

              if (dataTable.Rows.Count > page)
              {



                  dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
                  //while (dataTable.Rows.Count > rowLimit)
                  //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();
              }
          }
              DataView dvv = new DataView();
              dataTable.TableName = "table1";

              dvv.Table = dataTable;
              dtalstItems.DataSource = dvv;// dataTable; /// messages.dvorgProducts;
              dtalstItems.DataBind();


        
      }
      }
    }







   // LiveTimeReset

    protected void showResults(Object sender, EventArgs e)
    {string filter="";

            
        if(  ((ImageButton)sender).ID=="btnLive")
        {
            filters = " Live = " + "'BID'";
             items().Live = " Live = " + "'BID'";
        }
        else
        {
            if (((ImageButton)sender).ID == "btnLocked")
            {
                filters = " Live = " + "'Countdown'";
                 items().Live = " Live = " + "'Countdown'";
            }
            else
            {
                if (((ImageButton)sender).ID == "btnAll")
                {
                    items().Live =  "";

                }
            }
        }
        




        items().pager = 0;
        ////////items().rowlimit = 10;


        string sortr = "";

        //if (messages.dvorgProducts != null)
        //    sortr = messages.dvorgProducts.Sort.ToString();





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


        DropDownList drplstSort = (DropDownList)MainContent.FindControl("drplstSort");
        String sorter = drplstSort.SelectedValue.ToString();
        if (messages.dvorgProducts != null)
            messages.dvorgProducts.Sort = sorter;


        DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
        UserControl category1 = (UserControl)MainContent.FindControl("category1");

        ListBox lstcat = (ListBox)(MainContent.FindControl("category1")).FindControl("lstcat");


        TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");

        TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

        Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

        Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;


        //[get_Categories]


        //    @opt varchar(1),  
        //    @catID  int ,
        //    @catName varchar(50


        if (lstcat != null && lstcat.SelectedValue.ToString().Trim() != "")
        {
         /////////////   messages.catID = Convert.ToInt16(lstcat.SelectedValue.ToString());


        }


        //if (lstcat != null)
        //{
        //    messages.origID = drplstOrgs.SelectedValue.ToString() == "" ? 0 : Convert.ToInt16(drplstOrgs.SelectedValue.ToString() == "");

        //}


        int orgid = orgs().orgID;// messages.orgID;
        int catid =  items().CatID;

        DataSet ds = new DataSet();


     ///////////////////////   ds = messages.UpdateDonate("I", "get_Items", 0, catid, orgid, "");
        BLCustomer cst = (BLCustomer)custs();
        ds = items().GetItemsList(ref cst, "J", "get_Items", 0, orgid, catid, "");







        //DataView dv = new DataView((DataTable)dtalstItems.DataSource);
        DataView dv = new DataView(ds.Tables[0]);




        int rowLimit = items().rowlimit;
        int page = items().pager * rowLimit;
       ////////////// items().pager += 1;


        if (ds.Tables.Count > 0)
        {
            filters =  items().Live;


            if (PriceEnd > 0 && PriceEnd >= PriceStart ||  ( filters != null && filters != ""))
            {
                if (PriceEnd > 0 && PriceEnd >= PriceStart &&  ( filters != null && filters != ""))
                {
                    filters += filters.Trim() != "" ? " and " : "";

                    dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd     ;
                    if(filters.Trim()!=""){  dv.RowFilter +=  " and " + filters;}
                }
                else
                {
                    if (PriceEnd > 0 && PriceEnd >= PriceStart)
                    {
                        dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd;
                    }
                    else { dv.RowFilter = filters; }
                }
            }

            dv.Sort = drplstSort.SelectedValue.ToString();



            DataTable dataTable = dv.ToTable(); 
            
             items().dataTable = dataTable;


           if (dataTable.Rows.Count>0)
           
            dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
            //while (dataTable.Rows.Count > rowLimit)
            //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();

    
 
            dtalstItems.DataSource = dataTable; /// messages.dvorgProducts;
            dtalstItems.DataBind();




        }


       
    }




    protected void pageing(Object sender, EventArgs e)
    {
        String dir = "";
      
        
        
       

        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

        DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
      //  items().pager += 1;



        int rowLimit = items().rowlimit;
        int page = items().pager * rowLimit;

        int pageNext = items().pager  +1 ;

      
        //items().pager += 1;

        DataTable dataTable = ((DataTable)dtalstItems.DataSource);


        int totPages =  dataTable.Rows.Count / rowLimit;
        int totPagesRem = dataTable.Rows.Count % rowLimit;


        if (((Button)sender).CommandArgument == "vv")
        { dir = "forward"; } 
        else { dir = "backward";};


        if (dir == "forward") 
        {
            if (totPages > items().pager)
            {
                items().pager += 1;
                page = items().pager * rowLimit;
            }
            else
            {
                if (totPages == items().pager)
                {

                    if (totPagesRem > 0) { items().pager += 1; }

                    page = items().pager * rowLimit ;
                }
            }

        }







        if (dir == "backward")
        {
            if ( items().pager >0)
            {

                 

                items().pager -= 1;
                page = items().pager * rowLimit;
            }

        }
       /// items().pager += 1; items().pager -= 1; 
       // rowLimit = totPages == items().pager ?   totPagesRem : rowLimit;




        ////if (ds.Tables.Count > 0)
        ////{
        //    DataTable dataTable = dv.ToTable();
        //    dv.RowFilter = "Price >=  txtPriceStart    and Price <=  txtPriceEnd";


        //    dv.Sort = drplstSort.SelectedValue.ToString();

            dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
            //while (dataTable.Rows.Count > rowLimit)
            //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();


            dtalstItems.DataSource = dataTable; /// messages.dvorgProducts;
            dtalstItems.DataBind();
        //}
    }










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

        filters =  items().Live;


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

        String sorter = drplstSort.SelectedValue.ToString();

      //if (  messages.dvorgProducts!=null)
        messages.dvorgProducts.Sort =    sorter ;


    }
    

    protected void refreshSort(Object sender, EventArgs e)
    {

        string sortr = "";
        if (messages.dvorgProducts != null)
        {
        sortr = messages.dvorgProducts.Sort.ToString();

        String sorter = sortr + " ," + drplstSort.SelectedValue.ToString();
        messages.dvorgProducts.Sort = sorter;


      

     
     //   messages.dvorgProducts.Sort =    sorter ;
    }

    }
    






    protected void loads() 
    {
        ////////////int orgid = Convert.ToInt16(messages.orgID);
        ////////////int catid = Convert.ToInt16(messages.catID);

        ////////////DataSet ds = new DataSet();




        ////////////string sortr = "";

        ////////////if (messages.dvorgProducts != null && txtItemSearch.Text.Trim() != "")
        ////////////{
        ////////////    sortr = messages.dvorgProducts.RowFilter.ToString();

        ////////////    String sorter = sortr;// +" and  title like %" + txtItemSearch.Text.Trim() + "%";
        ////////////    messages.dvorgProducts.RowFilter = sorter;
        ////////////}








        

        //UserControl uc = (UserControl)this.FindControl("categoryProduct");

        //uc.dv

        //DataView dv = (DataView)uc.FindControl("dv");


        //////////ds   =     UpdateDonate("S", "get_Items", 0, catid, orgid, "");

        //////////grdvSubGmach.AutoGenerateColumns = false;


        //////////grdvSubGmach.DataSource=ds;

        //////////grdvSubGmach.DataBind();


    }











    public  DataSet getItems(String parm, string commandtext, int buyerid, int orgid, int catid, string status)
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
            int orgid = Convert.ToInt16(orgs().orgID);
            int catid = Convert.ToInt16(item().catID);


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
        //int orgid = Convert.ToInt16( messages.orgID);
        //int catid = Convert.ToInt16(messages.catID);
        int orgid = Convert.ToInt16(orgs().orgID);
        int catid = Convert.ToInt16(item().catID);
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


        //int orgid = Convert.ToInt16(messages.orgID);
        //int catid = Convert.ToInt16(messages.catID);
        int orgid = Convert.ToInt16(orgs().orgID);
        int catid = Convert.ToInt16(item().catID);
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
            ds = r.getItems(commandName, prm,buyerid ,itemid, orgid, catID, location,
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



        
    //protected void NavigationLink_Click(String dir)
    protected void NavigationLink_Click(Object sender , EventArgs e)
    {
        String dirs = "";







        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

        UserControl pageing1 = (UserControl)MainContent.FindControl("pageing1");


       // UserControl pageing1 = (UserControl)(MainContent.FindControl("orgProducts2")).FindControl("pageing1");


        DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");


       ///////////////// Label CurrentPage = (Label)pageing1.FindControl("CurrentPage");

        Label TotalPages = (Label)pageing1.FindControl("TotalPages");



        DropDownList drplstCPage = (DropDownList)pageing1.FindControl("drplstCPage");


        LinkButton FirstPage = (LinkButton)pageing1.FindControl("FirstPage");
        LinkButton PreviousPage = (LinkButton)pageing1.FindControl("PreviousPage");
        LinkButton NextPage = (LinkButton)pageing1.FindControl("NextPage");
        LinkButton LastPage = (LinkButton)pageing1.FindControl("LastPage");




         


        int rowLimit =    pagestatus.row;//        
        
           items().rowlimit=rowLimit;
        
       items().pager = pagestatus.page;
        
         int page = items().pager * rowLimit;

        ///////////////////////CurrentPage.Text = items().pager.ToString();
        int pageNext = items().pager + 1;




        String dir = pagestatus.dir == null ? "currrent" : pagestatus.dir;


        ////     DataList dtalstItems = (DataList)this.FindControl("dtalstItems");


        //int rowLimit = items().rowlimit;
        //int page = items().pager * rowLimit;

        //CurrentPage.Text = items().pager.ToString();
        //int pageNext = items().pager + 1;


        //items().pager += 1;







        DataSet ds = ((BLCustomer)messages.cust).Organization.Orgitems.Items;



        ///  DataTable dataTable = messages.DataTable != null ? messages.DataTable : null;      //              ((DataTable)dtalstItems.DataSource);




       ///////////////////////// DataTable dataTable =  ((DataView) dtalstItems.DataSource)).Tables[0]);


        DataTable dataTable = ((BLCustomer)messages.cust).Organization.Orgitems.dataTable; //ds.Tables[0];

        ////////  DataTable dataTable = (DataTable)((DataView)  ((DataList)this.Parent.FindControl("dtalstItems")).DataSource).Table;
        ////////DataTable dataTable = (DataTable)(  ((BLCustomer)messages.cust).Organization.Orgitems.ItemsDV).Table ;


        int totPages = dataTable.Rows.Count / rowLimit;

        /////int totPagesRem = dtalstItems.Items.Count % rowLimit;
        int totPagesRemAll = dataTable.Rows.Count % rowLimit;


       ////int totPagesRemAll = messages.DataTable.Rows.Count % rowLimit;



        totPages = totPagesRemAll > 0 ? totPages + 1 : totPages;







        TotalPages.Text = totPages.ToString();






        drplstCPage.Items.Clear();

        for (int pg = 1; pg <= totPages; pg++)
        {
            ListItem pages = new ListItem();
            pages.Value = pg.ToString();

            drplstCPage.Items.Add(pages);

        }










        if (dir == "Next")
        {
            if (totPages > items().pager)
            {

                page = items().pager * rowLimit;
                items().pager += 1;
            }
            else
            {
                if (totPages == items().pager)
                {
                    FirstPage.Enabled = false;
                    PreviousPage.Enabled = false;


                    if (totPagesRemAll > 0) { items().pager += 1; }

                    page = items().pager * rowLimit;
                }
            }

        }



         //FirstPage
         //PreviousPage
         //NextPage
         //LastPage



        if (dir == "Prev")
        {
            if (items().pager > 0)
            {



                items().pager -= 1;
                page = items().pager * rowLimit;
            }
            else{
                NextPage.Enabled = false;
                LastPage.Enabled = false;
                
                }
        }










        if (dir == "Last")
        {
            items().pager = totPages;


            if (totPagesRemAll > 0) { items().pager += 1; }

            page = items().pager * rowLimit;

            NextPage.Enabled = false;
            LastPage.Enabled = false;

        }







        if (dir == "First")
        {




            items().pager = 0;
            page = items().pager * rowLimit;
            FirstPage.Enabled = false;
            PreviousPage.Enabled = false;
        }








        if (dir.ToLower() == "currrent")
        {





            page = items().pager * rowLimit;


        }



















        if (dataTable.Rows.Count < page + rowLimit)
        {
            int rowlimit = (page + rowLimit) - dataTable.Rows.Count;

            rowLimit -= rowlimit;
        }



        /// items().pager += 1; items().pager -= 1; 
        // rowLimit = totPages == items().pager ?   totPagesRem : rowLimit;




        ////if (ds.Tables.Count > 0)
        ////{
        //    DataTable dataTable = dv.ToTable();
        //    dv.RowFilter = "Price >=  txtPriceStart    and Price <=  txtPriceEnd";


        //    dv.Sort = drplstSort.SelectedValue.ToString();










        //////////////////////////DataTable datatable = new DataTable();
        //////////////////////////datatable = messages.DataTable.Clone();




        //////////////////////////for (int x = page; x < page + rowLimit; x++)
        //////////////////////////{
        //////////////////////////    //if (x < page || x > page + rowLimit)
        //////////////////////////    //{

        //////////////////////////    datatable.ImportRow(messages.DataTable.Rows[x]);

        //////////////////////////    ////////// dataTable.Rows[x].Delete();
        //////////////////////////    //}
        //////////////////////////}



        /////////////////////////////////  datatable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();


        //////////////////////////dtalstItems.DataSource = datatable;// messages.DataTable;
        ///////////////////////////////////////////////// messages.DataTable=null;
        //////////////////////////dtalstItems.DataBind();












        ////////////////////////////////////////////////////////// DataTable dataTable = dv.ToTable();
        //////////////////  messages.DataTable = dataTable;
        //////if (ds.Tables[0].Rows.Count>0)
        //////    messages.DataTable = dataTable;









        /////////////////////////////////// dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
        //while (dataTable.Rows.Count > rowLimit)
        //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();



        //    DataList dtalstItems = (DataList) datalist;




        dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
       ///// DataList dtalstItems = (DataList)this.Parent.FindControl("dtalstItems");

        DataView dv = new DataView();
        dataTable.TableName = "table1";

        dv.Table = dataTable;




        dtalstItems.DataSource = dv;// dataTable; 
        dtalstItems.DataBind();


        //base.refRefresh();




        ///////////////////CurrentPage.Text = items().pager.ToString();


      ////////////////////////  TotalPages.Text = (messages.DataTable.Rows.Count / rowLimit).ToString();

        drplstCPage.SelectedIndex = items().pager - 1;

        //  PageSize






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





 


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



public partial class orgWatch : System.Web.UI.Page
{



    public string filters = "";


    DataSet ds;
    DataTable dataTable;



    Referrer r = new Referrer();
    public String SubGmachTitle = "";


    BLItems items = (BLItems)messages.cust.Organization.Orgitems;
    BLOrganization org = ((BLOrganization)messages.cust.Organization);
    BLCustomer cust = ((BLCustomer)messages.cust);






    protected void ListChanged(object sender, EventArgs e)
    {

    }



    protected void Page_Load(object sender, EventArgs e)
    {




      ///  if (messages.cust.Organizationhlder > 0)

        //{ btnBack.Visible = true; }
        //else { btnBack.Visible = false; }





        if (!IsPostBack)
        {
            items().Live = "";
        }

        filters = items().Live;

        //ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
        //UserControl category1 = (UserControl)MainContent.FindControl("category1");



      ////  BLItems.navigateCat += new EventHandler(itemSearch);






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


        string status = "approved";
        int origid = Convert.ToInt16(org.ID);




        DataSet ds = BLOrganization.GetOrgList("S", "get_Orgs", origid, status);







        //////////drplstOrgs.DataSource = ds;
        //////////drplstOrgs.DataValueField = "orgID";
        //////////drplstOrgs.DataTextField=  "orgTitle";
        //////////drplstOrgs.DataBind();


        //////////drplstOrgs.Items.Insert(0, "All Orginazations");











        int buyerid = cust.ID;// messages.buyerID;
        string commandName = "get_Credits";
        string prm = "E";


        //////Decimal credits_ = r.get_Credits(commandName, prm, buyerid, 0);




        //////messages.credits = Convert.ToInt16(credits_);



















   /////////////     itemSearch(sender, e);

        /// load();
        /// 

        ///////////////////////////// loads();
        //////////////}s
        if (BLCustomer.buyerID == 0) return; 



        int catid = 0;
        int buyersid = BLCustomer.buyerID;
        int orgid = BLOrganization.orgID;

        DataSet dst = new DataSet();

       // dst = UpdateDonate("C", "get_Items", 0, catid, orgid, "");

            dst= BLItems.fillWatch();
         

       
        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
        UserControl shoppingCart2 = (UserControl)MainContent.FindControl("shoppingCart2");

        DataList dtalstItems = (DataList)shoppingCart2.FindControl("dtalstItems");
        dtalstItems.DataSource = dst;
        dtalstItems.DataBind();





       // DataView dv = new DataView();


        

    }


    //@opt varchar(1), 
    //        @itemID  INT, 
    //        @catID  int ,
    //    @orgID  int 

 



    // LiveTimeReset

    protected void showResults(Object sender, EventArgs e)
    {
        string filter = "";


        if (((Button)sender).ID == "btnLive")
        {
            filters = " Live = " + "'BID'";
            items().Live = " Live = " + "'BID'";
        }
        else
        {
            if (((Button)sender).ID == "btnLocked")
            {
                filters = " Live = " + "'Countdown'";
                items().Live = " Live = " + "'Countdown'";
            }
            else
            {
                if (((Button)sender).ID == "btnAll")
                {
                    items().Live = "";

                }
            }
        }





        BLItems.pager = 0;
        ////////BLItems.rowlimit = 10;


        string sortr = "";

        if (messages.dvorgProducts != null)
            sortr = messages.dvorgProducts.Sort.ToString();





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


        int orgid = messages.orgs_.ID;// messages.orgID;
        int catid = messages.orgs_.Orgitems.CatID;

        DataSet ds = new DataSet();


        ///////////////////////   ds = messages.UpdateDonate("I", "get_Items", 0, catid, orgid, "");

        ds = BLItems.GetItemsList("J", "get_Items", 0, orgid, catid, "");







        //DataView dv = new DataView((DataTable)dtalstItems.DataSource);
        DataView dv = new DataView(ds.Tables[0]);




        int rowLimit = BLItems.rowlimit;
        int page = BLItems.pager * rowLimit;
        ////////////// BLItems.pager += 1;


        if (ds.Tables.Count > 0)
        {


            if (PriceEnd > 0 && PriceEnd > PriceStart || (filters != null && filters != ""))
            {
                if (PriceEnd > 0 && PriceEnd > PriceStart && (filters != null && filters != ""))
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



            DataTable dataTable = dv.ToTable();

            messages.orgs_.Orgitems.dataTable = dataTable;


            if (dataTable.Rows.Count > 0)

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
        //  BLItems.pager += 1;



        int rowLimit = BLItems.rowlimit;
        int page = BLItems.pager * rowLimit;

        int pageNext = BLItems.pager + 1;


        //BLItems.pager += 1;

        DataTable dataTable = ((DataTable)  dtalstItems.DataSource);


        int totPages = dataTable.Rows.Count / rowLimit;
        int totPagesRem = dataTable.Rows.Count % rowLimit;


        if (((Button)sender).CommandArgument == "vv")
        { dir = "forward"; }
        else { dir = "backward"; };


        if (dir == "forward")
        {
            if (totPages > BLItems.pager)
            {
                BLItems.pager += 1;
                page = BLItems.pager * rowLimit;
            }
            else
            {
                if (totPages == BLItems.pager)
                {

                    if (totPagesRem > 0) { BLItems.pager += 1; }

                    page = BLItems.pager * rowLimit;
                }
            }

        }







        if (dir == "backward")
        {
            if (BLItems.pager > 0)
            {



                BLItems.pager -= 1;
                page = BLItems.pager * rowLimit;
            }

        }
        /// BLItems.pager += 1; BLItems.pager -= 1; 
        // rowLimit = totPages == BLItems.pager ?   totPagesRem : rowLimit;




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
        string commandText = commandtext;// "get_Orgs";



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
  orgStatus, orgVideo);

        }

        return ds;
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




     
     
 
      







 




     


    //protected void NavigationLink_Click(String dir)
    protected void NavigationLink_Click(Object sender, EventArgs e)
    {
        String dirs = "";







        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

      //  UserControl pageing1 = (UserControl)(MainContent.FindControl("orgProducts2")).FindControl("pageing1");

        UserControl pageing1 = (UserControl)MainContent.FindControl("pageing1");

        DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");


      ///////////////  Label CurrentPage = (Label)pageing1.FindControl("CurrentPage");

        Label TotalPages = (Label)pageing1.FindControl("TotalPages");



        DropDownList drplstCPage = (DropDownList)pageing1.FindControl("drplstCPage");


        LinkButton FirstPage = (LinkButton)pageing1.FindControl("FirstPage");
        LinkButton PreviousPage = (LinkButton)pageing1.FindControl("PreviousPage");
        LinkButton NextPage = (LinkButton)pageing1.FindControl("NextPage");
        LinkButton LastPage = (LinkButton)pageing1.FindControl("LastPage");







        int rowLimit = pagestatus.row;//        

        BLItems.rowlimit = rowLimit;

        BLItems.pager = pagestatus.page;

        int page = BLItems.pager * rowLimit;

        ////////////////////////CurrentPage.Text = BLItems.pager.ToString();
        int pageNext = BLItems.pager + 1;




        String dir = pagestatus.dir == null ? "currrent" : pagestatus.dir;


        ////     DataList dtalstItems = (DataList)this.FindControl("dtalstItems");


        //int rowLimit = BLItems.rowlimit;
        //int page = BLItems.pager * rowLimit;

        //CurrentPage.Text = BLItems.pager.ToString();
        //int pageNext = BLItems.pager + 1;


        //BLItems.pager += 1;







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
            if (totPages > BLItems.pager)
            {

                page = BLItems.pager * rowLimit;
                BLItems.pager += 1;
            }
            else
            {
                if (totPages == BLItems.pager)
                {
                    FirstPage.Enabled = false;
                    PreviousPage.Enabled = false;


                    if (totPagesRemAll > 0) { BLItems.pager += 1; }

                    page = BLItems.pager * rowLimit;
                }
            }

        }



        //FirstPage
        //PreviousPage
        //NextPage
        //LastPage



        if (dir == "Prev")
        {
            if (BLItems.pager > 0)
            {



                BLItems.pager -= 1;
                page = BLItems.pager * rowLimit;
            }
            else
            {
                NextPage.Enabled = false;
                LastPage.Enabled = false;

            }
        }










        if (dir == "Last")
        {
            BLItems.pager = totPages;


            if (totPagesRemAll > 0) { BLItems.pager += 1; }

            page = BLItems.pager * rowLimit;

            NextPage.Enabled = false;
            LastPage.Enabled = false;

        }







        if (dir == "First")
        {




            BLItems.pager = 0;
            page = BLItems.pager * rowLimit;
            FirstPage.Enabled = false;
            PreviousPage.Enabled = false;
        }








        if (dir.ToLower() == "currrent")
        {





            page = BLItems.pager * rowLimit;


        }



















        if (dataTable.Rows.Count < page + rowLimit)
        {
            int rowlimit = (page + rowLimit) - dataTable.Rows.Count;

            rowLimit -= rowlimit;
        }



        /// BLItems.pager += 1; BLItems.pager -= 1; 
        // rowLimit = totPages == BLItems.pager ?   totPagesRem : rowLimit;




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




        ////////////////////CurrentPage.Text = BLItems.pager.ToString();


        ////////////////////////  TotalPages.Text = (messages.DataTable.Rows.Count / rowLimit).ToString();

        drplstCPage.SelectedIndex = BLItems.pager - 1;

        //  PageSize






    }


}


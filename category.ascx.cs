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

public partial class categoryProduct : System.Web.UI.UserControl
{
   // Queue queue = new Queue();
    Referrer r = new Referrer();
    DataSet dst;
    Control parent;

    


        protected void refreshCat(object sender, EventArgs e)
    {
        BLCustomer cst = (BLCustomer)custs();
            /////DataSet ds = BLCategory.GetCatList(ref  cst, "R", "get_Categories", 0, "");
            DataSet ds = orgs().Category.GetCatList(ref  cst, "R", "get_Categories", 0, "");
 
    custs_=cst;


            lstcat.DataSource = ds;
            lstcat.DataBind();


            lstcat.Items.Insert(0, "All Categories");
}











    protected void Page_Load(object sender, EventArgs e)
    {
        parent = messages.GetParentOfType(this.Parent
                                         );

        BLItems.navigateCat += new EventHandler(subCatAction);



        if (!IsPostBack)
        {
            switch (parent.ToString())
            {
                case "orgproducts_aspx":


                    break;
            }


            //      txtPriceEnd


            //if (!IsPostBack)
            //{


            messages.cnt = 0;
            messages.arCats = new String[20];

           /// DataSet ds = UpdateDonate("R", "get_Categories", 0, "");
           /// 
            BLCustomer cst = (BLCustomer)custs();
            DataSet ds = orgs().Category.GetCatList(ref cst, "R", "get_Categories", 0, "");
            
            
            
            custs_ = cst;



            lstcat.DataSource = ds;
            lstcat.DataBind();


            lstcat.Items.Insert(0, "All Categories");


            //}
        }


    }













    protected void showResults_(Object sender, EventArgs e)
    {

   /////////  DataList dtalstItems = (DataList)   ( (UserControl)   parent.FindControl("orgProducts2")).FindControl("dtalstItems");;


    // DataView dv = (DataView)dtalstItems.DataSource    ;

    ////    DataView dv = new DataView(dst.Tables[0]);

    //    dv.RowFilter = "cartPrice > 'txtPriceStart' and cartPrice < 'txtPriceEnd' ";




























        //messages.dvorgProducts=dv;
        

    }










    //////////////////////protected void showResults(Object sender, EventArgs e)
    //////////////////////{

    //////////////////////    items().pager = 0;
    //////////////////////    ////////items().rowlimit = 10;


    //////////////////////    string sortr = "";

    //////////////////////    if (messages.dvorgProducts != null)
    //////////////////////        sortr = messages.dvorgProducts.Sort.ToString();

       

        

    //////////////////////    // orgItems   obj = new orgItems();

    //////////////////////    //foreach (Control c in Page.Controls)

    //////////////////////    //{
    //////////////////////    //    string nm = c.ID;
    //////////////////////    //    foreach (Control cc in c.Controls)
    //////////////////////    //    {
    //////////////////////    //        string nmc = cc.ID;

    //////////////////////    //        foreach (Control ccc in cc.Controls)
    //////////////////////    //        {
    //////////////////////    //            string nmcc = ccc.ID;



    //////////////////////    //        }

    //////////////////////    //    }
    //////////////////////    //}
    //////////////////////    ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");


    //////////////////////    DropDownList drplstSort = (DropDownList) MainContent.FindControl("drplstSort")  ;
    //////////////////////    String sorter = drplstSort.SelectedValue.ToString();
    //////////////////////    if (messages.dvorgProducts != null)
    //////////////////////        messages.dvorgProducts.Sort = sorter;


    //////////////////////    DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
    //////////////////////    UserControl category1 = (UserControl)MainContent.FindControl("category1");

    //////////////////////    ListBox lstcat = (ListBox)(MainContent.FindControl("category1")).FindControl("lstcat");


    //////////////////////    TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");

    //////////////////////    TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

    //////////////////////    Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

    //////////////////////    Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;


    //////////////////////    //[get_Categories]


    //////////////////////    //    @opt varchar(1),  
    //////////////////////    //    @catID  int ,
    //////////////////////    //    @catName varchar(50


    //////////////////////    if (lstcat != null && lstcat.SelectedValue.ToString().Trim() != "")
    //////////////////////    {
    //////////////////////        messages.catID = Convert.ToInt16(lstcat.SelectedValue.ToString());


    //////////////////////    }


    //////////////////////    //if (lstcat != null)
    //////////////////////    //{
    //////////////////////    //    messages.origID = drplstOrgs.SelectedValue.ToString() == "" ? 0 : Convert.ToInt16(drplstOrgs.SelectedValue.ToString() == "");

    //////////////////////    //}


    //////////////////////    int orgid = messages.orgID;
    //////////////////////    int catid = messages.catID;

    //////////////////////    DataSet ds = new DataSet();


    //////////////////////    ds = messages.UpdateDonate("I", "get_Items", 0, catid, orgid, "");







    //////////////////////    //DataView dv = new DataView((DataTable)dtalstItems.DataSource);
    //////////////////////    DataView dv = new DataView(ds.Tables[0]);




    //////////////////////    int rowLimit = items().rowlimit;
    //////////////////////    int page = items().pager * rowLimit;
    //////////////////////    items().pager += 1;


    //////////////////////    if (ds.Tables.Count > 0)
    //////////////////////    {
    //////////////////////        DataTable dataTable = dv.ToTable();


    //////////////////////        if (PriceEnd > 0 && PriceEnd > PriceStart)
    //////////////////////        {
    //////////////////////            dv.RowFilter = "Price >= "+  PriceStart+"    and Price <="+  PriceEnd;
    //////////////////////        }


    //////////////////////        dv.Sort = drplstSort.SelectedValue.ToString();





    //////////////////////        dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
    //////////////////////        //while (dataTable.Rows.Count > rowLimit)
    //////////////////////        //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();


    //////////////////////        dtalstItems.DataSource = dataTable; /// messages.dvorgProducts;
    //////////////////////        dtalstItems.DataBind();
    //////////////////////    }
    //////////////////////}














    protected void clear()
    {

        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");


        DropDownList drplstSort = (DropDownList)MainContent.FindControl("drplstSort");
       /// String sorter = drplstSort.SelectedValue.ToString();
        drplstSort.SelectedIndex = 0;



       //// DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
        UserControl category1 = (UserControl)MainContent.FindControl("category1");

        ListBox lstcat = (ListBox)(MainContent.FindControl("category1")).FindControl("lstcat");


        ((TextBox)category1.FindControl("txtPriceStart")).Text="";

       ((TextBox)category1.FindControl("txtPriceEnd")).Text="";

       txtPriceStart.Text = "";

       txtPriceEnd.Text = "";


        //Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

        //Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;
    }





















    protected void subCat(Object sender, EventArgs e)
    {
        HtmlGenericControl catSelect = (HtmlGenericControl)this.FindControl("catSelect");

        catSelect.InnerText = ((ListBox)sender).SelectedItem != null ? ((ListBox)sender).SelectedItem.ToString() : "";

        ListBox lb = new ListBox();
        ListBox lbn = new ListBox();

        items().pager = 1;


        messages.cnt += 1;




        //  queue.Clear() ;



        // queue.Enqueue(hc.Value);

        //lstcatsub1.Visible = false;
        //lstcatsub2.Visible = false;
        //lstcatsub3.Visible = false;
        int counter = 0;


        String name = ((ListBox)sender).ID.ToString();
        int subcat = (((ListBox)sender).SelectedValue.ToString()) == "All Categories" ? 0 : (int)Convert.ToInt16(((ListBox)sender).SelectedValue.ToString());


        messages.subcatID = subcat;





        switch (name)
        {

            case "lstcat":
                //lstcatsub1.DataSource = ds;   
                //lstcatsub1.DataBind();
                //lstcatsub1.Visible = true;
                // lb = lstcat;
                //lbn = lstcatsub1;
                counter = 0;

                break;


            case "lstcatsub1":
                //lstcatsub1.DataSource = ds;   ;
                //lstcatsub1.DataBind();
                //lstcatsub1.Visible = true; lstcatsub2.Visible = true;
                //lb = lstcatsub1;
                //lbn = lstcatsub2;
                counter = 1;

                break;



            case "lstcatsub2":

                //lstcatsub1.Visible = true;

                //lstcatsub2.DataSource = ds; ;
                //lstcatsub2.DataBind();
                //lstcatsub2.Visible = true; lstcatsub3.Visible = true;
                //lb = lstcatsub2;
                // lbn = lstcatsub3;
                counter = 2;
                break;



            case "lstcatsub3":

                //lstcatsub1.Visible = true;
                //lstcatsub2.Visible = true;

                //lstcatsub3.Visible = true; 
                //lb  = lstcatsub3;
                //lbn = lstcatsub3;
                counter = 3;
                break;



        }




        BLCustomer cst = (BLCustomer)custs();
               
        cst.Organization.Orgitems.CatID = subcat;


                subCatAction( sender,   e);


                custs_ = cst;


        // messages.arCats[counter] = lb.SelectedItem.ToString() + " ";

        //////for (int x = counter+1; x < messages.arCats.Count(); x++)
        //////{
        //////    messages.arCats[x] = "";

        //////}


        //if (((ListBox)sender).SelectedItem.ToString().IndexOf(">") == -1 || name == "lstcatsub3")
        //{
        //    HtmlContainerControl catlstbx = (HtmlContainerControl)this.FindControl("catlstbx");

        //    messages.catID = ((ListBox)sender).SelectedValue.ToString() == ""?   0     :   Convert.ToInt16( ((ListBox)sender).SelectedValue.ToString().Replace('>', ' '))   ;


        //  //  catlstbx.Visible = true;
        //    return;

        //}

        //messages.catID = subcat;



        //{
        //    HtmlContainerControl catlstbx = (HtmlContainerControl)this.FindControl("catlstbx");

        //    catlstbx.Visible = true;
        //}

        //else 
        //{



    }




    protected void subCatAction(Object sender, EventArgs e)
     
    {
        int subcat = 0;
        subcat = items().CatID;// BLItems.catid;
        BLCustomer cst = (BLCustomer)custs();
        DataSet ds = orgs().Category.GetCatList(ref cst, "S", "get_Categories", subcat, "");


        custs_ = cst;



     //////////////////   HtmlInputText hc = (HtmlInputText)this.FindControl("lisub");
     //   if (messages.cnt > 1) { hc.Value += " > "; }

        //messages.arCats[counter] = lb.SelectedItem.ToString() + " ";
        //messages.address += lb.SelectedItem.ToString() + " ";



    //////////////////////    hc.Value =   messages.arCats.ToString() ; //messages.address;

        //lbn.DataSource = ds; ;
        //lbn.DataBind();


        lstcat.DataSource = ds;
        lstcat.DataBind();

        int orgid = Convert.ToInt16(orgs().ID);
       // int catid = Convert.ToInt16(messages.subCat);


      cst.Organization.Orgitems.CatID = subcat;
       /// BLCustomer cst = custs();
       /// 

      dst = items().GetItemsList(ref cst, "Q", "get_Items", custs().ID, orgid, subcat, "");

        custs_ = cst;

         


         ////DataView dv = new DataView(dst.Tables[0]);

      ///   messages.dvorgProducts = dv;
         
        
        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

         

         DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");


        /// Repeater rptBreadCrumbs = (Repeater)(MainContent.FindControl("orgProducts2")).FindControl("rptBreadCrumbs");



          Repeater rptBreadCrumbs = (Repeater) MainContent.FindControl("rptBreadCrumbs");



         //////dtalstItems.DataSource = dv;
         ////// dtalstItems.DataBind();



          rptBreadCrumbs.DataSource = items().CatbreadCrumbs;// messages.orgs_.Orgitems.CatbreadCrumbs;
          rptBreadCrumbs.DataBind();




















     //    DataTable dataTable = dv.ToTable();




         DataView dv = new DataView(dst.Tables[0]);

         DataTable dataTable = dv.ToTable();


         items().pager = 1;


         int rowLimit = items().rowlimit;
         int page = items().pager * rowLimit;
        // items().pager += 1;

             String   filters = items().Live;
         if (dst.Tables.Count > 0)
         {
              


             Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;
             Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

             if (PriceEnd > 0 && PriceEnd > PriceStart)
             {
                 dv.RowFilter = "Price >=" + PriceStart + "   and Price <= " + PriceEnd;    
                 if(filters.Trim()!=""){  dv.RowFilter +=  " and " + filters;}
             }


      

      ///   if (PriceEnd > 0 && PriceEnd > PriceStart ||  ( filters != null && filters != ""))
             
       //      if (PriceEnd > 0 && PriceEnd > PriceStart &&   ( filters != null && filters != ""))

        //          dv.RowFilter = "Price >= " + PriceStart + "    and Price <=" + PriceEnd;
                     


                       //  if(filters.Trim()!=""){  dv.RowFilter +=  " and " + filters;}
              
             
             
             
             else { dv.RowFilter = filters; }
            ////filters = " Live = " + "'BID'";
            ////   filters = " Live = " + "'Count Down'";
            
                 //else { dv.RowFilter = filters; }

             DropDownList drplstSort = (DropDownList)MainContent.FindControl("drplstSort");
             dv.Sort = drplstSort.SelectedValue.ToString();






             /// ((BLCustomer)messages.cust).Organization.Orgitems.ItemsDV = dv;








       

             items().dataTable = dataTable;




             int totPages = dataTable.Rows.Count / rowLimit;
             int totPagesRem = dataTable.Rows.Count % rowLimit;



             items().rempage = totPagesRem;

             items().totpage = totPagesRem > 0 ? totPages + 1 : totPages;

             //////////////////    int totPagesRemAll = messages.DataTable.Rows.Count % rowLimit;




             UserControl pageing1 = (UserControl)MainContent.FindControl("pageing1");

          /////////////////   Label CurrentPage = (Label)pageing1.FindControl("CurrentPage");

          Label TotalPages = (Label)pageing1.FindControl("TotalPages");



             DropDownList drplstCPage = (DropDownList)pageing1.FindControl("drplstCPage");




             ////CurrentPage.Text = items().pager.ToString();


        TotalPages.Text = totPages.ToString();


             totPages = totPagesRem > 0 ? totPages + 1 : totPages;

             drplstCPage.Items.Clear();
             for (int pg = 1; pg <= totPages; pg++)
             {
                 ListItem pages = new ListItem();
                 pages.Value = pg.ToString();

                 drplstCPage.Items.Add(pages);

             }


             //////////////////////////////////////////////////////////////////    drplstCPage.SelectedIndex = items().pager - 1;






             if (dataTable.Rows.Count > 0 && dataTable.Rows.Count > page)
             {

                 //////////////////  messages.DataTable = dataTable;
                 //////if (ds.Tables[0].Rows.Count>0)
                 //////    messages.DataTable = dataTable;

                 dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
                 //while (dataTable.Rows.Count > rowLimit)
                 //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();
             }

                 DataView dvv = new DataView();
                 dataTable.TableName = "table1";

                 dvv.Table = dataTable;
                 dtalstItems.DataSource = dvv;// dataTable; /// messages.dvorgProducts;
                 dtalstItems.DataBind();



           

           
         }


































































    }




















    protected DataSet UpdateItems(String parm, string commandtext, int buyerid, int orgid, int catid, string status)
    {

        int itemid = 0;
        // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = catid;
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



        String auctiontype = "penny";
        status = "";

        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
        //   string commandName;

        if (prm == "S" || prm == "Q")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm, buyerid,  itemid, orgid, catID, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype, 0
     );
        }




        return ds;
    }















    protected void catProd(Object sender, EventArgs e)
    {
        //String mc = messages.arCats.Count() > 0 ? messages.arCats[messages.arCats.Count() - 1] : "";
        //Response.Redirect("Default3.aspx?cat= "+mc);



        ////////////if (txtSearch.Text.Trim() != "")
        ////////////{
        ////////////    DataSet ds = UpdateDonate("N", "get_Categories", 0, txtSearch.Text.Trim());



        ////////////    //HtmlInputText hc = (HtmlInputText)this.FindControl("lisub");
        ////////////    ////   if (messages.cnt > 1) { hc.Value += " > "; }

        ////////////    ////messages.arCats[counter] = lb.SelectedItem.ToString() + " ";
        ////////////    ////messages.address += lb.SelectedItem.ToString() + " ";



        ////////////    //hc.Value = messages.arCats.ToString(); //messages.address;

        ////////////    lstcat.DataSource = ds;
        ////////////    lstcat.DataBind();
        ////////////}


    }
    





    protected DataSet       UpdateDonate(String parm, string commandtext, int id, string status)
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

        DataSet ds = new DataSet();
        //if (prm!="2")  status = drplstEmailSts.SelectedValue=="All" ? String.Empty : drplstEmailSts.SelectedValue  ;
        //if (prm == "8") prm = "2";
        string commandText = commandtext;// "get_Orgs";



        if (prm == "R")
        {
            orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getCats(commandText,
         prm,
         id,
      orgTitle 
     );



        }
        else
        {
            r.setCats(commandText,
                     prm,
                     id,
                  orgTitle 
             );
            orgStatus ="";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getCats(commandText,
          prm,
          id,
       orgTitle
      );
            //lstcat.DataSource = ds;
            //lstcat.DataBind();
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
            lstcat.DataSource = ds;
            lstcat.DataBind();
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



    public BLCustomer custs_
    {
         

        set
        {
            (Application["cust"]) = value;
        }

    }



}

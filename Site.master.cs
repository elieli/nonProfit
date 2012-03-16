//=====================================================
//' Project:      JomaDeals.com
//' Programmer:   Derek/Valentin
//' File:         site.master.cs
//' Description:  
//' Created:		07/09/09
//' Last Updated: 11/12/09
//' Val fix 10/07/09 - Color variation for footer past deal
//' Val fix 2009/11/09 - Fix Only 21 days fo Past deals
//' Val fix 11/11/09 - Post back for past deal 
//' Val fix 11/11/09 - Fixed last past deals
//' Val  speed up 01/04/2010
//'=====================================================
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
//*  

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text.RegularExpressions;

using System.Collections;
using System.Net.Mail;

using System.Web.Security;
using System.Text;
using System.Configuration;
using System.Xml.Linq;

public partial class Site : System.Web.UI.MasterPage
{
    Referrer r = new Referrer();
    Control parent;
    public int origid;
         public   long amount;
         public long amount1;
         public long amount2;
         public long amoun3t;


    protected void ResetDates(Object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlParameter[] Paramaters = new System.Data.SqlClient.SqlParameter[0];

        string StoredProcedure = "testdates";

        r.resetdates(StoredProcedure , items().Item.auctionID );


    }





    protected void refreshMenus(object sender, EventArgs e)
    {
        ////////////refreshMenu();

    }

    protected void Page_Load(object sender, EventArgs e)
    {


        //Response.Cookies["userName"].Value = "patrick";
        //Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);

        //HttpCookie aCookie = new HttpCookie("lastVisit");
        //aCookie.Value = DateTime.Now.ToString();
        //aCookie.Expires = DateTime.Now.AddDays(1);
        //Response.Cookies.Add(aCookie);

        //if (Request.Cookies["userName"] != null)
        //    Label1.Text = Server.HtmlEncode(Request.Cookies["userName"].Value);

        //if (Request.Cookies["userName"] != null)
        //{
        //    HttpCookie aCookie = Request.Cookies["userName"];
        //    Label1.Text = Server.HtmlEncode(aCookie.Value);
        //}


        //Session["nonProfit"] = "L";




        BLItem.refreshMenu += new EventHandler(refreshMenus);










        ////////////////////refreshMenu();



         




        //////////////while ((Logins.password != "tzally123" && Logins.password != "zalman123" && Logins.password != "zalman123" && Logins.password != "zalman123") &&
        ////////////// (Logins.userid != "tzally123" && Logins.userid != "zalman123" && Logins.userid != "zalman123" && Logins.userid != "zalman123"))
        //////////////{
        //////////////   items().rowlimit=0;
        //////////////     items().pager =0;

        //////////////    Response.Redirect("Login.aspx");
        //////////////};
       // Logins.userid = txtLoginEmail.Text;


       ///////// item_Search();

       /////////////////// refreshOrgs(sender, e);

      
      

        try
        {







            //if (!IsPostBack)
            //{
                messages.bidlevel = 0;
                //switch (Logins.password)
                //{
                //    case "tzally123":
                //        messages.buyerID = 6; 

                //        break;
                //    case "zalman123":
                //        messages.buyerID = 1;

                //        break;

                //    case "eli123":
                //        messages.buyerID = 2;

                //        break;

                //    default:


                //        BLCustomer cust = new BLCustomer(messages.buyerID);

                //        messages.cust = cust;


                //        break;


                //}



                if (Application["cust"] == null)
                {
                  
                    BLCustomer cust = new BLCustomer(0);

                  ///  messages.cust = cust;
                    Application["cust"] = cust;


                    //Response.Redirect("Login.aspx?login=org");
                }
                else{

                    //BLCustomer cust = new BLCustomer(1);

                    //messages.cust = cust;
                }










                imgLogo.ImageUrl = "images/" +    ( (BLCustomer)   Application["cust"] ).Organization.Logo;
















            ///////////    imgLogo.ImageUrl = "images/"+ messages.orgs_.Logo;
              
                //}


                int credits_ = items().Credits;
                //HtmlGenericControl pOtherViews = (HtmlGenericControl)Page.Master.FindControl("pOtherViews");
                //pOtherViews.InnerHtml = "you have a total of " + credits_ + " credits ";
      
                    //if (  drplstOrgs.SelectedIndex==0)

                  //////      if (BLCustomer.buyerID == 0)
                  //////{
                  //////    pOtherViews.InnerHtml = "";
                  //////}



                string status = "approved";
              ///////////////  int origid =   BLOrganization.orgID ;








               // origid = ((BLCustomer)Application["cust"]).Organization.ID;
                origid =orgs().orgID;



                Application["origid"]=origid;







            












                //DataSet ds = messages.getOrgs("S", "get_Orgs", origid, status);

              /////////  origid = 0;

            BLCustomer cst =  (BLCustomer) custs();
            DataSet ds = orgs().GetOrgList(ref  cst, "S", "get_Orgs", origid, status);

                custs_ = cst;


                int indx = drplstOrgs.SelectedIndex;//!= -1 ? drplstOrgs.SelectedIndex :0 ;


                if (indx >= 0) { origid = Convert.ToInt16(drplstOrgs.SelectedValue.ToString()); }

              if (!IsPostBack)
              {

                  drplstOrgs.DataSource = ds;
                  drplstOrgs.DataValueField = "orgID";
                  drplstOrgs.DataTextField = "orgTitle";
                  drplstOrgs.DataBind();


                  drplstOrgs.Items.Insert(0, "All Orginazations");
              }



              ///  if (indx != -1) drplstOrgs.SelectedIndex = indx;



                if (origid != 0  )
                {
                    ///////drplstOrgs.Items.FindByValue(BLOrganization.orgID.ToString()).Selected = true;

                    drplstOrgs.Items.FindByValue(  orgs().orgID.ToString()).Selected = true;




                }

                else
                {
                    if (indx >= 0) { drplstOrgs.SelectedIndex = indx; }

                    else { drplstOrgs.SelectedIndex = 0; }
                
                }


                //if (!IsPostBack  )
                //{
                    
                    //////////////if (origid != 0 )
                    //////////////{
                    //////////////    drplstOrgs.Items.FindByValue(origid.ToString()).Selected = true;
                    //////////////}
                    //////////////else 
                    //////////////{
                    //////////////    if (indx == -1) drplstOrgs.SelectedIndex = 0; 
                    //////////////}
                //////}


                ////////if (origid != 0)
                ////////{
                ////////    drplstOrgs.Items.FindByValue(origid.ToString()).Selected = true;
                ////////}
                ////////else { drplstOrgs.SelectedIndex = 0; }

                //if (messages.DataTable != null)
                //{
                ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

                DropDownList drplstSort = (DropDownList)(MainContent.FindControl("drplstSort"));

             //   UserControl pageing = (UserControl)(MainContent.FindControl("orgProducts2")).FindControl("pageing1");

                UserControl pageing = (UserControl)MainContent.FindControl("pageing1");

                DataList dtalstItems = (DataList)MainContent.FindControl("orgProducts2").FindControl("dtalstItems");



                HtmlContainerControl dvPageing = (HtmlContainerControl)MainContent.FindControl("dvPageing");



                if (dvPageing == null || dvPageing.Visible == false)
                {

                }

                else
                {

                    DropDownList drplstPageSize = (DropDownList)pageing.FindControl("drplstPageSize");

                   // items().pager = 1;
                    //items().rowlimit = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());  ///15;

                    //int rowLimit = items().rowlimit;
                    //int page = items().pager * rowLimit;






                      items().pager = 1;


                     items().rowlimit = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());  ///15;

                    int rowLimit = items().rowlimit;
                    int page = items().pager * rowLimit;






                    ////DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");

                    ////////////////////  Label CurrentPage = (Label)(MainContent.FindControl("orgProducts2")).FindControl("CurrentPage");

           ///////////         Label CurrentPage = (Label)pageing.FindControl("CurrentPage");

                    // CurrentPage.Text = page.ToString();// "1";

                    ///////////////CurrentPage.Text = items().pager.ToString();
                    int pageNext = items().pager + 1;


                    //items().pager += 1;




                    /////////////// DataTable dataTable = messages.DataTable != null ? messages.DataTable : null;      //              ((DataTable)dtalstItems.DataSource);


                    //  dtalstItems.DataSource = messages.DataTable;


                    ////  dataTable=  messages.DataTable;
                    /////  DataTable datatable = dataTable;


                    //tblProductsCopy.ImportRow(tblProducts.Rows[i]);

                    //int rowLimit = items().rowlimit;
                    //int page = items().pager * rowLimit;


                    ////row = MyDataTable.NewRow();
                    ////row.ItemArray = OtherDataTableDataRow.ItemArray;
                    ////MyDataTable.Rows.Add(row);


                    //while (dataTable.Rows.Count > page  )


                    //       dataTable.Rows[dataTable.Rows.Count - 1].Delete();



                    //////////////////DataTable datatable = new DataTable();
                    //////////////////datatable = messages.DataTable.Clone();




                    //////////////////for (int x = page; x < page + rowLimit; x++)
                    //////////////////{
                    //////////////////    //if (x < page || x > page + rowLimit)
                    //////////////////    //{

                    //////////////////    datatable.ImportRow(messages.DataTable.Rows[x]);

                    //////////////////    ////////// dataTable.Rows[x].Delete();
                    //////////////////    //}
                    //////////////////}



                    ///////  datatable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();




                    //////////////////////////DataView dv = new DataView();
                    //////////////////////////datatable.TableName = "table1";

                    //////////////////////////dv.Table = datatable;


                    //////////////////////////dtalstItems.DataSource = dv; // datatable;// messages.DataTable;
                    /////////////////////// messages.DataTable=null;
                    //////////////////////////////////////////////////////////////////////////////////dtalstItems.DataBind();

                    ///// messages.datalist= dtalstItems ;




                    //}



                    //////////////int totPages = messages.DataTable.Rows.Count / rowLimit;
                    int totPagesRem = dtalstItems.Items.Count % rowLimit;
                    ////////if (totPagesRem > 0) { totPages += 1; }


                    //////////////////////Label TotalPages = (Label)(MainContent.FindControl("orgProducts2")).FindControl("TotalPages");

                    Label TotalPages = (Label)pageing.FindControl("TotalPages");
                    ///    TextBox TotalPages = (TextBox)(MainContent.FindControl("TotalPages"));




                    //////////////////TotalPages.Text = totPages.ToString();
                    ///////////////////////////////////////////////////////itemSearch(sender, e);

                }



           


            //   m_bidPennySec
            //m_bidPennySecRepeat
            //bidPennySec
                cartitems.Text = items().cartcount.ToString();// messages.cartcount.ToString();


           






            //Code for the Countdown timer
            //Code for the Countdown timer
            DateTime dtNow = new DateTime();
            /// dtNow = DateTime.Now.AddMilliseconds( -  messages.pennysec );

            dtNow = DateTime.Now.AddMilliseconds(0 );

            DateTime dtFuture = new DateTime();//  (messages.bidEndTime.Year, messages.bidEndTime.Month, messages.bidEndTime.Day, messages.bidEndTime.Minute, messages.bidEndTime.Second, messages.bidEndTime.Millisecond);//        dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
            DateTime dtFuture1 = new DateTime();
            DateTime dtFuture2 = new DateTime();
            DateTime dtFuture3 = new DateTime();


            //DateTime dtFuture = new DateTime(2009, 10, 12, 14, 59, 59);

            //dtFuture1 = messages.bidEndTime1;
            //dtFuture2 = messages.bidEndTime2;
            //dtFuture3 = messages.bidEndTime3;








            //dtFuture = messages.bidEndTime;


            //TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
            //ts = dtFuture.Subtract(dtNow);
            // amount = (long)ts.TotalMilliseconds;


       
            ////////////amount = messages.amount_;/// calcdatespan(dtFuture);
            //////////////////// if (amount <= 378488)
            ////////////////////{

            ////////////////////    switch (messages.bidlevel)
            ////////////////////    {
            ////////////////////        case 0 :

            ////////////////////            messages.bidlevel = 1;

            ////////////////////            messages.bidEndTime = messages.bidEndTime1;

            ////////////////////            amount = calcdatespan(messages.bidEndTime);
            ////////////////////            break;
            ////////////////////        case 1:

            ////////////////////            messages.bidlevel = 2;

            ////////////////////            messages.bidEndTime = messages.bidEndTime2;
            ////////////////////            amount = calcdatespan(messages.bidEndTime);
            ////////////////////            break;

            ////////////////////        case 2:

            ////////////////////            messages.bidlevel = 3;

            ////////////////////            messages.bidEndTime = messages.bidEndTime3;
            ////////////////////            amount = calcdatespan(messages.bidEndTime);
            ////////////////////            break;
            ////////////////////        case 3:



            ////////////////////            break;
            ////////////////////    }


            ////////////////////}


            ////if (messages.bidEndTime.ToString() != messages.bidEndTime1.ToString())
            ////{
            ////    messages.bidEndTime = messages.bidEndTime1;
            ////}

            ////else 
            ////{

            ////    if (messages.bidEndTime.ToString() != messages.bidEndTime2.ToString())
            ////    {
            ////        messages.bidEndTime = messages.bidEndTime2;
            ////    }
            ////    else
            ////    {

            ////        if (messages.bidEndTime.ToString() != messages.bidEndTime3.ToString())
            ////        {
            ////            messages.bidEndTime = messages.bidEndTime3;
            ////        }

            ////    }
            ////}




            ///////////////   dtFuture = messages.bidEndTime;


            //////////////////// TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
            ////////////ts = dtFuture.Subtract(dtNow);
            ////////////long amount = (long)ts.TotalMilliseconds;






            //ts = dtFuture1.Subtract(dtNow);
            //long amount1 = (long)ts.TotalMilliseconds;

            //ts = dtFuture2.Subtract(dtNow);
            //long amount2 = (long)ts.TotalMilliseconds;

            //ts = dtFuture3.Subtract(dtNow);
            //long amount3 = (long)ts.TotalMilliseconds;




            //if (amount>0)
            DataSet dss = new DataSet();
            String parm = "Z";
            string commandtext = "get_Items";
            int id = 0;
            int orgid =  items().AuctionOrgID ;
            int catid = 0;
            int itemid = 0;
             status = "";
            String auctiontype = "";
            int auctionid = items().AuctionID;
            dss = item().GetAuctionItemt(item(), parm, commandtext, custs().ID, orgid, catid, itemid, status, auctiontype, auctionid);



            DataRow dr = dss.Tables[0].Rows[0];
             

              dtFuture = Convert.ToDateTime(dr["endTime"]);



            amount = calcdatespan(dtFuture);
            time(amount);


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


     
   

    }










    protected long calcdatespan(DateTime dtFuture)
    {
        DateTime dtNow = new DateTime();
       // dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);
        dtNow = DateTime.Now;
        TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
        ts = dtFuture.Subtract(dtNow);
        amount = (long)ts.TotalMilliseconds;

        return amount;


    }




    protected void time(long amount)
    {


        //Random rnd= new Random() ;
        // int rndom   = rnd.Next()  ;


        TimeSpan ts = new TimeSpan();
        ts = DateTime.Now.AddSeconds(15).Subtract(DateTime.Now);
        long amount1 = (long)ts.TotalMilliseconds;



        ts = DateTime.Now.AddSeconds(10).Subtract(DateTime.Now);
        long amount2 = (long)ts.TotalMilliseconds;


        ts = DateTime.Now.AddSeconds(5).Subtract(DateTime.Now);
        long amount3 = (long)ts.TotalMilliseconds;




        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
        //////HtmlContainerControl hdnTimer = (HtmlContainerControl)MainContent.FindControl("hdnTimer");

        //////HtmlContainerControl hdnTimer1 = (HtmlContainerControl)MainContent.FindControl("hdnTimer1");

        //////HtmlContainerControl hdnTimer2 = (HtmlContainerControl)MainContent.FindControl("hdnTimer2");

        //////HtmlContainerControl hdnTimer3 = (HtmlContainerControl)MainContent.FindControl("hdnTimer3");

        //////HtmlContainerControl dvAuction = (HtmlContainerControl)MainContent.FindControl("dvAuction");

        //////HtmlContainerControl dvBuyer = (HtmlContainerControl)MainContent.FindControl("dvBuyer");
        //////HtmlContainerControl hdnamount = (HtmlContainerControl)MainContent.FindControl("dvBuyer");

        //////if (hdnTimer != null)
        //////{
        //////    dvAuction.InnerHtml = messages.orgs_.Orgitems.Item.auctionID.ToString();



        //////    dvBuyer.InnerHtml = messages.cust.ID.ToString();
        //////    hdnamount.InnerText = amount.ToString();




        //////    hdnTimer.InnerHtml = amount.ToString();
        //////    hdnTimer1.InnerHtml = amount1.ToString();
        //////    hdnTimer2.InnerHtml = amount2.ToString();

        //////    hdnTimer3.InnerHtml = amount3.ToString();
        //////}


        // document.onload = GetCount(amount);  
        int auctionid = items().AuctionID;

        if (auctionid > 0)
        {
            ///messages.bidTimeLeft = amount;
             /////////////////////// lblDay.Text = dtNow.ToString("ddd, MMMM dd, yyyy");<script language=""javascript"" type=""text/javascript"">
            string code3 = @"              
                           amount=" + amount + @"; 
                            auctionid=" + auctionid + @"; 
                $(document).ready(function() {
               GetCount(" + amount + @"  ," + amount + @"  , " + auctionid + @")  })   ";


            string code4 = @"              
                            
                $(document).ready(function() {
               capture( )  })   ";
             
            //document.onload = GetCount(" + amount + @"  ," + amount + @"  , " + auctionid + @") ";
        



            string code = @"<script language=""javascript"" type=""text/javascript"">
             <!--
             //start
             //######################################################################################
             // Author: ricocheting.com
             // For: public release (freeware)
             // Date: 4/24/2003 (update: 5/15/2009)
             // Description: displays the amount of time until the dateFuture entered below.
             //###################################
             amount=" + amount + @";            

            var timeout;
  

            function stopCount()
            {

            alert('stop');
            clearTimeout(  timeout );
             
            }

             function GetCount(){
               
   alert('start');
 
               if(amount > 0) )
////               if(amount < getResetTime() )
//////////////////                             {    amount =       getTotBids (  )  ;
//////////////////                                }

//                amount =   getamounts();  
//                if(){
//                setTimeout(""GetCount()"", 1000);
//                        amount=amount-1000;
//                    }
         //////    document.getElementById('dvBid').style.visibility='hidden';
               


//                            } 
//             else
          {

document.getElementById('dvBid').style.visibility='block';
                // date is still good
                 days=0;hours=0;mins=0;secs=0;out="""";
                 var tempAmount = Math.floor(amount/1000);
                 days=Math.floor(tempAmount/86400);
                 tempAmount=tempAmount%86400;
                 hours=Math.floor(tempAmount/3600);
                 tempAmount=tempAmount%3600;
                 mins=Math.floor(tempAmount/60);//minutes
                 tempAmount=tempAmount%60;
                 secs=Math.floor(tempAmount);//seconds
                 if(days != 0) 
                 {
                    out += pad(days.toString(),'0').toString() + "":"";
                 }
                 if(days != 0 || hours != 0)
                 {
                    out += pad(hours.toString(),'0').toString() + "":"";
                 }
                 if(days != 0 || hours != 0 || mins != 0)
                 {
                        out += pad(mins.toString(),'0').toString() + "":"";}
                        out += pad(secs.toString(),'0').toString();
                        document.getElementById('countbox').innerHTML=out;
                      setTimeout(""GetCount()"", 1000);
                        amount=amount-1000;
                }
              }
 }


             window.onload=GetCount( ) ;
         document.onload = GetCount( );

           


             function pad(val, ch)
             {
                if (val<10)  
              return ch+val;
                return val;
             } 
             // -->
             </script>";







            string code2 = @"<script language=""javascript"" type=""text/javascript"">
            
            amount=" + amount + @"; 
            auctionid=" + auctionid + @";
         document.onload = GetCount(" + amount + @"  ," + amount + @"  , " + auctionid + @")            
             </script>";

            // -->    ";


            //  document.onload = GetCount(amount);  


            Control parent = messages.GetParentOfType(this.Parent
                                                       );

            switch (parent.ToString())
            {
                case "ASP.orgprofile_aspx":


                    break;
            }

            string prnt = parent.ToString();


            if (prnt == "ASP.auction_aspx")   //"ASP.orgproducts_aspx")
            {
                ClientScriptManager csm = Page.ClientScript;
                ClientScriptManager csm2 = Page.ClientScript;

                ////  csm.RegisterStartupScript(Page.GetType(), "timer" + amount, code2, true);

                csm2.RegisterClientScriptBlock(Page.GetType(), "timerstart" + amount, code3, true);
                csm.RegisterClientScriptBlock(Page.GetType(), "timerstarter" , code4, true);



            }


        }
    }





















    protected void catSearch(Object sender, EventArgs e)
    {

        if (Request.Url.ToString().IndexOf("orgProducts") == -1)
        { Response.Redirect("orgProducts.aspx"); }
        HtmlGenericControl dvCatsGen = (HtmlGenericControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "visible");

        itemSearch(sender, e);


        if (lstvCatGeneral.Rows == 0) { dvCatsGen.Style.Add("visibility", "hidden"); }

        /////item_Search();
    }






    





    protected void itemSearch(Object sender, EventArgs e)
    {



        int orgid = orgs().ID;// BLOrganization.orgID;
        int catid = items().CatID;// BLItems.catid;

        catid = 0;


        HtmlContainerControl dvCatsGen = (HtmlContainerControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "visible");


        DataSet ds = new DataSet();



        /////  BLCustomer cust = (BLCustomer)messages.cust; 

        BLCustomer cst = (BLCustomer)custs();
        ds = items().GetItemsList(ref cst, "I", "get_Items", custs().ID, orgid, catid, txtItemSearch.Text.Trim());
        custs_ = cst;


       //////// ds = BLItems.GetItemsList("A", "get_Items", 0, orgid, catid, txtItemSearch.Text.Trim());

        lstvCatGeneral.DataTextField = "catnamespec"; //"catname";
        lstvCatGeneral.DataValueField = "catid";

        lstvCatGeneral.DataSource = ds;


        lstvCatGeneral.DataBind();
    }




    protected void items_Search(Object sender, EventArgs e)
    {




        /// DataSet ds = UpdateDonate("R", "get_Categories", 0, "");
        /// 
        BLCustomer cst = (BLCustomer)custs();
        DataSet ds = orgs().Category.GetCatList(ref cst,"R", "get_Categories", 0, "");
        custs_ = cst;

        //lstcatsub1.Visible = false;
        //lstcatsub2.Visible = false;
        //lstcatsub3.Visible = false;
         ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
         UserControl category1 = (UserControl)MainContent.FindControl("category1");
        ListBox lstcat = (ListBox)category1.FindControl("lstcat");
        lstcat.DataSource = ds;
        lstcat.DataBind();


        lstcat.Items.Insert(0, "All Categories");

        



        HtmlGenericControl dvCatsGen = (HtmlGenericControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "hidden");

        int ggg = ((ListBox)sender).SelectedIndex >= 0 ? ((ListBox)sender).SelectedIndex : 0;

        int cat_id =   Convert.ToInt16(lstvCatGeneral.Items[ggg].Value);

        int org_id = orgs().ID;// messages.orgs_.ID;

       /// messages.orgs_.Orgitems.CatID= cat_id;


        items().CatID = cat_id;


        item_Searchs(org_id, cat_id);


    }








    protected void item_Searchs(int Orgid, int Catid)
    {
      //  int ggg = e.NewSelectedIndex;

      //int cat_id =  Convert.ToInt16(  lstvCatGeneral.Items[ggg].Controls[0].ToString());


      //messages.orgs_.Orgitems.ID = cat_id;

        HtmlContainerControl dvCatsGen = (HtmlContainerControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "hidden");



        int orgid = orgs().ID;// messages.orgs_.ID;// BLItems.orgID;
        int catid = items().CatID;// items().CatID;

        //// catid = 0;




        DataSet ds = new DataSet();



        /////  BLCustomer cust = (BLCustomer)messages.cust; 



    ///    ds = BLItems.GetItemsList("I", "get_Items", 0, catid, orgid, txtItemSearch.Text.Trim());



        BLCustomer cst = (BLCustomer)custs();

        ds = items().GetItemsList(ref cst, "Q", "get_Items", 0, orgid, catid, "");

        custs_ = cst;

      


    ///    return;












       // items().pager = 0;

        items().pager = 0;
        /////items().rowlimit = 10;


        string sortr = "";

        //////////if (messages.dvorgProducts != null)
        //////////    sortr = messages.dvorgProducts.Sort.ToString();



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

        DropDownList drplstSort = (DropDownList)(MainContent.FindControl("drplstSort"));





        DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");


        String sorter = "";

        if (drplstSort != null)
        {

            sorter = drplstSort.SelectedValue.ToString();

            if (messages.dvorgProducts != null)
                messages.dvorgProducts.Sort = sorter;

        }




        UserControl category1 = (UserControl)MainContent.FindControl("category1");
        Decimal PriceEnd = 0;
        Decimal PriceStart = 0;

        if (category1 != null)
        {
            ListBox lstcat = (ListBox)(MainContent.FindControl("category1")).FindControl("lstcat");


            TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");

            TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");





            PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

            PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;

            //[get_Categories]


            //    @opt varchar(1),  
            //    @catID  int ,
            //    @catName varchar(50






            if (lstcat != null && lstcat.SelectedValue.ToString().Trim() != "")
            {
                messages.catID = Convert.ToInt16(lstcat.SelectedValue.ToString());


            }



        }






        //if (lstcat != null)
        //{
        //    messages.orgID = drplstOrgs.SelectedValue.ToString() == "" ? 0 : Convert.ToInt16(drplstOrgs.SelectedValue.ToString() == "");

        //}









        //DataView dv = new DataView((DataTable)dtalstItems.DataSource);
        DataView dv = new DataView(ds.Tables[0]);


        String filters = items().Live;// items().Live;

        int rowLimit = items().rowlimit;
        int page = items().pager * rowLimit;
      


        if (ds.Tables.Count > 0)
        {


            if (PriceEnd > 0 && PriceEnd > PriceStart)
            {
                dv.RowFilter = "Price >=" + PriceStart + "   and Price <= " + PriceEnd;
                if (filters.Trim() != "") { dv.RowFilter += " and " + filters; }
            }
            else { dv.RowFilter = filters; }






            //if (PriceEnd > 0 && PriceEnd > PriceStart)
            //{
            //    dv.RowFilter = "Price >=" + PriceStart + "   and Price <= " + PriceEnd;
            //}


            if (drplstSort != null)
                dv.Sort = drplstSort.SelectedValue.ToString();

            DataTable dataTable = dv.ToTable();
            DataTable datatable = new DataTable();
            if (ds.Tables[0].Rows.Count > 0)

            {




                ////////////////////////////  dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
                //while (dataTable.Rows.Count > rowLimit)
                //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();


                //////////////////////////dtalstItems.DataSource = dataTable; /// messages.dvorgProducts;
                //////////////////////////dtalstItems.DataBind();



                parent = messages.GetParentOfType(this.Parent
                                                  );

            ////////////switch (parent.ToString())
            ////////////{
            ////////////    case "orgproducts_aspx":


            ////////////        break;

            ////////////    case "auction_aspx":
            ////////////        messages.DataTable = dataTable;
            ////////////        Response.Redirect("orgproducts.aspx?");



            ////////////    break;



            ////////////}







            UserControl pageing = (UserControl)(MainContent.FindControl("orgProducts2")).FindControl("pageing1");




            HtmlContainerControl dvPageing = (HtmlContainerControl)(MainContent.FindControl("orgProducts2")).FindControl("dvPageing");



            if (dvPageing == null || dvPageing.Visible == false)
            {

            }

            else
            {

                DropDownList drplstPageSize = (DropDownList)pageing.FindControl("drplstPageSize");
               ////////////////// items().pager = 1;
                items().rowlimit = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());  ///15;



                rowLimit = items().rowlimit;
                page = items().pager * rowLimit;






             
                datatable = dataTable.Clone();




                for (int x = page; x < page + rowLimit; x++)
                {
                    if (x < page || x > page + rowLimit)
                    {
                    }
                    else
                    {
                        if (dataTable.Rows.Count>x )
                        {
                            datatable.ImportRow(dataTable.Rows[x]);
                        }
                      
                    }

                    ////////// dataTable.Rows[x].Delete();
                    //}
                }



                ///////  datatable = datatable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();


            }

            items().pager += 1;



        /////////    Label CurrentPage = (Label)pageing.FindControl("CurrentPage");




            ///////////CurrentPage.Text = items().pager.ToString();
            int pageNext = items().pager + 1;




                DataView dvv = new DataView();
                datatable.TableName = "table1";

                dvv.Table = datatable;























                dtalstItems.DataSource = dvv;

                dtalstItems.DataBind();

            }
        }


    }
































    protected void refreshbOrgs(Object sender, EventArgs e)
    {

         
        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

       

        Button btnBack = (Button)(MainContent.FindControl("btnBack"));






         
            btnBack.Visible = false;



            //BLCustomer cust =    (BLCustomer)messages.cust;
            //cust.Organization = cust.Organizationhld;


            custs().Organization = custs().Organizationhld;

          //  BLOrganization.orgID = ((DropDownList)sender).SelectedIndex<=0 ? 0:     Convert.ToInt16(((DropDownList)sender).SelectedValue.ToString());

           //////////??? BLOrganization.orgID = ((DropDownList)sender).SelectedIndex <= 0 ? 0 : Convert.ToInt16(((DropDownList)sender).SelectedValue.ToString());

          //  cust.Organization = cust.Organizationhld;


            ///cust.Organization.ID = messages.orgID;
         
    }
    




    protected void refreshMenu( )
    {


        HtmlAnchor liBuycredits = (HtmlAnchor)this.FindControl("liBuycredits");
        HtmlAnchor liMessages = (HtmlAnchor)this.FindControl("liMessages");
        HtmlAnchor liWatchlist = (HtmlAnchor)this.FindControl("liWatchlist");
        HtmlAnchor liSellitems = (HtmlAnchor)this.FindControl("liSellitems");


        if (custs().signedinorgid == 0 && custs().buyerID == 0)
        {
            //liBuycredits.Attributes.Add("onclick", "");
            //liBuycredits.Attributes.Add("color", "gray");

            //liMessages.Attributes.Add("href", "#"); liMessages.Attributes.Add("color", "gray");
            //liWatchlist.Attributes.Add("href", "#"); liWatchlist.Attributes.Add("color", "gray");
            //liSellitems.Attributes.Add("href", "#"); liSellitems.Attributes.Add("color", "gray");
        }
        //<optgroup>
        else
        {
            if (custs().signedinorgid == 0)
            {
                ////////liSellitems.Attributes.Add("href", "#");
                ///liBuycredits.Attributes.Add("onclick", "");
                //liMessages.Attributes.Add("href", "#");

                //liWatchlist.Attributes.Add("href", "#");







            }

            else 
            {
                liSellitems.Attributes.Add("href", "default2.aspx");
                liMessages.Attributes.Add("href", "comment.aspx");
            }


        }



        if (  custs().buyerID != 0)
       
            {
                liSellitems.Attributes.Add("href", "#");





                if (drplstOrgs.SelectedIndex == 0)
                {
                    liBuycredits.Attributes.Add("onclick", "");
                    liMessages.Attributes.Add("href", "#");
                    liWatchlist.Attributes.Add("href", "#");

                }
                else
                {  liSellitems.Attributes.Add("href", "#");


                liBuycredits.Attributes.Add("onclick", "window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no')");
                liMessages.Attributes.Add("href", "comment.aspx");
                liWatchlist.Attributes.Add("href", "orgWatch.aspx");





                    //liBuycredits.Attributes.Add("disabled", "disabled");
                    //liMessages.Attributes.Add("disabled", "disabled");
                    //liWatchlist.Attributes.Add("disabled", "disabled");
                    //liSellitems.Attributes.Add("disabled", "disabled");
                }
            }
        





    }
    

    
    
    
    protected void refreshOrgs(Object sender, EventArgs e)
    {


        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

        DropDownList drplstSort = (DropDownList)(MainContent.FindControl("drplstSort"));


        Button btnBack = (Button)(MainContent.FindControl("btnBack"));


      orgs().orgID = drplstOrgs.SelectedIndex  >  0     ? Convert.ToInt16(drplstOrgs.SelectedValue.ToString()) :0 ;

      


      //         
         




        ////if (drplstOrgs.SelectedValue.IndexOf("All") != -1)
        ////{
        ////    btnBack.Visible = true;



           /// BLCustomer cust = (BLCustomer)messages.cust;

           custs().Organizationhld = custs().Organization;
            ///////////////////////////////cust.Organization = new BLOrganization();



           //// cust.Organization.ID = messages.orgID;



            ////////////////////////////////refreshMenu();


        ////}
        ////else { btnBack.Visible = false; }

       ///      txtItemSearch.Text = drplstOrgs.SelectedItem.ToString();



            if (btnBack != null)
            {

            if (custs().Organizationhlder > 0)
            {
                    btnBack.Visible = true;
                }
                else { btnBack.Visible = false; }
            }
     



            items().pager = 1;


                        

            DataSet dst = new DataSet();

            String param = "Q";
            BLCustomer cst = (BLCustomer)custs();



            dst = items().GetItemsList(ref cst, param, "get_Items", 0, orgs().orgID, 0, "");
            custs_ = cst;


            if (Request.Url.ToString().IndexOf("nonprofitHome") != -1   )

            {
                  Response.Redirect("orgHome.aspx");
            }

         // ||   Request.Url.ToString().IndexOf("orgHome") == -1 )
            if (Request.Url.ToString().IndexOf("orgProducts") != -1)
            {
                Response.Redirect("orgProducts.aspx");
            }
            else { Response.Redirect("orgHome.aspx"); }
            ////else
            ////{
            ////    if (Request.Url.ToString().IndexOf("orgHome") == -1) Response.Redirect("orgHome.aspx");
            ////}



           ////////////////////// item_Searchs(cust.Organization.ID, cust.Organization.Orgitems.CatID);

           // item_Search();


          


       

        //itemSearch(sender, e);


        return;





        DataView dv;
        DataSet ds = new DataSet();


        //  categoryProduct
        int catid = 0;

        int orgid = Convert.ToInt16(drplstOrgs.SelectedValue.ToString());


        ds = items().GetItemsList(ref cst, "Q", "get_Items", 0, orgid, catid, "");


        custs_ = cst;



       ////// ds = getItems("Q", "get_Items", 0, catid, orgid, "");



        dv = new DataView(ds.Tables[0]);

        int rowLimit = 4;

        // dv.RowFilter = "";


        ///   dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();



        //  return dataTable;
        UserControl category1 = (UserControl)Page.FindControl("category1");
      ///if (){}
        DataList catlstbx = (DataList)category1.FindControl("catlstbx");


        TextBox txtPriceStart = (TextBox)category1.FindControl("txtPriceStart");
        TextBox txtPriceEnd = (TextBox)category1.FindControl("txtPriceEnd");

        //String txtPriceStarts = txtPriceStart.Text;
        //String txtPriceEnds = txtPriceEnd.Text;
        String filter = catlstbx.SelectedItem.ToString() + " "; ;

        dv.RowFilter = filter;
        dv.RowFilter = filter + "'cartPrice' >  txtPriceStarts and 'cartPrice' < txtPriceEnds ";

        UserControl uc = (UserControl)this.FindControl("orgProducts2");

        DataList dtalstItems = (DataList)uc.FindControl("dtalstItems");




        Decimal PriceStart = txtPriceStart != null && txtPriceStart.Text.Trim() != "" ? Convert.ToDecimal(txtPriceStart.Text) : 0;

        Decimal PriceEnd = txtPriceEnd != null && txtPriceEnd.Text.Trim() != "" ? Convert.ToDecimal(txtPriceEnd.Text) : 0;




        DataTable dataTable = dv.ToTable();

        while (dataTable.Rows.Count > rowLimit)
            dataTable.Rows[dataTable.Rows.Count - 1].Delete();


        //////////////////////////////////////////dtalstItems.DataSource = dataTable;// ds;

        //////////////////////////////////////////dtalstItems.DataBind();








        string sortr = "";

        ////if (messages.dvorgProducts != null)
        sortr = messages.dvorgProducts.Sort.ToString();

        String sorter = drplstSort.SelectedValue.ToString();

        //if (  messages.dvorgProducts!=null)
        messages.dvorgProducts.Sort = sorter;


    }


    protected void refreshSort(Object sender, EventArgs e)
    {

        ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

        DropDownList drplstSort = (DropDownList)(MainContent.FindControl("drplstSort"));


        string sortr = "";
        if (messages.dvorgProducts != null)
        {
            sortr = messages.dvorgProducts.Sort.ToString();

            String sorter = sortr + " ," + drplstSort.SelectedValue.ToString();
            messages.dvorgProducts.Sort = sorter;





            //   messages.dvorgProducts.Sort =    sorter ;
        }

    }






    public DataSet getItems(String parm, string commandtext, int buyerid, int orgid, int catid, string status)
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



















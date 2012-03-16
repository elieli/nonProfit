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



public partial class org_Products : System.Web.UI.UserControl
{



   /// <summary>
   /// //////////
   /// </summary>
 /////////////BLItems items;

    Referrer r = new Referrer();
    public String SubGmachTitle = "";














    //protected void OnDataBinding_rptBreadCrumbs(object sender, RepeaterItemEventArgs e)
    //{


    //    switch (e.Item.ItemType)
    //    {
    //        case ListItemType.Item:
    //        case ListItemType.AlternatingItem:

    //            DataRowView dtRow = (DataRowView)e.Item.DataItem;


    //            ///  dtRow[0] = dtRow[0] + ">";
    //            break;

    //    }




    //}



    protected void Page_Load(object sender, EventArgs e)
    {


        //rptBreadCrumbs.DataSource = messages.orgs_.Orgitems.CatbreadCrumbs;
        //rptBreadCrumbs.DataBind();



        UserControl pageing = (UserControl)this.FindControl("pageing1");








        int rowLimit = items().rowlimit;
        int page = items().pager * rowLimit;














        /////  CurrentPage.Text = items().pager.ToString();
        int pageNext = items().pager + 1;
          DataSet ds = new DataSet();


        //items().pager += 1;



          if (items().RecentITems != null && items().RecentITems.Tables.Count > 0 && items().RecentITems.Tables[0].Rows.Count > 0)
        {

            ///  DataTable dataTable = messages.DataTable != null ? messages.DataTable : null;      //              ((DataTable)dtalstItems.DataSource);

            ds = items().RecentITems;

          loads();
            }
            else
          {
              loads();

              return;


             //  ds = BLItems.GetItemsList("V", "get_Items", 0, 0, 0, "");
                   }
                        
            
            DataTable dataTable;




            if (orgs().Orgitems.dataTable != null)
            {
                dataTable = orgs().Orgitems.dataTable;
            }
            else
            {
                dataTable =  ds.Tables.Count>0? ds.Tables[0] : null ;
            }


            int totPages = dataTable.Rows.Count / rowLimit;// dtalstItems.Items.Count / rowLimit;

            int totPagesRemAll = dataTable.Rows.Count % rowLimit;

            int totPagesRem = dtalstItems.Items.Count % rowLimit;



            ///  TotalPages.Text = totPages.ToString();






            if (!IsPostBack)
            {



              //////////////  DropDownList drplstcPage = (DropDownList)pageing.FindControl("drplstCPage");



              //////////////  Label Totalpages = (Label)pageing.FindControl("TotalPages");

              ////////////// ///////// Label Currentpage = (Label)pageing.FindControl("CurrentPage");

              ////////////////////////////  Currentpage.Text = items().pager.ToString();
              //////////////  Totalpages.Text = totPages.ToString();

              //////////////  drplstcPage.Items.Clear();
              //////////////  for (int y = 1; y <= totPages; y++)
              //////////////  {

              //////////////      //  drplstCPage.Items.Add(y.ToString());
              //////////////      drplstcPage.Items.Add(y.ToString());
              //////////////  }










                Type parentType = this.GetType();
                Control parent = messages.GetParentOfType(this.Parent
                                                );

                switch (parent.ToString())
                {
                    case "ASP.orgprofile_aspx":


                        break;
                }

                /// load();
                /// 

                ///// loads();


            //}
        }
    }



    //@opt varchar(1), 
    //        @itemID  INT, 
    //        @catID  int ,
    //    @orgID  int 


    protected void chgsts(object sender, EventArgs e)
    {
        int orgid = Convert.ToInt16(messages.orgID);
        int catid = Convert.ToInt16(messages.catID);


        UpdateDonate("S", "get_Items", 0, catid, orgid, "");

    }






    protected void loads()
    {


        DataView dv;


        int orgid = Convert.ToInt16(orgs().orgID);
        int catid = 0;// Convert.ToInt16(messages.catID);
        orgid = 0;

        //if (messages.dvorgProducts != null)

        //{ dv = messages.dvorgProducts; }

        //else
        //{
            DataSet ds = new DataSet();
            BLCustomer cst = (BLCustomer)custs();

            ds = items().GetItemsList(ref cst, "V", "get_Items", 0, 0, 0, "");
            ///////// ds   =     UpdateDonate("Q", "get_Items", 0, catid, orgid, "");

            custs_ = cst;

            //////  ds = UpdateDonate("Q", "get_Items", 0, catid, orgid, "");



            //BLOrganization org = new BLOrganization();

            //org.Orgitems.OrgID = orgid;

            //org.Orgitems.CatID = catid;


           /////////////////// ds = org.Orgitems.UpdateDonate("V", "get_Items", 0, 0, 0, "");

            ///  ds = BLItems.o..UpdateDonate("Q", "get_Items", 0, catid, orgid, "");



            ///  ds = BLItems.GetItemsList("Q", "get_Items", 0, catid, orgid, "");

            //    BLItems Itemss = new BLItems();

            //BLOrganization.

            ///// Itemss.Items = Itemss.UpdateDonate(parm, commandtext, id, orgid, catid, status);
            //  return Itemss.Items;



            //// grdvSubGmach.AutoGenerateColumns = false;
            ///////  items().rowlimit = 15;



            dv = new DataView(ds.Tables[0]);
        //}
            int rowLimit = 4;// items().rowlimit; 




        // dv.RowFilter = "";
        DataTable dataTable = dv.ToTable();




        DataTable datatable = new DataTable();
        datatable = dataTable.Clone();




        for (int x = 0; x < 4; x++)
        {
            //if (x < page || x > page + rowLimit)
            //{refreshMenu

            if (dataTable.Rows.Count-1 >=x)
            {

            datatable.ImportRow(dataTable.Rows[x]);
            }

            ////////// dataTable.Rows[x].Delete();
            //}
        }








        //while (dataTable.Rows.Count > rowLimit)
        //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();

        ///   dataTable = dataTable.AsEnumerable().Skip(0).Take(50).CopyToDataTable();



        //  return dataTable;

        dataTable.TableName = "table1";

        DataView dvv = new DataView();

        dvv.Table = dataTable;

        dtalstItems.DataSource = datatable; // dvv;// dataTable;// ds;

        dtalstItems.DataBind();


    //}



}
















    protected void rptProductList_OnItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:



                HtmlImage imgorgLogo = (HtmlImage)e.Item.FindControl("imgItem");

                imgorgLogo.Src = "Images/" + ((DataRowView)e.Item.DataItem)["img1"].ToString().Trim(); ;
                ////////////////imgorgLogo.Src = "Images/" + ((DataRowView)e.Item.DataItem)["img1"].ToString().Trim(); ;


                HtmlAnchor anchorProfile = (HtmlAnchor)e.Item.FindControl("anchorProfile");

                if (((DataRowView)e.Item.DataItem)["Live"].ToString() == "BID")
                {
                    anchorProfile.HRef = "Auction.aspx?" + "aid=" + ((DataRowView)e.Item.DataItem)["itemAuctionID"].ToString() + "&" + "cid=" + ((DataRowView)e.Item.DataItem)["catid"].ToString() + "&" + "id=" + ((DataRowView)e.Item.DataItem)["itemIDa"].ToString();
                }
                else 
                { 
                 ///   anchorProfile.HRef = "#"; 

                    anchorProfile.HRef = "Auction.aspx?" + "aid=" + ((DataRowView)e.Item.DataItem)["itemAuctionID"].ToString();
                
                
                }

                //HtmlAnchor anchorProfile1 = (HtmlAnchor)e.Item.FindControl("anchorProfile1");

                //anchorProfile1.HRef = "Auction.aspx?" + ((DataRowView)e.Item.DataItem)["itemAuctionID"].ToString();



                HtmlContainerControl amounter = (HtmlContainerControl)e.Item.FindControl("amounter");
                HtmlContainerControl dvauctionid = (HtmlContainerControl)e.Item.FindControl("dvauctionid");

                dvauctionid.InnerHtml = ((DataRowView)e.Item.DataItem)["itemAuctionid"].ToString();

                DateTime dtFuture = (DateTime)((DataRowView)e.Item.DataItem)["endTime"];

                DateTime dtNow = new DateTime();
                // dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);
                dtNow = DateTime.Now;
                TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
                ts = dtFuture.Subtract(dtNow);
                long amountlong = (long)ts.TotalMilliseconds;

                amounter.InnerHtml = amountlong.ToString();


                string auctionid = ((DataRowView)e.Item.DataItem)["itemAuctionid"].ToString();


                HtmlAnchor btnwatch = (HtmlAnchor)e.Item.FindControl("btnwatch");
                btnwatch.HRef = "#";
               /// btnwatch.Attributes.Add("onClick", "javascript:return watch(" + auctionid + ");");

                btnwatch.Attributes.Add("onClick", "javascript:watchlog(" + auctionid + ");");







                break;
        }
    }












    protected void load()
    {




        /////////////  UpdateDonate("S", "get_Orgs", 0, drplstEmailSts.SelectedValue.ToString());
        int orgid = Convert.ToInt16(messages.orgID);
        int catid = Convert.ToInt16(messages.catID);


        UpdateDonate("S", "get_Items", 0, catid, orgid, "");



        //if (mails.prm =="1")
        //{
        //    Update_Donate();
        //}





    }

    protected void email(Object sender, EventArgs e)
    {
        /// GridViewRow row = ((GridView)sender).Rows[e.RowIndex];

        /// HtmlContainerControl dvEmil = (HtmlContainerControl)row.FindControl("dvEmil");

        ///  HtmlTextArea txtemail = (HtmlTextArea)dvEmil.FindControl("txtemail");

    }



    protected void orgssub(Object sender, GridViewCommandEventArgs e)
    {
        //grdvSubGmach.EditIndex = -1;
        // grdvSubGmach.DataBind();


        //@opt varchar(1), 
        //    @itemID  INT, 
        //    @catID  int ,
        //@orgID  int 
        int orgid = Convert.ToInt16(messages.orgID);
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
        //dtalstItems.EditIndex = -1;
        //dtalstItems.DataBind();
        // UpdateDonate("S", "get_Orgs",0);


        int orgid = Convert.ToInt16(messages.orgID);
        int catid = Convert.ToInt16(messages.catID);

        UpdateDonate("S", "get_Items", 0, catid, orgid, "");
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

        int itemid = 0;
        // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = 0;
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



        String auctiontype = "";
        status = "";

        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
        //   string commandName;

        if (prm == "S" || prm == "Q" || prm == "C")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,buyerid , itemid, orgid, catID, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype, 0
     );
        }




        return ds;
    }

    protected void SubGmachBind(Object sender, GridViewRowEventArgs e)
    {

        switch (e.Row.RowType)
        {





            case DataControlRowType.DataRow:

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



    // protected void approveOrg(Object sender,  EventArgs e)
    // {

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



    // }








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



    protected void editGrid(Object sender, EventArgs e)
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
        //grdvSubGmach.AutoGenerateColumns = false;

        //////UpdateDonate("S", "get_Orgs", 0, "pending");

        //grdvSubGmach.EditIndex = -1;


        //grdvSubGmach.DataBind();



    }












    protected void Row_Updating(Object sender, GridViewUpdatedEventArgs e)
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























        //   String id =e.OldValues[0].ToString()   ;
        //String email =e.NewValues[0].ToString()   ;
        //String subtype =e.NewValues[0].ToString() ;
        //String firstName = e.NewValues[0].ToString()  ;
        //String lastName =e.NewValues[0].ToString() ;
        //String tel = e.NewValues[0].ToString() ;




        //String sunday = e.NewValues[0].ToString() ;
        //String monday = e.NewValues[0].ToString() ;
        //String tuesday = e.NewValues[0].ToString() ;
        //String wednesday = e.NewValues[0].ToString() ;
        //String thursday = e.NewValues[0].ToString() ;
        //String friday =  e.NewValues[0].ToString() ;
        //String morning =  e.NewValues[0].ToString() ;
        //String afternoon =  e.NewValues[0].ToString() ;
        //String evening =  e.NewValues[0].ToString() ;
        //String subType =  e.NewValues[0].ToString() ;
        //String prm = "u";


        //String avail_request = e.OldValues[0].ToString() ;





        // GridViewRow row = ((GridView)sender).Rows[e.RowIndex];//row.Cells[13].Controls[0]

        ////LiteralControl ltEmil = (LiteralControl)row.Cells[22].Controls[0];

        ////TextBox ID = (TextBox)row.Cells[1].Controls[0];
        ////string id = ID.Text;


        ////HtmlContainerControl dvEmail = (HtmlContainerControl)ltEmil.FindControl("dvEmail");

        ////////////////////  HtmlTextArea txtemail = (HtmlTextArea)ltEmil.FindControl("txtemail");
        ////TextBox txtemailfff = (TextBox)ltEmil.FindControl("txtemail");



        //HtmlTextArea txtemaillllll = (HtmlTextArea)ltEmil.FindControl("txt_email");


        string status = e.NewValues[0].ToString(); ;








        //  grdvSubGmach.EditIndex = e.NewEditIndex;
        //string firstName = "";
        //string lastName = "";


        string commandText = "setMatches";

        //r.setMatches(commandText, prm, id, morning, afternoon, evening,
        //  sunday, monday, tuesday, wednesday, thursday, friday,
        //  subType, avail_request, email, firstName, lastName, tel, status);
        //grdvSubGmach.AutoGenerateColumns = false;

        ///UpdateDonate("S", "get_Orgs", 0, "pending");


























    }


    protected void RowCommand(Object sender, GridViewCommandEventArgs e)
    {




        //int i = e.NewSelectedIndex;

        //grdvSubGmach.EditIndex = e..Row.DataItemIndex;
        //////////  grdvSubGmach.DataBind();

    }




    protected void indexchange(Object sender, GridViewSelectEventArgs e)
    {


        String id = ((GridView)sender).Rows[e.NewSelectedIndex].Cells[2].ToString();

        //int i = e.NewSelectedIndex;

        //////grdvSubGmach.EditIndex = e.NewSelectedIndex ;
        //////grdvSubGmach.DataBind();

    }




    protected void BreadCrumbLink_Click(Object sender, EventArgs e)
    {
        String dir = ((LinkButton)sender).CommandName.ToString();


        ///// NavigationLink_Click(dir);



        //  pagestatus.page = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());


        pagestatus.dir = dir;
        //  pagestatus.row = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());

        items().CatID = Convert.ToInt16(dir); ;//.catid = Convert.ToInt16(dir);



        BLItems.raise(sender, e);























        //////////////////protected void CPage(Object sender, EventArgs e)
        //////////////////{
        //////////////////  int cpage = Convert.ToInt16(drplstCPage.SelectedValue.ToString());

        //////////////////  string dir = "current";


        //////////////////  items().pager = cpage;

        //////////////////  NavigationLink_Click(dir);

        //////////////////}









        //////////////////protected void PageSize(Object sender, EventArgs e)
        //////////////////{
        //////////////////    items().rowlimit = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());

        //////////////////    string dir = "current";




        //////////////////    NavigationLink_Click(dir);


        //////////////////}










        //////////////////protected void NavigationLink_Click(Object sender, EventArgs e)
        //////////////////{
        //////////////////    String dir = ((LinkButton)sender).CommandName.ToString();


        //////////////////     NavigationLink_Click(dir);










        //////////////////    //ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

        //////////////////    //DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
        //////////////////    //  items().pager += 1;




        //////////////////    //if (((Button)sender).CommandArgument == "Next")
        //////////////////    //{ dir = "forward"; }
        //////////////////    //else
        //////////////////    //{

        //////////////////    //    if (((Button)sender).CommandArgument == "Prev")
        //////////////////    //    { dir = "backward"; }

        //////////////////    //    else
        //////////////////    //    {

        //////////////////    //        if (((Button)sender).CommandArgument == "First")
        //////////////////    //        { dir = "backward"; }





        //////////////////    //    };


        //////////////////    //    //}
        //////////////////    //}

        //////////////////}











        //////////////////protected void NavigationLink_Click(String dir )
        //////////////////{
        //////////////////    String dirs = "";




        //////////////////    DataList dtalstItems = (DataList)this.FindControl("dtalstItems");


        //////////////////    int rowLimit = items().rowlimit;
        //////////////////    int page = items().pager * rowLimit;














        //////////////////    CurrentPage.Text = items().pager.ToString();
        //////////////////    int pageNext = items().pager + 1;


        //////////////////    //items().pager += 1;




        ////////////////// DataTable dataTable =       messages.DataTable!=null?messages.DataTable: null ;      //              ((DataTable)dtalstItems.DataSource);






        ////////////////// int totPages = messages.DataTable.Rows.Count / rowLimit;
        //////////////////    int totPagesRem = dtalstItems.Items.Count % rowLimit;

        //////////////////    int totPagesRemAll = messages.DataTable.Rows.Count % rowLimit;










        //////////////////    TotalPages.Text = totPages.ToString();















        //////////////////    if (dir == "Next")
        //////////////////    {
        //////////////////        if (totPages > items().pager)
        //////////////////        {

        //////////////////            page = items().pager * rowLimit;
        //////////////////            items().pager += 1;
        //////////////////        }
        //////////////////        else
        //////////////////        {
        //////////////////            if (totPages == items().pager)
        //////////////////            {

        //////////////////                if (totPagesRem > 0) { items().pager += 1; }

        //////////////////                page = items().pager * rowLimit;
        //////////////////            }
        //////////////////        }

        //////////////////    }







        //////////////////    if (dir == "Prev")
        //////////////////    {
        //////////////////        if (items().pager > 0)
        //////////////////        {



        //////////////////            items().pager -= 1;
        //////////////////            page = items().pager * rowLimit;
        //////////////////        }

        //////////////////    }










        //////////////////    if (dir == "Last")
        //////////////////    { 
        //////////////////            items().pager= totPages;


        //////////////////                if (totPagesRem > 0) { items().pager += 1; }

        //////////////////                page = items().pager * rowLimit;



        //////////////////    }







        //////////////////    if (dir == "First")
        //////////////////    {




        //////////////////            items().pager = 0;
        //////////////////            page = items().pager * rowLimit;


        //////////////////    }








        //////////////////    if (dir == "Currrent")
        //////////////////    {





        //////////////////        page = items().pager * rowLimit;


        //////////////////    }



















        //////////////////    if (dataTable.Rows.Count < page + rowLimit)
        //////////////////    {
        //////////////////       int rowlimit = (page + rowLimit)  -   dataTable.Rows.Count       ;

        //////////////////       rowLimit -= rowlimit;
        //////////////////    }



        //////////////////    /// items().pager += 1; items().pager -= 1; 
        //////////////////    // rowLimit = totPages == items().pager ?   totPagesRem : rowLimit;




        //////////////////    ////if (ds.Tables.Count > 0)
        //////////////////    ////{
        //////////////////    //    DataTable dataTable = dv.ToTable();
        //////////////////    //    dv.RowFilter = "Price >=  txtPriceStart    and Price <=  txtPriceEnd";


        //////////////////    //    dv.Sort = drplstSort.SelectedValue.ToString();










        //////////////////    //////////////////////////DataTable datatable = new DataTable();
        //////////////////    //////////////////////////datatable = messages.DataTable.Clone();




        //////////////////    //////////////////////////for (int x = page; x < page + rowLimit; x++)
        //////////////////    //////////////////////////{
        //////////////////    //////////////////////////    //if (x < page || x > page + rowLimit)
        //////////////////    //////////////////////////    //{

        //////////////////    //////////////////////////    datatable.ImportRow(messages.DataTable.Rows[x]);

        //////////////////    //////////////////////////    ////////// dataTable.Rows[x].Delete();
        //////////////////    //////////////////////////    //}
        //////////////////    //////////////////////////}



        //////////////////    /////////////////////////////////  datatable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();


        //////////////////    //////////////////////////dtalstItems.DataSource = datatable;// messages.DataTable;
        //////////////////    ///////////////////////////////////////////////// messages.DataTable=null;
        //////////////////    //////////////////////////dtalstItems.DataBind();















        //////////////////    dataTable = dataTable.AsEnumerable().Skip(page).Take(rowLimit).CopyToDataTable();
        //////////////////    //while (dataTable.Rows.Count > rowLimit)
        //////////////////    //    dataTable.Rows[dataTable.Rows.Count - 1].Delete();


        //////////////////    dtalstItems.DataSource = dataTable; /// messages.dvorgProducts;
        //////////////////    dtalstItems.DataBind();







        //////////////////    CurrentPage.Text = items().pager.ToString();


        //////////////////    TotalPages.Text = (messages.DataTable.Rows.Count / rowLimit).ToString();

        //////////////////    drplstCPage.SelectedIndex=items().pager-1;

        //////////////////       //  PageSize






        //////////////////}







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
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
using System.Net.Mail;
using System.Xml.Linq;

public partial class comment : System.Web.UI.Page
{
    public String selecter;

    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl dvCatsGen = (HtmlGenericControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "hidden");


        if (!IsPostBack)
        {
            if (BLOrganization.orgID != 0 && BLCustomer.buyerID != 0)
            {
               // filMessages();
                itemSearch("V");

            }
            else { Response.Redirect("orgHome.aspx"); }
        }
       




       

       ////////// HtmlTable tblPost = (HtmlTable)this.FindControl("tblPost");
       //////////tblPost.Visible = false;

      //
    }



    protected void items_Search(Object sender, EventArgs e)
    {
        String select = grdvCatGeneral.SelectedValue.ToString();
        selecter = select;
        HtmlGenericControl dvCatsGen = (HtmlGenericControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "hidden");
        BLItems.msgAuctionID = Convert.ToInt16(selecter);
       

        //HtmlTable tblPost = (HtmlTable)this.FindControl("tblPost");
        //tblPost.Visible = true;
        filMessages();

    }





    protected void SendMessage(Object sender, EventArgs e)
    {
       string msg= txtmsg.Text;

       HtmlInputHidden hdnauid = (HtmlInputHidden)this.FindControl("hdnauid");
       BLItems.msgAuctionID = Convert.ToInt16(hdnauid.Value);
       msg = HTMLEmailEdit.Value;

       int orgID = BLCustomer.signedinorgid == 0 ? BLOrganization.orgID : BLCustomer.signedinorgid;

       ////int orgID =  BLOrganization.orgID;
          int buyerID = BLCustomer.buyerID ; 
        string forumMessage=msg;


        string messageType=      BLCustomer.signedinorgid==0 ?     "Q":"A" ;
            string messageSeneder="";
         //// BLItems.msgAuctionID = Convert.ToInt16( selecter);



          BLItem.setMessages(orgID,
      buyerID, forumMessage, messageType,
        messageSeneder);
          filMessages();

    }




    protected void filMessages()
    {
       



        string msg = txtmsg.Text;
        int orgID = BLCustomer.signedinorgid == 0 ? BLOrganization.orgID : BLCustomer.signedinorgid;

        ///int orgID = BLOrganization.orgID;
        int buyerID = BLCustomer.buyerID;
        string forumMessage = msg;
        string messageType = "";
        string messageSeneder = "";
        ///BLItems.AuctionID = Convert.ToInt16(selecter);

        DataSet ds = new DataSet();


        dtalstItems.AutoGenerateColumns = false;

      ds=  BLItem.fillMessages(orgID,
    buyerID, forumMessage, messageType,
      messageSeneder);
      if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
      {
          dtalstItems.DataSource = ds;

          dtalstItems.DataBind();
      }


    }












    protected void sortOrders(object sender, EventArgs e)
    {








    }

    //////////////protected override void RaisePostBackEvent(IPostBackEventHandler source, string eventArgument)
    //////////////{
    //////////////    if (source == grdvCatGeneral)
    //////////////    {
    //////////////        //add proper validation to avoid out of bounds exception
    //////////////        //this code increments, but you need to add something to increment or decrement 
    //////////////        grdvCatGeneral.SelectedIndex = Int32.Parse(eventArgument) + 1;
    //////////////    }
    //////////////}

  
    
    //protected void grdvCatGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //pass in an argument that will help to determine index of new selection
    //    //for this example, I just chose the row index
    //    e.Row.Attributes["onkeypress"] = String.Format("validateKeyPress({0});", e.Row.RowIndex);
    //}

    protected void grdvCatGeneral_OnItemDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {    



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String title=   ( (DataRowView)e.Row.DataItem)["title"].ToString() ;
           int auid=  Convert.ToInt16( ( (DataRowView)e.Row.DataItem)["itemauctionid"].ToString());
         //javascript:__doPostBack('grdvCatGeneral', rowIndex);

        e.Row.Attributes.Add("onclick", "validateKeyPress(" + e.Row.RowIndex + ','+ auid + ',' +"'"+ title+ "')") ;

            HtmlContainerControl dvlst = (HtmlContainerControl)e.Row.FindControl("dvlst");

             dvlst.InnerHtml=((DataRowView)e.Row.DataItem)["forum"].ToString();
           //////////////// LinkButton lnklst = (LinkButton)dvlst.FindControl("dvlst");
            

        }
    }






    protected void rptProductList_OnItemDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;


            //  e.Row.Cells[colIndex].Attributes.Add("title", tooltip);



          



            //switch (e.Item.ItemType)
            //{
            //    case ListItemType.Item:
            //    case ListItemType.AlternatingItem:



            HtmlImage imgorgLogo = (HtmlImage)e.Row.FindControl("imgItem");

            //  imgorgLogo.Src = "Images/" + ((DataRowView)e.Item.DataItem)["imgPath"].ToString().Trim(); ;
          /////////////////////////////  imgorgLogo.Src = "Images/" + ((DataRowView)e.Row.DataItem)["img1"].ToString().Trim(); ;


            HtmlAnchor anchorProfile = (HtmlAnchor)e.Row.FindControl("anchorProfile");
           /////////////////////////// anchorProfile.HRef = "orgCheckout.aspx?" + "aid=" + ((DataRowView)e.Row.DataItem)["item_AuctionID"].ToString();
            //if (((DataRowView)e.Item.DataItem)["Live"].ToString() == "BID")
            //{
           ///////////////// anchorProfile.HRef = "orgCheckout.aspx?" + "aid=" + ((DataRowView)e.Row.DataItem)["item_AuctionID"].ToString() + "&" + "cid=" + ((DataRowView)e.Row.DataItem)["catid"].ToString() + "&" + "id=" + ((DataRowView)e.Row.DataItem)["itemID"].ToString();
            //}
            //else { anchorProfile.HRef = "#"; }

            //HtmlAnchor anchorProfile1 = (HtmlAnchor)e.Item.FindControl("anchorProfile1");

            //anchorProfile1.HRef = "Auction.aspx?" + ((DataRowView)e.Item.DataItem)["itemAuctionID"].ToString();

            HtmlContainerControl bidcount = (HtmlContainerControl)e.Row.FindControl("bidcount");



            HtmlContainerControl currentBidPrice = (HtmlContainerControl)e.Row.FindControl("currentBidPrice");


            HtmlContainerControl dvusername = (HtmlContainerControl)e.Row.FindControl("dvusername");




             String messageType =  ((DataRowView)e.Row.DataItem)["messageType"].ToString() ;


             dvusername.InnerHtml = messageType == "Q" ? "Customer" : "Org";


          if( messageType == "Q")
          { e.Row.BackColor.GetBrightness(); 
          e.Row.BackColor= System.Drawing.Color.Aquamarine;
          
          }

            ////int bidcounter = Convert.ToInt16(((DataRowView)e.Row.DataItem)["bidcount"].ToString());


            ///////////////////////////sumcurrentBidPrice += BidPrice;
          /////////////////////////  sumbidcount += bidcounter;

            HtmlContainerControl amounter = (HtmlContainerControl)e.Row.FindControl("amounter");
            HtmlContainerControl dvauctionid = (HtmlContainerControl)e.Row.FindControl("dvauctionid");
            dvauctionid.InnerHtml = ((DataRowView)e.Row.DataItem)["item_Auctionid"].ToString();
           
            
            bidcount.InnerHtml = ((DataRowView)e.Row.DataItem)["itemStatus"].ToString();







            HtmlContainerControl forumMessage = (HtmlContainerControl)e.Row.FindControl("forumMessage");


            HtmlContainerControl buyer_name = (HtmlContainerControl)e.Row.FindControl("buyer_name");



            HtmlContainerControl org_title = (HtmlContainerControl)e.Row.FindControl("org_title");


            HtmlContainerControl forumdate = (HtmlContainerControl)e.Row.FindControl("forumdate");

            forumMessage.InnerHtml = ((DataRowView)e.Row.DataItem)["forumMessage"].ToString();



            
  //
  //
  //
  //
            buyer_name.InnerHtml = ((DataRowView)e.Row.DataItem)["buyer_name"].ToString();



            org_title.InnerHtml = ((DataRowView)e.Row.DataItem)["org_title"].ToString();



            forumdate.InnerHtml =  ((DataRowView)e.Row.DataItem)["forumdate"].ToString();

            ////////////DateTime dtNow = new DateTime();
            ////////////// dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);
            ////////////dtNow = DateTime.Now;
            ////////////TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
            ////////////ts = dtFuture.Subtract(dtNow);
            ////////////long amountlong = (long)ts.TotalMilliseconds;

            ////////////amounter.InnerHtml = amountlong.ToString();



            //        break;
            //}
        }


    }










    protected void itemSearch(Object sender, EventArgs e)
    {


      
        int buyerID = BLCustomer.buyerID;
        int orgid = BLCustomer.signedinorgid == 0 ? BLOrganization.orgID : BLCustomer.signedinorgid;


        int catid = items().CatID;

        catid = 0;


        HtmlContainerControl dvCatsGen = (HtmlContainerControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "visible");


        DataSet ds = new DataSet();



        /////  BLCustomer cust = (BLCustomer)messages.cust; 





        ds = BLItems.GetItemsList("K", "get_Items", 0, orgid, catid, txtItemSearch.Text.Trim());

         lstvCatGeneral.DataTextField = "forum2";
         lstvCatGeneral.DataValueField = "auctionid";





        grdvCatGeneral.AutoGenerateColumns = false;

        grdvCatGeneral.DataSource = ds;


        grdvCatGeneral.DataBind();
    }





    protected void catSearch(Object sender, EventArgs e)
    {

        //if (Request.Url.ToString().IndexOf("orgProducts") == -1)
        //{ Response.Redirect("orgProducts.aspx"); }
        HtmlGenericControl dvCatsGen = (HtmlGenericControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "visible");

        itemSearch("C" );
        /////item_Search();
    }












    protected void itemSearch(String type )
    {



        int orgid = messages.orgs_.ID;
        int catid = items().CatID;

        catid = 0;


        HtmlContainerControl dvCatsGen = (HtmlContainerControl)this.FindControl("dvCatsGen");

        dvCatsGen.Style.Add("visibility", "visible");


        DataSet ds = new DataSet();



        /////  BLCustomer cust = (BLCustomer)messages.cust; 



        ds = BLItems.GetItemsList("K", "get_Items", 0, orgid, catid, txtItemSearch.Text.Trim());

        ////grdvCatGeneral.DataTextField = "forum";// "title";
        ////grdvCatGeneral.DataValueField = "itemid";


        if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        { 
        dvCatsGen.Style.Add("visibility", "hidden");
        }

        if (type == "C")
        {
            grdvCatGeneral.AutoGenerateColumns = false;

            grdvCatGeneral.DataSource = ds;


            grdvCatGeneral.DataBind();

        }
        else
        {
            lstvCatGeneral.DataTextField = "forum2";
            lstvCatGeneral.DataValueField = "auctionid";
        }

       
    }




}

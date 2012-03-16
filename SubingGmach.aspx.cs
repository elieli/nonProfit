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

public partial class SubingGmach : System.Web.UI.Page
{
    Referrer r = new Referrer();
    public String SubGmachTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        load();

    }





    protected void chgsts( object sender , EventArgs e)
    {



        UpdateDonate("A", "set_Orgs", 0, "pending");
        
    }






    protected void load()
    {
       
        if (!IsPostBack)
        {


            mails.prm =  "2";
            String qry = Server.UrlDecode(Request.QueryString.ToString());



            //if (qry != null && qry.Length > 0 && qry.ToString() != string.Empty)
            //{
            //    mails.prm = qry.ToString().IndexOf("prm=") == -1 ? "0" : qry.Substring(qry.ToString().IndexOf("prm=") + 4, qry.Length - 4);

            //}




            UpdateDonate("S", "get_Orgs", 0, drplstEmailSts.SelectedValue.ToString());
          
            //if (mails.prm != "2" && (Logins.password != "itty" || Logins.userid != "itty"))
            //{ return; }


            //if (mails.prm == "2" && (Logins.password == "itty" || Logins.userid == "itty"))
            //{
            //    mails.prm = "8";
            //}


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
 



            //if (mails.prm =="1")
            //{
            //    Update_Donate();
            //}



          
        }

      //  UpdateDonate("S", "get_Orgs", 0, drplstEmailSts.SelectedValue.ToString());



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


        UpdateDonate("A", "set_Orgs", 0, "pending");
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
        grdvSubGmach.EditIndex = -1;
        grdvSubGmach.DataBind();
      // UpdateDonate("S", "get_Orgs",0);
        UpdateDonate("S", "get_Orgs",0,"pending");
        try
        {
            //GridViewRow row = ((GridView)sender).Rows[e.RowIndex];



            //HtmlContainerControl dvEmil = (HtmlContainerControl)row.FindControl("dvEmil");

            //HtmlTextArea txtemail = (HtmlTextArea)dvEmil.FindControl("txt_email");
            //TextBox txtEmail = (TextBox)dvEmil.FindControl("txtemail");
        }
        catch { }

        }






    protected void UpdateDonate(String parm, string commandtext, int id,  string status)
    {



        String orgEmail = ""; // ((HtmlInputControl)this.FindControl("orgEmail")).Value;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
        // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        String orgTitle = ""; //  ((HtmlInputControl)this.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();
        String orgFunct = ""; //  ((HtmlInputControl)this.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
        String orgDesc = ""; // ((HtmlInputControl)this.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
        String orgTaxID = ""; //  ((HtmlInputControl)this.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

        String orgPaypal = ""; //  ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

        String orgLogo = ""; //  ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
        String orgVideo = "";
       // String buttonLogo = ""; //  ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

        String orgStatus = status;// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();



        //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

        //if (ConfirmImg!=null) 
        //{
        //    OnSaveClick(buttonLogo);
        //    return;

        //}





        orgStatus = status;// drplstEmailSts.SelectedValue.ToString();







        String prm =      parm;

       
       

          

          //}

       // int id = 0;
       /// int Site = 0;// (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
       // String status = "pending";
        status = "";
   
        DataSet ds = new DataSet();
      //if (prm!="2")  status = drplstEmailSts.SelectedValue=="All" ? String.Empty : drplstEmailSts.SelectedValue  ;
      //if (prm == "8") prm = "2";
        string commandText =   "get_Orgs";



        if (prm== "S")
        {
            orgStatus = drplstEmailSts.SelectedValue.ToString();
               ds =    r.getOrgs(commandText,
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
        else
        {
   r.setOrgs(commandText,
            prm,
            id,
         orgTitle,
         orgFunct,
         orgDesc,
     orgTaxID,
     orgEmail,
     orgPaypal,
     orgLogo,
     orgStatus,
     orgVideo,"",""

    );
   prm = "S";
   orgStatus = drplstEmailSts.SelectedValue.ToString();
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

        };

       


          prm = mails.prm;  
          //////ds.Tables[0].Columns.Add("prm");

          //////foreach (DataRow dr in ds.Tables[0].Rows)
          //////{
          //////    dr["prm"] = prm;

          //////}

          if (ds.Tables.Count > 0)
          {
              grdvSubGmach.AutoGenerateColumns = false;
              grdvSubGmach.DataSource = ds;
              grdvSubGmach.CellPadding = 9;
              grdvSubGmach.Columns[3].ItemStyle.Width = 230;

              grdvSubGmach.DataBind();

              grdvSubGmach.Columns[grdvSubGmach.Columns.Count - 1].Visible = false;
          }

          else


          {grdvSubGmach.DataSource = null;
              grdvSubGmach.CellPadding = 9;
              grdvSubGmach.Columns[3].ItemStyle.Width = 230;

              grdvSubGmach.DataBind();
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

        DataSet ds = (DataSet)   ((GridView) grdvSubGmach).DataSource;
        int id = 0;
        bool cb = false;

        foreach (GridViewRow dr in grdvSubGmach.Rows)
        {

            foreach (TableCell cc in dr.Cells)
            {
                if (cc.FindControl("id") != null)
                {
                      id = (int)Convert.ToInt16(((Label)(cc.FindControl("id"))).Text);
                  cb = ((CheckBox)dr.Cells[3].FindControl("chkStatus")).Checked;
                      break;
                }
                  
            }


   //   cb=       ( (CheckBox) dr.Cells[3].FindControl("chkStatus")).Checked  ;



        // id =(int) Convert.ToInt16(  ( (Label) (       dr.Cells[2].FindControl("id"))).Text)  ;


            if
                (cb==true    )


                UpdateDonate("A", "set_Orgs", id , "approved");

            {
            

           

            //}
            
            }

            }
     


    }








    protected void Edit(Object sender, GridViewEditEventArgs e)
    {
        UpdateDonate("S", "get_Orgs", 0, "pending");
         grdvSubGmach.EditIndex = e.NewEditIndex;

         grdvSubGmach.DataBind();


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

         UpdateDonate("S", "get_Orgs", 0, "pending");

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
        grdvSubGmach.AutoGenerateColumns = false;

        UpdateDonate("S", "get_Orgs", 0, "pending");

        grdvSubGmach.EditIndex = -1;


        grdvSubGmach.DataBind();



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
         grdvSubGmach.AutoGenerateColumns = false;

         UpdateDonate("S", "get_Orgs", 0, "pending");


























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
    
    



}









////protected void GridView1_RowDataBound(object sender,
////GridViewRowEventArgs e)
////{
////if (e.Row.RowType == DataControlRowType.DataRow)
////{
////if (e.Row.Cells[0].Text == "0")
////{
////e.Row.Cells[2].Style["background-color"] = "yellow";
////}

////e.Row.Cells[0].Visible = false;
////}
////}

////Regards,
////Mykola
////http://marss.co.ua

////    Reply With Quote
////marss
////Old 11-21-2007, 01:54 PM 	  #3
////gnewsgroup
 
////Posts: n/a
	
////Default Re: Problem modifying GridView cells at OnDataBound
////On Nov 21, 1:03 am, marss <marss...@gmail.com> wrote:
////> On 21 ìÉÓ, 05:47, gnewsgroup <gnewsgr...@gmail.com> wrote:
////>
////> > I have a GridView which is bound to my database.
////>
////> > The leftmost column of the GridView has a value of either 0 or 1,
////> > and I need to highlight the cell of column 3 if the leftmost column
////> > has a value of 0. After highlighting, I want the leftmost column to
////> > disappear.
////>
////> Use OnRowDataBound event handler. It occurs when each single row is
////> bound. Also there is not need to add a label, you can paint a cell
////> itself.
////>
////> protected void GridView1_RowDataBound(object sender,
////> GridViewRowEventArgs e)
////> {
////> if (e.Row.RowType == DataControlRowType.DataRow)
////> {
////> if (e.Row.Cells[0].Text == "0")
////> {
////> e.Row.Cells[2].Style["background-color"] = "yellow";
////> }
////>
////> e.Row.Cells[0].Visible = false;
////> }
////>
////> }



//foreach (GridViewRow gvr in myGridView.Rows)
//{
//if (myGridView.Columns[0].Text.Equals("0"))
//{
//Label lbl = new Label();
//lbl.Text = gvr.Cells[2].Text;
//lbl.BackColor = Color.Yellow;
//gvr.Cells[2].Text = String.Empty;
//gvr.Cells[2].Controls.Add(lbl);
//}

//// Now let the leftmost column disappear!
//myGridView.Columns[0].Visible = false;
//}

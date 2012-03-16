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

public partial class Default2 : System.Web.UI.Page
{
   // Queue queue = new Queue();
    Referrer r = new Referrer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (custs() == null)
        {
            BLCustomer cust = new BLCustomer(0);
            Application["cust"]=cust;


        }

       // if (messages.orgs_.ID <= 0)
        if (custs().signedInorgID <= 0)
        {
            Response.Redirect("Login.aspx?login=org");
        }




        if (!IsPostBack)
        {
            messages.cnt = 0;
            messages.arCats = new  String [20];
 
            DataSet ds = UpdateDonate("R", "get_Categories", 0, "");


            lstcatsub1.Visible = false;
            lstcatsub2.Visible = false;
            lstcatsub3.Visible = false;



            lstcat.DataSource = ds;
            lstcat.DataBind();
        }
    }




    protected void subCat(Object sender, EventArgs e)
    {
        ListBox lb = new ListBox();
        ListBox lbn = new ListBox();
      
        
        messages.cnt += 1;

      

      //  queue.Clear() ;

      

       // queue.Enqueue(hc.Value);

        lstcatsub1.Visible = false;
        lstcatsub2.Visible = false;
        lstcatsub3.Visible = false;
        int counter = 0;


       String name= ((ListBox)sender).ID.ToString();
       int subcat = (int)Convert.ToInt16(((ListBox)sender).SelectedValue.ToString());


       items().CatID = subcat;


       items().CatID = subcat;


       switch (name)
        {

            case "lstcat":
                //lstcatsub1.DataSource = ds;   
                //lstcatsub1.DataBind();
                lstcatsub1.Visible = true;
                lb = lstcat;
                lbn = lstcatsub1;
                counter =0;

                break;


            case "lstcatsub1":
                //lstcatsub1.DataSource = ds;   ;
                //lstcatsub1.DataBind();
                lstcatsub1.Visible = true; lstcatsub2.Visible = true;
                lb = lstcatsub1;
                lbn = lstcatsub2;
                counter = 1;

                break;



            case "lstcatsub2":

                lstcatsub1.Visible = true;

                //lstcatsub2.DataSource = ds; ;
                //lstcatsub2.DataBind();
                lstcatsub2.Visible = true; lstcatsub3.Visible = true;
               lb = lstcatsub2;
                lbn = lstcatsub3;
                counter = 2;
                break;



            case "lstcatsub3":

                lstcatsub1.Visible = true;
                lstcatsub2.Visible = true;
               
                lstcatsub3.Visible = true; 
                lb  = lstcatsub3;
                lbn = lstcatsub3;
                counter = 3;
                break;
  
        }



       messages.arCats[counter] = lb.SelectedItem.ToString() + " ";

       for (int x = counter+1; x < messages.arCats.Count(); x++)
       {
           messages.arCats[x] = "";

       }


       if (((ListBox)sender).SelectedItem.ToString().IndexOf(">") == -1 || name == "lstcatsub3")
       {
           HtmlContainerControl catlstbx = (HtmlContainerControl)this.FindControl("catlstbx");

          custs().Organization.Orgitems.CatID = Convert.ToInt16( ((ListBox)sender).SelectedValue.ToString().Replace('>', ' '));

          custs_ = custs();



           catlstbx.Visible = true;
           return;

       }

        //messages.catID = subcat;



        //{
        //    HtmlContainerControl catlstbx = (HtmlContainerControl)this.FindControl("catlstbx");

        //    catlstbx.Visible = true;
        //}

        //else 
        //{

       




        DataSet ds = UpdateDonate("S", "get_Categories", subcat, "");



        HtmlInputText hc = (HtmlInputText)this.FindControl("lisub");
     //   if (messages.cnt > 1) { hc.Value += " > "; }

        //messages.arCats[counter] = lb.SelectedItem.ToString() + " ";
        //messages.address += lb.SelectedItem.ToString() + " ";



        hc.Value =   messages.arCats.ToString() ; //messages.address;

        lbn.DataSource = ds; ;
        lbn.DataBind();


        //}
    }


    protected void catProd(Object sender, EventArgs e)
    {
        String mc = messages.arCats.Count() > 0 ? messages.arCats[messages.arCats.Count() - 1] : "";
        Response.Redirect("Default3.aspx?cat= " + items().CatID);

       



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

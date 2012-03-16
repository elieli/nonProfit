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
 
    public partial class pageing : System.Web.UI.UserControl
    {
        static private DataList m_datalist;
        Control parent;
        DataSet ds;
        DataTable dataTable;


        public event EventHandler navigate;



        protected void Page_Load(object sender, EventArgs e)
        {


            if (drplstCPage.SelectedIndex == -1)

            { drplstCPage.SelectedValue = items().pager <= 0 ? "1" : items().pager.ToString(); }

            if (drplstPageSize.SelectedIndex == -1)
            { drplstPageSize.SelectedValue = items().rowlimit.ToString(); }



                     TotalPages.Text = (items().totpage).ToString();
                     ///////////////////////////CurrentPage.Text = (items().pager - 1).ToString();




      ///    messages.navigate += new EventHandler(NavigationLink_Click);

             

            if (!IsPostBack)
            {


                parent = messages.GetParentOfType(this.Parent);

                switch (parent.ToString())
                {
                    case "orgproducts_aspx":
                    case "ASP.orgproducts_aspx":
                    case "orgproducts_ascx":

                        ds = items().Items;
                        ////datalist = messages.datalist;

                    ////////    DataTable dataTable = (DataTable)(((BLCustomer)messages.cust).Organization.Orgitems.ItemsDV).Table;

                        break;

                    case "auction_aspx":
                        // messages.DataTable = dataTable;
                        Response.Redirect("orgproducts.aspx?");



                        break;



                }



                ////////////if (IsPostBack)
                ////////////{


                ////////////    ///////////////  DataTable dataTable = messages.DataTable != null ? messages.DataTable : null;

                ////////////    DataTable dataTable = (DataTable)((DataView)((DataList)this.Parent.FindControl("dtalstItems")).DataSource).Table;
                ////////////    DataList dtalstItems = (DataList)datalist;



                ////////////    DataView dv = new DataView();

                ////////////    dv.Table = dataTable;





                ////////////    dtalstItems.DataSource = dv;// dataTable;
                ////////////    dtalstItems.DataBind();

                ////////////}

            }

        }






        static public DataList datalist
        {
            get { return m_datalist; }
            set { m_datalist = value; }
        }






        protected void CPage(Object sender, EventArgs e)
        { 

           


            int cpage = Convert.ToInt16(((DropDownList)    sender).SelectedValue.ToString());

            string dir = "current";


          ///  items().pager = cpage;




            pagestatus.page=cpage;//.dir = dir;



            BLItems.raise(sender, EventArgs.Empty);


          //  NavigationLink_Click(dir);

        }








        protected void PageSize(Object sender, EventArgs e)
        {
           // items().rowlimit = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());

            string dir = "current";


            events ev = new events();



            pagestatus.row = Convert.ToInt16(((DropDownList)sender).SelectedValue.ToString());//dir;



            BLItems.raise(sender, EventArgs.Empty);

           /// navigate(sender, pagestatus);





            //  pagestatus.page = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());


          
            //  pagestatus.row = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());

          ///  messages.raise(sender, EventArgs.Empty);



         //   NavigationLink_Click(dir);


        }










        protected void NavigationLink_Click(Object sender, EventArgs e)
        {
            String dir = ((LinkButton)sender).CommandName.ToString();


           ///// NavigationLink_Click(dir);



          //  pagestatus.page = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());


            pagestatus.dir = dir;
          //  pagestatus.row = Convert.ToInt16(drplstPageSize.SelectedValue.ToString());

            BLItems.raise(sender, EventArgs.Empty);









            //ContentPlaceHolder MainContent = (ContentPlaceHolder)Page.Master.FindControl("Body");

            //DataList dtalstItems = (DataList)(MainContent.FindControl("orgProducts2")).FindControl("dtalstItems");
            //  items().pager += 1;




            //if (((Button)sender).CommandArgument == "Next")
            //{ dir = "forward"; }
            //else
            //{

            //    if (((Button)sender).CommandArgument == "Prev")
            //    { dir = "backward"; }

            //    else
            //    {

            //        if (((Button)sender).CommandArgument == "First")
            //        { dir = "backward"; }





            //    };


            //    //}
            //}

        }











        protected void NavigationLink_Click(String dir)
        {
            String dirs = "";




            ////     DataList dtalstItems = (DataList)this.FindControl("dtalstItems");


            int rowLimit = items().rowlimit;
            int page = items().pager * rowLimit;

            //CurrentPage.Text = items().pager.ToString();
            int pageNext = items().pager + 1;


            //items().pager += 1;







            DataSet ds = ((BLCustomer)messages.cust).Organization.Orgitems.Items;



            ///  DataTable dataTable = messages.DataTable != null ? messages.DataTable : null;      //              ((DataTable)dtalstItems.DataSource);




            ////   DataTable dataTable = (DataTable)((DataList)this.Parent.FindControl("dtalstItems")).DataSource;

            ////////  DataTable dataTable = (DataTable)((DataView)  ((DataList)this.Parent.FindControl("dtalstItems")).DataSource).Table;
            ////////DataTable dataTable = (DataTable)(  ((BLCustomer)messages.cust).Organization.Orgitems.ItemsDV).Table ;


            int totPages = dataTable.Rows.Count / rowLimit;

            /////int totPagesRem = dtalstItems.Items.Count % rowLimit;



            int totPagesRemAll = messages.DataTable.Rows.Count % rowLimit;










            ////TotalPages.Text = totPages.ToString();















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

                        if (totPagesRemAll > 0) { items().pager += 1; }

                        page = items().pager * rowLimit;
                    }
                }

            }







            if (dir == "Prev")
            {
                if (items().pager > 0)
                {



                    items().pager -= 1;
                    page = items().pager * rowLimit;
                }

            }










            if (dir == "Last")
            {
                items().pager = totPages;


                if (totPagesRemAll > 0) { items().pager += 1; }

                page = items().pager * rowLimit;



            }







            if (dir == "First")
            {




                items().pager = 0;
                page = items().pager * rowLimit;


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
            DataList dtalstItems = (DataList)this.Parent.FindControl("dtalstItems");

            DataView dv = new DataView();
            dataTable.TableName = "table1";

            dv.Table = dataTable;




            dtalstItems.DataSource = dv;// dataTable; 
            dtalstItems.DataBind();


            //base.refRefresh();




            //////////CurrentPage.Text = items().pager.ToString();


            //////////TotalPages.Text = (messages.DataTable.Rows.Count / rowLimit).ToString();

            //////////drplstCPage.SelectedIndex = items().pager - 1;

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





    }

    
 
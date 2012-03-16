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

public partial class simpleGetLoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string qry = Request.QueryString !=null  && Request.QueryString.Count>0 ?   Request.QueryString[0].ToString():  "" ;
        DataSet ds = new DataSet();
         
        int auctionid=     qry==null || qry == "" ?   0 :    (int) Convert.ToInt16 ( qry ) ;

        if (Application["cust"] == null)
        {

            BLCustomer cust = new BLCustomer(0);

           
            Application["cust"] = cust;


            
        }
        
        //try
        //{
       


      String Credits = custs().Credits.ToString();// dr["Credits"].ToString();

            

      HtmlContainerControl loginorg = (HtmlContainerControl)this.FindControl("loginorg");
      loginorg.InnerText = custs()  == null || custs().signedinorgid == 0 ? "" : custs().signedinorgname;



      HtmlContainerControl logincust = (HtmlContainerControl)this.FindControl("logincust");
      logincust.InnerText = custs().CustName == null || custs().CustName == "" ? "" : custs().CustName;

          

        HtmlContainerControl credits = (HtmlContainerControl)this.FindControl("credits");
        credits.InnerText =   Credits.ToString();   //messages.currentBidAmount.ToString();




        


        HtmlContainerControl cartcount = (HtmlContainerControl)this.FindControl("cartcount");
        cartcount.InnerText = items().cartcount.ToString();





        //HtmlContainerControl handling = (HtmlContainerControl)this.FindControl("cartcount");
        //handling.InnerText = items().Handling.ToString();



       
        //}
        //catch (Exception) { }
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

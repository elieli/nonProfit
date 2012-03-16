orgusing System;
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

public partial class simplePageBtn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnBidNow_Click();

    }


    protected void btnBidNow_Click()
    {

        string qry = Request.QueryString != null && Request.QueryString.Count > 0 ? Request.QueryString[0].ToString() : "";

       // HtmlInputFile fileLoad = (HtmlInputFile)this.FindControl("fileLoad");


        HtmlInputFile fileLoad = (HtmlInputFile)this.FindControl("fileLoad");


        messages.path = "Images/";

        String image = messages.filePost(fileLoad);
 
    }













}


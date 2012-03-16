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

public partial class Galleryfrm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    

    {
        if (!IsPostBack)
        {
          //  return;

      ///      this.Button1.Attributes.Add("onclick", "javascript:GetRowValue()");

        }
    }
    protected void OnSaveClick(object sender, EventArgs e)
    {



   String test=     Request.Form[""].ToString();



        HtmlInputFile fileLoad = (HtmlInputFile)this.FindControl("fileLoad");


        string path = Server.MapPath("images");

      String image =  messages.filePost(fileLoad,path);

 HtmlGenericControl  dvsavefile=(HtmlGenericControl)this.FindControl("dvsavefile");
 dvsavefile.InnerHtml = image;




    }


}

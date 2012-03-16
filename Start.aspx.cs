using System;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

public partial class Start : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void OnSaveClick(object sender, EventArgs e)
    {



        HtmlInputFile fileLoadimgTop = (HtmlInputFile)this.FindControl("fileLoadimgTop");

        HtmlInputFile fileLoadimgTop1 = (HtmlInputFile)this.FindControl("fileLoadimgTop1");

        HtmlInputFile fileLoadimgTop2 = (HtmlInputFile)this.FindControl("fileLoadimgTop2");





        HtmlInputFile fileLoad = (HtmlInputFile)this.FindControl("fileLoad");

        string path = Server.MapPath("//images");
        messages.filePost(fileLoadimgTop,path);


        messages.filePost(fileLoadimgTop1,path);
        messages.filePost(fileLoadimgTop2,path);





    }


}

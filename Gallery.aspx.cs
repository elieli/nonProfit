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

public partial class Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    

    {
        if (!IsPostBack)
        {
            //  return;

            ///string ctrlname = Request.Form("__EVENTTARGET");
         
            ///string ctrlname = page.Request.Params.Get("__EVENTTARGET");
           
        

      ///      this.Button1.Attributes.Add("onclick", "javascript:GetRowValue()");

        }
            else
        {
            string param = Request.Form["__EVENTARGUMENT"];

            if (param != null)

            OnSaveClick(sender, e);
        }
              

    }
    protected void OnSaveClick(object sender, EventArgs e)
    {



        String test = Request.Form["test"].ToString();





        HtmlInputFile fileLoad = (HtmlInputFile)this.FindControl("fileLoad");

        //window.location.reload(); 
      string  path= Server.MapPath("images");

      String image =  messages.filePost(fileLoad, path);

 HtmlGenericControl  dvsavefile=(HtmlGenericControl)this.FindControl("dvsavefile");
 dvsavefile.InnerHtml = image;


 this.Response.ClearContent();
 this.Response.Write(@"<html>
                            <head>
                            <script type='text/javascript' language='javascript'>
                            <!--
                     
                        window.close();

                            // -->
                            </script>
                            </head>
                            <body />
                            </html>");
 this.Response.End();


    }


}

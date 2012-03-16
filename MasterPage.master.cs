using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public String code = "";
    public String visulg;
    public String visus;
    public String visul;

    protected void Page_Load(object sender, EventArgs e)
      { // if (IsPostBack)
    //{
        //HtmlGenericControl ulsubs = (HtmlGenericControl)this.FindControl("ulsubs");
        //HtmlGenericControl ulplace = (HtmlGenericControl)this.FindControl("ulplace");
        //if (ulsubs!=null)
        //{
            visulg =  "block" ;
            visus = "none";
            visul = "none";

        //ulsubs.Visible = false;
        //ulplace.Visible = false;
        if (Logins.password != null && Logins.password == "itty")
        {


            visulg = "none";
            visus = "block";
            visul = "block";







            //ulsubs.Visible = true; 
            //ullog.Visible = false;
            //ulplace.Visible = true; 
        }

        code =   "<script  type='text/javascript' language='JavaScript'> " +
       "    function godom() {" +
  "   var ullog = document.getElementById('ullog'); " +
      "   var ulsubs = document.getElementById('ulsubs'); " +
      "   var ulplace = document.getElementById('ulplace'); " +
        "    ullog.style.display=' " + visulg + "'; " +
           "    ulsubs.style.display=' " + visus + "'; " +
            "    ulplace.style.display=' " + visul + "'; " +
                "   }  godom() ;  window.close();  </script>   ";


        ClientScriptManager csm = Page.ClientScript;

        csm.RegisterStartupScript(Page.GetType(), "timer", code, false);








    }
    }
//}
//}

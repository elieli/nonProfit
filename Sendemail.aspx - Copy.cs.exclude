using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
 
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Sendemail : System.Web.UI.Page
{
    Referrer r = new Referrer();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            String url = Server.UrlDecode(Request.QueryString.ToString());

            //mails.ID = "";
            // mails.email = "";
            // mails.reqemail = "";
            String[] qry = new String[0];

            qry = url.ToString().Split('&');
            if (qry != null && qry.Length > 0 && qry[0].ToString() != string.Empty)
            {


                mails.prm = qry[0].ToString().IndexOf("prm=") == -1 ? "0" : qry[0].Substring(qry[0].ToString().IndexOf("prm=") + 4, qry[0].Length - 4);

                mails.id = qry[1].ToString().IndexOf("id=") == -1 ? "0" : qry[1].Substring(qry[1].ToString().IndexOf("id=") + 3, qry[1].Length - 3);
             
                mails.sunday = qry[2].ToString().IndexOf("sunday=") == -1 ? "0" : qry[2].Substring(qry[2].ToString().IndexOf("sunday=") + 7, qry[2].Length - 7);
                mails.monday = qry[3].ToString().IndexOf("monday=") == -1 ? "0" : qry[3].Substring(qry[3].ToString().IndexOf("monday=") + 7, qry[3].Length - 7);
                mails.tuesday = qry[4].ToString().IndexOf("tuesday=") == -1 ? "0" : qry[4].Substring(qry[4].ToString().IndexOf("tuesday=") + 8, qry[4].Length - 8);
                mails.wednesday = qry[5].ToString().IndexOf("wednesday=") == -1 ? "0" : qry[5].Substring(qry[5].ToString().IndexOf("wednesday=") + 10, qry[5].Length - 10);
                mails.thursday = qry[6].ToString().IndexOf("thursday=") == -1 ? "0" : qry[6].Substring(qry[6].ToString().IndexOf("thursday=") + 9, qry[6].Length - 9);
                mails.friday = qry[7].ToString().IndexOf("friday=") == -1 ? "0" : qry[7].Substring(qry[7].ToString().IndexOf("friday=") + 7, qry[7].Length - 7);
                mails.morning = qry[8].ToString().IndexOf("morning=") == -1 ? "0" : qry[8].Substring(qry[8].ToString().IndexOf("morning=") + 8, qry[8].Length - 8);
                mails.afternoon = qry[9].ToString().IndexOf("afternoon=") == -1 ? "0" : qry[9].Substring(qry[9].ToString().IndexOf("afternoon=") + 10, qry[9].Length - 10);


                mails.evening = qry[10].ToString().IndexOf("evening=") == -1 ? "0" : qry[10].Substring(qry[10].ToString().IndexOf("evening=") + 8, qry[10].Length - 8);
                mails.subtype = qry[11].ToString().IndexOf("subtype=") == -1 ? "0" : qry[11].Substring(qry[11].ToString().IndexOf("subtype=") + 8, qry[11].Length - 8);
           
               // mails.ID = qry[0].ToString().IndexOf("id=") == -1 ? "0" : qry[0].Substring(qry[0].ToString().IndexOf("id=") + 3, qry[0].Length - 3);
                mails.email = qry[12].ToString().IndexOf("email=") == -1 ? "" : qry[12].Substring(qry[12].ToString().IndexOf("email=") + 6, qry[12].Length - 6);
                mails.reqemail = qry[13].ToString().IndexOf("reqemail=") == -1 ? "" : qry[13].Substring(qry[13].ToString().IndexOf("reqemail=") + 9, qry[13].Length - 9);


                mails.sunday = mails.sunday == "False" ? "0" : "1 ";
                mails.monday = mails.monday == "False" ? "0" : "1 ";
                mails.tuesday = mails.tuesday == "False" ? "0" : "1 ";
                mails.wednesday = mails.wednesday == "False" ? "0" : "1 ";
                mails.thursday = mails.thursday == "False" ? "0" : "1 ";
                mails.friday = mails.friday == "False" ? "0" : "1 ";

                mails.morning = mails.morning == "False" ? "0" : "1 ";
                mails.afternoon = mails.afternoon == "False" ? "0" : "1 ";
                mails.evening = mails.evening == "False" ? "0" : "1 ";


                if (mails.prm == "2")
                {
                    fillEmailList();
                }
                else { drplstEmil.Visible = false; }

               
                
                // drplstEmil.
            
            
            }
            return;
        }


     
       ////////////////// client.Send(entry);


       UpdateDonate();

    }






    protected void send_Email()
    {


      ///  HtmlTextArea txtmsg = (HtmlTextArea)this.FindControl("message");

        MailMessage entry = new MailMessage();
        string strEmailAddress = "";


        // strEmailAddress = Request.Form["Email"];
        strEmailAddress = mails.email; // Request.Form["Email"] != "" ? Request.Form["Email"] : Request.Form["Emailaddress"];

        string emailmsg = Request.Form["message"].ToString();

        //  string strRedirectTo =   (string) Request.RawUrl.ToString();   
        System.Text.StringBuilder Body = new System.Text.StringBuilder();

        entry.From = new MailAddress(mails.reqemail);

        entry.To.Add(strEmailAddress);
        entry.Body = emailmsg;// txtmsg.Value;// Body.ToString();



        entry.IsBodyHtml = true;
        entry.Priority = MailPriority.Normal;
        SmtpClient client = new SmtpClient();
        client.Host = "relay-hosting.secureserver.net";  //"127.0.0.1";

        client.Port = 25;
         client.Send(entry);



        string status = "emailed";
        string tel = "";
      string   prm = "e";

        string firstName = "";
        string lastName = "";
        string commandText = "setMatches";
        string avail_request = "available";
      //  int sts = r.setMatches(commandText, prm, mails.id, mails.morning, mails.afternoon, mails.evening,
      //mails.sunday, mails.monday, mails.tuesday, mails.wednesday, mails.thursday, mails.friday,
      //mails.subtype, avail_request, mails.email, firstName, lastName, tel, status);




    }





    protected void sendEmail(Object sender, EventArgs e)
    {
        UpdateDonate();
     
    }
    





































    






    protected void fillEmailList()
    {




        String id = mails.id;



        DataSet ds = new DataSet();
      
        string commandText = "getMatches";



        String email = ""; // (String)Request.Form["email"] == null ? Request.Form["email"].ToString() : Request.Form["email"].ToString();
       // String subtype =   ""; //            (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        //String firstName =                  (String)Request.Form["firstName"] == null ? Request.Form["First Name"].ToString() : Request.Form["firstName"].ToString();
        //String lastName = (String)Request.Form["lastName"] == null ? Request.Form["Last Name"].ToString() : Request.Form["lastName"].ToString();
        String tel = ""; //             (String)Request.Form["tel"] == null ? Request.Form["tel"].ToString() : Request.Form["tel"].ToString();





        String sunday = mails.sunday;//    ""; // (String)Request.Form["sunday"] == null ? "0" : "1";
        String monday = mails.monday;//  ""; // (String)Request.Form["monday"] == null ? "0" : "1"; // Request.Form["monday"].ToString() : Request.Form["monday"].ToString();
        String tuesday = mails.tuesday;// ""; // (String)Request.Form["tuesday"] == null ? "0" : "1";        //Request.Form["tuesday"].ToString() : Request.Form["tuesday"].ToString();
        String wednesday = mails.wednesday;// ""; // (String)Request.Form["wednesday"] == null ? "0" : "1"; //Request.Form["wednesday"].ToString() : Request.Form["wednesday"].ToString();
        String thursday = mails.thursday;// ""; // (String)Request.Form["thursday"] == null ? "0" : "1";  //Request.Form["thursday"].ToString() : Request.Form["thursday"].ToString();
        String friday = mails.friday;// ""; // (String)Request.Form["friday"] == null ? "0" : "1";  //Request.Form["friday"].ToString() : Request.Form["friday"].ToString();
        String morning = mails.morning;// ""; // (String)Request.Form["morning"] == null ? "0" : "1"; ///       Request.Form["morning"].ToString() : Request.Form["morning"].ToString();
        String afternoon = mails.afternoon;// ""; //  (String)Request.Form["afternoon"] == null ? "0" : "1"; // Request.Form["afternoon"].ToString() : Request.Form["afternoon"].ToString();
        String evening = mails.evening;// ""; // (String)Request.Form["evening"] == null ? "0" : "1";      // Request.Form["evening"].ToString() : Request.Form["evening"].ToString();
        String subType = mails.subtype;// ""; // (String)Request.Form["subType"] == null ? Request.Form["subType"].ToString() : Request.Form["subType"].ToString();

        String prm =   "5"    ;


        String avail_request = "available";// Request.Form["avail_request"];



 


         string   status = "";



         int ids = 0;

         ds = r.getOrgs(commandText,
                 prm,
                 ids,
              "",
              "",
              "",
          "",
          "",
          "",
          "",
          "",""

         );





            drplstEmil.DataSource = ds;

            drplstEmil.DataTextField = "email" ;
            drplstEmil.DataValueField = "email";
            drplstEmil.DataBind();



 

       
        

 

    }








































    protected void UpdateDonate()
    {




        String id = mails.id;



        DataSet ds = new DataSet();
      
        string commandText = "getMatches";



        String email = ""; // (String)Request.Form["email"] == null ? Request.Form["email"].ToString() : Request.Form["email"].ToString();
       // String subtype =   ""; //            (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
        //String firstName =                  (String)Request.Form["firstName"] == null ? Request.Form["First Name"].ToString() : Request.Form["firstName"].ToString();
        //String lastName = (String)Request.Form["lastName"] == null ? Request.Form["Last Name"].ToString() : Request.Form["lastName"].ToString();
        String tel = ""; //             (String)Request.Form["tel"] == null ? Request.Form["tel"].ToString() : Request.Form["tel"].ToString();





        String sunday = mails.sunday;//    ""; // (String)Request.Form["sunday"] == null ? "0" : "1";
        String monday = mails.monday;//  ""; // (String)Request.Form["monday"] == null ? "0" : "1"; // Request.Form["monday"].ToString() : Request.Form["monday"].ToString();
        String tuesday = mails.tuesday;// ""; // (String)Request.Form["tuesday"] == null ? "0" : "1";        //Request.Form["tuesday"].ToString() : Request.Form["tuesday"].ToString();
        String wednesday = mails.wednesday;// ""; // (String)Request.Form["wednesday"] == null ? "0" : "1"; //Request.Form["wednesday"].ToString() : Request.Form["wednesday"].ToString();
        String thursday = mails.thursday;// ""; // (String)Request.Form["thursday"] == null ? "0" : "1";  //Request.Form["thursday"].ToString() : Request.Form["thursday"].ToString();
        String friday = mails.friday;// ""; // (String)Request.Form["friday"] == null ? "0" : "1";  //Request.Form["friday"].ToString() : Request.Form["friday"].ToString();
        String morning = mails.morning;// ""; // (String)Request.Form["morning"] == null ? "0" : "1"; ///       Request.Form["morning"].ToString() : Request.Form["morning"].ToString();
        String afternoon = mails.afternoon;// ""; //  (String)Request.Form["afternoon"] == null ? "0" : "1"; // Request.Form["afternoon"].ToString() : Request.Form["afternoon"].ToString();
        String evening = mails.evening;// ""; // (String)Request.Form["evening"] == null ? "0" : "1";      // Request.Form["evening"].ToString() : Request.Form["evening"].ToString();
        String subType = mails.subtype;// ""; // (String)Request.Form["subType"] == null ? Request.Form["subType"].ToString() : Request.Form["subType"].ToString();

        String prm =   "4"    ;


        String avail_request = "available";// Request.Form["avail_request"];



     
        string  status = "emailed";


        if (mails.prm != "2" && mails.id!="")
        {
            mails.reqemail = "<ittybarb@gmails.com>";
            // mails.id = dr["id"].ToString();

            send_Email();



        }





        else
        {
            mails.reqemail =  drplstEmil.SelectedValue==String.Empty ?  "<ittybarb@gmails.com>" : drplstEmil.SelectedValue ;

            status = "";

            int ids = 0;

            ds = r.getOrgs(commandText,
                    prm,
                    ids,
                 "",
                 "",
                 "",
             "",
             "",
             "",
             "",
             "",""

            );













            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                mails.email = dr["email"].ToString();
                mails.id = dr["id"].ToString();

                send_Email();




            }

        }
        


        this.Response.ClearContent();
        this.Response.Write(@"<html>
<head>
<script type='text/javascript' language='javascript'>
<!--
top.close();
// -->
</script>
</head>
<body />
</html>");
        this.Response.End();

       /// Response.Redirect("Default.htm");

    }




}



 
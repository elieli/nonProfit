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




public partial class Donate : System.Web.UI.Page
{
    Referrer r = new Referrer();
    protected void Page_Load(object sender, EventArgs e)
    {

        CrediCardProscessing CardPro;

        int buyerid = messages.buyerID;
        string commandName = "get_Credits";
        string prm = "S";

      
        Decimal credits_ = r.get_Credits(commandName, prm, buyerid, 0);

        lblTotCredits.Text = credits_.ToString();

        HtmlInputText CreditsPrice = (HtmlInputText)this.FindControl("txtCreditsPrice");
        
        CreditsPrice.Value = String.Format("{0:c}", Convert.ToString(Convert.ToInt16(credits_) * .50));


      //  messages.credits = Convert.ToInt16(credits_);





        lblTotCredits.Text =   messages.credits.ToString();

         CreditsPrice.Value = String.Format("{0:c}", Convert.ToString( messages.credits   * .50));


    }



    protected void addCredits(object sender, EventArgs e)
    {



        int catid = 0;
        int orgid = messages.orgID;
        int buyerID = messages.buyerID;
        int credits_ = 0;
        DataSet ds = new DataSet();

        string prm = "A";
        string commandName = ""; Decimal amount = 0;

        int buyerid = messages.buyerID;
        commandName = "get_Donations";
       
        HtmlInputText txtCredits = (HtmlInputText)this.FindControl("txtCredits");

        Decimal credits =   txtCredits.Value.ToString().Trim()=="" ? 0 :  Convert.ToDecimal(txtCredits.Value.ToString());



        credits_ = Convert.ToInt16(credits);






        amount = donateAmount.Text.Trim() == "" ? 0 : Convert.ToDecimal(donateAmount.Text);






        Decimal gd = r.get_Donations(commandName, prm, orgid, buyerID, amount, credits_);






        lblTotCredits.Text =   messages.credits.ToString();





        HtmlInputText  CreditsPrice = (HtmlInputText)this.FindControl("txtCreditsPrice");
        


     //    credits = ((Button)sender).CommandName.ToString() == "rtrnCredits" ? credits * -1 : credits;




          
       ///    r.get_Credits(commandName, prm, buyerid, credits);
        
        
        
        
        prm = "S";
 ////   Decimal credits_ =    r.get_Credits( commandName,   prm, buyerid ,    credits     ) ;

    lblTotCredits.Text = credits_.ToString();

     CreditsPrice.Value = String.Format("{0:c}",  Convert.ToString(Convert.ToInt16(credits_) * .50));


        ///messages.credits=   Convert.ToInt16( credits_) ;

}




    //int catid = 0;
    //int orgid = messages.orgID;
    //int buyerID = messages.buyerID;
    //int credits = 0;
    //DataSet ds = new DataSet();

    //string prm = "T";
    //string commandName = ""; Decimal amount = 0;

    //Decimal gd = r.get_Donations(commandName, prm, orgID, buyerID, amount, credits);




     







}

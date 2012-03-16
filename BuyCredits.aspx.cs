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

public partial class BuyCredits : System.Web.UI.Page
{
    Referrer r = new Referrer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (custs().ID == 0) { return; }





        for (int x = 2012 ; x<2020; x++)
        {   cmbCardExpYear.Items.Add(x.ToString());
        }
      



        int buyerid = custs().buyerID;
        string commandName = "get_Credits";
        string prm = "S";


        //Decimal credits_ = r.get_Credits(commandName, prm, buyerid, 0);



        int credits_ = items().Credits;






        int credit = credits_;// Convert.ToInt16(Convert.ToString(credits_));

        /////lblTotCredits.Text = credits_.ToString();

        HtmlInputText CreditsPrice = (HtmlInputText)this.FindControl("txtCreditsPrice");

        //CreditsPrice.Value = String.Format("{0:c}", Convert.ToString(Convert.ToInt16(credits_) * .50));


        CreditsPrice.Value = String.Format("{0:c}", credit * .60);

        //  messages.credits = Convert.ToInt16(credits_);





        ///lblTotCredits.Text = messages.credits.ToString();

        CreditsPrice.Value = String.Format("{0:c}", Convert.ToString(messages.credits * .60));


    }



    protected void addCredits(object sender, EventArgs e)
    {
        ///lbltotcredits.Text = messages.credits.ToString();



        try
        {

            HtmlInputText CreditsPrice = (HtmlInputText)this.FindControl("txtCreditsPrice");


            HtmlInputText txtCredits = (HtmlInputText)this.FindControl("txtCredits");

            int buyerid = custs().ID;// messages.buyerID;
            string commandName = "get_Credits";
            string prm = "A";
            int credits = Convert.ToInt16(txtCredits.Value.ToString());


            credits = ((Button)sender).CommandName.ToString() == "rtrnCredits" ? credits * -1 : credits;



            CrediCardProscessing(credits);





            //////////r.get_Credits(commandName, prm, buyerid, credits);

            custs().CreDits = credits;



            //    prm = "S";
            //Decimal credits_ =    r.get_Credits( commandName,   prm, buyerid ,    credits     ) ;
            //credits = Convert.ToInt16(credits_);

            credits = items().Credits;

            //////lbltotcredits.Text = credits.ToString();

            CreditsPrice.Value = String.Format("{0:c}", Convert.ToString(Convert.ToInt16(credits) * .50));


            ///messages.credits=   Convert.ToInt16( credits_) ;
        }

        catch(Exception) { }
    }




    protected void CrediCardProscessing(int credits)
    {
        Decimal tot = Convert.ToDecimal(credits * .60);

        string dblDonationAmount = tot.ToString();
        lblmsg.Text = "";


        CrediCardProscessing CardPro = new CrediCardProscessing();
        CardPro.FirstName = "Eli";// this.tbFirstName.Text;
        CardPro.LastName = "Barber";// this.tbLastName.Text;
        CardPro.Address = "672 Crown St.";//this.tbAddress.Text;
        CardPro.City = "Bklyn";//txtbCity.Text;
        CardPro.State = "NY";// txtbState.Text;
        CardPro.ZIP = "11213";// this.tbPostalCode.Text;
        CardPro.Country = "US";//this.ddlCountry.SelectedValue;
        CardPro.CardNumber = this.txtCardNumber.Text;
        CardPro.Expiration = this.cmbCardExpMonth.SelectedValue + "/" + this.cmbCardExpYear.SelectedValue;
        CardPro.CVV = this.txtCardCVV2.Text;
        CardPro.CustomerIP = Request.UserHostAddress;


        Trace.Write("Amount", dblDonationAmount);

        CardPro.Amount = Double.Parse(dblDonationAmount, System.Globalization.NumberStyles.Currency);
        bool ProsPassed = CardPro.SubmitPayment("Donation to Friendshipcircle");
        lblmsg.Text =  CardPro.ErrorMessage;
        if (ProsPassed)
        {
            string bodytext = "Proscess Result Information\n--------------\n" +
                  "Authorization Code: " + CardPro.AuthorizationCode + "\n" +
                  "Transaction ID: " + CardPro.TransactionID + "\n";
            string ltrlResults = "<div style=\"color:#1C405E;\">You Have Successfully Donated to The Friendship " +
                 "Circle<br/>Authorization Code: " + CardPro.AuthorizationCode +
                 "<br/>Transaction ID: " + CardPro.TransactionID + @"<h2>Thank You</h2>Thank you for your support in assisting the Friendship Circle to continue supporting children with special needs, giving them and volunteers alike, a meaningful experience at our Ferber-Kaufman LifeTown at the Meer Family Friendship Center.  

 <div style=""font-size:smaller;"">Your contribution towards the Friendship Circle is tax deductible. 

Please print this page for your tax deductible receipt. 
</div></div>";



        }


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
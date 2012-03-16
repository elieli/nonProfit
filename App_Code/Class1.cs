using System;
using System.Data;
using System.Configuration;
 
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
 
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

 

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Class1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
public class PrgFunctions
{
    public PrgFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}


public class ProductDetails 
{
    public ProductDetails(Guid ff)
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public class CrediCardProscessing
{



    public CrediCardProscessing()
    {
        isLive =   true;
    }

    private TransactionMode currTranType = TransactionMode.AUTH_CAPTURE;

    /// <summary>
    /// The Current Transaction Mode
    /// </summary>
    /// <value>AUTH_CAPTURE</value>
    public TransactionMode CurrentTransactionMode
    {
        set { currTranType = value; }
        get { return currTranType; }
    }

    //private LineItemCollection LineItems = new LineItemCollection();

    //public LineItemCollection Items
    //{
    //    get { return LineItems; }
    //}

    /// <summary>
    /// Constructor For CC Prossecing
    /// </summary>
    /// <param name="Live">True for live transactions</param>
    public CrediCardProscessing(bool Live)
    {
        isLive = Live;
    }
    private string m_honor;

    public string honor
    {
        get { return m_honor; }
        set { m_honor = value; }
    }





    private string strAuthorCode;

    public string AuthorizationCode
    {
        get { return strAuthorCode; }
    }
    private string strTransactionID = string.Empty;

    /// <summary>
    /// Transaction ID Needs to be set for dealing with prev. Transactions
    /// </summary>
    public string TransactionID
    {
        get { return strTransactionID; }
        set { strTransactionID = value; }
    }
    private bool isLive = true;
    private string ErrMessage;
    //private string AuthNetLoginID = "62HBr9nV9P";
    //private string AuthNetPassword = "9tN538768Mku2S5W";
    //private string AuthNetTransKey = "9tN538768Mku2S5W";

    //private string AuthNetLoginID = "5jZ8xTff8X";
    //private string AuthNetPassword = "9N6Fx6N36kqzA5KK";
    //private string AuthNetTransKey = "9N6Fx6N36kqzA5KK";

    private string AuthNetLoginID = "5f8Mq8EhYQa";
    private string AuthNetPassword = "5H5nYE868a66Fuhg";
    private string AuthNetTransKey = "5H5nYE868a66Fuhg";
    /// <summary>
    /// Error Message if any
    /// </summary>
    public string ErrorMessage
    {
        get { return ErrMessage; }
    }

    private string strFirstName;

    /// <summary>
    /// Get or Set Payer's First Name
    /// </summary>    
    public string FirstName
    {
        get { return strFirstName; }
        set { strFirstName = value; }
    }
    private string strLastName;

    /// <summary>
    /// Get or Set Payer's Last Name
    /// </summary>
    public string LastName
    {
        get { return strLastName; }
        set { strLastName = value; }
    }
    private string strAddress;

    /// <summary>
    /// Get or Set Payer's Address
    /// </summary>
    public string Address
    {
        get { return strAddress; }
        set { strAddress = value; }
    }
    private string strCity;

    /// <summary>
    /// Get or Set Payer's City
    /// </summary>
    public string City
    {
        get { return strCity; }
        set { strCity = value; }
    }
    private string strState;

    /// <summary>
    /// Get or Set Payer's City
    /// </summary>
    public string State
    {
        get { return strState; }
        set { strState = value; }
    }
    private string strZIP;

    /// <summary>
    /// Get or Set Payer's Zip Code or Provincial Code
    /// </summary>
    public string ZIP
    {
        get { return strZIP; }
        set { strZIP = value; }
    }
    private string strCountry;


    /// <summary>
    /// Get or Set Payer's Country
    /// </summary>
    public string Country
    {
        get { return strCountry; }
        set { strCountry = value; }
    }
    private double dblAmount;

    /// <summary>
    /// Get or Set Transaction Amount
    /// </summary>
    public double Amount
    {
        get { return dblAmount; }
        set { dblAmount = value; }
    }

   
    private string strCardNumber;

    /// <summary>
    /// Get or Set Credit Card Number
    /// </summary>
    public string CardNumber
    {
        get { return strCardNumber; }
        set { strCardNumber = value.Replace(" ", "").Replace("-", "").Trim(); }
    }
    private string strExpiration;

    /// <summary>
    /// Get or Set Credit Card Expiration Date
    /// </summary>
    /// <example>MMYY or MM/YY or MM-YY or MMYYYY etc.</example>
    public string Expiration
    {
        get { return strExpiration; }
        set { strExpiration = value; }
    }
    private string strCVV;

    /// <summary>
    /// Get or Set CVV2 or CVC2 or CID
    /// </summary>
    public string CVV
    {
        get { return strCVV; }
        set { strCVV = value.Trim(); }
    }

    private string strCutomerIP = string.Empty;

    /// <summary>
    /// Get or Set Customer IP Address
    /// </summary>
    /// <exception cref="System.FormatException">Thrown when not a valid IP</exception>
    public string CustomerIP
    {
        set
        {
            // IPAddress.Parse(value);
            strCutomerIP = value;
        }
        get { return strCutomerIP; }
    }

    private string strPurchaseOrder;

    public string PurchaseOrder
    {
        get { return strPurchaseOrder; }
        set { strPurchaseOrder = value; }
    }

    private decimal? dcTax = null;


    public decimal? Tax
    {
        set { dcTax = value; }
        get { return dcTax; }
    }

    private decimal? dcFrieght = null;

    public decimal? Frieght
    {
        set { dcFrieght = value; }
        get { return dcFrieght; }
    }
    /// <summary>
    /// Submit Payment to be prosseced
    /// </summary>
    /// <param name="Description">The tranaction description</param>
    /// <returns>true if Successful</returns>
    public bool SubmitPayment(string Description)
    {




        return AuthorizePayment(strFirstName, strLastName, strAddress, strCity, strState, strZIP,
           strCountry, dblAmount, strCardNumber, strExpiration, strCVV, Description);
    }

    /// <summary>
    /// Submit Payment to be prosseced
    /// </summary>
    /// <returns>true if Successful</returns>
    public bool SubmitPayment()
    {
        return AuthorizePayment(strFirstName, strLastName, strAddress, strCity, strState, strZIP,
            strCountry, dblAmount, strCardNumber, strExpiration, strCVV, string.Empty);
    }
    private bool AuthorizePayment(string FirstName, string LastName, string Address,
        string City, string State, string ZIP, string Country, double Amount, string CardNumber,
        string Expiration, string CVV, string Description)
    {


        //   CreditCardProcessing_(FirstName,  LastName, Address,
        // City,  State, ZIP,Country,  Amount, CardNumber,
        //Expiration,  CVV,  Description);






        string AuthNetVersion = "3.1"; // Contains CCV support        
        // Get this from your authorize.net merchant interface        

        System.Net.WebClient objRequest = new System.Net.WebClient();
        System.Collections.Specialized.NameValueCollection objInf =
          new System.Collections.Specialized.NameValueCollection(30);
        System.Collections.Specialized.NameValueCollection objRetInf =
          new System.Collections.Specialized.NameValueCollection(30);
        byte[] objRetBytes;
        string[] objRetVals;
        string strError;

        objInf.Add("x_version", AuthNetVersion);
        objInf.Add("x_delim_data", "True");
        objInf.Add("x_login", AuthNetLoginID);
        objInf.Add("x_password", AuthNetPassword);
        objInf.Add("x_tran_key", AuthNetTransKey);
        objInf.Add("x_relay_response", "False");

        //TranactionID
        if (strTransactionID.Length > 0)
            objInf.Add("x_trans_id", strTransactionID);

        // Switch this to False once you go live
        objInf.Add("x_test_request", Convert.ToString(!isLive));

        objInf.Add("x_delim_char", ",");
        objInf.Add("x_encap_char", "|");

        // Billing Address
        objInf.Add("x_first_name", FirstName);
        objInf.Add("x_last_name", LastName);
        objInf.Add("x_address", Address);
        objInf.Add("x_city", City);
        objInf.Add("x_state", State);
        objInf.Add("x_zip", ZIP);
        objInf.Add("x_country", Country);

        if (Description.Length > 0)
            objInf.Add("x_description", Description);

        // Card Details
        objInf.Add("x_card_num", CardNumber);
        objInf.Add("x_exp_date", Expiration);

        // Authorisation code of the card (CCV)
        objInf.Add("x_card_code", CVV);

        objInf.Add("x_method", "CC");
        objInf.Add("x_type", Enum.GetName(typeof(TransactionMode), currTranType));
        objInf.Add("x_amount", Amount.ToString());

        //not required
        if (strCutomerIP.Length > 0)
        {
            objInf.Add("x_customer_ip", strCutomerIP);
        }

        ////////if (Linedsitems.Count > 0)
        ////////{
        ////////    foreach (LineItem Item in LineItems)
        ////////    {
        ////////        objInf.Add("x_line_item", Item.ToString());
        ////////    }
        ////////}
        // Currency setting. Check the guide for other supported currencies
        objInf.Add("x_currency_code", "USD");

        //try
        //{
        if (!isLive)
        {
            // Pure Test Server
           //// objRequest.BaseAddress = "https://www.eProcessingNetwork.Com/cgi-bin/tdbe/transact.pl";
           objRequest.BaseAddress = "https://certification.authorize.net/gateway/transact.dll";
        //  objRequest.BaseAddress = "https://test.authorize.net/gateway/transact.dll";
        }
        else
        {
            // Actual Server       4111111111111111
            //(uncomment the following line and also set above Testmode=off to go live)
            objRequest.BaseAddress = "https://www.eProcessingNetwork.Com/cgi-bin/tdbe/transact.pl";
            objRequest.BaseAddress = "https://secure.authorize.net/gateway/transact.dll";
        }
        objRetBytes =
          objRequest.UploadValues(objRequest.BaseAddress, "POST", objInf);
        objRetVals =
          System.Text.Encoding.ASCII.GetString(objRetBytes).Split(",".ToCharArray());

        if (objRetVals[0].Trim(char.Parse("|")) == "1")
        {
            // Returned Authorisation Code
            this.strAuthorCode = objRetVals[4].Trim(char.Parse("|"));
            // Returned Transaction ID
            this.strTransactionID = objRetVals[6].Trim(char.Parse("|"));

            return true;
        }
        else
        {
            // Error!
            strError = objRetVals[3].Trim(char.Parse("|")) + " (" +
              objRetVals[2].Trim(char.Parse("|")) + ")";

            if (objRetVals[2].Trim(char.Parse("|")) == "44")
            {
                // CCV transaction decline
                strError += "Our Card Code Verification (CCV) returned " +
                  "the following error: ";

                switch (objRetVals[38].Trim(char.Parse("|")))
                {
                    case "N":
                        strError += "Card Code does not match.";
                        break;
                    case "P":
                        strError += "Card Code was not processed.";
                        break;
                    case "S":
                        strError += "Card Code should be on card but was not indicated.";
                        break;
                    case "U":
                        strError += "Issuer was not certified for Card Code.";
                        break;
                }
            }

            if (objRetVals[2].Trim(char.Parse("|")) == "45")
            {
                if (strError.Length > 1)
                    strError += "<br />n";

                // AVS transaction decline
                strError += "Our Address Verification System (AVS) " +
                  "returned the following error: ";

                switch (objRetVals[5].Trim(char.Parse("|")))
                {
                    case "A":
                        strError += " the zip code entered does not match " +
                          "the billing address.";
                        break;
                    case "B":
                        strError += " no information was provided for the AVS check.";
                        break;
                    case "E":
                        strError += " a general error occurred in the AVS system.";
                        break;
                    case "G":
                        strError += " the credit card was issued by a non-US bank.";
                        break;
                    case "N":
                        strError += " neither the entered street address nor zip " +
                          "code matches the billing address.";
                        break;
                    case "P":
                        strError += " AVS is not applicable for this transaction.";
                        break;
                    case "R":
                        strError += " please retry the transaction; the AVS system " +
                          "was unavailable or timed out.";
                        break;
                    case "S":
                        strError += " the AVS service is not supported by your " +
                          "credit card issuer.";
                        break;
                    case "U":
                        strError += " address information is unavailable for the " +
                          "credit card.";
                        break;
                    case "W":
                        strError += " the 9 digit zip code matches, but the " +
                          "street address does not.";
                        break;
                    case "Z":
                        strError += " the zip code matches, but the address does not.";
                        break;
                }
            }

            // strError contains the actual error
            ErrMessage = strError;





            return false;
        }
        //catch (Exception ex)
        //}
        //{
        //    ErrMessage = ex.Message;
        //    throw ex;
        //}

    }













    public enum TransactionMode
    {
        /// <summary>
        /// Authorize and finalize transaction
        /// </summary>
        AUTH_CAPTURE,
        /// <summary>
        /// Only Authorize but do not proscess
        /// </summary>
        AUTH_ONLY,
        /// <summary>
        /// Capture without authorization
        /// </summary>
        CAPTURE_ONLY,
        /// <summary>
        /// Refund
        /// </summary>
        CREDIT,
        /// <summary>
        /// Cancel
        /// </summary>
        VOID,
        /// <summary>
        /// Prossescs Previuosly Captured
        /// </summary>
        PRIOR_AUTH_CAPTURE
    }


    public class LineItem
    {
        private string ItemID;
        private string ItemName;
        private string ItemDescription;
        private int ItemQuantity;
        private decimal ItemPrice;
        private bool ItemTaxable;

        /// <summary>
        /// Default Cunstructor
        /// </summary>
        public LineItem() { }

        /// <summary>
        /// Initilization Constructor
        /// </summary>
        /// <param name="ID">Product ID</param>
        /// <param name="Name">Product Name</param>
        /// <param name="Description">Product Desctiption</param>
        /// <param name="Quantity">Quantity</param>
        /// <param name="Price">Price</param>
        /// <param name="Taxable">Is Taxable</param>
        public LineItem(string ID, string Name, string Description, int Quantity,
            decimal Price, bool Taxable)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.Price = Price;
            this.Taxable = Taxable;
        }
        /// <summary>
        /// Item ID
        /// </summary>
        public string ID
        {
            set
            {
                if (value.Length <= 31)
                    ItemID = value;
                else
                    throw new ArgumentOutOfRangeException("ItemID", "ItemID is only allowed to be 31 Characters.");
            }
            get { return ItemID; }
        }

        /// <summary>
        /// Item Name
        /// </summary>
        public string Name
        {
            set
            {
                if (value.Length <= 31)
                    ItemName = value;
                else
                    throw new ArgumentOutOfRangeException("ItemName", "ItemName is only allowed to be 31 Characters.");
            }
            get { return ItemName; }
        }

        /// <summary>
        /// Item Description
        /// </summary>
        public string Description
        {
            set
            {
                if (value.Length <= 255)
                    ItemDescription = value;
                else
                    throw new ArgumentOutOfRangeException("Item Description", "Item Description Can only be 255 characters long");
            }
            get { return ItemDescription; }
        }

        /// <summary>
        /// Item Quantity
        /// </summary>
        public int Quantity
        {
            set { ItemQuantity = value; }
            get { return ItemQuantity; }
        }


        /// <summary>
        /// Item Price excluding tax, frieght and duty
        /// </summary>
        public decimal Price
        {
            set { ItemPrice = value; }
            get { return ItemPrice; }
        }

        /// <summary>
        /// Is item taxable
        /// </summary>
        public bool Taxable
        {
            set { ItemTaxable = value; }
            get { return ItemTaxable; }
        }

        public override string ToString()
        {
            string Tax = (ItemTaxable ? "YES" : "NO");
            string RetVal = string.Format("{0}<|>{1}<|>{2}<|>{3}<|>{4:.00}<|>{5}",
                ItemID, ItemName, ItemDescription, ItemQuantity, ItemPrice, Tax);

            return RetVal;
        }
    }

    //public class LineItemCollection : List<LineItem>

    //public class LineItemCollection : List<LineItem>
    //{
    //    public void Add(LineItem Item)
    //    {
    //        //if (base.Count < 30)
    //        //    base.Add(Item);
    //        //else
    //        //    throw new OverflowException("Can Only have 30 Line Items");
    //    }

    //public void AddNewLineItem(string ID, string Name, string Description, int Quantity,
    //    decimal Price, bool Taxable)
    //{
    //    LineItem Item = new LineItem(ID, Name, Description, Quantity, Price, Taxable);
    //     Add(Item);
    //}
    //}
}









class Program
{
    static void Main()
    {
        // Read all bytes in from a file on the disk.
        byte[] file = File.ReadAllBytes("C:\\ICON1.png");

        // Create a memory stream from those bytes.
        using (MemoryStream memory = new MemoryStream(file))
        {
            // Use the memory stream in a binary reader.
            using (BinaryReader reader = new BinaryReader(memory))
            {
                // Read in each byte from memory.
                for (int i = 0; i < file.Length; i++)
                {
                    byte result = reader.ReadByte();
                    Console.WriteLine(result);
                }
            }
        }
    }
}


static public class pagestatus  
{


    static private int Page;

    static private int Row;

    static private String Dir;


    static public int page
    {
        get { return Page; }
        set { Page = value; }
    }
    static public int row
    {
        get { return Row; }
        set { Row = value; }
    }
    static public String dir
    {
        get { return Dir; }
        set { Dir = value; }
    }
}

public  class arrays
{
     public System.Collections.ArrayList arll;















     CrediCardProscessing CardPro;



     public bool ProccessCreditCard()
     {





         CardPro = new CrediCardProscessing();

         string param = "";





         CardPro.FirstName = messages.firstname;// Request.Form["FirstName"];
         CardPro.LastName = messages.lastname;// Request.Form["LastName"];
         CardPro.Address = messages.address;// Request.Form["Address"];
         CardPro.City = messages.city;//  Request.Form["City"];
         CardPro.State = messages.state;// Request.Form["State"];
         CardPro.ZIP = messages.zipcode;// Request.Form["zipcode"];
         CardPro.Country = "USA";// Request.Form["FirstName"];
         CardPro.CardNumber = messages.cardnumber;// Request.Form["CardNumber"];
         CardPro.Expiration = messages.expdate;// Request.Form["expdate"];

         // CardPro.Expiration = this.ddlMonth.SelectedValue + "/" + this.ddlYear.SelectedValue;
         CardPro.CVV = messages.cvv;
         CardPro.CustomerIP = messages.CustomerIP;           /// Request.UserHostAddress;
         // Trace.Write("Amount", Request.Form["FirstName"]);

         //   CardPro.Amount = Double.Parse(Request.Form["amount"], System.Globalization.NumberStyles.Currency);
         CardPro.Amount = Double.Parse(messages.amount , System.Globalization.NumberStyles.Currency);

         Boolean ProsPassed = CardPro.SubmitPayment("Donation to Chabad");

         if (CardPro.ErrorMessage != null)
         {
             if (CardPro.ErrorMessage.Substring(0, CardPro.ErrorMessage.LastIndexOf("(")) == "There was a problem with the transactionA valid amount is required.")
             {
                 messages.err = CardPro.ErrorMessage;


                 messages.script = "<script type='text/javascript' language='javascript'>show('" + param + "','" + messages.amount + "' );</script>";



                 ///  ((HtmlContainerControl)this.FindControl("dvmsg")).InnerText = CardPro.ErrorMessage.ToString();



                 //   dvmsg.vat = CardPro.ErrorMessage.ToString();



                 ProsPassed = false;
                 //CardPro.ErrorMessage = "";

             }

             if (ProsPassed == false)
             {
                 messages.err = CardPro.ErrorMessage;

                 //script = "<script type='text/javascript' language='javascript'>show('" +  param + "','" +  amount_ + "' );</script>";


                 //lrt.Text = script;
             }



           //  TableDonate.Attributes.Add("onload", "show('" + param + "','" + amount_ + "' )");
             else
             {
                 messages.err = messages.firstname + " " + messages.lastname + " Thank you for your kind donation of " + messages.amount + " " + messages.honor + " for sponsoring our pesach Seder";
             }

         }

         else
         {
             messages.err = messages.firstname + " " + messages.lastname + " Thank you for your kind donation of " + messages.amount + " " + messages.honor + " for sponsoring our pesach Seder";
         }

         messages.pro = ProsPassed;
        // messages.err = ErrorMessage;

       //  messages.script = script;

         return ProsPassed;



     }








     public void Mail_Load()
     {

         System.Net.Mail.MailMessage entry = new System.Net.Mail.MailMessage();

         System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(); 

        
         string strEmailAddress = "";









         // strEmailAddress = Request.Form["Email"];
         strEmailAddress = messages.email; // Request.Form["Email"] != "" ? Request.Form["Email"] : Request.Form["Emailaddress"];


         //  string strRedirectTo =   (string) Request.RawUrl.ToString();   
         System.Text.StringBuilder Body = new System.Text.StringBuilder();

         entry.From = new System.Net.Mail.MailAddress("Chabad <info@systemoriginals.com>");

         entry.To.Add(strEmailAddress);





         entry.Subject = "Thank you for your kind donation!";















         // Body.AppendLine("<table>");

         //  for (int i = 0; i < Request.Form.Count; i++)
         //  {
         //      if (Request.Form[i] != "Submit" && Request.Form.Keys[i] != "CCType" && Request.Form.Keys[i] != "CCDNum" && Request.Form.Keys[i] != "CVV" && Request.Form.Keys[i] != "cardnumber" && Request.Form.Keys[i] != "cardnumber" && Request.Form.Keys[i] != "cardtype" && Request.Form.Keys[i] != "expiration" && Request.Form.Keys[i] != "expiration" && Request.Form.Keys[i] != "__EVENTVALIDATION" && Request.Form.Keys[i] != "__VIEWSTATE"    && Request.Form.Keys[i] != "expdate"   && Request.Form.Keys[i] != "cvv"    && Request.Form.Keys[i] != "hdninput"  )
         //      {
         //
         //
         //          Body.AppendLine(" <tr><td> <em>" + Request.Form.Keys[i] + "</em>" + "\t" + "   : </td><td align='left'> <b>" + Request.Form[i] + "</b> </br> </td></tr>");

         //
         //      }
         // }
         // Body.AppendLine("<em><b> Thank you for your kind and heartfelt gift, our appreciation goes beyond words! </b></em>");
         //  Body.AppendLine("</table>");



         Body.AppendLine("<br /><em><b>  Hi " + messages.firstname + " " + messages.lastname + ", </b></em> ");

         Body.AppendLine("<br /><br /><em><b>  Thanks for your kind donation of  $" + messages.amount + " " + messages.honor + "  helping Chabad continue its mission,</b></em> ");

         Body.AppendLine("<br /><em><b>  thus becoming a partner in spreading the light and warmth of judiasm to all our brothers and sisters.<b><em> ");

         Body.AppendLine("<br /><br /><em><b> Have A Happy Passover</b> </em>  ");
         Body.AppendLine("<br /><br /><em><b>   Best regards, </b></em>  ");

         Body.AppendLine("<br /><br /> <em><b>   The Chabad Staff </b></em>  ");



         entry.Body = Body.ToString();



         entry.IsBodyHtml = true;
         entry.Priority = System.Net.Mail.MailPriority.Normal;
        // System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
         //client.Host = "127.0.0.1";
         client.Host = "relay-hosting.secureserver.net";  //"127.0.0.1";

         client.Port = 25;
         //    client.Send(entry);







         ///    entry.From = new MailAddress(email_);

         entry.To.Clear();

         entry.To.Add("Eli Barber   <elibrb@gmail.com>");

         Body.AppendLine("<br /><em><b>        Address:    " + messages.address + ", </b></em>  ");
         Body.AppendLine("<br /><em><b>      City:    " + messages.city + ",</b> </em>  ");
         Body.AppendLine("<br /><em><b>    State: +" + messages.state + ", </b></em>  ");
         Body.AppendLine("<br /><em><b>    Zipcode: +   " + messages.zipcode + ", </b></em>  ");
         Body.AppendLine("<br /><em><b>     Phone: +  " + messages.phone + ", </b></em>  ");
         Body.AppendLine("<br /><em><b>      Email: +" + messages.email + ",</b> </em> ");




         entry.Body = Body.ToString();





         //    client.Send(entry);














     }













}







public class messageshld
{

      private BLCustomer m_custhld;
      public BLCustomer custhld
    {
        get
        {
            if (m_custhld == null)
            { return m_custhld = new BLCustomer(0); }

            else
            { return m_custhld; }

        }
        set
        { m_custhld = value; }// new BLCustomer(); }

    }



}













public  class events
{

   public event EventHandler navigate;

}

















public class Singleton
{
    private BLCustomer customer;

    static Singleton instance = null;
    static readonly object padlock = new object();

    Singleton()
    {
    
    }



    public static Singleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }



    }







    public BLCustomer Customer
    {
        get
        {
           


            return customer;
        }
        set
        {
            customer = value;
        }

    }












}

























public static class messages
{
    
    static private BLOrganization m_org;
    static public int bidlevel;
    static public String orgLogo;
    static public Boolean  orgall ;
    static public Referrer r ;
    static public int rowLimit;
   static private BLCustomer m_cust ;

   static public event EventHandler navigate;


   //public delegate void navigate(object sender, EventArgs e);



    static public int[] m_bidPennySec = new int[30];

    static public int[] m_bidPennySecRepeat = new int[30];

    static private int m_bSec;
    static private int  m_bidSec;
    static private int m_bidSecRepeat;










    static public void raise(object sender, EventArgs e)
    {
        navigate( sender,   e);

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    static private DataList m_datalist;






    static public DataList  datalist
    {
        get { return m_datalist; }
        set {m_datalist=value; }
    }



    static private int m_credits;
    static public int credits 


            //[get_credits]@opt varchar(1), 	 
            //@buyerID  INT , 
            // @Credits int
  
  
    {
        get
        {string commandName = "get_Credits";
            string prm="E";
           int  buyerID=messages.cust.ID;
            Decimal crd = 0;

             r = new Referrer();

            crd = r.get_Credits(commandName, prm, buyerID,0 );

              m_credits =    Convert.ToInt16(Convert.ToString(  crd))  ;
            
            return m_credits ;
        }

        set { m_credits = value; }
    }

    
    
    static private int m_cartcount;


    



    //static public int cartcount
    //{
    //    get{


    //        int catid = 0; 
    //        int orgid = messages.orgID;

    //        DataSet ds = new DataSet();

    //        ds = UpdateDonate("C", "get_Items", 0, catid, orgid, "");

    //           m_cartcount=  ds.Tables[0].Rows.Count;





    //        return  m_cartcount;


    //    }

        

    //}



    
    
    static private int m_donatecount;






    
    static public int donatecount
    {
        get{


           
            int orgid = messages.orgID;
            int buyerID = messages.buyerID; 
             int credits=0;
            DataSet ds = new DataSet();

             string prm="T";
            string commandName="get_Donations";Decimal amount=0;

            Decimal gd = r.get_Donations(commandName, prm, orgid, buyerID, amount, credits);


      

           
               m_cartcount= Convert.ToInt16(gd);





            return  m_cartcount;


        }

        

    }




















    static public BLItem blitem 
    {
        get { return cust.Organization.Orgitems.Item; }
    }




    static public DataTable DataTable; 




    static public DataView dvorgProducts;







    static public  BLOrganization orgs_
    {
        get
        {



            ////if (m_cust == null)
            ////{
            ////   ///////////// initCustomer(0);

            ////}
            return cust.Organization ;

        }


    }


    static public BLItems items_
    {
        get
        {
           

             
            //////if (m_cust == null)
            //////{
            //////    initCustomer(0);

            //////}
            return cust.Organization.Orgitems;

        }
       

    }










       

   















    static public BLCustomer cust 
    { 
        get
        {
 
            //if (m_cust == null)
            //{ return cust =  new BLCustomer(); }
        
            //else

            //if (m_cust == null)

            //{
            //    initCustomer();

            //}
                 
           

         //try
         //   {

    return     (  BLCustomer)   Singleton.Instance.Customer;
             

                


           // }

           ////catch {
           // return cust = new BLCustomer(0);
           //}


             // return m_cust ; 

            }
         set 
         {

             //try
             //{
             Singleton.Instance.Customer = value;

           

             //}

             //catch
             //{





             //    try
             //    {
             //        HttpContext.Current.Session["nonProfit"] = new BLCustomer(0);


             //    }

             //    catch
             //    {
                      

             //    }





          



              
                 
             }
             // m_cust = value;

       ///  }// new BLCustomer(); }
    
    }














    //static public BLOrganization org
    //{
    //    get
    //    {
    //        if (m_org == null)
    //        { return org = new BLOrganization(); }

    //        else
    //        { return m_org; }

    //    }
    //    set
    //    { m_org = value; }// new BLCustomer(); }

    //}













  //  static public DataSet getOrgs(String parm, string commandtext, int id, string status)
  //  {



  //      String orgEmail = ""; // ((HtmlInputControl)this.FindControl("orgEmail")).Value;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
  //      // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
  //      String orgTitle = ""; //  ((HtmlInputControl)this.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();
  //      String orgFunct = ""; //  ((HtmlInputControl)this.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
  //      String orgDesc = ""; // ((HtmlInputControl)this.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
  //      String orgTaxID = ""; //  ((HtmlInputControl)this.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

  //      String orgPaypal = ""; //  ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

  //      String orgLogo = ""; //  ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();

  //      // String buttonLogo = ""; //  ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

  //      String orgStatus = status;// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();


 
  //      orgStatus = status;// drplstEmailSts.SelectedValue.ToString();

  //      String prm = parm;



  //      status = "";

  //      DataSet ds = new DataSet();
  //      //if (prm!="2")  status = drplstEmailSts.SelectedValue=="All" ? String.Empty : drplstEmailSts.SelectedValue  ;
  //      //if (prm == "8") prm = "2";
  //      string commandText = commandtext;// "get_Orgs";



  //      if (prm == "S")
  //      {
  //          //orgStatus = ""; //drplstEmailSts.SelectedValue.ToString();
  //          ds = r.getOrgs(commandText,
  //       prm,
  //       id,
  //    orgTitle,
  //    orgFunct,
  //    orgDesc,
  //orgTaxID,
  //orgEmail,
  //orgPaypal,
  //orgLogo,
  //orgStatus,"");

  //      }

  //      return ds;
  //  }















   //static public DataSet UpdateDonate(String parm, string commandtext, int id, int orgid, int catid, string status)
   // {

   //     int itemid = 0;
   //     // int orgid=0;  
   //     int shippngCost = 0;
   //     //  int orgid = 0;  
   //     String title = "";
   //     int quantity = 0;
   //     int catID = 0;
   //     String location = "";
   //     String orgPaypal = "";
   //     String description = "";
   //     String condition = "";
   //     //String shippngCost = status; 
   //     DateTime startDate = DateTime.Today;
   //     DateTime endDate = DateTime.Today;
   //     DateTime soldDate = DateTime.Today;
   //     String commandName = commandtext;

   //     String prm = parm;



   //    if(parm== "I" )
   //    {
   //        title = status;

   //    }

   //     String auctiontype = "";
   //    // status = "";

   //     DataSet ds = new DataSet();

   //     string commandText = commandtext;
   //     commandName = commandtext;
   //     //   string commandName;

   //     if (prm == "S" || prm == "Q" || prm == "I" || prm == "C")
   //     {

   //         r = new Referrer();
   //         ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
   //         ds = r.getItems(commandName, prm,0, itemid, orgid, catID, location,
   //  description, quantity, shippngCost, condition, title,
   //       startDate, endDate, soldDate, auctiontype, 0
   //  );
   //     }




   //     return ds;
   // }





















   //////////protected DataSet UpdateDonate(String parm, string commandtext, int id, int orgid, int catid, string status)
   //////////{

   //////////    int itemid = 0;
   //////////    // int orgid=0;  
   //////////    int shippngCost = 0;
   //////////    //  int orgid = 0;  
   //////////    String title = "";
   //////////    int quantity = 0;
   //////////    int catID = 0;
   //////////    String location = "";
   //////////    String orgPaypal = "";
   //////////    String description = "";
   //////////    String condition = "";
   //////////    //String shippngCost = status; 
   //////////    DateTime startDate = DateTime.Today;
   //////////    DateTime endDate = DateTime.Today;
   //////////    DateTime soldDate = DateTime.Today;
   //////////    String commandName = commandtext;

   //////////    String prm = parm;



   //////////    String auctiontype = "";
   //////////    status = "";

   //////////    DataSet ds = new DataSet();

   //////////    string commandText = commandtext;
   //////////    commandName = commandtext;
   //////////    //   string commandName;

   //////////    if (prm == "S" || prm == "Q" || prm == "C")
   //////////    {
   //////////        ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
   //////////        ds = r.getItems(commandName, prm, itemid, orgid, catID, location,
   ////////// description, quantity, shippngCost, condition, title,
   //////////      startDate, endDate, soldDate, auctiontype, 0
   ////////// );
   //////////    }




   //////////    return ds;
   //////////}















    static public int pennysec 
    { 
        get
        {
            int rpt = 0;
            if (m_bidSec < 13 && messages.bidtype=="penny")
            {




                if (m_bidPennySec[m_bidSec] != null || m_bidPennySec[m_bidSec] > 0)
                {
                    m_bSec = m_bidPennySec[m_bidSecRepeat];

                }

                else { return 0; }




                    //m_bidSecRepeat = m_bidSecRepeat >= m_bidPennySecRepeat[m_bidSec] ? 0 : rpt + 1;


                    if (m_bidSecRepeat > m_bidPennySecRepeat[m_bidSec])
                    {
                        m_bidSecRepeat = 0;

                        m_bidSec += 1;

                    }

                    else { m_bidSecRepeat += 1; }


                //m_bSec = m_bidPennySec[m_bidSec] != null ? m_bidPennySec[m_bidSec] : 0;


                //if ( m_bidSecRepeat > m_bidPennySec ) { }




                //if (m_bidPennySec[m_bidSec, m_bidSecRepeat + 1] == null || m_bidPennySec[m_bidSec, m_bidSecRepeat + 1] == 0)
                //{
                //    m_bidSec += 1; m_bidSecRepeat = 0;

                //}
            }

           // TimeSpan ts = new TimeSpan();
     //DateTime       ts = Convert.ToDateTime(m_bSec);

     return  m_bSec;

        }

 

    }



























    public static Control GetParentOfType(this Control childControl            )
    {

        //foreach   (   Control parent  in childControl.Controls)

        //{
        //    if (parent.ToString().IndexOf("aspx")!=-1)
        //    {
        //        return parent;
        //    }
        //}
        //if (childControl.ToString().IndexOf("aspx") != -1)
        //{           // goto child;
        //      return childControl; 
        //}

        //else
        //{

        while (childControl.Parent != null && childControl.ToString().IndexOf("aspx") == -1 && childControl.ToString().IndexOf("ascx") == -1)
             

            //Control parent = childControl.Parent.Controls;
            //else
            {
               childControl=childControl.Parent;


                //while (parent.GetType() != parentType)
                //{
                //    parent = parent.Parent;
                //}
                //if (parent.GetType() == parentType)
              //  return null;

             //   throw new Exception("No control of expected type was found");
            }
        
        //child:
        return childControl; 

 


    }












    public static void initCustomer(int buyerid )
    {













        //switch (Logins.password)
        //{
        //    case "tzally123":
        //        messages.buyerID = 6;

        //        break;
        //    case "zalman123":
        //        messages.buyerID = 1;

        //        break;

        //    case "eli123":
        //        messages.buyerID = 2;

        //        break;

        //    default:


        BLCustomer cust = new BLCustomer(buyerid);

                messages.cust = cust;


        //        break;


        //}


    }







    static private Decimal m_currentBidAmount;
    static public Decimal currentBidAmount
    {
        get
        { 
            return m_currentBidAmount;
        }
        set
        { 
              m_currentBidAmount=value;
        }
    }

    


    static private String m_buyer_Name;
    static public String buyer_Name
    {
        get
        {
            DateTime dt = bidEndTime;
            return m_buyer_Name;
        }
    }



    static public int[] bidPennySecRepeat;




    static public long amount_
    {
        get
        {
            return   bidEndTime!=null ?     calcdatespan(bidEndTime)  : 0  ;

        }
    }




    static private DateTime m_bidEndTime;


    static private DateTime m_bidEndTime1;
    static private DateTime m_bidEndTime2;




    static private string m_amount;
    static public String amount
    {
        get { return m_amount; }
        set { m_amount = value; }
    }


    static public long calcdatespan(DateTime dtFuture)
    {
      
        DateTime dtNow = new DateTime();
        // dtNow = DateTime.Now.AddMilliseconds(-messages.pennysec);
        dtNow = DateTime.Now;
        TimeSpan ts = new TimeSpan();// dtFuture.Subtract(dtNow);
        ts = dtFuture.Subtract(dtNow);
        long amountt = (long)ts.TotalMilliseconds;

        return amountt;
    }











    static private DateTime m_bidEndTime3;

    static public DateTime bidEndTime 
        
            {get
            {string prm="D";  // date/time rtrv



           


                string commandtext="get_Bids";

                int id=   cust.Organization.Orgitems.Item.auctionID != 0      ?    cust.Organization.Orgitems.Item.auctionID   : 0   ;//messages.auctionID;
 
             


            //if (m_bidEndTime==null)
            //    {
                DataSet ds =  new DataSet();
           ds= bidst(prm);

            
           DateTime dtm = new DateTime();

           if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
           { 
                DataRow dtr = ds.Tables[0].Rows[0];

                m_buyer_Name = dtr["buyer_Name"].ToString();
               /////// m_credits = Convert.ToInt16( dtr["credits"].ToString());
            /// bidEndTime =   DateTime.Parse(  dtr["endTime"].ToString(   )          );
            /// 

              dtm =   DateTime.Parse(  dtr["endTime"].ToString(   )          );
             //bidEndTime1 = DateTime.Parse(dtr["endTime1"].ToString());
             //bidEndTime2 = DateTime.Parse(dtr["endTime2"].ToString());
             //bidEndTime3 = DateTime.Parse(dtr["endTime3"].ToString());

                //Decimal Tbidamount = dtr["bidamount"].ToString() == string.Empty ? 0 : Convert.ToDecimal(String.Format("{0:d}"  ,dtr["bidamount"].ToString()));
              currentBidAmount = dtr["currentBidPrice"].ToString() == string.Empty ? 0 : Convert.ToDecimal(dtr["currentBidPrice"].ToString());
      
             ///////soldAmount = dtr["soldAmount"].ToString() == string.Empty ? 0 : Convert.ToDecimal(dtr["soldAmount"].ToString());
          m_bidEndTime=dtm;
           
           //}

        //   return dtm  ;// m_bidEndTime; 
                }
              ///return m_bidEndTime  ;
 

                   
                
                return  id>0 ?  UpdateItems(prm, commandtext, id) : DateTime.Now ;
             
        }
       
                
                
                set{

                    m_bidEndTime = value;
                }
        }



            static public DateTime bidEndTime11;



            static public DateTime bidEndTime1
                
                 {
                get {return  m_bidEndTime1;}
                     set { m_bidEndTime1 = value; }
            }


            static public DateTime bidEndTime2
            {
                get { return m_bidEndTime1; }
                set { m_bidEndTime1 = value; }
            }



            static public DateTime bidEndTime3
            {
                get { return m_bidEndTime1; }
                set { m_bidEndTime1 = value; }
            }





                
            //static public DateTime bidEndTime2;
            //static public DateTime bidEndTime3;



    static public long bidTimeLeft;

     static public int auctionID
     {
         get { return cust.Organization.Orgitems.Item.auctionID; }
     }
         
         


    static public string bidtype;
    static public int prodID; 
    static public int itemID;
    static public int orgID;
    static public int buyerID;
    static public int catID;
    static public int subcatID;
    static public decimal soldAmount;



    ///public static string[] ar = { "DIdonatename", "DIdonatename", "DIimagesrc", "DIAmount", "DIImgPhotoSrc", "DIimgID", "DCIdonateText" };
   /////////////// public string[] arn = { "DIimgID", "DInextpage", "DIdonatename", "DIimagesrc", "DIAmount", "DIImgPhotoSrc", "DRIdonateText" };

    static public string[] ar = { "DIimgID", "DInextpage", "DIdonatename", "DIimagesrc", "DIAmount", "DIImgPhotoSrc", "DCIdonateText" };

    static private Queue m_qulstPages; 
    static public string  history;
static public Queue qulstPages
{
    get
    {
        if (m_qulstPages == null)
        {
            m_qulstPages = new Queue();


        }
        return m_qulstPages;

    }
}



















   // public   List<String> lstPages = new List<String>();



        static public string[]  arCats ;


    static public string defaultpage;
    static public Boolean newImage;
    static private XmlDocument m_xml;
    static public ArrayList arrlstPages = new ArrayList();

    static public ArrayList arrlstPagesHst = new ArrayList();

    static public XmlDocument xml
    {
        get
        {
            if (m_xml == null)
            {
                m_xml = new XmlDocument();


            }
            return m_xml;

        }



    }














    static public bool   hackTester(String str)
    {



  ///       str = "H/H";// Request.QueryString.ToString();

        System.Text.RegularExpressions.Regex tester
                   = new System.Text.RegularExpressions.Regex("[<//\\>((&lt)|(&gt))).]", System.Text.RegularExpressions.RegexOptions.Singleline);
        

        System.Text.RegularExpressions.Match yy = tester.Match(str);


        if (yy.Value!="")
        { return false; }
       

      //  string ggg = yy.Value;


        return true;

    }





    static public string path;
    static public string image;














  static  public DateTime UpdateItems(String parm, string commandtext, int id)
    { // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = 0;
        String location = "";
        String orgPaypal = "";
        String description = "";
        String condition = "";
        //String shippngCost = status; 
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = commandtext;
        String soldFixedBid = "";
        String prm = parm;
        String auctionType = messages.bidtype;

        //  int credits = 3;
        DateTime biddate = DateTime.Now;
        int itemAuctionID = id;
        // status = "";
        DateTime bid = DateTime.Now; ; int fee_per_bid = 0;
        DataSet ds = new DataSet();
       decimal  bidamount = 0;
        string commandText = commandtext;
        commandName = commandtext;
        
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
        ds= r.get_BidsDate(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            bid = Convert.ToDateTime(dr["endTime"]);
        }


        



       
        return bid;
    }































    static public DataSet getItems(String parm, string commandtext, int id, int orgid, int catid, string status)
    {

        int itemid = 0;
        // int orgid=0;  
        int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        int catID = 0;
        String location = "";
        // String orgPaypal = "";
        String description = "";
        String condition = "";
        //String shippngCost = status; 
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = commandtext;

        String prm = parm;



        String auctiontype = "";
        status = "";

        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
        //   string commandName;

        if (prm == "S" || prm == "Q")
        {
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,0, itemid, orgid, catID, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype, 0
     );
        }




        return ds;
    }


















    static public DataSet bidst(string prm)
    {
        int orgid = Convert.ToInt16(((BLCustomer) messages.cust).Organization.ID);
      //  int orgid = Convert.ToInt16(messages.orgID);
        int catid = Convert.ToInt16(messages.catID);
        int itemid = Convert.ToInt16(messages.itemID);
        string bidtype = messages.bidtype;
        int buyerid = messages.buyerID;
        DateTime biddate = DateTime.Now;
        Decimal bidamount = 0;
        int credits = 3;
        int fee_per_bid = 0;
        int auctionid = messages.auctionID;
        String soldFixedBid = "";
     

         
        DataSet ds = new DataSet();
        

        String commandName = "get_Bids";
        String auctionType = "penny";
        
        int itemAuctionID = messages.auctionID;
        int buyerID = messages.buyerID;

        ds   = r.get_BidsLog(commandName, prm, itemAuctionID, buyerID, biddate,
          bidamount, credits,
          soldFixedBid, fee_per_bid, auctionType);
        



        return ds;


    }























  static public  String filePost(HtmlInputFile fileLoadimgTop , String paths )
    {


       
      paths=  paths.Replace("/","");
     /// paths = Server.MapPath("\\images") ;
        if (fileLoadimgTop != null && fileLoadimgTop.PostedFile != null && fileLoadimgTop.PostedFile.FileName != "")
        {
            //try
            //{
            //  ///  string path = Request.MapPath("images");


                fileLoadimgTop.PostedFile.SaveAs( paths + "\\" + fileLoadimgTop.PostedFile.FileName);
                //Span1.InnerHtml = "File uploaded successfully to <b>c:\\temp\\" +
                //                  fileLoad.PostedFile.FileName + "</b> on the Web server";

             //   image = "~\\" + path + "\\" + fileLoadimgTop.PostedFile.FileName;

                image =  paths + "\\" + fileLoadimgTop.PostedFile.FileName;

            //}
            //catch (Exception exc)
            //{
            //    //Span1.InnerHtml = "Error saving file <b>c:\\temp\\" +
            //    //                fileLoad.PostedFile.FileName + "</b><br>" + exc.ToString();
            //}



        }

        return image;

    }








































   /// public static ArrayList pages = new ArrayList();

    public static String pages ;

    public static string page ;

    public static int pager;
    public static string section;








    public static ArrayList xmlToarrays(XmlDocument HomeSettings, string DonateExlDonateWall, string[] ar, string[] arr, ArrayList arll)
    {

        int xy = 0;
        int xx = 0;

        string[] ars = new string [ar.Length+5]  ;
      
        for (int u=0 ; u<=9; u++)
        { ars[u]=""; }
        
        

        string[] Donates = DonateExlDonateWall.Split('/');
        string DonateExl = Donates[0];
        string DonatePage = Donates[1];
        string DonateWall = Donates[2];

        XmlNode CurrNode = HomeSettings.SelectSingleNode(DonateExl);

        XmlElement NewNodes = HomeSettings.CreateElement(DonateWall);
       

        //  CurrNode = HomeSettings.SelectSingleNode(DonateExl + "/" + DonateWall);
        CurrNode = HomeSettings.SelectSingleNode(DonateExl + "/" + DonatePage + "/" + DonateWall);
        XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall);
        xy = 0;
       /// arl.Clear();
        ///// System.Collections.ArrayList arl  = new System.Collections.ArrayList();
       //  arl = new ArrayList();
                /////////// List<string> cities = new List<string>();

        array_list arlList = new array_list();



        foreach (XmlNode xms in CurrNodes)
        {
            XmlNodeList CurrNodeC = xms.ChildNodes;

    

            for (int u = 0; u <= 9; u++)
            { ars[u] = ""; }

            //  CurrNode =  xm.InnerText;
           //// CurrNodeC = xms.ChildNodes;



            foreach (XmlNode xmm in CurrNodeC)
            {

         


                for (int x = 0; x <= ar.Length-1; x++ )
                {








                    if (xmm.Name == ar[x])
                    {
                        ars[x] = xmm.InnerText == null ? string.Empty : xmm.InnerText ;



 //static public string[] ardonateimagesrc = new string[55];



 //   static public string[] ardonateImgPhotoSrc = new string[55];
    

 //   static public string[] ardonateImgNpage = new string[55];
   

 //   static public string[] ardonateImgText = new string[55];
    
 //   static public string[] ardonateImgAmt = new string[55];
    

 //   static public string[] ardonateImgNumber = new string[55];
     

 //   static public string[] ardonateImgName = new string[55];
     

                        //string[] ar = { "DWlinknumber", "DWdonatename", "DWimagesrc", "DWamt", "DWdonateText" };



                        if (xmm.Name == "DWdonateText")
                        {

                          ////  int xx = Convert.ToInt16(ars[0]);

                            if (xx < 101) 
                            {
                               // xx = 0; 

                            //////////arlList.ardonateimagesrc[100 - xx] = ars[2];// messages.script;
                            //////////arlList.ardonateImgName[100 - xx] = ars[1];//  messages.lastname;
                            //////////arlList.ardonateImgText[100 - xx] = ars[5];// = honors;

                            //////////arlList.ardonateImgPhotoSrc[100 - xx] = ars[4];// messages.script;
                            //////////arlList.ardonateImgAmt[100 - xx] = ars[3];//  messages.lastname;
                            //////////arlList.ardonateImgNumber[100 - xx] = ars[0];// = honors;
                            //////////arlList.ardonateImgNpage[100 - xx] = ars[7];// = honors;
                          
                                arlList.ardonateimagesrc[              xx] = ars[2];// messages.script;
                            arlList.ardonateImgName[  xx] = ars[1];//  messages.lastname;
                            arlList.ardonateImgText[  xx] = ars[5];// = honors;

                            arlList.ardonateImgPhotoSrc[ xx] = ars[4];// messages.script;
                            arlList.ardonateImgAmt[ xx] = ars[3];//  messages.lastname;
                            arlList.ardonateImgNumber[  xx] = ars[0];// = honors;
                            arlList.ardonateImgNpage[  xx] = ars[7];// = hon

                            xx += 1;


                            }


                            //arl.Clear();


                           /// arl.Clear();

                            //while (arl.Count < 7)
                            //{// arl.Add(""); 
                                //arl.Add(string.Join(" ", ardonateImgNumber));
                                //arl.Add(string.Join(" ", ardonateImgNpage));
                                //arl.Add(string.Join(" ", ardonateImgName));
                                //arl.Add(string.Join(" ", ardonateimagesrc));
                                //arl.Add(string.Join(" ", ardonateImgNumber));
                                //arl.Add(string.Join(" ", ardonateImgAmt));
                                //arl.Add(string.Join(" ", ardonateImgPhotoSrc));
                                //arl.Add(string.Join(" ", ardonateImgText));


                            ////////////////////////arlList.arl.Add(arlList.ardonateImgNumber);
                            ////////////////////////arlList.arl.Add(arlList.ardonateImgNpage);
                            ////////////////////////arlList.arl.Add(arlList.ardonateImgName);
                            ////////////////////////arlList.arl.Add(arlList.ardonateimagesrc);
                            ////////////////////////arlList.arl.Add(arlList.ardonateImgNumber);
                            ////////////////////////arlList.arl.Add(arlList.ardonateImgAmt);
                            ////////////////////////arlList.arl.Add(arlList.ardonateImgPhotoSrc);
                            ////////////////////////arlList.arl.Add(arlList.ardonateImgText);
                          
                            //arl[0] = ardonateImgNumber;
                            //arl[1] = ardonateImgNpage;
                            //arl[2] = ardonateImgName;
                            //arl[3] = ardonateimagesrc;
                            //arl[4] = ardonateImgAmt;
                            //arl[5] = ardonateImgPhotoSrc;
                            //arl[6] = ardonateImgText;
                            //}
                           //// break;
                          ////////////////    messages.cnt   += 1;
                            //arl.Add(ardonateImgNumber);
                            //arl.Add(ardonateImgNpage);
                            //arl.Add(ardonateImgName);
                            //arl.Add(ardonateimagesrc);
                            //arl.Add(ardonateImgAmt);
                            //arl.Add(ardonateImgPhotoSrc);
                            //arl.Add(ardonateImgText);



                            //arl.Add(ardonateimagesrc);
                            //arl.Add(ardonateImgName);
                            //arl.Add(ardonateImgPhoto);
                            //arl.Add(ardonateImgText);
                            //arl.Add(ardonateImgPhotoSrc);
                            //arl.Add(ardonateImgAmt);
                            //arl.Add(ardonateImgNumber);
                            //arl.Add(ardonateImgNpage);




                            //arll.Add(arl);

                        }

                        else
                        {
                          
                            
                            if (xmm.Name.Contains("donateText")           &&  DonateWall != "DonateWall" )
                            {

                                //if (number != null && number != "")
                                //{
                                    ////   int x = Convert.ToInt16(number);
                               //   xy +=1;// messages.cnt;

                                    //////ardonateWallSrc[xy] = ars[2];// messages.script;
                                    //////ardonateWall[xy] = ars[1];//  messages.lastname;
                                    //////ardonateWalls[xy] = ars[4];// = honors;






                                arlList.ardonateimagesrc[xy] = ars[3];// messages.script;
                                arlList.ardonateImgName[xy] = ars[2];//  messages.lastname;
                                arlList.ardonateImgText[xy] = ars[6];// = honors;

                                arlList.ardonateImgPhotoSrc[xy] = ars[5];// messages.script;
                                arlList.ardonateImgAmt[xy] = ars[4];//  messages.lastname;
                                arlList.ardonateImgNumber[xy] = ars[0];// = honors;
                                arlList.ardonateImgNpage[xy] = ars[1];// = honors;

                                    xy += 1;
                                    ///arl.Clear();


                                    //while (arl.Count < 7)
                                    //{ arl.Add(""); }

                                    //arl[0] = ardonateImgNumber;
                                    //arl[1] = ardonateImgNpage;
                                    //arl[2] = ardonateImgName;
                                    //arl[3] = ardonateimagesrc;
                                    //arl[4] = ardonateImgAmt;
                                    //arl[5] = ardonateImgPhotoSrc;
                                    //  arl[6] = ardonateImgText;

                                    //arlList.arl.Add(ardonateImgNumber);
                                    //arlList.arl.Add(ardonateImgNpage);
                                    //arlList.arl.Add(ardonateImgName);
                                    //arlList.arl.Add(ardonateimagesrc);
                                    //arlList.arl.Add(ardonateImgNumber);
                                    //arlList.arl.Add(ardonateImgAmt);
                                    //arlList.arl.Add(ardonateImgPhotoSrc);
                                    //arlList.arl.Add(ardonateImgText);



                                   

                                    //arl.Add(ardonateImgNumber);
                                    //arl.Add(ardonateImgNpage);
                                    //arl.Add(ardonateImgName);
                                    //arl.Add(ardonateimagesrc);
                                    //arl.Add(ardonateImgAmt);
                                    //arl.Add(ardonateImgPhotoSrc);
                                    //arl.Add(ardonateImgText);

                                

                                    //donateimagesrc[x] = messages.script;
                                    //donateImgPhoto[x] = messages.err;
                                    //donateImgNpage[x] = messages.number;
                                    //donateImgText[x] = honors;
                                   /////////////// messages.cnt = xy + 1;
                                //}
                                    /////  break;
                            }

                            //number = xmm.InnerText;
                            //messages.number = number;


                    

                        }
                    }
                }
             }

           // return arll;
          






    

        }



        ArrayList ht = new ArrayList();

        ///ht.Add(1, arl);

        arlList.arl.Add(arlList.ardonateImgNumber);
        arlList.arl.Add(arlList.ardonateImgNpage);
        arlList.arl.Add(arlList.ardonateImgName);
        arlList.arl.Add(arlList.ardonateimagesrc);
       // arlList.arl.Add(arlList.ardonateImgNumber);
        arlList.arl.Add(arlList.ardonateImgAmt);
        arlList.arl.Add(arlList.ardonateImgPhotoSrc);
        arlList.arl.Add(arlList.ardonateImgText);


        arll.Add(arlList); 
      ///  messages.cnt = arll.Count;
      ///  arl.Clear();

        //////////////for (int y = 0; y <= ar.Length-1; y++)
        //////////////{
        //////////////    xmlToarraysNodes(HomeSettings, CurrNode, ar[y], arr[y] );


        //////////////}
        return arll;
    }



//    List<Point> listPoint = new List<Point>();
//Point pointToAdd;
//pointToAdd = new Point(1, 1);
//for (int i = 0; i <= 10; i++)
//{
//    if (!listPoint.Contains(pointToAdd))
//    {
//        listPoint.Add(pointToAdd);
//    }
//}
//Console.WriteLine(listPoint.Count);

    //List<Point> CleanList(List<Point> listPoint)
    //{
    //    List<Point> cleanList = new List<Point>();
    //    foreach (Point currentPoint in listPoint)
    //    {
    //        if (!(cleanList.Contains(currentPoint)))
    //        {
    //            cleanList.Add(currentPoint);
    //        }
    //    }
    //    return cleanList;
    //}


    public static XmlNode xmlToarraysNodes(XmlDocument HomeSettings, XmlNode CurrNode, string element, string innertext )
    {

        XmlElement NewNodes = HomeSettings.CreateElement(element);
        NewNodes.InnerText = NewNodes.InnerText = innertext;
        CurrNode.PrependChild(NewNodes);

        return CurrNode;
    }






      //public static XmlNode xmlToXml(XmlDocument HomeSettings, XmlNode CurrNode, string element, string innertext, string DonateExl)
  
    public static XmlNode xmlToXml(XmlDocument HomeSettings, string CurrNode, string element, string innertext, string DonateExl   ,string imgpage )
    {

        XmlNode DonateExlNode = HomeSettings.SelectSingleNode(DonateExl);



      ///  XmlElement NewNodesCurrNode = HomeSettings.CreateElement(CurrNode);
       XmlElement NewNodes = HomeSettings.CreateElement(element);
       /// XmlElement NewNodes = CurrNode.cr.CreateElement(element); 
      /// DonateExlNode.PrependChild(NewNodesCurrNode);
       NewNodes.InnerText = innertext;
       DonateExlNode.PrependChild(NewNodes);




       if (imgpage != "")
       {




           //XmlAttribute atr;


           //if (DonateExlNode.Attributes["PageIcon"] != null)
           //{
           //    atr = (XmlAttribute)NewNodes.Attributes["PageIcon"];
           //    DonateImgHst = atr.Value;
           //}








           XmlAttribute attribute;



           attribute = HomeSettings.CreateAttribute("PageIcon");

           attribute.Value = imgpage;

           NewNodes.Attributes.Append(attribute);
       }






        //XmlNode DonateExlNodes = HomeSettings.SelectSingleNode(DonateExl + "/" + element);
        //DonateExlNodes.AppendChild(.InnerXml = innertext;
    ///   HomeSettings.Save(strPhysicalPath);

       return DonateExlNode;
    }







    public static string copyXmlPages(XmlDocument HomeSettings, XmlDocument HomeSettings_, string DonateExlDonateWall, string DonateExlHst, string DonateImgHst, string option)
    {

        string[] Donates = DonateExlDonateWall.Split('/');
        string DonateExl = Donates[0];

        string DonatePage = Donates[1];




        string[] DonatesHst = DonateExlHst.Split('/');
        string DonateExl_Hst = DonatesHst[0];

        string DonatePageHst = DonatesHst[1];


        XmlNode RootNode = HomeSettings_.SelectSingleNode(DonateExl );

        
            XmlNode CurrNode_ = HomeSettings.SelectSingleNode(DonateExl + "/" + DonatePage);
        



        XmlNode RootNodeHst = HomeSettings_.SelectSingleNode(DonateExl_Hst);
    
       // string strCurrNode = DonateExl + "/" + DonatePage; 
        string strCurrNode =  DonatePage;
        string innertext = "";// CurrNode.InnerXml;
        string element;

        string DonateExlDonatePage = DonateExl + "/" + DonatePage; 
        
        string DonateExlDonatePageHst = DonateExl_Hst + "/" + DonatePageHst;
        //xmlToXml(HomeSettings_, RootNode, strCurrNode, innertext, DonateExl);





        if (option == "E")
        {
          
            if (CurrNode_ == null  ) { return "Page not found"; }

            


                
       if (DonateImgHst != "")
       {



           if (CurrNode_.Attributes["PageIcon"] != null)
           {


               CurrNode_.Attributes["PageIcon"].Value = DonateImgHst;
           }
           else 
           {
               XmlAttribute attribute;



               attribute = HomeSettings.CreateAttribute("PageIcon");

               attribute.Value = DonateImgHst;

               CurrNode_.Attributes.Append(attribute);
           }




           return "Page Icon Edited";
       }






          
        

        }
        



        if (option == "N"  )
        {
            XmlNodeList CurrNodessTest = HomeSettings_.SelectNodes(DonateExl + "/" + DonatePageHst);

            if (CurrNodessTest != null && CurrNodessTest.Count > 0) { return "Page already exist remove from history and then copy"; }



            xmlToXml(HomeSettings_, "", DonatePageHst, innertext, DonateExl_Hst,DonateImgHst);

            return "New Page Created";
        
        }
        
        
        
        if (option == "B" || option == "C"  ||  option == "CH" )
        {
            XmlNodeList CurrNodessTest = HomeSettings_.SelectNodes(DonateExl + "/" + DonatePageHst);

            if (CurrNodessTest != null && CurrNodessTest.Count > 0) { return "Page already exist remove from history and then copy"; }
        }



        if (option == "C" || option == "B" || option == "CH")
        {

            //XmlElement NewNodes = HomeSettings_.CreateElement(DonatePage);
        XmlElement NewNodes = HomeSettings_.CreateElement(DonatePageHst);

        if (option == "C" || option=="CH"  )
        {
            RootNode.PrependChild(NewNodes);
        }
        else { RootNodeHst.PrependChild(NewNodes); }

        }
        ///  string DonateExlDonatePage = DonateExl + "/" + DonatePage;
        XmlNode CurrNodeHst_ = HomeSettings.SelectSingleNode(DonateExl_Hst + "/" + DonatePageHst);

        
       // XmlNodeList CurrNodess = HomeSettings_.SelectNodes(DonateExl + "/" + DonatePage);
        XmlNodeList CurrNodess = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage);
       XmlNodeList CurrNodes = CurrNode_.ChildNodes;
       // XmlNodeList CurrNodes = CurrNodeHst_.ChildNodes;  
         
       /// foreach (XmlNode xms in CurrNodes)
       // {


               for (int ii = CurrNodes.Count - 1; ii >= 0; ii--)
            {

                    XmlAttribute atr;
                    DonateImgHst = "";
                XmlNode xms = CurrNodes[ii];
                if (xms.Attributes["PageIcon"] != null)
                {
                    atr = (XmlAttribute)xms.Attributes["PageIcon"];
                    DonateImgHst = atr.Value;
                }


            switch (option)
            {


                case "B":


                    xmlToXml(HomeSettings_, xms.ParentNode.Name, xms.Name, innertext, DonateExlDonatePageHst,DonateImgHst );
                    xms.ParentNode.RemoveChild(xms);
                    break;


                case "C":


                  //  xmlToXml(HomeSettings_, xms.ParentNode.Name, xms.Name, innertext, DonateExlDonatePage);
                    xmlToXml(HomeSettings_, xms.ParentNode.Name, xms.Name, innertext, DonateExlDonatePageHst,DonateImgHst );
                    break;


                case "CH":


                    //  xmlToXml(HomeSettings_, xms.ParentNode.Name, xms.Name, innertext, DonateExlDonatePage);
                    xmlToXml(HomeSettings_, xms.ParentNode.Name, xms.Name, innertext, DonateExlDonatePageHst, DonateImgHst);
                    break;
                case "R":


                 ////   xms.ParentNode.RemoveChild(xms);

                    break;

            }
               
             

























            XmlNodeList CurrNodeC = xms.ChildNodes;
          


            for (int i = CurrNodeC.Count - 1; i >= 0; i--)
            {


                switch (option)
                {



                
                    case "B":

                      //  xmlToXml(HomeSettings_, CurrNodeC[i].ParentNode.Name, CurrNodeC[i].Name, CurrNodeC[i].InnerText, DonateExl);
                        xmlToXml(HomeSettings_, CurrNodeC[i].ParentNode.Name, CurrNodeC[i].Name, CurrNodeC[i].InnerText, DonateExl_Hst + "/" + DonatePageHst + "/" + CurrNodeC[i].ParentNode.Name, "");

                        CurrNodeC[i].ParentNode.RemoveChild(CurrNodeC[i]);
            
                        break;

                    case "C" :


                        xmlToXml(HomeSettings_, CurrNodeC[i].ParentNode.Name, CurrNodeC[i].Name, CurrNodeC[i].InnerText, DonateExl + "/" + DonatePageHst + "/" + CurrNodeC[i].ParentNode.Name, "");
               
                break;



                    case "CH":


                xmlToXml(HomeSettings_, CurrNodeC[i].ParentNode.Name, CurrNodeC[i].Name, CurrNodeC[i].InnerText, DonateExl_Hst + "/" + DonatePageHst + "/" + CurrNodeC[i].ParentNode.Name  , "" );

                break;
                    


                    case "R" :


                 CurrNodeC[i].ParentNode.RemoveChild(CurrNodeC[i]);
            
                break;

                }
               
                }



          ////////////  xms.ParentNode.RemoveChild(xms);


            if (option == "R")
            {

                CurrNodes[ii].ParentNode.RemoveChild(CurrNodes[ii]);
            }
        }

        ///  XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall);

        ////////////////XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage);



        ////////////////foreach (XmlNode xms in CurrNodes)
        ////////////////{


        ////////////////   /////// xmlToXml(HomeSettings_, xms.ParentNode ,  xms.Name , innertext, DonateExl);


        ////////////////    XmlNodeList CurrNodeC = xms.ChildNodes;


        ////////////////    for (int i = CurrNodeC.Count - 1; i >= 0; i--)
        ////////////////    {


           


        ////////////////        CurrNodeC[i].ParentNode.RemoveChild(CurrNodeC[i]);
        ////////////////    }

 
        ////////////////}

               if (option == "R")
               CurrNode_.ParentNode.RemoveChild(CurrNode_);

        return "Page copied sucessfully";
    }










    public static void removeTextWalls(XmlDocument HomeSettings, string DonateExlDonateWall )
    {

        string[] Donates = DonateExlDonateWall.Split('/');
        string DonateExl = Donates[0];

        string DonatePage = Donates[1];
       /// string DonateWall = Donates[2];
        XmlNode CurrNode = HomeSettings.SelectSingleNode(DonateExl + "/" + DonatePage);

        

       ///  XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall);

            XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage  );


      
         foreach (XmlNode xms in CurrNodes)
         {
             XmlNodeList CurrNodeC = xms.ChildNodes;


             for (int i = CurrNodeC.Count - 1; i >= 0; i--)
            {
                CurrNodeC[i].ParentNode.RemoveChild(CurrNodeC[i]);
            }

       

             ////foreach (XmlNode xmss in CurrNodeC)
             ////{

             ////    if (xmss.Name == DonateWall)
             ////    {
             ////        xmss.ParentNode..RemoveChild(xmss);
             ////    }
             ////}
         }

    }












    public static void removeTextWallsSection(XmlDocument HomeSettings, string DonateExlDonateWall)
    {

        string[] Donates = DonateExlDonateWall.Split('/');
        string DonateExl = Donates[0];

        string DonatePage = Donates[1];
         string DonateWall = Donates[2];
         XmlNode CurrNode = HomeSettings.SelectSingleNode(DonateExl + "/" + DonatePage + "/" + DonateWall);



        ///  XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall);

         XmlNodeList CurrNodes = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall);



        foreach (XmlNode xms in CurrNodes)
        {
            XmlNodeList CurrNodeC = xms.ChildNodes;


            for (int i = CurrNodeC.Count - 1; i >= 0; i--)
            {
                CurrNodeC[i].ParentNode.RemoveChild(CurrNodeC[i]);
            }



            xms.ParentNode.RemoveChild(xms);

            ////foreach (XmlNode xmss in CurrNodeC)
            ////{

            ////    if (xmss.Name == DonateWall)
            ////    {
            ////        xmss.ParentNode..RemoveChild(xmss);
            ////    }
            ////}
        }

    }










    public static void createTextWalls(XmlDocument HomeSettings, string DonateExlDonateWall,string[] ar, string[] arr)
    {

        string[] Donates = DonateExlDonateWall.Split('/') ;
      string  DonateExl =Donates[0];
     
      string DonatePage = Donates[1];
      string DonateWall = Donates[2];
      XmlNode CurrNode_ = HomeSettings.SelectSingleNode(DonateExl + "/" + DonatePage);

      XmlElement NewNodes = HomeSettings.CreateElement(DonateWall);




      ////////////////////////////////////  CurrNode_.PrependChild(NewNodes);
        ///     CurrNode_.AppendChild(NewNodes);
  //XmlNode xmlNode = xmlDocument.SelectSingleNode("//COLUMNS");
  //                  IEnumerator iEnumerator = xmlNode.ChildNodes.GetEnumerator();
  //                  while (iEnumerator.MoveNext())
  //                  {
  //                      string nombre = ((XmlNode)iEnumerator.Current).InnerText;
  //                      if (nombre.ToUpper().CompareTo("ID") != 0)
  //                          this.listView.Columns.Add(nombre);
  //                  }
  //                  iEnumerator = xmlDocument.SelectNodes("//ROW").GetEnumerator();
  //                  while (iEnumerator.MoveNext())
  //                  {
  //                      ListViewItem listViewItem = new ListViewItem();
  //                      xmlNode = (XmlNode)iEnumerator.Current;


     XmlNode CurrNode = HomeSettings.SelectSingleNode(DonateExl + "/" + DonatePage + "/" + DonateWall);

     IEnumerator ie = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall).GetEnumerator();


     if (CurrNode == null)
     {
         CurrNode_.PrependChild(NewNodes);
     }
     else 
     {


         while (ie.MoveNext())
         {             
                 CurrNode = (XmlNode)ie.Current;
                 
             }
         CurrNode_.PrependChild(NewNodes);


         }







     ie = HomeSettings.SelectNodes(DonateExl + "/" + DonatePage + "/" + DonateWall).GetEnumerator();


      while (ie.MoveNext() )
      {
         if  (((XmlNode)ie.Current).InnerText=="") 
         {
             CurrNode = (XmlNode)ie.Current;
             break;             
         }
      }

   //   CurrNode = (XmlNode)ie.Current;
     



      for (int y = 0; y < ar.Length; y++)
      {
                    createTextWallNodes( HomeSettings,  CurrNode,  ar[y], arr[y]);


      }
      CurrNode_.PrependChild(NewNodes);
    }










    public static XmlNode createTextWallNodes(XmlDocument HomeSettings, XmlNode CurrNode, string element, string innertext)
    {

        XmlElement NewNodes = HomeSettings.CreateElement(element);
        NewNodes.InnerText = NewNodes.InnerText = innertext;
        
        
        ///CurrNode.PrependChild(NewNodes);
         CurrNode.AppendChild(NewNodes);
        //CurrNode.LastChild

      //  CurrNode.InsertAfter(  NewNodes, CurrNode.LastChild );



        return CurrNode;
    }











    public static string  DataItem;
    public static int ItemIndex;

    public static int pageindex;

    public static int sectionindex;
    public static int pointer;
    public static int origpointer;
    public static int pointerHolder;




    public static MemoryStream CreateMemoryStream_1(string filePath)
    {
        //Step1: read whole FileStream into byte array.
        byte[] buffer = System.IO.File.ReadAllBytes(filePath);


        //Step2:convert byte array into MemoryStream.  
        MemoryStream ms1 = new MemoryStream(buffer);





        return ms1;
    }


    public static byte[] ImageToByte2(System.Drawing.Image img)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();

           

            byteArray = stream.ToArray();
        }
        return byteArray;
    }





    public static byte[] StreamToBytes(MemoryStream streamer)
    {
        byte[] byteArray = new byte[0];


        byteArray = streamer.ToArray();



        return byteArray;
    }



    public static bool writeByteArrayToFile(byte[] buff, string fileName)
    {
        bool response = false;

        try
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(buff);
            bw.Close(); //Thanks Karlo for pointing out!
            response = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return response;
    }
























  static  public string strPhysicalPath;




 


  public static   string[] sect = { "DonateWall", "DonateCenterImg", "DonateRightimages", "DonateLeftimages","DonateTopImg", "DonateTopRightImg", "DonateTopLeftImg",  "DonateWallIcon",                          
                          "DonateWallIcon1", "DonateWallIcon2", "DonateTopBanner", "DonateSecondBanner", 
                          "DonateThirdBanner",   "DonateBottomimages"  };

  public static   string[] textsect = { "DonateWall", "DCIdonateText", "DRIdonateText", "DLIdonateText","DTIdonateText", "DTRIdonateText", "DTLIdonateText",  "DWWIdonateText",                          
                          "DWWI1donateText", "DWWI1donateText", "DTBdonateText", "DSBdonateText", 
                          "DTHBdonateText",   "DBBdonateText"  };



    public static List<String> lstPages = new List<String>();

  //static public XmlDocument HomeSettings;// = new XmlDocument();
  //static public XmlNode CurrNode;





    public static void ConfirmImg_Load(int indxp, int indxs)
    { 


        int w = 0;
        string DonateExlDonateWall = sect[indxs];

 
        int x = xml_list.indexSection;

        if (lstPages == null || lstPages.Count == 0)
            lstPages = (List<String>)messages.qulstPages.Peek();

        String[] pags  = lstPages[indxp].Split(',');
        string lstpages = pags[0];// lstPages[indxp];
     
















        string strPhysicalPath = "";

        XmlDocument HomeSettings = new XmlDocument();
        strPhysicalPath = messages.strPhysicalPath;
        
       
        HomeSettings.Load(strPhysicalPath);

        string[] pages = lstPages[messages.pageindex].Split(',');

        string page = pages[0];/// lstPages[messages.pageindex];// messages.page;


        /////////  messages.removeTextWalls(HomeSettings, "DonateExl/" + page + "/" + node);
        messages.removeTextWallsSection(HomeSettings, "DonateExl/" + page + "/" + DonateExlDonateWall);


        HomeSettings.Save(strPhysicalPath);








        while (w < xml_list.ardonateimagesrc.Length && xml_list.ardonateimagesrc[w] != null)
        {
            w++;

        }


        w--;

        //   while (w < xml_list.ardonateimagesrc.Length && xml_list.ardonateimagesrc[w] != null)
        while (w >= 0)
        {

            
            //  firstname_ + " " + lastname_
           //////////// string[] arr = { xml_list.ardonateImgName[w], xml_list.ardonateimagesrc[w], xml_list.ardonateImgAmt[w], xml_list.ardonateImgPhotoSrc[w], xml_list.ardonateImgNumber[w], xml_list.ardonateImgText[w] };
            string[] arr = { xml_list.ardonateImgNumber[w], xml_list.ardonateImgNpage[w], xml_list.ardonateImgName[w], xml_list.ardonateimagesrc[w], xml_list.ardonateImgAmt[w], xml_list.ardonateImgPhotoSrc[w], xml_list.ardonateImgText[w] };

            createTextWall(ar, arr, textsect[indxs], DonateExlDonateWall);
            //w++;

            w--;
        }



        xml_list.indexPage = indxp;
        xml_list.indexPage = indxs;




        messages.arrlstPages.RemoveAt(indxp);



        clsPages clspages = new clsPages(lstpages, strPhysicalPath);

        //////////messages.arrlstPages.Add(clspages);

        messages.arrlstPages.Insert(indxp, clspages);


        xml_Load(indxp, indxs);


    }





   public static void xml_Load(int indexPage, int indexSection)
    {
        clsPages clspages = (clsPages)messages.arrlstPages[indexPage];

        arraylists arlists = (arraylists)clspages.allPages[indexPage];

        array_list arlpages = (array_list)arlists.arlpages[indexSection];

      //  ArrayImg_Load(arlpages, indexPage, indexSection);



    }






    //protected void ArrayImg_Load(array_list aaa, int indxp, int indxs)
    //{

    //    ArrayList arl = (ArrayList)((array_list)aaa).arl;





    //    xml_list.ardonateImgNumber = arl.Count > 0 ? (string[])arl[0] : xml_list.ardonateImgNumber;
    //   xml_list.ardonateImgNpage = arl.Count > 0 ? (String[])arl[1] : xml_list.ardonateImgNpage;
    //     xml_list.ardonateImgName = arl.Count > 0 ? (String[])arl[2] : xml_list.ardonateImgName;

    //     xml_list.ardonateimagesrc = arl.Count > 0 ? (String[])arl[3] : xml_list.ardonateimagesrc;
    //      xml_list.ardonateImgAmt = arl.Count > 0 ? (String[])arl[4] : xml_list.ardonateImgAmt;
    //      xml_list.ardonateImgPhotoSrc = arl.Count > 0 ? (String[])arl[5] : xml_list.ardonateImgPhotoSrc;
    //    // donateImgPhoto = (String[])arl[2];

    //      xml_list.ardonateImgText = arl.Count > 0 ? (String[])arl[6] : xml_list.ardonateImgText;







    //    xml_list.indexPage = indxp;
    //    xml_list.indexSection = indxs;





    //}






    public  static void createTextWall(string[] arx, string[] arrx, string text, string node)
    {


        arx[6] = text;






        try
        {









            string strPhysicalPath = "";

            XmlDocument HomeSettings = new XmlDocument();
            strPhysicalPath = messages.strPhysicalPath;

            //strPhysicalPath = Request.MapPath("~\\XML\\changeText.xml");
            HomeSettings.Load(strPhysicalPath);

            string[] pages = lstPages[messages.pageindex].Split(',');

            string page = pages[0];// lstPages[messages.pageindex];// messages.page;


            /////////  messages.removeTextWalls(HomeSettings, "DonateExl/" + page + "/" + node);
            messages.createTextWalls(HomeSettings, "DonateExl/" + page + "/" + node, arx, arrx);


            HomeSettings.Save(strPhysicalPath);


        }
        catch { }






    }









    static public void ArrayImgPointer(string ImgNumber, string ImgNpage, string txttop, string imagesrc, string imgtop, string ImgAmt, string txtimgcenter, int indxp, int indxs)
    {


        int pointer = messages.pointer;

        ///  ArrayList arl = (ArrayList)((array_list)aaa).arl;

         
        xml_list.ardonateImgNumber[pointer] = ImgNumber;
       xml_list.ardonateImgNpage[pointer] = ImgNpage;
          xml_list.ardonateImgName[pointer] = txttop;
        xml_list.ardonateimagesrc[pointer] = imagesrc;
        xml_list.ardonateImgAmt[pointer] = ImgAmt;

         xml_list.ardonateImgPhotoSrc[pointer] = imgtop;
         xml_list.ardonateImgText[pointer] = txtimgcenter;








        xml_list.indexPage = indxp;
        xml_list.indexSection = indxs;
 }










    static public DataList PagesLoad(DataList Repeater1)
    {

       //// String com = System.Configuration.ConfigurationManager.AppSettings["com.systemsoriginals.www.webservice"].ToString();


        //          * ++++++++++++++++++++++**************


        DataSet ds = new DataSet();
       
     XmlNode CurrNode;


        XmlDocument HomeSettings = new XmlDocument();

        // m_pages

        //strPhysicalPath = messages.strPhysicalPath;   // Request.MapPath("~\\XML\\changeText.xml");
        
     
     //messages.xml.Load(strPhysicalPath);


        HomeSettings.Load(strPhysicalPath);


        CurrNode = HomeSettings.SelectSingleNode("DonateExl");

        XmlNodeList CurrNodes = CurrNode.ChildNodes;
        int xx = 0;

        messages.arrlstPages.Clear();






        if (messages.arrlstPages.Count == 0)
        {
            foreach (XmlNode node in CurrNodes)
            {

                if (node.Name.ToString() == "DonateHomePage")
                {
                    messages.defaultpage = node.InnerText;

                }
                else
                {
                    clsPages clspages = new clsPages(node.Name.ToString(), strPhysicalPath);

                    messages.arrlstPages.Add(clspages);
                }

            }


        }


        messages.lstPages.Clear();
        foreach (XmlNode node in CurrNodes)
        {
          
            string nodeAttr =  node.Attributes.Count>0?   node.Attributes[0].Value : "";

            messages.lstPages.Add(node.Name.ToString() + "," + nodeAttr);

        }




        Repeater1.DataSource = messages.lstPages;
        Repeater1.DataBind();


        messages.qulstPages.Clear();
        messages.qulstPages.Enqueue(lstPages);
        return Repeater1;

    }











static public void ArrayImg_Load(array_list aaa, int indxp, int indxs)
 {

     ArrayList arl = (ArrayList)((array_list)aaa).arl;





   xml_list.ardonateImgNumber = arl.Count > 0 ? (string[])arl[0] : xml_list.ardonateImgNumber;
      xml_list.ardonateImgNpage = arl.Count > 0 ? (String[])arl[1] : xml_list.ardonateImgNpage;
      xml_list.ardonateImgName = arl.Count > 0 ? (String[])arl[2] : xml_list.ardonateImgName;

     xml_list.ardonateimagesrc = arl.Count > 0 ? (String[])arl[3] : xml_list.ardonateimagesrc;
       xml_list.ardonateImgAmt = arl.Count > 0 ? (String[])arl[4] : xml_list.ardonateImgAmt;
     xml_list.ardonateImgPhotoSrc = arl.Count > 0 ? (String[])arl[5] : xml_list.ardonateImgPhotoSrc;
     // donateImgPhoto = (String[])arl[2];

     xml_list.ardonateImgText = arl.Count > 0 ? (String[])arl[6] : xml_list.ardonateImgText;







     xml_list.indexPage = indxp;
     xml_list.indexSection = indxs;





 }



















static public void ArrayImgPointerRemove_Load()
 {


     int pointer = messages.pointer;

     ///  ArrayList arl = (ArrayList)((array_list)aaa).arl;



     for (int indx = pointer; indx <= xml_list.ardonateimagesrc.Length && xml_list.ardonateimagesrc[indx] != null; indx++)
     {

         xml_list.ardonateImgNumber[indx] = xml_list.ardonateImgNumber[indx + 1];
         xml_list.ardonateImgNpage[indx] = xml_list.ardonateImgNpage[indx + 1];
         xml_list.ardonateImgName[indx] = xml_list.ardonateImgName[indx + 1];
         xml_list.ardonateimagesrc[indx] = xml_list.ardonateimagesrc[indx + 1];
         xml_list.ardonateImgAmt[indx] = xml_list.ardonateImgAmt[indx + 1];

         xml_list.ardonateImgPhotoSrc[indx] = xml_list.ardonateImgPhotoSrc[indx + 1];
         xml_list.ardonateImgText[indx] = xml_list.ardonateImgText[indx + 1];


     }
     int idx = 0;

     while (xml_list.ardonateimagesrc[idx] != null)
     { idx++; }
     idx -= 1;

     //////xml_list.ardonateImgNumber[idx] = null ;
     //////xml_list.ardonateImgNpage[idx] = null;
     //////xml_list.ardonateImgName[idx] = null;
     //////xml_list.ardonateimagesrc[idx] = null;
     //////xml_list.ardonateImgAmt[idx] = null;

     //////xml_list.ardonateImgPhotoSrc[idx] = null;
     //////xml_list.ardonateImgText[idx] = null;


     //xml_list.indexPage = indxp;
     //xml_list.indexPage = indxs;

     messages.pointer = idx;
    messages.ConfirmImg_Load(messages.pageindex, messages.sectionindex);
     messages.pointer = 0;
 //    ConfirmImg(sender, e);


 }


















 











    public static byte[] ImageToByte(System.Drawing.Image img)
    {
        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }








    //private static void decompressFile(string inFile, string outFile)
    //{
    //    System.IO.FileStream outFileStream = new System.IO.FileStream(outFile, System.IO.FileMode.Create);
    //    zlib.ZOutputStream outZStream = new zlib.ZOutputStream(outFileStream);
    //    System.IO.FileStream inFileStream = new System.IO.FileStream(inFile, System.IO.FileMode.Open);
    //    try
    //    {
    //        CopyStream(inFileStream, outZStream);
    //    }
    //    finally
    //    {
    //        outZStream.Close();
    //        outFileStream.Close();
    //        inFileStream.Close();
    //    }
    //}

    //public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
    //{
    //    byte[] buffer = new byte[2000];
    //    int len;
    //    while ((len = input.Read(buffer, 0, 2000)) > 0)
    //    {
    //        output.Write(buffer, 0, len);
    //    }
    //    output.Flush();
    //}



//    using System;
//using System.Collections;
//public class SamplesArrayList  {

//   public static void Main()  {

//      // Creates and initializes a new ArrayList.
//      ArrayList myAL = new ArrayList();
//      myAL.Add("Hello");
//      myAL.Add("World");
//      myAL.Add("!");

//      // Displays the properties and values of the ArrayList.
//      Console.WriteLine( "myAL" );
//      Console.WriteLine( "\tCount:    {0}", myAL.Count );
//      Console.WriteLine( "\tCapacity: {0}", myAL.Capacity );
//      Console.Write( "\tValues:" );
//      PrintValues( myAL );
//   }

//   public static void PrintValues( IEnumerable myList )  {
//      System.Collections.IEnumerator myEnumerator = myList.GetEnumerator();
//      while ( myEnumerator.MoveNext() )
//         Console.Write( "\t{0}", myEnumerator.Current );
//      Console.WriteLine();
//   }
//}



      
   

   
    

    //static public atring[] ardonateWallSrc
    //{
    //    get { return m_ardonateWallSrc; }
    //    set { m_ardonateWallSrc = value; }

    //}




    //static private atring[] m_ardonateWalls;

    //static public atring[] ardonateWall
    //{
    //    get { return m_ardonateWalls; }
    //    set { m_ardonateWalls = value; }

    //}


    //static private atring[] m_ardonateWall;

    //static public atring[] ardonateWall
    //{
    //    get { return m_ardonateWall; }
    //    set { m_ardonateWall = value; }

    //}







     















    static private int m_amt;

    static public int amt
    {
        get { return m_amt; }
        set { m_amt = value; }

    }





    static private long m_amounts;

    static public long amounts
    {
        get { return m_amounts; }
        set { m_amounts = value; }

    }






    static private string m_photo ;

    static public string photo
    {
        get { return m_photo; }
        set { m_photo = value; }

    }



    static private string m_urlsrc;

    static public string urlsrc
    {
        get { return m_urlsrc; }
        set { m_urlsrc = value; }

    }



    static private string m_firstname;

    static public string firstname
    {
        get { return m_firstname; }
        set { m_firstname = value; }

    }



    static private string m_lastname;

    static public string lastname
    {
        get { return m_lastname; }
        set { m_lastname = value; }

    }

    static private string m_honor;

    static public string honor
    {
        get { return m_honor; }
        set { m_honor = value; }

    }






    static private string m_address;

    static public string address
    {
        get { return m_address; }
        set { m_address = value; }

    }





    static private string m_city;

    static public string  city
    {
        get { return m_city; }
        set { m_city = value; }

    }





    static private string m_email;

    static public string  email
    {
        get { return m_email; }
        set { m_email = value; }

    }







    static private string m_state;

    static public string state
    {
        get { return m_state; }
        set { m_state = value; }

    }





    static private string m_phone;

    static public string  phone
    {
        get { return m_phone; }
        set { m_phone = value; }

    }





    static private string m_zipcode;

    static public string zipcode
    {
        get { return m_zipcode; }
        set { m_zipcode = value; }

    }





    static private string m_cardnumber;

    static public string cardnumber
    {
        get { return m_cardnumber; }
        set { m_cardnumber = value; }

    }







    static private string m_expdate;

    static public string expdate
    {
        get { return m_expdate; }
        set { m_expdate = value; }

    }



    

    static private string m_cvv;

    static public string cvv
    {
        get { return m_cvv; }
        set { m_cvv = value; }

    }


    static private string m_CustomerIP;

    static public string  CustomerIP
    {
        get { return m_CustomerIP; }
        set { m_CustomerIP = value; }

    }
















    static private string m_number;

    static public string number
    {
        get { return m_number; }
        set { m_number = value; }

    }


    static private bool m_pro;

    static public bool pro
    {
        get { return m_pro; }
        set { m_pro = value; }

    }

    static private int m_cnt;

    static public int cnt
    {
        get { return m_cnt; }
        set { m_cnt = value; }

    }


    static private bool m_again;

    static public bool again
    {
        get { return m_again; }
        set { m_again = value; }

    }



    static private string m_err;

    static public string err
    {
        get { return m_err; }
        set { m_err = value; }

    }


    static private string m_script;

    static public string script
    {
        get { return m_script; }
        set { m_script = value; }

    }












    public static byte[] SetDpiTo72(this byte[] imageToFit, string mimeType, System.Drawing.Size newSize)
    {
        using (MemoryStream memoryStream = new MemoryStream(), newMemoryStream = new MemoryStream())
        {
            memoryStream.Write(imageToFit, 0, imageToFit.Length/4);
            var originalImage = new Bitmap(memoryStream);

            using (var canvas = Graphics.FromImage(originalImage))
            {
                canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                canvas.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                canvas.DrawImage((System.Drawing.Image)originalImage, 0, 0, newSize.Width, newSize.Height);

                originalImage.SetResolution(72, 72);

                //var epQuality = new System.Drawing.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 75);
                //var epParameters = new EncoderParameters(1);
                //epParameters.Param[0] = epQuality;

                System.Drawing.Image newimg = System.Drawing.Image.FromStream(memoryStream);

                
                //Getting an GDI+ exception after the execution of this line.
                //newimg.Save("C:\\test1234.jpg", ImageFunctions.GetEncoderInfo(mimeType), epParameters);

                //originalImage.Save("test.jpg", ImageFormat.Jpeg);

                //This line give me an Argumentexception - Parameter is not valid.
                //originalImage.Save(newMemoryStream, ImageFunctions.GetEncoderInfo(mimeType), epParameters);
                //newMemoryStream.Close();
            }
            return   newMemoryStream.ToArray();
        }
    }


    //    Image newImage = Image.FromFile("SampImag.jpg");

    //// Create coordinates for upper-left corner of image and for size of image.
    //int x = 0;
    //int y = 0;
    //int width = 450;
    //int height = 150;

    //// Draw image to screen.
    //e.Graphics.DrawImage(newImage, x, y, width, height);



    //private static Bitmap ResizeImage(Image image, int width, int height)
    //{
    //    //var frameCount = image.GetFrameCount(new FrameDimension(image.FrameDimensionsList[0]));
    //    //var newDimensions = ImageFunctions.GenerateImageDimensions(image.Width, image.Height, width, height);
    //    Bitmap resizedImage;

    //    //if (frameCount > 1)
    //    //{
    //    //    //we have a animated GIF
    //    resizedImage = System.Drawing.ResizeAnimatedGifImage(image, width, height);
    //    //}
    //    //else
    //    //{
    //     //  resizedImage = (Bitmap)image.GetThumbnailImage(newDimensions.Width, newDimensions.Height, null, IntPtr.Zero);
    //    //}

    //     resizedImage.SetResolution(72, 72);

    //    return resizedImage;
    //}





    //private static Bitmap ResizeImage(Image image, int width, int height)
    //{
    //    var frameCount = image.GetFrameCount(new FrameDimension(image.FrameDimensionsList[0]));
    //    var newDimensions = ImageFunctions.GenerateImageDimensions(image.Width, image.Height, width, height);

    //    var resizedImage = new Bitmap(newDimensions.Width, newDimensions.Height);
    //    if (frameCount > 1)
    //    {
    //        //we have a animated GIF
    //        resizedImage = ResizeAnimatedGifImage(image, width, height);
    //    }
    //    else
    //    {

    //        //we have a normal image
    //        using (var gfx = Graphics.FromImage(resizedImage))
    //        {
    //            gfx.SmoothingMode = SmoothingMode.HighQuality;
    //            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //            gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;

    //            var targRectangle = new Rectangle(0, 0, newDimensions.Width, newDimensions.Height);
    //            var srcRectangle = new Rectangle(0, 0, image.Width, image.Height);

    //            gfx.DrawImage(image, targRectangle, srcRectangle, GraphicsUnit.Pixel);
    //        }
    //    }

    //    return resizedImage;
    //}


}

public class array_list 
{

    public ArrayList arl = new ArrayList();







  public string[] ardonateimagesrc = new string[101];



  public string[] ardonateImgPhotoSrc = new string[101];


  public string[] ardonateImgNpage = new string[101];


  public string[] ardonateImgText = new string[101];

  public string[] ardonateImgAmt = new string[101];


  public string[] ardonateImgNumber = new string[101];


  public string[] ardonateImgName = new string[101];

  public string[] ardonateImgPhoto = new string[101];













}
public static class xml_list
{
    public static int indexPage;
    public static int indexSection;
    public static int xmlcnt;
    public static ArrayList xmlarl = new ArrayList();

    public static string[] ardonateimagesrc = new string[101];

    public static string[] ardonateImgPhotoSrc = new string[101];


    public static string[] ardonateImgNpage = new string[101];


    public static string[] ardonateImgText = new string[101];

    public static string[] ardonateImgAmt = new string[101];


    public static string[] ardonateImgNumber = new string[101];


    public static string[] ardonateImgName = new string[101];

    public static string[] ardonateImgPhoto = new string[101];



}
////class Program
////{ 
////    static void Main(string[] args)
////    {
        
////        //Document document = new Document();
////        //using (var stream = new FileStream("test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
////        //{
////        //    PdfWriter.GetInstance(document, stream);
////        //    document.Open();
////        //    using (var imagestream = new FileStream("test.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
////        //    {
////        //        var image = Image.GetInstance(imagestream);
////        //        document.Add(image);
////        //    }
////        //    document.Close();
////        //}
////    }
////}










///     getDataSet(ref <code>dsHesapPlan);

// Set the path of the rdlc document
////////// string reportPath = "Report.rdlc";

// Initiate ReportViewer object
// ReportViewer1 rView = new ReportViewer1();

////////ReportViewer1.LocalReport.DataSources.Add( new  Microsoft.Reporting.WebForms.ReportDataSource("table",ds.Tables[0])  );

////////ReportViewer1.LocalReport.ReportPath = reportPath;

////////ReportViewer1.DataBind();



//rView.Dock = DockStyle.Fill;
//this.Controls.Add(rView);

//// Add data source to the local report
//// Note that the name should either be passed as parameter or 
//// parsed from the report document
//rView.LocalReport.DataSources
//       .Add(new ReportDataSource("HESAP_PLAN_dtLast", dsHesapPlan.Tables[0]));

//// Set the active report path of the ReportViewer object
//rView.LocalReport.ReportPath = reportPath;









//////////// WebService2 ws = new WebService2();


//////////// string ii = ws.HelloWorld();

//////////// WebService1 ws2 = new WebService1();


//////////// ArrayList iil = ws2.GetClien(5);


//////////// AsyncCallback cb;

//////////// object ass;


//////////// object[] al = (object[])WebService11.GetClien(5);

////////////ClientDataw ss= ( ClientDataw )al[0] ;

////////////       string name=    ss.Name;



////////////       string aldd = (string)WebService11.Gevald();


//          * ++++++++++++++++++++++**************




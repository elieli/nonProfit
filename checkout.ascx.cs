using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Mail;
using Lib;
 
    

    /// <summary>
    ///		Summary description for checkout.
    /// </summary>
    public partial  class checkout : System.Web.UI.UserControl
    {
        BLCustomer cust;
        private bool personalizeOrder;

        #region AppSettings
        private string emailNotificationCustomerFrom = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerFrom");
        private string emailNotificationCustomerTo   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerTo");
        private string emailNotificationCustomerCc   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerCc");
        private string emailNotificationCustomerBcc  = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerBcc");
        private string emailNotificationVendorFrom = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorFrom");
        private string emailNotificationVendorTo   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorTo");
        private string emailNotificationVendorCc   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorCc");
        private string emailNotificationVendorBcc  = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorBcc");
        private string emailNotificationWebMasterFrom = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterFrom");
        private string emailNotificationWebMasterTo   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterTo");
        private string emailNotificationWebMasterCc   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterCc");
        private string emailNotificationWebMasterBcc  = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterBcc");
        private bool emailNotification = ((string)ConfigurationSettings.AppSettings.Get("emailNotification")=="yes");

        private decimal ccSurchargeVISA  = Convert.ToDecimal(ConfigurationSettings.AppSettings.Get("CCSurchargeVISA"));
        private decimal ccSurchargeMC  = Convert.ToDecimal(ConfigurationSettings.AppSettings.Get("CCSurchargeMC"));
        private decimal ccSurchargeDISCOVER  = Convert.ToDecimal(ConfigurationSettings.AppSettings.Get("CCSurchargeDISCOVER"));
        private decimal ccSurchargeAMEX  = Convert.ToDecimal(ConfigurationSettings.AppSettings.Get("CCSurchargeAMEX"));

        private string siteName = (string)ConfigurationSettings.AppSettings.Get("siteName");
        private string smtpServer = (string)ConfigurationSettings.AppSettings.Get("smtpServer");

        private string upsLicenseNum = (string)ConfigurationSettings.AppSettings.Get("UpsLicenseNum");
        private string upsUID = (string)ConfigurationSettings.AppSettings.Get("UpsUID");
        private string upsPassword = (string)ConfigurationSettings.AppSettings.Get("UpsPassword");
        private decimal upsAddressValidQuality = decimal.Parse((string)ConfigurationSettings.AppSettings.Get("UpsAddressValidQuality"));
        private int upsShipperPostCode = int.Parse((string)ConfigurationSettings.AppSettings.Get("UpsShipperPostCode"));
        private int upsShipFromPostCode = int.Parse((string)ConfigurationSettings.AppSettings.Get("UpsShipFromPostCode"));
        #endregion

        #region Controls
        //        protected System.Web.UI.WebControls.TextBox email00;
        //        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorEmail00;
        //        protected System.Web.UI.WebControls.RegularExpressionValidator RegularexpressionvalidatorEmail00;
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
		
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.CustomValidatorCardNumber.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.CustomValidatorCardNumber_ServerValidate);
			this.goToNext.Click += new System.Web.UI.ImageClickEventHandler(this.goToNext_Click);
			this.goToBack00.Click += new System.Web.UI.ImageClickEventHandler(this.goToBack00_Click);
			this.goToNext00.Click += new System.Web.UI.ImageClickEventHandler(this.goToNext00_Click);
			this.goToBack01.Click += new System.Web.UI.ImageClickEventHandler(this.goToBack01_Click);
			this.goToNext01.Click += new System.Web.UI.ImageClickEventHandler(this.goToNext01_Click);

		}
        #endregion

        public int orderId;

        private decimal upsAddrValidationQuality;

        protected void Page_Load(object sender, System.EventArgs e)
        {
			/*if(!this.Request.IsSecureConnection)
				Response.Redirect(Request.Url.PathAndQuery,true);*/
            //((index)this.Page).shoppingCart.CustomerID = custID;
            cust.ShoppingCart.Retrieve();
			
            if (cust.ShoppingCart.ItemsCount<=0)
            {
                Itemspanel.Visible=false;
                NoItemspanel.Visible=true;
            }
            else
            {
                if(!Page.IsPostBack)
                {
                    month.DataSource = lib.CreateMonths();
                    month.DataTextField="Text";
                    month.DataValueField="Value";
                    month.DataBind();

                    //					sdmonth.DataSource = lib.CreateMonths();
                    //					sdmonth.DataTextField="Text";
                    //					sdmonth.DataValueField="Value";
                    //					sdmonth.DataBind();

                    year.DataSource = lib.CreateYears(0,10,1);
                    year.DataTextField="Text";
                    year.DataValueField="Value";
                    year.DataBind();

                    //					sdyear.DataSource = lib.CreateYears(0,-10,-1);
                    //					sdyear.DataTextField="Text";
                    //					sdyear.DataValueField="Value";
                    //					sdyear.DataBind();

                    country.DataSource = lib.CreateCountries();
                    country.DataTextField="Text";
                    country.DataValueField="Value";
                    country.DataBind();
                    country.SelectedValue = "US";

                    country00.DataSource = lib.CreateCountries();
                    country00.DataTextField="Text";
                    country00.DataValueField="Value";
                    country00.DataBind();
                    country00.SelectedValue = "US";
					
                    /*foreach( ShipmentService service in UPSShipmentService.Services )
						ddlUPSShipServ.Items.Add(new ListItem("UPS " + service.Name + " [US Only]", service.Value));*/
					//start temporary shiping methods until wheights can be established
					ddlUPSShipServ.Items.Add(new ListItem("USPS Or Cheapest Method", "USPS"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Next Day Air", "Next Day Air"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Second Day Air", "2 Day Air"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Third Day Air", "3 Day Air"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Ground", "Ground"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Next Day Air COD ($8.50 Additional Charge Applies)", "Next Day Air COD"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Second Day Air COD ($8.50 Additional Charge Applies)", "2 Day Air COD"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Third Day Air COD ($8.50 Additional Charge Applies)", "3 Day Air COD"));
					ddlUPSShipServ.Items.Add(new ListItem("UPS Ground COD ($8.50 Additional Charge Applies)", "Ground COD"));
					//End temp Sipping Methods
					ddlUPSShipServ.Items.Add(new ListItem("Pick-up by customer", "customer"));
                    ddlUPSShipServ.Items.Add(new ListItem("--Other--", "other"));

                    FillFields();
                }

					
            }
        }

		private void AlternetePayMethods()
		{
			try
			{
				if (int.Parse(this.PayementMethod.Value) == 2)
				{	
					lblPayMethod.Text = "";
					this.RequiredfieldvalidatorCreditCard.Enabled = false;
					this.RequiredfieldvalidatorExpDateMonth.Enabled = false;
					this.RequiredfieldvalidatorExpDateYear.Enabled = false;
					this.CustomValidatorCardNumber.Enabled = false;
					this.RequiredFieldValidatorCardNumber.Enabled = false;
					this.cardNumber.Text = "Please Enter Number";
					this.month.SelectedIndex = 1;
					this.year.SelectedValue = Convert.ToString(DateTime.Now.Year);
				}
				else
				{
					lblPayMethod.Text = "";
					this.RequiredfieldvalidatorCreditCard.Enabled = true;
					this.RequiredfieldvalidatorExpDateMonth.Enabled = true;
					this.RequiredfieldvalidatorExpDateYear.Enabled = true;
					this.CustomValidatorCardNumber.Enabled = true;
					this.RequiredFieldValidatorCardNumber.Enabled = true;
				}
			}
			catch
			{
				lblPayMethod.Text = "Must Select a payment Method.";
			}
		}
        protected void Page_PreRender(object sender, System.EventArgs e)
        {
            
        }

        protected void rptProductList_Bind()
        {
            DataSet dsProductList = null;
            //cust.ShoppingCart.CustomerID = custID;
            cust.ShoppingCart.Retrieve();
            dsProductList = cust.ShoppingCart.Products;
            rptProductList.DataSource = dsProductList.Tables["ShoppingCart"];
            rptProductList.DataBind();
        }

        protected void rptProductList_OnItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            switch(e.Item.ItemType)	
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:

                    HtmlAnchor aProductName = (HtmlAnchor) e.Item.FindControl("aProductName");
                    HtmlAnchor aImghref = (HtmlAnchor) e.Item.FindControl("aImghref");
                    HtmlImage imgList = (HtmlImage) e.Item.FindControl("imgList");
					
                    HtmlGenericControl spanProductPrice = (HtmlGenericControl) e.Item.FindControl("spanProductPrice");
                    HtmlGenericControl spanQuantity = (HtmlGenericControl) e.Item.FindControl("spanQuantity");
                    HtmlGenericControl spanPersonalize = (HtmlGenericControl) e.Item.FindControl("spanPersonalize");
                    HtmlGenericControl spanProductTotalPrice = (HtmlGenericControl) e.Item.FindControl("spanProductTotalPrice");
                    ImageButton btnQuantityUpdate = (ImageButton) e.Item.FindControl("btnQuantityUpdate");

                    aProductName.InnerText = ((DataRowView)e.Item.DataItem)["ProductName"].ToString();
                    aProductName.HRef = ".?page=detail&id=8&idp="+((DataRowView)e.Item.DataItem)["ProductID"].ToString();
                    aImghref.HRef = aProductName.HRef;
                    spanProductPrice.InnerText = ((decimal)((DataRowView)e.Item.DataItem)["ProductPrice"]).ToString("c");
                    spanQuantity.InnerText = ((DataRowView)e.Item.DataItem)["Quantity"].ToString();
                    spanPersonalize.InnerHtml = (bool)((DataRowView)e.Item.DataItem)["Personalize"] ? ((decimal)((DataRowView)e.Item.DataItem)["ProductPersPrice"]).ToString("c") : "&nbsp;";
                    spanProductTotalPrice.InnerText = (((decimal)((DataRowView)e.Item.DataItem)["ProductPrice"] ) * (int)((DataRowView)e.Item.DataItem)["Quantity"] + ((bool)((DataRowView)e.Item.DataItem)["Personalize"] ? (decimal)((DataRowView)e.Item.DataItem)["ProductPersPrice"] : 0)).ToString("c");

					if((bool)((DataRowView)e.Item.DataItem)["Personalize"])
					{	
						personalizeOrder = true;
						this.Context.Session.Add("personalizeOrder",personalizeOrder);
					}
					else
						this.Context.Session.Add("personalizeOrder",false);
                    //personalizeOrder = (bool)((DataRowView)e.Item.DataItem)["Personalize"] ?  (bool)((DataRowView)e.Item.DataItem)["Personalize"] : personalizeOrder;
					
					personalizeOrder = 	(bool)((DataRowView)e.Item.DataItem)["Personalize"];
					
					
                   
                    break;
            }
        }

        private void GetFromLogin()
        {
            try
            {
                if(Request.Cookies["Forum"]["UserID"] != null)
                {
                    SqlConnection sqlConnection = new SqlConnection();
                    sqlConnection.ConnectionString = ConfigurationSettings.AppSettings["SqlConnectionStringShof"]; 
                    sqlConnection.Open();

					bool IsWife;
					if(Request.Cookies["forum"]["who"].Trim() == "wife")
						IsWife = true;
					else
						IsWife = false;

                    string strLoggedInUserCode = Request.Cookies["forum"]["shID"];
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM [d_Shluchim] WHERE Shluach=" + strLoggedInUserCode,
                        sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
					SqlCommand CommandMosad = new SqlCommand("SELECT * FROM d_Mosdos "
						+ "WHERE Shluach = " + strLoggedInUserCode,sqlConnection);
					SqlDataReader MosadReader = CommandMosad.ExecuteReader();

                    SqlDataReader typeList = sqlCommand.ExecuteReader();
                    if(typeList.Read())
                    {
						if(IsWife)
							firstName.Text = typeList["WifeName"].ToString();
						else
                            firstName.Text = typeList["FirstName"].ToString();

						if(MosadReader.Read())
						{
							this.address1.Text = MosadReader["address"].ToString();
							town.Text = MosadReader["City"].ToString();
							state.Text = MosadReader["State"].ToString();
							postcode.Text = MosadReader["ZipCode"].ToString();
							try
							{
								country.SelectedValue = Lib.lib.GetMyCountry(MosadReader["Country"].ToString());
							}
							catch{}
							phoneNumber.Text = MosadReader["Phone"].ToString();
							faxNumber.Text = MosadReader["Fax"].ToString();

						}
						else
						{
							address1.Text = typeList["Address"].ToString();
							town.Text = typeList["City"].ToString();
							try
							{
								state.Text = typeList["State"].ToString();
							}
							catch{}
							postcode.Text = typeList["ZipCode"].ToString();
							try
							{
								country.SelectedValue = Lib.lib.GetMyCountry(typeList["Country"].ToString());
							}
							catch{}
							phoneNumber.Text = typeList["Phone"].ToString();
							faxNumber.Text = typeList["Fax"].ToString();
						}

                        lastName.Text = typeList["LastName"].ToString();
                        
                       
                        
						if(IsWife)
							email.Text = typeList["WEmail"].ToString();
						else
                            email.Text = typeList["Email"].ToString();
                        
                    }
                    typeList.Close();
                    sqlConnection.Close();
                }
            }
            catch{}
        }
        
        private void FillFields()
        {
            try
            {
                if(Request.Cookies["Forum"]["UserID"] == null)
                    return;
            }
            catch{return;}

            BLCustomer customerInfo = cust;

            saveDetails.Checked = customerInfo.SaveInfo;

            if (customerInfo.SaveInfo) 
            {
                try
                {
                    creditCard.SelectedValue = customerInfo.CreditCard.CardType;
                }
                catch{}
                cardNumber.Text = customerInfo.CreditCard.CardNumber;
                //					try
                //					{
                //						if customerInfo.CreditCard.Startdate!=DateTime.MinValue)
                //							sdyear.SelectedValue = customerInfo.CreditCard.Startdate.Year.ToString();
                //					}
                //					catch{}
                //					try
                //					{
                //						if customerInfo.CreditCard.Startdate!=DateTime.MinValue)
                //							sdmonth.SelectedValue = customerInfo.CreditCard.Startdate.Month.ToString();
                //					}
                //					catch{}
                try
                {
                    if (customerInfo.CreditCard.ExpiryDate!=DateTime.MinValue)
                        year.SelectedValue = customerInfo.CreditCard.ExpiryDate.Year.ToString();
                }
                catch{}
                try
                {
                    if (customerInfo.CreditCard.ExpiryDate!=DateTime.MinValue)
                        month.SelectedValue = customerInfo.CreditCard.ExpiryDate.Month.ToString();
                }
                catch{}
                //					issueNumber.Text = customerInfo.CreditCard.IssueNumber;

                firstName.Text = customerInfo.BillingAddress.FirstName;
                lastName.Text = customerInfo.BillingAddress.LastName;
                company.Text = customerInfo.BillingAddress.Company;
                address1.Text = customerInfo.BillingAddress.Address1;
                address2.Text = customerInfo.BillingAddress.Address2;
                town.Text = customerInfo.BillingAddress.City;
                state.Text = customerInfo.BillingAddress.State;
                postcode.Text = customerInfo.BillingAddress.PostCode;
                try
                {
                    country.SelectedValue = country.Items.FindByText(customerInfo.BillingAddress.Country).Value;
                }
                catch{}
                phoneNumber.Text = customerInfo.BillingAddress.Phone;
                faxNumber.Text = customerInfo.BillingAddress.Fax;
                email.Text = customerInfo.BillingAddress.EMail;

                firstName00.Text = customerInfo.ShippingAddress.FirstName;
                lastName00.Text = customerInfo.ShippingAddress.LastName;
                company00.Text = customerInfo.ShippingAddress.Company;
                address100.Text = customerInfo.ShippingAddress.Address1;
                address200.Text = customerInfo.ShippingAddress.Address2;
                town00.Text = customerInfo.ShippingAddress.City;
                state00.Text = customerInfo.ShippingAddress.State;
                postcode00.Text = customerInfo.ShippingAddress.PostCode;
                try
                {
                    country00.SelectedValue = country00.Items.FindByText(customerInfo.ShippingAddress.Country).Value;
                }
                catch{}
                //                phoneNumber00.Text = customerInfo.ShippingAddress.Phone;
                //                faxNumber00.Text = customerInfo.ShippingAddress.Fax;
                //                email00.Text = customerInfo.ShippingAddress.EMail;
                if( customerInfo.ShippingAddress.Field1 == "Other" )
                { 
                    ddlUPSShipServ.SelectedValue = "other";
                    //txtShippingComment.Text = customerInfo.ShippingAddress.Field2;
                    txtShippingComment.Enabled = true;
                }
                else
                {
					try
					{
						ddlUPSShipServ.SelectedValue = customerInfo.ShippingAddress.Field4;
					}
					catch
					{
						ddlUPSShipServ.SelectedValue = "USPS";
					}
                }

                sameAsBilling.Checked = customerInfo.ShippingAddress.ID == 0;
            }
            else
            {
                GetFromLogin();
            }
        }

        private void SaveFields()
        {
            BLCustomer customerInfo = cust;

            customerInfo.SaveInfo = saveDetails.Checked;

            customerInfo.CreditCard.ID = 0;
            customerInfo.CreditCard.CardHolder = firstName.Text+" "+lastName.Text;
            customerInfo.CreditCard.CardType = creditCard.SelectedValue;
            customerInfo.CreditCard.CardNumber = cardNumber.Text.Replace("-","").Replace(" ","");
			if(this.txtbCvv.Text != string.Empty)
			{
				customerInfo.CreditCard.CVV = this.txtbCvv.Text;
			}
            //				try
            //				{
            //					customerInfo.CreditCard.Startdate = new DateTime(Convert.ToInt32(sdyear.SelectedValue),Convert.ToInt32(sdmonth.SelectedValue),1);
            //				}
            //				catch{}
            try
            {
                customerInfo.CreditCard.ExpiryDate = new DateTime(Convert.ToInt32(year.SelectedItem.Value),Convert.ToInt32(month.SelectedValue),1);
            }
            catch{}
            //				customerInfo.CreditCard.IssueNumber = issueNumber.Text;
			if(int.Parse(this.PayementMethod.Value) == 2)
			{
				customerInfo.CreditCard.CardType = "";
			}
			customerInfo.CreditCard.Update();

            customerInfo.BillingAddress.FirstName = firstName.Text;
            customerInfo.BillingAddress.LastName = lastName.Text;
            customerInfo.BillingAddress.Company = company.Text;
            customerInfo.BillingAddress.Address1 = address1.Text;
            customerInfo.BillingAddress.Address2 = address2.Text;
            customerInfo.BillingAddress.City = town.Text;
            customerInfo.BillingAddress.State = state.Text;
            customerInfo.BillingAddress.PostCode = postcode.Text;
            customerInfo.BillingAddress.Country = (country.SelectedValue==""?"":country.SelectedItem.Text);
            customerInfo.BillingAddress.Phone = phoneNumber.Text;
            customerInfo.BillingAddress.Fax = faxNumber.Text;
            customerInfo.BillingAddress.EMail = email.Text;
			
            customerInfo.BillingAddress.Update();

            //			if (!sameAsBilling.Checked) 
            //			{
            customerInfo.ShippingAddress.FirstName = firstName00.Text;
            customerInfo.ShippingAddress.LastName = lastName00.Text;
            customerInfo.ShippingAddress.Company = company00.Text;
            customerInfo.ShippingAddress.Address1 = address100.Text;
            customerInfo.ShippingAddress.Address2 = address200.Text;
            customerInfo.ShippingAddress.City = town00.Text;
            customerInfo.ShippingAddress.State = state00.Text;
            customerInfo.ShippingAddress.PostCode = postcode00.Text;
            customerInfo.ShippingAddress.Country = (country00.SelectedValue==""?"":country00.SelectedItem.Text);
            //            customerInfo.ShippingAddress.Phone = phoneNumber00.Text;
            //            customerInfo.ShippingAddress.Fax = faxNumber00.Text;
            //            customerInfo.ShippingAddress.EMail = email00.Text;

			switch( ddlUPSShipServ.SelectedValue )
			{
				case "other":
					customerInfo.ShippingAddress.Field1 = "Other";
					customerInfo.ShippingAddress.Field2 = txtShippingComment.Text;
					break;
				case "customer":
					customerInfo.ShippingAddress.Field1 = "Customer";
					customerInfo.ShippingAddress.Field2 = ddlUPSShipServ.SelectedItem.Text;
					break;
				/*default:
					customerInfo.ShippingAddress.Field1 = "UPS";
					customerInfo.ShippingAddress.Field2 = ddlUPSShipServ.SelectedItem.Text;
					//customerInfo.ShippingAddress.Field3 = this.upsAddrValidationQuality.ToString();
					customerInfo.ShippingAddress.Field4 = ddlUPSShipServ.SelectedValue;
					break;*/
				default:
					customerInfo.ShippingAddress.Field1 = this.ddlUPSShipServ.SelectedValue;
					customerInfo.ShippingAddress.Field2 = this.txtShippingComment.Text;
					break;
			}

            customerInfo.ShippingAddress.Update();
            //			} 
            //			else 
            //			{
            //				customerInfo.ShippingAddress.ID = 0;
            //			}

            customerInfo.Update();
        }

        private void goToNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
			AlternetePayMethods();
            if (Page.IsValid) 
            {
                billing.Visible=false;
                if (sameAsBilling.Checked)
                {
                    //					confirmation.Visible=true;
                    //					confShipping.Visible=!sameAsBilling.Checked;
                    firstName00.Text = firstName.Text;
                    lastName00.Text = lastName.Text;
                    company00.Text = company.Text;
                    address100.Text = address1.Text ;
                    address200.Text = address2.Text ;
                    town00.Text = town.Text;
                    state00.Text = state.Text;
                    postcode00.Text = postcode.Text;
                    country00.SelectedValue = country.SelectedValue;
                    //                    phoneNumber00.Text = phoneNumber.Text;
                    //                    faxNumber00.Text = faxNumber.Text;
                    //                    email00.Text = email.Text;
                }
                //				else
                //				{
                shipping.Visible=true;
                //				}

                SaveFields();
            }
        }

        private void goToBack00_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            shipping.Visible=false;
            billing.Visible=true;
            SaveFields();
        }

        private void goToNext01_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Page.IsValid && cust.ShoppingCart.ItemsCount>0)
            {
                
                SaveFields();
                decimal shipmentCharges = 0;
                try
                {
                    shipmentCharges = decimal.Parse((string)ViewState["upsShipmentCharges"]);
                }
                catch{}
				decimal totalCCSurcharge = cust.ShoppingCart.GetTotalCCSurcharge(getCCSurcharge()) + shipmentCharges * getCCSurcharge();
				if(int.Parse(this.PayementMethod.Value) == 2)
                    totalCCSurcharge = 0;                
                this.orderId = BLOrders.Create(cust.ID, totalCCSurcharge, shipmentCharges);
                if (this.orderId>0)
                {
                    if (emailNotification)
                    {
                        StringWriter writer = new StringWriter();
                        Server.Execute("email/emailNewOrder.aspx?oid="+this.orderId.ToString(), writer);
                        string strhtmlbody = writer.ToString();
                        //                        Response.Write(strhtmlbody);
                        //                        Response.End();
                        MailMessage objMailMessage = new MailMessage();
                        objMailMessage.Subject = this.lastName.Text+", " + this.firstName.Text + " " + this.state.Text + ", Order #" + this.orderId;
                        objMailMessage.From = this.emailNotificationCustomerFrom;
                        objMailMessage.To = email.Text;
                        objMailMessage.Cc = this.emailNotificationCustomerCc;
                        objMailMessage.Bcc = this.emailNotificationCustomerBcc;
                        objMailMessage.Body = strhtmlbody;
                        objMailMessage.BodyFormat = MailFormat.Html;
                        SmtpMail.SmtpServer = this.smtpServer;
                        SmtpMail.Send( objMailMessage );
						
                        cust.ShoppingCart.Retrieve();
                        DataView dvProductList = cust.ShoppingCart.Products.Tables[0].DefaultView;
                        dvProductList.RowFilter = "ProductInventory <= ProductReorder";
				
                        if (dvProductList.Count>0)
                        {
                            StringWriter writer1 = new StringWriter();
                            Server.Execute("email/emailReorder.aspx?cid="+cust.ID.ToString(), writer1);
                            strhtmlbody = writer1.ToString();
                            //                            Response.Write(strhtmlbody);
                            //                            Response.End();
                            objMailMessage = new MailMessage();
                            objMailMessage.Subject = siteName+": Reorder products";
                            objMailMessage.From = this.emailNotificationVendorFrom;
                            objMailMessage.To = this.emailNotificationVendorTo;
                            objMailMessage.Cc = this.emailNotificationVendorCc;
                            objMailMessage.Bcc = this.emailNotificationVendorBcc;
                            objMailMessage.Body = strhtmlbody;
                            objMailMessage.BodyFormat = MailFormat.Html;
                            SmtpMail.SmtpServer = this.smtpServer;
                            SmtpMail.Send( objMailMessage );
                        }
                    }
                    spanThankNameSite.InnerText = (string)ConfigurationSettings.AppSettings.Get("siteName");
                    BLOrders order = new BLOrders();
                    order.ID = this.orderId;
                    order.Retrieve();
                    if (Session["personalizeOrder"] != null && (bool)Session["personalizeOrder"] == true) 
                    {
                        aPersonalizeOrder.HRef = new Uri(Page.Request.Url,"index.aspx?page=orderpersonalize&uid="+order.UID).ToString();
                        pnPersonalizeOrder.Visible = true;
                    } 
                     cust.ShoppingCart.Clear();

                    confirmation.Visible=false;
                    this.aPrintOrder.Attributes["onclick"] = "window.open('orderprint.aspx?uid="+order.UID+"', 'anew', config='toolbar=no, menubar=no, resizable=yes, scrollbars=yes');";
                    thankyou.Visible=true;
                }
            }
        }

        private void goToBack01_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //			if (sameAsBilling.Checked)
            //			{
            //				billing.Visible=true;
            //				confirmation.Visible=false;
            //			}
            //			else
            //			{
            shipping.Visible=true;
            confirmation.Visible=false;
            //			}
        }

        private decimal getCCSurcharge()
        {
            switch (creditCard.SelectedValue)
            {
                case "VISA":
                    return ccSurchargeVISA;
                case "MC":
                    return ccSurchargeMC;
                case "DISCOVER":
                    return ccSurchargeDISCOVER;
                case "AMEX":
                    return ccSurchargeAMEX;
            }
            return 0;
        }

        private void goToNext00_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            decimal totalCCSurcharge = cust.ShoppingCart.GetTotalCCSurcharge(getCCSurcharge());
            decimal totalPrice = cust.ShoppingCart.TotalPrice;
            if (Page.IsValid)
            {
                 cust.ShoppingCart.Retrieve();
			/*	UPS Validation
			 * if( this.ddlUPSShipServ.SelectedValue != "other" && this.ddlUPSShipServ.SelectedValue != "customer" )
				{
					UPSAddressValidation validation = new UPSAddressValidation(this.upsLicenseNum, this.upsUID, this.upsPassword);
					validation.City = town00.Text;
					validation.StateProvinceCode = state00.Value;
					try
					{
						validation.ZipCode = int.Parse(postcode00.Text);
					}
					catch{}
					if (validation.ValidateAddress())
					{
						if (Convert.ToDecimal(validation.Quality) >= this.upsAddressValidQuality)
						{
							UPSShippingRate rate = new UPSShippingRate(this.upsLicenseNum, this.upsUID, this.upsPassword);
							rate.ShipperPostCode = this.upsShipperPostCode;
							rate.ShipFromPostCode = this.upsShipFromPostCode;
							try
							{
								rate.ShipToPostCode = int.Parse(postcode00.Text);
							}
							catch{}
                        
							rate.Packages.Add(new UPSPackage(Convert.ToSinglecust.ShoppingCart.TotalWeight), "02"));
							rate.ShipmentServiceCode = ddlUPSShipServ.SelectedValue;

							if (rate.GetShipmentCharges())
							{
								totalCCSurcharge += (decimal)rate.TotalCharges.MoneyValue * getCCSurcharge();
								spanCCSurcharge.InnerText = totalCCSurcharge.ToString("c");
								spanShippingCharges.InnerText = rate.TotalCharges.MoneyValue.ToString("c");
								spanTotalPrice.InnerText = (totalPrice + totalCCSurcharge + (decimal)rate.TotalCharges.MoneyValue).ToString("c");
								trShippingCharges.Visible = true;
								ViewState["upsShipmentCharges"] = rate.TotalCharges.MoneyValue.ToString();
							}
							else
							{
								lblShippingError.Visible = true;
								lblShippingError.Text = "UPS Shipping Charges Calculation Error: " + rate.ErrorText;
								return;
							}
						}
						else
						{
							lblShippingError.Visible = true;
							lblShippingError.Text = "UPS Address Validation Result: " + lib.GetUPSAddressValidationDescription(validation.Quality);
							return;
						}
						this.upsAddrValidationQuality = Convert.ToDecimal(validation.Quality);
						lblUPSAddrVaildationResult.Visible = true;
						lblUPSAddrVaildationResult.Text = "UPS Address Validation Result: " + lib.GetUPSAddressValidationDescription(validation.Quality);
					}
					else
					{
						lblShippingError.Visible = true;
						lblShippingError.Text = "UPS Address Validation Error: " + validation.ErrorText;
						return;
					}
				}
				else */if( /*this.ddlUPSShipServ.SelectedValue == "customer"*/ this.ddlUPSShipServ.SelectedValue != "other" )
				{					
					trShippingCharges.Visible = true;
					//temp fix for shipping charges
					if(this.ddlUPSShipServ.SelectedValue == "customer")
						spanShippingCharges.InnerText = 0.ToString("c");
					else
						spanShippingCharges.InnerText = "Shipping Charges will be added";
				}
                else
                {
                    spanCCSurcharge.InnerText = totalCCSurcharge.ToString("c");
                    spanTotalPrice.InnerText = (totalPrice + totalCCSurcharge).ToString("c");
                    trShippingCharges.Visible = false;
                }
				this.lblSubTotal.Text = totalPrice.ToString("c");
				
				this.spanTotalPrice.InnerText = totalPrice.ToString("c");
				//temp instructions
				if(int.Parse(PayementMethod.Value) == 2)
					spanCCSurcharge.InnerText = "No credit card surcharge";
				else
					spanCCSurcharge.InnerText = "Thus Far " + totalCCSurcharge.ToString("c");
				if(int.Parse(PayementMethod.Value) == 2 && this.ddlUPSShipServ.SelectedValue == "customer")
                    this.spanTotalPrice.InnerText = totalPrice.ToString("c");
				else
					spanTotalPrice.InnerText ="Will be determined at shipping";
                //end temp
				rptProductList_Bind();
                spanItemsCount.InnerText = cust.ShoppingCart.ItemsCount.ToString();

                shipping.Visible=false;
                confirmation.Visible=true;

                SaveFields();
            }
        }

		
        private void CustomValidatorCardNumber_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string cardNumber = this.cardNumber.Text.Trim();
            if (creditCard.SelectedIndex > 0 && cardNumber.Length > 0)
                switch (creditCard.SelectedValue)
                {
                    case "VISA":
                        args.IsValid = cardNumber[0] == '4';
                        return;
                    case "MC":
                        args.IsValid = cardNumber[0] == '5';
                        return;
                    case "AMEX":
                        args.IsValid = cardNumber[0] == '3';
                        return;
                    case "DISCOVER":
                        args.IsValid = cardNumber[0] == '6';
                        return;
                    default:
                        args.IsValid = false;
                        return;
                }
            args.IsValid = true;
        }
    }
//}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Collections;

//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Summary description for BLCustomer.
	/// </summary>
	public class BLCustomer
    {
        Referrer r = new Referrer();
		#region Fields
        private string name;
        private int id;
        private decimal credits;
		private DateTime created;
        private DataSet allorgs;
        private DataSet custinfo;
		private string uid;
		private BLCreditCard creditCard;
		private BLAddress billingAddress;
		private BLAddress shippingAddress; 
		private BLShoppingCart shoppingCart;
        private BLOrganization organization;
        private BLOrganization organizationhld;
 
        private  ArrayList  organizationhldr ;

		private bool saveInfo;
		
		#endregion
		
		#region Properties
		
		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}





        private String signedinorgName;
        public String signedinOrgName
        {
            get { return signedinorgName; }
            set { signedinorgName = value; }
        }


        
        private int signedinorgID;
        public int signedInorgID
        {
            get { return signedinorgID; }
            set { signedinorgID = value; }
        }








        public DataSet Custinfo
        {
            get { return custinfo; }
            set { custinfo = value; }
        }






        public DataSet allOrgs
        {
            get { return allorgs; }
            set { allorgs = value; }
        }

        
        
        
        
        
        
        
        public int Organizationhlder
        {
            get
            { return   organizationhldr==null? 0  :        organizationhldr.Count; }
        }



        public BLOrganization Organizationhld 
        {
            get
            {
                if (organizationhldr.Count > 0)
                {
                    organizationhld = (BLOrganization)organizationhldr[organizationhldr.Count-1];
                    organizationhldr.Remove(organizationhld);              
                    return organizationhld;
                }
                else
                { return null; }
            }
            
            set 
            { organizationhld = value;

            if (organizationhldr==null)
            { organizationhldr = new ArrayList(); }
         
            organizationhldr.Add(organizationhld);


           
            }




        }

        public BLOrganization Organization
        {
            get { return organization; }
            set { organization= value; }
        }
		
		public BLShoppingCart ShoppingCart
		{
			get{ return shoppingCart; }
		}
		
		public BLCreditCard CreditCard
		{
			get{ return creditCard; }
			set{ creditCard = value; }
		}

		public BLAddress ShippingAddress
		{
			get{ return shippingAddress; }
			set{ shippingAddress = value; }
		}

		public BLAddress BillingAddress
		{
			get{ return billingAddress; }
			set{ billingAddress = value; }
		}

		public DateTime Created
		{
			get{ return created; }
			set{ created = value; }
		}






        public Decimal CreDits
        {

            set
            {




                int buyerid = this.ID;
                string commandName = "get_Credits";
                string prm = "A";


                credits = r.get_Credits(commandName, prm, buyerid, 0);

                credits = value;
            }



        }





        public Decimal Credits
        {
            get {
            
                
                

                //int buyerid =   this.ID  ;
                //string commandName = "get_Credits";
                //string prm = "E";


                //credits =   r.get_Credits(commandName, prm, buyerid, 0);
                return credits; 
            
            }
            set {
            
                
                

                //int buyerid =   this.ID  ;
                //string commandName = "get_Credits";
                //string prm = "E";


                //credits =   r.get_Credits(commandName, prm, buyerid, 0);

                credits = value;
            }





        }


		public string UID
		{
			get{ return uid; }
			set{ uid = value; }
		}

		public bool SaveInfo
		{
			get{ return saveInfo; }
			set{ saveInfo = value; }
		}

		#endregion

		#region Methods
		
		#region Static Methods



        private   String custname;

        public   String CustName
        {
            get { return    custname; }
            set {  custname = value; }
        }





        public  int buyerID
        {
            get { return  ID; }
            set {  ID = value; }
        }


        public   int signedinorgid
        {
            get { return  signedInorgID; }
            set {  signedInorgID = value; }
        }


        public   String signedinorgname
        {
            get { return  signedinOrgName; }
            set {  signedinOrgName = value; }
        }


		public static DataSet GetCustList(BLCustomer cust,   string commandName, string prm, int id, string buyer_Name, string buyer_email, string buyer_paypalAccount)
		{
            DataSet dts = new DataSet();

         //   dts = messages.cust.getBuyers(prm, commandName, id, "");         
         //messages.cust.Custinfo =dts;


         dts = cust.getBuyers(prm, commandName, id, "");
          cust.Custinfo = dts;


            return dts;// DALCCustomer.GetList();
		}







		public static DataSet GetList()
		{
            DataSet ds = new DataSet();
      


          ds=  messages.cust.UpdateDonate("S", "get_Orgs", 0, "pending");

          messages.cust.allorgs =ds;

             

            return ds;// DALCCustomer.GetList();
		}
		




		public static int Update(int ID, DateTime Created, string UID, int BillingAddressID,
			 int ShippingAddressID, int CreditCardID, bool SaveInfo )
		{
			int returnValue = 0;
			
			returnValue = DALCCustomer.Update(ID, Created, UID, BillingAddressID, ShippingAddressID, CreditCardID, SaveInfo);

			return returnValue;
		}

		public static void Delete(int Id)
		{
			DALCCustomer.Delete(Id);
		}

		#endregion
		
		#region None Static Methods











        protected DataSet UpdateDonate(String parm, string commandtext, int id, string status)
        {



            String orgEmail = ""; // ((HtmlInputControl)this.FindControl("orgEmail")).Value;//   (String)Request.Form["orgEmail"] == null ? "0" : (String)Request.Form["orgEmail"].ToString();)
            // String subtype = ((HtmlInputControl)this.FindControl("orgEmail")).Value;//  (String)Request.Form["subtype"] == null ? "0" : "1";// (String)Request.Form["subtype"] == null ? Request.Form["subtype"].ToString() : Request.Form["subType"].ToString();
            String orgTitle = ""; //  ((HtmlInputControl)this.FindControl("orgTitle")).Value;//  (String)Request.Form["orgTitle"] == null ? (String)Request.Form["orgTitle"].ToString() : (String)Request.Form["orgTitle"].ToString();
            String orgFunct = ""; //  ((HtmlInputControl)this.FindControl("orgFucnionality")).Value;//  (String)Request.Form["orgFucnionality"] == null ? (String)Request.Form["orgFucnionality"].ToString() : (String)Request.Form["orgFucnionality"].ToString();
            String orgDesc = ""; // ((HtmlInputControl)this.FindControl("orgDescription")).Value;//  (String)Request.Form["orgDescription"] == null ? (String)Request.Form["orgDescription"].ToString() : (String)Request.Form["orgDescription"].ToString();
            String orgTaxID = ""; //  ((HtmlInputControl)this.FindControl("orgTaxID")).Value;//  (String)Request.Form["orgTaxID"] == null ? (String)Request.Form["orgTaxID"].ToString() : (String)Request.Form["orgTaxID"].ToString();

            String orgPaypal = ""; //  ((HtmlInputControl)this.FindControl("orgPayPalAccount")).Value;//   (String)Request.Form["orgPayPalAccount"] == null ? (String)Request.Form["orgPayPalAccount"].ToString() : (String)Request.Form["orgPayPalAccount"].ToString();

            String orgLogo = ""; //  ((HtmlInputControl)this.FindControl("orgLogo")).Value;//  (String)Request.Form["orgLogo"] == null ? (String)Request.Form["orgLogo"].ToString() : (String)Request.Form["orgLogo"].ToString();
            String orgVideo = "";
            // String buttonLogo = ""; //  ((HtmlInputControl)this.FindControl("buttonLogo")).Value;//   (String)Request.Form["buttonLogo"] == null ? (String)Request.Form["buttonLogo"].ToString() : (String)Request.Form["buttonLogo"].ToString();

            String orgStatus = status;// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();



            //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

            //if (ConfirmImg!=null) 
            //{
            //    OnSaveClick(buttonLogo);
            //    return;

            //}





            orgStatus = status;// drplstEmailSts.SelectedValue.ToString();







            String prm = parm;






            //}

            // int id = 0;
            /// int Site = 0;// (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
            // String status = "pending";
            status = "";

            DataSet ds = new DataSet();
            //if (prm!="2")  status = drplstEmailSts.SelectedValue=="All" ? String.Empty : drplstEmailSts.SelectedValue  ;
            //if (prm == "8") prm = "2";
            string commandText = "get_Orgs";



            if (prm == "S")
            {
                orgStatus = "All";// drplstEmailSts.SelectedValue.ToString();
                ds = r.getOrgs(commandText,
             prm,
             id,
          orgTitle,
          orgFunct,
          orgDesc,
      orgTaxID,
      orgEmail,
      orgPaypal,
      orgLogo,
      orgStatus,orgVideo );

            }
            else
            {
                r.setOrgs(commandText,
                         prm,
                         id,
                      orgTitle,
                      orgFunct,
                      orgDesc,
                  orgTaxID,
                  orgEmail,
                  orgPaypal,
                  orgLogo,
                  orgStatus,
                  orgVideo,"",""
                 );
                orgStatus = "approved";
                ds = r.getOrgs(commandText,
                         prm,
                         id,
                      orgTitle,
                      orgFunct,
                      orgDesc,
                  orgTaxID,
                  orgEmail,
                  orgPaypal,
                  orgLogo,
                  orgStatus,    "" );

            };





            return ds;


        }









        public  DataSet  getBuyers(String parm, string commandtext, int id, string status)
        {

 
            String orgStatus = status;// (String)Request.Form["orgStatus"] == null ? (String)Request.Form["orgStatus"].ToString() : (String)Request.Form["orgStatus"].ToString();



            //  String ConfirmImg = (String)Request.Form["ConfirmImg"] == null ? (String)Request.Form["ConfirmImg"].ToString() : (String)Request.Form["ConfirmImg"].ToString();

            //if (ConfirmImg!=null) 
            //{
            //    OnSaveClick(buttonLogo);
            //    return;

            //}





            orgStatus = status;// drplstEmailSts.SelectedValue.ToString();







            String prm = parm;


            String buyer_Name = "";

            String buyer_email = "";

            String buyer_paypalAccount = "";

            int buyer_CreditCardInfoID = 0;
            int buyer_BillingAddressID = 0;
            int buyer_ShippingAddressID = 0;
            int Credits = 0;
           // String buyer_email = "";



            //}

            int idd = ID;
            /// int Site = 0;// (int)Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SiteID"]);
            // String status = "pending";
            status = "";
            prm = "S";
            DataSet ds = new DataSet();
            //if (prm!="2")  status = drplstEmailSts.SelectedValue=="All" ? String.Empty : drplstEmailSts.SelectedValue  ;
            //if (prm == "8") prm = "2";
           string commandText = "get_Buyers";

           ds = r.getBuyers(commandText, prm, idd,
		 buyer_Name  ,
		  buyer_email   ,	
          buyer_paypalAccount,
		 buyer_CreditCardInfoID  ,
	  buyer_BillingAddressID    ,
	  buyer_ShippingAddressID   ,	
	  Credits   
	);

        //   Name = ds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();



           CustName = ds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();

           return ds;
        }






















		public int Update()
		{
			int returnValue = 0;

			returnValue = Update(this.id, this.created, this.uid, this.billingAddress.ID, this.ShippingAddress.ID, this.creditCard.ID, this.saveInfo);
			
			this.id = returnValue;

			return returnValue;
		}

		
		public void Delete()
		{
			Delete(this.id);
		}

		public void Retrieve()
		{
			DataSet dsitems;

			if( this.uid.Length > 0 )
				dsitems = DALCCustomer.GetItemBySessionID(this.uid);
 			else
				dsitems = DALCCustomer.GetItem(this.id);

			if( dsitems.Tables.Count > 0 && dsitems.Tables[0].Rows.Count > 0)
			{
				this.id = Convert.ToInt32( dsitems.Tables["Customer"].Rows[0]["ID"] );
				this.uid = Convert.ToString( dsitems.Tables["Customer"].Rows[0]["SessionID"] );
				this.created = Convert.ToDateTime( dsitems.Tables["Customer"].Rows[0]["Created"] );
				this.saveInfo = Convert.ToBoolean( dsitems.Tables["Customer"].Rows[0]["SaveInfo"] );

				int creditCardID = Convert.ToInt32( dsitems.Tables["Customer"].Rows[0]["CreditCardInfoID"] );
				int billingInfoID = Convert.ToInt32( dsitems.Tables["Customer"].Rows[0]["BillingAddressID"] );
				int shippingInfoID = Convert.ToInt32( dsitems.Tables["Customer"].Rows[0]["ShippingAddressID"] );
               
                if (organization == null)
                {
                    organization = new BLOrganization();
                }


				if( creditCardID > 0)
				{
					creditCard = new BLCreditCard();
					creditCard.ID = creditCardID;
					creditCard.Retrieve();
				}

				if( billingInfoID > 0 )
				{
					billingAddress = new BLAddress();
					billingAddress.ID = billingInfoID;
					billingAddress.Retrieve();
				}

				if( shippingInfoID > 0 )
				{
					shippingAddress = new BLAddress();
					shippingAddress.ID = shippingInfoID;
					shippingAddress.Retrieve();
				}

				if(shoppingCart == null)
				{
					shoppingCart = new BLShoppingCart();
				}
                
				shoppingCart.CustomerID = this.id;
				shoppingCart.Retrieve();







                
                    
				if(organization == null)
				{
					organization = new  BLOrganization();
				}
                
				///////////organization.ID  = messages.orgID;
				organization.Retrieve();/// = new BLShoppingCart();



               /// messages.cust = this ;

               /// messages.org = organization;


			}
			else
			{
				this.id = 0;
				ClearFields();
			}
		}
		
		private void Init()
		{
			Retrieve();
		}

		private void ClearFields()
		{
			this.created = DateTime.MinValue;
			this.uid = string.Empty;
			this.saveInfo = false;

			this.creditCard = null;
			this.billingAddress = null;
			this.shippingAddress = null;
			this.shoppingCart = null;
			
			this.billingAddress = new BLAddress();
			this.shippingAddress = new BLAddress();
			this.shoppingCart = new BLShoppingCart();
			this.creditCard = new BLCreditCard();
            this.organization = new BLOrganization();
            this.organizationhld = new BLOrganization();


		}

		#endregion

		#endregion		
		
        public BLCustomer(int id)
        {
            ClearFields();

            ID = id;
            string prm = "S";
            string commandName = "get_Buyers";
            if (ID != 0)
            {
                getBuyers(prm, commandName, id, "");
            }
        }
	}
//}

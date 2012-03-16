using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Summary description for BLCustomer.
	/// </summary>
	public class BLOrganization
    {
        Referrer r = new Referrer();

		#region Fields

        private DataSet m_ds;
		private int id;
		private DateTime created;
		private string uid;
		private BLCreditCard creditCard;
		private BLAddress billingAddress;
		private BLAddress shippingAddress;
        private BLShoppingCart shoppingCart;
        private BLItems items;
        private BLItem item; 
        private BLOrders  orders ;
        private BLCategory category;
        private string logo;
		private bool saveInfo;
		
		#endregion
		
		#region Properties
		
		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}
        public DataSet  DS
        {
            get { return m_ds; }
            set { m_ds = value; }
        }





        private string know;

        public string Know
        {
            get
            {
                 
                int yy = 0;

                int second = Convert.ToInt16(DateTime.Now.Minute.ToString());
                dsKnow = r.get_orgKnow("get_orgKnow", "S", auctionOrgID, "");
                if (dsknow != null && dsknow.Tables.Count > 0 && dsknow.Tables[0].Rows.Count>0)
                {
                for (int len = 0; len < second; len++)
                {
                    yy += 1;

                    if (yy >= dsknow.Tables[0].Rows.Count) 
                    { yy = 0; }
                }

                know = dsknow.Tables[0].Rows[yy]["orgKnow"].ToString();
                }

                return  know;
            }
            //set
            //{
            //     know = value;
            //}
        }


        private int auctionorgID;

        public int auctionOrgID
        {
            get
            {

                return auctionorgID;
            }
            set
            {
                auctionorgID = value;
            }
        }




        private DataSet dsknow;

        public DataSet dsKnow
        {
            get
            {
               
                return dsknow;
            }
            set
            {
                dsknow = value;
            }
        }




        //public static decimal getCredits
        //{
        //    get { return  Convert.ToInt16( Credits); }

        //}





        public  int orgID
        {
            get { return  ID; }
            set {  ID = value; }
        }
















        private DataSet m_Items;
       
        public DataSet ITems
        {
            get
            {
                return m_Items;
            }
            set
            {
                m_Items = value;
            }
        }


        private String orgtitle;
        public  String orgTitle
        {
            get
            {
                return  orgtitle;
            }
            set
            {
                 orgtitle = value;
            }
        }

      
         private String video;
        public String Logo
        {
            get
            {
                return logo;
            }
            set
            {
                logo = value;
            }
        }

        
        public String Video
        {
            get
            {
                return video;
            }
            set
            {
                video = value;
            }
        }


        public BLCategory Category
        {
            get { return category; }
            set { category = value; }
        }





        public BLItem  Item 
        {
            get { return item ; }
            set { item  = value; }
        }


        public BLItems Orgitems
        {
            get { return items; }
            set { items = value; }
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


        
		public BLOrders Orders
		{
            get { return orders; }
            set { orders = value; }
		}



///orgorders




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
		
		public static DataSet GetList()
		{
			return DALCCustomer.GetList();
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



        ////////////////////  dsitems=  GetOrgList( , "S", "get_Orgs", this.ID, "");

         dsKnow =   r.get_orgKnow("get_orgKnow", "S", this.ID, "");















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
               
                
                
                if (shoppingCart == null)
                {
                    shoppingCart = new BLShoppingCart();
                }

                shoppingCart.CustomerID = this.id;
                shoppingCart.Retrieve();




				if(items == null)
				{
                     items = new BLItems();
				}
                 items.OrgID = this.id;
                items.Retrieve();






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














        public   DataSet GetOrgList(ref BLCustomer cust,  String parm, string commandtext, int id, string status)
        {
           //// BLCustomer cust = (BLCustomer)messages.cust;






            DataSet ds = new DataSet();

            switch (parm)
            {
                case "S":

                    ds = cust.Organization.Orgitems.Items;

                    break;
                case "J":
 
                        ds = cust.Organization.Orgitems.Items;
                   

                    break;
                case "I":

                    //  ds = cust.Organization.Orgitems.ItemsGeneralSearch;

                    ds = cust.Organization.Orgitems.Items;
                    break;


                case "A":

                    ds = cust.Organization.Orgitems.categories;

                    break;


            }
            if(parm!="J")
            ds = cust.Organization.UpdateOrgs(parm, commandtext, id, status);


            return ds;
        }

        
        



        public DataSet UpdateOrgs(String parm, string commandtext, int id, string status)
        {



            String orgEmail = "";  
            String orgTitle = ""; 
            String orgFunct = ""; 
            String orgDesc = ""; 
            String orgTaxID = "";
            String orgPaypal = ""; 
            String orgLogo = "" ;
            String orgVideo = "";
           
            String orgStatus = status;
            orgStatus = status;
            String prm = parm;            
            status = "";
            string pwd = "";

            DataSet ds = new DataSet();
          
            string commandText = "get_Orgs";


            if (prm == "S")
            {
               //// orgStatus = "All"; 
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
      orgStatus,"");

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
                  orgVideo, "", ""
                 );



              ///////////////  orgStatus = drplstEmailSts.SelectedValue.ToString();
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
                  orgStatus,"");

            };




            prm = mails.prm;

            DS = ds;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
            {

                Logo = ds.Tables[0].Rows[0]["orgLogo"].ToString();
                Video = ds.Tables[0].Rows[0]["orgVideo"].ToString();
                orgTitle = ds.Tables[0].Rows[0]["orgTitle"].ToString();

            }

            return ds;


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
            this.category = null;

			this.billingAddress = new BLAddress();
			this.shippingAddress = new BLAddress();
			this.shoppingCart = new BLShoppingCart();
            this.creditCard = new BLCreditCard();
            this.items = new BLItems();
            this.orders = new BLOrders();
            this.category = new BLCategory();
            this.item = new BLItem();
           

		}

		#endregion

		#endregion		
		
        public BLOrganization()
		{
			ClearFields();
		}
	}
//}

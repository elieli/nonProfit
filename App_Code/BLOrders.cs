using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// ����� BLOrders ��������� ������-������ ������.
	/// </summary>
	public class BLOrders
	{
		
		#region Fields
          Referrer r = new Referrer();

		#region Private Fields
		
		/// <summary>
		///		ID ������
		/// </summary>
		private int id;

		/// <summary>
		///		UID ������
		/// </summary>
		private string uid;

		/// <summary>
		///		ID ����������
		/// </summary>
		private int �ustomerID;

		/// <summary>
		///		ID ���������� � ��������� ��������
		/// </summary>
		private int �reditCardInfoID;

		/// <summary>
		///		ID ���������� �� ������ ������
		/// </summary>
		private int billingAddressID;

		/// <summary>
		///		ID ���������� �� ������ ��������
		/// </summary>
		private int shippingAddressID;

        /// <summary>
        ///		������� �� ������ ������ ��������� ���������
        /// </summary>
        private decimal ccSurcharge;

        /// <summary>
        ///		��������� ��������
        /// </summary>
        private decimal shippingCharges;

        /// <summary>
        ///		����� ��������
        /// </summary>
        private string trackingNumber;
		
		/// <summary>
		/// non-ups trcking numbers 
		/// </summary>

		private string strNonUpsTracking;

		/// <summary>
		///		������ ������
		/// </summary>
		private int status;

		/// <summary>
		///		���� �������� ������
		/// </summary>
		private DateTime created;

		/// <summary>
		///		����� ��������� ������
		/// </summary>
		private DataSet orderProducts;

        private DataSet orders;


		#endregion

		#endregion
		
		#region Properties
		
		#region None Static Properties

		/// <value>
		///		������������� � �������� ID ������
		/// </value>
		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}

		/// <value>
		///		������������� � �������� UID ������
		/// </value>
		public string UID
		{
			get{ return uid; }
			set{ uid = value; }
		}

		/// <value>
		///		������������� � �������� ID ����������
		/// </value>
		public int CustomerID
		{
			get{ return �ustomerID; }
			set{ �ustomerID = value; }
		}

		/// <value>
		///		������������� � �������� ID ���������� � ��������� ��������
		/// </value>
		public int CreditCardInfoID
		{
			get{ return �reditCardInfoID; }
			set{ �reditCardInfoID = value; }
		}

		/// <value>
		///		������������� � �������� ID ���������� �� ������ ������
		/// </value>
		public int BillingAddressID
		{
			get{ return billingAddressID; }
			set{ billingAddressID = value; }
		}

		/// <value>
		///		������������� � �������� ID ���������� �� ������ ��������
		/// </value>
		public int ShippingAddressID
		{
			get{ return shippingAddressID; }
			set{ shippingAddressID = value; }
		}

        /// <value>
        ///		������������� � �������� ������� �� ������ ������ ��������� ���������
        /// </value>
        public decimal CCSurcharge
        {
            get{ return ccSurcharge; }
            set{ ccSurcharge = value; }
        }

        /// <value>
        ///		������������� � �������� ��������� ��������
        /// </value>
        public decimal ShippingCharges
        {
            get{ return shippingCharges; }
            set{ shippingCharges = value; }
        }
        
        /// <value>
        ///		������������� � �������� ����� ��������
        /// </value>
        public string TrackingNumber
        {
            get{ return trackingNumber; }
            set{ trackingNumber = value; }
        }

		///<value>
		///Non-Ups Tracking Numbers Won't Automatically track.
		///</value>
		public string NonUpsTrackNumber
		{
			get{ return strNonUpsTracking; }
			set{ strNonUpsTracking = value;}
		}

		/// <value>
		///		������������� � �������� ������ ������
		/// </value>
		public int Status
		{
			get{ return status; }
			set{ status = value; }
		}

		/// <value>
		///		������������� � �������� ���� �������� ������
		/// </value>
		public DateTime Created
		{
			get{ return created; }
			set{ created = value; }
		}

		/// <value>
		///		�������� ����� ��������� ������
		/// </value>
		public DataSet OrderProducts
		{
			get
			{
				return orderProducts;
			}
		}

		#endregion

		#endregion

		#region Methods

		#region Static Methods
		
		/// <summary>
		///		�������� ����� ���� �������
		/// </summary>
		public static DataSet GetList()
		{
            
			DataSet orderList = DALCOrder.GetList();
			return orderList;
		}

		/// <summary>
		///		�������� ����� ������� � ��������� �������� 
		/// </summary>
		public static DataSet GetOrdersList( string commandName, string prm, int auctionid,int orgid, int buyerid, int ordr_CreditCardInfoID, int ordr_BillingAddressID,
                        int ordr_ShippingAddressID, string ordr_Status,
                         String ordr_Type) 
        {
            DataSet orderList = messages.orgs_.Orders.GetOrders(commandName, prm, auctionid, orgid, buyerid, ordr_CreditCardInfoID, ordr_BillingAddressID,
                          ordr_ShippingAddressID, ordr_Status, ordr_Type);
		return orderList;
		}





        public static DataSet returnOrders 
        {
            get {
              return  messages.orgs_.Orders.orders;
            }

        }




		/// <summary>
		///		�������� ����� ������� ��� ���������� ����������
		/// </summary>
		public static DataSet GetListByCustomer(int customerID)
		{ 
			DataSet orderList = DALCOrder.GetListByCustomerID(customerID);
			return orderList;
		}

        /// <summary>
        ///		������� �����
        /// </summary>
        public static int Create(int customerID)
        {
            return Create(customerID, 0, 0);
        }

		/// <summary>
		///		������� �����
		/// </summary>
		public static int Create(int customerID, decimal shippingCharges)
		{
			return Create(customerID, 0, shippingCharges);
		}

        /// <summary>
        ///		������� �����
        /// </summary>
        public static int Create(int customerID, decimal ccSurcharge, decimal shippingCharges)
        {
            int returnValue = 0;

            returnValue = DALCOrder.Create(customerID, ccSurcharge, shippingCharges);
			
            return returnValue;
        }

		/// <summary>
		///		��������� ���������� �� ������
		/// </summary>
		public static int Update(int id, int customerID, int �reditCardInfoID, int billingAddressID, int shippingAddressID, decimal ccSurcharge, decimal shippingCharges, string trackingNumber, int status, DateTime created, string nonUpsTracking)
		{
			int returnValue = 0;

			returnValue = DALCOrder.Update(id, customerID, �reditCardInfoID, billingAddressID, shippingAddressID, ccSurcharge, shippingCharges, trackingNumber, status, created, nonUpsTracking);
			
			return returnValue;
		}

		/// <summary>
		///		������� �����
		/// </summary>
		public static void Delete(int id)
		{
			DALCOrder.Delete(id);
		}

		#endregion

		#region None static Methods

		/// <summary>
		///		��������� ���������� �� ������
		/// </summary>
        /// 











        public static DataSet fillcarts(BLOrganization orgs   )
        {
            DataSet ds = new DataSet();
            ds = orgs.Orders.fillCart(orgs);//            messages.orgs_.Orders.fillCart();

            return ds;

        }




        protected DataSet fillCart(BLOrganization orgs)
        {



            String parm; string commandtext = ""; int id;
            int orgid; int catid = 0;
            int itemid = 0; string status;
            string auctiontype = messages.bidtype == null ? "" : messages.bidtype;
            int auctionid =  orgs.Orgitems.AuctionID;
            //messages.orgID=13;
            int buyerid = orgs.Orgitems.buyerID;
            orgid = orgs.orgID;// BLOrganization.orgID;// messages.orgs_.ID;//.orgID;

            //  int itemid = 0;
            // int orgid=0;  
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

            String prm = "O";// parm;


            int credits = 3;


            status = "";

            DataSet ds = new DataSet();

            string commandText = commandtext;
            commandName = "get_Items";// commandtext;
            //   string commandName;

            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,buyerid, itemid, orgid, catid, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype, auctionid);





            if (ds.Tables.Count > 0)
            {
                orgs.Orders.orders = ds;
            }

            return ds;
        }























        public  DataSet GetOrders(string commandName, string prm, int auctionid,int orgid, int buyerid, int ordr_CreditCardInfoID, int ordr_BillingAddressID,
                        int ordr_ShippingAddressID, string ordr_Status,
                         String ordr_Type)
		{
            	DataSet orderList = new DataSet();

                int orders = 0;

            orders = r.get_orders(commandName, prm, auctionid, orgid, buyerid, ordr_CreditCardInfoID, ordr_BillingAddressID,
                          ordr_ShippingAddressID, ordr_Status,                           ordr_Type            );



	 
			return orderList;
		}
















		public int Update()
		{
			int returnValue = 0;

			returnValue = Update(this.id, this.�ustomerID, this.�reditCardInfoID, this.billingAddressID, this.shippingAddressID, this.ccSurcharge, this.shippingCharges, this.trackingNumber, this.status, this.created, this.strNonUpsTracking);
			
			return returnValue;
		}
		
		/// <summary>
		///		������� �����
		/// </summary>
		public void Delete()
		{
			Delete(this.id);
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.�ustomerID = 0;
			this.�reditCardInfoID = 0;
			this.billingAddressID = 0;
			this.shippingAddressID = 0;
            this.ccSurcharge = 0;
            this.shippingCharges = 0;
            this.trackingNumber = string.Empty;
			this.strNonUpsTracking = string.Empty;
			this.status = 0;
			this.created = DateTime.MinValue;;
			this.orderProducts = null;
		}

		/// <summary>
		///		�������� ���������� �� ������
		/// </summary>
		public void Retrieve()
		{
			DataSet item;
			if( this.id > 0 )
				item = DALCOrder.GetItem(this.id);
			else
				item = DALCOrder.GetItemByUID(this.uid);

			if( item!=null && item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
			{
				this.id = Convert.ToInt32( item.Tables["Order"].Rows[0]["ordrID"] );
				this.uid = Convert.ToString( item.Tables["Order"].Rows[0]["ordrUID"] );
				this.�ustomerID = Convert.ToInt32( item.Tables["Order"].Rows[0]["ordr_CustomerID"] );
				this.�reditCardInfoID = Convert.ToInt32( item.Tables["Order"].Rows[0]["ordr_CreditCardInfoID"] );
				this.billingAddressID = Convert.ToInt32( item.Tables["Order"].Rows[0]["ordr_BillingAddressID"] );
				this.shippingAddressID = Convert.ToInt32( item.Tables["Order"].Rows[0]["ordr_ShippingAddressID"] );
                this.ccSurcharge = Convert.ToDecimal( item.Tables["Order"].Rows[0]["ordrCCSurcharge"] );
                this.shippingCharges = Convert.ToDecimal( item.Tables["Order"].Rows[0]["ordrShippingCharges"] );
                this.trackingNumber = Convert.ToString( item.Tables["Order"].Rows[0]["ordrTrackingNumber"] );
				this.status = Convert.ToInt32( item.Tables["Order"].Rows[0]["ordrStatus"] );
				this.created = Convert.ToDateTime( item.Tables["Order"].Rows[0]["ordrCreated"] );
				this.strNonUpsTracking = Convert.ToString( item.Tables["Order"].Rows[0]["ordrTrackingNumberNonUps"]);
				this.orderProducts = DALCOrderProduct.GetList(this.id);
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� � ���������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		����������� ���������� ������ BLOrders
		/// </summary>
		public BLOrders()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		#endregion









	}
//}

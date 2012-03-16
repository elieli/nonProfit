using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//

//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// ����� BLProduct ��������� ������-������ ��������.
	/// </summary>
	public class BLItems
    {
        Referrer r = new Referrer();



 
            public  static event EventHandler navigateCat;






        


        //public static DataSet fillcarts()
        //{
        //    DataSet ds = new DataSet();
        // ds=    messages.cust.ShoppingCart.fillCart();

        // return ds;

        //}











            public   void setWatch(BLItems items)
            {
                string commandName = "get_watch";
                string prm = "I";


                int auctionid = items.AuctionID;// BLItems.AuctionID;


                int orgID = items.OrgID;// BLOrganization.orgID;

                int buyerID = items.buyerID;// BLCustomer.buyerID;


                DataSet ds = new DataSet();

               ///  messages.orgs_.Orgitems.UpdateWatch(prm, commandName, orgID, buyerID, auctionid);
                 items.UpdateWatch(prm, commandName, orgID, buyerID, auctionid);
          
            }





                  /// public static DataSet get_watch(string commandName, string prm, int auctionid, int orgID, int buyerID)

            public  DataSet fillWatch(BLItems items)
            {
                string commandName="get_watch";
                string prm ="B";
                int auctionid = items.AuctionID;// BLItems.AuctionID;


                int orgID = items.AuctionOrgID;//.OrgID;// BLOrganization.orgID; 
                int buyerID = items.buyerID;// BLCustomer.buyerID; 


                DataSet ds = new DataSet();

                ds = items.UpdateWatch(prm, commandName, orgID, buyerID, auctionid);
                return ds;
            }





            static public void raise(object sender, EventArgs e)
            {
                navigateCat(sender, e);

            }


        
            //public  int  AuctionID
            //{
            //    get { return items().auctionID; }
            //    set { items().auctionID = value; }
            //}


            public int AuctionID
            {
                get { return   auctionID; }
                set { auctionID = value; }
            }




            public int AuctionOrgID
            {
                get { return auctionorgid; }
                set { auctionorgid = value; }
            }






            public  int msgAuctionID
            {
                get { return  msgauctionID; }
                set {  msgauctionID = value; }
            }



          private BLItem item ;

        public BLItem Item 
        {
            get { return  item ; }
            set { item = value; }
        }







        protected DataSet UpdateWatch(String parm, string commandtext, int orgid, int buyerid, int auctionid)
        {
            DataSet ds = new DataSet();

            if (parm == "I")
            {
                r.get_watch(commandtext, parm, auctionid, orgid, buyerid);
            }
            else
            {
                ds = r.get_watch(commandtext, parm, auctionid, orgid, buyerid);
            }

            return ds;
        }


        private int buyerid;
    private int orgID;
        
    private int credits; 
        private string live;
        private int auctionid;

        private int auctionorgid;
        private int msgauctionid;
         private int catID;


		#region Fields

		#region Private Fields
		
		/// <summary>
		///		ID ��������
		/// </summary>
		private int id;
		
		/// <summary>
		///		��� ��������
		/// </summary>
		private string skuNumber;

		/// <summary>
		///		������� ���������������� ��������
		/// </summary>
		private bool enabled;

        /// <summary>
        ///		������� �������������� ��������
        /// </summary>
        private bool personalize;

        /// <summary>
        ///		������� ������������ �������������� ��������
        /// </summary>
        private bool persRequired;

		/// <summary>
		///		��� ��������
		/// </summary>
		private string name;

		/// <summary>
		///		�������� ��������
		/// </summary>
		private string description;

        /// <summary>
        ///		��� ��������
        /// </summary>
        private decimal weight;

		/// <summary>
		///		���� ��������
		/// </summary>
		private decimal price;

		/// <summary>
		///		������� ���� ��������
		/// </summary>
		private decimal regPrice;

		/// <summary>
		///		������ ���� ��������
		/// </summary>
		private decimal persPrice;

        /// <summary>
        ///		������� ������� �� ��������� ��������
        /// </summary>
        private bool ccSurcharge;

		/// <summary>
		///		������� ���������� ��������
		/// </summary>
		private bool onSale;

		/// <summary>
		///		�������� ���������� ��������
		/// </summary>
		private string saleText;

		/// <summary>
		///		���������� �������� �� ������
		/// </summary>
		private int inventory;

		/// <summary>
		///		���������� �������� ��� ������ ������
		/// </summary>
		private int reorder;

		/// <summary>
		///		���������� ���������� ��-���������
		/// </summary>
		private int defQuantity;

        /// <summary>
        ///		����������� ���������� ����������
        /// </summary>
        private int minQuantity;

		/// <summary>
		///		����� ���������
		/// </summary>
		/////////////////////private DataSet ;

		/// <summary>
		///		����� ���������
		/// </summary>
		private DataSet attributes;
		
		/// <summary>
		///		����� ��������� ����������
		/// </summary>
		private DataSet relatedInfo;

		//stores the aount of items per case
		private int intAmountPerCase;

		#endregion

		#endregion
		
		#region Properties
		
		#region None Static Properties

		/// <value>
		///		������������� � �������� ID ��������
		/// </value>

        public String Live
        {
            get { return live; }
            set {   live=value; }
        }

        public int Credits
        {
            get { return credits; }
            set { credits = value; }
        }


        	public int OrgID
		{
			get{ return orgID; }
			set{ orgID = value; }
		}



            public int buyerID
            {
                get { return buyerid; }
                set { buyerid = value; }
            }


        
        
            public int auctionID
            {
                get { return auctionid; }
                set { auctionid = value; }
            }

            public int msgauctionID
            {
                get { return msgauctionid; }
                set { msgauctionid = value; }
            }

            private DataTable datatable;

            public DataTable dataTable
            {
                get { return datatable; }
                set
                {
                    datatable = value;

                }
            }



            private DataSet catbreadcrumbs;

            public DataSet CatbreadCrumbs
            {
                get {

                    string commandName = "get_Categories";

                    catbreadcrumbs = r.getCats(  commandName, "F", catID, "");
                    return catbreadcrumbs; }
                set
                {
                    catbreadcrumbs = value;
                                         
                }
            }





            public   int catid
            {
                get { return  catID; }
                set
                {
                     catID = value;

                     


                }
            }


        	public int CatID
		{
			get{ return catID; }
			set
            { 
                catID = value;

              string commandName="get_Categories";

              CatbreadCrumbs = r.getCats(commandName, "F", catID, "");


            }
		}



        
        
        public int ID
		{
			get{ return id; }
			set{ id = value; }
		}

		/// <value>
		///		������������� � �������� ��� ��������
		/// </value>
		public string SkuNumber
		{
			get{ return skuNumber; }
			set{ skuNumber = value; }
		}

		/// <value>
		///		������������� � �������� ������� ���������������� ��������
		/// </value>
		public bool Enabled
		{
			get{ return enabled; }
			set{ enabled = value; }
		}
        
        /// <value>
        ///		������������� � �������� ������� �������������� ��������
        /// </value>
        public bool Personalize
        {
            get{ return personalize; }
            set{ personalize = value; }
        }

        /// <summary>
        ///		������� ������������ �������������� ��������
        /// </summary>
        public bool PersRequired
        {
            get{ return persRequired; }
            set{ persRequired = value; }
        }

		/// <value>
		///		������������� � �������� ��� ��������
		/// </value>
		public string Name
		{
			get{ return name; }
			set{ name = value; }
		}

		/// <value>
		///		������������� � �������� �������� ��������
		/// </value>
		public string Description
		{
			get{ return description; }
			set{ description = value; }
		}

        /// <value>
        ///		������������� � �������� ��� ��������
        /// </value>
        public decimal Weight
        {
            get{ return weight; }
            set{ weight = value; }
        }

		/// <value>
		///		������������� � �������� ���� ��������
		/// </value>
		public decimal Price
		{
			get{ return price; }
			set{ price = value; }
		}

		/// <value>
		///		������������� � �������� ������� ���� ��������
		/// </value>
		public decimal RegPrice
		{
			get{ return regPrice; }
			set{ regPrice = value; }
		}

		/// <value>
		///		������������� � �������� ������ ���� ��������
		/// </value>
		public decimal PersPrice
		{
			get{ return persPrice; }
			set{ persPrice = value; }
		}

        /// <value>
        ///		������������� � �������� ������� ������� �� ��������� ��������
        /// </value>
        public bool CCSurcharge
        {
            get{ return ccSurcharge; }
            set{ ccSurcharge = value; }
        }

		/// <value>
		///		������������� � �������� ������� ���������� ��������
		/// </value>
		public bool OnSale
		{
			get{ return onSale; }
			set{ onSale = value; }
		}

		/// <value>
		///		������������� � �������� �������� ���������� ��������
		/// </value>
		public string SaleText
		{
			get{ return saleText; }
			set{ saleText = value; }
		}

		/// <value>
		///		������������� � �������� ���������� �������� �� ������
		/// </value>
		public int Inventory
		{
			get{ return inventory; }
			set{ inventory = value; }
		}

		/// <value>
		///		������������� � �������� ���������� �������� ��� ������ ������
		/// </value>
		public int Reorder
		{
			get{ return reorder; }
			set{ reorder = value; }
		}

		/// <value>
		///		������������� � �������� ���������� ���������� ��-���������
		/// </value>
		public int DefQuantity
		{
			get{ return defQuantity; }
			set{ defQuantity = value; }
		}

        /// <value>
        ///		������������� � �������� ����������� ���������� ����������
        /// </value>rowLimit
        public int MinQuantity
        {
            get{ return minQuantity; }
            set{ minQuantity = value; }
        }

		/// <value>
		///		�������� ����� ���������
		/// </value>
        /// 
        public DataSet categories;
		public DataSet Categories
		{
			get
			{ 
				return categories; 
			}
		}

		/// <value>
		///		�������� ����� ���������
		/// </value>
		public DataSet Attributes
		{
			get
			{
				return attributes;
			}
		}

		/// <value>
		///		�������� ����� ��������� ����������
		/// </value>
		public DataSet RelatedInfo
		{
			get
			{ 
				return relatedInfo; 
			}
		}








        private DataView m_ItemsDV;

        public DataView ItemsDV
        {
            get
            {
                return m_ItemsDV;
            }
            set
            {
                m_ItemsDV = value;
            }
        }





         	private DataSet m_Items;

		public  DataSet Items
		{
			get
			{ 
				return m_Items; 
			}
            set
			{ 
				  m_Items=value; 
			}
		}






        private DataSet recentitems;

        public DataSet RecentItems
        {
            get
            {
                return recentitems;
            }
            set
            {
                recentitems = value;
            }
        }










        private DataSet cartitems;


        public DataSet cartItems
        {
            get
            {
                return cartitems;
            }
            set
            {
                cartitems = value;
            }
        }



         

        public   DataSet RecentITems
        {
            get
            {
                return  recentitems;
            }
            set
            {
                 recentitems = value;
            }
        }










        private DataSet m_ItemsGeneralSearch;

        public DataSet ItemsGeneralSearch
        {
            get
            {
                return m_ItemsGeneralSearch;
            }
            set
            {
                m_ItemsGeneralSearch = value;
            }
        }






		//amount per case property
		public int AmountPerCase
		{
			get{return intAmountPerCase;}
			set{intAmountPerCase = value;}
		}
		
		#endregion

		#endregion

		#region Methods
		
		#region Static Methods
		
		/// <summary>
		///		�������� ����� ��������� �� ID ��������� � �������� ����������������
		/// </summary>

        private   int m_rowlimit;
        public  int rowlimit
        {
            get
            {
                if (m_rowlimit == 0)
                {
                    m_rowlimit = 16;

                }
                return m_rowlimit; }
            set { m_rowlimit = value; }
        }

        private   int m_pager;
        public   int pager
        {
            get { return m_pager; }
            set { m_pager = value; }
        }



        private   int m_totpage;
        public  int totpage
        {
            get { return m_totpage; }
            set { m_totpage = value; }
        }


        private   int m_rempage;
        public   int rempage
        {
            get { return m_rempage; }
            set { m_rempage = value; }
        }










           private int m_cartcount;






           public int cartcount
           {
               get
               {


                   int catid = 0;
                   int orgid = OrgID;/// messages.orgID;

                   DataSet ds = new DataSet();

                   ds = UpdateDonate("C", "get_Items", 0, catid, orgid, "");

                   m_cartcount = ds.Tables[0].Rows.Count;


                   return m_cartcount;


               }
           }















           public  DataSet GetItemsList(ref BLCustomer cust, String parm, string commandtext, int id, int orgid, int catid, string status)
        {
             /// BLCustomer cust = (BLCustomer)messages.cust;

            

            DataSet ds = new DataSet();

            switch (parm)
            {
                case "Q" :

                    ds = cust.Organization.Orgitems.UpdateDonate(parm, commandtext,cust.ID, orgid, catid, status);
                     cust.Organization.Orgitems.Items=ds; 

                    break;
                case "K":

                    ds = cust.Organization.Orgitems.UpdateDonate(parm, commandtext, cust.ID, orgid, catid, status);
                   // cust.Organization.Orgitems.Items = ds;

                    break;
                    case "V" :

                    parm="Q";
                    ds = cust.Organization.Orgitems.UpdateDonate(parm, commandtext, cust.ID, orgid, catid, status);
                     cust.Organization.Orgitems.RecentItems=ds;
                     try { cust.Organization.Orgitems.dataTable = ds.Tables[0]; } catch(Exception ex){}
                    


                     break;
                      case "I" :

                     ds = cust.Organization.Orgitems.UpdateDonate(parm, commandtext, cust.ID, orgid, catid, status);
                 ///////////////////////////// cust.Organization.Orgitems.Items=ds; 
                  //  ds = cust.Organization.Orgitems.ItemsGeneralSearch;

                ///ds = cust.Organization.Orgitems.Items; 
                    break;


                      case "A":
                    ds = cust.Organization.Orgitems.UpdateDonate(parm, commandtext, cust.ID, orgid, catid, status);
                     cust.Organization.Orgitems.categories=ds;
                   // ds = cust.Organization.Orgitems.categories;

                    break;

                      case "C":
                    ds = cust.Organization.Orgitems.UpdateDonate(parm, commandtext, cust.ID, orgid, catid, status);
                    cust.Organization.Orgitems.cartItems = ds;
                    // ds = cust.Organization.Orgitems.categories;

                    break;
                      case   "J":

                    ds = cust.Organization.Orgitems.Items; 

                    break;

                    


            } 

          
            return ds;

           //  return cust;

        }







        public  int  GetOrgbyAuctionID(BLItems items,   int AuctionID )
        {
            DataSet ds =  new DataSet();

             int shippngCost = 0;
        //  int orgid = 0;  
        String title = "";
        int quantity = 0;
        ////  catid = messages.blitem.catID;
        String location = "";
        String orgPaypal = "";
        String description = "";
        String condition = "";
        //String shippngCost = status; 
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;
        DateTime soldDate = DateTime.Today;
        String commandName = "get_Items";

        String prm = "U";


        int credits = 1;


       
       
       
        //   string commandName;

        
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            ds = r.getItems(commandName, prm,0, 0, 0, 0, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, "",AuctionID  
     );


            if(ds.Tables.Count>0  &&      ds.Tables[0].Rows.Count>0    )
            {
              int orgid=  Convert.ToInt16(  ds.Tables[0].Rows[0][0]) ;

            //  messages.orgs_.ID = orgid;

             // this.OrgID = orgid;

              items.AuctionOrgID = orgid;

            }


            return orgID;

        }
        
        
        
        
        public static DataSet GetList(int categoryID, bool ifEnabled)
		{
			DataSet productList = DALCProduct.GetListByCategory(categoryID, ifEnabled, "");
			return productList;
		}

		/// <summary>
		///		�������� ����� ��������� ��������� �� �������� ����������������
		/// </summary>
		public static DataSet GetListLast(bool ifEnabled, int count)
		{
			DataSet productList = DALCProduct.GetListLast(ifEnabled, count);
			return productList;
		}

        /// <summary>
        ///		�������� ����� ��������� ��������� ��������� �� �������� ����������������
        /// </summary>
        public static DataSet GetListLastByCategory(int �ategoryID, bool ifEnabled, int count, string special)
        {
            DataSet productList = DALCProduct.GetListLastByCategory(�ategoryID, ifEnabled, count, special);
            return productList;
        }

        /// <summary>
        ///		�������� ����� ��������� ��������� ������������ �� �������� ����������������
        /// </summary>
        public static DataSet GetListLastByCategoryRec(int �ategoryID, bool ifEnabled, int count, string special)
        {
            DataSet productList = DALCProduct.GetListLastByCategoryRec(�ategoryID, ifEnabled, count, special);
            return productList;
        }

		/// <summary>
		///		�������� ����� ��������� ��������� �� �������� ���������������� � ID ������������
		/// </summary>
		public static DataSet GetListLast(bool ifEnabled, int count, int userID)
		{
			DataSet productList = DALCProduct.GetListLast(ifEnabled, count, userID);
			return productList;
		}

		/// <summary>
		///		�������� ����� ��������� �� ID ���������, �������� ���������������� � �������� �������������
		/// </summary>
		public static DataSet GetList(int categoryID, bool ifEnabled, string special)
		{
			DataSet productList = DALCProduct.GetListByCategory(categoryID, ifEnabled, special);
			return productList;
		}

        /// <summary>
        ///		�������� ����������� ����� ��������� �� ID ���������, �������� ���������������� � �������� �������������
        /// </summary>
        /// 

        public static DataSet GetGroupListByCategory(int categoryID)
        {
            DataSet productList = DALCProduct.GetGroupListByCategory(categoryID);
            return productList;
        }

        /// <summary>
        ///		�������� ����������� ����� ��������� �� ID ���������, �������� ���������������� � �������� �������������
        /// </summary>

        public static DataSet GetListRec(int categoryID, bool ifEnabled, string special)
        {
            DataSet productList = DALCProduct.GetListByCategoryRec(categoryID, ifEnabled, special);
            return productList;
        }

		/// <summary>
		///		�������� ����� ��������� �� ID ���������� � �������� �������������
		/// </summary>
		public static DataSet GetListByCustomer(int customerID, string special)
		{
			DataSet productList = DALCProduct.GetListByCustomer(customerID, special);
			return productList;
		}

		/// <summary>
		///		�������� ����� ��������� �� ID ������������
		/// </summary>
		public static DataSet GetListByUser(int userID)
		{
			DataSet productList = DALCProduct.GetListByUser(userID);
			return productList;
		}

		/// <summary>
		///		�������� ����� ��������� �� ID ������������ � ID ���������
		/// </summary>
		public static DataSet GetListByUserCat(int userID, int categoryID)
		{
			DataSet productList = DALCProduct.GetListByUserCat(userID, categoryID);
			return productList;
		}

		public static DataSet GetList(string searchParam, bool ifEnabled)
		{
			DataSet productList = DALCProduct.GetList(searchParam.Trim(), ifEnabled);
			return productList;
		}

		public static DataSet GetListBySearchAndUser(string searchParam, int userID)
		{
			DataSet productList = DALCProduct.GetListBySearchAndUser(searchParam, userID);
			return productList;
		}

		/// <summary>
		///		�������� ����� ���� ���������
		/// </summary>
		public static DataSet GetList()
		{
			DataSet productList = DALCProduct.GetList();
			return productList;
		}

		/// <summary>
		///		��������� ���������� � ��������
		/// </summary>
		public static int Update(int id, string skuNumber, bool enabled, bool personalize, bool persRequired, string name, string description, decimal weight, decimal price, decimal regPrice, decimal persPrice, bool ccSurcharge, bool onSale, string saleText, int inventory, int reorder, int defQuantity, int minQuantity, int PerCase)
		{
			int returnValue = 0;

		//	returnValue = DALCProduct.Update(id,  enabled, personalize, persRequired, name, description, weight, price, regPrice, persPrice, ccSurcharge, onSale, saleText, inventory, reorder, defQuantity, minQuantity, PerCase);

			return returnValue;
		}

		/// <summary>
		///		������� �������
		/// </summary>
		public static void Delete(int id)
		{
			DALCProduct.Delete(id);
		}

		/// <summary>
		///		������� ������� �� ���������
		/// </summary>
		public static void RemoveFromCategory(int id, int categoryID)
		{
			DALCProduct.RemoveFromCategory(id, categoryID);
		}

		/// <summary>
		///		������� ������� �� ���������� ����������
		/// </summary>
		public static void RemoveFromCustomer(int id, int �ustomerID)
		{
			DALCProduct.RemoveFromCustomer(id, �ustomerID);
		}

		/// <summary>
		///		������� ������� �� ���������� ������������
		/// </summary>
		public static void RemoveFromUser(int id, int userID)
		{
			DALCProduct.RemoveFromUser(id, userID);
		}

		/// <summary>
		///		������� ������� �� ��������� ����������� �������
		/// </summary>
		public static void RemoveFromCategory(int id, int categoryID, string special)
		{
			DALCProduct.RemoveSpecialFromCategory(id, categoryID, special);
		}

        /// <summary>
        ///		������� ��� �������� �� ��������� ����������� �������
        /// </summary>
        public static void RemoveAllFromCategory(int categoryID, string special)
        {
            DALCProduct.RemoveAllSpecialFromCategory(categoryID, special);
        }

		/// <summary>
		///		������� ������� �� ���������� ���������� ����������� �������
		/// </summary>
		public static void RemoveFromCustomer(int id, int �ustomerID, string special)
		{
			DALCProduct.RemoveSpecialFromCustomer(id, �ustomerID, special);
		}

		/// <summary>
		///		��������� ������� � ���������
		/// </summary>
		public static void AddToCategory(int id, int categoryID)
		{
			DALCProduct.AddToCategory(id, categoryID,0);
		}

		/// <summary>
		///		��������� ������� � ���������� ����������
		/// </summary>
		public static void AddToCustomer(int id, int customerID)
		{
			DALCProduct.AddToCustomer(id, customerID, "", 0);
		}

		/// <summary>
		///		��������� ������� � ���������� ������������
		/// </summary>
		public static void AddToUser(int id, int userID)
		{
			DALCProduct.AddToUser(id, userID);
		}

		/// <summary>
		///		��������� ������� � ��������� ����������� �������
		/// </summary>
		public static void AddToCategory(int id, int categoryID, string special,int groupnumber,Boolean display )
		{
			DALCProduct.AddToCategory(id, categoryID, special,groupnumber,display);
		} 

		/// <summary>
		///		��������� ������� � ���������� ���������� ����������� �������
		/// </summary>
		public static void AddToCustomer(int id, int �ustomerID, string special)
		{
			DALCProduct.AddToCustomer(id, �ustomerID, special, 0);
		}

		/// <summary>
		///		��������� ������� � ���������� ���������� ����������� ������� � ���������
		///		������������� ���������� ������� � ����������
		/// </summary>
		public static void AddToCustomer(int id, int �ustomerID, string special, int maxCount)
		{
			DALCProduct.AddToCustomer(id, �ustomerID, special, maxCount);
		}

		#endregion

		#region None Static Methods

		/// <summary>
		///		��������� ���������� � ��������
		/// </summary>
		public int Update()
		{
			int returnValue = 0;

		/////////////////////	returnValue = Update(this.id,  this.enabled, this.personalize, this.persRequired, this.name, this.description, this.weight, this.price, this.regPrice, this.persPrice, this.ccSurcharge, this.onSale, this.saleText, this.inventory, this.reorder, this.defQuantity, this.minQuantity, this.AmountPerCase, this.intAmountPerCase);
			this.id = returnValue;
			
			return returnValue;
		}
		
		/// <summary>
		///		������� �������
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
			this.skuNumber = string.Empty;
			this.enabled = false;
            this.personalize = false;
            this.persRequired = false;
			this.name = string.Empty;
			this.description = string.Empty;
            this.weight = 0;
			this.price = 0;
			this.regPrice = 0;
			this.persPrice = 0;
            this.ccSurcharge = true;
			this.onSale = false;
			this.saleText = string.Empty;
			this.inventory = 0;
			this.reorder = 0;
			this.defQuantity = 0;
            this.minQuantity = 0;
			this.categories = null;
			this.attributes = null;
			this.relatedInfo = null;
			this.AmountPerCase = 1;
		}

		/// <summary>
		///		�������� ID ������������ ��������
		/// </summary>
		public int GetAttributeID(string name)
		{
			if(attributes!=null && attributes.Tables.Count > 0)
			{
				foreach(DataRow row in attributes.Tables[0].Rows)
				{
					if (Convert.ToString(row["attrName"])==name) 
					{
						return Convert.ToInt32(row["attrID"]);
					}
				}
			}
			return 0;
		}







































		/// <summary>
		///		�������� �������� ������������ ��������
		/// </summary>
		public string GetAttributeValue(string name)
		{
			if(attributes!=null && attributes.Tables.Count > 0)
			{
				foreach(DataRow row in attributes.Tables[0].Rows)
				{
					if (Convert.ToString(row["attrName"])==name) 
					{
						if (Convert.ToInt32(row["attr_AttributeValueID"]) > 0)
							return BLAttributeValue.GetValue(Convert.ToInt32(row["attr_AttributeValueID"]));
						else
							return Convert.ToString(row["attrValue"]);
					}
				}
			}
			return "";
		}

		/// <summary>
		///		�������� ID �������� ������������ ��������
		/// </summary>
		public string GetAttributeValueID(string name)
		{
			if(attributes!=null && attributes.Tables.Count > 0)
			{
				foreach(DataRow row in attributes.Tables[0].Rows)
				{
					if (Convert.ToString(row["attrName"])==name) 
					{
						return Convert.ToString(row["attr_AttributeValueID"]);
					}
				}
			}
			return "";
		}

		/// <summary>
		///		�������� ���������� � ��������
		/// </summary>
		public void Retrieve()
		{
			/////////////RetrieveByUser(-1);



		}












        public DataSet UpdateDonate(String parm, string commandtext, int buyerid, int orgid, int catid, string status)
    {

        int itemid = 0;
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

        String prm = parm;



        if (parm == "I" || parm == "A")
       {
           title = status;

       }

        String auctiontype = "";
       // status = "";

        DataSet ds = new DataSet();

        string commandText = commandtext;
        commandName = commandtext;
        //   string commandName;

        //if (prm == "S" || prm == "Q" || prm == "I" || prm == "C")
        //{

            //r = new Referrer();
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
        ds = r.getItems(commandName, prm,buyerid, itemid, orgid, catid, location,
     description, quantity, shippngCost, condition, title,
          startDate, endDate, soldDate, auctiontype, 0
     );
        //}


        


        return ds;
    }
























		/// <summary>
		///		�������� ���������� � �������� �� ID ������������
		/// </summary>
		public void RetrieveByUser(int userID)
		{
			if( this.id > 0 )
			{
				DataSet dsitems;
				if( userID > 0 )
					dsitems = DALCProduct.GetItemByUser(this.id, userID);
				else
					dsitems = DALCProduct.GetItem(this.id);

				if( dsitems.Tables.Count > 0 && dsitems.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( dsitems.Tables["Product"].Rows[0]["prdID"] );
				//	this.skuNumber = Convert.ToString( dsitems.Tables["Product"].Rows[0]["prdSkuNumber"] );
					this.enabled = Convert.ToBoolean( dsitems.Tables["Product"].Rows[0]["prdEnabled"] );
                    this.personalize = Convert.ToBoolean( dsitems.Tables["Product"].Rows[0]["prdPersonalize"] );
                    this.persRequired = Convert.ToBoolean( dsitems.Tables["Product"].Rows[0]["prdPersRequired"] );
					this.name = Convert.ToString( dsitems.Tables["Product"].Rows[0]["prdName"] );
					this.description = Convert.ToString( dsitems.Tables["Product"].Rows[0]["prdDescription"] );
                    this.weight = Convert.ToDecimal( dsitems.Tables["Product"].Rows[0]["prdWeight"] );
					this.price = Convert.ToDecimal( dsitems.Tables["Product"].Rows[0]["prdPrice"] );
					this.regPrice = Convert.ToDecimal( dsitems.Tables["Product"].Rows[0]["prdRegPrice"] );
					this.persPrice = Convert.ToDecimal( dsitems.Tables["Product"].Rows[0]["prdPersPrice"] );
                    this.ccSurcharge = Convert.ToBoolean( dsitems.Tables["Product"].Rows[0]["prdCCSurcharge"] );
					this.onSale = Convert.ToBoolean( dsitems.Tables["Product"].Rows[0]["prdOnSale"] );
					this.saleText = Convert.ToString( dsitems.Tables["Product"].Rows[0]["prdSaleText"] );
					this.inventory = Convert.ToInt32( dsitems.Tables["Product"].Rows[0]["prdInventory"] );
					this.reorder = Convert.ToInt32( dsitems.Tables["Product"].Rows[0]["prdReorder"] );
					this.defQuantity = Convert.ToInt32( dsitems.Tables["Product"].Rows[0]["prdDefQuantity"] );
                    this.minQuantity = Convert.ToInt32( dsitems.Tables["Product"].Rows[0]["prdMinQuantity"] );
					this.AmountPerCase = Convert.ToInt32( dsitems.Tables["Product"].Rows[0]["prdAmountPerCase"]);
					this.categories = DALCCategory.GetListByProduct(this.id);
			         this.attributes = DALCAttribute.GetList(this.id);
					this.relatedInfo = DALCRelatedInfo.GetList(this.id);
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� � ��������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

        private void ClearFields()
        {


            this.Item = null;


            this.Item = new BLItem();


        }
		#endregion
		
		#region Constructors

		/// <summary>
		///		����������� ���������� ������ BLProduct
		/// </summary>
        public BLItems()
		{
			//
			// TODO: Add constructor logic here
			//

            ClearFields();

		}

		#endregion
	

    





	}




//}

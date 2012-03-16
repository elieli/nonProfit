using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//

//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Класс BLProduct реализует бизнес-логику продукта.
	/// </summary>
	public class BLItem
    {
        Referrer r = new Referrer();
        
        public static event EventHandler refreshMenu;


		#region Fields

		#region Private Fields
		
		/// <summary>
		///		ID продукта
		/// </summary>
		private int id;
		
		/// <summary>
		///		Код продукта
		/// </summary>
		private string skuNumber;

		/// <summary>
		///		Признак действительности продукта
		/// </summary>
		private bool enabled;

        /// <summary>
        ///		Признак персонализации продукта
        /// </summary>
        private bool personalize;

        /// <summary>
        ///		Признак обязательной персонализации продукта
        /// </summary>
        private bool persRequired;

		/// <summary>
		///		Имя продукта
		/// </summary>
		private string name;

		/// <summary>
		///		Описание продукта
		/// </summary>
		private string description;

        /// <summary>
        ///		Вес продукта
        /// </summary>
        private decimal weight;

		/// <summary>
		///		Цена продукта
		/// </summary>
		private decimal price;

		/// <summary>
		///		Обычная цена продукта
		/// </summary>
		private decimal regPrice;

		/// <summary>
		///		Другая цена продукта
		/// </summary>
		private decimal persPrice;

        /// <summary>
        ///		Признак доплаты за кредитную карточку
        /// </summary>
        private bool ccSurcharge;

		/// <summary>
		///		Признак распродажи продукта
		/// </summary>
		private bool onSale;

		/// <summary>
		///		Описание распродажи продукта
		/// </summary>
		private string saleText;

		/// <summary>
		///		Количество продукта на складе
		/// </summary>
		private int inventory;

		/// <summary>
		///		Количество продукта для нового заказа
		/// </summary>
		private int reorder;

		/// <summary>
		///		Заказуемое количество по-умолчанию
		/// </summary>
		private int defQuantity;

        /// <summary>
        ///		Минимальное заказуемое количество
        /// </summary>
        private int minQuantity;

		/// <summary>
		///		Набор категорий
		/// </summary>
		/////////////////////private DataSet ;

		/// <summary>
		///		Набор атрибутов
		/// </summary>
		private DataSet attributes;
		
		/// <summary>
		///		Набор связанной информации
		/// </summary>
		private DataSet relatedInfo;

		//stores the aount of items per case
		private int intAmountPerCase;

		#endregion

		#endregion
		
		#region Properties
		
		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID продукта
		/// </value>
        private int catid;
        private int auctionid;

        public int catID
        {
            get { return catid; }
            set { catid = value; }
        }



        public int auctionID
        {
            get { return auctionid; }
            set { auctionid = value; }
        }





        public int ID
        {
            get { return id; }
            set { id = value; }
        }




		/// <value>
		///		Устанавливает и получает код продукта
		/// </value>
		public string SkuNumber
		{
			get{ return skuNumber; }
			set{ skuNumber = value; }
		}

		/// <value>
		///		Устанавливает и получает признак действительности продукта
		/// </value>
		public bool Enabled
		{
			get{ return enabled; }
			set{ enabled = value; }
		}
        
        /// <value>
        ///		Устанавливает и получает признак персонализации продукта
        /// </value>
        public bool Personalize
        {
            get{ return personalize; }
            set{ personalize = value; }
        }

        /// <summary>
        ///		Признак обязательной персонализации продукта
        /// </summary>
        public bool PersRequired
        {
            get{ return persRequired; }
            set{ persRequired = value; }
        }

		/// <value>
		///		Устанавливает и получает имя продукта
		/// </value>
		public string Name
		{
			get{ return name; }
			set{ name = value; }
		}

		/// <value>
		///		Устанавливает и получает описание продукта
		/// </value>
		public string Description
		{
			get{ return description; }
			set{ description = value; }
		}

        /// <value>
        ///		Устанавливает и получает вес продукта
        /// </value>
        public decimal Weight
        {
            get{ return weight; }
            set{ weight = value; }
        }

		/// <value>
		///		Устанавливает и получает цену продукта
		/// </value>
		public decimal Price
		{
			get{ return price; }
			set{ price = value; }
		}

		/// <value>
		///		Устанавливает и получает обычную цену продукта
		/// </value>
		public decimal RegPrice
		{
			get{ return regPrice; }
			set{ regPrice = value; }
		}

		/// <value>
		///		Устанавливает и получает другую цену продукта
		/// </value>
		public decimal PersPrice
		{
			get{ return persPrice; }
			set{ persPrice = value; }
		}

        /// <value>
        ///		Устанавливает и получает признак доплаты за кредитную карточку
        /// </value>
        public bool CCSurcharge
        {
            get{ return ccSurcharge; }
            set{ ccSurcharge = value; }
        }

		/// <value>
		///		Устанавливает и получает признак распродажи продукта
		/// </value>
		public bool OnSale
		{
			get{ return onSale; }
			set{ onSale = value; }
		}

		/// <value>
		///		Устанавливает и получает описание распродажи продукта
		/// </value>
		public string SaleText
		{
			get{ return saleText; }
			set{ saleText = value; }
		}

		/// <value>
		///		Устанавливает и получает количество продукта на складе
		/// </value>
		public int Inventory
		{
			get{ return inventory; }
			set{ inventory = value; }
		}

		/// <value>
		///		Устанавливает и получает количество продукта для нового заказа
		/// </value>
		public int Reorder
		{
			get{ return reorder; }
			set{ reorder = value; }
		}

		/// <value>
		///		Устанавливает и получает заказуемое количество по-умолчанию
		/// </value>
		public int DefQuantity
		{
			get{ return defQuantity; }
			set{ defQuantity = value; }
		}

        private String handling;
        public String Handling
        {
            get { return handling; }
            set { handling = value; }
        }
        /// <value>
        ///		Устанавливает и получает минимальное заказуемое количество
        /// </value>
        public int MinQuantity
        {
            get{ return minQuantity; }
            set{ minQuantity = value; }
        }

		/// <value>
		///		Получает набор категорий
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



       private DataSet bidder;
       public DataSet Bidder
        {
            get
            {
                return bidder;
            }
            set
            {
                bidder = value;
            }
        }



          private DataSet sponsors;
		public DataSet Sponsors
		{
			get
			{



                String prm = "S";

              String  commandName = "get_Sponsors";

              if (sponsors!=null  && sponsors.Tables.Count>0) sponsors.Tables.Clear();
              sponsors = r.get_Sponsors(commandName, prm, this.auctionID,0,0);

        

           

				return sponsors; 
			}
            set
            {
                sponsors = value;

            }
		}
		/// <value>
		///		Получает набор атрибутов
		/// </value>
		public DataSet Attributes
		{
			get
			{


				return attributes;
			}
		}

		/// <value>
		///		Получает набор связанной информации
		/// </value>
		public DataSet RelatedInfo
		{
			get
			{ 
				return relatedInfo; 
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



           ///   'I' , 13 , 100.02 , 13

          public void UpdateSponsors( int auctionid,int  amount, int  buyerid)
              
          {

                String prm = "I";

              String  commandName = "get_Sponsors";

            //  Sponsors.Tables.Clear();
           //   Sponsors = r.get_Sponsors(commandName, prm, this.auctionID);
              r.get_Sponsors(commandName, prm, this.auctionID, amount,buyerid);
          }










     public DateTime UpdateItems(String parm, string commandtext, int id , int  buyerid)
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
            decimal bidamount = 0;
            string commandText = commandtext;
            commandName = commandtext;
            int buyerID =      buyerid;//              messages.cust.ID;
            ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
            r.get_bids(commandName, prm, itemAuctionID, buyerID, biddate,
              bidamount, buyerID,
              soldFixedBid, fee_per_bid, auctionType);

                //DataRow  dr  = ds.Tables[0].Rows[0];

              ////  bid = Convert.ToDateTime( dr["endTime"]);


              //  Bidder = ds;





            return bid;
        }





         
   

            static public void raiseMenu(object sender, EventArgs e)
            {
               ////////refreshMenu(sender, e);

            }


            public static void setMessages(BLItem item, int orgID,
            int buyerID, string forumMessage,            string messageType ,
            string messageSeneder  )
     {
         DataSet ds = new DataSet();
         String parm = "I";
         String commandtext = "get_Forum";
          item.UpdateMessages(   parm,   commandtext, item.auctionID,  orgID ,
              buyerID,   forumMessage,     messageType ,     messageSeneder  );
          

     }





     public static DataSet fillMessages(BLItem item, int orgID,
            int buyerID, string forumMessage,            string messageType ,
            string messageSeneder  )
              {    
                  DataSet ds = new DataSet();
                         String parm ="S";
                      String commandtext="get_Forum";


              //        ds = messages.orgs_.Orgitems.Item.UpdateMessages(parm, commandtext, orgID,
              //buyerID, forumMessage, messageType, messageSeneder);

                      ds = item.UpdateMessages(   parm, commandtext, orgID, item.auctionID,
              buyerID, forumMessage, messageType, messageSeneder);
                      return ds;

              }




        public  DataSet GetAuctionItemt(  BLItem item,    String parm, string commandtext, int buyerid, int orgid, int catid, int itemid, string status, String auctiontype, int auctionid)
		{
			 
		 
            DataSet ds = new DataSet();

            ds = item.UpdateDonate(parm, commandtext, buyerid, orgid, catid, itemid, status, auctiontype, auctionid);


    //   ds= messages.orgs_.Orgitems.Item.UpdateDonate(  parm,   commandtext,   id,   orgid,   catid,   itemid,   status,   auctiontype,   auctionid);

       return ds;

    }


         
		/// <summary>
		///		Получает набор продуктов по ID категории и признаку действительности
		/// </summary>
		public static DataSet GetList(int categoryID, bool ifEnabled)
		{
			DataSet productList = DALCProduct.GetListByCategory(categoryID, ifEnabled, "");
			return productList;
		}

		/// <summary>
		///		Получает набор последних продуктов по признаку действительности
		/// </summary>
		public static DataSet GetListLast(bool ifEnabled, int count)
		{
			DataSet productList = DALCProduct.GetListLast(ifEnabled, count);
			return productList;
		}

        /// <summary>
        ///		Получает набор последних продуктов категории по признаку действительности
        /// </summary>
        public static DataSet GetListLastByCategory(int сategoryID, bool ifEnabled, int count, string special)
        {
            DataSet productList = DALCProduct.GetListLastByCategory(сategoryID, ifEnabled, count, special);
            return productList;
        }

        /// <summary>
        ///		Получает набор последних продуктов подкатегорий по признаку действительности
        /// </summary>
        public static DataSet GetListLastByCategoryRec(int сategoryID, bool ifEnabled, int count, string special)
        {
            DataSet productList = DALCProduct.GetListLastByCategoryRec(сategoryID, ifEnabled, count, special);
            return productList;
        }

		/// <summary>
		///		Получает набор последних продуктов по признаку действительности и ID пользователя
		/// </summary>
		public static DataSet GetListLast(bool ifEnabled, int count, int userID)
		{
			DataSet productList = DALCProduct.GetListLast(ifEnabled, count, userID);
			return productList;
		}

		/// <summary>
		///		Получает набор продуктов по ID категории, признаку действительности и признаку специальности
		/// </summary>
		public static DataSet GetList(int categoryID, bool ifEnabled, string special)
		{
			DataSet productList = DALCProduct.GetListByCategory(categoryID, ifEnabled, special);
			return productList;
		}

        /// <summary>
        ///		Получает рекурсивный набор продуктов по ID категории, признаку действительности и признаку специальности
        /// </summary>
        /// 

        public static DataSet GetGroupListByCategory(int categoryID)
        {
            DataSet productList = DALCProduct.GetGroupListByCategory(categoryID);
            return productList;
        }

        /// <summary>
        ///		Получает рекурсивный набор продуктов по ID категории, признаку действительности и признаку специальности
        /// </summary>

        public static DataSet GetListRec(int categoryID, bool ifEnabled, string special)
        {
            DataSet productList = DALCProduct.GetListByCategoryRec(categoryID, ifEnabled, special);
            return productList;
        }

		/// <summary>
		///		Получает набор продуктов по ID покупателя и признаку специальности
		/// </summary>
		public static DataSet GetListByCustomer(int customerID, string special)
		{
			DataSet productList = DALCProduct.GetListByCustomer(customerID, special);
			return productList;
		}

		/// <summary>
		///		Получает набор продуктов по ID пользователя
		/// </summary>
		public static DataSet GetListByUser(int userID)
		{
			DataSet productList = DALCProduct.GetListByUser(userID);
			return productList;
		}

		/// <summary>
		///		Получает набор продуктов по ID пользователя и ID категории
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
		///		Получает набор всех продуктов
		/// </summary>
		public static DataSet GetList()
		{
			DataSet productList = DALCProduct.GetList();
			return productList;
		}

		/// <summary>
		///		Обновляет информацию о продукте
		/// </summary>
		public static int Update(int id, string skuNumber, bool enabled, bool personalize, bool persRequired, string name, string description, decimal weight, decimal price, decimal regPrice, decimal persPrice, bool ccSurcharge, bool onSale, string saleText, int inventory, int reorder, int defQuantity, int minQuantity, int PerCase)
		{
			int returnValue = 0;

		//	returnValue = DALCProduct.Update(id,  enabled, personalize, persRequired, name, description, weight, price, regPrice, persPrice, ccSurcharge, onSale, saleText, inventory, reorder, defQuantity, minQuantity, PerCase);

			return returnValue;
		}

		/// <summary>
		///		Удаляет продукт
		/// </summary>
		public static void Delete(int id)
		{
			DALCProduct.Delete(id);
		}

		/// <summary>
		///		Удаляет продукт из категории
		/// </summary>
		public static void RemoveFromCategory(int id, int categoryID)
		{
			DALCProduct.RemoveFromCategory(id, categoryID);
		}

		/// <summary>
		///		Удаляет продукт из информации покупателя
		/// </summary>
		public static void RemoveFromCustomer(int id, int сustomerID)
		{
			DALCProduct.RemoveFromCustomer(id, сustomerID);
		}

		/// <summary>
		///		Удаляет продукт из информации пользователя
		/// </summary>
		public static void RemoveFromUser(int id, int userID)
		{
			DALCProduct.RemoveFromUser(id, userID);
		}

		/// <summary>
		///		Удаляет продукт из категории специальным образом
		/// </summary>
		public static void RemoveFromCategory(int id, int categoryID, string special)
		{
			DALCProduct.RemoveSpecialFromCategory(id, categoryID, special);
		}

        /// <summary>
        ///		Удаляет все продукты из категории специальным образом
        /// </summary>
        public static void RemoveAllFromCategory(int categoryID, string special)
        {
            DALCProduct.RemoveAllSpecialFromCategory(categoryID, special);
        }

		/// <summary>
		///		Удаляет продукт из информации покупателя специальным образом
		/// </summary>
		public static void RemoveFromCustomer(int id, int сustomerID, string special)
		{
			DALCProduct.RemoveSpecialFromCustomer(id, сustomerID, special);
		}

		/// <summary>
		///		Добавляет продукт в категорию
		/// </summary>
		public static void AddToCategory(int id, int categoryID)
		{
			DALCProduct.AddToCategory(id, categoryID,0);
		}

		/// <summary>
		///		Добавляет продукт в информацию покупателя
		/// </summary>
		public static void AddToCustomer(int id, int customerID)
		{
			DALCProduct.AddToCustomer(id, customerID, "", 0);
		}

		/// <summary>
		///		Добавляет продукт в информацию пользователя
		/// </summary>
		public static void AddToUser(int id, int userID)
		{
			DALCProduct.AddToUser(id, userID);
		}

		/// <summary>
		///		Добавляет продукт в категорию специальным образом
		/// </summary>
		public static void AddToCategory(int id, int categoryID, string special,int groupnumber,Boolean display )
		{
			DALCProduct.AddToCategory(id, categoryID, special,groupnumber,display);
		} 

		/// <summary>
		///		Добавляет продукт в информацию покупателя специальным образом
		/// </summary>
		public static void AddToCustomer(int id, int сustomerID, string special)
		{
			DALCProduct.AddToCustomer(id, сustomerID, special, 0);
		}

		/// <summary>
		///		Добавляет продукт в информацию покупателя специальным образом и указанием
		///		максимального количества записей в результате
		/// </summary>
		public static void AddToCustomer(int id, int сustomerID, string special, int maxCount)
		{
			DALCProduct.AddToCustomer(id, сustomerID, special, maxCount);
		}

		#endregion

		#region None Static Methods

		/// <summary>
		///		Обновляет информацию о продукте
		/// </summary>
		public int Update()
		{
			int returnValue = 0;

		/////////////////////	returnValue = Update(this.id,  this.enabled, this.personalize, this.persRequired, this.name, this.description, this.weight, this.price, this.regPrice, this.persPrice, this.ccSurcharge, this.onSale, this.saleText, this.inventory, this.reorder, this.defQuantity, this.minQuantity, this.AmountPerCase, this.intAmountPerCase);
			this.id = returnValue;
			
			return returnValue;
		}
		
		/// <summary>
		///		Удаляет продукт
		/// </summary>
		public void Delete()
		{
			Delete(this.id);
		}
		
		/// <summary>
		///		Инициализирует переменные
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
		///		Получает ID необходимого атрибута
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
		///		Получает значение необходимого атрибута
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













        protected DataSet UpdateDonate(String parm, string commandtext, int buyerid, int orgid, int catid, int itemid, string status, String auctiontype, int auctionid)
        {

            //  int itemid = 0;
            // int orgid=0;  
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
            String commandName = commandtext;

            String prm = parm;


            int credits = 1;


            status = "";

            DataSet ds = new DataSet();

            string commandText = commandtext;
            commandName = commandtext;
            //   string commandName;

            if (prm == "S" || prm == "Z")
            {
                ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
                ds = r.getItems(commandName, prm, buyerid, itemid, orgid, catid, location,
         description, quantity, shippngCost, condition, title,
              startDate, endDate, soldDate, auctiontype, auctionid
         );







            }



            Handling = ds.Tables[0].Columns["handlingtime"].ToString();


            return ds;
        }

























        

        
        //protected DataSet UpdateMessages(String parm, string commandtext, int id, int orgid, int catid, int itemid, string status, String auctiontype, int auctionid)

        protected DataSet UpdateMessages(String parm, String commandtext,   int auctionid,  int orgID ,
            int buyerID, string forumMessage,            string messageType ,
            string messageSeneder   )
        {

            //  int itemid = 0;
            // int orgid=0;  
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
            String commandName = commandtext;

            String prm = parm;


            int credits = 1;


         //   status = "";

              int forumid=0;
              int item_AuctionID = auctionid;// items().msgAuctionID;
            //int orgID=0;
            //int buyerID= BLCustomer.buyerID ;
            //string forumMessage="";
            //string messageType="";
            //string messageSeneder="";

             DateTime forumdate=DateTime.Now;







            DataSet ds = new DataSet();

            string commandText = commandtext;
            commandName = commandtext;
            //   string commandName;

            if (prm == "I" )
            {
                ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
          

        int result=  r.setForum(  commandName,   prm,
                                 forumid,   item_AuctionID,   orgID,   buyerID,   forumMessage,   messageType,   messageSeneder,   forumdate);

            }
                else
            {
                if (prm == "S")
                {
                    ds = r.getForum(commandName, prm,
                                           forumid, item_AuctionID, orgID, buyerID, forumMessage, messageType, messageSeneder, forumdate);
                }
            }



            return ds;
        }













































		/// <summary>
		///		Получает ID значения необходимого атрибута
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
		///		Получает информацию о продукте
		/// </summary>
		public void Retrieve()
		{
			RetrieveByUser(-1);
		}

		/// <summary>
		///		Получает информацию о продукте по ID пользователя
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
		///		Инициализирует информацию о продукте
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion
		
		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса BLProduct
		/// </summary>
		public BLItem()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
	

    





	}




//}

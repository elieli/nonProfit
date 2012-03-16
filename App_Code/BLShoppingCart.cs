using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Summary description for BLShoppingCart.
	/// </summary>
	public class BLShoppingCart
    {
        Referrer r = new Referrer();
		#region Fields
		
		private int customerID;
		private DataSet shoppingCart;
		
		#endregion

		#region Properties
		
		public int CustomerID
		{
			get{ return customerID; }
			set{ customerID = value; }
		}

		public DataSet Products
		{
			get{ return shoppingCart; }
		}
		
		public int ItemsCount
		{
			get
			{ 
				int itemCount=0;
				if(shoppingCart!=null && shoppingCart.Tables.Count > 0)
				{
					foreach(DataRow row in shoppingCart.Tables["ShoppingCart"].Rows)
					{
						try
                        {
                           // itemCount += Convert.ToInt32(row["cartQuantity"]);
							itemCount+=Convert.ToInt32(row["Quantity"]);
						}
						catch
						{
							itemCount++;
						}
					}
				}
				return itemCount; 
			}
		}

		public decimal TotalPrice
		{
			get
			{ 
				decimal totalPrice=0;
				if(shoppingCart!=null && shoppingCart.Tables.Count > 0)
				{
					foreach(DataRow row in shoppingCart.Tables["ShoppingCart"].Rows)
					{
						try
						{

                           // totalPrice += (Convert.ToDecimal(row["ProductPrice"])) * Convert.ToInt32(row["Quantity"]) + (Convert.ToBoolean(row["Personalize"]) ? Convert.ToDecimal(row["ProductPersPrice"]) : 0);

                            totalPrice += (Convert.ToDecimal(row["currentBidPrice"])) * Convert.ToInt32(row["Quantity"]) + (Convert.ToBoolean(row["Personalize"]) ? Convert.ToDecimal(row["ProductPersPrice"]) : 0);
						}
						catch
						{
						}
					}
				}
				return totalPrice; 
			}
		}

        public decimal TotalWeight
        {
            get
            { 
                decimal totalWeight=0;
                if(shoppingCart!=null && shoppingCart.Tables.Count > 0)
                {
                    foreach(DataRow row in shoppingCart.Tables["ShoppingCart"].Rows)
                    {
                        try
                        {
                            totalWeight+=Convert.ToDecimal(row["ProductWeight"]) * Convert.ToInt32(row["Quantity"]);
                        }
                        catch
                        {
                        }
                    }
                }
                return totalWeight; 
            }
        }

		#endregion

		#region Methods

        public decimal GetTotalCCSurcharge(decimal ccSurcharge)
        {
            decimal totalCCSurcharge=0;
            if(shoppingCart!=null && shoppingCart.Tables.Count > 0)
            {
                foreach(DataRow row in shoppingCart.Tables["ShoppingCart"].Rows)
                {
                    try
                    {
                        totalCCSurcharge += (bool)row["ProductCCSurcharge"] ? ((Convert.ToDecimal(row["ProductPrice"])) * Convert.ToInt32(row["Quantity"]) + (Convert.ToBoolean(row["Personalize"]) ? Convert.ToDecimal(row["ProductPersPrice"]) : 0)) * ccSurcharge : 0;
                    }
                    catch
                    {
                    }
                }
            }
            return totalCCSurcharge; 
        }

		public void DeleteProduct(int ProductID)
		{
			DALCShoppingCart.Delete(ProductID, this.customerID);
		}

		#region Add Product
        public void AddProduct(int productID, int quantity, bool personalize) 
        {
            DALCShoppingCart.Add(productID, this.customerID, quantity, personalize);
        }

		public void AddProduct(int productID, int quantity) 
		{
			DALCShoppingCart.Add(productID, this.customerID, quantity);
		}

		public void AddProduct(int productID) 
		{
			DALCShoppingCart.Add(productID, this.customerID);
		}
		#endregion

		#region Add Product With On Stock Check
		public bool AddProductStockCheck(int productID, int quantity, bool personalize) 
		{
			BLProduct product = new BLProduct();
			product.ID = productID;
			product.Retrieve();

			DataRow[] rows = this.Products.Tables[0].Select("ProductID=" + productID.ToString());
			int prdQuantityAtCart = ( rows.Length > 0 ) ? (int)(rows[0]["Quantity"]) : 0;

			if( quantity + prdQuantityAtCart > product.Inventory )
				return false;
			else
				DALCShoppingCart.Add(productID, this.customerID, quantity, personalize);

			return true;
		}






//NEW

        public decimal GetTotalquantity(int productID)
        {
            decimal totalCCSurcharge = 0; decimal ccSurcharge = 0;
            if (shoppingCart != null && shoppingCart.Tables.Count > 0)
            {
                foreach (DataRow row in shoppingCart.Tables["ShoppingCart"].Rows)
                {
                    try
                    {
                        totalCCSurcharge += (bool)row["ProductCCSurcharge"] ? ((Convert.ToDecimal(row["ProductPrice"])) * Convert.ToInt32(row["Quantity"]) + (Convert.ToBoolean(row["Personalize"]) ? Convert.ToDecimal(row["ProductPersPrice"]) : 0)) * ccSurcharge : 0;
                    }
                    catch
                    {
                    }
                }
            }
            return totalCCSurcharge;
        }


//NEW








		public bool AddProductStockCheck(int productID, int quantity) 
		{
//			BLProduct product = new BLProduct();
//			product.ID = productID;
//			product.Retrieve();
//
//			if( quantity > product.Inventory )
//				return false;
//			else
//				DALCShoppingCart.Add(productID, this.customerID, quantity);
//
//			return true;

			return AddProductStockCheck(productID, quantity, false);
		}

		public bool AddProductStockCheck(int productID) 
		{
//			BLProduct product = new BLProduct();
//			product.ID = productID;
//			product.Retrieve();
//
//			if( product.Inventory < 1 )
//				return false;
//			else
//				DALCShoppingCart.Add(productID, this.customerID);
//
//			return true;

			return AddProductStockCheck(productID, 1, false);
		}
		#endregion


		public void AddProductAttribute(int ProductID, int AttributeID, string AttributeValue)
		{
			DALCShoppingCart.AddProductAttribute(ProductID, this.customerID, AttributeID, AttributeValue);
		}
		public void AddProductAttribute(int ProductID, int AttributeID, int AttributeValueID, string AttributeValue)
		{
			DALCShoppingCart.AddProductAttribute(ProductID, this.customerID, AttributeID, AttributeValueID, AttributeValue);
		}
		
		
		public void Clear()
		{
			DALCShoppingCart.Clear(this.customerID);
		}

		public void SetQuantity(int ProductID, int Quantity)
		{
			DALCShoppingCart.SetQuantity(ProductID, this.customerID, Quantity);
		}
		
		public bool SetQuantityStockCheck(int ProductID, int Quantity)
		{
			BLProduct product = new BLProduct();
			product.ID = ProductID;
			product.Retrieve();

			if( Quantity > product.Inventory )
				return false;
			else
				DALCShoppingCart.SetQuantity(ProductID, this.customerID, Quantity);

			return true;
		}

        public void SetPersonalize(int ProductID, bool Personalize)
        {
            DALCShoppingCart.SetPersonalize(ProductID, this.customerID, Personalize);
        }

		public void Retrieve()
        {
            //BLOrganization orgs; 
            //int ogid = fillCart(orgs);
			    //Init();
		}








        public static DataSet fillcarts(ref BLCustomer cst)
        {
            BLOrganization orgs = (BLOrganization)cst.Organization;


            DataSet ds = new DataSet();
         ds=  orgs.ShoppingCart.fillCart(orgs);

         return ds;

        }




        protected DataSet fillCart(BLOrganization orgs)
         {


                     
            String parm; string commandtext=""; int id; 
            int orgid; int catid=0;
            int itemid=0; string status;
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

            String prm ="C";// parm;


            int credits = 3;


            status = "";

            DataSet ds = new DataSet();

            string commandText =    commandtext;
            commandName ="get_Items"  ;// commandtext;
            //   string commandName;
 
                ///orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
                ds = r.getItems(commandName, prm,buyerid, itemid, orgid, catid, location,
         description, quantity, shippngCost, condition, title,
              startDate, endDate, soldDate, auctiontype, auctionid);



           

            if( ds.Tables.Count > 0 )
				{


                    orgs.ShoppingCart.shoppingCart  = ds;
            }

            return ds;
        }
































		private void Init()
		{


            
         
   

			if( this.customerID > 0 )
			{
				DataSet items = DALCShoppingCart.GetItem(this.customerID);
				if( items.Tables.Count > 0 )
				{
					this.shoppingCart = items;
				}
				else
				{
					ClearFields();
				}
			}
			else
			{
				this.customerID = 0;
				ClearFields();
			}
		}

		private void ClearFields()
		{
			this.shoppingCart = null;
		}

		
		#endregion
		
		public BLShoppingCart()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
//}

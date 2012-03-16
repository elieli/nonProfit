using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Класс BLPrice реализует бизнес-логику цены.
	/// </summary>
	public class BLPrice
	{

		#region Fields

		#region Private Fields

		private int id;
		private int productID;
		private int quantity;
        private decimal price;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

		#endregion

		#endregion

		#region Methods

		#region Static Methods

		public static DataSet GetList()
		{
			return DALCPrice.GetList();
		}

		public static DataSet GetList(int productID)
		{
			return GetList(productID, 1);
		}
		
        public static DataSet GetList(int productID, int minQuantity)
        {
            DataSet resList = null;
	
            resList = DALCPrice.GetList(productID, minQuantity);

            return resList;
        }

		public static void Delete(int id)
		{
			DALCPrice.Delete(id);
		}

        public static decimal GetPriceByQuantity(int productID, int quantity)
        {
            return DALCPrice.GetPriceByQuantity(productID, quantity);
        }

        public static int Update(int id, int productID, int quantity, decimal price)
        {
            return DALCPrice.Update(id, productID, quantity, price);
        }

        public static void CopyToProduct(int productID, int toProductID)
        { 
            DALCPrice.CopyToProduct(productID, toProductID);
        }

        public static void DeleteByProduct(int productID)
        { 
            DALCPrice.DeleteByProduct(productID);
        }

        public static void MoveToProduct(int productID, int toProductID)
        { 
            DALCPrice.DeleteByProduct(toProductID);
            DALCPrice.CopyToProduct(productID, toProductID);
            DALCPrice.DeleteByProduct(productID);
        }

		#endregion

		#region None static methods
		
		public void Delete()
		{
			Delete(this.id);
		}

		public int Update()
		{
			this.id = Update(this.id, this.productID, this.quantity, this.price);
            return this.id;
		}

		private void FieldInitialization()
		{
			this.id = 0;
			this.productID = -1;
			this.quantity = 0;
            this.price = 0;
		}

		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCPrice.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
                    DataRow row = item.Tables["Price"].Rows[0];
					this.id = Convert.ToInt32( row["ID"] );
					this.productID = Convert.ToInt32( row["_ProductID"] );
                    this.quantity = (int)row["Quantity"];
                    this.price = (decimal)row["Price"];
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		#endregion

		#endregion

		#region Constructors
		
		public BLPrice()
		{
            Retrieve();
		}

        public BLPrice(int id)
        {
            this.id = id;
            Retrieve();
        }

		#endregion

	}
//}

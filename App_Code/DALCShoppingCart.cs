using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
////using Microsoft.ApplicationBlocks.Data;

//
//{
	/// <summary>
	/// Summary description for DALCShoppingCart.
	/// </summary>
	public class DALCShoppingCart
	{
		
		#region Fields

		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		
		#endregion

		#region Static Methods
		
		public static void Add(int ProductID, int CustomerID)
		{
			Add(ProductID, CustomerID, 0, false);
		}
		
        public static void Add(int ProductID, int CustomerID, int Quantity)
        {
            Add(ProductID, CustomerID, Quantity, false);
        }

		public static void Add(int ProductID, int CustomerID, int Quantity, bool Personalize)
		{
			SqlParameter[] arParams = new SqlParameter[4];

			arParams[0] = new SqlParameter("@cs2p_ProductID", ProductID);
			arParams[1] = new SqlParameter("@cs2p_CustomerID", CustomerID);
			arParams[2] = new SqlParameter("@cs2pQuantity", Quantity);
            arParams[3] = new SqlParameter("@cs2pPersonalize", Personalize);

			SqlHelper.ExecuteScalar(connectionString, "ecom_ShoppingCart_Add", arParams);
		}

		public static void AddProductAttribute(int ProductID, int CustomerID, int AttributeID, string AttributeValue)
		{
			AddProductAttribute(ProductID, CustomerID, AttributeID, -1, AttributeValue);
		}
		public static void AddProductAttribute(int ProductID, int CustomerID, int AttributeID, int AttributeValueID, string AttributeValue)
		{
			SqlParameter[] arParams = new SqlParameter[5];

			arParams[0] = new SqlParameter("@ProductID", ProductID);
			arParams[1] = new SqlParameter("@CustomerID", CustomerID);
			arParams[2] = new SqlParameter("@AttributeID", AttributeID);
			arParams[3] = new SqlParameter("@AttributeValueID", AttributeValueID <= 0 ? (object)DBNull.Value : AttributeValueID );
			arParams[4] = new SqlParameter("@AttributeValue", AttributeValue);

			SqlHelper.ExecuteScalar(connectionString, "ecom_ShoppingCart_AddAttribute", arParams);
		}

		public static void Delete(int ProductID, int CustomerID)
		{
			SqlParameter[] arParams = new SqlParameter[2];

			arParams[0] = new SqlParameter("@cs2p_ProductID", ProductID);
			arParams[1] = new SqlParameter("@cs2p_CustomerID", CustomerID);

			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ShoppingCart_Delete", arParams);
		}

		public static void Clear(int CustomerID)
		{
			SqlParameter param = new SqlParameter("@cs2p_CustomerID", CustomerID);
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ShoppingCart_Clear", param);
		}

		public static void SetQuantity(int ProductID, int CustomerID, int Quantity)
		{
			SqlParameter[] arParams = new SqlParameter[3];

			arParams[0] = new SqlParameter("@cs2p_ProductID", ProductID <= 0?
				DBNull.Value : (object)ProductID
				);
			arParams[1] = new SqlParameter("@cs2p_CustomerID", CustomerID <= 0?
				DBNull.Value : (object)CustomerID);
			arParams[2] = new SqlParameter("@cs2pQuantity", Quantity);

			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ShoppingCart_SetQuantity", arParams);
		}
		
        public static void SetPersonalize(int ProductID, int CustomerID, bool Personalize)
        {
            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@cs2p_ProductID", ProductID <= 0?
                DBNull.Value : (object)ProductID
                );
            arParams[1] = new SqlParameter("@cs2p_CustomerID", CustomerID <= 0?
                DBNull.Value : (object)CustomerID);
            arParams[2] = new SqlParameter("@cs2pPersonalize", Personalize);

            SqlHelper.ExecuteNonQuery(connectionString, "ecom_ShoppingCart_SetPersonalize", arParams);
        }

		public static DataSet GetItem(int CustomerID)
		{
			DataSet itemDataSet = null;
			DataSet tmpDataSet = null;
			
			SqlParameter itemID = new SqlParameter("@ID", CustomerID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_ShoppingCart_GetItem", itemID);

			itemDataSet = new DataSet("ShoppingCart");
			
			DataTable itemTable = new DataTable("ShoppingCart");
			
			itemTable.Columns.Add("ProductID", int.MinValue.GetType() );
            itemTable.Columns.Add("SkuNumber", int.MinValue.GetType()); //new
            itemTable.Columns.Add("subSkuNumber", int.MinValue.GetType()); //new
            itemTable.Columns.Add("skuQuantity", int.MinValue.GetType()); //new
            itemTable.Columns.Add("skuPrice", decimal.MinValue.GetType());//new
       
            itemTable.Columns.Add("Quantity", int.MinValue.GetType() );
            itemTable.Columns.Add("Personalize", typeof(bool) );
			itemTable.Columns.Add("ProductSkuNumber", string.Empty.GetType() );
			itemTable.Columns.Add("ProductEnabled", true.GetType() );
			itemTable.Columns.Add("ProductName", string.Empty.GetType() );
			itemTable.Columns.Add("ProductDescription", string.Empty.GetType() );
            itemTable.Columns.Add("ProductWeight", decimal.MinValue.GetType() );
			itemTable.Columns.Add("ProductPrice", decimal.MinValue.GetType() );
            itemTable.Columns.Add("ProductPersPrice", decimal.MinValue.GetType() );
            itemTable.Columns.Add("ProductPersonalize", typeof(bool) );
            itemTable.Columns.Add("ProductPersRequired", typeof(bool) );
            itemTable.Columns.Add("ProductCCSurcharge", typeof(bool) );
			itemTable.Columns.Add("ProductInventory", int.MinValue.GetType() );
			itemTable.Columns.Add("ProductReorder", int.MinValue.GetType() );

			itemTable.Columns.Add("CustomerID", int.MinValue.GetType() );

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();
					
					newRow["ProductID"] = Convert.ToInt32( row["prdID"] );
				    newRow["Quantity"] = row["cs2pQuantity"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["cs2pQuantity"] );
 


                    newRow["SkuNumber"] = row["SkuNumber"] == DBNull.Value ? 0 :
                        Convert.ToInt32(row["SkuNumber"]);

                    newRow["subSkuNumber"] = row["subSkuNumber"] == DBNull.Value ? 0 :
                        Convert.ToInt32(row["subSkuNumber"]);
                     





                    newRow["Personalize"] = row["cs2pPersonalize"] == DBNull.Value ? false :
                        Convert.ToBoolean( row["cs2pPersonalize"] );
					newRow["ProductSkuNumber"] = row["prdSkuNumber"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["prdSkuNumber"] );
					newRow["ProductEnabled"] = row["prdEnabled"] == DBNull.Value ? false :
						Convert.ToBoolean( row["prdEnabled"] );
					newRow["ProductName"] = row["prdName"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["prdName"] );
					newRow["ProductDescription"] = row["prdDescription"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["prdDescription"] );
                    newRow["ProductWeight"] = row["prdWeight"] == DBNull.Value ? 0 :
                        Convert.ToDecimal( row["prdWeight"] );
					newRow["ProductPrice"] = row["AdvPrice"] == DBNull.Value ? 0 :
						Convert.ToDecimal( row["AdvPrice"] );
                    newRow["ProductPersPrice"] = row["prdPersPrice"] == DBNull.Value ? 0 :
                        Convert.ToDecimal( row["prdPersPrice"] );
                    newRow["ProductPersonalize"] = row["prdPersonalize"] == DBNull.Value ? false :
                        Convert.ToBoolean( row["prdPersonalize"] );
                    newRow["ProductPersRequired"] = row["prdPersRequired"] == DBNull.Value ? false :
                        Convert.ToBoolean( row["prdPersRequired"] );
                    newRow["ProductCCSurcharge"] = row["prdCCSurcharge"] == DBNull.Value ? false :
                        Convert.ToBoolean( row["prdCCSurcharge"] );
					newRow["ProductInventory"] = row["prdInventory"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["prdInventory"] );
					newRow["ProductReorder"] = row["prdReorder"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["prdReorder"] );

					newRow["CustomerID"] = row["cs2p_CustomerID"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["cs2p_CustomerID"] );

					itemTable.Rows.Add(newRow);
				}
			}

			itemDataSet.Tables.Add(itemTable);

			return itemDataSet;
		}

		#endregion
		
		private DALCShoppingCart()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
//}


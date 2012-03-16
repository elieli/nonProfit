using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCProduct реализует логику доступа к данным продукта.
	/// </summary>
	public class DALCProduct 
	{

		#region Fields

		#region Private Fields
		
		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string m_sConnectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];

		#endregion

		#endregion

		#region Methods

		#region Static Methods
		
		/// <summary>
		///		Удаляет продукт
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter spPrdID = new SqlParameter("@prdID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_Delete", spPrdID);
		}

		/// <summary>
		///		Удаляет продукт из категории
		/// </summary>
		public static void RemoveFromCategory(int id, int categoryID)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spCategoryID = new SqlParameter("@CategoryID", categoryID);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_RemoveFromCategory", spProductID, spCategoryID);
		}

		/// <summary>
		///		Удаляет продукт из информации покупателя
		/// </summary>
		public static void RemoveFromCustomer(int id, int customerID)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spCustomerID = new SqlParameter("@CustomerID", customerID);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_RemoveFromCustomer", spProductID, spCustomerID);
		}

		/// <summary>
		///		Удаляет продукт из информации пользователя
		/// </summary>
		public static void RemoveFromUser(int id, int userID)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_RemoveFromUser", spProductID, spUserID);
		}

        /// <summary>
        ///		Удаляет все продукты из категории специальным образом
        /// </summary>
        public static void RemoveAllSpecialFromCategory(int categoryID, string special)
        {
            SqlParameter spCategoryID = new SqlParameter("@CategoryID", categoryID);
            SqlParameter spSpecial = new SqlParameter("@Special", special);
            SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_RemoveAllSpecialFromCategory", spCategoryID, spSpecial);
        }

		/// <summary>
		///		Удаляет продукт из категории специальным образом
		/// </summary>
		public static void RemoveSpecialFromCategory(int id, int categoryID, string special)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spCategoryID = new SqlParameter("@CategoryID", categoryID);
			SqlParameter spSpecial = new SqlParameter("@Special", special);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_RemoveSpecialFromCategory", spProductID, spCategoryID, spSpecial);
		}

		/// <summary>
		///		Удаляет продукт из информации покупателя специальным образом
		/// </summary>
		public static void RemoveSpecialFromCustomer(int id, int customerID, string special)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spCustomerID = new SqlParameter("@CustomerID", customerID);
			SqlParameter spSpecial = new SqlParameter("@Special", special);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_RemoveSpecialFromCustomer", spProductID, spCustomerID, spSpecial);
		}

		/// <summary>
		///		Добавляет продукт в категорию
		/// </summary>
		public static void AddToCategory(int id, int categoryID, string special , int groupNumber , Boolean Display)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spCategoryID = new SqlParameter("@CategoryID", categoryID);
			SqlParameter spSpecial = new SqlParameter("@Special", special);
            SqlParameter spgroupNumber = new SqlParameter("@groupNumber", groupNumber);
            SqlParameter spDisplay = new SqlParameter("@Display", Display);




			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_AddToCategory", spProductID, spCategoryID, spSpecial);
		}



        public static void AddToCategory(int id, int categoryID , int groupNumber )
        {
            bool Display = true; String special = "";

            SqlParameter spProductID = new SqlParameter("@ProductID", id);
            SqlParameter spCategoryID = new SqlParameter("@CategoryID", categoryID);
            SqlParameter spSpecial = new SqlParameter("@Special", special);
            SqlParameter spgroupNumber = new SqlParameter("@groupNumber", groupNumber);
            SqlParameter spDisplay = new SqlParameter("@Display", Display);




            SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_AddToCategory", spProductID, spCategoryID, spSpecial);
        }




		/// <summary>
		///		Добавляет продукт в информацию покупателя
		/// </summary>
		public static void AddToCustomer(int id, int customerID, string special, int maxCount)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spCustomerID = new SqlParameter("@CustomerID", customerID);
			SqlParameter spSpecial = new SqlParameter("@Special", special);
			SqlParameter spMaxCount = new SqlParameter("@MaxCount", maxCount);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_AddToCustomer", spProductID, spCustomerID, spSpecial, spMaxCount);
		}

		/// <summary>
		///		Добавляет продукт в информацию пользователя
		/// </summary>
		public static void AddToUser(int id, int userID)
		{
			SqlParameter spProductID = new SqlParameter("@ProductID", id);
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Product_AddToUser", spProductID, spUserID);
		}

		/// <summary>
		///		Обновляет информацию о продукте
		/// </summary>
		public static int Update(int id, string skuNumber, bool enabled, bool personalize, bool persRequired, string name, string description, decimal weight, decimal price, decimal regPrice, decimal persPrice, bool ccSurcharge, bool onSale, string saleText, int inventory, int reorder, int defQuantity, int minQuantity, int AmountPerCase)
		{
			int returnValue = 0;
			SqlParameter[] sqlParameters = new SqlParameter[19];

			sqlParameters[0] = new SqlParameter("@prdID", id);
			sqlParameters[1] = new SqlParameter("@prdSkuNumber", skuNumber);
			sqlParameters[2] = new SqlParameter("@prdEnabled", enabled);
            sqlParameters[3] = new SqlParameter("@prdPersonalize", personalize);
            sqlParameters[4] = new SqlParameter("@prdPersRequired", persRequired);
			sqlParameters[5] = new SqlParameter("@prdName", name);
			sqlParameters[6] = new SqlParameter("@prdDescription", description);
            sqlParameters[7] = new SqlParameter("@prdWeight", weight);
			sqlParameters[8] = new SqlParameter("@prdPrice", price);
			sqlParameters[9] = new SqlParameter("@prdRegPrice", regPrice);
			sqlParameters[10] = new SqlParameter("@prdPersPrice", persPrice);
            sqlParameters[11] = new SqlParameter("@prdCCSurcharge", ccSurcharge);
			sqlParameters[12] = new SqlParameter("@prdOnSale", onSale);
			sqlParameters[13] = new SqlParameter("@prdSaleText", saleText);
			sqlParameters[14] = new SqlParameter("@prdInventory", inventory);
			sqlParameters[15] = new SqlParameter("@prdReorder", reorder);
			sqlParameters[16] = new SqlParameter("@prdDefQuantity", defQuantity);
            sqlParameters[17] = new SqlParameter("@prdMinQuantity", minQuantity);
			sqlParameters[18] = new SqlParameter("@prdAmntPerCase", AmountPerCase);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Product_Update", sqlParameters) );

			return returnValue;
		}
		
		/// <summary>
		///		Преобразовывает набор продуктов
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;

			dataSet = new DataSet("Products");
			
			DataTable table = new DataTable("Product");

			table.Columns.Add("prdID", int.MinValue.GetType() );
			table.Columns.Add("prdSkuNumber", string.Empty.GetType() );
			table.Columns.Add("prdEnabled", false.GetType() );
            table.Columns.Add("prdPersonalize", false.GetType() );
            table.Columns.Add("prdPersRequired", false.GetType() );
			table.Columns.Add("prdName", string.Empty.GetType() );
			table.Columns.Add("prdDescription", string.Empty.GetType() );
            table.Columns.Add("prdWeight", decimal.MinValue.GetType() );
			table.Columns.Add("prdPrice", decimal.MinValue.GetType() );
			table.Columns.Add("prdRegPrice", decimal.MinValue.GetType() );
			table.Columns.Add("prdPersPrice", decimal.MinValue.GetType() );
            table.Columns.Add("prdCCSurcharge", false.GetType() );
			table.Columns.Add("prdOnSale", false.GetType() );
			table.Columns.Add("prdSaleText", string.Empty.GetType() );
			table.Columns.Add("prdInventory", int.MinValue.GetType() );
			table.Columns.Add("prdReorder", int.MinValue.GetType() );
			table.Columns.Add("prdDefQuantity", int.MinValue.GetType() );
            table.Columns.Add("prdMinQuantity", int.MinValue.GetType() );
			table.Columns.Add("c2pOrder", int.MinValue.GetType() );
            table.Columns.Add("ifSpecial", typeof(bool) );
            table.Columns.Add("Price", decimal.MinValue.GetType() );
			table.Columns.Add("prdAmountPerCase", int.MinValue.GetType());
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["prdID"] = Convert.ToInt32( row["prdID"] );
					newRow["prdSkuNumber"] = Convert.ToString( row["prdSkuNumber"] );
					try
					{
						newRow["prdEnabled"] = Convert.ToBoolean( row["prdEnabled"] );
					}
					catch
					{
						newRow["prdEnabled"] = false;
					}
                    try
                    {
                        newRow["prdPersonalize"] = Convert.ToBoolean( row["prdPersonalize"] );
                    }
                    catch
                    {
                        newRow["prdPersonalize"] = false;
                    }
                    try
                    {
                        newRow["prdPersRequired"] = Convert.ToBoolean( row["prdPersRequired"] );
                    }
                    catch
                    {
                        newRow["prdPersRequired"] = false;
                    }
					newRow["prdName"] = Convert.ToString( row["prdName"] );
					newRow["prdDescription"] = Convert.ToString( row["prdDescription"] );
                    try
                    {
                        newRow["prdWeight"] = Convert.ToDecimal( row["prdWeight"] );
                    }
                    catch
                    {
                        newRow["prdWeight"] = 0;
                    }
					try
					{
						newRow["prdPrice"] = Convert.ToDecimal( row["prdPrice"] );
					}
					catch
					{
						newRow["prdPrice"] = 0;
					}
					try
					{
						newRow["prdRegPrice"] = Convert.ToDecimal( row["prdRegPrice"] );
					}
					catch
					{
						newRow["prdRegPrice"] = 0;
					}
					try
					{
						newRow["prdPersPrice"] = Convert.ToDecimal( row["prdPersPrice"] );
					}
					catch
					{
						newRow["prdPersPrice"] = 0;
					}
                    try
                    {
                        newRow["prdCCSurcharge"] = Convert.ToBoolean( row["prdCCSurcharge"] );
                    }
                    catch
                    {
                        newRow["prdCCSurcharge"] = false;
                    }
					try
					{
						newRow["prdOnSale"] = Convert.ToBoolean( row["prdOnSale"] );
					}
					catch
					{
						newRow["prdOnSale"] = false;
					}
					newRow["prdSaleText"] = Convert.ToString( row["prdSaleText"] );
					try
					{
						newRow["prdInventory"] = Convert.ToInt32( row["prdInventory"] );
					}
					catch
					{
						newRow["prdInventory"] = 0;
					}
					try
					{
						newRow["prdReorder"] = Convert.ToInt32( row["prdReorder"] );
					}
					catch
					{
						newRow["prdReorder"] = 0;
					}
					try
					{
						newRow["prdDefQuantity"] = Convert.ToInt32( row["prdDefQuantity"] );
					}
					catch
					{
						newRow["prdDefQuantity"] = 0;
					}
                    try
                    {
                        newRow["prdMinQuantity"] = Convert.ToInt32( row["prdMinQuantity"] );
                    }
                    catch
                    {
                        newRow["prdMinQuantity"] = 0;
                    }
					try
					{
						newRow["c2pOrder"] = Convert.ToInt32( row["c2pOrder"] );
					}
					catch
					{
						newRow["c2pOrder"] = int.MinValue;
					}
                    try
                    {
                        newRow["ifSpecial"] = Convert.ToBoolean( row["ifSpecial"] );
                    }
                    catch
                    {
                        newRow["ifSpecial"] = false;
                    }
                    try
                    {
                        newRow["Price"] = Convert.ToDecimal( row["Price"] );
                    }
                    catch
                    {
                        newRow["Price"] = 0;
                    }
					try
					{
						newRow["prdAmountPerCase"] = Convert.ToInt32(row["prdAmountPerCase"]);
					}
					catch
					{
						newRow["prdAmountPerCase"] = 1;
					}
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		Получает набор продуктов по ID категории, признаку действительности продукта и признаку специальности
		/// </summary>
		public static DataSet GetListByCategory(int сategoryID, bool ifEnabled, string special)
		{
			DataSet tmpDataSet = null;
			
			if( сategoryID >= 0 )
			{
				SqlParameter spCatID = new SqlParameter("@catID", сategoryID);
				SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
				SqlParameter spSpecial = new SqlParameter("@Special", special);
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListByCategory", spCatID, spIfEnabled, spSpecial);
			}
			else
			{
				SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetList", spIfEnabled);
			}
						
			return ConvertList(tmpDataSet);
		}

        /// <summary>
        ///		Получает рекурсивный набор продуктов по ID категории, признаку действительности продукта и признаку специальности
        /// </summary>
        public static DataSet GetListByCategoryRec(int сategoryID, bool ifEnabled, string special)
        {
            DataSet tmpDataSet = null;
			
            if( сategoryID >= 0 )
            {
                SqlParameter spCatID = new SqlParameter("@catID", сategoryID);
                SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
                SqlParameter spSpecial = new SqlParameter("@Special", special);
                tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListByCategoryRec", spCatID, spIfEnabled, spSpecial);
            }
            else
            {
                SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
                tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetList", spIfEnabled);
            }
						
            return ConvertList(tmpDataSet);
        }

		/// <summary>
		///		Получает набор продуктов по ID покупателя и признаку специальности
		/// </summary>
		public static DataSet GetListByCustomer(int customerID, string special)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spCustomerID = new SqlParameter("@CustomerID", customerID);
			SqlParameter spSpecial = new SqlParameter("@Special", special);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListByCustomer", spCustomerID, spSpecial);
						
			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор продуктов по ID пользователя
		/// </summary>
		public static DataSet GetListByUser(int userID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListByUser", spUserID);
						
			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор продуктов по ID пользователя и ID категории
		/// </summary>
		public static DataSet GetListByUserCat(int userID, int categoryID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			SqlParameter spCatID = new SqlParameter("@catID", categoryID);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListByUserCat", spUserID, spCatID);
						
			return ConvertList(tmpDataSet);
		}

		public static DataSet GetList(string searchParam, bool ifEnabled)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spSearchParam = new SqlParameter("@search", searchParam);
			SqlParameter spIfEnabled = new SqlParameter("@ifEnabled", ifEnabled);
			SqlParameter spSpecial = new SqlParameter("@Special", "SFeatured");
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListBySearchWithCategory", spSearchParam, spIfEnabled, spSpecial);
			//tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListBySearch", spSearchParam, spIfEnabled);			
			return ConvertList(tmpDataSet);
		}
		
		public static DataSet GetListLast(bool ifEnabled, int count)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
			SqlParameter spCount = new SqlParameter("@Count", count);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListLast", spIfEnabled, spCount);
						
			return ConvertList(tmpDataSet);
		}

        public static DataSet GetListLastByCategory(int сategoryID, bool ifEnabled, int count, string special)
        {
            DataSet tmpDataSet = null;
			
            SqlParameter spCatID = new SqlParameter("@catID", сategoryID);
            SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
            SqlParameter spCount = new SqlParameter("@Count", count);
            SqlParameter spSpecial = new SqlParameter("@Special", special);
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListLastByCategory", spCatID, spIfEnabled, spCount, spSpecial);
						
            return ConvertList(tmpDataSet);
        }



        public static DataSet GetGroupListByCategory(int сategoryID)
        {
            DataSet tmpDataSet = null;

            SqlParameter spCatID = new SqlParameter("@catID", сategoryID);
             //////////////////////  tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetGroupListLastByCategory", spCatID, spIfEnabled, spCount, spSpecial);

            return ConvertList(tmpDataSet);
        }





        public static DataSet GetListLastByCategoryRec(int сategoryID, bool ifEnabled, int count, string special)
        {
            DataSet tmpDataSet = null;
			
            SqlParameter spCatID = new SqlParameter("@catID", сategoryID);
            SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
            SqlParameter spCount = new SqlParameter("@Count", count);
            SqlParameter spSpecial = new SqlParameter("@Special", special);
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListLastByCategoryRec", spCatID, spIfEnabled, spCount, spSpecial);
						
            return ConvertList(tmpDataSet);
        }

		public static DataSet GetListLast(bool ifEnabled, int count, int userID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spIfEnabled = new SqlParameter("@IfEnabled", ifEnabled);
			SqlParameter spCount = new SqlParameter("@Count", count);
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListLastAndUser", spIfEnabled, spCount, spUserID);
						
			return ConvertList(tmpDataSet);
		}

		public static DataSet GetListBySearchAndUser(string searchParam, int userID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spSearchParam = new SqlParameter("@searchParam", searchParam);
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetListBySearchAndUser", spSearchParam, spUserID);
						
			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор всех продуктов
		/// </summary>
		public static DataSet GetList()
		{
			return GetListByCategory(-1, false, "");
		}

		/// <summary>
		///		Получает информацию об одном продукте
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spPrdID = new SqlParameter("@prdID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetItem", spPrdID);

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает информацию об одном продукте по ID продукта и ID пользователя
		/// </summary>
		public static DataSet GetItemByUser(int id, int userID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spPrdID = new SqlParameter("@prdID", id);
			SqlParameter spUserID = new SqlParameter("@UserID", userID);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Product_GetItemByUser", spPrdID, spUserID);

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор атрибутов продукта
		/// </summary>
		public static DataSet GetAttributeList(int id)
		{
			return DALCAttribute.GetList(id);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCProduct
		/// </summary>
		private DALCProduct()
		{
		}
		
		#endregion

	}
 

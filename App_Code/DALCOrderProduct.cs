using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCOrderProduct реализует логику доступа к данным продукта ордера.
	/// </summary>
	public class DALCOrderProduct
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
		///		Удаляет продукт ордера
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter orprID = new SqlParameter("@orprID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_OrderProduct_Delete", orprID);
		}

		/// <summary>
		///		Обновляет информацию о продукте ордера
		/// </summary>
		public static int Update(int id, int orderID, int productID, string skuNumber, string name, decimal price, int quantity, bool personalize, decimal persPrice, string persComments, string persFileName, bool isPersonalizationLocked)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[12];

			arParams[0] = new SqlParameter("@orprID", id);
			arParams[1] = new SqlParameter("@orpr_OrderID", orderID <= 0?
				DBNull.Value : (object)orderID);
            arParams[2] = new SqlParameter("@orpr_ProductID", productID <= 0?
                DBNull.Value : (object)productID);
			arParams[3] = new SqlParameter("@orprSkuNumber", skuNumber);
			arParams[4] = new SqlParameter("@orprName", name);
			arParams[5] = new SqlParameter("@orprPrice", price);
			arParams[6] = new SqlParameter("@orprQuantity", quantity);
            arParams[7] = new SqlParameter("@orprPersonalize", personalize);
            arParams[8] = new SqlParameter("@orprPersPrice", persPrice);
			arParams[9] = new SqlParameter("@orprPersComments", persComments);
			arParams[10] = new SqlParameter("@orprPersFileName", persFileName);
			arParams[11] = new SqlParameter("@orprIsPesonalizationLocked", isPersonalizationLocked ? 1:0 );
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_OrderProduct_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор продуктов ордера
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			dataSet = new DataSet("OrderProduct");
			
			DataTable table = new DataTable("OrderProduct");
			
			table.Columns.Add("orprID", int.MinValue.GetType() );
			table.Columns.Add("orpr_OrderID", int.MinValue.GetType() );
            table.Columns.Add("orpr_ProductID", int.MinValue.GetType() );
			table.Columns.Add("orprSkuNumber", string.Empty.GetType() );
			table.Columns.Add("orprName", string.Empty.GetType() );
			table.Columns.Add("orprPrice", decimal.MinValue.GetType() );
			table.Columns.Add("orprQuantity", int.MinValue.GetType() );
            table.Columns.Add("orprPersonalize", typeof(bool) );
            table.Columns.Add("orprPersPrice", decimal.MinValue.GetType() );
			table.Columns.Add("orprPersComments", typeof(string) );
			table.Columns.Add("orprPersFileName", typeof(string) );
			table.Columns.Add("orprIsPersonalizationLocked", typeof(bool) );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["orprID"] = Convert.ToInt32( row["orprID"] );
					newRow["orpr_OrderID"] = row["orpr_OrderID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["orpr_OrderID"] );
                    newRow["orpr_ProductID"] = row["orpr_ProductID"] == DBNull.Value ? -1 :
                        Convert.ToInt32( row["orpr_ProductID"] );
					newRow["orprSkuNumber"] = Convert.ToString( row["orprSkuNumber"] );
					newRow["orprName"] = Convert.ToString( row["orprName"] );
					newRow["orprPrice"] = row["orprPrice"] == DBNull.Value ? -1 :
						Convert.ToDecimal( row["orprPrice"] );
					newRow["orprQuantity"] = row["orprQuantity"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["orprQuantity"] );
                    newRow["orprPersonalize"] = row["orprPersonalize"] == DBNull.Value ? false : Convert.ToBoolean( row["orprPersonalize"] );
                    newRow["orprPersPrice"] = row["orprPersPrice"] == DBNull.Value ? -1 :
                        Convert.ToDecimal( row["orprPersPrice"] );
					newRow["orprPersComments"] = Convert.ToString( row["orprPersComments"] );
					newRow["orprPersFileName"] = row["orprPersFileName"] == DBNull.Value ? string.Empty :(string)row["orprPersFileName"] ;
					newRow["orprIsPersonalizationLocked"] = row["orprIsPersonalizationLocked"] == DBNull.Value ? false:Convert.ToBoolean(row["orprIsPersonalizationLocked"]) ;
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		Получает набор продуктов ордера указанного ордера
		/// </summary>
		public static DataSet GetList(int orderID)
		{
			DataSet tmpDataSet = null;
			
			if (orderID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OrderProduct_GetListByOrderID", new SqlParameter("@OrderID", orderID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OrderProduct_GetList");
			
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		Получает набор всех атрибутов
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		Получает один атрибут
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@orprID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OrderProduct_GetItem", id);

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает GUID пользователя, купившего определенный продукт
		/// </summary>
		/// <param name="orderProductID">
		///		ID OrderProduct'a
		/// </param>
		public static string GetUserGUIDByOrderProductID(int orderProductID)
		{
			string userGUID = null;
			
			SqlParameter ID = new SqlParameter("@OrderProductID", orderProductID);
			///////////////////////userGUID = Convert.ToString((Guid)SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_OrderProduct_GetUserGUIDByOrderProductID", ID));

			return userGUID;
		}


		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCOrderProduct
		/// </summary>
		private DALCOrderProduct()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCPrice реализует логику доступа к цене.
	/// </summary>
	public class DALCPrice
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
		
		public static void Delete(int id)
		{
			SqlParameter prcID = new SqlParameter("@prcID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Price_Delete", prcID);
		}

        public static decimal GetPriceByQuantity(int productID, int quantity)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ProductID", productID <= 0?
                DBNull.Value : (object)productID);
            arParams[1] = new SqlParameter("@Quantity", quantity);
            return (decimal)SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Price_GetPriceByQuantity", arParams);
        }

		public static int Update(int id, int productID, int quantity, decimal price)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[4];

			arParams[0] = new SqlParameter("@prcID", id);
			arParams[1] = new SqlParameter("@prc_ProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@prcQuantity", quantity);
            arParams[3] = new SqlParameter("@prcPrice", price);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Price_Update", arParams) );

			return returnValue;
		}

		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("Price");
			
			DataTable table = new DataTable("Price");
			
			table.Columns.Add("ID", typeof(int) );
			table.Columns.Add("_ProductID", typeof(int) );
            table.Columns.Add("Quantity", typeof(int) );
            table.Columns.Add("Price", typeof(decimal) );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["ID"] = Convert.ToInt32( row["prcID"] );
					newRow["_ProductID"] = row["prc_ProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["prc_ProductID"] );
					newRow["Quantity"] = Convert.ToInt32( row["prcQuantity"] );
                    newRow["Price"] = Convert.ToDecimal( row["prcPrice"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		public static DataSet GetList(int productID, int minQuantity)
		{
			DataSet tmpDataSet = null;
			
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Price_GetListByProductID", new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value)), new SqlParameter("@MinQuantity", minQuantity));
			
			return ConvertList(tmpDataSet);
		}
		
		public static DataSet GetList()
		{
			DataSet tmpDataSet = null;
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Price_GetList");
			
            return ConvertList(tmpDataSet);
		}

        public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@prcID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Price_GetItem", id);

			return ConvertList(tmpDataSet);
		}

        public static void CopyToProduct(int productID, int toProductID)
        {
            SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
            SqlParameter pToProductID = new SqlParameter("@ToProductID", (toProductID>=0?(object)toProductID:DBNull.Value));
            SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Price_CopyToProduct", pProductID, pToProductID);
        }

        public static void DeleteByProduct(int productID)
        {
            SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
            SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Price_DeleteByProduct", pProductID);
        }

		#endregion

		#endregion

		#region Constructors

		private DALCPrice()
		{
		}

        #endregion

	}
 

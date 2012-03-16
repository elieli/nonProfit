using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
//using Microsoft.ApplicationBlocks.Data;
using System.IO;


 
	/// <summary>
	/// Класс DALCRelatedInfo реализует логику доступа к данным связанной информации.
	/// </summary>
	public class DALCRelatedInfo
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
		///		Удаляет связанную информацию
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter rlnfID = new SqlParameter("@rlnfID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_RelatedInfo_Delete", rlnfID);
		}

		/// <summary>
		///		Обновляет информацию о связанной информации
		/// </summary>
		public static int Update(int id, int productID, string name, string description, string url, string special, int order)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[7];

			arParams[0] = new SqlParameter("@rlnfID", id);
			arParams[1] = new SqlParameter("@rlnf_ProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@rlnfName", name);
			arParams[3] = new SqlParameter("@rlnfDescription", description);
			arParams[4] = new SqlParameter("@rlnfURL", url);
			arParams[5] = new SqlParameter("@rlnfSpecial", special);
			arParams[6] = new SqlParameter("@rlnfOrder", order);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_RelatedInfo_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор связанной информации
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			dataSet = new DataSet("RelatedInfo");
			
			DataTable table = new DataTable("RelatedInfo");
			
			table.Columns.Add("rlnfID", int.MinValue.GetType() );
			table.Columns.Add("rlnf_ProductID", int.MinValue.GetType() );
			table.Columns.Add("rlnfName", string.Empty.GetType() );
			table.Columns.Add("rlnfDescription", string.Empty.GetType() );
			table.Columns.Add("rlnfURL", string.Empty.GetType() );
			table.Columns.Add("rlnfSpecial", string.Empty.GetType() );
			table.Columns.Add("rlnfOrder", int.MinValue.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["rlnfID"] = Convert.ToInt32( row["rlnfID"] );
					newRow["rlnf_ProductID"] = row["rlnf_ProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["rlnf_ProductID"] );
					newRow["rlnfName"] = Convert.ToString( row["rlnfName"] );
					newRow["rlnfDescription"] = Convert.ToString( row["rlnfDescription"] );
					newRow["rlnfURL"] = Convert.ToString( row["rlnfURL"] );
					newRow["rlnfSpecial"] = Convert.ToString( row["rlnfSpecial"] );
					newRow["rlnfOrder"] = row["rlnfOrder"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["rlnfOrder"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		Получает набор связанной информации
		/// </summary>
		public static DataSet GetList(int productID, string special)
		{
			DataSet tmpDataSet = null;
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_RelatedInfo_GetListByProduct", new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value)), new SqlParameter("@Special", special));
			
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		Получает набор связанной информации
		/// </summary>
		public static DataSet GetList(int productID)
		{
			return GetList(productID, "");
		}

		/// <summary>
		///		Получает набор всей связанной информации
		/// </summary>
		public static DataSet GetList()
		{
			DataSet tmpDataSet = null;
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_RelatedInfo_GetList");
			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает одну связанную информацию
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@rlnfID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_RelatedInfo_GetItem", id);

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Копирует связанную информацию
		/// </summary>
		public static void CopyToProduct(int productID, int toProductID)
		{
			SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
			SqlParameter pToProductID = new SqlParameter("@ToProductID", (toProductID>=0?(object)toProductID:DBNull.Value));
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_RelatedInfo_CopyToProduct", pProductID, pToProductID);
		}

		/// <summary>
		///		Удаляет связанную информацию продукта
		/// </summary>
		public static void DeleteByProduct(int productID)
		{
			SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_RelatedInfo_DeleteByProduct", pProductID);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCRelatedInfo
		/// </summary>
		private DALCRelatedInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

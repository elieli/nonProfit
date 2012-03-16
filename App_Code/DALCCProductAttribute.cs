using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCCProductAttribute реализует логику доступа к данным атрибута продукта покупателя.
	/// </summary>
	public class DALCCProductAttribute
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
		///		Удаляет атрибут продукта покупателя
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter cpatID = new SqlParameter("@cpatID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_CProduct2Attribute_Delete", cpatID);
		}

		/// <summary>
		///		Обновляет информацию об атрибуте продукта покупателя
		/// </summary>
		public static int Update(int id, int productID, int attributeID, int attributeEnumID, int attributeValueID, string avalue)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[5];

			arParams[0] = new SqlParameter("@cpatID", id);
			arParams[1] = new SqlParameter("@cpat_CProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@cpat_AttributeID", attributeID <= 0?
				DBNull.Value : (object)attributeID);
			arParams[3] = new SqlParameter("@cpat_AttributeValueID", attributeValueID <= 0?
				DBNull.Value : (object)attributeValueID);
			arParams[4] = new SqlParameter("@cpatValue", avalue);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_CProduct2Attribute_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор атрибутов продукта покупателя
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("CProductAttribute");
			
			DataTable table = new DataTable("CProductAttribute");
			
			int tmpTypeInt = 0;
			string tmpTypeString = string.Empty;

			table.Columns.Add("cpatID", tmpTypeInt.GetType() );
			table.Columns.Add("cpat_CProductID", tmpTypeInt.GetType() );
			table.Columns.Add("cpat_AttributeID", tmpTypeInt.GetType() );
			table.Columns.Add("cpat_AttributeValueID", tmpTypeInt.GetType() );
			table.Columns.Add("cpatValue", tmpTypeString.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["cpatID"] = Convert.ToInt32( row["cpatID"] );
					newRow["cpat_CProductID"] = row["cpat_CProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["cpat_CProductID"] );
					newRow["cpat_AttributeID"] = row["cpat_AttributeID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["cpat_AttributeID"] );
					newRow["cpat_AttributeValueID"] = row["cpat_AttributeValueID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["cpat_AttributeValueID"] );
					newRow["cpatValue"] = Convert.ToString( row["cpatValue"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		Получает набор атрибутов указанного продукта покупателя
		/// </summary>
		public static DataSet GetList(int productID)
		{
			DataSet tmpDataSet = null;
			
			if (productID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_CProduct2Attribute_GetListByCProductID", new SqlParameter("@CProductID", productID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_CProduct2Attribute_GetList");
			
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		Получает набор всех атрибутов продуктов покупателей
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		Получает один атрибут продукта покупателя
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@cpatID", id);
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_CProduct2Attribute_GetItem", ID);
		
			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCCProductAttribute
		/// </summary>
		private DALCCProductAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

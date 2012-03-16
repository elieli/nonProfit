using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


//{
	/// <summary>
	/// Класс DALCAttributeValue реализует логику доступа к значению атрибута.
	/// </summary>
	public class DALCAttributeValue
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
		///		Удаляет значение атрибута
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter atevID = new SqlParameter("@atevID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_AttributeValue_Delete", atevID);
		}

		/// <summary>
		///		Обновляет информацию о значении атрибута
		/// </summary>
		public static int Update(int id, string name, string avalue)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[3];

			arParams[0] = new SqlParameter("@atevID", id);
			arParams[1] = new SqlParameter("@atevName", name);
			arParams[2] = new SqlParameter("@atevValue", avalue);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_AttributeValue_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор значений атрибута продукта
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;

			dataSet = new DataSet("AttributeValue");
			
			DataTable table = new DataTable("AttributeValue");
			
			int tmpTypeInt = 0;
			string tmpTypeString = string.Empty;

			table.Columns.Add("atevID", tmpTypeInt.GetType() );
			table.Columns.Add("atevName", tmpTypeString.GetType() );
			table.Columns.Add("atevValue", tmpTypeString.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["atevID"] = Convert.ToInt32( row["atevID"] );
					newRow["atevName"] = Convert.ToString( row["atevName"] );
					newRow["atevValue"] = Convert.ToString( row["atevValue"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		Получает набор значений атрибута по имени
		/// </summary>
		public static DataSet GetList(string name)
		{
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_AttributeValue_GetListByName", new SqlParameter("@Name", name));
			
			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор значений атрибута указанного атрибута
		/// </summary>
		public static DataSet GetList(int attributeID)
		{
			DataSet tmpDataSet = null;
			
			if (attributeID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_AttributeValue_GetListByAttributeID", new SqlParameter("@ProductID", attributeID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_AttributeValue_GetList");
			
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		Получает набор всех значений атрибутов
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		Получает одно значение атрибута
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@atevID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_AttributeValue_GetItem", id);

			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCAttributeValue
		/// </summary>
		private DALCAttributeValue()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
//}

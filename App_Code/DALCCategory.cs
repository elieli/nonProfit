using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCCategory реализует логику доступа к категории.
	/// </summary>
	public class DALCCategory
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
		///		Изменяет порядковый номер категории
		/// </summary>
		public static void ChangeOrder(int id, bool directionUp)
		{
			SqlParameter catID = new SqlParameter("@catID", id);
			SqlParameter prmDirectionUp = new SqlParameter("@directionUp", directionUp);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Category_ChangeOrder", catID, prmDirectionUp);
		}

		/// <summary>
		///		Удаляет категорию
		/// </summary>
		public static int Delete(int id)
		{
			int returnValue = 0;
			SqlParameter catID = new SqlParameter("@catID", id);
			returnValue = Convert.ToInt32( SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Category_Delete", catID) );
			return returnValue;
		}

		/// <summary>
		///		Обновляет информацию о категории
		/// </summary>
		public static int Update(int id, int parentID, string name, int order)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[4];

			arParams[0] = new SqlParameter("@catID", id);
			arParams[1] = new SqlParameter("@catName", name);
			arParams[2] = new SqlParameter("@catParentID", parentID);
			arParams[3] = new SqlParameter("@catOrder", order);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Category_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор категорий
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet categoryList = null;

			categoryList = new DataSet("Category");
			
			DataTable tableCategory = new DataTable("Category");
			
			int tmpTypeInt = 0;
			string tmpTypeString = string.Empty;

			tableCategory.Columns.Add("catID", tmpTypeInt.GetType() );
			tableCategory.Columns.Add("cat_ParentID", tmpTypeInt.GetType() );
			tableCategory.Columns.Add("catLevel", tmpTypeInt.GetType() );
			tableCategory.Columns.Add("catPath", tmpTypeString.GetType() );
			tableCategory.Columns.Add("catName", tmpTypeString.GetType() );
			tableCategory.Columns.Add("catOrder", tmpTypeInt.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = tableCategory.NewRow();
					newRow["catID"] = Convert.ToInt32( row["catID"] );
					newRow["cat_ParentID"] = Convert.ToInt32( row["cat_ParentID"] );
					newRow["catLevel"] = Convert.ToInt32( row["catLevel"] );
					newRow["catPath"] = row["catPath"] != DBNull.Value ? Convert.ToString( row["catPath"] )
						: string.Empty;
					newRow["catName"] = row["catName"] != DBNull.Value ? Convert.ToString( row["catName"] )
						: string.Empty;
					newRow["catOrder"] = row["catOrder"] != DBNull.Value ? Convert.ToInt32( row["catOrder"] )
						: 0;
					tableCategory.Rows.Add(newRow);
				}
			}

			categoryList.Tables.Add(tableCategory);
			
			return categoryList;
		}

		/// <summary>
		///		Получает набор категорий указанной родительской категории
		/// </summary>
		public static DataSet GetList(int parentID)
		{
			DataSet tmpDataSet = null;
			
			if (parentID>=0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Category_GetListByParentID", new SqlParameter("@ParentID", parentID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Category_GetList");

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор категорий, в которых присутствует указанный продукт
		/// </summary>
		public static DataSet GetListByProduct(int productID)
		{
			return GetListByProduct(productID,"");
		}

		/// <summary>
		///		Получает набор категорий, в которых присутствует указанный продукт специальным образом
		/// </summary>
		public static DataSet GetListByProduct(int productID, string special)
		{
			DataSet tmpDataSet = null;
			
			if (productID>=0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Category_GetListByProductID", new SqlParameter("@ProductID", productID), new SqlParameter("@c2pSpecial", special));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Category_GetList");

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор категорий пути
		/// </summary>
		public static DataSet GetPathList(int id)
		{
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Category_GetPathList", new SqlParameter("@catID", id));

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор всех категорий
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		Получает информацию об одной категории
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter catID = new SqlParameter("@catID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Category_GetItem", catID);

			return ConvertList(tmpDataSet);
		}

         

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCCategory
		/// </summary>
		private DALCCategory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

	}
 


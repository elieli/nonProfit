using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCOProductPersField реализует логику доступа к настраиваемым данным продукта ордера.
	/// </summary>
	public class DALCOProductPersField
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
			SqlParameter opfdID = new SqlParameter("@opfdID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_OProductPersField_Delete", opfdID);
		}

		public static int Update(int id, int orderProductID, string name, string text, bool required, string description, string defaultText, int maxChars, int heightLines)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[9];

			arParams[0] = new SqlParameter("@opfdID", id);
			arParams[1] = new SqlParameter("@opfd_OrderProductID", orderProductID <= 0?
				DBNull.Value : (object)orderProductID);
			arParams[2] = new SqlParameter("@opfdName", name);
			arParams[3] = new SqlParameter("@opfdText", text);
            arParams[4] = new SqlParameter("@opfdRequired", required);
            arParams[5] = new SqlParameter("@opfdDescription", description);
            arParams[6] = new SqlParameter("@opfdDefaultText", defaultText);
            arParams[7] = new SqlParameter("@opfdMaxChars", maxChars);
            arParams[8] = new SqlParameter("@opfdHeightLines", heightLines);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_OProductPersField_Update", arParams) );

			return returnValue;
		}

		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("OProductPersField");
			
			DataTable table = new DataTable("OProductPersField");
			
			table.Columns.Add("ID", typeof(int) );
			table.Columns.Add("_OrderProductID", typeof(int) );
			table.Columns.Add("Name", typeof(string) );
			table.Columns.Add("Text", typeof(string) );
            table.Columns.Add("Required", typeof(bool) );
            table.Columns.Add("Description", typeof(string) );
            table.Columns.Add("DefaultText", typeof(string) );
            table.Columns.Add("MaxChars", typeof(int) );
			table.Columns.Add("HeightLines", typeof(int) );
			table.Columns.Add("ExampleImageUrl", typeof(string) );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["ID"] = Convert.ToInt32( row["opfdID"] );
					newRow["_OrderProductID"] = row["opfd_OrderProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["opfd_OrderProductID"] );
					newRow["Name"] = Convert.ToString( row["opfdName"] );
					newRow["Text"] = Convert.ToString( row["opfdText"] );
                    newRow["Required"] = Convert.ToString( row["opfdRequired"] );
                    newRow["Description"] = Convert.ToString( row["opfdDescription"] );
                    newRow["DefaultText"] = Convert.ToString( row["opfdDefaultText"] );
                    newRow["MaxChars"] = Convert.ToString( row["opfdMaxChars"] );
					newRow["HeightLines"] = Convert.ToString( row["opfdHeightLines"] );
					try
					{
						string exampleImageName = Convert.ToString( row["opfdExampleImageName"] );
						string url = string.Empty;
						string imageGalleryUrl = System.Configuration.ConfigurationSettings.AppSettings["ImageGallery_URL"];
						url = System.Web.HttpContext.Current.Request.ApplicationPath + imageGalleryUrl + exampleImageName;
						url = url.Replace("//", "/");
						newRow["ExampleImageUrl"] = url;
					}
					catch
					{
						newRow["ExampleImageUrl"] = string.Empty;
					}
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		public static DataSet GetList(int orderProductID)
		{
			DataSet tmpDataSet = null;
			
			object productID = (orderProductID>0)?(object)orderProductID:DBNull.Value;
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductPersField_GetListByOrderProductID", new SqlParameter("@OrderProductID", productID));
			
			return ConvertList(tmpDataSet);
		}
		
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@opfdID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductPersField_GetItem", id);
		
			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCOProductPersField
		/// </summary>
		private DALCOProductPersField()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

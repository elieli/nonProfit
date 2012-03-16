using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCProductPersField реализует логику доступа к настраиваемым данным продукта.
	/// </summary>
	public class DALCProductPersField
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
			SqlParameter ppfID = new SqlParameter("@ppfID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_ProductPersField_Delete", ppfID);
		}

		public static int Update(int id, int productID, bool enabled, bool required, string name, string description, string defaultText, int maxChars, int heightLines)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[9];

			arParams[0] = new SqlParameter("@ppfID", id);
			arParams[1] = new SqlParameter("@ppf_ProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@ppfEnabled", enabled);
            arParams[3] = new SqlParameter("@ppfRequired", required);
			arParams[4] = new SqlParameter("@ppfName", name);
			arParams[5] = new SqlParameter("@ppfDescription", description);
            arParams[6] = new SqlParameter("@ppfDefaultText", defaultText);
            arParams[7] = new SqlParameter("@ppfMaxChars", maxChars);
			arParams[8] = new SqlParameter("@ppfHeightLines", heightLines);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_ProductPersField_Update", arParams) );

			return returnValue;
		}

		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("ProductPersField");
			
			DataTable table = new DataTable("ProductPersField");
			
			table.Columns.Add("ID", typeof(int) );
			table.Columns.Add("_ProductID", typeof(int) );
            table.Columns.Add("Enabled", typeof(bool) );
            table.Columns.Add("Required", typeof(bool) );
			table.Columns.Add("Name", typeof(string) );
            table.Columns.Add("Description", typeof(string) );
            table.Columns.Add("DefaultText", typeof(string) );
			table.Columns.Add("MaxChars", typeof(int) );
			table.Columns.Add("HeightLines", typeof(int) );
			table.Columns.Add("ExampleImageName", typeof(string) );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["ID"] = Convert.ToInt32( row["ppfID"] );
					newRow["_ProductID"] = row["ppf_ProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["ppf_ProductID"] );
					newRow["Enabled"] = Convert.ToBoolean( row["ppfEnabled"] );
                    newRow["Required"] = Convert.ToBoolean( row["ppfRequired"] );
                    newRow["Name"] = Convert.ToString( row["ppfName"] );
                    newRow["Description"] = Convert.ToString( row["ppfDescription"] );
					newRow["DefaultText"] = Convert.ToString( row["ppfDefaultText"] );
                    newRow["MaxChars"] = Convert.ToInt32( row["ppfMaxChars"] );
					newRow["HeightLines"] = Convert.ToInt32( row["ppfHeightLines"] );
					newRow["ExampleImageName"] = Convert.ToString( row["ppfExampleImageName"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		public static DataSet GetList(int productID)
		{
			DataSet tmpDataSet = null;
			
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_ProductPersField_GetListByProductID", new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value)));
			
			return ConvertList(tmpDataSet);
		}
		
		public static DataSet GetList()
		{
			DataSet tmpDataSet = null;
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_ProductPersField_GetList");
			
            return ConvertList(tmpDataSet);
		}

        public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@ppfID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_ProductPersField_GetItem", id);

			return ConvertList(tmpDataSet);
		}

        public static void CopyToProduct(int productID, int toProductID)
		{
			DataSet fileList = GetList(productID);

			foreach(DataRow row in fileList.Tables[0].Rows)
			{
				//DeleteFile(Convert.ToInt32(row["rlflID"]));
				string name = ((int)row["_ProductID"]>=0?"":"temp/") + row["ExampleImageName"].ToString();
				string fileName = GetFileName(name, string.Empty);

				FileInfo fileInfo = new FileInfo(fileName);
					
				if( fileInfo.Exists )
				{
					string to_name = (toProductID>=0?"":"temp/") + row["ExampleImageName"].ToString();
					string to_fileName = GetFileName(to_name, string.Empty);

					fileInfo.CopyTo(to_fileName, true);
				}
			}

            SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
            SqlParameter pToProductID = new SqlParameter("@ToProductID", (toProductID>=0?(object)toProductID:DBNull.Value));
            SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_ProductPersField_CopyToProduct", pProductID, pToProductID);
        }
		
		public static string GetFileName(string fileName, string fileExtension)
		{
			string url = string.Empty;
			url = System.Web.HttpContext.Current.Request.ApplicationPath + ConfigurationSettings.AppSettings["PersonalizationSampleImage_URL"] + fileName;
			if( fileExtension != string.Empty )
				url += "." + fileExtension;
			url = url.Replace("//", "/");
			string path = string.Empty;
			path = System.Web.HttpContext.Current.Request.MapPath(url);

			return path;
		}

        public static void DeleteByProduct(int productID)
        {
            SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
            SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_ProductPersField_DeleteByProduct", pProductID);
        }

		/// <summary>
		///		Изменяет в БД колонку имени картинки указаного свойства.
		/// </summary>
		/// <param name="persFieldID">ID свойства персонализации.</param>
		/// <param name="imageName">Имя изображения (не длиннее 250 символов)</param>
		public static void UploadExampleImage(int persFieldID, string imageName)
		{
			if( imageName != null)
				if( imageName.Length <= 250 )
				{
					SqlParameter[] parameters = new SqlParameter[2];
					parameters[0] = new SqlParameter("@ppfID", (persFieldID>=0?(object)persFieldID:DBNull.Value));
					parameters[1] = new SqlParameter("@ppfExampleImageName", (object)imageName);

					SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_ProductPersField_UploadImage", parameters);
				}
		}

		public static void DeleteExampleImage(int persFieldID)
		{
			SqlParameter paramID = new SqlParameter("@ppfID", persFieldID);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_ProductPersField_DeleteExampleImage", paramID);
		}
		#endregion

		#endregion

		#region Constructors

		private DALCProductPersField()
		{
		}

        #endregion

	}
 

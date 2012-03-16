using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;



 
	/// <summary>
	/// Summary description for DALCImageGalleryConfig.
	/// </summary>
	public class DALCImageGalleryConfig
	{
		
		#region Fields

		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		
		#endregion
		
		
		public static DataSet GetConfigOption(string imageType)
		{
			DataSet dataSet = null;
			DataSet tmpDataSet = null;
			
			SqlParameter paramAlias = new SqlParameter("@Alias", imageType);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_ImageGallery_GetGonfig", paramAlias);

			dataSet = new DataSet("ImageGallerySettings");
			
			DataTable itemTable = new DataTable("ImageGallerySettings");
			
			itemTable.Columns.Add("maxWidth", int.MinValue.GetType() );
			itemTable.Columns.Add("maxHeight", int.MinValue.GetType() );
			itemTable.Columns.Add("maxCount", int.MinValue.GetType() );
			itemTable.Columns.Add("Alias", string.Empty.GetType() );

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();

					newRow["maxWidth"] = row["maxWidth"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["maxWidth"] );
					newRow["maxHeight"] = row["maxHeight"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["maxHeight"] );
					newRow["maxCount"] = row["maxCount"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["maxCount"] );
					newRow["Alias"] = row["Alias"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["Alias"] );
					
					itemTable.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(itemTable);

			return dataSet;
		}
		
		
		private DALCImageGalleryConfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
 

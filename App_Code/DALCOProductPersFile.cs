using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
//using Microsoft.ApplicationBlocks.Data;
using System.IO;


 
	/// <summary>
	/// Класс DALCOProductPersFile реализует логику доступа к настраиваемым файлам продукта ордера.
	/// </summary>
	public class DALCOProductPersFile
	{
		
		#region Fields

		#region Private Fields
		
        public static string persFileUrl = ConfigurationSettings.AppSettings["PersFile_URL"];

		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string m_sConnectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];

		#endregion

		#endregion
		
		#region Methods

		#region Static Methods
		
        public static string GetFileName(string fileName, string fileExtension)
        {
            string url = string.Empty;
            url = System.Web.HttpContext.Current.Request.ApplicationPath + persFileUrl + fileName + "." + fileExtension;
            url = url.Replace("//", "/");
            string path = string.Empty;
            path = System.Web.HttpContext.Current.Request.MapPath(url);

            return path;
        }

        public static void DeleteFile(int id)
        {
            DataSet fileList = GetItem(id);
            if( fileList.Tables["OProductPersFile"] != null )
            {
                foreach(DataRow row in fileList.Tables["OProductPersFile"].Rows)
                {
                    string name = row["FileName"].ToString();
                    string extension = row["FileExtension"].ToString();
                    string fileName = GetFileName(name,extension);

                    FileInfo fileInfo = new FileInfo(fileName);
					
                    if( fileInfo.Exists )
                    {
                        fileInfo.Delete();
                    }
                }
            }
        }

		public static void Delete(int id)
		{
            DeleteFile(id);

			SqlParameter opflID = new SqlParameter("@opflID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_OProductPersFile_Delete", opflID);
		}

		public static int Update(int id, int orderProductID, string fileName, string description, HttpPostedFile pf)
		{
            string fileExtension = "";
            string newFileName = fileName;
            string fileFullName;
            FileInfo fileInfo;

            if (pf != null)
            {
                DeleteFile(id);

                int cnt = -1;
                FileInfo wFile = new FileInfo(pf.FileName);
                fileExtension = wFile.Extension;

                do 
                {
                    cnt++;
                    newFileName = fileName + ((cnt==0)?"":"_"+cnt.ToString());
                    
                    fileExtension = fileExtension.StartsWith(".") ? fileExtension.Remove(0, 1) : fileExtension;

                    fileFullName = GetFileName(newFileName, fileExtension);

                    fileInfo = new FileInfo(fileFullName);
                } while(fileInfo.Exists);

                pf.SaveAs(fileFullName);
            }

			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[5];

			arParams[0] = new SqlParameter("@opflID", id);
			arParams[1] = new SqlParameter("@opfl_OrderProductID", orderProductID <= 0?
				DBNull.Value : (object)orderProductID);
			arParams[2] = new SqlParameter("@opflFileName", newFileName);
			arParams[3] = new SqlParameter("@opflFileExtension", fileExtension);
            arParams[4] = new SqlParameter("@opflDescription", description);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_OProductPersFile_Update", arParams) );

			return returnValue;
		}

		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("OProductPersFile");
			
			DataTable table = new DataTable("OProductPersFile");
			
			table.Columns.Add("ID", typeof(int) );
			table.Columns.Add("_OrderProductID", typeof(int) );
			table.Columns.Add("FileName", typeof(string) );
			table.Columns.Add("FileExtension", typeof(string) );
            table.Columns.Add("Description", typeof(string) );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["ID"] = Convert.ToInt32( row["opflID"] );
					newRow["_OrderProductID"] = row["opfl_OrderProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["opfl_OrderProductID"] );
					newRow["FileName"] = Convert.ToString( row["opflFileName"] );
					newRow["FileExtension"] = Convert.ToString( row["opflFileExtension"] );
                    newRow["Description"] = Convert.ToString( row["opflDescription"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		public static DataSet GetList(int orderProductID)
		{
			DataSet tmpDataSet = null;
			
			if (orderProductID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductPersFile_GetListByOrderProductID", new SqlParameter("@OrderProductID", orderProductID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductPersFile_GetList");
			
			return ConvertList(tmpDataSet);
		}
		
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@opflID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductPersFile_GetItem", id);
		
			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCOProductPersFile
		/// </summary>
		private DALCOProductPersFile()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
//using Microsoft.ApplicationBlocks.Data;
using System.IO;


 
	/// <summary>
	/// Класс DALCRelatedFile реализует логику доступа к данным связанного файла.
	/// </summary>
	public class DALCRelatedFile
	{
		
		#region Fields

		#region Private Fields

		public static string relatedFileUrl = ConfigurationSettings.AppSettings["RelatedFile_URL"];

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
			url = System.Web.HttpContext.Current.Request.ApplicationPath + relatedFileUrl + fileName;
			if( fileExtension != string.Empty )
				url += "." + fileExtension;
			url = url.Replace("//", "/");
			string path = string.Empty;
			path = System.Web.HttpContext.Current.Request.MapPath(url);

			return path;
		}

		/// <summary>
		///		Удаляет связанный файл на диске
		/// </summary>
		public static void DeleteFile(int id)
		{
			DataSet fileList = GetItem(id);
			if( fileList.Tables["RelatedFile"] != null )
			{
				foreach(DataRow row in fileList.Tables["RelatedFile"].Rows)
				{
					string name = ((int)row["rlfl_ProductID"]>=0?"":"temp/") + row["rlflFileName"].ToString();
					string extension = row["rlflFileExtension"].ToString();
					string fileName = GetFileName(name,extension);

					FileInfo fileInfo = new FileInfo(fileName);
					
					if( fileInfo.Exists )
					{
						fileInfo.Delete();
					}
				}
			}
		}

		/// <summary>
		///		Удаляет связанный файл
		/// </summary>
		public static void Delete(int id)
		{
			DeleteFile(id);

			SqlParameter rlflID = new SqlParameter("@rlflID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_RelatedFile_Delete", rlflID);
		}

		/// <summary>
		///		Обновляет информацию о связанном файле
		/// </summary>
		public static int Update(int id, int productID, string name, string description, HttpPostedFile pf, string fileName, string special, int order)
		{
			string fileExtension = "";
			string originalFileName = "";
            string newFileName = fileName;
            string fileFullName;
            FileInfo fileInfo;

			if (pf != null)
			{
				DeleteFile(id);

                int cnt = -1;
                
				FileInfo wFile = new FileInfo(pf.FileName);
				originalFileName = wFile.Name;
				fileExtension = wFile.Extension;
				fileExtension = fileExtension.StartsWith(".") ? fileExtension.Remove(0, 1) : fileExtension;

                do
                {
                    cnt++;
                    newFileName = fileName + ((cnt==0)?"":"_"+cnt.ToString());
                    
                    fileExtension = fileExtension.StartsWith(".") ? fileExtension.Remove(0, 1) : fileExtension;

                    fileFullName = GetFileName((productID>=0?"":"temp/") + newFileName, fileExtension);

                    fileInfo = new FileInfo(fileFullName);
                } while(fileInfo.Exists);

				pf.SaveAs(fileFullName);
			}

			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[9];

			arParams[0] = new SqlParameter("@rlflID", id);
			arParams[1] = new SqlParameter("@rlfl_ProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@rlflName", name);
			arParams[3] = new SqlParameter("@rlflDescription", description);
			arParams[4] = new SqlParameter("@rlflFileName", newFileName);
			arParams[5] = new SqlParameter("@rlflFileExtension", fileExtension);
			arParams[6] = new SqlParameter("@rlflOriginalFileName", originalFileName);
			arParams[7] = new SqlParameter("@rlflSpecial", special);
			arParams[8] = new SqlParameter("@rlflOrder", order);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_RelatedFile_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор связанных файлов
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			dataSet = new DataSet("RelatedFile");
			
			DataTable table = new DataTable("RelatedFile");
			
			table.Columns.Add("rlflID", int.MinValue.GetType() );
			table.Columns.Add("rlfl_ProductID", int.MinValue.GetType() );
			table.Columns.Add("rlflName", string.Empty.GetType() );
			table.Columns.Add("rlflDescription", string.Empty.GetType() );
			table.Columns.Add("rlflFileName", string.Empty.GetType() );
			table.Columns.Add("rlflFileExtension", string.Empty.GetType() );
			table.Columns.Add("rlflOriginalFileName", string.Empty.GetType() );
			table.Columns.Add("rlflSpecial", string.Empty.GetType() );
			table.Columns.Add("rlflOrder", int.MinValue.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["rlflID"] = Convert.ToInt32( row["rlflID"] );
					newRow["rlfl_ProductID"] = row["rlfl_ProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["rlfl_ProductID"] );
					newRow["rlflName"] = Convert.ToString( row["rlflName"] );
					newRow["rlflDescription"] = Convert.ToString( row["rlflDescription"] );
					newRow["rlflFileName"] = Convert.ToString( row["rlflFileName"] );
					newRow["rlflFileExtension"] = Convert.ToString( row["rlflFileExtension"] );
					newRow["rlflOriginalFileName"] = Convert.ToString( row["rlflOriginalFileName"] );
					newRow["rlflSpecial"] = Convert.ToString( row["rlflSpecial"] );
					newRow["rlflOrder"] = row["rlflOrder"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["rlflOrder"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		Получает набор связанных файлов
		/// </summary>
		public static DataSet GetList(int productID, string special)
		{
			DataSet tmpDataSet = null;
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_RelatedFile_GetListByProduct", new SqlParameter("@ProductID",(productID>=0?(object)productID:DBNull.Value)), new SqlParameter("@Special", special));
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		Получает набор связанных файлов
		/// </summary>
		public static DataSet GetList(int productID)
		{
			return GetList(productID, "");
		}

		/// <summary>
		///		Получает набор всех связанных файлов
		/// </summary>
		public static DataSet GetList()
		{
			DataSet tmpDataSet = null;
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_RelatedFile_GetList");
			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает один связанный файл
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@rlflID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_RelatedFile_GetItem", id);

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Копирует связанные файлы
		/// </summary>
		public static void CopyToProduct(int productID, int toProductID)
		{
			//Копируем файлы только в том случае, если разботаем с буфером
			if ((productID>=0 && toProductID<0) || (productID<0 && toProductID>=0))
			{
				DataSet fileList = GetList(productID);
				if( fileList.Tables["RelatedFile"] != null )
				{
					foreach(DataRow row in fileList.Tables["RelatedFile"].Rows)
					{
						//DeleteFile(Convert.ToInt32(row["rlflID"]));
						string name = ((int)row["rlfl_ProductID"]>=0?"":"temp/") + row["rlflFileName"].ToString();
						string extension = row["rlflFileExtension"].ToString();
						string fileName = GetFileName(name,extension);

						FileInfo fileInfo = new FileInfo(fileName);
					
						if( fileInfo.Exists )
						{
							string to_name = (toProductID>=0?"":"temp/") + row["rlflFileName"].ToString();
							string to_fileName = GetFileName(to_name,extension);

							fileInfo.CopyTo(to_fileName, true);
						}
					}
				}
				SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
				SqlParameter pToProductID = new SqlParameter("@ToProductID", (toProductID>=0?(object)toProductID:DBNull.Value));
				SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_RelatedFile_CopyToProduct", pProductID, pToProductID);
			}
		}

		/// <summary>
		///		Удаляет связанные файлы продукта
		/// </summary>
		public static void DeleteByProduct(int productID)
		{
			DataSet fileList = GetList(productID);
			if( fileList.Tables["RelatedFile"] != null )
			{
				foreach(DataRow row in fileList.Tables["RelatedFile"].Rows)
				{
					DeleteFile(Convert.ToInt32(row["rlflID"]));
				}
			}
			SqlParameter pProductID = new SqlParameter("@ProductID", (productID>=0?(object)productID:DBNull.Value));
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_RelatedFile_DeleteByProduct", pProductID);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCRelatedFile
		/// </summary>
		private DALCRelatedFile()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

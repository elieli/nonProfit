using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Drawing;


 
	/// <summary>
	/// Summary description for DALCImageGallery.
	/// </summary>
	public class DALCImageGallery
	{
		#region Fields

		/// <summary>
		///		—трока соединени€ с базой данных
		/// </summary>
		private static string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		public static string imageGalleryUrl = ConfigurationSettings.AppSettings["ImageGallery_URL"];
		//public static string imageGalleryPath = System.Web.HttpContext.Current.Server.MapPath(imageGalleryUrl);
		
		#endregion
		
		#region Static Methods

		public static DataSet GetBindingList(int id)
		{
			DataSet dataSet = null;
			DataSet tmpDataSet = null;
			
			SqlParameter itemID = new SqlParameter("@ID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_ImageGallery_GetBindingList", itemID);

			dataSet = new DataSet("ImageGallery");
			
			DataTable itemTable = new DataTable("GalleryBindingList");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("BindingType", string.Empty.GetType() );
			itemTable.Columns.Add("BindingValue", string.Empty.GetType() );

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();

					newRow["ID"] = Convert.ToInt32( row["ID"] );
					newRow["BindingType"] = row["BindingType"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["BindingType"] );
					newRow["BindingValue"] = row["BindingValue"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["BindingValue"] );
					
					itemTable.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(itemTable);

			return dataSet;
		}

		public static string GetFileName(string fileName, string fileExtension)
		{
			string url = string.Empty;
			url = System.Web.HttpContext.Current.Request.ApplicationPath + imageGalleryUrl + fileName + "." + fileExtension;
			url = url.Replace("//", "/");
			string path = string.Empty;
			path = System.Web.HttpContext.Current.Request.MapPath(url);

			return path;
		}

		public static void Bind(int galleryId, string bindingType, string bindingValue)
		{
			SqlParameter[] arParams = new SqlParameter[3];

			arParams[0] = new SqlParameter("@galleryId", galleryId);
			arParams[1] = new SqlParameter("@BindingType", bindingType);
			arParams[2] = new SqlParameter("@BindingValue", bindingValue);
		
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ImageGallery_Bind", arParams);
		}
		
		public static void DeleteBinding(int galleryId, string bindingType, string bindingValue)
		{
			SqlParameter[] arParams = new SqlParameter[3];

			arParams[0] = new SqlParameter("@galleryId", galleryId);
			arParams[1] = new SqlParameter("@BindingType", bindingType);
			arParams[2] = new SqlParameter("@BindingValue", bindingValue);
		
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ImageGallery_DeleteBinding", arParams);
		}
		
		public static int GetGalleryID(string BindingType, string BindingValue)
		{
			int galleryID = 0;

			SqlParameter[] arParams = new SqlParameter[2];

			arParams[0] = new SqlParameter("@BindingType", BindingType);
			arParams[1] = new SqlParameter("@BindingValue", BindingValue);
		
			try
			{
				galleryID = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_ImageGallery_GetGalleryIDByBinding", arParams) );
			}
			catch{}
			
			return galleryID;
		}
		
		public static void Delete(int id)
		{
			DataSet imageList = GetImageList(id, false);

			if( imageList.Tables["ImageGallery"] != null )
			{
				foreach(DataRow row in imageList.Tables["ImageGallery"].Rows)
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

			SqlParameter paramID = new SqlParameter("@ID", id);
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ImageGallery_Delete", paramID);
		}
		
		public static int Update(int id, string name, string description)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[3];

			arParams[0] = new SqlParameter("@id", id);
			arParams[1] = new SqlParameter("@name", name);
			arParams[2] = new SqlParameter("@description", description);
		
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_ImageGallery_Update", arParams) );

			return returnValue;
		}

		
		public static int ImageUpdate(int id, int galleryID, Image image, 
				string originalFileName, float width, float height, System.Drawing.Imaging.ImageFormat format)
		{
			int returnValue = 0;			
			
			string fileExtension = string.Empty;

			FileInfo imageFile = new FileInfo(originalFileName);
			fileExtension = imageFile.Extension;
			fileExtension = fileExtension.StartsWith(".") ? fileExtension.Remove(0, 1) : fileExtension;

			string fileName = Guid.NewGuid().ToString();

			string fileFullName = GetFileName(fileName, fileExtension);

			image.Save(fileFullName, format);
			

			SqlParameter[] arParams = new SqlParameter[7];

			arParams[0] = new SqlParameter("@id", id);
			arParams[1] = new SqlParameter("@ecomImageGallery_ID", galleryID);
			arParams[2] = new SqlParameter("@FileName", fileName);
			arParams[3] = new SqlParameter("@FileExtension", fileExtension);
			arParams[4] = new SqlParameter("@OriginalFileName", originalFileName);
			arParams[5] = new SqlParameter("Width",image.Width);
			arParams[6] = new SqlParameter("Height",image.Height);
		
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_ImageGallery_ImageUpdate", arParams) );
			image.Dispose();
			return returnValue;

		}

	
		public static void ImageDelete(int imageID)
		{
			DataSet item = GetImageItem(imageID, false);

			string fileName = string.Empty;
			if( item.Tables.Count > 0 && item.Tables["ImageGallery"].Rows.Count > 0 )
			{
				string name = item.Tables["ImageGallery"].Rows[0]["FileName"].ToString();
				string extension = item.Tables["ImageGallery"].Rows[0]["FileExtension"].ToString();
				fileName = GetFileName(name, extension);

				FileInfo imageFile = new FileInfo(fileName);
				if( imageFile.Exists )
				{
					GC.Collect();
					imageFile.Delete();
				}
			}
			
			SqlParameter paramID = new SqlParameter("@ID", imageID);
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_ImageGallery_ImageDelete", paramID);

		}
		
		
		public static DataSet GetItem(int id)
		{
			DataSet dataSet = null;
			DataSet tmpDataSet = null;
			
			SqlParameter itemID = new SqlParameter("@ID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_ImageGallery_GetItem", itemID);

			dataSet = new DataSet("ImageGallery");
			
			DataTable itemTable = new DataTable("ImageGallery");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("name", string.Empty.GetType() );
			itemTable.Columns.Add("Description", string.Empty.GetType() );

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();

					newRow["ID"] = Convert.ToInt32( row["ID"] );
					newRow["Name"] = row["name"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["name"] );
					newRow["Description"] = row["description"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["description"] );
				
					itemTable.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(itemTable);

			return dataSet;
		}
		
		
		
		public static DataSet GetList()
		{
			DataSet dataSet = null;
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_ImageGallery_GetList");

			dataSet = new DataSet("ImageGallerys");
			
			DataTable itemTable = new DataTable("ImageGallerys");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("name", string.Empty.GetType() );
			itemTable.Columns.Add("descrition", string.Empty.GetType() );

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();

					newRow["ID"] = Convert.ToInt32( row["ID"] );
					newRow["Name"] = row["name"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["name"] );
					newRow["Description"] = row["descrition"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["descrition"] );
					
					itemTable.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(itemTable);

			return dataSet;
		}


		public static DataSet GetImageList(int id, bool OnlyExists)
		{
			return Getimages(id, OnlyExists, true);
		}
		public static DataSet GetImageItem(int id, bool OnlyExists)
		{
			return Getimages(id, OnlyExists, false);
		}
		private static DataSet Getimages(int id, bool OnlyExists, bool isList)
		{
			DataSet dataSet = null;
			DataSet tmpDataSet = null;
			
			string storedProcedure = string.Empty;
			
			if( isList )
			{
				storedProcedure = "ecom_ImageGallery_ImageGetList";
			}
			else
			{
				storedProcedure = "ecom_ImageGallery_ImageGetItem";
			}

			SqlParameter itemID = new SqlParameter("@ID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, storedProcedure, itemID);

			dataSet = new DataSet("ImageGallery");
			
			DataTable itemTable = new DataTable("ImageGallery");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("name", string.Empty.GetType() );
			itemTable.Columns.Add("Description", string.Empty.GetType() );
			itemTable.Columns.Add("FileName", string.Empty.GetType() );
			itemTable.Columns.Add("FileExtension", string.Empty.GetType() );
			itemTable.Columns.Add("OriginalFileName", string.Empty.GetType() );
			itemTable.Columns.Add("GalleryID", int.MinValue.GetType() );
			itemTable.Columns.Add("ImageUrl", string.Empty.GetType() );
			itemTable.Columns.Add("Width",int.MinValue.GetType());
			itemTable.Columns.Add("Height",int.MinValue.GetType());

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();

					newRow["ID"] = Convert.ToInt32( row["ID"] );
					newRow["Name"] = row["name"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["name"] );
					newRow["Description"] = row["description"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["description"] );
					newRow["FileName"] = row["FileName"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["FileName"] );
					newRow["FileExtension"] = row["FileExtension"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["FileExtension"] );
					newRow["OriginalFileName"] = row["OriginalFileName"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["OriginalFileName"] );
					newRow["GalleryID"] = row["ecomImageGallery_ID"] == DBNull.Value ? 0 :
						Convert.ToInt32( row["ecomImageGallery_ID"] );
					//newRow["Width"] = row["Width"] == DBNull.Value ? 0 : Convert.ToInt32(row["Width"]);
					//newRow["Height"] = row["Height"] == DBNull.Value ? 0 : Convert.ToInt32(row["Height"]);

					string name = newRow["FileName"].ToString();
					string extension = newRow["FileExtension"].ToString();

					string url = string.Empty;
					url = System.Web.HttpContext.Current.Request.ApplicationPath + imageGalleryUrl + name + "." + extension;
					url = url.Replace("//", "/");

					string fileName = GetFileName(name,extension);

					FileInfo file = new FileInfo(fileName);

					//===≈сли в таблице нет размеров тогда вычисл€ем их
					//===Width
					if (row["Width"] == DBNull.Value)
					{						
						if (file.Exists == true)
						{
							Image img = Image.FromFile(file.FullName);
							newRow["Width"] = img.Width;
						    img.Dispose();
						}
						else
						{
							newRow["Width"] = 0;
						}
					}
					else
					{
						newRow["Width"] = Convert.ToInt32(row["Width"]);
					}

					//===Height
					if (row["Height"] == DBNull.Value)
					{						
						if (file.Exists == true)
						{
							Image img = Image.FromFile(file.FullName);
							newRow["Height"] = img.Height;
							img.Dispose();
						}
						else
						{
							newRow["Height"] = 0;
						}
					}
					else
					{
						newRow["Height"] = Convert.ToInt32(row["Height"]);
					}

                   //==============

					newRow["ImageUrl"] = url; //imageGalleryUrl + name + "." + extension;

					if( OnlyExists )
					{
						FileInfo imageFile = new FileInfo(fileName);
						if( imageFile.Exists )
						{							
							itemTable.Rows.Add(newRow);
						}
					}
					else
					{
						itemTable.Rows.Add(newRow);
					}
				}
			}

			dataSet.Tables.Add(itemTable);

			return dataSet;
		}



		#endregion
		
		private DALCImageGallery()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
 

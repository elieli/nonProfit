using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Summary description for DALCUser.
	/// </summary>
	public class DALCUser
	{
		
		#region Fields

		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		
		#endregion

		#region Static Methods

		public static void Delete(int ID)
		{
			SqlParameter paramID = new SqlParameter("@ID", ID);
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_User_Delete", paramID);
		}

		public static DataSet GetList()
		{
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_User_GetList"); 

			return ConvertList(tmpDataSet);
		}

		public static DataSet GetListByProduct(int productID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter spProductID = new SqlParameter("@ProductID", productID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_User_GetListByProduct", spProductID); 

			return ConvertList(tmpDataSet);
		}

		public static int Update(int ID, int CustomerID, string UID, bool Enabled, string Login, string Password,
			string EMail, DateTime Created)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[8];
			arParams[0] = new SqlParameter("@usrID", ID);
			arParams[1] = new SqlParameter("@usr_CustomerID", CustomerID <= 0 ? 
				DBNull.Value : (object)CustomerID);
			arParams[2] = new SqlParameter("@usrUID", UID);
			arParams[3] = new SqlParameter("@usrEnabled", Enabled);
			arParams[4] = new SqlParameter("@usrLogin", Login);
			arParams[5] = new SqlParameter("@usrPassword", Password);
			arParams[6] = new SqlParameter("@usrEMail", EMail);
			if(Created == DateTime.MinValue)
			{
				arParams[7] = new SqlParameter("@usrCreated", DBNull.Value);
			}
			else
			{
				arParams[7] = new SqlParameter("@usrCreated", Created);
			}

			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_User_Update", arParams) );

			return returnValue;
		}

		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet itemDataSet = null;
			itemDataSet = new DataSet("User");
			
			DataTable itemTable = new DataTable("User");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("CustomerID", int.MinValue.GetType() );
			itemTable.Columns.Add("UID", string.Empty.GetType() );
			itemTable.Columns.Add("Enabled", false.GetType() );
			itemTable.Columns.Add("Login", string.Empty.GetType() );
			itemTable.Columns.Add("Password", string.Empty.GetType() );
			itemTable.Columns.Add("EMail", string.Empty.GetType() );
			itemTable.Columns.Add("Created", DateTime.MinValue.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();
					
					newRow["ID"] = Convert.ToInt32( row["usrID"] );
					newRow["CustomerID"] = row["usr_CustomerID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["usr_CustomerID"] );
					newRow["UID"] = row["usrUID"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["usrUID"] );
					newRow["Enabled"] = row["usrEnabled"] == DBNull.Value ? false :
						Convert.ToBoolean( row["usrEnabled"] );
					newRow["Login"] = row["usrLogin"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["usrLogin"] );
					newRow["Password"] = row["usrPassword"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["usrPassword"] );
					newRow["EMail"] = row["usrEMail"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["usrEMail"] );
					newRow["Created"] = row["usrCreated"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["usrCreated"] );
					itemTable.Rows.Add(newRow);
				}
			}

			itemDataSet.Tables.Add(itemTable);

			return itemDataSet;
		}

		public static DataSet GetItem(int ID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter itemID = new SqlParameter("@ID", ID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_User_GetItem", itemID); 

			return ConvertList(tmpDataSet);
		}

		public static DataSet GetItemByLogin(string Login)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter itemLogin = new SqlParameter("@Login", Login);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_User_GetItemByLogin", itemLogin); 

			return ConvertList(tmpDataSet);
		}

		public static DataSet GetItemByUID(string UID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter itemUID = new SqlParameter("@UID", UID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_User_GetItemByUID", itemUID); 

			return ConvertList(tmpDataSet);
		}

		public static DataSet GetItemByEMail(string EMail)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter itemEMail = new SqlParameter("@EMail", EMail);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_User_GetItemByEMail", itemEMail); 

			return ConvertList(tmpDataSet);
		}

		#endregion		
		
		private DALCUser()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
 

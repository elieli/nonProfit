using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Summary description for DALCCustomer.
	/// </summary>
	public class DALCCustomer
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
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_Customer_Delete", paramID);
		}

		public static DataSet GetList()
		{
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_Customer_GetList"); 

			return ConvertList(tmpDataSet);
		}

		public static int Update(int ID, DateTime Created, string SessionID, int BillingAddressID, 
			int ShippingAddressID, int CreditCardInfoID, bool SaveInfo)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[7];
			arParams[0] = new SqlParameter("@cstmID", ID);
			arParams[1] = new SqlParameter("@cstm_CreditCardInfoID", CreditCardInfoID <= 0 ? 
				DBNull.Value : (object)CreditCardInfoID);
			arParams[2] = new SqlParameter("@cstm_BillingAddress", BillingAddressID <= 0 ? 
				DBNull.Value : (object)BillingAddressID);
			arParams[3] = new SqlParameter("@cstm_ShippingAddressID", ShippingAddressID <= 0 ? 
				DBNull.Value : (object)ShippingAddressID);
			arParams[4] = new SqlParameter("@cstmSessionID", SessionID);
			if(Created == DateTime.MinValue)
			{
				arParams[5] = new SqlParameter("@cstmCreated", DBNull.Value);
			}
			else
			{
				arParams[5] = new SqlParameter("@cstmCreated", Created);
			}
			arParams[6] = new SqlParameter("@cstmSaveInfo", SaveInfo);

			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_Customer_Update", arParams) );

			return returnValue;
		}

		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet itemDataSet = null;
			itemDataSet = new DataSet("Customer");
			
			DataTable itemTable = new DataTable("Customer");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("Created", DateTime.MinValue.GetType() );
			itemTable.Columns.Add("SessionID", string.Empty.GetType() );
			itemTable.Columns.Add("BillingAddressID", int.MinValue.GetType() );
			itemTable.Columns.Add("ShippingAddressID", int.MinValue.GetType() );
			itemTable.Columns.Add("CreditCardInfoID", int.MinValue.GetType() );
			itemTable.Columns.Add("SaveInfo", false.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();
					
					newRow["ID"] = Convert.ToInt32( row["cstmID"] );
					newRow["SessionID"] = row["cstmSessionID"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["cstmSessionID"] );
					newRow["Created"] = row["cstmCreated"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["cstmCreated"] );
					newRow["BillingAddressID"] = row["cstm_BillingAddressID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["cstm_BillingAddressID"] );
					newRow["ShippingAddressID"] = row["cstm_ShippingAddressID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["cstm_ShippingAddressID"] );
					newRow["CreditCardInfoID"] = row["cstm_CreditCardInfoID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["cstm_CreditCardInfoID"] );
					newRow["SaveInfo"] = row["cstmSaveInfo"] == DBNull.Value ? false :
						Convert.ToBoolean( row["cstmSaveInfo"] );

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
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_Customer_GetItem", itemID); 

			return ConvertList(tmpDataSet);
		}

		public static DataSet GetItemBySessionID(string SessionID)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter itemSessionID = new SqlParameter("@SessionID", SessionID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_Customer_GetItemBySessionID", itemSessionID); 

			return ConvertList(tmpDataSet);
		}

		#endregion		
		
		private DALCCustomer()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
 

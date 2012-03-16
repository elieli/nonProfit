using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Summary description for DALCCreditCard.
	/// </summary>
	public class DALCCreditCard
	{
		#region Fields

		#region Private Fields
		
		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		
		#endregion

		#endregion

		#region Static Methods
		
		public static void Delete(int ID)
		{
			SqlParameter paramID = new SqlParameter("@ID", ID);
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_CreditCard_Delete", paramID);
		}
		
		public static int Update(int ID, string CardHolder, string CardNumber, string CardType, 
								DateTime StartDate, DateTime ExpiryDate, string IssueNumber, string CVV)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[8];

			arParams[0] = new SqlParameter("@ccID", ID);
			arParams[1] = new SqlParameter("@ccCardHolder", CardHolder);
			arParams[2] = new SqlParameter("@ccCardType", CardType);
			arParams[3] = new SqlParameter("@ccCardNumber", CardNumber);
			arParams[4] = new SqlParameter("@ccIssueNumber", IssueNumber);
			arParams[5] = new SqlParameter("@ccCVV", CVV);
			
			if( StartDate == DateTime.MinValue )
			{
				arParams[6] = new SqlParameter("@ccStartDate", DBNull.Value);
			}
			else
			{
				arParams[6] = new SqlParameter("@ccStartDate", StartDate);
			}
			
			if( ExpiryDate == DateTime.MinValue )
			{
				arParams[7] = new SqlParameter("@ccExpiryDate", DBNull.Value);
			}
			else
			{
				arParams[7] = new SqlParameter("@ccExpiryDate", ExpiryDate);
			}
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_CreditCard_Update", arParams) );

			return returnValue;
		}

		
		
		public static DataSet GetList()
		{
			DataSet itemDataSet = null;
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_CreditCard_GetList");

			itemDataSet = new DataSet("CreditCard");
			
			DataTable itemTable = new DataTable("CreditCard");

			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("CardType", string.Empty.GetType() );
			itemTable.Columns.Add("CardNumber", string.Empty.GetType() );
			itemTable.Columns.Add("StartDate", DateTime.MinValue.GetType() );
			itemTable.Columns.Add("ExpiryDate", DateTime.MinValue.GetType() );
			itemTable.Columns.Add("IssueNumber", string.Empty.GetType() );
			itemTable.Columns.Add("CVV", string.Empty.GetType() );
			itemTable.Columns.Add("CardHolder", string.Empty.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();
					
					newRow["ID"] = Convert.ToInt32( row["ccID"] );
					newRow["CardType"] = row["ccCardType"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCardType"] );
					newRow["CardNumber"] = row["ccCardNumber"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCardNumber"] );
					newRow["StartDate"] = row["ccStartDate"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["ccStartDate"] );
					newRow["ExpiryDate"] = row["ccExpiryDate"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["ccExpiryDate"] );
					newRow["IssueNumber"] = row["ccIssueNumber"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccIssueNumber"] );
					newRow["CVV"] = row["ccCVV"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCVV"] );
					newRow["CardHolder"] = row["ccCardHolder"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCardHolder"] );

					itemTable.Rows.Add(newRow);
				}
			}

			itemDataSet.Tables.Add(itemTable);

			return itemDataSet;
		}
		
		
		public static DataSet GetItem(int ID)
		{
			DataSet itemDataSet = null;
			DataSet tmpDataSet = null;
			
			SqlParameter itemID = new SqlParameter("@ID", ID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_CreditCard_GetItem", itemID);

			itemDataSet = new DataSet("CreditCard");
			
			DataTable itemTable = new DataTable("CreditCard");

			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("CardHolder", string.Empty.GetType() );
			itemTable.Columns.Add("CardType", string.Empty.GetType() );
			itemTable.Columns.Add("CardNumber", string.Empty.GetType() );
			itemTable.Columns.Add("StartDate", DateTime.MinValue.GetType() );
			itemTable.Columns.Add("ExpiryDate", DateTime.MinValue.GetType() );
			itemTable.Columns.Add("IssueNumber", string.Empty.GetType() );
			itemTable.Columns.Add("CVV", string.Empty.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();
					
					newRow["ID"] = Convert.ToInt32( row["ccID"] );
					newRow["CardHolder"] = row["ccCardHolder"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCardHolder"] );
					newRow["CardType"] = row["ccCardType"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCardType"] );
					newRow["CardNumber"] = row["ccCardNumber"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCardNumber"] );
					newRow["StartDate"] = row["ccStartDate"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["ccStartDate"] );
					newRow["ExpiryDate"] = row["ccExpiryDate"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["ccExpiryDate"] );
					newRow["IssueNumber"] = row["ccIssueNumber"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccIssueNumber"] );
					newRow["CVV"] = row["ccCVV"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["ccCVV"] );

					itemTable.Rows.Add(newRow);
				}
			}

			itemDataSet.Tables.Add(itemTable);

			return itemDataSet;
		}


		#endregion
		
		#region Constructors
		private DALCCreditCard()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
	}
 

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;

 
	/// <summary>
	/// Summary description for DALCAddress.
	/// </summary>
	public class DALCAddress
	{
		
		#region Fields

		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		
		#endregion

		#region Static Methods
		
		public static DataSet GetList()
        {            
			DataSet dataSet = null;
			DataSet tmpDataSet = null;
			
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_Address_GetList");

			dataSet = new DataSet("Address");
			
			DataTable itemTable = new DataTable("Address");
			
			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("FirstName", string.Empty.GetType() );
			itemTable.Columns.Add("LastName", string.Empty.GetType() );
			itemTable.Columns.Add("Company", string.Empty.GetType() );
			itemTable.Columns.Add("Address1", string.Empty.GetType() );
			itemTable.Columns.Add("Address2", string.Empty.GetType() );
			itemTable.Columns.Add("City", string.Empty.GetType() );
			itemTable.Columns.Add("State", string.Empty.GetType() );
			itemTable.Columns.Add("PostCode", string.Empty.GetType() );
			itemTable.Columns.Add("Country", string.Empty.GetType() );
			itemTable.Columns.Add("Phone", string.Empty.GetType() );
			itemTable.Columns.Add("Fax", string.Empty.GetType() );
			itemTable.Columns.Add("EMail", string.Empty.GetType() );
			itemTable.Columns.Add("Field1", string.Empty.GetType() );
			itemTable.Columns.Add("Field2", string.Empty.GetType() );
			itemTable.Columns.Add("Field3", string.Empty.GetType() );
			itemTable.Columns.Add("Field4", string.Empty.GetType() );
			itemTable.Columns.Add("Field5", string.Empty.GetType() );
			itemTable.Columns.Add("Field6", string.Empty.GetType() );
			itemTable.Columns.Add("Field7", string.Empty.GetType() );

			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();

					newRow["ID"] = Convert.ToInt32( row["adrID"] );
					newRow["FirstName"] = row["adrFirstName"] == null ? string.Empty :
						Convert.ToString( row["adrFirstName"] );
					newRow["LastName"] = row["adrLastName"] == null ? string.Empty :
						Convert.ToString( row["adrLastName"] );
					newRow["Company"] = row["adrCompany"] == null ? string.Empty :
						Convert.ToString( row["adrCompany"] );
					newRow["Address1"] = row["adrAddress1"] == null ? string.Empty :
						Convert.ToString( row["adrAddress1"] );
					newRow["Address2"] = row["adrAddress2"] == null ? string.Empty :
						Convert.ToString( row["adrAddress2"] );
					newRow["City"] = row["adrCity"] == null ? string.Empty :
						Convert.ToString( row["adrCity"] );
					newRow["State"] = row["adrState"] == null ? string.Empty :
						Convert.ToString( row["adrState"] );
					newRow["Country"] = row["adrCountry"] == null ? string.Empty :
						Convert.ToString( row["adrCountry"] );
					newRow["PostCode"] = row["adrPostCode"] == null ? string.Empty :
						Convert.ToString( row["adrPostCode"] );
					newRow["Phone"] = row["adrPhone"] == null ? string.Empty :
						Convert.ToString( row["adrPhone"] );
					newRow["Fax"] = row["adrFax"] == null ? string.Empty :
						Convert.ToString( row["adrFax"] );
					newRow["EMail"] = row["adrEMail"] == null ? string.Empty :
						Convert.ToString( row["adrEMail"] );
					newRow["Field1"] = row["adrField1"] == null ? string.Empty :
						Convert.ToString( row["adrField1"] );
					newRow["Field2"] = row["adrField2"] == null ? string.Empty :
						Convert.ToString( row["adrField2"] );
					newRow["Field3"] = row["adrField3"] == null ? string.Empty :
						Convert.ToString( row["adrField3"] );
					newRow["Field4"] = row["adrField4"] == null ? string.Empty :
						Convert.ToString( row["adrField4"] );
					newRow["Field5"] = row["adrField5"] == null ? string.Empty :
						Convert.ToString( row["adrField5"] );
					newRow["Field6"] = row["adrField6"] == null ? string.Empty :
						Convert.ToString( row["adrField6"] );
					newRow["Field7"] = row["adrField7"] == null ? string.Empty :
						Convert.ToString( row["adrField7"] );
					
					itemTable.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(itemTable);

			return dataSet;
		}
		
		
		public static void Delete(int ID)
		{
			SqlParameter paramID = new SqlParameter("@ID", ID);
			SqlHelper.ExecuteNonQuery(connectionString, "ecom_Address_Delete", paramID);
		}

		public static int Update(int ID, string FirstName, string LastName, string Company, 
			string Address1, string Address2, string City, string State, string PostCode, string Country,
			string Phone, string Fax, string EMail, string Field1, string Field2, string Field3, string Field4, string Field5, string Field6, string Field7)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[20];

			arParams[0] = new SqlParameter("@adrID", ID);
			arParams[1] = new SqlParameter("@adrFirstName", FirstName);
			arParams[2] = new SqlParameter("@adrLastName", LastName);
			arParams[3] = new SqlParameter("@adrCompany", Company);
			arParams[4] = new SqlParameter("@adrAddress1", Address1);
			arParams[5] = new SqlParameter("@adrAddress2", Address2);
			arParams[6] = new SqlParameter("@adrCity", City);
			arParams[7] = new SqlParameter("@adrState", State);
			arParams[8] = new SqlParameter("@adrPostCode", PostCode);
			arParams[9] = new SqlParameter("@adrCountry", Country);
			arParams[10] = new SqlParameter("@adrPhone", Phone);
			arParams[11] = new SqlParameter("@adrFax", Fax);
			arParams[12] = new SqlParameter("@adrEMail", EMail);
			arParams[13] = new SqlParameter("@adrField1", Field1);
			arParams[14] = new SqlParameter("@adrField2", Field2);
			arParams[15] = new SqlParameter("@adrField3", Field3);
			arParams[16] = new SqlParameter("@adrField4", Field4);
			arParams[17] = new SqlParameter("@adrField5", Field5);
			arParams[18] = new SqlParameter("@adrField6", Field6);
			arParams[19] = new SqlParameter("@adrField7", Field7);
		
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(connectionString, "ecom_Address_Update", arParams) );

			return returnValue;
		}

		public static DataSet GetItem(int ID)
		{
			DataSet itemDataSet = null;
			DataSet tmpDataSet = null;
			
			SqlParameter itemID = new SqlParameter("@ID", ID);
			tmpDataSet = SqlHelper.ExecuteDataset(connectionString, "ecom_Address_GetItem", itemID);

			itemDataSet = new DataSet("Address");
			
			DataTable itemTable = new DataTable("Address");

			itemTable.Columns.Add("ID", int.MinValue.GetType() );
			itemTable.Columns.Add("FirstName", string.Empty.GetType() );
			itemTable.Columns.Add("LastName", string.Empty.GetType() );
			itemTable.Columns.Add("Company", string.Empty.GetType() );
			itemTable.Columns.Add("Address1", string.Empty.GetType() );
			itemTable.Columns.Add("Address2", string.Empty.GetType() );
			itemTable.Columns.Add("City", string.Empty.GetType() );
			itemTable.Columns.Add("State", string.Empty.GetType() );
			itemTable.Columns.Add("PostCode", string.Empty.GetType() );
			itemTable.Columns.Add("Country", string.Empty.GetType() );
			itemTable.Columns.Add("Phone", string.Empty.GetType() );
			itemTable.Columns.Add("Fax", string.Empty.GetType() );
			itemTable.Columns.Add("EMail", string.Empty.GetType() );
			itemTable.Columns.Add("Field1", string.Empty.GetType() );
			itemTable.Columns.Add("Field2", string.Empty.GetType() );
			itemTable.Columns.Add("Field3", string.Empty.GetType() );
			itemTable.Columns.Add("Field4", string.Empty.GetType() );
			itemTable.Columns.Add("Field5", string.Empty.GetType() );
			itemTable.Columns.Add("Field6", string.Empty.GetType() );
			itemTable.Columns.Add("Field7", string.Empty.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = itemTable.NewRow();
					
					newRow["ID"] = Convert.ToInt32( row["adrID"] );
					newRow["FirstName"] = row["adrFirstName"] == null ? string.Empty :
						Convert.ToString( row["adrFirstName"] );
					newRow["LastName"] = row["adrLastName"] == null ? string.Empty :
						Convert.ToString( row["adrLastName"] );
					newRow["Company"] = row["adrCompany"] == null ? string.Empty :
						Convert.ToString( row["adrCompany"] );
					newRow["Address1"] = row["adrAddress1"] == null ? string.Empty :
						Convert.ToString( row["adrAddress1"] );
					newRow["Address2"] = row["adrAddress2"] == null ? string.Empty :
						Convert.ToString( row["adrAddress2"] );
					newRow["City"] = row["adrCity"] == null ? string.Empty :
						Convert.ToString( row["adrCity"] );
					newRow["State"] = row["adrState"] == null ? string.Empty :
						Convert.ToString( row["adrState"] );
					newRow["Country"] = row["adrCountry"] == null ? string.Empty :
						Convert.ToString( row["adrCountry"] );
					newRow["PostCode"] = row["adrPostCode"] == null ? string.Empty :
						Convert.ToString( row["adrPostCode"] );
					newRow["Phone"] = row["adrPhone"] == null ? string.Empty :
						Convert.ToString( row["adrPhone"] );
					newRow["Fax"] = row["adrFax"] == null ? string.Empty :
						Convert.ToString( row["adrFax"] );
					newRow["EMail"] = row["adrEMail"] == null ? string.Empty :
						Convert.ToString( row["adrEMail"] );
					newRow["Field1"] = row["adrField1"] == null ? string.Empty :
						Convert.ToString( row["adrField1"] );
					newRow["Field2"] = row["adrField2"] == null ? string.Empty :
						Convert.ToString( row["adrField2"] );
					newRow["Field3"] = row["adrField3"] == null ? string.Empty :
						Convert.ToString( row["adrField3"] );
					newRow["Field4"] = row["adrField4"] == null ? string.Empty :
						Convert.ToString( row["adrField4"] );
					newRow["Field5"] = row["adrField5"] == null ? string.Empty :
						Convert.ToString( row["adrField5"] );
					newRow["Field6"] = row["adrField6"] == null ? string.Empty :
						Convert.ToString( row["adrField6"] );
					newRow["Field7"] = row["adrField7"] == null ? string.Empty :
						Convert.ToString( row["adrField7"] );

					itemTable.Rows.Add(newRow);
				}
			}

			itemDataSet.Tables.Add(itemTable);

			return itemDataSet;
		}


		
		#endregion

		private DALCAddress()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
 

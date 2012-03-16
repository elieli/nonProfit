using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// ����� DALCOProductAttribute ��������� ������ ������� � ������ �������� �������� ������.
	/// </summary>
	public class DALCOProductAttribute
	{
		
		#region Fields

		#region Private Fields
		
		/// <summary>
		///		������ ���������� � ����� ������
		/// </summary>
		private static string m_sConnectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];

		#endregion

		#endregion
		
		#region Methods

		#region Static Methods
		
		/// <summary>
		///		������� ������� �������� ������
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter opatID = new SqlParameter("@opatID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_OProductAttribute_Delete", opatID);
		}

		/// <summary>
		///		��������� ���������� �� �������� �������� ������
		/// </summary>
		public static int Update(int id, int productID, string name, string avalue)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[4];

			arParams[0] = new SqlParameter("@opatID", id);
			arParams[1] = new SqlParameter("@opat_OrderProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@opatName", name);
			arParams[3] = new SqlParameter("@opatValue", avalue);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_OProductAttribute_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		��������������� ����� ��������� �������� ������
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("OProductAttribute");
			
			DataTable table = new DataTable("OProductAttribute");
			
			int tmpTypeInt = 0;
			string tmpTypeString = string.Empty;

			table.Columns.Add("opatID", tmpTypeInt.GetType() );
			table.Columns.Add("opat_OrderProductID", tmpTypeInt.GetType() );
			table.Columns.Add("opatName", tmpTypeString.GetType() );
			table.Columns.Add("opatValue", tmpTypeString.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["opatID"] = Convert.ToInt32( row["opatID"] );
					newRow["opat_OrderProductID"] = row["opat_OrderProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["opat_OrderProductID"] );
					newRow["opatName"] = Convert.ToString( row["opatName"] );
					newRow["opatValue"] = Convert.ToString( row["opatValue"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		�������� ����� ��������� ���������� �������� ������
		/// </summary>
		public static DataSet GetList(int productID)
		{
			DataSet tmpDataSet = null;
			
			if (productID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductAttribute_GetListByOrderProductID", new SqlParameter("@OrderProductID", productID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductAttribute_GetList");
			
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		�������� ����� ���� ��������� ��������� �������
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		�������� ���� ������� �������� ������
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@opatID", id);
            tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_OProductAttribute_GetItem", ID);
		
			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		����������� ���������� ������ DALCOProductAttribute
		/// </summary>
		private DALCOProductAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

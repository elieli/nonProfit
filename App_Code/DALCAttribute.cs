using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// ����� DALCAttribute ��������� ������ ������� � ������ ��������.
	/// </summary>
	public class DALCAttribute
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
		///		������� �������
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter attrID = new SqlParameter("@attrID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Attribute_Delete", attrID);
		}

		
		public static string GetValue(int productID, string attributeName)
		{
			string returnValue = string.Empty;
			SqlParameter[] arParams = new SqlParameter[2];

			arParams[0] = new SqlParameter("@productID", productID);
			arParams[1] = new SqlParameter("@attributeName", attributeName);
			
			object tmp = SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Attribute_GetValueByProductIDandName", arParams);

			returnValue = tmp != null && tmp != DBNull.Value ? Convert.ToString(tmp) : string.Empty;

			return returnValue;
		}
		
		/// <summary>
		///		��������� ���������� �� ��������
		/// </summary>
		public static int Update(int id, int productID, int attributeValueID, string name, string avalue)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[5];

			arParams[0] = new SqlParameter("@attrID", id);
			arParams[1] = new SqlParameter("@attr_ProductID", productID <= 0?
				DBNull.Value : (object)productID);
			arParams[2] = new SqlParameter("@attr_AttributeValueID", attributeValueID <= 0?
				DBNull.Value : (object)attributeValueID);
			arParams[3] = new SqlParameter("@attrName", name);
			arParams[4] = new SqlParameter("@attrValue", avalue);
			
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Attribute_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		��������������� ����� ��������� ��������
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet dataSet = null;
			
			dataSet = new DataSet("Attribute");
			
			DataTable table = new DataTable("Attribute");
			
			int tmpTypeInt = 0;
			string tmpTypeString = string.Empty;

			table.Columns.Add("attrID", tmpTypeInt.GetType() );
			table.Columns.Add("attr_ProductID", tmpTypeInt.GetType() );
			table.Columns.Add("attr_AttributeValueID", tmpTypeInt.GetType() );
			table.Columns.Add("attrName", tmpTypeString.GetType() );
			table.Columns.Add("attrValue", tmpTypeString.GetType() );
			
			if( tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = table.NewRow();
					newRow["attrID"] = Convert.ToInt32( row["attrID"] );
					newRow["attr_ProductID"] = row["attr_ProductID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["attr_ProductID"] );
					newRow["attr_AttributeValueID"] = row["attr_AttributeValueID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["attr_AttributeValueID"] );
					newRow["attrName"] = Convert.ToString( row["attrName"] );
					newRow["attrValue"] = Convert.ToString( row["attrValue"] );
					table.Rows.Add(newRow);
				}
			}

			dataSet.Tables.Add(table);
			
			return dataSet;
		}

		/// <summary>
		///		�������� ����� ��������� ���������� ��������
		/// </summary>
		public static DataSet GetList(int productID)
		{
			DataSet tmpDataSet = null;
			
			if (productID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Attribute_GetListByProductID", new SqlParameter("@ProductID", productID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Attribute_GetList");
			
			return ConvertList(tmpDataSet);
		}
		
		/// <summary>
		///		�������� ����� ���� ���������
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		�������� ���� �������
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ID = new SqlParameter("@attrID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Attribute_GetItem", id);

			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		����������� ���������� ������ DALCAttribute
		/// </summary>
		private DALCAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

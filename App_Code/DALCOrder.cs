using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.ApplicationBlocks.Data;


 
	/// <summary>
	/// Класс DALCOrder реализует логику доступа к ордеру.
	/// </summary>
	public class DALCOrder
	{
		
		#region Fields

		#region Private Fields
		
		/// <summary>
		///		Строка соединения с базой данных
		/// </summary>
		private static string m_sConnectionString = ConfigurationSettings.AppSettings["SqlConnectionString"];
		
		#endregion

		#endregion
		
		#region Methods

		#region Static Methods
		
		/// <summary>
		///		Удаляет ордер
		/// </summary>
		public static void Delete(int id)
		{
			SqlParameter ordrID = new SqlParameter("@ordrID", id);
			SqlHelper.ExecuteNonQuery(m_sConnectionString, "ecom_Order_Delete", ordrID);
		}

		/// <summary>
		///		Создает ордер
		/// </summary>
		public static int Create(int customerID, decimal ccSurcharge, decimal shippingCharges)
		{
			int returnValue = 0;

			SqlParameter[] arParams = new SqlParameter[3];

			arParams[0] = new SqlParameter("@CustomerID", customerID);
            arParams[1] = new SqlParameter("@CCSurcharge", ccSurcharge);
            arParams[2] = new SqlParameter("@ShippingCharges", shippingCharges);

			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Order_Create", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Обновляет информацию об ордере
		/// </summary>
		public static int Update(int id, int customerID, int creditCardInfoID, int billingAddressID, int shippingAddressID, decimal ccSurcharge, decimal shippingCharges, string trackingNumber, int status, DateTime created, string nonUpsTracking)
		{
			int returnValue = 0;
			SqlParameter[] arParams = new SqlParameter[11];

			arParams[0] = new SqlParameter("@ordrID", id);
			arParams[1] = new SqlParameter("@ordr_CustomerID", customerID <= 0?
				DBNull.Value : (object)customerID);
			arParams[2] = new SqlParameter("@ordr_CreditCardInfoID", creditCardInfoID <= 0?
				DBNull.Value : (object)creditCardInfoID);
			arParams[3] = new SqlParameter("@ordr_BillingAddress", billingAddressID <= 0?
				DBNull.Value : (object)billingAddressID);
			arParams[4] = new SqlParameter("@ordr_ShippingAddressID", shippingAddressID <= 0?
				DBNull.Value : (object)shippingAddressID);
            arParams[5] = new SqlParameter("@ordrCCSurcharge", ccSurcharge);
            arParams[6] = new SqlParameter("@ordrShippingCharges", shippingCharges);
            arParams[7] = new SqlParameter("@ordrTrackingNumber", trackingNumber);
			arParams[8] = new SqlParameter("@ordrStatus", status);
			arParams[9] = new SqlParameter("@ordrTrackingNumberNonUps", nonUpsTracking);

			if( created == DateTime.MinValue )
			{
				arParams[10] = new SqlParameter("@ordrCreated", DBNull.Value);
			}
			else
			{
				arParams[10] = new SqlParameter("@ordrCreated", created);
			}
		
			returnValue = Convert.ToInt32( SqlHelper.ExecuteScalar(m_sConnectionString, "ecom_Order_Update", arParams) );

			return returnValue;
		}

		/// <summary>
		///		Преобразовывает набор ордеров
		/// </summary>
		private static DataSet ConvertList(DataSet tmpDataSet)
		{
			DataSet orderList = null;

			orderList = new DataSet("Order");
			
			DataTable tableOrder = new DataTable("Order");
			
			tableOrder.Columns.Add("ordrID", int.MinValue.GetType() );
			tableOrder.Columns.Add("ordrUID", string.Empty.GetType() );
			tableOrder.Columns.Add("ordr_CustomerID", int.MinValue.GetType() );
			tableOrder.Columns.Add("ordr_CreditCardInfoID", int.MinValue.GetType() );
			tableOrder.Columns.Add("ordr_BillingAddressID", int.MinValue.GetType() );
			tableOrder.Columns.Add("ordr_ShippingAddressID", int.MinValue.GetType() );
            tableOrder.Columns.Add("ordrCCSurcharge", decimal.MinValue.GetType() );
            tableOrder.Columns.Add("ordrShippingCharges", decimal.MinValue.GetType() );
			tableOrder.Columns.Add("ordrTrackingNumber", string.Empty.GetType() );
            tableOrder.Columns.Add("ordrStatus", int.MinValue.GetType() );
			tableOrder.Columns.Add("ordrTrackingNumberNonUps", string.Empty.GetType() );
			tableOrder.Columns.Add("ordrCreated", DateTime.MinValue.GetType() );
			tableOrder.Columns.Add("adrFirstName", string.Empty.GetType() );
			tableOrder.Columns.Add("adrLastName", string.Empty.GetType() );
			tableOrder.Columns.Add("adrEMail", string.Empty.GetType() );
			tableOrder.Columns.Add("Total", double.MinValue.GetType() );
			
			if( tmpDataSet!=null && tmpDataSet.Tables.Count > 0)
			{
				foreach(DataRow row in tmpDataSet.Tables[0].Rows)
				{
					DataRow newRow = tableOrder.NewRow();
					newRow["ordrID"] = Convert.ToInt32( row["ordrID"] );
					newRow["ordrUID"] = Convert.ToString( row["ordrUID"] );
					newRow["ordr_CustomerID"] = row["ordr_CustomerID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["ordr_CustomerID"] );
					newRow["ordr_CreditCardInfoID"] = row["ordr_CreditCardInfoID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["ordr_CreditCardInfoID"] );
					newRow["ordr_BillingAddressID"] = row["ordr_BillingAddressID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["ordr_BillingAddressID"] );
					newRow["ordr_ShippingAddressID"] = row["ordr_ShippingAddressID"] == DBNull.Value ? -1 :
						Convert.ToInt32( row["ordr_ShippingAddressID"] );
                    newRow["ordrCCSurcharge"] = row["ordrCCSurcharge"] == DBNull.Value ? 0 : Convert.ToDecimal( row["ordrCCSurcharge"] );
                    newRow["ordrShippingCharges"] = row["ordrShippingCharges"] == DBNull.Value ? 0 : Convert.ToDecimal( row["ordrShippingCharges"] );
                    newRow["ordrTrackingNumber"] = Convert.ToString( row["ordrTrackingNumber"] );
					newRow["ordrStatus"] = Convert.ToString( row["ordrStatus"] );
					newRow["ordrTrackingNumberNonUps"] = Convert.ToString( row["ordrTrackingNumberNonUps"]);
					newRow["ordrCreated"] = row["ordrCreated"] == DBNull.Value ? DateTime.MinValue :
						Convert.ToDateTime( row["ordrCreated"] );

					newRow["adrFirstName"] = row["adrFirstName"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["adrFirstName"] );
					newRow["adrLastName"] = row["adrLastName"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["adrLastName"] );
					newRow["adrEMail"] = row["adrEMail"] == DBNull.Value ? string.Empty :
						Convert.ToString( row["adrEMail"] );
					newRow["Total"] = row["Total"] == DBNull.Value ? 0 :
						Convert.ToDouble( row["Total"] );

					tableOrder.Rows.Add(newRow);
				}
			}

			orderList.Tables.Add(tableOrder);
			
			return orderList;
		}

		/// <summary>
		///		Получает набор ордеров с указанным статусом
		/// </summary>
		public static DataSet GetList(int status)
		{
			DataSet tmpDataSet = null;
			
			if (status>=0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Order_GetListByStatus", new SqlParameter("@ordrStatus", status));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Order_GetList");

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор ордеров для указанного покупателя
		/// </summary>
		public static DataSet GetListByCustomerID(int customerID)
		{
			DataSet tmpDataSet = null;
			
			if (customerID>0)
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Order_GetListByCustomerID", new SqlParameter("@CustomerID", customerID));
			else
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Order_GetList");

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает набор всех ордеров
		/// </summary>
		public static DataSet GetList()
		{
			return GetList(-1);
		}

		/// <summary>
		///		Получает информацию об одном ордере
		/// </summary>
		public static DataSet GetItem(int id)
		{
			DataSet tmpDataSet = null;
			
			SqlParameter ordrID = new SqlParameter("@ordrID", id);
			tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Order_GetItem", ordrID);

			return ConvertList(tmpDataSet);
		}

		/// <summary>
		///		Получает информацию об одном ордере
		/// </summary>
		public static DataSet GetItemByUID(string uid)
		{
			DataSet tmpDataSet = null;
			
			try
			{
				SqlParameter ordrUID = new SqlParameter("@ordrUID", uid);
				tmpDataSet = SqlHelper.ExecuteDataset(m_sConnectionString, "ecom_Order_GetItemByUID", ordrUID);
			}
			catch{}

			return ConvertList(tmpDataSet);
		}

		#endregion

		#endregion

		#region Constructors

		/// <summary>
		///		Конструктор экземпляра класса DALCOrder
		/// </summary>
		private DALCOrder()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

	}
 

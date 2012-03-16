using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// ����� BLOProductAttribute ��������� ������-������ �������� �������� ������.
	/// </summary>
	public class BLOProductAttribute
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID �������� �������� ������
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID ��������, � �������� ����������� ������� �������� ������
		/// </summary>
		private int orderProductID;

		/// <summary>
		///		��� �������� �������� ������
		/// </summary>
		private string name;

		/// <summary>
		///		�������� �������� �������� ������
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		������������� � �������� ID �������� �������� ������
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		������������� � �������� ID �������� ������, � �������� ����������� �������
		/// </value>
		public int OrderProductID
		{
			get { return orderProductID; }
			set { orderProductID = value; }
		}

		/// <value>
		///		������������� � �������� ��� �������� �������� ������
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		������������� � �������� �������� �������� �������� ������
		/// </value>
		public string Value
		{
			get { return avalue; }
			set { avalue = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region Static Methods

		/// <summary>
		///		�������� ����� ���� ��������� �������� ������
		/// </summary>
		public static DataSet GetList()
		{
			return DALCOProductAttribute.GetList();
		}

		/// <summary>
		///		�������� ����� ��������� ���������� �������� ������
		/// </summary>
		public static DataSet GetList(int orderProductID)
		{
			DataSet opatList = null;
	
			opatList = DALCOProductAttribute.GetList(orderProductID);

			return opatList;
		}
		
		/// <summary>
		///		������� ������� �������� ������
		/// </summary>
		public void Delete(int id)
		{
			DALCOProductAttribute.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		������� ������� �������� ������
		/// </summary>
		public void Delete()
		{
			DALCOProductAttribute.Delete(this.id);
		}

		/// <summary>
		///		��������� ������� �������� ������
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCOProductAttribute.Update(this.id, this.orderProductID, this.name, this.avalue);
			
			return returnValue;
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.orderProductID = 0;
			this.name = string.Empty;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		�������� ���������� �� �������� �������� ������
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCOProductAttribute.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["OProductAttribute"].Rows[0]["opatID"] );
					this.orderProductID = Convert.ToInt32( item.Tables["OProductAttribute"].Rows[0]["opat_OrderProductID"] );
					this.name = Convert.ToString( item.Tables["OProductAttribute"].Rows[0]["opatName"] );
					this.avalue = Convert.ToString( item.Tables["OProductAttribute"].Rows[0]["opatValue"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� �� �������� �������� ������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		����������� ���������� ������ BLOProductAttribute
		/// </summary>
		public BLOProductAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
}

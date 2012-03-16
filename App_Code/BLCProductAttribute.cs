using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// ����� BLCProductAttribute ��������� ������-������ �������� �������� ����������.
	/// </summary>
	public class BLCProductAttribute
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID �������� �������� ����������
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID ��������, � �������� ����������� ������� �������� ����������
		/// </summary>
		private int cProductID;

		/// <summary>
		///		ID ��������
		/// </summary>
		private int attributeID;

		/// <summary>
		///		ID ������������ ��������
		/// </summary>
		private int attributeEnumID;

		/// <summary>
		///		ID �������� ��������
		/// </summary>
		private int attributeValueID;

		/// <summary>
		///		�������� �������� �������� ����������
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		������������� � �������� ID �������� �������� ����������
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		������������� � �������� ID �������� ����������, � �������� ����������� �������
		/// </value>
		public int CProductID
		{
			get { return cProductID; }
			set { cProductID = value; }
		}

		/// <value>
		///		������������� � �������� ID ��������
		/// </value>
		public int AttributeID
		{
			get { return attributeID; }
			set { attributeID = value; }
		}

		/// <value>
		///		������������� � �������� ID �������� ��������
		/// </value>
		public int AttributeValueID
		{
			get { return attributeValueID; }
			set { attributeValueID = value; }
		}

		/// <value>
		///		������������� � �������� �������� �������� �������� ����������
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
		///		�������� ����� ���� ��������� �������� ����������
		/// </summary>
		public static DataSet GetList()
		{
			return DALCCProductAttribute.GetList();
		}

		/// <summary>
		///		�������� ����� ��������� ���������� �������� ����������
		/// </summary>
		public static DataSet GetList(int cProductID)
		{
			DataSet cpatList = null;
	
			cpatList = DALCCProductAttribute.GetList(cProductID);

			return cpatList;
		}
		
		/// <summary>
		///		������� ������� �������� ����������
		/// </summary>
		public void Delete(int id)
		{
			DALCCProductAttribute.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		������� ������� �������� ����������
		/// </summary>
		public void Delete()
		{
			DALCCProductAttribute.Delete(this.id);
		}

		/// <summary>
		///		��������� ������� �������� ����������
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCCProductAttribute.Update(this.id, this.cProductID, this.attributeID, this.attributeEnumID, this.attributeValueID, this.avalue);
			
			return returnValue;
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.cProductID = 0;
			this.attributeID = 0;
			this.attributeEnumID = 0;
			this.attributeValueID = 0;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		�������� ���������� �� �������� �������� ����������
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCCProductAttribute.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpatID"] );
					this.cProductID = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpat_CProductID"] );
					this.attributeID = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpat_AttributeID"] );
					this.attributeValueID = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpat_AttributeValueID"] );
					this.avalue = Convert.ToString( item.Tables["CProductAttribute"].Rows[0]["cpatValue"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� �� �������� �������� ����������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		����������� ���������� ������ BLCProductAttribute
		/// </summary>
		public BLCProductAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
}

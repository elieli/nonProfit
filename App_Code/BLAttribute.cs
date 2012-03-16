using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// ����� BLAttribute ��������� ������-������ ��������.
	/// </summary>
	public class BLAttribute
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID ��������
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID ��������, � �������� ����������� �������
		/// </summary>
		private int productID;

		/// <summary>
		///		ID �������� ��������
		/// </summary>
		private int attributeValueID;

		/// <summary>
		///		��� ��������
		/// </summary>
		private string name;

		/// <summary>
		///		�������� ��������
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		������������� � �������� ID ��������
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		������������� � �������� ID ��������, � �������� ����������� �������
		/// </value>
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
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
		///		������������� � �������� ��� ��������
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		������������� � �������� �������� ��������
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
		///		�������� ����� ���� ���������
		/// </summary>
		public static DataSet GetList()
		{
			return DALCAttribute.GetList();
		}

		/// <summary>
		///		�������� ����� ��������� ���������� �������� 
		/// </summary>
		public static DataSet GetList(int productID)
		{
			DataSet attrList = null;
	
			attrList = DALCAttribute.GetList(productID);

			return attrList;
		}
		
		public static string GetValue(int productID, string attributeName)
		{
			return DALCAttribute.GetValue(productID, attributeName);	
		}

		/// <summary>
		///		������� �������
		/// </summary>
		public void Delete(int id)
		{
			DALCAttribute.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		������� �������
		/// </summary>
		public void Delete()
		{
			DALCAttribute.Delete(this.id);
		}

		/// <summary>
		///		��������� �������
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCAttribute.Update(this.id, this.productID, this.attributeValueID, this.name, this.avalue);
			
			return returnValue;
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.productID = 0;
			this.attributeValueID = 0;
			this.name = string.Empty;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		�������� ���������� �� ��������
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCAttribute.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["Attribute"].Rows[0]["attrID"] );
					this.productID = Convert.ToInt32( item.Tables["Attribute"].Rows[0]["attr_ProductID"] );
					this.attributeValueID = Convert.ToInt32( item.Tables["Attribute"].Rows[0]["attr_AttributeValueID"] );
					this.name = Convert.ToString( item.Tables["Attribute"].Rows[0]["attrName"] );
					this.avalue = Convert.ToString( item.Tables["Attribute"].Rows[0]["attrValue"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� �� ��������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		����������� ���������� ������ BLAttribute
		/// </summary>
		public BLAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
}

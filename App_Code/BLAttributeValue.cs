using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


 
	/// <summary>
	/// ����� BLAttributeValue ��������� ������-������ �������� ��������.
	/// </summary>
	public class BLAttributeValue
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID �������� ��������
		/// </summary>
		private int id;
		
		/// <summary>
		///		��� �������� ��������
		/// </summary>
		private string name;

		/// <summary>
		///		��������
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		������������� � �������� ID �������� ��������
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		������������� � �������� ��� �������� ��������
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		������������� � �������� ��������
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
		///		�������� ����� ���� �������� ���������
		/// </summary>
		public static DataSet GetList()
		{
			return DALCAttributeValue.GetList();
		}
		
		/// <summary>
		///		�������� �������� �� ID
		/// </summary>
		public static string GetValue(int atevID)
		{
			if( atevID > 0 )
			{
				DataSet item = DALCAttributeValue.GetItem(atevID);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					return Convert.ToString( item.Tables["AttributeValue"].Rows[0]["atevValue"] );
				}
			};
			return "";
		}

		/// <summary>
		///		�������� ����� �������� �������� ���������� ��������
		/// </summary>
		public static DataSet GetList(int attributeID)
		{
			DataSet atevList = null;
	
			atevList = DALCAttributeValue.GetList(attributeID);

			return atevList;
		}
		
		/// <summary>
		///		�������� ����� �������� �������� �� �����
		/// </summary>
		public static DataSet GetList(string name)
		{
			DataSet atevList = null;
	
			atevList = DALCAttributeValue.GetList(name);

			return atevList;
		}

		/// <summary>
		///		������� ������������ ��������
		/// </summary>
		public static void Delete(int id)
		{
			DALCAttributeValue.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		������� ������������ �������
		/// </summary>
		public void Delete()
		{
			DALCAttributeValue.Delete(this.id);
		}

		/// <summary>
		///		��������� ������������ ��������
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCAttributeValue.Update(this.id, this.name, this.avalue);
			this.id = returnValue;
			
			return returnValue;
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.name = string.Empty;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		�������� ���������� � ������������ ��������
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCAttributeValue.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["AttributeValue"].Rows[0]["atevID"] );
					this.name = Convert.ToString( item.Tables["AttributeValue"].Rows[0]["atevName"] );
					this.avalue = Convert.ToString( item.Tables["AttributeValue"].Rows[0]["atevValue"] );
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
		///		����������� ���������� ������ BLAttributeValue
		/// </summary>
		public BLAttributeValue()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

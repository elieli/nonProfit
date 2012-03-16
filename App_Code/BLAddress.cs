using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Summary description for BLAddress.
	/// </summary>
	public class BLAddress
	{
		
		#region Fields

		private int id;
		private string firstName;
		private string lastName;
		private string company;
		private string address1;
		private string address2;
		private string city;
		private string state;
		private string postCode;
		private string country;
		private string phone;
		private string fax;
		private string eMail;
		private string field1;
		private string field2;
		private string field3;
		private string field4;
		private string field5;
		private string field6;
		private string field7;
		
		#endregion

		#region Properties
		
		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}

		public string EMail
		{
			get{ return eMail; }
			set{ eMail = value; }
		}

		public string Fax
		{
			get{ return fax; }
			set{ fax = value; }
		}

		public string Phone
		{
			get{ return phone; }
			set{ phone = value; }
		}

		public string Country
		{
			get{ return country; }
			set{ country = value; }
		}
		
		public string PostCode
		{
			get{ return postCode; }
			set{ postCode = value; }
		}

		public string State
		{
			get{ return state; }
			set{ state = value; }
		}
		
		public string City
		{
			get{ return city; }
			set{ city = value; }
		}

		public string Address1
		{
			get{ return address1; }
			set{ address1 = value; }
		}

		public string Address2
		{
			get{ return address2; }
			set{ address2 = value; }
		}

		public string Company
		{
			get{ return company; }
			set{ company = value; }
		}

		
		public string LastName
		{
			get{ return lastName; }
			set{ lastName = value; }
		}

		public string FirstName
		{
			get{ return firstName; }
			set{ firstName = value; }
		}

		public string Field1
		{
			get{ return field1; }
			set{ field1 = value; }
		}

		public string Field2
		{
			get{ return field2; }
			set{ field2 = value; }
		}

		public string Field3
		{
			get{ return field3; }
			set{ field3 = value; }
		}

		public string Field4
		{
			get{ return field4; }
			set{ field4 = value; }
		}

		public string Field5
		{
			get{ return field5; }
			set{ field5 = value; }
		}

		public string Field6
		{
			get{ return field6; }
			set{ field6 = value; }
		}

		public string Field7
		{
			get{ return field7; }
			set{ field7 = value; }
		}

		#endregion

		#region Methods
		
		#region Static Methods

		public static int Update(int ID, string FirstName, string LastName, string Company, 
			string Address1, string Address2, string City, string State, string PostCode, string Country,
			string Phone, string Fax, string EMail, string Field1, string Field2, string Field3, string Field4, string Field5, string Field6, string Field7)
		{
			int returnValue = 0;

			returnValue = DALCAddress.Update(ID, FirstName, LastName, Company, Address1, Address2, City, State, 
				PostCode, Country, Phone, Fax, EMail, Field1, Field2, Field3, Field4, Field5, Field6, Field7);

			return returnValue;
		}

		public static int Update(int ID, string FirstName, string LastName, string Company, 
			string Address1, string Address2, string City, string State, string PostCode, string Country,
			string Phone, string Fax, string EMail)
		{
			int returnValue = 0;

			returnValue = Update(ID, FirstName, LastName, Company, Address1, Address2, City, State, 
				PostCode, Country, Phone, Fax, EMail, "", "", "", "", "", "", "");

			return returnValue;
		}

		public static void Delete(int Id)
		{
			DALCAddress.Delete(Id);
		}

		public static DataSet GetList()
		{
			return DALCAddress.GetList();
		}

		#endregion

		#region None Static Methods
		
		public void Update()
		{
			int addressInfoID = 0;

			addressInfoID = Update(this.id, this.firstName, this.lastName, this.company, this.address1, this.address2,
				this.city, this.state, this.postCode, this.country, this.phone, this.fax, this.eMail, this.field1, this.field2, this.field3, this.field4, this.field5, this.field6, this.field7);

			this.id = addressInfoID;
		}

		
		public void Delete()
		{
			Delete(this.id);
		}

		public void Retrieve()
		{
			Init();
		}
		
		private void Init()
		{
			if( this.id > 0 )
			{
				DataSet items = DALCAddress.GetItem(this.id);

				if( items.Tables.Count > 0 && items.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( items.Tables["Address"].Rows[0]["ID"] );
					this.firstName = Convert.ToString( items.Tables["Address"].Rows[0]["FirstName"] );
					this.lastName = Convert.ToString( items.Tables["Address"].Rows[0]["LastName"] );
					this.company = Convert.ToString( items.Tables["Address"].Rows[0]["Company"] );
					this.address1 = Convert.ToString( items.Tables["Address"].Rows[0]["Address1"] );
					this.address2 = Convert.ToString( items.Tables["Address"].Rows[0]["Address2"] );
					this.city = Convert.ToString( items.Tables["Address"].Rows[0]["City"] );
					this.state = Convert.ToString( items.Tables["Address"].Rows[0]["State"] );
					this.postCode = Convert.ToString( items.Tables["Address"].Rows[0]["PostCode"] );
					this.country = Convert.ToString( items.Tables["Address"].Rows[0]["Country"] );
					this.phone = Convert.ToString( items.Tables["Address"].Rows[0]["Phone"] );
					this.fax = Convert.ToString( items.Tables["Address"].Rows[0]["Fax"] );
					this.eMail = Convert.ToString( items.Tables["Address"].Rows[0]["EMail"] );
					this.field1 = Convert.ToString( items.Tables["Address"].Rows[0]["Field1"] );
					this.field2 = Convert.ToString( items.Tables["Address"].Rows[0]["Field2"] );
					this.field3 = Convert.ToString( items.Tables["Address"].Rows[0]["Field3"] );
					this.field4 = Convert.ToString( items.Tables["Address"].Rows[0]["Field4"] );
					this.field5 = Convert.ToString( items.Tables["Address"].Rows[0]["Field5"] );
					this.field6 = Convert.ToString( items.Tables["Address"].Rows[0]["Field6"] );
					this.field7 = Convert.ToString( items.Tables["Address"].Rows[0]["Field7"] );

				}
				else
				{
					this.id = 0;
					ClearFields();
				}
			}
			else
			{
				this.id = 0;
				ClearFields();
			}
		}

		private void ClearFields()
		{
			this.firstName = string.Empty;
			this.lastName = string.Empty;
			this.company = string.Empty;
			this.address1 = string.Empty;
			this.address2 = string.Empty;
			this.city = string.Empty;
			this.state = string.Empty;
			this.postCode = string.Empty;
			this.country = string.Empty;
			this.phone = string.Empty;
			this.fax = string.Empty;
			this.eMail = string.Empty;
			this.field1 = string.Empty;
			this.field2 = string.Empty;
			this.field3 = string.Empty;
			this.field4 = string.Empty;
			this.field5 = string.Empty;
			this.field6 = string.Empty;
			this.field7 = string.Empty;
		}

		#endregion

		#endregion
		
		public BLAddress()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
//}

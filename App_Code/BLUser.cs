using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Summary description for BLUser.
	/// </summary>
	public class BLUser
	{
		#region Fields
		
		private int id;
		private BLCustomer customer;
		private string uid;
		private bool enabled;
		private string login;
		private string password;
		private string email;
		private DateTime created;
		
		#endregion
		
		#region Properties
		
		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}

		public BLCustomer Customer
		{
			get{ return customer; }
			set{ customer = value; }
		}
		
		public string UID
		{
			get{ return uid; }
			set{ uid = value; }
		}

		public bool Enabled
		{
			get{ return enabled; }
			set{ enabled = value; }
		}

		public string Login
		{
			get{ return login; }
			set{ login = value; }
		}

		public string Password
		{
			get{ return password; }
			set{ password = value; }
		}

		public string EMail
		{
			get{ return email; }
			set{ email = value; }
		}

		public DateTime Created
		{
			get{ return created; }
			set{ created = value; }
		}

		#endregion

		#region Methods
		
		#region Static Methods
		
		public static DataSet GetList()
		{
			return DALCUser.GetList();
		}
		
		public static DataSet GetListByProduct(int productID)
		{
			return DALCUser.GetListByProduct(productID);
		}

		public static int Update(int ID, int CustomerID, string UID, bool Enabled, string Login, string Password,
			string EMail, DateTime Created)
		{
			int returnValue = 0;
			
			returnValue = DALCUser.Update(ID, CustomerID, UID, Enabled, Login, Password, EMail, Created);

			return returnValue;
		}

		public static void Delete(int Id)
		{
			DALCUser.Delete(Id);
		}

		#endregion
		
		#region None Static Methods
		
		public int Update()
		{
			int returnValue = 0;

			if (this.id>0)
			{
				BLUser oldUser = new BLUser();
				oldUser.ID = this.id;
				oldUser.Retrieve();
				if (oldUser.ID > 0 )
				{
					if (oldUser.Login!=this.login || oldUser.Password!=this.password)
					{
						this.uid=Guid.NewGuid().ToString();
					}
				}
			}
			else
			{
				this.uid=Guid.NewGuid().ToString();
			}

			returnValue = Update(this.id, this.customer.ID, this.uid, this.enabled, this.login, this.password, this.email, this.created);
			
			this.id = returnValue;

			return returnValue;
		}
		
		public void Delete()
		{
			Delete(this.id);
		}

		public void Retrieve()
		{
			DataSet items;

			if( this.login.Length > 0 )
				items = DALCUser.GetItemByLogin(this.login);
			else if( this.uid.Length > 0 )
				items = DALCUser.GetItemByUID(this.uid);
			else if( this.email.Length > 0 )
				items = DALCUser.GetItemByEMail(this.email);
			else
				items = DALCUser.GetItem(this.id);

			if( items.Tables.Count > 0 && items.Tables[0].Rows.Count > 0)
			{
				this.id = Convert.ToInt32( items.Tables["User"].Rows[0]["ID"] );
				int customerID = Convert.ToInt32( items.Tables["User"].Rows[0]["CustomerID"] );
				this.uid = Convert.ToString( items.Tables["User"].Rows[0]["UID"] );
				this.enabled = Convert.ToBoolean( items.Tables["User"].Rows[0]["Enabled"] );
				this.login = Convert.ToString( items.Tables["User"].Rows[0]["Login"] );
				this.password = Convert.ToString( items.Tables["User"].Rows[0]["Password"] );
				this.email = Convert.ToString( items.Tables["User"].Rows[0]["EMail"] );
				this.created = Convert.ToDateTime( items.Tables["User"].Rows[0]["Created"] );

				if (customer == null)
				{
					customer = new BLCustomer(0);
				}
				if( customerID > 0)
				{
					this.customer.ID = customerID;
					this.customer.Retrieve();
				}
				else
				{
				}
			}
			else
			{
				ClearFields();
			}
		}
		
		private void Init()
		{
			Retrieve();
		}

		private void ClearFields()
		{
			this.id = 0;

			this.customer = null;
			this.customer = new BLCustomer(0);

			this.uid = string.Empty;
			this.enabled = false;
			this.login = string.Empty;
			this.password = string.Empty;
			this.email = string.Empty;
			this.created = DateTime.MinValue;
		}

		#endregion

		#endregion		
		
		public BLUser()
		{
			ClearFields();
		}
	}
//}

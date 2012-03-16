using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Summary description for BLCreditCard.
	/// </summary>
	public class BLCreditCard
	{
		#region Fields

		private string cardNumber;
		private int id;

		private string cardHolder;
		private DateTime startDate;
		private DateTime expiryDate;
		private string issueNumber;
		private string cardType;
		private string cvv;
		
		#endregion

		#region Properties

		public string CardHolder
		{
			get{ return cardHolder; }
			set{ cardHolder = value; }
		}

		public string CardType
		{
			get{ return cardType; }
			set{ cardType = value; }
		}
		
		public string CardNumber
		{
			get{ return cardNumber; }
			set{ cardNumber = value; }
		}

		public string CVV
		{
			get{ return cvv; }
			set{ cvv = value; }
		}

		public string IssueNumber
		{
			get{ return issueNumber; }
			set{ issueNumber = value; }
		}

		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}

		public DateTime StartDate
		{
			get{ return startDate; }
			set{ startDate = value; }
		}

		public DateTime ExpiryDate
		{
			get{ return expiryDate; }
			set{ expiryDate = value; }
		}

		#endregion

		#region Methods
		
		#region Static Methods

		public static int Update(int ID, string CardHolder, string CardNumber, string CardType, 
			DateTime StartDate, DateTime ExpiryDate, string IssueNumber, string CVV)
		{
			int returnValue = 0;

			returnValue = DALCCreditCard.Update(ID, CardHolder, CardNumber, CardType, 
								StartDate, ExpiryDate, IssueNumber, CVV);

			return returnValue;
		}


		public static void Delete(int Id)
		{
			DALCCreditCard.Delete(Id);
		}

		public static DataSet GetList()
		{
			return DALCCreditCard.GetList();
		}

		#endregion

		
		#region None Static Methods
		
		public void Update()
		{
			int itemID = 0;

			itemID = Update(this.id, this.cardHolder, this.cardNumber, this.cardType, this.startDate, 
				this.expiryDate, this.issueNumber, this.cvv);

			this.id = itemID;
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
				DataSet items = DALCCreditCard.GetItem(this.id);
				if( items.Tables.Count > 0 && items.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( items.Tables["CreditCard"].Rows[0]["ID"] );
					this.cardHolder = Convert.ToString( items.Tables["CreditCard"].Rows[0]["CardHolder"] );
					this.cardNumber = Convert.ToString( items.Tables["CreditCard"].Rows[0]["CardNumber"] );
					this.cardType = Convert.ToString( items.Tables["CreditCard"].Rows[0]["CardType"] );
					this.issueNumber = Convert.ToString( items.Tables["CreditCard"].Rows[0]["IssueNumber"] );
					this.cvv = Convert.ToString( items.Tables["CreditCard"].Rows[0]["CVV"] );
					this.startDate  = Convert.ToDateTime( items.Tables["CreditCard"].Rows[0]["StartDate"] );
					this.expiryDate = Convert.ToDateTime( items.Tables["CreditCard"].Rows[0]["ExpiryDate"] );
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
			this.cardHolder = string.Empty;
			this.cardNumber = string.Empty;
			this.cardType = string.Empty;
			this.issueNumber = string.Empty;
			this.cvv = string.Empty;
			this.expiryDate = DateTime.MinValue;
			this.startDate = DateTime.MinValue;
		}

		#endregion

		#endregion
		
		public BLCreditCard()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
//}

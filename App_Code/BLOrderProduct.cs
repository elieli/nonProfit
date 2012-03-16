using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// ����� BLOrdersProduct ��������� ������-������ �������� ������.
	/// </summary>
	public class BLOrdersProduct
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID �������� ������
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID ������, � �������� ����������� �������
		/// </summary>
		private int orderID;

        /// <summary>
        ///		ID ��������
        /// </summary>
        private int productID;

		/// <summary>
		///		��� �������� ������
		/// </summary>
		private string skuNumber;

		/// <summary>
		///		��� �������� ������
		/// </summary>
		private string name;

		/// <summary>
		///		���� �������� ������
		/// </summary>
		private decimal price;

		/// <summary>
		///		���������� �������� ������
		/// </summary>
		private int quantity;

        /// <summary>
        ///		������� ��������������
        /// </summary>
        private bool personalize;

        /// <summary>
        ///		���� ��������������
        /// </summary>
        private decimal persPrice;

        /// <summary>
        ///		����������� ��������������
        /// </summary>
		private string persComments;

		/// <summary>
		///		���� � ����� ��������������� ��������������
		/// </summary>
		private string persFileName;

		/// <summary>
		///		����� ��������� �������� ������
		/// </summary>
		private DataSet oProductAttributes;

		/// <summary>
		///		������������� �� ���� �������������� ��� �������������� �������������
		/// </summary>
		private bool isPersonalizationLocked;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		������������� � �������� ID �������� ������
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		������������� � �������� ID ������, � �������� ����������� �������
		/// </value>
		public int OrderID
		{
			get { return orderID; }
			set { orderID = value; }
		}

        /// <value>
        ///		������������� � �������� ID ��������
        /// </value>
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

		/// <value>
		///		������������� � �������� ��� �������� ������
		/// </value>
		public string SkuNumber
		{
			get { return skuNumber; }
			set { skuNumber = value; }
		}

		/// <value>
		///		������������� � �������� ��� �������� ������
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		������������� � �������� ���� �������� ������
		/// </value>
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

		/// <value>
		///		������������� � �������� ���������� �������� ������
		/// </value>
		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

        /// <value>
        ///		������������� � �������� ������� ��������������
        /// </value>
        public bool Personalize
        {
            get { return personalize; }
            set { personalize = value; }
        }

        /// <value>
        ///		������������� � �������� ���� ��������������
        /// </value>
        public decimal PersPrice
        {
            get { return persPrice; }
            set { persPrice = value; }
        }

        /// <value>
        ///		������������� � �������� ���� � ����� ��������������
        /// </value>
        public string PersFileName
        {
            get { return persFileName; }
            set { persFileName = value; }
		}

		/// <value>
		///		������������� � �������� ����������� ��������������
		/// </value>
		public string PersComments
		{
			get { return persComments; }
			set { persComments = value; }
		}

		/// <value>
		///		�������� ����� ��������� �������� ������
		/// </value>
		public DataSet OProductAttributes
		{
			get
			{
				return oProductAttributes;
			}
		}


		/// <summary>
		///		������������� �� ���� �������������� ��� �������������� �������������
		/// </summary>
		public bool IsPersonalizationLocked
		{
			get { return isPersonalizationLocked; }
			set { isPersonalizationLocked = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region Static Methods

		/// <summary>
		///		�������� ����� ���� ��������� �������
		/// </summary>
		public static DataSet GetList()
		{
			return DALCOrderProduct.GetList();
		}

		/// <summary>
		///		�������� ����� ��������� ���������� ������
		/// </summary>
		public static DataSet GetList(int orderID)
		{
			DataSet orprList = null;
	
			orprList = DALCOrderProduct.GetList(orderID);

			return orprList;
		}
		
		/// <summary>
		///		������� ������� ������
		/// </summary>
		public void Delete(int id)
		{
			DALCOrderProduct.Delete(id);
		}
		
		/// <summary>
		///		�������� GUID ������������, ��������� ������������ �������
		/// </summary>
		/// <param name="orderProductID">
		///		ID OrderProduct'a
		/// </param>
		public static string GetUserGUIDByOrderProductID(int orderProductID)
		{
			return DALCOrderProduct.GetUserGUIDByOrderProductID(orderProductID);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		������� ������� ������
		/// </summary>
		public void Delete()
		{
			DALCOrderProduct.Delete(this.id);
		}

		/// <summary>
		///		��������� ������� ������
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCOrderProduct.Update(this.id, this.orderID, this.productID, this.skuNumber, this.name, this.price, this.quantity, this.personalize, this.persPrice, this.persComments, this.persFileName, this.isPersonalizationLocked);
			
			return returnValue;
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.orderID = 0;
            this.productID = 0;
			this.skuNumber = string.Empty;
			this.name = string.Empty;
			this.price = 0;
			this.quantity = 0;
            this.personalize = false;
            this.persPrice = 0;
            this.persComments = string.Empty;
			this.oProductAttributes = null;
			this.isPersonalizationLocked = false;
		}

		/// <summary>
		///		�������� ���������� � �������� ������
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCOrderProduct.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["OrderProduct"].Rows[0]["orprID"] );
					this.orderID = Convert.ToInt32( item.Tables["OrderProduct"].Rows[0]["orpr_OrderID"] );
                    this.productID = Convert.ToInt32( item.Tables["OrderProduct"].Rows[0]["orpr_ProductID"] );
					this.skuNumber = Convert.ToString( item.Tables["OrderProduct"].Rows[0]["orprSkuNumber"] );
					this.name = Convert.ToString( item.Tables["OrderProduct"].Rows[0]["orprName"] );
					this.price = Convert.ToDecimal( item.Tables["OrderProduct"].Rows[0]["orprPrice"] );
					this.quantity = Convert.ToInt32( item.Tables["OrderProduct"].Rows[0]["orprQuantity"] );
                    this.personalize = Convert.ToBoolean( item.Tables["OrderProduct"].Rows[0]["orprPersonalize"] );
                    this.persPrice = Convert.ToDecimal( item.Tables["OrderProduct"].Rows[0]["orprPersPrice"] );
					this.persComments = Convert.ToString( item.Tables["OrderProduct"].Rows[0]["orprPersComments"] );
					this.persFileName = (string)item.Tables["OrderProduct"].Rows[0]["orprPersFileName"];
					this.isPersonalizationLocked = (bool)item.Tables["OrderProduct"].Rows[0]["orprIsPersonalizationLocked"];
					//this.orpributeEnums = DALCOrderProductEnum.GetList(this.id);
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� � �������� ������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}
		
		/// <summary>
		///		��������� ���� ���������� �������������� � ������ � ��������� ��� ��������� � ������ ��������� � ��
		/// </summary>
		public void UploadPersFile(Stream inputStream, string path)
		{
			if( inputStream.CanRead )
			{
				int BUFFER_LENGTH = 256;
				int readBytes;

				try
				{
					string fileName = Guid.NewGuid().ToString() + ".pdf";
					FileStream outputStream = new FileStream(path + "\\" + fileName, FileMode.Create);

					try
					{
						byte[] buffer = new byte[BUFFER_LENGTH];
						for( int i = 0; i < inputStream.Length; i += BUFFER_LENGTH )
						{
							readBytes = inputStream.Read(buffer, 0, BUFFER_LENGTH);
							outputStream.Write(buffer, 0, readBytes);
						}
						
						this.persFileName = fileName;
						this.Update();
					}
					finally
					{
						outputStream.Close();
					}					
				}
				finally
				{
					inputStream.Close();
				}
			}
		}


		/// <summary>
		///		������� URL �����-������� ��������������, ���� �� ����������
		/// </summary>
		public string GetPersFileUrl()
		{
			string url = string.Empty;
			string samplePersFilePath = System.Configuration.ConfigurationSettings.AppSettings["PersonalizationSampleFile_URL"];
			url = System.Web.HttpContext.Current.Request.ApplicationPath + samplePersFilePath + this.persFileName;
			url = url.Replace("//", "/");
			return url;
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		����������� ���������� ������ BLOrdersProduct
		/// </summary>
		public BLOrdersProduct()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
}

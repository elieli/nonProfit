using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// Класс BLOrdersProduct реализует бизнес-логику продукта заказа.
	/// </summary>
	public class BLOrdersProduct
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID продукта ордера
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID ордера, к которому принадлежит продукт
		/// </summary>
		private int orderID;

        /// <summary>
        ///		ID продукта
        /// </summary>
        private int productID;

		/// <summary>
		///		Код продукта ордера
		/// </summary>
		private string skuNumber;

		/// <summary>
		///		Имя продукта ордера
		/// </summary>
		private string name;

		/// <summary>
		///		Цена продукта ордера
		/// </summary>
		private decimal price;

		/// <summary>
		///		Количество продукта ордера
		/// </summary>
		private int quantity;

        /// <summary>
        ///		Признак персонализации
        /// </summary>
        private bool personalize;

        /// <summary>
        ///		Цена персонализации
        /// </summary>
        private decimal persPrice;

        /// <summary>
        ///		Комментарии персонализации
        /// </summary>
		private string persComments;

		/// <summary>
		///		Путь к файлу иллюстрирующему персонализацию
		/// </summary>
		private string persFileName;

		/// <summary>
		///		Набор атрибутов продукта ордера
		/// </summary>
		private DataSet oProductAttributes;

		/// <summary>
		///		Заблокированы ли поля персонализации для редактирования пользователем
		/// </summary>
		private bool isPersonalizationLocked;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID продукта ордера
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		Устанавливает и получает ID ордера, к которому принадлежит продукт
		/// </value>
		public int OrderID
		{
			get { return orderID; }
			set { orderID = value; }
		}

        /// <value>
        ///		Устанавливает и получает ID продукта
        /// </value>
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

		/// <value>
		///		Устанавливает и получает код продукта ордера
		/// </value>
		public string SkuNumber
		{
			get { return skuNumber; }
			set { skuNumber = value; }
		}

		/// <value>
		///		Устанавливает и получает имя продукта ордера
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		Устанавливает и получает цену продукта ордера
		/// </value>
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

		/// <value>
		///		Устанавливает и получает количество продукта ордера
		/// </value>
		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

        /// <value>
        ///		Устанавливает и получает признак персонализации
        /// </value>
        public bool Personalize
        {
            get { return personalize; }
            set { personalize = value; }
        }

        /// <value>
        ///		Устанавливает и получает цену персонализации
        /// </value>
        public decimal PersPrice
        {
            get { return persPrice; }
            set { persPrice = value; }
        }

        /// <value>
        ///		Устанавливает и получает путь к файлу персонализации
        /// </value>
        public string PersFileName
        {
            get { return persFileName; }
            set { persFileName = value; }
		}

		/// <value>
		///		Устанавливает и получает комментарии персонализации
		/// </value>
		public string PersComments
		{
			get { return persComments; }
			set { persComments = value; }
		}

		/// <value>
		///		Получает набор атрибутов продукта ордера
		/// </value>
		public DataSet OProductAttributes
		{
			get
			{
				return oProductAttributes;
			}
		}


		/// <summary>
		///		Заблокированы ли поля персонализации для редактирования пользователем
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
		///		Получает набор всех продуктов ордеров
		/// </summary>
		public static DataSet GetList()
		{
			return DALCOrderProduct.GetList();
		}

		/// <summary>
		///		Получает набор продуктов указанного ордера
		/// </summary>
		public static DataSet GetList(int orderID)
		{
			DataSet orprList = null;
	
			orprList = DALCOrderProduct.GetList(orderID);

			return orprList;
		}
		
		/// <summary>
		///		Удаляет продукт ордера
		/// </summary>
		public void Delete(int id)
		{
			DALCOrderProduct.Delete(id);
		}
		
		/// <summary>
		///		Получает GUID пользователя, купившего определенный продукт
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
		///		Удаляет продукт ордера
		/// </summary>
		public void Delete()
		{
			DALCOrderProduct.Delete(this.id);
		}

		/// <summary>
		///		Обновляет продукт ордера
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCOrderProduct.Update(this.id, this.orderID, this.productID, this.skuNumber, this.name, this.price, this.quantity, this.personalize, this.persPrice, this.persComments, this.persFileName, this.isPersonalizationLocked);
			
			return returnValue;
		}

		/// <summary>
		///		Инициализирует переменные
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
		///		Получает информацию о продукте ордера
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
		///		Инициализирует информацию о продукте ордера
		/// </summary>
		private void Init()
		{
			Retrieve();
		}
		
		/// <summary>
		///		Загружает файл клиентской персонализации с потока и применяет все сделанные в классе изменения в БД
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
		///		Достает URL файла-примера персонализации, если он существует
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
		///		Конструктор экземпляра класса BLOrdersProduct
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

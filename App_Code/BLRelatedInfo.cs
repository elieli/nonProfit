using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Класс BLRelatedInfo реализует бизнес-логику связанной информации.
	/// </summary>
	public class BLRelatedInfo
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID связанного файла
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID продукта, с которым связана информация
		/// </summary>
		private int productID;

		/// <summary>
		///		Имя связанной информации
		/// </summary>
		private string name;

		/// <summary>
		///		Описание связанной информации
		/// </summary>
		private string description;

		/// <summary>
		///		url
		/// </summary>
		private string url;

		/// <summary>
		///		Признак специальности
		/// </summary>
		private string special;

		/// <summary>
		///		Порядковый номер
		/// </summary>
		private int order;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID связанной информации
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		Устанавливает и получает ID продукта, с которым связана информация
		/// </value>
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

		/// <value>
		///		Устанавливает и получает имя связанного файла
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		Устанавливает и получает описание связанного файла
		/// </value>
		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		/// <value>
		///		Устанавливает и получает URL
		/// </value>
		public string URL
		{
			get { return url; }
			set { url = value; }
		}

		/// <value>
		///		Устанавливает и получает признак специальности
		/// </value>
		public string Special
		{
			get { return special; }
			set { special = value; }
		}

		/// <value>
		///		Устанавливает и получает порядковый номер
		/// </value>
		public int Order
		{
			get { return order; }
			set { order = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region Static Methods

		/// <summary>
		///		Получает набор всей связанной информации
		/// </summary>
		public static DataSet GetList()
		{
			return DALCRelatedInfo.GetList();
		}

		/// <summary>
		///		Получает набор связанной информации
		/// </summary>
		public static DataSet GetList(int productID)
		{
			DataSet rlnfList = null;
	
			rlnfList = DALCRelatedInfo.GetList(productID);

			return rlnfList;
		}
		
		/// <summary>
		///		Получает набор связанной информации
		/// </summary>
		public static DataSet GetList(int productID, string special)
		{
			DataSet rlnfList = null;
	
			rlnfList = DALCRelatedInfo.GetList(productID, special);

			return rlnfList;
		}

		/// <summary>
		///		Удаляет связанную информацию
		/// </summary>
		public static void Delete(int id)
		{ 
			DALCRelatedInfo.Delete(id);
		}

		/// <summary>
		///		Обновляет связанную информацию
		/// </summary>
		public static int Update(int id, int productID, string name, string description, string url, string special, int order)
		{
			int returnValue = -1;
			
			returnValue = DALCRelatedInfo.Update(id, productID, name, description, url, special, order);
			
			return returnValue;
		}

		/// <summary>
		///		Копирует связанную информацию
		/// </summary>
		public static void CopyToProduct(int productID, int toProductID)
		{ 
			DALCRelatedInfo.CopyToProduct(productID, toProductID);
		}

		/// <summary>
		///		Удаляет связанную информацию продукта
		/// </summary>
		public static void DeleteByProduct(int productID)
		{ 
			DALCRelatedInfo.DeleteByProduct(productID);
		}

		/// <summary>
		///		Перемещает связанную информацию
		/// </summary>
		public static void MoveToProduct(int productID, int toProductID)
		{ 
			DALCRelatedInfo.DeleteByProduct(toProductID);
			DALCRelatedInfo.CopyToProduct(productID, toProductID);
			DALCRelatedInfo.DeleteByProduct(productID);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		Удаляет связанную информацию
		/// </summary>
		public void Delete()
		{
			DALCRelatedInfo.Delete(this.id);
		}

		/// <summary>
		///		Обновляет связанную информацию
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = Update(this.id, this.productID, this.name, this.description, this.url, this.special, this.order);
			
			return returnValue;
		}

		/// <summary>
		///		Инициализирует переменные
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.productID = -1;
			this.name = string.Empty;
			this.description = string.Empty;
			this.url = string.Empty;
			this.special = string.Empty;
			this.order = 0;
		}

		/// <summary>
		///		Получает информацию о связанной информации
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCRelatedInfo.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["RelatedInfo"].Rows[0]["rlnfID"] );
					this.productID = Convert.ToInt32( item.Tables["RelatedInfo"].Rows[0]["rlnf_ProductID"] );
					this.name = Convert.ToString( item.Tables["RelatedInfo"].Rows[0]["rlnfName"] );
					this.description = Convert.ToString( item.Tables["RelatedInfo"].Rows[0]["rlnfDescription"] );
					this.url = Convert.ToString( item.Tables["RelatedInfo"].Rows[0]["rlnfURL"] );
					this.special = Convert.ToString( item.Tables["RelatedInfo"].Rows[0]["rlnfSpecial"] );
					this.order = Convert.ToInt32( item.Tables["RelatedInfo"].Rows[0]["rlnfOrder"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		Инициализирует информацию
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		Конструктор экземпляра класса BLRelatedInfo
		/// </summary>
		public BLRelatedInfo()
		{
			FieldInitialization();
		}
		#endregion

	}
//}

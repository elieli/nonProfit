using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;



//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// Класс BLRelatedFile реализует бизнес-логику связанного файла.
	/// </summary>
	public class BLRelatedFile
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID связанного файла
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID продукта, с которым связан файл
		/// </summary>
		private int productID;

		/// <summary>
		///		Имя связанного файла
		/// </summary>
		private string name;

		/// <summary>
		///		Описание связанного файла
		/// </summary>
		private string description;

		/// <summary>
		///		Имя файла на диске
		/// </summary>
		private string fileName;

		/// <summary>
		///		Расширение файла на диске
		/// </summary>
		private string fileExtension;

		/// <summary>
		///		Оригинальное имя загруженного файла
		/// </summary>
		private string originalFileName;

		/// <summary>
		///		Признак специальности
		/// </summary>
		private string special;

		/// <summary>
		///		Порядковый номер связанного файла
		/// </summary>
		private int order;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID связанного файла
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		Устанавливает и получает ID продукта, с которым связан файл
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
		///		Устанавливает и получает имя файла на диске
		/// </value>
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

		/// <value>
		///		Устанавливает и получает расширение файла на диске
		/// </value>
		public string FileExtension
		{
			get { return fileExtension; }
			set { fileExtension = value; }
		}

		/// <value>
		///		Устанавливает и получает оригинальное имя загруженного файла
		/// </value>
		public string OriginalFileName
		{
			get { return originalFileName; }
			set { originalFileName = value; }
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
		///		Устанавливает и получает порядковый номер связанного файла
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
		///		Получает набор всех связанных файлов
		/// </summary>
		public static DataSet GetList()
		{
			return DALCRelatedFile.GetList();
		}

		/// <summary>
		///		Получает набор связанных файлов
		/// </summary>
		public static DataSet GetList(int productID)
		{
			DataSet rlflList = null;
	
			rlflList = DALCRelatedFile.GetList(productID);

			return rlflList;
		}
		
		/// <summary>
		///		Получает набор связанных файлов
		/// </summary>
		public static DataSet GetList(int productID, string special)
		{
			DataSet rlflList = null;
	
			rlflList = DALCRelatedFile.GetList(productID, special);

			return rlflList;
		}

		/// <summary>
		///		Удаляет связанный файл
		/// </summary>
		public static void Delete(int id)
		{ 
			DALCRelatedFile.Delete(id);
		}

		/// <summary>
		///		Обновляет связанный файл
		/// </summary>
		public static int Update(int id, int productID, string name, string description, HttpPostedFile pf, string fileName, string special, int order)
		{
			int returnValue = -1;
			
			returnValue = DALCRelatedFile.Update(id, productID, name, description, pf, fileName, special, order);
			
			return returnValue;
		}

		/// <summary>
		///		Копирует связанные файлы
		/// </summary>
		public static void CopyToProduct(int productID, int toProductID)
		{ 
			DALCRelatedFile.CopyToProduct(productID, toProductID);
		}

		/// <summary>
		///		Удаляет связанные файлы продукта
		/// </summary>
		public static void DeleteByProduct(int productID)
		{ 
			DALCRelatedFile.DeleteByProduct(productID);
		}

		/// <summary>
		///		Перемещает связанные файлы
		/// </summary>
		public static void MoveToProduct(int productID, int toProductID)
		{ 
			DALCRelatedFile.DeleteByProduct(toProductID);
			DALCRelatedFile.CopyToProduct(productID, toProductID);
			DALCRelatedFile.DeleteByProduct(productID);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		Удаляет связанный файл
		/// </summary>
		public void Delete()
		{
			DALCRelatedFile.Delete(this.id);
		}

		/// <summary>
		///		Обновляет связанный файл
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = Update(this.id, this.productID, this.name, this.description, null, this.fileName, this.special, this.order);
			
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
			this.fileName = string.Empty;
			this.fileExtension = string.Empty;
			this.originalFileName = string.Empty;
			this.special = string.Empty;
			this.order = 0;
		}

		/// <summary>
		///		Получает информацию о связанном файле
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCRelatedFile.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["RelatedFile"].Rows[0]["rlflID"] );
					this.productID = Convert.ToInt32( item.Tables["RelatedFile"].Rows[0]["rlfl_ProductID"] );
					this.name = Convert.ToString( item.Tables["RelatedFile"].Rows[0]["rlflName"] );
					this.description = Convert.ToString( item.Tables["RelatedFile"].Rows[0]["rlflDescription"] );
					this.fileName = Convert.ToString( item.Tables["RelatedFile"].Rows[0]["rlflFileName"] );
					this.fileExtension = Convert.ToString( item.Tables["RelatedFile"].Rows[0]["rlflFileExtension"] );
					this.originalFileName = Convert.ToString( item.Tables["RelatedFile"].Rows[0]["rlflOriginalFileName"] );
					this.special = Convert.ToString( item.Tables["RelatedFile"].Rows[0]["rlflSpecial"] );
					this.order = Convert.ToInt32( item.Tables["RelatedFile"].Rows[0]["rlflOrder"] );
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
		///		Конструктор экземпляра класса BLRelatedFile
		/// </summary>
		public BLRelatedFile()
		{
			FieldInitialization();
		}
		#endregion

	}
//}

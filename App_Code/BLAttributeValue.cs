using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


 
	/// <summary>
	/// Класс BLAttributeValue реализует бизнес-логику значения атрибута.
	/// </summary>
	public class BLAttributeValue
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID значения атрибута
		/// </summary>
		private int id;
		
		/// <summary>
		///		Имя значения атрибута
		/// </summary>
		private string name;

		/// <summary>
		///		Значение
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID значения атрибута
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		Устанавливает и получает имя значения атрибута
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		Устанавливает и получает значение
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
		///		Получает набор всех значений атрибутов
		/// </summary>
		public static DataSet GetList()
		{
			return DALCAttributeValue.GetList();
		}
		
		/// <summary>
		///		Получает значение по ID
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
		///		Получает набор значений атрибута указанного атрибута
		/// </summary>
		public static DataSet GetList(int attributeID)
		{
			DataSet atevList = null;
	
			atevList = DALCAttributeValue.GetList(attributeID);

			return atevList;
		}
		
		/// <summary>
		///		Получает набор значений атрибута по имени
		/// </summary>
		public static DataSet GetList(string name)
		{
			DataSet atevList = null;
	
			atevList = DALCAttributeValue.GetList(name);

			return atevList;
		}

		/// <summary>
		///		Удаляет перечисление атрибута
		/// </summary>
		public static void Delete(int id)
		{
			DALCAttributeValue.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		Удаляет перечисление атрибут
		/// </summary>
		public void Delete()
		{
			DALCAttributeValue.Delete(this.id);
		}

		/// <summary>
		///		Обновляет перечисление атрибута
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCAttributeValue.Update(this.id, this.name, this.avalue);
			this.id = returnValue;
			
			return returnValue;
		}

		/// <summary>
		///		Инициализирует переменные
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.name = string.Empty;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		Получает информацию о перечислении атрибута
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
		///		Инициализирует информацию об атрибуте
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		Конструктор экземпляра класса BLAttributeValue
		/// </summary>
		public BLAttributeValue()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
 

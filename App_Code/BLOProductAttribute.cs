using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// Класс BLOProductAttribute реализует бизнес-логику атрибута продукта ордера.
	/// </summary>
	public class BLOProductAttribute
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID атрибута продукта ордера
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID продукта, к которому принадлежит атрибут продукта ордера
		/// </summary>
		private int orderProductID;

		/// <summary>
		///		Имя атрибута продукта ордера
		/// </summary>
		private string name;

		/// <summary>
		///		Значение атрибута продукта ордера
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID атрибута продукта ордера
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		Устанавливает и получает ID продукта ордера, к которому принадлежит атрибут
		/// </value>
		public int OrderProductID
		{
			get { return orderProductID; }
			set { orderProductID = value; }
		}

		/// <value>
		///		Устанавливает и получает имя атрибута продукта ордера
		/// </value>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <value>
		///		Устанавливает и получает значение атрибута продукта ордера
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
		///		Получает набор всех атрибутов продукта ордера
		/// </summary>
		public static DataSet GetList()
		{
			return DALCOProductAttribute.GetList();
		}

		/// <summary>
		///		Получает набор атрибутов указанного продукта ордера
		/// </summary>
		public static DataSet GetList(int orderProductID)
		{
			DataSet opatList = null;
	
			opatList = DALCOProductAttribute.GetList(orderProductID);

			return opatList;
		}
		
		/// <summary>
		///		Удаляет атрибут продукта ордера
		/// </summary>
		public void Delete(int id)
		{
			DALCOProductAttribute.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		Удаляет атрибут продукта ордера
		/// </summary>
		public void Delete()
		{
			DALCOProductAttribute.Delete(this.id);
		}

		/// <summary>
		///		Обновляет атрибут продукта ордера
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCOProductAttribute.Update(this.id, this.orderProductID, this.name, this.avalue);
			
			return returnValue;
		}

		/// <summary>
		///		Инициализирует переменные
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.orderProductID = 0;
			this.name = string.Empty;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		Получает информацию об атрибуте продукта ордера
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCOProductAttribute.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["OProductAttribute"].Rows[0]["opatID"] );
					this.orderProductID = Convert.ToInt32( item.Tables["OProductAttribute"].Rows[0]["opat_OrderProductID"] );
					this.name = Convert.ToString( item.Tables["OProductAttribute"].Rows[0]["opatName"] );
					this.avalue = Convert.ToString( item.Tables["OProductAttribute"].Rows[0]["opatValue"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		Инициализирует информацию об атрибуте продукта ордера
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		Конструктор экземпляра класса BLOProductAttribute
		/// </summary>
		public BLOProductAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
}

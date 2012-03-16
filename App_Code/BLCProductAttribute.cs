using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// Класс BLCProductAttribute реализует бизнес-логику атрибута продукта покупателя.
	/// </summary>
	public class BLCProductAttribute
	{

		#region Fields

		#region Private Fields

		/// <summary>
		///		ID атрибута продукта покупателя
		/// </summary>
		private int id;
		
		/// <summary>
		///		ID продукта, к которому принадлежит атрибут продукта покупателя
		/// </summary>
		private int cProductID;

		/// <summary>
		///		ID атрибута
		/// </summary>
		private int attributeID;

		/// <summary>
		///		ID перечисления атрибута
		/// </summary>
		private int attributeEnumID;

		/// <summary>
		///		ID значения атрибута
		/// </summary>
		private int attributeValueID;

		/// <summary>
		///		Значение атрибута продукта покупателя
		/// </summary>
		private string avalue;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		/// <value>
		///		Устанавливает и получает ID атрибута продукта покупателя
		/// </value>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <value>
		///		Устанавливает и получает ID продукта покупателя, к которому принадлежит атрибут
		/// </value>
		public int CProductID
		{
			get { return cProductID; }
			set { cProductID = value; }
		}

		/// <value>
		///		Устанавливает и получает ID атрибута
		/// </value>
		public int AttributeID
		{
			get { return attributeID; }
			set { attributeID = value; }
		}

		/// <value>
		///		Устанавливает и получает ID значения атрибута
		/// </value>
		public int AttributeValueID
		{
			get { return attributeValueID; }
			set { attributeValueID = value; }
		}

		/// <value>
		///		Устанавливает и получает значение атрибута продукта покупателя
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
		///		Получает набор всех атрибутов продукта покупателя
		/// </summary>
		public static DataSet GetList()
		{
			return DALCCProductAttribute.GetList();
		}

		/// <summary>
		///		Получает набор атрибутов указанного продукта покупателя
		/// </summary>
		public static DataSet GetList(int cProductID)
		{
			DataSet cpatList = null;
	
			cpatList = DALCCProductAttribute.GetList(cProductID);

			return cpatList;
		}
		
		/// <summary>
		///		Удаляет атрибут продукта покупателя
		/// </summary>
		public void Delete(int id)
		{
			DALCCProductAttribute.Delete(id);
		}

		#endregion

		#region None static methods
		
		/// <summary>
		///		Удаляет атрибут продукта покупателя
		/// </summary>
		public void Delete()
		{
			DALCCProductAttribute.Delete(this.id);
		}

		/// <summary>
		///		Обновляет атрибут продукта покупателя
		/// </summary>
		public int Update()
		{
			int returnValue = -1;
			
			returnValue = DALCCProductAttribute.Update(this.id, this.cProductID, this.attributeID, this.attributeEnumID, this.attributeValueID, this.avalue);
			
			return returnValue;
		}

		/// <summary>
		///		Инициализирует переменные
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.cProductID = 0;
			this.attributeID = 0;
			this.attributeEnumID = 0;
			this.attributeValueID = 0;
			this.avalue = string.Empty;
		}

		/// <summary>
		///		Получает информацию об атрибуте продукта покупателя
		/// </summary>
		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCCProductAttribute.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpatID"] );
					this.cProductID = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpat_CProductID"] );
					this.attributeID = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpat_AttributeID"] );
					this.attributeValueID = Convert.ToInt32( item.Tables["CProductAttribute"].Rows[0]["cpat_AttributeValueID"] );
					this.avalue = Convert.ToString( item.Tables["CProductAttribute"].Rows[0]["cpatValue"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		Инициализирует информацию об атрибуте продукта покупателя
		/// </summary>
		private void Init()
		{
			Retrieve();
		}

		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		Конструктор экземпляра класса BLCProductAttribute
		/// </summary>
		public BLCProductAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

	}
}

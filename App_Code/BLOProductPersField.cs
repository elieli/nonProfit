using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// Класс BLOProductPersField реализует бизнес-логику настраиваемых данных продукта ордера.
	/// </summary>
	public class BLOProductPersField
	{

		#region Fields

		#region Private Fields

		private int id;
		private int orderProductID;
		private string name;
		private string text;
        private bool required;
        private string description;
        private string defaultText;
        private int maxChars;
        private int heightLines;
		private string exampleImageName;

		#endregion

		#endregion
		
		#region Properties

		#region None Static Properties

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public int OrderProductID
		{
			get { return orderProductID; }
			set { orderProductID = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string DefaultText
        {
            get { return defaultText; }
            set { defaultText = value; }
        }

        public int MaxChars
        {
            get { return maxChars; }
            set { maxChars = value; }
        }

        public int HeightLines
        {
            get { return heightLines; }
            set { heightLines = value; }
        }
		
		public string ExampleImageName
		{
			get { return exampleImageName; }
			set { if(value.Length<=250)exampleImageName = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region Static Methods

		public static DataSet GetList()
		{
			return DALCOProductPersField.GetList();
		}

		public static DataSet GetList(int orderProductID)
		{
			return DALCOProductPersField.GetList(orderProductID);
		}
		
		public static void Delete(int id)
		{
			DALCOProductPersField.Delete(id);
		}

        public static int Update(int id, int orderProductID, string name, string text, bool required, string description, string defaultText, int maxChars, int heightLines)
        {
            return DALCOProductPersField.Update(id, orderProductID, name, text, required, description, defaultText, maxChars, heightLines);
        }

		#endregion

		#region None static methods
		
		public void Delete()
		{
			Delete(this.id);
		}

		public int Update()
		{
			this.id = Update(this.id, this.orderProductID, this.name, this.text, this.required, this.description, this.defaultText, this.maxChars, this.heightLines);
			return this.id;
		}

		private void FieldInitialization()
		{
			this.id = 0;
			this.orderProductID = 0;
			this.name = string.Empty;
			this.text = string.Empty;
            this.required = false;
            this.description = string.Empty;
            this.defaultText = string.Empty;
            this.maxChars = 0;
            this.heightLines = 0;
		}

		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCOProductPersField.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
                    DataRow row = item.Tables["OProductPersField"].Rows[0];
					this.id = Convert.ToInt32( row["ID"] );
					this.orderProductID = Convert.ToInt32( row["_OrderProductID"] );
					this.name = Convert.ToString( row["Name"] );
					this.text = Convert.ToString( row["Text"] );
                    this.required = Convert.ToBoolean( row["Required"] );
                    this.description = Convert.ToString( row["Description"] );
                    this.defaultText = Convert.ToString( row["DefaultText"] );
                    this.maxChars = Convert.ToInt32( row["MaxChars"] );
                    this.heightLines = Convert.ToInt32( row["heightLines"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		public string GetExampleImageUrl()
		{
			string url = string.Empty;
			string imageGalleryUrl = System.Configuration.ConfigurationSettings.AppSettings["ImageGallery_URL"];
			url = System.Web.HttpContext.Current.Request.ApplicationPath + imageGalleryUrl + this.exampleImageName;
			url = url.Replace("//", "/");
			return url;
		}
		
		#endregion

		#endregion

		#region Constructors
		
		public BLOProductPersField()
		{
            Retrieve();
		}

        public BLOProductPersField(int id)
        {
            this.id = id;
            Retrieve();
        }

		#endregion

	}
}

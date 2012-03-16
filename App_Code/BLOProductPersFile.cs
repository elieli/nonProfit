using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// Класс BLOProductPersFile реализует бизнес-логику настраиваемых файлов продукта ордера.
	/// </summary>
	public class BLOProductPersFile
	{

		#region Fields

		#region Private Fields

		private int id;
		private int orderProductID;
		private string fileName;
		private string fileExtension;
        private string description;

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

		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

        public string FileExtension
        {
            get { return fileExtension; }
            set { fileExtension = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

		#endregion

		#endregion

		#region Methods

		#region Static Methods

		public static DataSet GetList()
		{
			return DALCOProductPersFile.GetList();
		}

		public static DataSet GetList(int orderProductID)
		{
			return DALCOProductPersFile.GetList(orderProductID);
		}
		
		public static void Delete(int id)
		{
			DALCOProductPersFile.Delete(id);
		}

        public static int Update(int id, int orderProductID, string fileName, string description, HttpPostedFile pf)
        {
            return DALCOProductPersFile.Update(id, orderProductID, fileName, description, pf);
        }

		#endregion

		#region None static methods
		
		public void Delete()
		{
			Delete(this.id);
		}

		public int Update()
		{
			this.id = Update(this.id, this.orderProductID, this.fileName, this.description, null);
			return this.id;
		}

		private void FileInitialization()
		{
			this.id = 0;
			this.orderProductID = 0;
			this.fileName = string.Empty;
			this.fileExtension = string.Empty;
            this.description = string.Empty;
		}

		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCOProductPersFile.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
                    DataRow row = item.Tables["OProductPersFile"].Rows[0];
					this.id = Convert.ToInt32( row["ID"] );
					this.orderProductID = Convert.ToInt32( row["_OrderProductID"] );
					this.fileName = Convert.ToString( row["FileName"] );
					this.fileExtension = Convert.ToString( row["FileExtension"] );
                    this.description = Convert.ToString( row["Description"] );
				}
				else
					FileInitialization();
			}
			else
				FileInitialization();
		}
		
		#endregion

		#endregion

		#region Constructors
		
		public BLOProductPersFile()
		{
            Retrieve();
		}

        public BLOProductPersFile(int id)
        {
            this.id = id;
            Retrieve();
        }

		#endregion

	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;



namespace D3DM.ECom.BusinessLogic
{
	/// <summary>
	/// Класс BLProductPersField реализует бизнес-логику настраиваемых данных продукта.
	/// </summary>
	public class BLProductPersField
	{

		#region Fields

		#region Private Fields

		private int id;
		private int productID;
		private bool enabled;
        private bool required;
		private string name;
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

		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

		public string Name
		{
			get { return name; }
			set { name = value; }
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
			return DALCProductPersField.GetList();
		}

		public static DataSet GetList(int productID)
		{
			DataSet resList = null;
	
			resList = DALCProductPersField.GetList(productID);

			return resList;
		}
		
		public static void Delete(int id)
		{
			DALCProductPersField.Delete(id);
		}

        public static int Update(int id, int productID, bool enabled, bool required, string name, string description, string defaultText, int maxChars, int heightLines)
        {
            return DALCProductPersField.Update(id, productID, enabled, required, name, description, defaultText, maxChars, heightLines);
        }

        public static void CopyToProduct(int productID, int toProductID)
        { 
            DALCProductPersField.CopyToProduct(productID, toProductID);
        }

        public static void DeleteByProduct(int productID)
        { 
            DALCProductPersField.DeleteByProduct(productID);
        }

        public static void MoveToProduct(int productID, int toProductID)
        { 
            DALCProductPersField.DeleteByProduct(toProductID);
            DALCProductPersField.CopyToProduct(productID, toProductID);
            DALCProductPersField.DeleteByProduct(productID);
        }

		public static void UploadExampleImage(int persFieldID, string path, Image image, HttpResponse Response)
		{
			string imageName = Guid.NewGuid().ToString() + ".jpg";

			image = GetThumbnailImage((Bitmap)image, image.Width, image.Height, 640, 480, Response);
			image.Save(path + imageName, ImageFormat.Jpeg);

			DALCProductPersField.UploadExampleImage(persFieldID, imageName);
		}

//		public static void UploadExampleImage(int persFieldID, string path, Image image, bool ifTemporary, HttpResponse Response)
//		{
//			if( ifTemporary )
//				path += "temp/";
//			BLProductPersField.UploadExampleImage(persFieldID, path, image, Response);
//		}

		public static void DeleteExampleImage(int persFieldID, string path)
		{
			if( persFieldID > 0 )
			{
				BLProductPersField field = new BLProductPersField();
				field.ID = persFieldID;
				field.Retrieve();
				field.DeleteExampleImage(path);
			}
		}
		
		protected static Image GetThumbnailImage(Bitmap bitmap,  float width, float height, float maxWidth, float maxHeight, HttpResponse Response)
		{
			System.Drawing.Image g = bitmap;
			System.Drawing.Imaging.ImageFormat thisFormat=g.RawFormat;
  
			//somehow find required image size
			//Size thumbSize = newThumbSize(g.Width, g.Height);
			Resize(ref width, ref height, maxWidth, maxHeight);
			Size thumbSize = new Size((int)width, (int)height);
  
			//Creating blank image as a canvas
			Bitmap imgOutput = new Bitmap(thumbSize.Width,thumbSize.Height);
			
			imgOutput.MakeTransparent();
			imgOutput.MakeTransparent(Color.Black);
			//Create graphics object for alteration
			Graphics newGraphics = Graphics.FromImage(imgOutput); 
			newGraphics.Clear(Color.FromArgb(0, 255, 255, 255)); //blank the image
			//Setting High Quality Transformation
			newGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			newGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			newGraphics.DrawImage(g,0,0,thumbSize.Width,thumbSize.Height);
			newGraphics.Flush();

			return imgOutput;
		}
		
		protected static void Resize(ref float Width, ref float Height, float MaxWidth, float MaxHeight)
		{
			float tmpWidth = Width;
			float tmpHeight = Height;

			float div;

			if(Width >= Height)
			{
				if(Width > MaxWidth)
				{
					tmpWidth = MaxWidth;
					div = Width / Height;
					tmpHeight = tmpWidth / div;
				}
				if(tmpHeight > MaxHeight)
				{
					div = tmpHeight / tmpWidth;
					tmpHeight = MaxHeight;
					tmpWidth = tmpHeight / div ;
				}
			}
			else if(Width < Height)
			{
				if(Height > MaxHeight)
				{
					tmpHeight = MaxHeight;
					div = Height / Width;
					tmpWidth = tmpHeight / div;
				}
				if(tmpWidth > MaxWidth)
				{
					div = tmpWidth / tmpHeight;
					tmpWidth = MaxWidth;
					tmpHeight = tmpWidth / div;
				}
			}
			
			Width = tmpWidth;
			Height = tmpHeight;
		}
	


		#endregion

		#region None static methods
		
		public void Delete()
		{
			Delete(this.id);
		}

		public int Update()
		{
			this.id = Update(this.id, this.productID, this.enabled, this.required, this.name, this.description, this.defaultText, this.maxChars, this.heightLines);
            return this.id;
		}

		private void FieldInitialization()
		{
			this.id = 0;
			this.productID = -1;
			this.enabled = false;
            this.required = false;
			this.name = string.Empty;
			this.description = string.Empty;
            this.defaultText = string.Empty;
            this.maxChars = 0;
            this.heightLines = 0;
			this.exampleImageName = string.Empty;
		}

		public void Retrieve()
		{
			if( this.id > 0 )
			{
				DataSet item = DALCProductPersField.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
                    DataRow row = item.Tables["ProductPersField"].Rows[0];
					this.id = Convert.ToInt32( row["ID"] );
					this.productID = Convert.ToInt32( row["_ProductID"] );
                    this.enabled = Convert.ToBoolean( row["Enabled"] );
                    this.required = Convert.ToBoolean( row["Required"] );
					this.name = Convert.ToString(  row["Name"] );
                    this.description = Convert.ToString(  row["Description"] );
                    this.defaultText = Convert.ToString(  row["DefaultText"] );
					this.maxChars = Convert.ToInt32( row["MaxChars"] );
                    this.heightLines = Convert.ToInt32( row["HeightLines"] );
					this.exampleImageName = Convert.ToString( row["ExampleImageName"] );
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		public void UploadExampleImage(string path, Image image)
		{
            BLProductPersField.UploadExampleImage(this.ID, path, image , null);
		}

		public string GetExampleImageUrl()
		{
			string url = string.Empty;
			string imageGalleryUrl = System.Configuration.ConfigurationSettings.AppSettings["PersonalizationSampleImage_URL"];
			url = System.Web.HttpContext.Current.Request.ApplicationPath + imageGalleryUrl;
//			if( this.ProductID <= 0 )
//				url += "temp/";
			url += this.exampleImageName;
			url = url.Replace("//", "/");
			return url;
		}

		public void DeleteExampleImage(string path)
		{
			if( this.exampleImageName != string.Empty )
			{
				FileInfo imageFile = new FileInfo(path + exampleImageName);
				if( imageFile.Exists )
				{
					GC.Collect();
					imageFile.Delete();
				}
			}
			DALCProductPersField.DeleteExampleImage(this.ID);
		}

		#endregion

		#endregion

		#region Constructors
		
		public BLProductPersField()
		{
            Retrieve();
		}

        public BLProductPersField(int id)
        {
            this.id = id;
            Retrieve();
        }

		#endregion

	}
}

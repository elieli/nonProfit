using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//

//namespace D3DM.ECom.BusinessLogic
//{
	/// <summary>
	/// ����� BLCategory ��������� ������-������ ���������.
	/// </summary>
	public class BLCategory
    {
        Referrer r = new Referrer();
		
		#region Fields

		#region Private Fields
		
		/// <summary>
		///		ID ��������
		/// </summary>
		private int id;

		/// <summary>
		///		ID �������� ���������
		/// </summary>
		private int parentID;

		/// <summary>
		///		������� ���������
		/// </summary>
		private int level;

		/// <summary>
		///		���� � ���������
		/// </summary>
		private string path;

		/// <summary>
		///		��� ���������
		/// </summary>
		private string name;

		/// <summary>
		///		���������� ����� ���������
		/// </summary>
		private int order;

		/// <summary>
		///		����� ���������
		/// </summary>
        private DataSet products;
        
        
        private DataSet categories;

		#endregion

		#endregion
		
		#region Properties
		
		#region None Static Properties

		/// <value>
		///		������������� � �������� ID ���������
		/// </value>
		public int ID
		{
			get{ return id; }
			set{ id = value; }
		}

		/// <value>
		///		������������� � �������� ID ������������ ���������
		/// </value>
		public int ParentID
		{
			get{ return parentID; }
			set{ parentID = value; }
		}

		/// <value>
		///		�������� ������� ���������
		/// </value>
		public int Level
		{
			get{ return level; }
		}

		/// <value>
		///		�������� ���� � ���������
		/// </value>
		public string Path
		{
			get{ return path; }
		}

		/// <value>
		///		������������� � �������� ��� ���������
		/// </value>
		public string Name
		{
			get{ return name; }
			set{ name = value; }
		}

		/// <value>
		///		������������� � �������� ���������� ����� ���������
		/// </value>
		public int Order
		{
			get{ return order; }
			set{ order = value; }
		}

		/// <value>
		///		�������� ����� ���������
		/// </value>
		public DataSet Products
		{
			get
			{
				return products;
			}
		}
        public DataSet Categories
        {
            get
            {
                return categories;
            }
        }






        private DataSet m_Items;

        public DataSet Items
        {
            get
            {
                return m_Items;
            }
            set
            {
                m_Items = value;
            }
        }





		#endregion

		#endregion

		#region Methods

		#region Static Methods
		
		/// <summary>
		///		�������� ����� ���� ���������
		/// </summary>
		public static DataSet GetList()
		{
			DataSet categoryList = DALCCategory.GetList();
			return categoryList;
		}

		/// <summary>
		///		�������� ����� ��������� ��������� ������������ ���������
		/// </summary>
		public static DataSet GetList(int parentID)
		{
			DataSet categoryList = DALCCategory.GetList(parentID);
			return categoryList;
		}

		/// <summary>
		///		�������� ����� ��������� ����
		/// </summary>
		public static DataSet GetPathList(int id)
		{
			DataSet categoryList = DALCCategory.GetPathList(id);
			return categoryList;
		}

		/// <summary>
		///		�������� ����� ���������, � ������� ������������ ��������� �������
		/// </summary>
		public static DataSet GetListByProduct(int productID)
		{
			DataSet categoryList = DALCCategory.GetListByProduct(productID);
			return categoryList;
		}

		/// <summary>
		///		�������� ����� ���������, � ������� ������������ ��������� ������� ����������� �������
		/// </summary>
		public static DataSet GetListByProduct(int productID, string special)
		{
			DataSet categoryList = DALCCategory.GetListByProduct(productID, special);
			return categoryList;
		}

		/// <summary>
		///		��������� ���������� � ���������
		/// </summary>
		public static int Update(int id, int parentID, string name, int order)
		{
			int returnValue = 0;

			returnValue = DALCCategory.Update(id, parentID, name, order);
			
			return returnValue;
		}

		/// <summary>
		///		������� ���������
		/// </summary>
		public static int Delete(int id)
		{
			int returnValue = 0;
			returnValue = DALCCategory.Delete(id);
			return returnValue;
		}

		/// <summary>
		///		�������� ��������� � ������
		/// </summary>
		public static void ChangeOrderUp(int id)
		{
			DALCCategory.ChangeOrder(id, true);
		}

		/// <summary>
		///		�������� ��������� � ������
		/// </summary>
		public static void ChangeOrderDown(int id)
		{
			DALCCategory.ChangeOrder(id, false);
		}







        public  DataSet GetCatList(ref  BLCustomer cust, String parm, string commandtext,   int catid, string status)
        {
            /// BLItems Itemss = new BLItems();

           /// BLCustomer cust = (BLCustomer)messages.cust;



            DataSet ds = new DataSet();

            switch (parm)
            {
                case "S":

                    ds = cust.Organization.Category.Items;

                    break;

                case "I":

                    //  ds = cust.Organization.Orgitems.ItemsGeneralSearch;

                    ds = cust.Organization.Category.Items;
                    break;


                case "A":

                   // ds = cust.Organization.Orgitems.categories;

                    break;


                case "R":

                    // ds = cust.Organization.Orgitems.categories;

                    break;
                    /// cust.Organization.Orgitems.UpdateDonate("I", "get_Items", 0, orgid, catid, status);


                  
            }

            ds = cust.Organization.Category.UpdateDonate(parm, commandtext, catid, status);

            return ds;

        }

		#endregion

		#region None static Methods

		/// <summary>
		///		��������� ���������� � ���������
		/// </summary>
		public int Update()
		{
			int returnValue = 0;

			returnValue = Update(this.id, this.parentID, this.name, this.order);
			
			return returnValue;
		}
		
		/// <summary>
		///		������� ���������
		/// </summary>
		public int Delete()
		{
			int returnValue = 0;
			returnValue = Delete(this.id);
			return returnValue;
		}

		/// <summary>
		///		�������������� ����������
		/// </summary>
		private void FieldInitialization()
		{
			this.id = 0;
			this.parentID = 0;
			this.name = string.Empty;
			this.order = 0;
			this.products = null;
		}

		/// <summary>
		///		�������� ���������� � ���������
		/// </summary>
		public void Retrieve()
		{
			if( this.id >= 0 )
			{
				DataSet item = DALCCategory.GetItem(this.id);
				if( item.Tables.Count > 0 && item.Tables[0].Rows.Count > 0)
				{
					this.id = Convert.ToInt32( item.Tables["Category"].Rows[0]["catID"] );
					this.parentID = Convert.ToInt32( item.Tables["Category"].Rows[0]["cat_ParentID"] );
					this.level = Convert.ToInt32( item.Tables["Category"].Rows[0]["catLevel"] );
					this.path = Convert.ToString( item.Tables["Category"].Rows[0]["catPath"] );
					this.name = Convert.ToString( item.Tables["Category"].Rows[0]["catName"] );
					this.order = Convert.ToInt32( item.Tables["Category"].Rows[0]["catOrder"] );
					//this.products = DALCProduct.GetList(this.id, false);
				}
				else
					FieldInitialization();
			}
			else
				FieldInitialization();
		}
		
		/// <summary>
		///		�������������� ���������� � ���������
		/// </summary>
		private void Init()
		{
			Retrieve();
		}









        protected DataSet UpdateDonate(String parm, string commandtext, int id, string status)
        {
            
         
            String orgTitle = "";
                  

            String orgStatus = status;

            orgStatus = status;

            
            String prm = parm;

            status = "";

            DataSet ds = new DataSet();
          

            string commandText = commandtext;




            if (prm == "R")
            {
                orgStatus = "";

                ds = r.getCats(commandText,
             prm,
             id,
          orgTitle
         );



            }
            else
            {
                r.setCats(commandText,
                         prm,
                         id,
                      orgTitle
                 );
                orgStatus = "";// drplstEmailSts.SelectedValue.ToString();
                ds = r.getCats(commandText,
              prm,
              id,
           orgTitle
          );
                

            };



            return ds;
            


         



        }



		#endregion

		#endregion

		#region Constructors
		
		/// <summary>
		///		����������� ���������� ������ BLCategory
		/// </summary>
		public BLCategory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		#endregion

	}
//}

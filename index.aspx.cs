using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Collections.Specialized;
using System.Configuration;
using Lib;
//using D3DM.ECom.BusinessLogic;


namespace Shof 
{
	/// <summary>
	/// Summary description for index.
	/// </summary>
	public partial class index : System.Web.UI.Page  
	{ 

        protected System.Web.UI.HtmlControls.HtmlTableCell  tdLeftBordur;
        protected System.Web.UI.HtmlControls.HtmlTableCell tdBotFooter;
        protected System.Web.UI.HtmlControls.HtmlForm Form2;
        protected System.Web.UI.HtmlControls.HtmlTableCell  tblCenter;
        protected System.Web.UI.HtmlControls.HtmlImage  imgLefCorner;
        ////protected PlaceHolder CenterPlaceHolder;
        ////protected PlaceHolder CategoryListPlaceHolder;
        ////protected PlaceHolder CategoryPathPlaceHolder;




        protected void Page_Load(object sender, System.EventArgs e)
        { 
         PlaceHolder  CLPLH =   new PlaceHolder() ; //CenterPlaceHolder
            PlaceHolder CPLH = new PlaceHolder()   ;// CategoryListPlaceHolder;
            PlaceHolder CPPLH = new PlaceHolder(); //CategoryPathPlaceHolder;
         
			goto nx;
			if (Request.Cookies["forum"] == null)
			{
				string QStr;

				if(Request.QueryString.HasKeys())
					QStr = Request.Url.Query;
				else
					QStr = "";
				
				Response.Redirect("/registration/login.asp?page=protected&pagesreturn=/catalog/index.aspx" + Server.UrlEncode(QStr),true);
			}
			if(Request.Cookies["customer_uid"] == null)
			{
				this.customer_uid = Session.SessionID;
				HttpCookie cookieCustomerUId = new HttpCookie("customer_uid", this.customer_uid);
				cookieCustomerUId.Expires = System.DateTime.Today.AddMonths(1); 
				Response.Cookies.Add(cookieCustomerUId);
			}
			else
			{
				try
				{
					if (Request.Cookies["forum"]["shID"] != null)
						this.customer_uid = Request.Cookies["forum"]["shID"];
					else
						//this.customer_uid = Request.Cookies["customer_uid"].Value;
						Response.Redirect("/registration/login.asp?page=protected&pagesreturn=/catalog/index.aspx" + Server.UrlEncode(Request.Url.Query),true);
				}
				catch
				{
					this.customer_uid = Request.Cookies["customer_uid"].Value;
				}
			}
nx:
			customer = new BLCustomer();
			customer.UID = this.customer_uid;
			customer.Retrieve();
			//            }
			if customer.ID <= 0)
			{
				customer.UID = this.customer_uid;
				customer.Update();
				customer.Retrieve();
			}

			NameValueCollection queryString = Page.Request.QueryString;
			this.selPage = queryString.Get("page");

			XmlDocument configXml = new XmlDocument();
			configXml.Load(MapPath(PATH_TO_CONFIG));

			XmlElement pageConf = (XmlElement)configXml.DocumentElement.GetElementsByTagName("pageconfig")[0];
			XmlElement tmpEl = (XmlElement)pageConf.SelectSingleNode("(//page)[@code='"+this.selPage+"']");

			if(tmpEl == null)
			{
				this.selPage = "home";
				tmpEl = (XmlElement)pageConf.SelectSingleNode("(//page)[@code='"+this.selPage+"']");
			}
			
			XmlNodeList tmpList = tmpEl.ChildNodes;
			int cnt = tmpList.Count;
			for(int i = 0; i < cnt; i++)
			{
				tmpEl = (XmlElement) tmpList[i];
				switch ( tmpEl.Name)
				{
					case "title" : title = tmpEl.InnerText; break;
					case "module" : centerModuleUrl = tmpEl.InnerText; break;
					case "javascript" : javascript = tmpEl.InnerText; break;
					case "login" : login = tmpEl.InnerText; break;
					case "leftmenuoff" : leftMenuOff = tmpEl.InnerText == "yes"; break;
				}
			}
			
			string search;
			search = this.Request.Form["txtSearch"];
			if( search == null )
				try
				{	
					search = this.ViewState["searchParam"].ToString();	}
				catch{}

			if( search != null )
				this.ViewState["searchParam"] = search;

			this.navPage = this.selPage;
			if (leftMenuOff)
			{
				//tdLeftMenu.Visible = false;
				//tblCenter.Width = "556";
				imgLefCorner.Src = "../downloads/img/corner_r31.gif";
				imgLefCorner.Width = 152;
				tdLeftBordur.Visible = true;
			}
	 //	CenterPlaceHolder
            CPLH.Controls.Add(LoadControl(centerModuleUrl));
			if (!leftMenuOff)
			//	CategoryListPlaceHolder
                    CLPLH.Controls.Add(LoadControl("category_list.ascx"));
Trace.Write("in index Page_Load");
			//CategoryPathPlaceHolder
                CPPLH.Controls.Add(LoadControl("category_path.ascx"));
		}

		public string title;
		public string javascript;
		public string centerModuleUrl;
		public bool leftMenuOff = false;
		public string login="";
		public string searchWord="";

		private string customer_uid;

		public string selPage;
		public string navPage;

		public string SearchParameter
		{
			get
			{
				try
				{
					return this.ViewState["searchParam"].ToString();
				}
				catch
				{
					return null;
				}
			}
			set
			{
				this.ViewState["searchParam"] = value;
			}
		}

		public BLShoppingCart shoppingCart;
		public BLUser user;
		public BLCustomer customer;

		public StateBag PublicViewState
		{
			get
			{
				return this.ViewState;
			}
		}

		public static string PATH_TO_CONFIG = (string)ConfigurationSettings.AppSettings.Get("pathToConfig");
		public static string PATH_TO_CMS_XML = (string)ConfigurationSettings.AppSettings.Get("pathToCmsXml");
   
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load +=new EventHandler(Page_Load);
		}
		#endregion
	}
}

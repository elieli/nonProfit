namespace Shof.modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using System.Collections.Specialized;

	//using D3DM.ECom.BusinessLogic;

	/// <summary>
	///		Summary description for catnav.
	/// </summary>
	public partial class category_list : System.Web.UI.UserControl
    {
        BLCustomer cust;
		protected int categoryID, reqCatId;
		protected int categoryChildID;
		DataSet dsCategory;
		DataSet dsCategory2;

		protected string SearchParameter
		{
			get
			{
                //////if( (cust.SearchParameter != null )
                //////    return ((index)this.Page).SearchParameter;
				return "Catalog Search ";
			}
		}
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
			NameValueCollection queryString = Page.Request.QueryString;
			try
			{
				this.categoryID = System.Convert.ToInt32(queryString.Get("idc"));
				reqCatId = System.Convert.ToInt32(queryString.Get("idc"));
			}
			catch{}

			rptCategoryList_Bind();
		}

		private void rptCategoryList_Bind()
		{
			dsCategory = BLCategory.GetList(this.categoryID);
			if (this.categoryID==0)
			{
				rptCategoryList.DataSource = dsCategory.Tables["Category"];
				rptCategoryList.DataBind();
			}
			else
			{
				BLCategory category = new BLCategory();
				category.ID = this.categoryID;
				category.Retrieve();
				dsCategory2 = BLCategory.GetList(category.ParentID);

				if (category.ParentID>0 && dsCategory.Tables["Category"].Rows.Count==0)
				{
					dsCategory = dsCategory2;

					BLCategory category2 = new BLCategory();
					category2.ID = category.ParentID;
					category2.Retrieve();
					dsCategory2 = BLCategory.GetList(category2.ParentID);

					this.categoryChildID = this.categoryID;
					this.categoryID = category.ParentID;

                    rptCategoryList.DataSource = dsCategory2.Tables["Category"];
					rptCategoryList.DataBind();
				}
				else
				{
                    rptCategoryList.DataSource = dsCategory2.Tables["Category"];
					rptCategoryList.DataBind();
				}
			}
		}

		protected void rptCategoryList_OnItemDataBound(object sender, RepeaterItemEventArgs e) 
		{
			switch(e.Item.ItemType)	
			{
				case ListItemType.Item:
				case ListItemType.AlternatingItem:
					Repeater rptCategoryList2 = (Repeater) e.Item.FindControl("rptCategoryList2");
					HtmlAnchor aCat = (HtmlAnchor) e.Item.FindControl("aCat");
					HtmlTableRow main_tr = (HtmlTableRow) e.Item.FindControl("main_tr");
					int currCatId = (int)((DataRowView)e.Item.DataItem)["catID"];

					if( currCatId == categoryID )
					{
						main_tr.BgColor = "#BAD0DC";
						aCat.Attributes["class"] = "LeftMenuL1A";
					}
					else
						aCat.Attributes["class"] = "LeftMenuL1";
					
					if( currCatId == reqCatId )
						main_tr.BgColor="#FFFFFF";

//					aCat.Attributes["class"]=(categoryID.ToString()==((DataRowView)e.Item.DataItem)["catID"].ToString())?"LeftMenuL1A":"LeftMenuL1";
					aCat.InnerText = ((DataRowView)e.Item.DataItem)["catName"].ToString();
					aCat.HRef = ".?page=list&id=8&idc="+((DataRowView)e.Item.DataItem)["catID"].ToString();

					if (Convert.ToInt32(((DataRowView)e.Item.DataItem)["catID"].ToString())==this.categoryID)
					{
						rptCategoryList2.DataSource = dsCategory.Tables["Category"];
						rptCategoryList2.DataBind();
					}

					break;
			}
		}

		protected void rptCategoryList2_OnItemDataBound(object sender, RepeaterItemEventArgs e) 
		{
			switch(e.Item.ItemType)	
			{
				case ListItemType.Item:
				case ListItemType.AlternatingItem:
					
					HtmlAnchor aCat2 = (HtmlAnchor) e.Item.FindControl("aCat2");
					HtmlTableRow main_tr = (HtmlTableRow) e.Item.FindControl("main_tr");
					int currCatId = (int)((DataRowView)e.Item.DataItem)["catID"];
					
					main_tr.BgColor="#BAD0DC";
					if (Convert.ToInt32(((DataRowView)e.Item.DataItem)["catID"].ToString())==reqCatId)
						main_tr.BgColor="#FFFFFF";

					aCat2.Attributes["class"]=(categoryChildID == currCatId)?"LeftMenuL2A":"LeftMenuL2";

					aCat2.InnerText = " - " + ((DataRowView)e.Item.DataItem)["catName"].ToString();
					aCat2.HRef = ".?page=list&id=8&idc="+((DataRowView)e.Item.DataItem)["catID"].ToString();

					break;
			}
		}

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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion


	

		
	}
}

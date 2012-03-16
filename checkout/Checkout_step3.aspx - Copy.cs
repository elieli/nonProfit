/*  
'=====================================================
' Project:      JomaDeals.com
' Programmer:   Derek Souers
' File:         Checkout_step3.aspx
' Description:  
' Created:		07/30/09
' Last Updated: 10/16/09
'
'=====================================================
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using MainStreet.BusinessFlow.SDK;
using MainStreet.BusinessFlow.SDK.Web;
using MainStreet.BusinessFlow.SDK.Ws;


public partial class checkout_Checkout_step3 : System.Web.UI.Page
{
    private int m_orderId = 0;
    private Guid m_orderGuid;
    protected string Output = "";

    #region "Properties"
    /// <summary>
    /// Gets or Sets the Order ID for display.
    /// </summary>
    /// <remarks>
    /// By default this control will load this property from an order_id QueryString parameter. 
    /// </remarks>
    public int OrderId
    {
        get { return m_orderId; }
        set { m_orderId = value; }
    }


    /// <summary>
    /// Gets or Sets the Order GUID for use when linking to the order detail page.
    /// </summary>
    /// <remarks>
    /// By default this control will load this property from an order_guid QuesryString parameter. 
    /// </remarks>
    public Guid OrderGuid
    {
        get { return m_orderGuid; }
        set { m_orderGuid = value; }
    }
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        //Validate
        OrderId = PrgFunctions.TryCastInt(Request["order_id"], OrderId);
        OrderGuid = PrgFunctions.TryCastGuid(Request["order_guid"], OrderGuid);

        OrderDetail oDetail = null;

        if (OrderGuid != Guid.Empty)
        {
            try
            {
                oDetail = BusinessFlow.WebServices.Order.GetDetail(OrderGuid);
            }
            catch (Exception)
            {
                Response.Redirect(ResolveUrl("~/checkout/checkout_step2.aspx"));
            }
        }
        else if ((OrderId.ToString().Length > 2))
        {
            try
            {
                oDetail = BusinessFlow.WebServices.Order.GetDetail(OrderId.ToString());
            }
            catch (Exception)
            {
                Response.Redirect(ResolveUrl("~/checkout/checkout_step2.aspx"));
            }
        }
        else
        {
            Response.Redirect(ResolveUrl("~/checkout/checkout_step2.aspx"));
        }

        if ((oDetail == null) || (oDetail.OrderRow == null))
            Response.Redirect(ResolveUrl("~/checkout/checkout_step2.aspx"));

        //Save the IP
        PrgFunctions f = new PrgFunctions((MainStreet.BusinessFlow.SDK.Web.BusinessFlowWebContext)BusinessFlow.Context);
        string ip = f.GetIP();
        f.UpdateOrderAttribute(PrgFunctions.TryCastGuid(oDetail.OrderRow["order_guid"]), "IpAddress", ip);

        //Save the referer
        if ((Session != null) && (Session["UrlReferer"] != null) && (Session["UrlReferer"].ToString().Length!=0))
        {
            f.UpdateOrderAttribute(PrgFunctions.TryCastGuid(oDetail.OrderRow["order_guid"]), "UrlReferer", Session["UrlReferer"].ToString());
        }

        //Google Analytics
        string jsCode = buildGAJavaScript(oDetail);
	
	/* Valentin fixed we use google analitic in control
        if (jsCode.Length > 5)
        {
            HtmlGenericControl hgc2 = new HtmlGenericControl("script");
            hgc2.Attributes.Add("language", "javascript");
            hgc2.Attributes.Add("type", "text/javascript");
            hgc2.InnerHtml = jsCode;
            Page.Header.Controls.Add(hgc2);

            jsCode = string.Empty;
        }
	 */
	 jsCode = string.Empty;
	
        //Nextopia
        jsCode = buildNXTJavaScript(oDetail);

        if (jsCode.Length > 5)
        {
            HtmlGenericControl hgc3 = new HtmlGenericControl("script");
            hgc3.Attributes.Add("language", "javascript");
            hgc3.Attributes.Add("type", "text/javascript");
            hgc3.InnerHtml = jsCode;
            Page.Header.Controls.Add(hgc3);
        }

        //Commision Junction
        jsCode = buildCommissionJunctionScript(oDetail);

        if (jsCode.Length > 5)
        {
            Output = jsCode;
        }
    }


    private string buildCommissionJunctionScript(OrderDetail od)
    {
        string enterpriseId = "1513615";
        string actionId = "329243";

        string jsCode = @"<img src=""https://www.emjcd.com/u?CID=" + enterpriseId +
            "&OID=InvoiceID-" + od.OrderRow.order_id.ToString() +
            "&TYPE=" + actionId;

        int count = 0;

        //ITEM1=3 214sku&AMT1=13.49&QTY1
        foreach (DataRow dr in od.OrderItems)
        {
            jsCode += "&ITEM" + (count + 1).ToString() + "=" + dr["item_cd"].ToString() +
                "&AMT" + (count + 1).ToString() + "=" + PrgFunctions.TryCastDouble(dr["item_wholesale_price"]).ToString() +
                "&QTY" + (count + 1).ToString() + "=" + PrgFunctions.TryCastInt(dr["order_item_quantity"], 1).ToString();
            count++;
        }

	 jsCode += "&DISCOUNT=" + od.OrderRow.order_discount.ToString();

        jsCode += "&CURRENCY=USD" +
            @"&METHOD=IMG"" height=""1"" width=""20"">";

        if (count != 0)
            return jsCode;

        return "";
    }


    private string buildGAJavaScript(OrderDetail od)
    {
        try
        {
            string jsCode = "";

            Functions.WebForms f = new Functions.WebForms();
            string googleAnalyticsAccountName = f.GetAppSettings("googleAnalyticsAccountName");
            string googleId = f.GetAppSettings("googleAnalyticsId");

            if (googleAnalyticsAccountName.Length != 0)
            {

                jsCode = "var pageTracker = _gat._getTracker('" + googleId + "'); pageTracker._trackPageview();";

                //TODO: Specific identifiers should be move to app.config
                jsCode = jsCode + "pageTracker._addTrans('" + od.OrderRow.order_id.ToString() + "', '" + googleAnalyticsAccountName + "', '" + PrgFunctions.TryCastDouble(od.OrderRow.order_total).ToString() + "', '" + PrgFunctions.TryCastDouble(od.OrderRow.order_tax).ToString() + "', '" + PrgFunctions.TryCastDouble(od.OrderRow.order_shipping).ToString() + "', '" + od.OrderRow.order_ship_city.ToString() + "', '" + od.OrderRow.order_ship_state_name.ToString() + "', '" + od.OrderRow.order_ship_country_name.ToString() + "' ); ";

                foreach (DataRow dr in od.OrderItems.Rows)
                {
                    jsCode = jsCode + "pageTracker._addItem('" + od.OrderRow.order_id.ToString() + " ', '" + dr["item_cd"].ToString() + "', '" + dr["order_item_description"].ToString() + "', 'Products', '" + PrgFunctions.TryCastDouble(dr["item_wholesale_price"]).ToString() + "', '" + dr["order_item_quantity"].ToString() + "'); ";
                }

                jsCode = jsCode + "pageTracker._trackTrans();";
            }
            return jsCode;
        }
        catch
        {
            return "";
        }
    }


    private string buildNXTJavaScript(OrderDetail od)
    {
        try
        {
            string jsCode = "";
            string strData = "";

            Functions.WebForms f = new Functions.WebForms();
            string nextopiaAccountName = f.GetAppSettings("nextopiaAccountName");
            string nextopiaId = f.GetAppSettings("nextopiaId");

            jsCode = "function nxtsubmit_purchase() {";
            jsCode = jsCode + "var nxturl = 'https://analytics.nextopia.net/p.php';";
            jsCode = jsCode + "var nxty = '" + nextopiaId + "';";
            jsCode = jsCode + "var nxtz = '1';";
            jsCode = jsCode + "info = new Image(1,1);";

            strData = od.OrderRow.order_id.ToString() + "|" + nextopiaAccountName + "|" + PrgFunctions.TryCastDouble(od.OrderRow.order_total).ToString() + "|" + PrgFunctions.TryCastDouble(od.OrderRow.order_tax).ToString() + "|" + PrgFunctions.TryCastDouble(od.OrderRow.order_shipping).ToString() + "|" + od.OrderRow.order_ship_city.ToString() + "|" + od.OrderRow.order_ship_state_name.ToString() + "|" + od.OrderRow.order_ship_country_name.ToString() + "\\n";

            foreach (DataRow dr in od.OrderItems.Rows)
            {
                strData = strData + od.OrderRow.order_id.ToString() + "|" + dr["item_cd"].ToString() + "|" + dr["order_item_description"].ToString() + "|Products|" + PrgFunctions.TryCastDouble(dr["item_wholesale_price"]).ToString() + "|" + dr["order_item_quantity"].ToString() + "\\n";
            }

            jsCode = jsCode + "info.src = nxturl + '?y=' + nxty + '&z=' + nxtz + '&x=' + escape('" + strData + "');}nxtsubmit_purchase();";

            return jsCode;
        }
        catch
        {
            return "";
        }
    }
}

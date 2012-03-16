using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Login
/// </summary>
public class Logins
{
	 
		 
    private static string m_password;
    public static string password
    {
        get
        {
            return m_password;
        }
        set { m_password = value; }
    }



    private static string m_userid;
    public static string userid
    {
        get
        {
            return m_userid;
        }
        set { m_userid = value; }
    }
 
 
}

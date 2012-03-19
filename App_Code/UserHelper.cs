using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for UserHelper
/// </summary>
public class UserHelper
{
    public static void SetCookieForUser(string userId, BLCustomer customer)
    {
        FormsAuthentication.SetAuthCookie(userId, false);
        CurrentCustomer = customer;
    }

    public static BLCustomer GetCurrentCustomer()
    {
        var identity = HttpContext.Current.User.Identity;
        if (!identity.IsAuthenticated)
            return null;

        if (CurrentCustomer == null)
        {
            var userId = identity.Name;
            CurrentCustomer = GetCustomerInfoByUserId(userId);
        }

        return CurrentCustomer;
    }

    private static BLCustomer GetCustomerInfoByUserId(string userId)
    {
        // TODO: add logic to get data from database
        return null;
    }

    private static BLCustomer CurrentCustomer
    {
        get { return System.Web.HttpContext.Current.Session["cust"] as BLCustomer; }
        set { System.Web.HttpContext.Current.Session["cust"] = value;  }
    }


}
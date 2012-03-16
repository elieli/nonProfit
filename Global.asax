 
<%@ Application Language="C#" %>

<script RunAt="server">
    
    private static string[] SQLKeywords = new string[]
{
"EXEC", "SELECT", "INSERT", "UPDATE", "DELETE",
"CAST", "DECLARE", "NVARCHAR", "VARCHAR"
};

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        
        

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }
    /// <summary>
    /// This is added from http://www.west-wind.com/weblog/posts/447503.aspx
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        if (context != null)
        {
            string queryString =
            context.Request.ServerVariables["QUERY_STRING"];
            if (string.IsNullOrEmpty(queryString) == false)
            {
                if (queryString.Length > 500)
                    throw new Exception(string.Format("Unexpected 'QUERY_STRING' length ({0}).", queryString));


                queryString = Server.UrlDecode(queryString);

                queryString =
                queryString.Replace(" ", string.Empty).ToUpper();


                foreach (string keyword in SQLKeywords)
                {
                    if (queryString.IndexOf(keyword) != (-1))
                        throw new Exception(string.Format("Unexpected T-SQL keyword ('{0}') has been detected ({1})", keyword, queryString));
                }
            }
        }
    }





    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>


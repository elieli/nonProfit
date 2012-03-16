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
using System.Data.SqlClient;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
public static class  SqlHelper
{
    //public   SqlHelper()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public  static int ExecuteScalar (String cmd ,String str, System.Data.SqlClient.SqlParameter[] Paramaters)    
{
        int   vlu=0;
        return vlu;
}



    public static DataSet ExecuteDataset(string StoredProcedure1, String str1, System.Data.SqlClient.SqlParameter id1 , System.Data.SqlClient.SqlParameter id2 ,System.Data.SqlClient.SqlParameter id3 )
    {
        DataSet ds = new DataSet();

        return ds;
    }


    public static DataSet ExecuteDataset(string StoredProcedure1b, String str1b, System.Data.SqlClient.SqlParameter id1b, System.Data.SqlClient.SqlParameter id2b, System.Data.SqlClient.SqlParameter id3b, System.Data.SqlClient.SqlParameter id3bb)
    {
        DataSet ds = new DataSet();

        return ds;
    }

    
    public static DataSet ExecuteDataset(string StoredProcedure1a, String str1a, System.Data.SqlClient.SqlParameter id1a , System.Data.SqlClient.SqlParameter id2a  )
    {
        DataSet ds = new DataSet();

        return ds;
    }




    public static DataSet ExecuteDataset(string StoredProcedure, String str, System.Data.SqlClient.SqlParameter id)
    {
        DataSet ds = new DataSet();

        return ds;
    }


    public static DataSet ExecuteDataset(string Str1, String str2i,int inti)
    {
        DataSet ds = new DataSet();

        return ds;
    }
    public static DataSet ExecuteDataset(string Str1, String str2)
    {
        DataSet ds = new DataSet();

        return ds;
    }

    public static int  ExecuteNonQuery(string StoredProcedure, String str, System.Data.SqlClient.SqlParameter id)
    {
        return 0;
 
    }
    public static void ExecuteNonQuery(string StoredProcedures, String strs, System.Data.SqlClient.SqlParameter[] ids)
    {

    }
    public static void ExecuteNonQuery(string StoredProcedure, String str, System.Data.SqlClient.SqlParameter id, System.Data.SqlClient.SqlParameter idd)
    {

    }


    public static void ExecuteNonQuery(string Strnq1, String strnq2, System.Data.SqlClient.SqlParameter id, System.Data.SqlClient.SqlParameter idd,System.Data.SqlClient.SqlParameter idd1 )
    {

    }


    public static void ExecuteNonQuery(string Strnq1a, String strnq2a, System.Data.SqlClient.SqlParameter ida, System.Data.SqlClient.SqlParameter idda, System.Data.SqlClient.SqlParameter idd1a, System.Data.SqlClient.SqlParameter idd1b)
    { }
}

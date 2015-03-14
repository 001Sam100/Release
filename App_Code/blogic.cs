using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Net.Mail;
using System.Web.Mail;
using System.Configuration;

/// <summary>
/// Summary description for blogic
/// </summary>
public class blogic : CRMSQLHelper
{
    DataSet ds = new DataSet();
    SqlDataReader dr;
    public DataSet login_employee(string proc,string vt,string emailid, string pwd)
    {
        try
        {
            SqlParameter sp1=new SqlParameter("@email",emailid);
            SqlParameter sp2 = new SqlParameter("@pwd", pwd);
            ds = ExecuteDataset(proc, new SqlParameter[] {sp1, sp2}, vt);
            return ds;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public SqlDataReader forgot_mail(string proc, string emailid)
    {
        try
        {
            SqlParameter sp1 = new SqlParameter("@email", emailid);
            dr = ExecuteReader(proc, new SqlParameter[] { sp1 });
            return dr;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public int change_password(string proc, string emailid, string pwd)
    {
        try
        {
            SqlParameter sp1 = new SqlParameter("@email", emailid);
            SqlParameter sp2 = new SqlParameter("@pwd", pwd);
            int i = ExecuteNonQuery(proc, new SqlParameter[] { sp1, sp2 });
            return i;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

	public blogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
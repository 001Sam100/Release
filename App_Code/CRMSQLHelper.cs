using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for CRMSQLHelper
/// </summary>
public class CRMSQLHelper
{
	public CRMSQLHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SqlConnection connection()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cultlogin"].ConnectionString);
        return con;
    }
    public DataSet ExecuteDataset(string proc, SqlParameter[] parameters, string virtualtable)
    {
        if (proc != null)
        {
            SqlConnection mycon = connection();
            SqlCommand mycmd = new SqlCommand(proc, mycon);
            mycmd.CommandType = CommandType.StoredProcedure;
            DataSet myds = new DataSet();
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters)
                {
                    mycmd.Parameters.Add(param);
                }
            }
            SqlDataAdapter mysda = new SqlDataAdapter(mycmd);
            mysda.Fill(myds, virtualtable);
            if (mycon.State == ConnectionState.Open)
            {
                mycon.Close();

            }
            return myds;

        }
        else
        {
            return null;
        }

    }
    public int ExecuteNonQuery(string proc, SqlParameter[] parameters)
    {
        int IsSuccess = 0;
        try
        {

            if (proc != null)
            {
                SqlConnection mycon = connection();
                SqlCommand mycmd = new SqlCommand(proc, mycon);
                mycmd.CommandType = CommandType.StoredProcedure;
                mycon.Close();
                mycon.Open();
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {

                        mycmd.Parameters.Add(param);
                    }
                }
                int roweffected = mycmd.ExecuteNonQuery();
                if (mycon.State == ConnectionState.Open)
                {
                    mycon.Close();
                }
                if (roweffected > 0)
                {
                    IsSuccess = 1;
                    return IsSuccess;
                }
                else
                {
                    IsSuccess = 0;
                    return IsSuccess;
                }

            }
            else
            {
                IsSuccess = 0;
                return IsSuccess;
            }
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                IsSuccess = 2;

            }
            return IsSuccess;
        }
        catch (Exception ex)
        {
            string str = ex.Message;
            return 0;
        }
    }

    public SqlDataReader ExecuteReader(string ProcedureName, SqlParameter[] Parameters)
    {
        if (ProcedureName != "")
        {
            SqlConnection mycon = connection();
            SqlCommand mycmd = new SqlCommand(ProcedureName, mycon);
            mycmd.CommandType = CommandType.StoredProcedure;
            mycon.Close();
            mycon.Open();
            if (Parameters != null)
            {
                foreach (SqlParameter para in Parameters)
                {
                    mycmd.Parameters.Add(para);
                }
            }
            SqlDataReader mydr = mycmd.ExecuteReader(CommandBehavior.CloseConnection);


            return mydr;
        }
        else
        {
            return null;
        }
    }

    public string ExecuteNonQueryOutput(string proc, string outsqlvar, SqlParameter[] parameters)
    {
        string issuccess = "";
        try
        {
            if (proc != null)
            {
                SqlConnection mycon = connection();
                SqlCommand mycmd = new SqlCommand(proc, mycon);
                mycmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sp = mycmd.Parameters.Add(outsqlvar, SqlDbType.NVarChar, 100);
                sp.Direction = ParameterDirection.Output;
                mycon.Close();
                mycon.Open();
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {

                        mycmd.Parameters.Add(param);
                    }
                }
                int roweffected = mycmd.ExecuteNonQuery();

                if (roweffected > 0)
                {
                    issuccess = sp.Value.ToString();
                }
                else
                {
                    issuccess = "Insertion Failed";
                }
                return issuccess;

            }
            else
            {
                issuccess = "Insertion Failed";
                return issuccess;
            }
        }
        catch (SqlException Ex)
        {
            if (Ex.Number == 2627)
            {
                issuccess = "Duplicate Entry";
            }
            return issuccess;
        }
        catch (Exception)
        {

            issuccess = "Insertion Failed";
            return issuccess;
        }
    }
    public int ExecuteNonQueryOutputInt(string proc, string outsqlvar, SqlParameter[] parameters)
    {
        try
        {
            if (proc != null)
            {
                SqlConnection mycon = connection();
                SqlCommand mycmd = new SqlCommand(proc, mycon);
                mycmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sp = mycmd.Parameters.Add(outsqlvar, SqlDbType.Int);
                sp.Direction = ParameterDirection.Output;
                mycon.Close();
                mycon.Open();
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {

                        mycmd.Parameters.Add(param);
                    }
                }
                mycmd.ExecuteNonQuery();
                int temp = Convert.ToInt32(sp.Value.ToString());
                return temp;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            string st = ex.Message;
            return 0;

        }

    }
    public DataSet ReturnDataset(string proc, string VirtualTable)
    {

        if (proc != null)
        {
            SqlConnection mycon = connection();
            SqlCommand mycmd = new SqlCommand(proc, mycon);
            mycmd.CommandType = CommandType.StoredProcedure;
            DataSet myds = new DataSet();
            SqlDataAdapter mysda = new SqlDataAdapter(mycmd);
            mysda.Fill(myds, VirtualTable);
            if (mycon.State == ConnectionState.Open)
            {
                mycon.Close();

            }
            return myds;

        }
        else
        {
            return null;
        }
    }
    public int ExecuteNonQueryWithoutParmeter(string proc)
    {
        int IsSuccess = 0;
        try
        {

            if (proc != null)
            {
                SqlConnection mycon = connection();
                SqlCommand mycmd = new SqlCommand(proc, mycon);
                mycmd.CommandType = CommandType.StoredProcedure;
                mycon.Close();
                mycon.Open();

                int roweffected = mycmd.ExecuteNonQuery();
                if (roweffected > 0)
                {
                    IsSuccess = 1;
                    return IsSuccess;
                }
                else
                {
                    IsSuccess = 0;
                    return IsSuccess;
                }

            }
            else
            {
                IsSuccess = 0;
                return IsSuccess;
            }
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                IsSuccess = 2;

            }
            return IsSuccess;
        }
        catch (Exception ex)
        {
            string str = ex.Message;
            return 0;
        }
    }
}
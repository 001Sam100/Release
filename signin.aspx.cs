using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class signin : System.Web.UI.Page
{
    blogic bl = new blogic();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bntsign_Click(object sender, EventArgs e)
    {
        string email = txtmail.Text;
        string pwd = txtpass.Text;
        if (email != null && pwd !=null)
        {
           ds= bl.login_employee("employlogin", "vt", email, pwd);
           if (ds.Tables[0].Rows.Count > 0)
           {
               Session["emp_name"] = ds.Tables[0].Rows[0]["email"].ToString();
               lblsuccess.Text = "<script>alert('Login success')</script>";
           }
           else
           {
               lblsuccess.Text = "<script>alert('Email id or password is not valid')</script>";
           }
        }
        else
        {
            lblsuccess.Text = "<script>alert('Please fill email id or password')</script>";
        }
    }
}
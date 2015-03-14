using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class change_password : System.Web.UI.Page
{
    blogic bl = new blogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(Request.QueryString["EmailId"]))
        {
            lblmail.Text = Request.QueryString["EmailId"];
        }
    }
    protected void bntchange_Click(object sender, EventArgs e)
    {
        string email = lblmail.Text;
        string password = txtpass.Text;
        if (email != null && password != null)
        {
            int i = bl.change_password("change_password", email, password);
            if (i > 0)
            {
                Response.Redirect("index.aspx");
            }
        }
        else
        {
            lblchangesuccess.Text = "<script>alert('Please fill password')</script>";
        }
    }
}
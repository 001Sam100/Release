using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class forgot_password : System.Web.UI.Page
{
    blogic bl = new blogic();
    DataSet ds = new DataSet();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string email = Request.Form["txtforgotmail"];
            if (email != null)
            {
                dr = bl.forgot_mail("forgot", email);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string password = dr["pwd"].ToString();
                        string ActivationURL = Server.HtmlEncode("http://localhost:10582/Login/change_password.aspx?EmailId=" + email);
                        string body = "Hi!<br> Thanks for showing interest and change password in <a href='http://www.culttechnology.com'>culttechnology.com<a><br> " +
                  "Please <a href='" + ActivationURL + "'>click here </a> to reset your password and enjoy our services.<br>Thanks!";
                        int i = SendLoginDetails(email, "Forgot Password", body);
                        if (i > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Email send Successfully');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Server error');", true);
                        }
                    }
                }
                else
                {

                    Label1.Text = "Sorry! Email Id doesn't exist";//"<script>alert('Sorry! Email Id doesn't exist')</script>";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Sorry! Email Id doesn't exist');", true);
                }
            }
            else
            {
                Label1.Text = "Blank field aren't allowed";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Blank field aren't allowed');", true);
            }

        }
    }

    public int SendLoginDetails(string email, string subject, string query)
    {
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(email);
            MailMessage mMailMessage = new MailMessage();
            mMailMessage.To.Add(new MailAddress("shailesh.1920@gmail.com"));
            mail.From = new MailAddress("shailesh.1920@gmail.com");

            mail.Subject = "Change Password";
            mail.Body = query;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("shailesh.1920@gmail.com", "ur gmail pwd");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            string str = ex.Message;
            return 0;
        }
    }
}
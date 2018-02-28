using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = TextBox2.Text;
            string pass = TextBox3.Text;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ToString();
            con.Open();
            string selectString = " SELECT COUNT(*) FROM [Users] where ([UserName] =@tags) AND ([Password]= @Text)";
            OleDbCommand cmd = new OleDbCommand(selectString, con);



            cmd.Parameters.AddWithValue("@tags", user);

            cmd.Parameters.AddWithValue("@Text", pass);
            cmd.Connection = con;
            int a =(int) cmd.ExecuteScalar();

            if(a==1)
            {
                MessageBox.Show("login successful");
                Response.Redirect("Admin.aspx");

            }

            else { MessageBox.Show("Try again your password or username is incorrect"); }


        }
    }
}
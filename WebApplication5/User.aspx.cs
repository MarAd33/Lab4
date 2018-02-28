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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fname = TextBox1.Text;
            string lname = TextBox4.Text;
            string eid = TextBox2.Text;
            string ph = TextBox3.Text;
            string rvalue = RadioButtonList1.SelectedItem.Value.ToString();
            MessageBox.Show(rvalue);
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ToString();
            con.Open();
            string selectString = "insert into [Users](FirstName,LastName,Gender,PhoneNumber,EmailAddr)values(@na,@pr,@quan,@ph,@em)";

            OleDbCommand cmd = new OleDbCommand(selectString, con);
            //MessageBox.Show(DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@na", fname);
            cmd.Parameters.AddWithValue("@pr", lname);
            cmd.Parameters.AddWithValue("@quan", rvalue);
            cmd.Parameters.AddWithValue("@ph", ph);
            cmd.Parameters.AddWithValue("@em", eid);

            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show(a.ToString());
        }
    }
}
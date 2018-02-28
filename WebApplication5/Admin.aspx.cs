using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication5
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String nm = TextBox1.Text.ToString();
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ToString();
            con.Open();
            string selectString = " SELECT FirstName,LastName,Gender,PhoneNumber,EmailAddr FROM [Users] where ([FirstName] like '%'+ @tags + '%') AND ([LastName] like '%'+ @Text + '%')";
            OleDbCommand cmd = new OleDbCommand(selectString, con);
            

            
            cmd.Parameters.AddWithValue("@tags", TextBox1.Text);
            
            cmd.Parameters.AddWithValue("@Text", TextBox2.Text);
         

            cmd.Connection = con;
            foreach (DataGridViewColumn column in GridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridView1.AutoGenerateColumns = true;

            DataTable results = new DataTable();
            GridView1.AutoGenerateColumns = true;


            results.Load(cmd.ExecuteReader());
            GridView1.DataSource = results;
            GridView1.DataBind();
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MessageBox.Show(dr[0].ToString());

            }

        }
    }
}
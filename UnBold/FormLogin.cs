using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UnBold
{
    public partial class FormLogin : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public FormLogin()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=HARKULAS\SQLEXPRESS;Initial Catalog=AP76001;Integrated Security=True";
        }
        private void txtUserEnter(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals("USERNAME / EMAIL"))
            {
                txtUserName.Text = "";
            }

        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals(""))
            {
                txtUserName.Text = "USERNAME / EMAIL";
            }
        }

        private void txtPasswordEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("PASSWORD"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPasswordLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = "PASSWORD";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM dbo.Users";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                if (txtUserName.Text.Equals(dr["Login_Name"].ToString()) && txtPassword.Text.Equals(dr["Password"].ToString()))
                {
                    //MessageBox.Show("Login Done","Congratulation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //this.Hide();
                    Dashboard ds = new Dashboard();
                    ds.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Your Username Or Passowrd Is Wrong , Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            con.Close();
        }
    }
}

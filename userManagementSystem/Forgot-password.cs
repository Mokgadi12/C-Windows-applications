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

namespace userManagementSystem
{
    public partial class Forgot_password : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=sqlserver.dynamicdna.co.za;Initial Catalog=User-Management-System-Mokgadi;User ID=BBD;Password=123");
        public Forgot_password()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            login lf = new login();
            lf.Show();
            this.Hide();
        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register rf = new register();
            rf.Show();
            this.Hide();
        }

        private void showpasswordBtn_Click(object sender, EventArgs e)
        {
            if (emailtxb.Text.Length > 0)
            {
                
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SELECT Password FROM Customer WHERE Email = '"+emailtxb.Text+"'",con);

                    dr = com.ExecuteReader();
                
                    while (dr.Read())
                    {
                        MessageBox.Show("Your password is : " + dr ["Password"].ToString());
                    }
                    con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("failed to connect to Database!");
                }
               
            }
            else
                MessageBox.Show("Email is required to retrive password ");
        }
    }
}

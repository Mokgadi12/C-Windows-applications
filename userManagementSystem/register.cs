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
    public partial class register : Form
    {
        SqlConnection con = new SqlConnection("Data Source=sqlserver.dynamicdna.co.za;Initial Catalog=User-Management-System-Mokgadi;User ID=BBD;Password=123");
        public register()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login lf = new login();
            lf.Show();
            this.Hide();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (fullnametxb.Text.Length > 0 && emailtxb.Text.Length > 0 && passwordtxb.Text.Length > 0)
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO Customer VALUES ('"+fullnametxb.Text+"','"+emailtxb.Text+"','"+passwordtxb.Text+"')", con);
                    try
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("Sucessfully registered");
                        fullnametxb.Clear();
                        emailtxb.Clear();
                        passwordtxb.Clear();

                 

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Failed to register, contact system Admin.");
                    }
                    con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Failed to connect to database.");
                }
            }
            else
                MessageBox.Show("All fields are required!");
       
        }
    }
}

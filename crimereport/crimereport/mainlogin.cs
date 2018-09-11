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
using System.Text.RegularExpressions;

namespace crimereport
{
    public partial class mainlogin : Form
    {
        public mainlogin()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label1.Text = "";
            label2.Text="";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (check==false)
            {
                string pattern = "^[a-zA-Z0-9 ]*";

                if (Regex.IsMatch(txtpass.Text, pattern))
                {
                    txtpass.BackColor = Color.Green;
                    check = true;
                }
                else
                {
                    MessageBox.Show("Password");
                    txtpass.BackColor = Color.Red;
                }

            }
            if(check==true)
            {
                string connectionString = @"Data Source=.;Initial Catalog=CrimeReport;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM usr WHERE username='" + txtname.Text + "' AND userpass='" + txtpass.Text + "'", con);
                    /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                    DataTable dt = new DataTable(); //this is creating a virtual table  
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        new front().Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            label2.Text = "Enter Your password";
            label2.Visible = true;
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            label1.Text = "Enter Your Name";
            label1.Visible = true;
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            label1.Visible = false;

        }

        private void txtname_OnValueChanged(object sender, EventArgs e)
        {
            string pattern = "^[a-zA-Z ]*$";

            if (Regex.IsMatch(txtname.Text, pattern))
            {
                txtname.BackColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Please ALPHABET A to Z or a-z");
                txtname.BackColor = Color.Red;
            }
        }

        private void txtpass_OnValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

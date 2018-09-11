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
    public partial class front : Form
    {
        public front()
        {
            InitializeComponent();
            this.ActiveControl = mainpanel;
            Searchpanel.Visible = false;
            addadminpanel.Visible = false;
            Welcomepanel.Visible = true;
            Insertdatapanel.Visible = false;
            viewdatapanel.Visible = false;
            viewadminpanel.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Searchpanel.Visible = false;
            addadminpanel.Visible = true;
            Welcomepanel.Visible = false;
            Insertdatapanel.Visible = false;
            viewdatapanel.Visible = false;
            viewadminpanel.Visible = false;

        }

        private void bunifuMetroTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                string connectionString = @"Data Source=.;Initial Catalog=CrimeReport;Integrated Security=True";
                using (SqlConnection con=new SqlConnection(connectionString))
                {
                    bool check = false;
                    con.Open();
                    string query = @"select * from crime where cityname like '%"+searchbar.Text+"%';";
                    SqlCommand com = new SqlCommand(query,con);
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read() == true)
                    {
                        int i = rdr.GetInt32(rdr.GetOrdinal("id"));
                        string cityname = rdr.GetString(1);
                        string people = rdr.GetString(2);
                        string prosec = rdr.GetString(3);
                        string murder = rdr.GetString(4);
                        string amurder = rdr.GetString(5);
                        string Robary = rdr.GetString(6);
                        string kransom = rdr.GetString(7);
                        string kabduction = rdr.GetString(8);
                        string Rape = rdr.GetString(9);
                        string grape = rdr.GetString(10);
                        string MIsc = rdr.GetString(11);
                        CitynameLbl.Text = cityname;
                        Populationlbl.Text = people;
                        proseclbl.Text = prosec;
                        murderlbl.Text = murder;
                        AttemptedMurderlbl.Text = amurder;
                        Robarylbl.Text = Robary;
                        KidnapingRansomlbl.Text = kransom;
                        Kidnapingabduction.Text = kabduction;
                        Rapelbl.Text = Rape;
                        GANGRAPE.Text = grape;
                        LNSLAW.Text = MIsc;
                        float totalfirs = (Convert.ToInt64(prosec)) + (Convert.ToInt64(murder)) + (Convert.ToInt64(amurder)) + (Convert.ToInt64(Robary)) + (Convert.ToInt64(kransom)) + (Convert.ToInt64(kabduction)) + (Convert.ToInt64(Rape)) + (Convert.ToInt64(grape)) + (Convert.ToInt64(MIsc));
                        TotalFirslbl.Text = totalfirs.ToString();
                        float population = Convert.ToInt64(people);

                        float crimeRate = (totalfirs / population) * 100;
                        crimeratelbl.Text = crimeRate.ToString();
                        check = true;
                    }
                    con.Close();
                    if (check)
                    {
                        Searchpanel.Visible = true;
                        Welcomepanel.Visible = false;
                        addadminpanel.Visible = false;
                        Insertdatapanel.Visible = false;
                        viewdatapanel.Visible = false;
                        viewadminpanel.Visible = false;
                        check = false;
                    }
                    else
                    {
                        MessageBox.Show("Record Not found");
                        check = false;
                    }
                }
                
            }
        }

        private void searchbar_Enter(object sender, EventArgs e)
        {
            searchbar.Text = "";
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            txtusername.Text = "";
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            txtpassword.Text = "";
        }

        private void txtaddress_Enter(object sender, EventArgs e)
        {
            txtaddress.Text = "";
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            txtemail.Text = "";
        }

        private void txtcinc_Enter(object sender, EventArgs e)
        {
            txtcinc.Text = "";
        }

        private void adduserbtn_Click(object sender, EventArgs e)
        {
            bool validated = false;
            if (txtusername.Text=="" || txtusername.Text == "User Name")
            {
                txtusername.Focus();
                MessageBox.Show("Enter your Name");
            }
            else
            {
                if (Regex.IsMatch(txtusername.Text,"^[A-Za-z ]{3,15}$"))
                {
                    if (txtpassword.Text=="" || txtpassword.Text == "Password")
                    {
                        MessageBox.Show("empty password");
                    }
                    else
                    {
                        if (Regex.IsMatch(txtpassword.Text,"^[a-zA-Z0-9 ]{7,20}$"))
                        {
                            if (txtaddress.Text == "" || txtaddress.Text == "Address")
                            {
                                MessageBox.Show("Enter Address");
                            }
                            else
                            {
                                if (!validated)
                                {
                                    if (txtemail.Text == "" || txtemail.Text == "Email")
                                    {
                                        MessageBox.Show("Enter your Email");
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(txtemail.Text, "^[a-zA-Z0-9_]*[@][a-zA-Z]{3,8}[.][a-zA-Z]{3}$"))
                                        {
                                            if (txtcinc.Text == ""|| txtcinc.Text == "CNIC")
                                            {
                                                MessageBox.Show("Enter your CNIC");
                                            }
                                            else
                                            {
                                                if (Regex.IsMatch(txtcinc.Text, "^[0-9]{5}[-][0-9]{7}[-][0-9]$"))
                                                {
                                                    validated = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Enter Your Cnic LIKE 12345-1234567-1");
                                                    validated = false;
                                                    txtcinc.Focus();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Enter Your Email LIKE ABCD123_@gmail.com");
                                            validated = false;
                                            txtemail.Focus();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Address Should be in between 7 to 50");
                                    validated = false;
                                    txtaddress.Focus();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password Should be in between 7 to 20");
                            validated = false;
                            txtpassword.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User Name Should be Alphabet");
                    txtusername.Focus();
                    validated = false;
                }
            }
            if (validated)
            {
                MessageBox.Show("Validation Done");
                string name = txtusername.Text;
                string password = txtpassword.Text;
                string address = txtaddress.Text;
                string email = txtemail.Text;
                string cnic = txtcinc.Text;

                string connectionString = @"Data Source=.;Initial Catalog=CrimeReport;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string checkquery = "select * from usr where cnic ='"+txtcinc.Text+"';";
                    SqlCommand cmd = new SqlCommand(checkquery, con);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read() == true)
                    {
                        MessageBox.Show("Record already exist");
                        string choice = MessageBox.Show("Do yOu want To Update record..?", "update record", MessageBoxButtons.YesNo).ToString();
                        if (choice == "Yes")
                        {
                            reader1.Close();
                            string updatequery = @"UPDATE usr SET username = '"+txtusername.Text+ "',userpass='" + txtpassword.Text+ "', useradd= '" +txtaddress.Text+ "', email='" + txtemail.Text + "' WHERE cnic ='"+txtcinc.Text+"';";
                            SqlCommand updatecommand = new SqlCommand(updatequery, con);
                            int updaterecord = updatecommand.ExecuteNonQuery();
                            if (updaterecord != 0)
                            {
                                MessageBox.Show("Your Record has been updated");
                            }

                        }
                    }
                    else
                    {
                        reader1.Close();
                        string query = @"INSERT INTO usr(username,userpass,useradd,email,cnic)
VALUES ('" + name + "', '" + password + "','" + address + "', '" + email + "','" + cnic + "' );";
                        SqlCommand com = new SqlCommand(query, con);
                        int record = com.ExecuteNonQuery();
                        if (record != 0)
                        {
                            MessageBox.Show(record + "Data Added");
                        }
                    }

                    txtusername.Text = "User Name";
                    txtpassword.Text = "Password";
                    txtaddress.Text = "Address";
                    txtemail.Text = "Email";
                    txtcinc.Text = "CNIC";
                    con.Close();
                }
            }
        }

        private void Murderfr_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void CityName_Enter(object sender, EventArgs e)
        {
            CityName.Text = "";
        }

        private void population_Enter(object sender, EventArgs e)
        {
            population.Text = "";
        }

        private void Prosecutionfir_Enter(object sender, EventArgs e)
        {
            Prosecutionfir.Text = "";
        }

        private void Murderfr_Enter(object sender, EventArgs e)
        {
            Murderfr.Text = "";
        }

        private void attemptmurderfir_Enter(object sender, EventArgs e)
        {
            attemptmurderfir.Text = "";
        }

        private void robaryfir_Enter(object sender, EventArgs e)
        {
            robaryfir.Text = "";
        }

        private void rapefir_Enter(object sender, EventArgs e)
        {
            rapefir.Text = "";
        }

        private void gangrapesfirs_Enter(object sender, EventArgs e)
        {
            gangrapesfirs.Text = "";
        }

        private void kidnappingabdutionfirs_Enter(object sender, EventArgs e)
        {
            kidnappingabdutionfirs.Text = "";
        }

        private void kidnappingrensomfirs_Enter(object sender, EventArgs e)
        {
            kidnappingrensomfirs.Text = "";
        }

        private void LnLfirs_Enter(object sender, EventArgs e)
        {
            LnLfirs.Text = "";
        }

        private void Insertdatabtn_Click(object sender, EventArgs e)
        {
            bool validated = false;
            if (CityName.Text == "" || CityName.Text == "City Name")
            {
                MessageBox.Show("Enter City Name");
            }
            else
            {
                if (Regex.IsMatch(CityName.Text, "^[a-zA-Z  ]*$"))
                {
                    if (population.Text == "" || population.Text == "Enter Population")
                    {
                        MessageBox.Show("Enter Population city");
                    }
                    else
                    {
                        if (Regex.IsMatch(population.Text, "^[0-9]*$"))
                        {
                            if (Prosecutionfir.Text == "" || Prosecutionfir.Text == "Prosecution Fir's")
                            {
                                MessageBox.Show("Enter prosecution Fir");
                            }
                            else
                            {
                                if (Regex.IsMatch(Prosecutionfir.Text, "^[0-9]*$"))
                                {
                                    if (Murderfr.Text == "" || Murderfr.Text == "Murder Fir's")
                                    {
                                        MessageBox.Show("Enter Murder fir's");
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(Murderfr.Text, "^[0-9]*$"))
                                        {
                                            if (attemptmurderfir.Text == "" || attemptmurderfir.Text == "Attempmurder Fir's")
                                            {
                                                MessageBox.Show("Enter Attempmurder fir's");
                                            }
                                            else
                                            {
                                                if (Regex.IsMatch(attemptmurderfir.Text, "^[0-9]*$"))
                                                {
                                                    if (robaryfir.Text == "" || robaryfir.Text == "robary Fir's")
                                                    {
                                                        MessageBox.Show("Enter robary fir's");
                                                    }
                                                    else
                                                    {
                                                        if (Regex.IsMatch(robaryfir.Text, "^[0-9]*$"))
                                                        {
                                                            if (rapefir.Text == "" || rapefir.Text == "Rape Fir's")
                                                            {
                                                                MessageBox.Show("Enter rape fir's");
                                                            }
                                                            else
                                                            {
                                                                if (Regex.IsMatch(rapefir.Text, "^[0-9]*$"))
                                                                {
                                                                    if (gangrapesfirs.Text == "" || gangrapesfirs.Text == "Gang Rape Fir's")
                                                                    {
                                                                        MessageBox.Show("Enter gangrape fir's");
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Regex.IsMatch(gangrapesfirs.Text, "^[0-9]*$"))
                                                                        {
                                                                            if (kidnappingabdutionfirs.Text == "" || kidnappingabdutionfirs.Text == "Kidnapping Abduction Fir's")
                                                                            {
                                                                                MessageBox.Show("Enter Kidnapping Abduction fir's");
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Regex.IsMatch(kidnappingabdutionfirs.Text, "^[0-9]*$"))
                                                                                {
                                                                                    if (kidnappingrensomfirs.Text == "" || kidnappingrensomfirs.Text == "kidnappingrensom")
                                                                                    {
                                                                                        MessageBox.Show("Enter kidnapping rensom fir's");
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Regex.IsMatch(kidnappingrensomfirs.Text, "^[0-9]*$"))
                                                                                        {
                                                                                            if (LnLfirs.Text == "" || LnLfirs.Text == "Local and Law's Fir's")
                                                                                            {
                                                                                                MessageBox.Show("Enter Local and Law's Fir's");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (Regex.IsMatch(LnLfirs.Text, "^[0-9]*$"))
                                                                                                {
                                                                                                    validated = true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    MessageBox.Show(" should be Numbers");
                                                                                                    validated = false;
                                                                                                    LnLfirs.Focus();
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            MessageBox.Show(" should be Numbers");
                                                                                            validated = false;
                                                                                            kidnappingrensomfirs.Focus();
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    MessageBox.Show(" should be Numbers");
                                                                                    validated = false;
                                                                                    kidnappingabdutionfirs.Focus();
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show(" should be Numbers");
                                                                            validated = false;
                                                                            gangrapesfirs.Focus();
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show(" should be Numbers");
                                                                    validated = false;
                                                                    rapefir.Focus();
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show(" should be Numbers");
                                                            validated = false;
                                                            robaryfir.Focus();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show(" should be Numbers");
                                                    validated = false;
                                                    attemptmurderfir.Focus();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(" should be Numbers");
                                            validated = false;
                                            Murderfr.Focus();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(" should be Numbers");
                                    validated = false;
                                    Prosecutionfir.Focus();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Population should be Numbers");
                            validated = false;
                            population.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter City Name  in Alphabets");
                    validated = false;
                    CityName.Focus();
                }
            }
            if (validated)
            {
                string connectionstring = @"Data Source=.;Initial Catalog=CrimeReport;Integrated Security=True";
                using (SqlConnection con=new SqlConnection(connectionstring))
                {
                    con.Open();
                    
                    string checkquery = "select cityname from crime where cityname like '%"+CityName.Text+"%';";
                    SqlCommand cmd = new SqlCommand(checkquery, con);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read() == true)
                    {
                        MessageBox.Show("Record already exist");
                        string choice=MessageBox.Show("Do yOu want To Update record..?","update record",MessageBoxButtons.YesNo).ToString();
                        if (choice == "Yes")
                        {
                            reader1.Close();
                            string updatequery = @"UPDATE crime SET people = '" + population.Text + "', prosecutionfir = '" + Prosecutionfir.Text + "', Murderfir = '" + Murderfr.Text + "', attemptedmurderfirs = '" + attemptmurderfir.Text + "', hurtfirs = '" + robaryfir.Text + "', kidnapingRansomfirs = '" + kidnappingrensomfirs.Text + "', kidnapingabductionfirs = '" + kidnappingabdutionfirs.Text + "', RapeFirs = '" + rapefir.Text + "', Gangrapefirs = '" + gangrapesfirs.Text + "', others = '" + LnLfirs.Text + "' WHERE cityname like '%" + CityName.Text + "%';";
                            SqlCommand updatecommand = new SqlCommand(updatequery, con);
                            int updaterecord = updatecommand.ExecuteNonQuery();
                            if (updaterecord != 0)
                            {
                                MessageBox.Show("Your Record has been updated");
                            }

                        }
                    }
                    else
                    {
                        reader1.Close();
                        string query = "INSERT INTO crime(cityname,people,prosecutionfir,Murderfir,attemptedmurderfirs,hurtfirs,kidnapingRansomfirs,kidnapingabductionfirs,RapeFirs,Gangrapefirs,others) VALUES('" + CityName.Text + "','" + population.Text + "','" + Prosecutionfir.Text + "','" + Murderfr.Text + "','" + attemptmurderfir.Text + "','" + robaryfir.Text + "','" + kidnappingrensomfirs.Text + "','" + kidnappingabdutionfirs.Text + "','" + rapefir.Text + "','" + gangrapesfirs.Text + "','" + LnLfirs.Text + "');";
                        CityName.Text = "City Name";
                        population.Text = "City Population";
                        Prosecutionfir.Text = "prosecution Fir's";
                        Murderfr.Text = "Murder Fir's";
                        attemptmurderfir.Text = "Attemted mUrder Fir's";
                        robaryfir.Text = "Robary Fir's";
                        rapefir.Text = "rape Fir's";
                        gangrapesfirs.Text = "gang rape Fir's";
                        kidnappingrensomfirs.Text = "kidnappinf rensom Fir's";
                        kidnappingabdutionfirs.Text = "kidnaping abduction Fir's";
                        LnLfirs.Text = "Laws and Local Fir's";
                        SqlCommand com = new SqlCommand(query, con);
                        int record = com.ExecuteNonQuery();
                        if (record != 0)
                        {
                            MessageBox.Show(record + "Data Added");
                        }
                    }
                    con.Close();
                }
            }
        }

        private void insertdata(object sender, EventArgs e)
        {
            viewadminpanel.Visible = false;
            Searchpanel.Visible = false;
            addadminpanel.Visible = false;
            Welcomepanel.Visible = false;
            Insertdatapanel.Visible = true;
            viewdatapanel.Visible = false;
        }

        private void front_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crimeReportDataSet1.crime' table. You can move, or remove it, as needed.
            this.crimeTableAdapter.Fill(this.crimeReportDataSet1.crime);

        }

        private void ViewDatabtn(object sender, EventArgs e)
        {
            viewadminpanel.Visible = false;
            Searchpanel.Visible = false;
            addadminpanel.Visible = false;
            Welcomepanel.Visible = false;
            Insertdatapanel.Visible = false;
            viewdatapanel.Visible = true;
            string connectionString = @"Data Source=.;Initial Catalog=CrimeReport;Integrated Security=True"; ;
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                con.Open();
                string query = "select * from crime";
                SqlDataAdapter sda = new SqlDataAdapter(query,con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void ViewAdmins(object sender, EventArgs e)
        {
            Searchpanel.Visible = false;
            addadminpanel.Visible = false;
            Welcomepanel.Visible = true;
            Insertdatapanel.Visible = false;
            viewdatapanel.Visible = false;
            viewadminpanel.Visible = true;
            string connectionString = @"Data Source=.;Initial Catalog=CrimeReport;Integrated Security=True"; ;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "select * from usr";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

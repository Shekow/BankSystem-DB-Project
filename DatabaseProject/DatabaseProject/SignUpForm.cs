using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class SignUpForm : Form
    {
        DatabaseProject.DBAccess dbAccess = new DatabaseProject.DBAccess();
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String FirstName = txtFirstName.Text;
            String SecondName = txtSecondName.Text;
            String LastName = txtLastName.Text;
            String SSN = txtSSN.Text;
            String Password = txtPassword.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);
            String Type = comboType.Text;
            SqlCommand cmd = new SqlCommand("INSERT INTO [User] VALUES(@SSN, @FirstName, @SecondName, @LastName, @BuildingNumber, @Street, @City, @Country, @Password, @Type)");
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Street", Street);
            cmd.Parameters.AddWithValue("@BuildingNumber", BuildingNumber);
            cmd.Parameters.AddWithValue("@Type", Type);

            int row = dbAccess.executeQuery(cmd);
            if (row == 1)
            {
                MessageBox.Show("Account created successfully");
                this.Hide();
                HomePage homePage = new HomePage();
                homePage.Show();
            }
            else
            {
                MessageBox.Show("Error: something went wrong");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginPage = new Login();
            loginPage.Show();
        }
    }
}

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
            String MiddleName = txtMiddleName.Text;
            String LastName = txtLastName.Text;
            String SSN = txtSSN.Text;
            String Password = txtPassword.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);
            String Type = comboType.Text;
            SqlCommand cmd;
            if (Type == "Customer")
            {
                cmd =
               new SqlCommand
               ("INSERT INTO Customer VALUES(@SSN, @FirstName, " +
               "@MiddleName, @LastName, @BuildingNumber, @Street, @City, @Country, @Password)");
            }
            else
            {
                cmd =
               new SqlCommand
               ("INSERT INTO Employee VALUES(@SSN, @FirstName, " +
               "@MiddleName, @LastName, @BuildingNumber, @Street, @City, @Country, @Password, @Admin)");
            }

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Street", Street);
            cmd.Parameters.AddWithValue("@BuildingNumber", BuildingNumber);
            if (Type == "Admin") { cmd.Parameters.AddWithValue("@Admin", "True"); }
            else { cmd.Parameters.AddWithValue("@Admin", "False"); }

            int row = dbAccess.executeQuery(cmd);
            if (row == 1)
            {
                HomePage.user.SSN = SSN;
                HomePage.user.FirstName = FirstName;
                HomePage.user.MiddleName = MiddleName;
                HomePage.user.LastName = LastName;
                HomePage.user.Password = Password;
                HomePage.user.BuildingNumber = BuildingNumber;
                HomePage.user.Street = Street;
                HomePage.user.City = City;
                HomePage.user.Country = Country;
                HomePage.user.Type = Type;
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

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
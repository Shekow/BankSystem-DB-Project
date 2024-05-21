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
    public partial class UpdateUserForm : Form
    {
        DatabaseProject.DBAccess dbAccess = new DatabaseProject.DBAccess();
        public UpdateUserForm()
        {
            InitializeComponent();
        }

        private void UpdateUserForm_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = HomePage.user.FirstName;
            txtMiddleName.Text = HomePage.user.MiddleName;
            txtLastName.Text = HomePage.user.LastName;
            txtPhone.Text = HomePage.user.Phone;
            txtPassword.Text = HomePage.user.Password;
            txtBuildingNumber.Text = HomePage.user.BuildingNumber.ToString();
            txtStreet.Text = HomePage.user.Street;
            txtCity.Text = HomePage.user.City;
            txtCountry.Text = HomePage.user.Country;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String FirstName = txtFirstName.Text;
            String MiddleName = txtMiddleName.Text;
            String LastName = txtLastName.Text;
            String Password = txtPassword.Text;
            String Phone = txtPhone.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);
            String query = $"UPDATE [{(HomePage.user.Type == "Customer" ? "Customer" : "Employee")}] SET " +
                $"FirstName = '{FirstName}', " +
                $"MiddleName = '{MiddleName}', " +
                $"LastName = '{LastName}', " +
                $"Password = '{Password}', " +
                $"Phone = '{Phone}', " +
                $"BuildingNumber = {BuildingNumber}, " +
                $"Street = '{Street}', " +
                $"City = '{City}', " +
                $"Country = '{Country}' " +
                $"WHERE SSN = '{HomePage.user.SSN}'";
            SqlCommand cmd = new SqlCommand(query);
            int changes;
            try
            {
                changes = dbAccess.executeQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some data is missing/invalid");
                return;
            }
            if (changes == 1)
            {
                HomePage.user.FirstName = FirstName;
                HomePage.user.MiddleName = MiddleName;
                HomePage.user.LastName = LastName;
                HomePage.user.Password = Password;
                HomePage.user.Phone = Phone;
                HomePage.user.BuildingNumber = BuildingNumber;
                HomePage.user.Street = Street;
                HomePage.user.City = City;
                HomePage.user.Country = Country;
                MessageBox.Show("Information updated successfully");
                this.Hide();
                if (HomePage.user.Type == "Customer")
                {
                    CustomerHomePage customerHomePage = new CustomerHomePage();
                    customerHomePage.Show();
                }
                else if (HomePage.user.Type == "Employee")
                {
                    EmployeeHP emplyeeHomePage = new EmployeeHP();
                    emplyeeHomePage.Show();
                }
                else
                {
                    AdminHP adminHomePage = new AdminHP();
                    adminHomePage.Show();
                }
            }
            else
            {
                MessageBox.Show("Error: something went wrong");
            }
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (HomePage.user.Type != "Admin")
            {
                MessageBox.Show("Sorry, You can't delete your account");
                return;
            }
            
            DialogResult result = MessageBox.Show("Are you sure?", "Delete account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;
            String query = $"DELETE FROM [Employee] WHERE [SSN] = '{HomePage.user.SSN}' AND [Admin] = 'True'"; ;
            
            SqlCommand cmd = new SqlCommand(query);
            int changes = dbAccess.executeQuery(cmd);
            if (changes == 1)
            {
                MessageBox.Show("Account deleted successfully");
                HomePage homePage = new HomePage();
                this.Hide();
                homePage.Show();
            }
            else
            {
                MessageBox.Show("Error: something went wrong");
            }
        }
    }
}

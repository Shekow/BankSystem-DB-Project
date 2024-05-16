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
            txtSecondName.Text = HomePage.user.SecondName;
            txtLastName.Text = HomePage.user.LastName;
            txtPassword.Text = HomePage.user.Password;
            txtBuildingNumber.Text = HomePage.user.BuildingNumber.ToString();
            txtStreet.Text = HomePage.user.Street;
            txtCity.Text = HomePage.user.City;
            txtCountry.Text = HomePage.user.Country;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String FirstName = txtFirstName.Text;
            String SecondName = txtSecondName.Text;
            String LastName = txtLastName.Text;
            String Password = txtPassword.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);
            String query = $"UPDATE [User] SET " +
                $"FirstName = '{FirstName}', " +
                $"SecondName = '{SecondName}', " +
                $"LastName = '{LastName}', " +
                $"Password = '{Password}', " +
                $"BuildingNumber = {BuildingNumber}, " +
                $"Street = '{Street}', " +
                $"City = '{City}', " +
                $"Country = '{Country}' " +
                $"WHERE SSN = '{HomePage.user.SSN}'";
            SqlCommand cmd = new SqlCommand(query);
            int changes  = dbAccess.executeQuery(cmd);
            if (changes == 1)
            {
                HomePage.user.FirstName = FirstName;
                HomePage.user.SecondName = SecondName;
                HomePage.user.LastName = LastName;
                HomePage.user.Password = Password;
                HomePage.user.BuildingNumber = BuildingNumber;
                HomePage.user.Street = Street;
                HomePage.user.City = City;
                HomePage.user.Country = Country;
                MessageBox.Show("Information updated successfully");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: something went wrong");
            }
        }
    }
}

using DatabaseProject.DatabaseProject;
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
    public partial class CustomerForm : Form
    {
        DBAccess dbAccess = new DBAccess();
        public EmployeeHomePage homePage = new EmployeeHomePage();
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String FirstName = txtFirstName.Text;
            String MiddleName = txtMiddleName.Text;
            String LastName = txtLastName.Text;
            String SSN = txtSSN.Text;
            String Phone = txtPhone.Text;
            String Password = txtPassword.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);
            SqlCommand cmd = new SqlCommand("INSERT INTO Customer VALUES(@SSN, @FirstName, " +
               "@MiddleName, @LastName, @Phone, @BuildingNumber, @Street, @City, @Country, @Password)");

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Street", Street);
            cmd.Parameters.AddWithValue("@BuildingNumber", BuildingNumber);

            int row = dbAccess.executeQuery(cmd);
            if (row == 1)
            {
                MessageBox.Show("Customer added successfully");
                this.Hide();
                homePage.LoadCustomers();
            }
            else
            {
                MessageBox.Show("Error: something went wrong");
            }
        }
    }
}

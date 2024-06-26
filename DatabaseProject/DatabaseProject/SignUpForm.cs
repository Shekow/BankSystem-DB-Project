﻿using System;
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
            String Phone = txtPhone.Text;
            String Password = txtPassword.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);
            SqlCommand cmd;
            if (HomePage.user.Type == "Customer")
            {
                cmd =
               new SqlCommand
               ("INSERT INTO Customer VALUES(@SSN, @FirstName, " +
               "@MiddleName, @LastName, @Phone, @BuildingNumber, @Street, @City, @Country, @Password)");
            }
            else
            {
                cmd =
               new SqlCommand
               ("INSERT INTO Employee VALUES(@SSN, @FirstName, " +
               "@MiddleName, @LastName, @Phone, @BuildingNumber, @Street, @City, @Country, @Password, @Admin)");
            }

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
            if (HomePage.user.Type == "Admin") { cmd.Parameters.AddWithValue("@Admin", "True"); }
            else { cmd.Parameters.AddWithValue("@Admin", "False"); }

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
                HomePage.user.SSN = SSN;
                HomePage.user.Phone = Phone;
                HomePage.user.FirstName = FirstName;
                HomePage.user.MiddleName = MiddleName;
                HomePage.user.LastName = LastName;
                HomePage.user.Password = Password;
                HomePage.user.BuildingNumber = BuildingNumber;
                HomePage.user.Street = Street;
                HomePage.user.City = City;
                HomePage.user.Country = Country;
                MessageBox.Show("Account created successfully");
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginPage = new Login();
            loginPage.Show();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuildingNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void City_Click(object sender, EventArgs e)
        {

        }

        private void Country_Click(object sender, EventArgs e)
        {

        }

        private void BuildingNumber_Click(object sender, EventArgs e)
        {

        }

        private void Street_Click(object sender, EventArgs e)
        {

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }
    }
}
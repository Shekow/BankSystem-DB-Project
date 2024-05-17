using DatabaseProject.DatabaseProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class Login : Form
    {
        DBAccess dbAccess = new DBAccess();
        public Login()
        {
            InitializeComponent();
        }

        private void FirstName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String SSN = txtSSN.Text;
            String Password = txtPassword.Text;
            String query;
            if (HomePage.user.Type == "Customer")
            {
                query = $"SELECT * FROM [Customer] WHERE [SSN] = '{SSN}' AND [Password] = '{Password}'";
            }
            else if (HomePage.user.Type == "Employee")
            {
                query = $"SELECT * FROM [Employee] WHERE [SSN] = '{SSN}' AND [Password] = '{Password}' AND [Admin] = 'False'";
            }
            else
            {
                query = $"SELECT * FROM [Employee] WHERE [SSN] = '{SSN}' AND [Password] = '{Password}' AND [Admin] = 'True'";
            }

            DataTable dtUsers = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtUsers);
            if (dtUsers.Rows.Count == 1)
            {
                HomePage.user.SSN = dtUsers.Rows[0]["SSN"].ToString();
                HomePage.user.FirstName = dtUsers.Rows[0]["FirstName"].ToString();
                HomePage.user.MiddleName = dtUsers.Rows[0]["MiddleName"].ToString();
                HomePage.user.LastName = dtUsers.Rows[0]["LastName"].ToString();
                HomePage.user.Password = dtUsers.Rows[0]["Password"].ToString();
                HomePage.user.BuildingNumber = Convert.ToInt32(dtUsers.Rows[0]["BuildingNumber"].ToString());
                HomePage.user.Street = dtUsers.Rows[0]["Street"].ToString();
                HomePage.user.City = dtUsers.Rows[0]["City"].ToString();
                HomePage.user.Country = dtUsers.Rows[0]["Country"].ToString();
                MessageBox.Show("You successfully logged in");
                dbAccess.closeConn();
                this.Hide();
                if (HomePage.user.Type == "Customer")
                {
                    CustomerHomePage customerHomePage = new CustomerHomePage();
                    customerHomePage.Show();
                }
                else if (HomePage.user.Type == "Employee")
                {
                    EmpForm emplyeeHomePage = new EmpForm();
                    emplyeeHomePage.Show();
                }
                else
                {
                    AdminHomePage adminHomePage = new AdminHomePage();
                    adminHomePage.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid SSN/password");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm signupForm = new SignUpForm();
            signupForm.Show();
        }
    }
}

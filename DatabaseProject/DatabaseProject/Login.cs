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

            String query = $"SELECT * FROM [User] WHERE SSN = '{SSN}' AND Password = '{Password}'";
            DataTable dtUsers = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtUsers);
            if (dtUsers.Rows.Count == 1)
            {
                MessageBox.Show("You successfully logged in");
                dbAccess.closeConn();
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
            SignUpForm signupForm = new SignUpForm();
            signupForm.Show();
        }
    }
}

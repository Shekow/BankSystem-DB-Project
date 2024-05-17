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
    public partial class HomePage : Form
    {
        public static User user = new User();
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void UpdateProfileButton_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm();
            updateUserForm.ShowDialog();
        }

        private void AddBankButton_Click(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm();
            bankForm.ShowDialog();
        }

        private void AddBankBranchButton_Click(object sender, EventArgs e)
        {
            BankBranchForm bankBranchForm = new BankBranchForm();
            bankBranchForm.ShowDialog();
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            user.Type = "Customer";
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm();
            bankForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankBranchForm bankBranchForm = new BankBranchForm();
            bankBranchForm.Show();
        }
    }
}

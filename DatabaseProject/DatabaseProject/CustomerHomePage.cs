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
    public partial class CustomerHomePage : Form
    {
        DBAccess dbAccess = new DBAccess();
        Account account = new Account();
        public CustomerHomePage()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomerHomePage_Load(object sender, EventArgs e)
        {
            String query = $"SELECT * FROM [Account] WHERE CSSN = '{HomePage.user.SSN}'";
            DataTable dtAccount = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtAccount);
            for (int i = 0; i < dtAccount.Rows.Count; i++)
            {
                comboAccounts.Items.Add(dtAccount.Rows[i]["Number"].ToString());
            }
        }

        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            String AccountNumber = comboAccounts.Text;
            String query = $"SELECT * FROM [Account] WHERE CSSN = '{HomePage.user.SSN}' AND Number = {AccountNumber}";
            DataTable dtAccounts = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtAccounts);
            if (dtAccounts.Rows.Count == 1)
            {
                account.Number = Convert.ToInt32(dtAccounts.Rows[0]["Number"].ToString());
                account.BranchNumber = Convert.ToInt32(dtAccounts.Rows[0]["BranchNumber"].ToString());
                account.BankCode = dtAccounts.Rows[0]["BankCode"].ToString();
                account.Type = dtAccounts.Rows[0]["BankCode"].ToString();
                account.Balance = Convert.ToInt32(dtAccounts.Rows[0]["Balance"].ToString());

                AccountBranchNumberLabel.Text = account.Number.ToString();
                AccountBankCodeLabel.Text = account.BankCode.ToString();
                AccountBalanceLabel.Text = account.Balance.ToString();
                AccountTypeLabel.Text = account.Type.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Account");
            }
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {

        }
    }
}

using DatabaseProject.DatabaseProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
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
            String Type = comboLoanType.Text;
            String loansQuery = $"SELECT [Number] FROM [Loan] WHERE BankCode = '{account.BankCode}' AND BranchNumber = {account.BranchNumber} AND [Type] = '{Type}'";
            DataTable dtLoans = new DataTable();
            dbAccess.readDatathroughAdapter(loansQuery, dtLoans);
            comboLoanNumber.Items.Clear();
            for (int i = 0; i < dtLoans.Rows.Count; i++)
            {
                comboLoanNumber.Items.Add(dtLoans.Rows[i]["Number"].ToString());
            }
        }

        private void CustomerHomePage_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = HomePage.user.FirstName;
            this.LoadAccounts();
            deleteButton.Visible = false;
        }

        public void LoadAccounts()
        {
            comboAccounts.Items.Clear();
            String query = $"SELECT * FROM [Account] WHERE CSSN = '{HomePage.user.SSN}'";
            DataTable dtAccount = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtAccount);
            for (int i = 0; i < dtAccount.Rows.Count; i++)
            {
                comboAccounts.Items.Add(dtAccount.Rows[i]["Number"].ToString());
            }
        }

        public void LoadPendingBalanace()
        {
            String pendingBal = $"SELECT [Amount] FROM [Requests] WHERE [AccountNumber] = {account.Number} AND NOT EXISTS(SELECT * FROM [ProcessLoanRequest] WHERE [RequestID] = [ID])";
            DataTable dtRequests = new DataTable();
            dbAccess.readDatathroughAdapter(pendingBal, dtRequests);
            AccountPendingBalanceLabel.Text = dtRequests.Compute("SUM(Amount)", String.Empty).ToString();
            if (AccountPendingBalanceLabel.Text.Equals(String.Empty))
                AccountPendingBalanceLabel.Text = "0";
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
                account.Type = dtAccounts.Rows[0]["Type"].ToString();
                account.Balance = Convert.ToDouble(dtAccounts.Rows[0]["Balance"].ToString());

                AccountBranchNumberLabel.Text = account.BranchNumber.ToString();
                AccountBankCodeLabel.Text = account.BankCode.ToString();
                AccountBalanceLabel.Text = account.Balance.ToString();
                AccountTypeLabel.Text = account.Type.ToString();

                this.LoadPendingBalanace();
                deleteButton.Visible = true;

                comboLoanType.Text = "";
                comboLoanNumber.Text = "";
                txtAmount.Text = "";

                String loansQuery = $"SELECT DISTINCT [Type] FROM [Loan] WHERE BankCode = '{account.BankCode}' AND BranchNumber = {account.BranchNumber}";
                DataTable dtLoans = new DataTable();
                dbAccess.readDatathroughAdapter(loansQuery, dtLoans);
                comboLoanType.Items.Clear();
                for (int i = 0; i < dtLoans.Rows.Count; i++)
                {
                    comboLoanType.Items.Add(dtLoans.Rows[i]["Type"].ToString());
                }

            }
            else
            {
                MessageBox.Show("Invalid Account");
            }
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            accountForm.customerHomePage = this;
            accountForm.Show();
        }

        private void RequestLoanButton_Click(object sender, EventArgs e)
        {
            String LoanNumber = comboLoanNumber.Text;
            double Amount = Convert.ToDouble(txtAmount.Text);
            SqlCommand cmd = new SqlCommand("INSERT INTO [Requests](AccountNumber, LoanNumber, BranchNumber, BankCode, Amount)" +
                "VALUES(@AccountNumber, @LoanNumber, @BranchNumber, @BankCode, @Amount)");
            cmd.Parameters.AddWithValue("@AccountNumber", account.Number);
            cmd.Parameters.AddWithValue("@LoanNumber", LoanNumber);
            cmd.Parameters.AddWithValue("@BranchNumber", account.BranchNumber);
            cmd.Parameters.AddWithValue("@BankCode", account.BankCode);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            try
            {
                int changes = dbAccess.executeQuery(cmd);
                if (changes > 0)
                {
                    MessageBox.Show("Loan requested successfully");
                    this.LoadPendingBalanace();
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some data is missing/invalid");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm();
            this.Hide();
            updateUserForm.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", $"Delete account {account.Number}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;
            String query = $"DELETE FROM [Account] WHERE [Number] = '{account.Number}'"; ;

            SqlCommand cmd = new SqlCommand(query);
            int changes = dbAccess.executeQuery(cmd);
            if (changes == 1)
            {
                MessageBox.Show("Account deleted successfully");
                account = new Account();
                CustomerHomePage homePage = new CustomerHomePage();
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

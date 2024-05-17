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
            for (int i = 0; i < dtLoans.Rows.Count; i++)
            {
                comboLoanNumber.Items.Add(dtLoans.Rows[i]["Number"].ToString());
            }
        }

        private void CustomerHomePage_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = HomePage.user.FirstName;
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
                account.Type = dtAccounts.Rows[0]["Type"].ToString();
                account.Balance = Convert.ToDouble(dtAccounts.Rows[0]["Balance"].ToString());

                AccountBranchNumberLabel.Text = account.Number.ToString();
                AccountBankCodeLabel.Text = account.BankCode.ToString();
                AccountBalanceLabel.Text = account.Balance.ToString();
                AccountTypeLabel.Text = account.Type.ToString();

                String pendingBal = $"SELECT SUM([Amount]) AS Total FROM [Requests] WHERE [AccountNumber] = {account.Number}";
                DataTable dtRequests = new DataTable();
                dbAccess.readDatathroughAdapter(pendingBal, dtRequests);
                AccountPendingBalanceLabel.Text = dtRequests.Rows[0]["Total"].ToString();

                String loansQuery = $"SELECT DISTINCT [Type] FROM [Loan] WHERE BankCode = '{account.BankCode}' AND BranchNumber = {account.BranchNumber}";
                DataTable dtLoans = new DataTable();
                dbAccess.readDatathroughAdapter(loansQuery, dtLoans);
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
            this.Hide();
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
            int changes = dbAccess.executeQuery(cmd);
            if (changes > 0)
            {
                MessageBox.Show("Loan requested successfully");
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

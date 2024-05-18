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
    public partial class AdminHomePage : Form
    {
        DBAccess dbAccess = new DBAccess();
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            String query = "SELECT [Customer].[FirstName] AS [Customer First Name], [Account].[Number] AS [Account Number], [Requests].[BranchNumber], [Requests].[BankCode], [LoanNumber], [Requests].[Amount] AS [Requested Amount], [Employee].[FirstName] AS [Employee First Name], [State] " +
                "FROM [ProcessLoanRequest] " +
                "JOIN [Employee] ON [ProcessLoanRequest].[ESSN] = [Employee].[SSN]" +
                "JOIN [Requests] ON [ProcessLoanRequest].[RequestID] = [Requests].[ID]" +
                "JOIN [Account] ON [Requests].[AccountNumber] = [Account].[Number]" +
                "JOIN [Customer] ON [Account].[CSSN] = [Customer].[SSN]" +
                "JOIN [Loan] ON [Requests].[LoanNumber] = [Loan].[Number]";
            DataTable dtLogs = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtLogs);
            dataGridLogs.DataSource = dtLogs;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            String query = "SELECT [SSN], [FirstName], [MiddleName], [LastName], SUM([Requests].[Amount]) AS [Total requested]" +
                "FROM [Requests]" +
                "JOIN [Account] ON [Requests].[AccountNumber] = [Account].[Number]" +
                "JOIN [Customer] ON [Account].[CSSN] = [Customer].[SSN]" +
                "WHERE NOT EXISTS(SELECT * FROM [ProcessLoanRequest] WHERE [RequestID] = [ID]) " +
                "GROUP BY [SSN], [FirstName], [MiddleName], [LastName];";
            DataTable dtLogs = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtLogs);
            dataGridLogs.DataSource = dtLogs;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm();
            bankForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoanForm loanForm = new LoanForm();
            loanForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankBranchForm bankBranchForm = new BankBranchForm();
            bankBranchForm.Show();
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = HomePage.user.FirstName;
        }

        private void label2_Click(object sender, EventArgs e)
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
    }
}

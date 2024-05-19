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
    public partial class ReportForm : Form
    {
        DBAccess dbAccess = new DBAccess();
        public ReportForm()
        {
            InitializeComponent();
        }
        void LoadTotal(String query, Label label)
        {
            DataTable dtLoans = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtLoans);
            label.Text = dtLoans.Compute("SUM(Amount)", String.Empty).ToString();
            if (label.Text.Equals(String.Empty))
                label.Text = "0.0";
        }
        void LoadDataGrid(String query)
        {
            DataTable dataTable = new DataTable();
            dbAccess.readDatathroughAdapter(query, dataTable);
            dataGridStatistics.DataSource = dataTable;
        }
        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadTotal("SELECT * FROM [Requests]", txtRequested);
            LoadTotal("SELECT [Amount] FROM [Requests] WHERE NOT EXISTS(SELECT * FROM [ProcessLoanRequest] WHERE [RequestID] = [ID])", txtPending);
            LoadTotal("SELECT * FROM [ProcessLoanRequest] JOIN [Requests] ON [ProcessLoanRequest].[RequestID] = [Requests].[ID] WHERE [State] = 'Accepted'", txtAccepted);
            LoadTotal("SELECT * FROM [ProcessLoanRequest] JOIN [Requests] ON [ProcessLoanRequest].[RequestID] = [Requests].[ID] WHERE [State] = 'Rejected'", txtRejected);
            LoadTotal("SELECT * FROM [ProcessLoanRequest] JOIN [Requests] ON [ProcessLoanRequest].[RequestID] = [Requests].[ID] WHERE [State] = 'Paid'", txtPaid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "SELECT [Bank].[Code], [Bank].[Name], COUNT([Account].[Number]) AS [Total Accounts] FROM [Bank] " +
                "JOIN [Account] ON [Account].[BankCode] = [Bank].[Code]" +
                "GROUP BY [Bank].[Code], [Bank].[Name]";
            LoadDataGrid(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "SELECT [Customer].[City], SUM([Requests].[Amount]) AS [Total Amount] FROM [Account] " +
                "JOIN [Requests] ON [Account].[Number] = [Requests].[AccountNumber]" +
                "JOIN [Customer] ON [Account].[CSSN] = [Customer].[SSN]" +
                "GROUP BY [Customer].[City]" +
                "ORDER BY SUM([Requests].[Amount]) DESC";
            LoadDataGrid(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String query = "SELECT TOP 10 * FROM [Requests]";
            LoadDataGrid(query);
        }
    }
}

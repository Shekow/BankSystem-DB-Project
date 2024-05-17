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
    public partial class LoanLogs : Form
    {
        DBAccess dbAccess = new DBAccess();
        public LoanLogs()
        {
            InitializeComponent();
        }

        private void LoanLogs_Load(object sender, EventArgs e)
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
            datagridLoanLogs.DataSource = dtLogs;
        }
    }
}

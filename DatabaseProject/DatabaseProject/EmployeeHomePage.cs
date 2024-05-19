using DatabaseProject.DatabaseProject;
using System;
using System.Collections;
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
    public partial class EmployeeHomePage : Form
    {
        DBAccess dbAccess = new DBAccess();
        public EmployeeHomePage()
        {
            InitializeComponent();
        }
        public void LoadCustomers()
        {
            String query = "SELECT * FROM [Customer]";
            DataTable dtLogs = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtLogs);
            dataGridCustomers.DataSource = dtLogs;
        }
        private void EmployeeHomePage_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = HomePage.user.FirstName;
            this.LoadCustomers();
            this.LoadPending();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
            customerForm.homePage = this;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm();
            this.Hide();
            updateUserForm.Show();
        }
        void LoadPending()
        {
            FlowPanel.Controls.Clear();
            String query = "SELECT * FROM [Requests] WHERE NOT EXISTS(SELECT * FROM [ProcessLoanRequest] WHERE [RequestID] = [ID])";
            DataTable dtLoans = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtLoans);
            for (int i = 0; i < dtLoans.Rows.Count; i++)
            {
                Panel panel = new Panel()
                {
                    Name = $"PanelLoan{dtLoans.Rows[i]["ID"]}",
                    BackColor = Color.Transparent,
                    Size = new Size(380, 50),
                    Margin = new Padding(10),
                    Tag = dtLoans.Rows[i]["ID"],
                };
                Label labelAccount = new Label()
                {
                    Text = "Account: " + dtLoans.Rows[i]["AccountNumber"].ToString(),
                    Location = new Point(1, 1),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelBank = new Label()
                {
                    Text = "Bank: " + dtLoans.Rows[i]["BankCode"].ToString(),
                    Location = new Point(80, 1),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelBranch = new Label()
                {
                    Text = "Branch: " + dtLoans.Rows[i]["BranchNumber"].ToString(),
                    Location = new Point(180, 1),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelLoan = new Label()
                {
                    Text = "Loan: " + dtLoans.Rows[i]["LoanNumber"].ToString(),
                    Location = new Point(80, 25),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelAmount = new Label()
                {
                    Text = "Amount: " + dtLoans.Rows[i]["Amount"].ToString(),
                    Location = new Point(180, 25),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Button acceptButton = new Button()
                {
                    Name = $"LoanButtonAccept{dtLoans.Rows[i]["ID"]}",
                    Text = "Accept",
                    Location = new Point(300, 1),
                    ForeColor = Color.White,
                    BackColor = Color.SpringGreen,
                    AutoSize = true,
                    Tag = dtLoans.Rows[i]["ID"],
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Button rejectButton = new Button()
                {
                    Name = $"LoanButtonReject{dtLoans.Rows[i]["ID"]}",
                    Text = "Reject",
                    Location = new Point(300, 25),
                    ForeColor = Color.White,
                    BackColor = Color.Crimson,
                    AutoSize = true,
                    Tag = dtLoans.Rows[i]["ID"],
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                acceptButton.Click += (buttonSender, buttonArgs) =>
                {
                    query = $"SELECT * FROM [Requests] WHERE [ID] = '{acceptButton.Tag}'";
                    DataTable dt = new DataTable();
                    dbAccess.readDatathroughAdapter(query, dt);
                    String State = "Accepted";
                    query = $" Insert into ProcessLoanRequest values (@SSN, @id ,@State )";
                    String query2 = $"UPDATE Account SET Balance = Balance + {dt.Rows[0]["Amount"]} WHERE Number = {dt.Rows[0]["AccountNumber"]};";
                    SqlCommand cmd = new SqlCommand(query);
                    SqlCommand cmd2 = new SqlCommand(query2);

                    cmd.Parameters.AddWithValue("@SSN", HomePage.user.SSN);
                    cmd.Parameters.AddWithValue("@id", dt.Rows[0]["ID"]);
                    cmd.Parameters.AddWithValue("@State", State);
                    int changes2 = dbAccess.executeQuery(cmd2);
                    int changes = dbAccess.executeQuery(cmd);
                    if (changes == 1 && changes2 == 1)
                    {
                        MessageBox.Show("Loan accepted successfully");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                    LoadPending();
                };
                rejectButton.Click += (buttonSender, buttonArgs) =>
                {
                    query = $"SELECT * FROM [Requests] WHERE [ID] = '{rejectButton.Tag}'";
                    DataTable dt = new DataTable();
                    dbAccess.readDatathroughAdapter(query, dt);
                    String State = "Rejected";
                    query = $" Insert into ProcessLoanRequest values (@SSN, @id ,@State )";
                    String query2 = $"UPDATE Account SET Balance = Balance + {dt.Rows[0]["Amount"]} WHERE Number = {dt.Rows[0]["AccountNumber"]};";
                    SqlCommand cmd = new SqlCommand(query);
                    SqlCommand cmd2 = new SqlCommand(query2);

                    cmd.Parameters.AddWithValue("@SSN", HomePage.user.SSN);
                    cmd.Parameters.AddWithValue("@id", dt.Rows[0]["ID"]);
                    cmd.Parameters.AddWithValue("@State", State);
                    int changes2 = dbAccess.executeQuery(cmd2);
                    int changes = dbAccess.executeQuery(cmd);
                    if (changes == 1 && changes2 == 1)
                    {
                        MessageBox.Show("Loan rejected successfully");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                    LoadPending();
                };
                panel.Controls.Add(labelAccount);
                panel.Controls.Add(labelBank);
                panel.Controls.Add(labelBranch);
                panel.Controls.Add(labelLoan);
                panel.Controls.Add(labelAmount);
                panel.Controls.Add(acceptButton);
                panel.Controls.Add(rejectButton);
                FlowPanel.Controls.Add(panel);
            }
        }
        void LoadInProgress()
        {
            FlowPanel.Controls.Clear();
            String query = "SELECT [ID], [AccountNumber], [BankCode], [BranchNumber], [LoanNumber], [Amount] FROM [ProcessLoanRequest] " +
                "JOIN Requests ON [ProcessLoanRequest].[RequestID] = [Requests].[ID] " +
                "WHERE [State] = 'Accepted' " +
                "EXCEPT " +
                "SELECT [ID], [AccountNumber], [BankCode], [BranchNumber], [LoanNumber], [Amount] FROM [ProcessLoanRequest] " +
                "JOIN Requests ON [ProcessLoanRequest].[RequestID] = [Requests].[ID] " +
                "WHERE [State] = 'Paid'";
            DataTable dtLoans = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtLoans);
            for (int i = 0; i < dtLoans.Rows.Count; i++)
            {
                Panel panel = new Panel()
                {
                    Name = $"PanelLoan{dtLoans.Rows[i]["ID"]}",
                    BackColor = Color.Transparent,
                    Size = new Size(380, 50),
                    Margin = new Padding(10),
                    Tag = dtLoans.Rows[i]["ID"],
                };
                Label labelAccount = new Label()
                {
                    Text = "Account: " + dtLoans.Rows[i]["AccountNumber"].ToString(),
                    Location = new Point(1, 1),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelBank = new Label()
                {
                    Text = "Bank: " + dtLoans.Rows[i]["BankCode"].ToString(),
                    Location = new Point(80, 1),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelBranch = new Label()
                {
                    Text = "Branch: " + dtLoans.Rows[i]["BranchNumber"].ToString(),
                    Location = new Point(180, 1),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelLoan = new Label()
                {
                    Text = "Loan: " + dtLoans.Rows[i]["LoanNumber"].ToString(),
                    Location = new Point(80, 25),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Label labelAmount = new Label()
                {
                    Text = "Amount: " + dtLoans.Rows[i]["Amount"].ToString(),
                    Location = new Point(180, 25),
                    ForeColor = Color.DeepSkyBlue,
                    AutoSize = true,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                Button acceptButton = new Button()
                {
                    Name = $"LoanButtonAccept{dtLoans.Rows[i]["ID"]}",
                    Text = "Pay Off",
                    Location = new Point(300, 10),
                    ForeColor = Color.White,
                    BackColor = Color.SpringGreen,
                    AutoSize = true,
                    Tag = dtLoans.Rows[i]["ID"],
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                };
                acceptButton.Click += (buttonSender, buttonArgs) =>
                {
                    String State = "Paid";
                    query = $" Insert into ProcessLoanRequest values (@SSN, @id ,@State)";
                    // String query2 = $"UPDATE Account SET Balance = Balance + {dtLoans.Rows[0]["Amount"]} WHERE Number = {dtLoans.Rows[0]["AccountNumber"]};";
                    SqlCommand cmd = new SqlCommand(query);
                    // SqlCommand cmd2 = new SqlCommand(query2);

                    cmd.Parameters.AddWithValue("@SSN", HomePage.user.SSN);
                    cmd.Parameters.AddWithValue("@id", acceptButton.Tag);
                    cmd.Parameters.AddWithValue("@State", State);
                    // int changes2 = dbAccess.executeQuery(cmd2);
                    int changes = dbAccess.executeQuery(cmd);
                    if (changes == 1)
                    {
                        MessageBox.Show("Loan Paid successfully");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                    LoadInProgress();
                };
                
                panel.Controls.Add(labelAccount);
                panel.Controls.Add(labelBank);
                panel.Controls.Add(labelBranch);
                panel.Controls.Add(labelLoan);
                panel.Controls.Add(labelAmount);
                panel.Controls.Add(acceptButton);
                FlowPanel.Controls.Add(panel);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadPending();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadInProgress();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }
    }
}

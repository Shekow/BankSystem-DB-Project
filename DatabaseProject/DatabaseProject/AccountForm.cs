using DatabaseProject.DatabaseProject;
using System;
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
    public partial class AccountForm : Form
    {
        public CustomerHomePage customerHomePage;
        DBAccess dbAccess = new DBAccess();
        public AccountForm()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String BankCode = comboBankCode.Text;
            String query = $"SELECT * FROM [Branch] WHERE BankCode = '{BankCode}'";
            DataTable dtBranches = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtBranches);
            comboBranchNumber.Items.Clear();
            for (int i = 0; i < dtBranches.Rows.Count; i++)
            {
                comboBranchNumber.Items.Add(dtBranches.Rows[i]["Number"].ToString());
            }
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            String query = $"SELECT * FROM [Bank]";
            DataTable dtBanks = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtBanks);
            for (int i = 0; i < dtBanks.Rows.Count; i++)
            {
                comboBankCode.Items.Add(dtBanks.Rows[i]["Code"].ToString());
            }
        }

        private void RequestLoanButton_Click(object sender, EventArgs e)
        {
            String BankCode = comboBankCode.Text;
            String BranchNumber = comboBranchNumber.Text;
            String Type = comboType.Text;
            SqlCommand cmd = new SqlCommand("INSERT INTO Account(BankCode, BranchNumber, Type, CSSN)" +
                "VALUES(@BankCode, @BranchNumber, @Type, @CSSN)");
            cmd.Parameters.AddWithValue("@BankCode", BankCode);
            cmd.Parameters.AddWithValue("@BranchNumber", BranchNumber);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@CSSN", HomePage.user.SSN);
            try
            {
                int changes = dbAccess.executeQuery(cmd);
                if (changes > 0)
                {
                    MessageBox.Show("Account created successfully");
                    dbAccess.closeConn();
                    this.customerHomePage.LoadAccounts();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error: something went wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some data is missing/invalid");
            }
            
        }
    }
}

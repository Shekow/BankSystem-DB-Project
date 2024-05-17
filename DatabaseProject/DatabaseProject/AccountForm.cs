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
    public partial class AccountForm : Form
    {
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
    }
}

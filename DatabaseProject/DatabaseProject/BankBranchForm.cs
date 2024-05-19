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
    public partial class BankBranchForm : Form
    {
        DBAccess dbAccess = new DBAccess();
        public BankBranchForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BankBranchForm_Load(object sender, EventArgs e)
        {
            String query = $"SELECT * FROM [Bank]";
            DataTable dtBanks = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtBanks);
            for (int i = 0; i < dtBanks.Rows.Count; i++) 
            {
                comboBankCode.Items.Add(dtBanks.Rows[i]["Code"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String BankCode = comboBankCode.Text;
            String Number = txtNumber.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);

            SqlCommand cmd = new SqlCommand("INSERT INTO [Branch](Number, BankCode, BuildingNumber, Street, City, Country) " +
                "VALUES(@Number, @BankCode, @BuildingNumber, @Street, @City, @Country)");
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@BankCode", BankCode);
            cmd.Parameters.AddWithValue("@BuildingNumber", BuildingNumber);
            cmd.Parameters.AddWithValue("@Street", Street);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            try
            {
                int changes = dbAccess.executeQuery(cmd);
                if (changes > 0)
                {
                    MessageBox.Show("Branch added successfully");
                    dbAccess.closeConn();
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

        private void City_Click(object sender, EventArgs e)
        {

        }
    }
}

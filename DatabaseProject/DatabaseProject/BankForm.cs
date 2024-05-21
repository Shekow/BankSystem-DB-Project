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
    public partial class BankForm : Form
    {
        DBAccess dbAccess = new DBAccess();
        public BankForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Name = txtName.Text;
            String Code = txtCode.Text;
            String Country = txtCountry.Text;
            String City = txtCity.Text;
            String Street = txtStreet.Text;
            int BuildingNumber = Convert.ToInt32(txtBuildingNumber.Text);

            SqlCommand cmd = new SqlCommand("INSERT INTO [Bank] VALUES(@Name, @Code, @BuildingNumber, @Street, @City, @Country)");
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Street", Street);
            cmd.Parameters.AddWithValue("@BuildingNumber", BuildingNumber);

            try
            {
                int changes = dbAccess.executeQuery(cmd);
                if (changes == 1)
                {
                    MessageBox.Show("Bank Added successfully");
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

using DatabaseProject.DatabaseProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class ViewCustomers : Form
    {
        DBAccess dbAccess = new DBAccess();
        Account account = new Account();
        public ViewCustomers()
        {

            InitializeComponent();
        }

        private void ViewCustomers_Load(object sender, EventArgs e)
        {
            String query = $"SELECT * FROM Customer";
            DataTable dtCustomer = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtCustomer);
            for (int i = 0; i < dtCustomer.Rows.Count; i++)
            {
                combocustomers.Items.Add(dtCustomer.Rows[i]["SSN"]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SSN = combocustomers.Text;
            String query = $"SELECT * FROM Customer where SSN = '{SSN}'";
            DataTable dtCustomer = new DataTable();
            dbAccess.readDatathroughAdapter(query, dtCustomer);
            if (dtCustomer.Rows.Count == 1)
            {
                String CName = dtCustomer.Rows[0]["FirstName"].ToString();
                String Ccountry = dtCustomer.Rows[0]["Country"].ToString();
                String Caddress = dtCustomer.Rows[0]["Address"].ToString();
                String Ccity = dtCustomer.Rows[0]["City"].ToString();


                AddressText.Text = Caddress;
                CityText.Text = Ccity;
                Nametext.Text = CName;
                CountryText.Text = Ccountry;
            }
            else
            {
                MessageBox.Show("Invalid Customer");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

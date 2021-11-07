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

namespace Lab6_Basic_Command
{
    public partial class BillsForm : Form
    {
        public void LoadBill()
        {
            string connectionString = @"Data Source=DESKTOP-CU4CFCO\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from Bills";

            sqlConnection.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách hóa đơn được bán trong một khoảng thời gian" + catName;

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable("Bills");
            da.Fill(dt);

            dgvBills.DataSource = dt;

            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }
        public BillsForm()
        {
            InitializeComponent();

            LoadBill();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvBills_DoubleClick(object sender, EventArgs e)
        {
            string billsID = dgvBills.SelectedRows[0].Cells[0].Value.ToString();
            if (billsID != "")
            {
                frmBillDetails foodForm = new frmBillDetails();
                foodForm.Show(this);
                foodForm.LoadBillDetails(Convert.ToInt32(billsID));
            }
        }

    }
}

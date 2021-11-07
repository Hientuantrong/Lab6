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
    public partial class frmBillDetails : Form
    {
        public void LoadBillDetails(int BillsID)
        {
            string connectionString = @"Data Source=DESKTOP-CU4CFCO\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select Name from Bills where ID = " + BillsID;

            sqlConnection.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh mục những mặt hàng mua bởi hóa đơn" + catName;

            sqlCommand.CommandText = "select * from BillDetails where ID = " + BillsID;

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable("BillDetails");
            da.Fill(dt);

            dgvBillDetails.DataSource = dt;

            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }
        public frmBillDetails()
        {
            InitializeComponent();
        }

        private void frmBillDetails_Load(object sender, EventArgs e)
        {

        }
    }
}

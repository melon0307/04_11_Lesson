using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2._4._Disconnected_離線_DataSet;

namespace Starter
{
    public partial class FrmDisConnected_離線DataSet : Form
    {
        public FrmDisConnected_離線DataSet()
        {
            InitializeComponent();
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView7.DataSource = (this.nwDataSet1.Products);

        }

        private void Button30_Click(object sender, EventArgs e)
        {            
            this.dataGridView1.DataSource = this.nwDataSet1;
            this.dataGridView1.DataMember = "Categories";
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            this.dataGridView7.AllowUserToAddRows = false;
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            this.dataGridView7.Columns[1].Frozen = true;
            this.dataGridView7.Rows[3].Frozen = true;
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dataGridView7.CurrentCell.Value.ToString());
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dataGridView7.CurrentRow.Cells[3].Value.ToString());
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                int ProductID = (int)this.dataGridView7.CurrentRow.Cells["ProductID"].Value;
                
                FrmProductDetails f = new FrmProductDetails();
                f.Text = ProductID.ToString();
                f.ProductID = ProductID;
                f.Show();                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataColumn dataColumn = new DataColumn("Total", typeof(decimal));
            dataColumn.Expression = "UnitPrice * UnitsInStock";
            this.nwDataSet1.Products.Columns.Add(dataColumn);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView8.DataSource = this.nwDataSet1.Products;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProductCRUD f = new FrmProductCRUD();
            f.Show();
        }
    }
}

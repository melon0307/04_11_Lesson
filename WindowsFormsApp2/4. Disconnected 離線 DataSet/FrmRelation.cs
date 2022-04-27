using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2._4._Disconnected_離線_DataSet
{
    public partial class FrmRelation : Form
    {
        public FrmRelation()
        {
            InitializeComponent();
        }

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nWDataSet);

        }

        private void FrmRelation_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'nWDataSet.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.nWDataSet.Products);
            // TODO: 這行程式碼會將資料載入 'nWDataSet.Categories' 資料表。您可以視需要進行移動或移除。
            this.categoriesTableAdapter.Fill(this.nWDataSet.Categories);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Weak
            //this.nWDataSet.Categories[0].GetChildRows("FK_Products_Categories"); 回傳DataRows陣列

            //Strong
            int position_c = this.categoriesBindingSource.Position;
            this.dataGridView1.DataSource = this.nWDataSet.Categories[position_c].GetProductsRows(); //回傳productsRows陣列
            //====================================

            //Weak
            
            MessageBox.Show(this.nWDataSet.Products[0].GetParentRow("FK_Products_Categories")["CategoryName"].ToString());

            //Strong
            MessageBox.Show(this.nWDataSet.Products[0].CategoriesRow.CategoryName);
            
            
        }
    }
}

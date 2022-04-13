using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2._1._OverView
{
    public partial class Frm_Overview : Form
    {
        public Frm_Overview()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = tabControl1.TabCount-1; //載入Form 預設的tabpage            
        }

        private void btnConnected_Click(object sender, EventArgs e)
        {
            // Step1: SqlConnection
            // Step2: SqlCommand
            // Step3: SqlDataReader
            // Step4: UI Control

            SqlConnection conn = null;              //宣告在try區塊外，讓最後的finally能使用conn變數，並給他一個空值
            try
            {
                // Step1 連線
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();

                // Step2 指令
                SqlCommand command = new SqlCommand("select * from Products", conn);

                // Step3 傳回SqlDataReader型態的物件
                SqlDataReader dataReader = command.ExecuteReader();

                // Step4 輸出在控制項上
                listBox1.Items.Clear();
                while (dataReader.Read())   //Read 若有資料則回傳true 反之false 因此使用while 讓他判定並連續回傳
                {
                    string s = $"{dataReader["ProductName"],-40/*給他40個空間，負值為靠左對齊*/} - {dataReader["UnitPrice"]:c2}"; // syntax sugar 語法糖 $"" { }括號內都轉string
                                                                                                                     // ↑冒號後為格式，c2為貨幣
                    listBox1.Items.Add(s);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void btnDisConnected_Click(object sender, EventArgs e)
        {
            // Step1: SqlConnection
            // Step2: SqlDataAdapter
            // Step3: DataSet            - In Memmory DB
            // Step4: UI Control        - DataGridView  -  Table

            // Step1
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            
            //Step2
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products", conn);
            
            //Step3
            DataSet ds = new DataSet();
            adapter.Fill(ds);             //Auto Connected DB: conn.Open(); => SqlCommand("select....") => SqlDataReader => while(DataReader.Read()).....conn.Close();     

            //Step4 
            this.dataGridView1.DataSource = ds.Tables[0];     //有可能fill許多table，輸出索引0(第1個table)到控制項上
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Production.ProductPhoto", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products where UnitPrice >30 Order by UnitPrice  ", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView2.DataSource = this.nwDataSet1.Products;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.dataGridView2.DataSource = this.nwDataSet1.Categories; 

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.customersTableAdapter1.Fill(this.nwDataSet1.Customers);
            this.dataGridView2.DataSource = this.nwDataSet1.Customers;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.FillByUnitPriceMoreThan(this.nwDataSet1.Products, 30);
            this.dataGridView2.DataSource = this.nwDataSet1.Products;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.InsertProduct("x", false);
            MessageBox.Show("輸入完成");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Update(this.nwDataSet1.Products);
            MessageBox.Show("Products資料已做修改");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.bindingSource1.DataSource = this.nwDataSet1.Categories;
            this.dataGridView3.DataSource = this.bindingSource1;
            //this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
            this.textBox1.DataBindings.Add("Text", this.bindingSource1, "CategoryName");
            // textbox與bindingSourse繫結  (控制項中的哪個屬性，來源，CategoryRow中的哪個屬性(欄位))
            this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "Picture", true);
            //pictureBox與bindingSourse繫結   (控制項中的哪個屬性，來源，CategoryRow中的哪個屬性(欄位)，是否把byte[]型態轉換成圖片)
            this.bindingNavigator1.BindingSource = this.bindingSource1;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
            //this.bindingSource1.MoveFirst();
            //this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position -= 1;
            //this.bindingSource1.MovePrevious();
            //this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position += 1;
            //this.bindingSource1.MoveNext();
            //this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.bindingSource1.Count - 1;
            //this.bindingSource1.MoveLast();
            //this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)    //此事件為當bindingSourse.Position改變時觸發
        {
            this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FrmNoCode f = new FrmNoCode();
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.customersTableAdapter1.Fill(this.nwDataSet1.Customers);

            this.dataGridView4.DataSource = this.nwDataSet1.Products;
            this.dataGridView5.DataSource = this.nwDataSet1.Categories;
            this.dataGridView6.DataSource = this.nwDataSet1.Customers;

            this.listBox2.Items.Clear();
            for(int i =0; i < this.nwDataSet1.Tables.Count; i++)
            {
                DataTable dataTable = this.nwDataSet1.Tables[i];
                this.listBox2.Items.Add(dataTable.TableName);
                string s = "";
                string st = "";
                // Column schema
                for(int column = 0; column < dataTable.Columns.Count; column++)
                {                    
                    s += dataTable.Columns[column]+"  ";                    
                }
                listBox2.Items.Add(s);

                // Row - Data
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    for(int j = 0 ; j<dataTable.Columns.Count; j++)
                    {                         
                         st += dataTable.Rows[row][j]+" ";                        
                                                                 // ↑ 第row筆的第j個欄位
                    }
                    this.listBox2.Items.Add(st);
                    st = "";
                }               

                listBox2.Items.Add("=====================================");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Weak Type
            MessageBox.Show(this.nwDataSet1.Products.Rows[0]["ProductName"].ToString()); // Weak Type 假如"ProductName"打錯，編譯會過但exe會出錯
            MessageBox.Show(this.nwDataSet1.Products.Rows[0][1].ToString());

            // Strong Type
            MessageBox.Show(this.nwDataSet1.Products[0].ProductName); //Strong Type 將欄位階變為屬性，因此ProductName若打錯，編譯階段就會出錯 
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.nwDataSet1.Products.WriteXml("Product.xml", XmlWriteMode.WriteSchema);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            nwDataSet1.Products.Clear();
            this.nwDataSet1.Products.ReadXml("Product.xml");
            this.dataGridView4.DataSource = this.nwDataSet1.Products;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            /*
             if (this.splitContainer2.Panel1Collapsed == true)
            {
                this.splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                this.splitContainer2.Panel1Collapsed = true;
            }
            */
            this.splitContainer2.Panel1Collapsed = !this.splitContainer2.Panel1Collapsed;
        }
    }
}

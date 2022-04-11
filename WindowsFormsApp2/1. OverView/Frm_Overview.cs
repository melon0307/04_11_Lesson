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
            tabControl1.SelectedIndex = 1;
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
    }
}

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
using System.Configuration;
using WindowsFormsApp2.Properties;

namespace Starter

{
    public partial class FrmSqlConnection : Form
    {
        public FrmSqlConnection()
        {
            InitializeComponent();
            this.tabPage1.BackColor = Settings.Default.MyBackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = "Data Source = .;Initial Catalog = Northwind;Integrated Security = true";
            // Step1: SqlConnection
            // Step2: SqlCommand
            // Step3: SqlDataReader
            // Step4: UI Control


            try
            {
                // syntax sugar : using()內當成物件，{}執行完 自動conn.Close();
                // Step1 連線
                using (SqlConnection conn = new SqlConnection(connstring))
                {
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

                } // Auto conn.Close(), Auto conn.Dispose(); 釋放物件資源(記憶體)
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstring = "Data Source = .;Initial Catalog = Northwind;User ID = sa;Password = sa";
            // Step1: SqlConnection
            // Step2: SqlCommand
            // Step3: SqlDataReader
            // Step4: UI Control


            try
            {
                // syntax sugar : using()內當成物件，{}執行完 自動conn.Close();
                // Step1 連線
                using (SqlConnection conn = new SqlConnection(connstring))
                {
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
                } // Auto conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string connstring = "Data Source = .;Initial Catalog = Northwind;Integrated Security = true";
            // Step1: SqlConnection
            // Step2: SqlCommand
            // Step3: SqlDataReader
            // Step4: UI Control


            try
            {
                // syntax sugar : using()內當成物件，{}執行完 自動conn.Close();
                // Step1 連線
                SqlConnection conn = null;
                using ( conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    MessageBox.Show(conn.State.ToString());

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
                }// Auto conn.Close();

                MessageBox.Show(conn.State.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 參考加入System.Configuration，並using
            string connstring =ConfigurationManager.ConnectionStrings["WindowsFormsApp2.Properties.Settings.NorthwindConnectionString"].ConnectionString; 
            // Step1: SqlConnection
            // Step2: SqlCommand
            // Step3: SqlDataReader
            // Step4: UI Control


            try
            {
                // syntax sugar : using()內當成物件，{}執行完 自動conn.Close();
                // Step1 連線
                using (SqlConnection conn = new SqlConnection(connstring))
                {
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
                    } // Auto conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connstring = Settings.Default.MyNWConnectionString;
            try
            {
                // syntax sugar : using()內當成物件，{}執行完 自動conn.Close();
                // Step1 連線
                using (SqlConnection conn = new SqlConnection(connstring))
                {
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

                } // Auto conn.Close(), Auto conn.Dispose(); 釋放物件資源(記憶體)
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.MyBackColor = this.tabPage1.BackColor = this.colorDialog1.Color;
                Settings.Default.Save();  // save到config
            }
        }
    }
}

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
using System.Threading;

namespace Starter

{
    public partial class FrmSqlConnection : Form
    {
        public FrmSqlConnection()
        {
            InitializeComponent();
            this.tabPage1.BackColor = Settings.Default.MyBackColor;
            this.tabControl1.SelectedIndex = 1;

            //========================================
            
            for(int i = 0; i < 3; i++)
            {
                string[] city = { "taipei", "taichung", "kaohsiung" };
                LinkLabel x = new LinkLabel();
                x.Text = city[i];
                x.Top =30*i;
                x.Left = 5;
                x.Click += X_Click;
                x.Tag = i;
                this.panel1.Controls.Add(x);
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            // Weak
            //MessageBox.Show(((LinkLabel)sender).Text+" - "+((LinkLabel)sender).Tag); 

            // Strong
            LinkLabel l = sender as LinkLabel;  // 若l轉型不成功，則會是空值，程式不會崩潰
            if(l != null)
            {
                MessageBox.Show(l.Text);
            }
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

        private void button58_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\Source\Repos\melon0307\04_11_Lesson\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
                                                   //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Student\\Source\\Repos\\melon0307\\04_11_Lesson\\WindowsFormsApp2\\Database1.mdf;Integrated Security=True"
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
                    SqlCommand command = new SqlCommand("select * from MyTable", conn);

                    // Step3 傳回SqlDataReader型態的物件
                    SqlDataReader dataReader = command.ExecuteReader();

                    // Step4 輸出在控制項上
                    listBox1.Items.Clear();
                    while (dataReader.Read())   //Read 若有資料則回傳true 反之false 因此使用while 讓他判定並連續回傳
                    {
                        string s = $"{dataReader["User Name"],-20/*給他40個空間，負值為靠左對齊*/} - {dataReader["Password"]}"; // syntax sugar 語法糖 $"" { }括號內都轉string
                                                                                                                      
                        listBox1.Items.Add(s);
                    }

                } // Auto conn.Close(), Auto conn.Dispose(); 釋放物件資源(記憶體)
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"
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
                    SqlCommand command = new SqlCommand("select * from MyTable", conn);

                    // Step3 傳回SqlDataReader型態的物件
                    SqlDataReader dataReader = command.ExecuteReader();

                    // Step4 輸出在控制項上
                    listBox1.Items.Clear();
                    while (dataReader.Read())   //Read 若有資料則回傳true 反之false 因此使用while 讓他判定並連續回傳
                    {
                        string s = $"{dataReader["User Name"],-20/*給他20個空間，負值為靠左對齊*/} - {dataReader["Password"]}"; // syntax sugar 語法糖 $"" { }括號內都轉string

                        listBox1.Items.Add(s);
                    }

                } // Auto conn.Close(), Auto conn.Dispose(); 釋放物件資源(記憶體)
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"
            // Step1: SqlConnection
            // Step2: SqlCommand
            // Step3: SqlDataReader
            // Step4: UI Control

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.AttachDBFilename = Application.StartupPath /*與 |DataDirectory| 相同*/+ @"\Database1.mdf";
            builder.IntegratedSecurity = true;

            try
            {
                // syntax sugar : using()內當成物件，{}執行完 自動conn.Close();
                // Step1 連線
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)) //改成 builder的連接字串
                {
                    conn.Open();

                    // Step2 指令
                    SqlCommand command = new SqlCommand("select * from MyTable", conn);

                    // Step3 傳回SqlDataReader型態的物件
                    SqlDataReader dataReader = command.ExecuteReader();

                    // Step4 輸出在控制項上
                    listBox1.Items.Clear();
                    while (dataReader.Read())   //Read 若有資料則回傳true 反之false 因此使用while 讓他判定並連續回傳
                    {
                        string s = $"{dataReader["User Name"],-20/*給他20個空間，負值為靠左對齊*/} - {dataReader["Password"]}"; // syntax sugar 語法糖 $"" { }括號內都轉string

                        listBox1.Items.Add(s);
                    }

                } // Auto conn.Close(), Auto conn.Dispose(); 釋放物件資源(記憶體)
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connstring = Settings.Default.NorthwindConnectionString;
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
                    conn.StateChange += Conn_StateChange;
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

        private void Conn_StateChange(object sender, StateChangeEventArgs e)
        {
            this.toolStripStatusLabel1.Text = e.CurrentState.ToString();
            // this.statusStrip1.Items[0].Text = e.CurrentState.ToString();
            this.toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
            Application.DoEvents();
            Thread.Sleep(1000);  //單位ms
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.productsTableAdapter1.Connection.ConnectionString);
            this.productsTableAdapter1.Connection.StateChange += Conn_StateChange;

            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView1.DataSource = this.nwDataSet1.Products;
        }
    }
}

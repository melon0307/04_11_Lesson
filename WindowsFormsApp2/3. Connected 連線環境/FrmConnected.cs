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
using WindowsFormsApp2.Properties;

namespace Starter
{
    public partial class FrmConnected : Form
    {
        public FrmConnected()
        {
            InitializeComponent();
            LoadCountryToCombox();
            CreateListViewColumns();
            this.tabControl1.SelectedIndex = 1;
        }

        private void CreateListViewColumns()
        {
            // Select Connected

            this.listView1.View = View.Details;
            SqlConnection conn = null;             
            try
            {                
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conn.Open();                                
                SqlCommand command = new SqlCommand("select * from Customers", conn);                               
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dt = dataReader.GetSchemaTable();
                this.dataGridView1.DataSource = dt;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    this.listView1.Columns.Add(dt.Rows[i][0].ToString());
                }
                this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void LoadCountryToCombox()
        {        
            // Select Connected

            SqlConnection conn = null;             
            try
            {                
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conn.Open();                                
                SqlCommand command = new SqlCommand("select distinct Country from Customers", conn);                               
                SqlDataReader dataReader = command.ExecuteReader();                                
                comboBox1.Items.Clear();
                while (dataReader.Read())   
                {
                   comboBox1.Items.Add(dataReader["Country"]);
                }
                conn.Close();
                comboBox1.Text = "請選擇 ...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Add("xxx");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 // Select Connected

            SqlConnection conn = null;             
            try
            {                
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conn.Open();
                SqlCommand command = new SqlCommand();            //"select * from Customers where Country = 'USA'", conn);
                command.CommandText = $"select * from Customers where Country = '{this.comboBox1.Text}' ";
                command.Connection = conn;

                SqlDataReader dataReader = command.ExecuteReader();
                this.listView1.Items.Clear();
                Random rd = new Random();
                while (dataReader.Read())   
                {                    
                   ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());
                    lvi.ImageIndex = rd.Next(0,this.ImageList1.Images.Count);
                    if(lvi.Index %2 == 0)
                    {
                        lvi.BackColor = Color.SandyBrown;
                    }
                    else
                    {
                        lvi.BackColor = Color.AntiqueWhite;
                    }

                    for(int i = 1; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))     // 判定()內i 是否為null，回傳true/false
                        {
                            lvi.SubItems.Add("N/A");
                        }
                        else
                        {
                             lvi.SubItems.Add(dataReader[i].ToString());
                        }
                       
                    }
                }
                conn.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }

        private void detailsViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
 // Insert Connected

            SqlConnection conn = null;
            
            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;

                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);                                             
                SqlCommand command = new SqlCommand();
                command.CommandText = $"Insert into MyMember(UserName,Password) values('{userName}','{password}')";
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Select();

                MessageBox.Show("Member insert successfully");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
 // Select Connected

            SqlConnection conn = null;
            string userName = this.textBox1.Text;
            string password = this.textBox2.Text;
            try
            {                
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conn.Open();                                
                SqlCommand command = new SqlCommand();
                command.CommandText = $"select * from MyMember where UserName = '{userName}' and Password = '{password}'";
                command.Connection = conn;
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    MessageBox.Show("登入成功");
                }
                else
                {
                    MessageBox.Show("UserName or Password 錯誤");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Select();
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;

                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandText = "Insert into MyMember(UserName,Password) values(@UserName,@Password)";
                command.Connection = conn;

                // 幾個參數分別都要add 格式參考資料表內
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                //SqlParameter p1 = new SqlParameter();
                //p1.ParameterName = "@UserName";
                //p1.SqlDbType = SqlDbType.NVarChar;
                //p1.Size = 16;
                //p1.Value = userName;
                //command.Parameters.Add(p1);

                //SqlParameter p2 = new SqlParameter();
                //p2.ParameterName = "@Password";
                //p2.SqlDbType = SqlDbType.NVarChar;
                //p2.Size = 40;
                //p2.Value = password;
                //command.Parameters.Add(p2);

                conn.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Member insert successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Select();

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string userName = this.textBox1.Text;
            string password = this.textBox2.Text;
            try
            {
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"select * from MyMember where UserName =@UserName and Password = @Password";
                command.Connection = conn;

                // 幾個參數分別都要add 格式參考資料表內
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    MessageBox.Show("登入成功");
                }
                else
                {
                    MessageBox.Show("UserName or Password 錯誤");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Select();
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;

                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                SqlCommand command = new SqlCommand();
                command.CommandText = "InsertMember";     //預存程序的名稱
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure; //設定為預存程序

                // 幾個參數分別都要add 格式參考資料表內
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@Return_Value";
                p1.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(p1);

                conn.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Member insert successfully, MemberID = "+p1.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Select();

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string userName = this.textBox1.Text;
            string password = this.textBox2.Text;
            try
            {
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "MemberLogOn";
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;

                // 幾個參數分別都要add 格式參考資料表內
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    MessageBox.Show("登入成功");
                }
                else
                {
                    MessageBox.Show("UserName or Password 錯誤");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Select();
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

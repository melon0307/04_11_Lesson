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
using System.Web.Security;

namespace Starter
{
    public partial class FrmConnected : Form
    {
        public FrmConnected()
        {
            InitializeComponent();
            LoadCountryToCombox();
            CreateListViewColumns();
            this.tabControl1.SelectedIndex = 3;
            this.listBox4.Visible = false;
            this.pictureBox1.AllowDrop = true;
            this.pictureBox1.DragEnter += PictureBox1_DragEnter;
            this.pictureBox1.DragDrop += PictureBox1_DragDrop;
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
            this.flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;

        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] image = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < image.Length; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(image[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 120;
                pic.Height = 80;
                pic.Click += Pic_Click;
                this.flowLayoutPanel1.Controls.Add(pic);
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.BackgroundImage = ((PictureBox)sender).Image;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Show();
        }

        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
           string[]image =(string[]) e.Data.GetData(DataFormats.FileDrop);
            this.pictureBox1.Image = Image.FromFile(image[0]);
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;
                password = /*System.Web.Security.*/FormsAuthentication.HashPasswordForStoringInConfigFile(password, "sha1");

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
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

                    MessageBox.Show("Member insert successfully, MemberID = " + p1.Value);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.myMemberTableAdapter1.Insert(textBox1.Text, textBox2.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select sum(UnitPrice) from Products";
                    comm.Connection = conn;
                    conn.Open();
                    this.listBox2.Items.Add($"sum UnitPrice =  {comm.ExecuteScalar():c2}");

                    comm.CommandText = "select Max(UnitPrice) from Products";
                    comm.Connection = conn;
                    this.listBox2.Items.Add($"max UnitPrice =  {comm.ExecuteScalar():c2}");

                    comm.CommandText = "select Min(UnitPrice) from Products";
                    comm.Connection = conn;
                    this.listBox2.Items.Add($"min UnitPrice =  {comm.ExecuteScalar():c2}");                    

                    comm.CommandText = "select count(*) from Products";
                    comm.Connection = conn;
                    this.listBox2.Items.Add($"sum UnitPrice =  {comm.ExecuteScalar():c2}");

                    comm.CommandText = "select Avg(UnitPrice) from Products";
                    comm.Connection = conn;
                    this.listBox2.Items.Add($"avg UnitPrice =  {comm.ExecuteScalar():c2}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "select * from Products;select * from Categories"; // 2個指令用分號;隔開
                    comm.Connection = conn;
                    conn.Open();

                    SqlDataReader dataReader = comm.ExecuteReader();
                    while (dataReader.Read())
                    {
                        listBox1.Items.Add(dataReader["ProductName"]);
                    }

                    dataReader.NextResult(); // 讀出下個結果集(Categories)

                    while (dataReader.Read())
                    {
                        listBox2.Items.Add(dataReader["CategoryName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string Sqlcmd = "CREATE TABLE[dbo].[MyImageTable]([ImageID][int] IDENTITY(1, 1) NOT NULL," +
                                            " [Description] [text] NULL," +
                                            "[Image] [image] NULL," +
                                            " CONSTRAINT[PK_MyImageTable] PRIMARY KEY CLUSTERED([ImageID] ASC)" +
                                            "WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY])"+
                                            "ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = Sqlcmd; 
                    comm.Connection = conn;
                    conn.Open();

                    comm.ExecuteNonQuery();
                    MessageBox.Show("Create Table MyImageTable Sucessfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "影像檔案(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|所有檔案(*.*)|*.*";
                                                                                                                            // ↑用分號隔開各個副檔名
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into MyImageTable(Description,Image) values(@Description,@Image)";
                    command.Connection = conn;

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();  //剛好為傳回byte[]

                    command.Parameters.Add("@Description", SqlDbType.Text).Value = textBox4.Text;
                    command.Parameters.Add("@Image", SqlDbType.Image).Value = bytes;

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert MyImageTable successfully");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select * from MyImageTable";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    this.listBox3.Items.Clear();
                    this.listBox4.Items.Clear(); 
                    while (dataReader.Read())
                    {
                        this.listBox3.Items.Add(dataReader["Description"]);
                        this.listBox4.Items.Add(dataReader["ImageID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ImageID = (int)this.listBox4.Items[this.listBox3.SelectedIndex];
            ShowImage(ImageID);
        }

        private void ShowImage(int imageID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from MyImageTable where ImageID = {imageID}";
                    command.Connection = conn;
                    conn.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        byte[] bytes = (byte[])dataReader["Image"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                        this.pictureBox2.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        MessageBox.Show("No record");
                    }
                }
            }
            catch (Exception ex)
            {
                this.pictureBox2.Image = this.pictureBox2.ErrorImage;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select * from MyImageTable";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    this.listBox5.Items.Clear();
                    while (dataReader.Read())
                    {
                        Myimage myimage = new Myimage();
                        myimage.myImageID = (int)dataReader["ImageID"];
                        myimage.myDescription = (string)dataReader["Description"];
                        this.listBox5.Items.Add(myimage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imageID = ((Myimage)this.listBox5.SelectedItem).myImageID;
            ShowImage(imageID);
        }
    }
}
class Myimage:Object
{
    internal int myImageID;
    internal string myDescription;
    public override string ToString() // 此方法為父類別Object
    {
        return this.myDescription;
    }
}

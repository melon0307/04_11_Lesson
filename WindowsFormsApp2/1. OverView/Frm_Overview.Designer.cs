
namespace WindowsFormsApp2._1._OverView
{
    partial class Frm_Overview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDisConnectedProducts = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnConnected = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.productsTableAdapter1 = new WindowsFormsApp2.NWDataSetTableAdapters.ProductsTableAdapter();
            this.nwDataSet1 = new WindowsFormsApp2.NWDataSet();
            this.button4 = new System.Windows.Forms.Button();
            this.categoriesTableAdapter1 = new WindowsFormsApp2.NWDataSetTableAdapters.CategoriesTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nwDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisConnectedProducts
            // 
            this.btnDisConnectedProducts.Location = new System.Drawing.Point(28, 51);
            this.btnDisConnectedProducts.Name = "btnDisConnectedProducts";
            this.btnDisConnectedProducts.Size = new System.Drawing.Size(140, 51);
            this.btnDisConnectedProducts.TabIndex = 1;
            this.btnDisConnectedProducts.Text = "DisConnected - Products";
            this.btnDisConnectedProducts.UseVisualStyleBackColor = true;
            this.btnDisConnectedProducts.Click += new System.EventHandler(this.btnDisConnected_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Items.AddRange(new object[] {
            "aaa",
            "bbb",
            "ccc"});
            this.listBox1.Location = new System.Drawing.Point(279, 140);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(630, 194);
            this.listBox1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1014, 607);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnConnected);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1006, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connected";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.btnDisConnectedProducts);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1006, 581);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DisConnected SetData";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnConnected
            // 
            this.btnConnected.Location = new System.Drawing.Point(37, 112);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.Size = new System.Drawing.Size(117, 51);
            this.btnConnected.TabIndex = 3;
            this.btnConnected.Text = "Connected";
            this.btnConnected.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(225, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(678, 198);
            this.dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "DisConnected - Categories";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "DisConnected - UnitPrice >30";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(28, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(875, 10);
            this.label1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 292);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 51);
            this.button3.TabIndex = 6;
            this.button3.Text = "DisConnected - Products";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(225, 292);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(678, 198);
            this.dataGridView2.TabIndex = 7;
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // nwDataSet1
            // 
            this.nwDataSet1.DataSetName = "NWDataSet";
            this.nwDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 349);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 51);
            this.button4.TabIndex = 8;
            this.button4.Text = "DisConnected - Categories";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // categoriesTableAdapter1
            // 
            this.categoriesTableAdapter1.ClearBeforeFill = true;
            // 
            // Frm_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 607);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Overview";
            this.Text = "Frm_Overview";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nwDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDisConnectedProducts;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnConnected;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button3;
        private NWDataSetTableAdapters.ProductsTableAdapter productsTableAdapter1;
        private NWDataSet nwDataSet1;
        private System.Windows.Forms.Button button4;
        private NWDataSetTableAdapters.CategoriesTableAdapter categoriesTableAdapter1;
    }
}
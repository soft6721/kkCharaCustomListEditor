namespace kkCharaCustomListEditor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCategoryId;
        private System.Windows.Forms.TextBox txtUnknownNumber;
        private System.Windows.Forms.TextBox txtUnknownString;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.Label lblUnknownNumber;
        private System.Windows.Forms.Label lblUnknownString;
        private System.Windows.Forms.Button btnAddRow;

        private void InitializeComponent()
        {
            cmbCategoryId = new ComboBox();
            txtUnknownNumber = new TextBox();
            txtUnknownString = new TextBox();
            lblCategoryId = new Label();
            lblUnknownNumber = new Label();
            lblUnknownString = new Label();
            dataGridView1 = new DataGridView();
            btnLoad = new Button();
            btnSave = new Button();
            btnAddRow = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cmbCategoryId
            // 
            cmbCategoryId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryId.Location = new Point(80, 12);
            cmbCategoryId.Name = "cmbCategoryId";
            cmbCategoryId.Size = new Size(150, 28);
            cmbCategoryId.TabIndex = 1;
            // 
            // txtUnknownNumber
            // 
            txtUnknownNumber.Location = new Point(80, 38);
            txtUnknownNumber.Name = "txtUnknownNumber";
            txtUnknownNumber.Size = new Size(150, 27);
            txtUnknownNumber.TabIndex = 3;
            // 
            // txtUnknownString
            // 
            txtUnknownString.Location = new Point(80, 64);
            txtUnknownString.Name = "txtUnknownString";
            txtUnknownString.Size = new Size(400, 27);
            txtUnknownString.TabIndex = 5;
            // 
            // lblCategoryId
            // 
            lblCategoryId.AutoSize = true;
            lblCategoryId.Location = new Point(12, 15);
            lblCategoryId.Name = "lblCategoryId";
            lblCategoryId.Size = new Size(70, 20);
            lblCategoryId.TabIndex = 0;
            lblCategoryId.Text = "カテゴリID:";
            // 
            // lblUnknownNumber
            // 
            lblUnknownNumber.AutoSize = true;
            lblUnknownNumber.Location = new Point(12, 41);
            lblUnknownNumber.Name = "lblUnknownNumber";
            lblUnknownNumber.Size = new Size(72, 20);
            lblUnknownNumber.TabIndex = 2;
            lblUnknownNumber.Text = "不明数値:";
            // 
            // lblUnknownString
            // 
            lblUnknownString.AutoSize = true;
            lblUnknownString.Location = new Point(12, 67);
            lblUnknownString.Name = "lblUnknownString";
            lblUnknownString.Size = new Size(87, 20);
            lblUnknownString.TabIndex = 4;
            lblUnknownString.Text = "不明文字列:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 350);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(500, 62);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "読み込み";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(580, 62);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "保存";
            btnSave.Click += btnSave_Click;
            // 
            // btnAddRow
            // 
            btnAddRow.Location = new Point(660, 62);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(75, 23);
            btnAddRow.TabIndex = 9;
            btnAddRow.Text = "追加";
            btnAddRow.Click += btnAddRow_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(lblCategoryId);
            Controls.Add(cmbCategoryId);
            Controls.Add(lblUnknownNumber);
            Controls.Add(txtUnknownNumber);
            Controls.Add(lblUnknownString);
            Controls.Add(txtUnknownString);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnAddRow);
            Name = "MainForm";
            Text = "KK Characustom CSV Editor";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

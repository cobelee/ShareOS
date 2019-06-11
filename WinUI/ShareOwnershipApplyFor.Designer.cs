namespace WinUI
{
    partial class ShareOwnershipApplyFor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbbIssueNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvShareOwnershipApply = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnApplyFor = new System.Windows.Forms.Button();
            this.tbShareholderNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnershipApply)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbIssueNumber
            // 
            this.cbbIssueNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbIssueNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIssueNumber.FormattingEnabled = true;
            this.cbbIssueNumber.Location = new System.Drawing.Point(544, 108);
            this.cbbIssueNumber.Name = "cbbIssueNumber";
            this.cbbIssueNumber.Size = new System.Drawing.Size(121, 20);
            this.cbbIssueNumber.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "股权交易期数：";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(654, 83);
            this.textBox1.TabIndex = 6;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "　　该窗口主要实现股东申请受让股权份额数据的采集工作。\r\n　　股东管理办公室下发《股权受让申请表》后，股东根据实据情况，向股东管理办公室提出股权受让申请。股东管理" +
                "办公室根据反馈的《股权受让申请表》，将数据录入系统。\r\n　　本系统支持条形码扫描录入。将输入光标置于股东号输入文本框后，用条形码扫描枪对准《股权受让申请表》上的" +
                "股东号条形码采集股东号。系统会可能自动弹出股权受让申请文本框。\r\n";
            // 
            // dgvShareOwnershipApply
            // 
            this.dgvShareOwnershipApply.AllowUserToAddRows = false;
            this.dgvShareOwnershipApply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShareOwnershipApply.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShareOwnershipApply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareOwnershipApply.Location = new System.Drawing.Point(6, 55);
            this.dgvShareOwnershipApply.MultiSelect = false;
            this.dgvShareOwnershipApply.Name = "dgvShareOwnershipApply";
            this.dgvShareOwnershipApply.ReadOnly = true;
            this.dgvShareOwnershipApply.RowTemplate.Height = 23;
            this.dgvShareOwnershipApply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShareOwnershipApply.Size = new System.Drawing.Size(403, 270);
            this.dgvShareOwnershipApply.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbMessage);
            this.groupBox1.Controls.Add(this.btnApplyFor);
            this.groupBox1.Controls.Add(this.tbShareholderNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(433, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 169);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增股权受让申请";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbMessage.Location = new System.Drawing.Point(16, 20);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(65, 12);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "[提示信息]";
            // 
            // btnApplyFor
            // 
            this.btnApplyFor.Location = new System.Drawing.Point(48, 119);
            this.btnApplyFor.Name = "btnApplyFor";
            this.btnApplyFor.Size = new System.Drawing.Size(136, 23);
            this.btnApplyFor.TabIndex = 2;
            this.btnApplyFor.Text = "股权受让申请";
            this.btnApplyFor.UseVisualStyleBackColor = true;
            this.btnApplyFor.Click += new System.EventHandler(this.btnApplyFor_Click);
            // 
            // tbShareholderNumber
            // 
            this.tbShareholderNumber.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbShareholderNumber.Location = new System.Drawing.Point(75, 75);
            this.tbShareholderNumber.Name = "tbShareholderNumber";
            this.tbShareholderNumber.Size = new System.Drawing.Size(131, 21);
            this.tbShareholderNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "股东号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExportToExcel);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.dgvShareOwnershipApply);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 331);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "股权受让申请记录表";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Location = new System.Drawing.Point(273, 20);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(136, 23);
            this.btnExportToExcel.TabIndex = 11;
            this.btnExportToExcel.Text = "导出汇总文件(&E)";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "撤销股权受让申请";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.FileName = "股权受让申请汇总表";
            this.saveFileDialog1.Filter = "Excel 97-2003 工作簿(*.xls)|*.xls|CSV文件 逗号分隔(*.csv)|*.csv|XML 数据(*.xml)|*.xml";
            // 
            // ShareOwnershipApplyFor
            // 
            this.AcceptButton = this.btnApplyFor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbbIssueNumber);
            this.Controls.Add(this.label1);
            this.Name = "ShareOwnershipApplyFor";
            this.Text = "股权受让申请管理";
            this.Load += new System.EventHandler(this.ShareOwnershipApplyFor_Load);
            this.Shown += new System.EventHandler(this.ShareOwnershipApplyFor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnershipApply)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbIssueNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvShareOwnershipApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApplyFor;
        private System.Windows.Forms.TextBox tbShareholderNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExportToExcel;
    }
}
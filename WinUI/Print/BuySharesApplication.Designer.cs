namespace WinUI.Print
{
    partial class BuySharesApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuySharesApplication));
            this.cbbIssueNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvShareOwnership = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnership)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbIssueNumber
            // 
            this.cbbIssueNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIssueNumber.FormattingEnabled = true;
            this.cbbIssueNumber.Location = new System.Drawing.Point(107, 73);
            this.cbbIssueNumber.Name = "cbbIssueNumber";
            this.cbbIssueNumber.Size = new System.Drawing.Size(121, 20);
            this.cbbIssueNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
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
            this.textBox1.Size = new System.Drawing.Size(615, 49);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "《股权受让申请表》由股东管理办公室下发，股东申请受让股权的依据。股东管理办公室凭此采集股东申请受让股权数据。";
            // 
            // dgvShareOwnership
            // 
            this.dgvShareOwnership.AllowUserToAddRows = false;
            this.dgvShareOwnership.AllowUserToDeleteRows = false;
            this.dgvShareOwnership.AllowUserToOrderColumns = true;
            this.dgvShareOwnership.AllowUserToResizeRows = false;
            this.dgvShareOwnership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShareOwnership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareOwnership.Location = new System.Drawing.Point(14, 99);
            this.dgvShareOwnership.Name = "dgvShareOwnership";
            this.dgvShareOwnership.ReadOnly = true;
            this.dgvShareOwnership.RowTemplate.Height = 23;
            this.dgvShareOwnership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShareOwnership.Size = new System.Drawing.Size(507, 322);
            this.dgvShareOwnership.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(527, 99);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 41);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印股权受让\r\n申请表(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(234, 71);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // BuySharesApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 433);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvShareOwnership);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbbIssueNumber);
            this.Controls.Add(this.label1);
            this.Name = "BuySharesApplication";
            this.Text = "打印股权受让申请表";
            this.Load += new System.EventHandler(this.BuySharesApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnership)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbIssueNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvShareOwnership;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnQuery;
    }
}
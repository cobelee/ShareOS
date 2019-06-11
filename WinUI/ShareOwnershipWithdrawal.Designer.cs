namespace WinUI
{
    partial class ShareOwnershipWithdrawal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareOwnershipWithdrawal));
            this.dgvShareOwnership = new System.Windows.Forms.DataGridView();
            this.cbCurrentYear = new System.Windows.Forms.CheckBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lbHistoryYear = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPreviewPersonWithdrawalReport = new System.Windows.Forms.Button();
            this.btnMultPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lbWithdrawTotals = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnership)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShareOwnership
            // 
            this.dgvShareOwnership.AllowUserToAddRows = false;
            this.dgvShareOwnership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShareOwnership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareOwnership.Location = new System.Drawing.Point(12, 95);
            this.dgvShareOwnership.Name = "dgvShareOwnership";
            this.dgvShareOwnership.ReadOnly = true;
            this.dgvShareOwnership.RowTemplate.Height = 23;
            this.dgvShareOwnership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShareOwnership.Size = new System.Drawing.Size(522, 325);
            this.dgvShareOwnership.TabIndex = 0;
            // 
            // cbCurrentYear
            // 
            this.cbCurrentYear.AutoSize = true;
            this.cbCurrentYear.Checked = true;
            this.cbCurrentYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCurrentYear.Location = new System.Drawing.Point(74, 29);
            this.cbCurrentYear.Name = "cbCurrentYear";
            this.cbCurrentYear.Size = new System.Drawing.Size(72, 16);
            this.cbCurrentYear.TabIndex = 1;
            this.cbCurrentYear.Text = "当前年份";
            this.cbCurrentYear.UseVisualStyleBackColor = true;
            this.cbCurrentYear.CheckedChanged += new System.EventHandler(this.cbCurrentYear_CheckedChanged);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Enabled = false;
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(247, 29);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(63, 21);
            this.dtpYear.TabIndex = 2;
            // 
            // lbHistoryYear
            // 
            this.lbHistoryYear.AutoSize = true;
            this.lbHistoryYear.Location = new System.Drawing.Point(176, 33);
            this.lbHistoryYear.Name = "lbHistoryYear";
            this.lbHistoryYear.Size = new System.Drawing.Size(65, 12);
            this.lbHistoryYear.TabIndex = 3;
            this.lbHistoryYear.Text = "历史年份：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(349, 28);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "股权退出人员列表";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(556, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "股权退出(&W)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(556, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "撤销退出(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(556, 209);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(133, 46);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "打印股权退出\r\n个人清算报告";
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
            // btnPreviewPersonWithdrawalReport
            // 
            this.btnPreviewPersonWithdrawalReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewPersonWithdrawalReport.Location = new System.Drawing.Point(556, 272);
            this.btnPreviewPersonWithdrawalReport.Name = "btnPreviewPersonWithdrawalReport";
            this.btnPreviewPersonWithdrawalReport.Size = new System.Drawing.Size(133, 46);
            this.btnPreviewPersonWithdrawalReport.TabIndex = 9;
            this.btnPreviewPersonWithdrawalReport.Text = "预览股权退出\r\n个人清算报告";
            this.btnPreviewPersonWithdrawalReport.UseVisualStyleBackColor = true;
            this.btnPreviewPersonWithdrawalReport.Click += new System.EventHandler(this.btnPreviewPersonWithdrawalReport_Click);
            // 
            // btnMultPrint
            // 
            this.btnMultPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultPrint.Location = new System.Drawing.Point(556, 341);
            this.btnMultPrint.Name = "btnMultPrint";
            this.btnMultPrint.Size = new System.Drawing.Size(133, 32);
            this.btnMultPrint.TabIndex = 10;
            this.btnMultPrint.Text = "批量打印(&P)";
            this.btnMultPrint.UseVisualStyleBackColor = true;
            this.btnMultPrint.Click += new System.EventHandler(this.btnMultPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "当年退出股权总数：";
            // 
            // lbWithdrawTotals
            // 
            this.lbWithdrawTotals.AutoSize = true;
            this.lbWithdrawTotals.Location = new System.Drawing.Point(336, 80);
            this.lbWithdrawTotals.Name = "lbWithdrawTotals";
            this.lbWithdrawTotals.Size = new System.Drawing.Size(29, 12);
            this.lbWithdrawTotals.TabIndex = 12;
            this.lbWithdrawTotals.Text = "0.00";
            // 
            // ShareOwnershipWithdrawal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 444);
            this.Controls.Add(this.lbWithdrawTotals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMultPrint);
            this.Controls.Add(this.btnPreviewPersonWithdrawalReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lbHistoryYear);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.cbCurrentYear);
            this.Controls.Add(this.dgvShareOwnership);
            this.Name = "ShareOwnershipWithdrawal";
            this.Text = "股权退出";
            this.Load += new System.EventHandler(this.ShareOwnershipWithdrawal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnership)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShareOwnership;
        private System.Windows.Forms.CheckBox cbCurrentYear;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lbHistoryYear;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnPreviewPersonWithdrawalReport;
        private System.Windows.Forms.Button btnMultPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbWithdrawTotals;
    }
}
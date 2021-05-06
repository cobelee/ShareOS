namespace WinUI.Print
{
    partial class InvestmentCertification
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbIssueNumber = new System.Windows.Forms.ComboBox();
            this.dgvShareholder = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.cbHideBonus = new System.Windows.Forms.CheckBox();
            this.lbIssue = new System.Windows.Forms.Label();
            this.btnSortDep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareholder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股权交易期数：";
            // 
            // cbbIssueNumber
            // 
            this.cbbIssueNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIssueNumber.FormattingEnabled = true;
            this.cbbIssueNumber.Location = new System.Drawing.Point(107, 6);
            this.cbbIssueNumber.Name = "cbbIssueNumber";
            this.cbbIssueNumber.Size = new System.Drawing.Size(121, 20);
            this.cbbIssueNumber.TabIndex = 1;
            this.cbbIssueNumber.SelectedIndexChanged += new System.EventHandler(this.cbbIssueNumber_SelectedIndexChanged);
            // 
            // dgvShareholder
            // 
            this.dgvShareholder.AllowUserToAddRows = false;
            this.dgvShareholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShareholder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareholder.Location = new System.Drawing.Point(14, 32);
            this.dgvShareholder.Name = "dgvShareholder";
            this.dgvShareholder.ReadOnly = true;
            this.dgvShareholder.RowTemplate.Height = 23;
            this.dgvShareholder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShareholder.Size = new System.Drawing.Size(944, 516);
            this.dgvShareholder.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(964, 32);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSort.Location = new System.Drawing.Point(807, 3);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(151, 23);
            this.btnSort.TabIndex = 4;
            this.btnSort.Text = "先代理人，后部门排序";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // cbHideBonus
            // 
            this.cbHideBonus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHideBonus.AutoSize = true;
            this.cbHideBonus.Location = new System.Drawing.Point(501, 8);
            this.cbHideBonus.Name = "cbHideBonus";
            this.cbHideBonus.Size = new System.Drawing.Size(144, 16);
            this.cbHideBonus.TabIndex = 5;
            this.cbHideBonus.Text = "隐藏红股全部转让的人";
            this.cbHideBonus.UseVisualStyleBackColor = true;
            this.cbHideBonus.CheckedChanged += new System.EventHandler(this.cbHideBonus_CheckedChanged);
            // 
            // lbIssue
            // 
            this.lbIssue.AutoSize = true;
            this.lbIssue.Location = new System.Drawing.Point(235, 11);
            this.lbIssue.Name = "lbIssue";
            this.lbIssue.Size = new System.Drawing.Size(59, 12);
            this.lbIssue.TabIndex = 6;
            this.lbIssue.Text = "[lbIssue]";
            // 
            // btnSortDep
            // 
            this.btnSortDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortDep.Location = new System.Drawing.Point(651, 3);
            this.btnSortDep.Name = "btnSortDep";
            this.btnSortDep.Size = new System.Drawing.Size(150, 23);
            this.btnSortDep.TabIndex = 7;
            this.btnSortDep.Text = "先部门，后代理人排序";
            this.btnSortDep.UseVisualStyleBackColor = true;
            this.btnSortDep.Click += new System.EventHandler(this.btnSortDep_Click);
            // 
            // InvestmentCertification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 560);
            this.Controls.Add(this.btnSortDep);
            this.Controls.Add(this.lbIssue);
            this.Controls.Add(this.cbHideBonus);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvShareholder);
            this.Controls.Add(this.cbbIssueNumber);
            this.Controls.Add(this.label1);
            this.Name = "InvestmentCertification";
            this.RightToLeftLayout = true;
            this.Text = "打印出资证明书";
            this.Load += new System.EventHandler(this.InvestmentCertification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareholder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbIssueNumber;
        private System.Windows.Forms.DataGridView dgvShareholder;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.CheckBox cbHideBonus;
        private System.Windows.Forms.Label lbIssue;
        private System.Windows.Forms.Button btnSortDep;
    }
}
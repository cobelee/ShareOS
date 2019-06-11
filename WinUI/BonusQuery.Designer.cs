namespace WinUI
{
    partial class BonusQuery
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvBonusRecord = new System.Windows.Forms.DataGridView();
            this.btnPersonal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusRecord)).BeginInit();
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
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(234, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvBonusRecord
            // 
            this.dgvBonusRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBonusRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusRecord.Location = new System.Drawing.Point(12, 32);
            this.dgvBonusRecord.MultiSelect = false;
            this.dgvBonusRecord.Name = "dgvBonusRecord";
            this.dgvBonusRecord.ReadOnly = true;
            this.dgvBonusRecord.RowTemplate.Height = 23;
            this.dgvBonusRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonusRecord.Size = new System.Drawing.Size(345, 280);
            this.dgvBonusRecord.TabIndex = 3;
            // 
            // btnPersonal
            // 
            this.btnPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonal.Location = new System.Drawing.Point(363, 32);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(140, 23);
            this.btnPersonal.TabIndex = 4;
            this.btnPersonal.Text = "查询个人分红记录(&P)";
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // BonusQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 324);
            this.Controls.Add(this.btnPersonal);
            this.Controls.Add(this.dgvBonusRecord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.cbbIssueNumber);
            this.Controls.Add(this.label1);
            this.Name = "BonusQuery";
            this.Text = "分红记录查询";
            this.Load += new System.EventHandler(this.BonusQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbIssueNumber;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvBonusRecord;
        private System.Windows.Forms.Button btnPersonal;
    }
}
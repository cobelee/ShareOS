namespace WinUI
{
    partial class ShareOwnershipManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareOwnershipManage));
            this.dgvShareOwnership = new System.Windows.Forms.DataGridView();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnHistoryRecord = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnBuyShareOwnership = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnership)).BeginInit();
            this.SuspendLayout();
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
            this.dgvShareOwnership.Location = new System.Drawing.Point(12, 12);
            this.dgvShareOwnership.Name = "dgvShareOwnership";
            this.dgvShareOwnership.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = "RowIndex";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShareOwnership.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShareOwnership.RowTemplate.Height = 23;
            this.dgvShareOwnership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShareOwnership.Size = new System.Drawing.Size(386, 368);
            this.dgvShareOwnership.TabIndex = 0;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncrease.Location = new System.Drawing.Point(404, 12);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(100, 23);
            this.btnIncrease.TabIndex = 1;
            this.btnIncrease.Text = "股权增持(&I)";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrease.Location = new System.Drawing.Point(404, 41);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(100, 23);
            this.btnDecrease.TabIndex = 2;
            this.btnDecrease.Text = "退股(&D)";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnHistoryRecord
            // 
            this.btnHistoryRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoryRecord.Location = new System.Drawing.Point(404, 184);
            this.btnHistoryRecord.Name = "btnHistoryRecord";
            this.btnHistoryRecord.Size = new System.Drawing.Size(100, 23);
            this.btnHistoryRecord.TabIndex = 3;
            this.btnHistoryRecord.Text = "历史记录(&Q)";
            this.btnHistoryRecord.UseVisualStyleBackColor = true;
            this.btnHistoryRecord.Click += new System.EventHandler(this.btnHistoryRecord_Click);
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
            // btnBuyShareOwnership
            // 
            this.btnBuyShareOwnership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuyShareOwnership.Location = new System.Drawing.Point(404, 90);
            this.btnBuyShareOwnership.Name = "btnBuyShareOwnership";
            this.btnBuyShareOwnership.Size = new System.Drawing.Size(100, 23);
            this.btnBuyShareOwnership.TabIndex = 5;
            this.btnBuyShareOwnership.Text = "购买股权(&B)";
            this.btnBuyShareOwnership.UseVisualStyleBackColor = true;
            this.btnBuyShareOwnership.Click += new System.EventHandler(this.btnBuyShareOwnership_Click);
            // 
            // ShareOwnershipManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 392);
            this.Controls.Add(this.btnBuyShareOwnership);
            this.Controls.Add(this.btnHistoryRecord);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.dgvShareOwnership);
            this.Name = "ShareOwnershipManage";
            this.Text = "股权管理";
            this.Load += new System.EventHandler(this.ShareOwnershipManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareOwnership)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShareOwnership;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnHistoryRecord;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnBuyShareOwnership;
    }
}
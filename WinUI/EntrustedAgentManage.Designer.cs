namespace WinUI
{
    partial class EntrustedAgentManage
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
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetAgent = new System.Windows.Forms.Button();
            this.btnCancelAgent = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvShareholder = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvEntrustedAgent = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareholder)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrustedAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "可选股东";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "受权委托代理人：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 314);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelAgent);
            this.panel1.Controls.Add(this.btnSetAgent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(217, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 308);
            this.panel1.TabIndex = 4;
            // 
            // btnSetAgent
            // 
            this.btnSetAgent.Location = new System.Drawing.Point(24, 63);
            this.btnSetAgent.Name = "btnSetAgent";
            this.btnSetAgent.Size = new System.Drawing.Size(75, 23);
            this.btnSetAgent.TabIndex = 0;
            this.btnSetAgent.Text = ">";
            this.btnSetAgent.UseVisualStyleBackColor = true;
            this.btnSetAgent.Click += new System.EventHandler(this.btnSetAgent_Click);
            // 
            // btnCancelAgent
            // 
            this.btnCancelAgent.Location = new System.Drawing.Point(26, 124);
            this.btnCancelAgent.Name = "btnCancelAgent";
            this.btnCancelAgent.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAgent.TabIndex = 1;
            this.btnCancelAgent.Text = "<";
            this.btnCancelAgent.UseVisualStyleBackColor = true;
            this.btnCancelAgent.Click += new System.EventHandler(this.btnCancelAgent_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvShareholder);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 308);
            this.panel2.TabIndex = 5;
            // 
            // dgvShareholder
            // 
            this.dgvShareholder.AllowUserToAddRows = false;
            this.dgvShareholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShareholder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShareholder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareholder.Location = new System.Drawing.Point(3, 63);
            this.dgvShareholder.Name = "dgvShareholder";
            this.dgvShareholder.ReadOnly = true;
            this.dgvShareholder.RowTemplate.Height = 23;
            this.dgvShareholder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShareholder.Size = new System.Drawing.Size(202, 242);
            this.dgvShareholder.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvEntrustedAgent);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(347, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 308);
            this.panel3.TabIndex = 6;
            // 
            // dgvEntrustedAgent
            // 
            this.dgvEntrustedAgent.AllowUserToAddRows = false;
            this.dgvEntrustedAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntrustedAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntrustedAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrustedAgent.Location = new System.Drawing.Point(3, 63);
            this.dgvEntrustedAgent.Name = "dgvEntrustedAgent";
            this.dgvEntrustedAgent.ReadOnly = true;
            this.dgvEntrustedAgent.RowTemplate.Height = 23;
            this.dgvEntrustedAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntrustedAgent.Size = new System.Drawing.Size(202, 242);
            this.dgvEntrustedAgent.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "姓名筛选：";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(80, 10);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(125, 21);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // EntrustedAgentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EntrustedAgentManage";
            this.Text = "委托代理人管理";
            this.Load += new System.EventHandler(this.EntrustedAgentManage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareholder)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrustedAgent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelAgent;
        private System.Windows.Forms.Button btnSetAgent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvShareholder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvEntrustedAgent;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
    }
}
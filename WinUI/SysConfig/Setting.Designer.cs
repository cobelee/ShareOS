namespace ShareOS.SysConfig
{
    partial class SettingMain
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
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.gvAccount = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbTrueName = new System.Windows.Forms.TextBox();
            this.lbTrueName = new System.Windows.Forms.Label();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.tbPassword2 = new System.Windows.Forms.TextBox();
            this.lbPassword2 = new System.Windows.Forms.Label();
            this.tbPassword1 = new System.Windows.Forms.TextBox();
            this.lbPassword1 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.gvAccount);
            this.tabAccount.Controls.Add(this.panel5);
            this.tabAccount.Controls.Add(this.panel2);
            this.tabAccount.Location = new System.Drawing.Point(4, 21);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(614, 334);
            this.tabAccount.TabIndex = 3;
            this.tabAccount.Text = "系统账户";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // gvAccount
            // 
            this.gvAccount.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvAccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAccount.GridColor = System.Drawing.SystemColors.ControlText;
            this.gvAccount.Location = new System.Drawing.Point(3, 90);
            this.gvAccount.MultiSelect = false;
            this.gvAccount.Name = "gvAccount";
            this.gvAccount.ReadOnly = true;
            this.gvAccount.RowHeadersVisible = false;
            this.gvAccount.RowTemplate.Height = 23;
            this.gvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAccount.Size = new System.Drawing.Size(608, 184);
            this.gvAccount.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnUpdateAccount);
            this.panel5.Controls.Add(this.btnDeleteAccount);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 274);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(608, 57);
            this.panel5.TabIndex = 4;
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Location = new System.Drawing.Point(14, 17);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(185, 23);
            this.btnUpdateAccount.TabIndex = 2;
            this.btnUpdateAccount.Text = "重置密码(&E)（暂时未实现）";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(238, 17);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteAccount.TabIndex = 3;
            this.btnDeleteAccount.Text = "删除账户(&D)";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbTrueName);
            this.panel2.Controls.Add(this.lbTrueName);
            this.panel2.Controls.Add(this.btnAddAccount);
            this.panel2.Controls.Add(this.tbPassword2);
            this.panel2.Controls.Add(this.lbPassword2);
            this.panel2.Controls.Add(this.tbPassword1);
            this.panel2.Controls.Add(this.lbPassword1);
            this.panel2.Controls.Add(this.tbUserName);
            this.panel2.Controls.Add(this.lbUserName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 87);
            this.panel2.TabIndex = 1;
            // 
            // tbTrueName
            // 
            this.tbTrueName.Location = new System.Drawing.Point(80, 48);
            this.tbTrueName.Name = "tbTrueName";
            this.tbTrueName.Size = new System.Drawing.Size(100, 21);
            this.tbTrueName.TabIndex = 10;
            // 
            // lbTrueName
            // 
            this.lbTrueName.AutoSize = true;
            this.lbTrueName.Location = new System.Drawing.Point(11, 51);
            this.lbTrueName.Name = "lbTrueName";
            this.lbTrueName.Size = new System.Drawing.Size(65, 12);
            this.lbTrueName.TabIndex = 9;
            this.lbTrueName.Text = "真实姓名：";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(479, 48);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccount.TabIndex = 6;
            this.btnAddAccount.Text = "添加账户";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // tbPassword2
            // 
            this.tbPassword2.Location = new System.Drawing.Point(295, 48);
            this.tbPassword2.Name = "tbPassword2";
            this.tbPassword2.Size = new System.Drawing.Size(100, 21);
            this.tbPassword2.TabIndex = 5;
            // 
            // lbPassword2
            // 
            this.lbPassword2.AutoSize = true;
            this.lbPassword2.Location = new System.Drawing.Point(224, 51);
            this.lbPassword2.Name = "lbPassword2";
            this.lbPassword2.Size = new System.Drawing.Size(65, 12);
            this.lbPassword2.TabIndex = 4;
            this.lbPassword2.Text = "确认密码：";
            // 
            // tbPassword1
            // 
            this.tbPassword1.Location = new System.Drawing.Point(295, 11);
            this.tbPassword1.Name = "tbPassword1";
            this.tbPassword1.Size = new System.Drawing.Size(100, 21);
            this.tbPassword1.TabIndex = 3;
            // 
            // lbPassword1
            // 
            this.lbPassword1.AutoSize = true;
            this.lbPassword1.Location = new System.Drawing.Point(224, 14);
            this.lbPassword1.Name = "lbPassword1";
            this.lbPassword1.Size = new System.Drawing.Size(65, 12);
            this.lbPassword1.TabIndex = 2;
            this.lbPassword1.Text = "输入密码：";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(80, 11);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 1;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(11, 14);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(53, 12);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "用户名：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAccount);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 359);
            this.tabControl1.TabIndex = 1;
            // 
            // SettingMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 359);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingMain";
            this.Text = "镇海石化工业贸易有限责任公司补充医保报销系统－－－系统设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.DataGridView gvAccount;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbTrueName;
        private System.Windows.Forms.Label lbTrueName;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.TextBox tbPassword2;
        private System.Windows.Forms.Label lbPassword2;
        private System.Windows.Forms.TextBox tbPassword1;
        private System.Windows.Forms.Label lbPassword1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TabControl tabControl1;

    }
}
namespace WinUI
{
    partial class PersonalBonusRecord
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPersonType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbIdentityCard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbShareholderNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBouns = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBouns)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbPersonType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbIdentityCard);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbSex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbShareholderNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 78);
            this.panel1.TabIndex = 3;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(288, 50);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(53, 12);
            this.lbStatus.TabIndex = 11;
            this.lbStatus.Text = "[Status]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "股东状态：";
            // 
            // lbPersonType
            // 
            this.lbPersonType.AutoSize = true;
            this.lbPersonType.Location = new System.Drawing.Point(69, 50);
            this.lbPersonType.Name = "lbPersonType";
            this.lbPersonType.Size = new System.Drawing.Size(77, 12);
            this.lbPersonType.TabIndex = 9;
            this.lbPersonType.Text = "[PersonType]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "人员类别：";
            // 
            // lbIdentityCard
            // 
            this.lbIdentityCard.AutoSize = true;
            this.lbIdentityCard.Location = new System.Drawing.Point(288, 25);
            this.lbIdentityCard.Name = "lbIdentityCard";
            this.lbIdentityCard.Size = new System.Drawing.Size(89, 12);
            this.lbIdentityCard.TabIndex = 7;
            this.lbIdentityCard.Text = "[IdentityCard]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "身份证号：";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(45, 26);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(35, 12);
            this.lbSex.TabIndex = 5;
            this.lbSex.Text = "[Sex]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别：";
            // 
            // lbShareholderNumber
            // 
            this.lbShareholderNumber.AutoSize = true;
            this.lbShareholderNumber.Location = new System.Drawing.Point(288, 0);
            this.lbShareholderNumber.Name = "lbShareholderNumber";
            this.lbShareholderNumber.Size = new System.Drawing.Size(119, 12);
            this.lbShareholderNumber.TabIndex = 3;
            this.lbShareholderNumber.Text = "[ShareholderNumber]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "股东号：";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(45, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(53, 12);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "[lbName]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // dgvBouns
            // 
            this.dgvBouns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBouns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBouns.Location = new System.Drawing.Point(12, 96);
            this.dgvBouns.MultiSelect = false;
            this.dgvBouns.Name = "dgvBouns";
            this.dgvBouns.ReadOnly = true;
            this.dgvBouns.RowTemplate.Height = 23;
            this.dgvBouns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBouns.Size = new System.Drawing.Size(515, 281);
            this.dgvBouns.TabIndex = 4;
            // 
            // PersonalBonusRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 389);
            this.Controls.Add(this.dgvBouns);
            this.Controls.Add(this.panel1);
            this.Name = "PersonalBonusRecord";
            this.Text = "PersonalBonusRecord";
            this.Load += new System.EventHandler(this.PersonalBonusRecord_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBouns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPersonType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbIdentityCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbShareholderNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBouns;
    }
}
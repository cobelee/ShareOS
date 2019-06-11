namespace WinUI.Dialog
{
    partial class AddShareholder
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudShareholderNumber = new System.Windows.Forms.NumericUpDown();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbJobNumber = new System.Windows.Forms.TextBox();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.tbIdentityCard = new System.Windows.Forms.TextBox();
            this.rbtnIsNotShare = new System.Windows.Forms.RadioButton();
            this.rbtnIsShare = new System.Windows.Forms.RadioButton();
            this.cbbPersonType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudShareholderNumber)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股东号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "股东姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "工号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "性别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "身份证号码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "人员类别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "股东身份：";
            // 
            // nudShareholderNumber
            // 
            this.nudShareholderNumber.Location = new System.Drawing.Point(89, 19);
            this.nudShareholderNumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudShareholderNumber.Name = "nudShareholderNumber";
            this.nudShareholderNumber.Size = new System.Drawing.Size(100, 21);
            this.nudShareholderNumber.TabIndex = 7;
            this.nudShareholderNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(89, 53);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 21);
            this.tbName.TabIndex = 8;
            // 
            // tbJobNumber
            // 
            this.tbJobNumber.Location = new System.Drawing.Point(89, 88);
            this.tbJobNumber.Name = "tbJobNumber";
            this.tbJobNumber.Size = new System.Drawing.Size(100, 21);
            this.tbJobNumber.TabIndex = 9;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Checked = true;
            this.rbtnMale.Location = new System.Drawing.Point(12, 5);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(35, 16);
            this.rbtnMale.TabIndex = 10;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "男";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(78, 5);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(35, 16);
            this.rbtnFemale.TabIndex = 11;
            this.rbtnFemale.Text = "女";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // tbIdentityCard
            // 
            this.tbIdentityCard.Location = new System.Drawing.Point(89, 158);
            this.tbIdentityCard.Name = "tbIdentityCard";
            this.tbIdentityCard.Size = new System.Drawing.Size(121, 21);
            this.tbIdentityCard.TabIndex = 12;
            // 
            // rbtnIsNotShare
            // 
            this.rbtnIsNotShare.AutoSize = true;
            this.rbtnIsNotShare.Location = new System.Drawing.Point(151, 229);
            this.rbtnIsNotShare.Name = "rbtnIsNotShare";
            this.rbtnIsNotShare.Size = new System.Drawing.Size(59, 16);
            this.rbtnIsNotShare.TabIndex = 14;
            this.rbtnIsNotShare.Text = "非股东";
            this.rbtnIsNotShare.UseVisualStyleBackColor = true;
            // 
            // rbtnIsShare
            // 
            this.rbtnIsShare.AutoSize = true;
            this.rbtnIsShare.Checked = true;
            this.rbtnIsShare.Location = new System.Drawing.Point(89, 229);
            this.rbtnIsShare.Name = "rbtnIsShare";
            this.rbtnIsShare.Size = new System.Drawing.Size(47, 16);
            this.rbtnIsShare.TabIndex = 13;
            this.rbtnIsShare.TabStop = true;
            this.rbtnIsShare.Text = "股东";
            this.rbtnIsShare.UseVisualStyleBackColor = true;
            // 
            // cbbPersonType
            // 
            this.cbbPersonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPersonType.FormattingEnabled = true;
            this.cbbPersonType.Location = new System.Drawing.Point(89, 193);
            this.cbbPersonType.Name = "cbbPersonType";
            this.cbbPersonType.Size = new System.Drawing.Size(121, 20);
            this.cbbPersonType.TabIndex = 15;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(48, 281);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "确定(&O)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(167, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnMale);
            this.panel1.Controls.Add(this.rbtnFemale);
            this.panel1.Location = new System.Drawing.Point(76, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 23);
            this.panel1.TabIndex = 18;
            // 
            // AddShareholder
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(291, 332);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbbPersonType);
            this.Controls.Add(this.rbtnIsNotShare);
            this.Controls.Add(this.rbtnIsShare);
            this.Controls.Add(this.tbIdentityCard);
            this.Controls.Add(this.tbJobNumber);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.nudShareholderNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddShareholder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "股东注册";
            this.Load += new System.EventHandler(this.AddShareholder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudShareholderNumber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudShareholderNumber;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbJobNumber;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.TextBox tbIdentityCard;
        private System.Windows.Forms.RadioButton rbtnIsNotShare;
        private System.Windows.Forms.RadioButton rbtnIsShare;
        private System.Windows.Forms.ComboBox cbbPersonType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
    }
}
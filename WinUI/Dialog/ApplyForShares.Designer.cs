namespace WinUI.Dialog
{
    partial class ApplyForShares
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
            this.components = new System.ComponentModel.Container();
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
            this.nudShareOwnership = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShareOwnership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 147);
            this.panel1.TabIndex = 3;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(299, 109);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(53, 12);
            this.lbStatus.TabIndex = 11;
            this.lbStatus.Text = "[Status]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "股东状态：";
            // 
            // lbPersonType
            // 
            this.lbPersonType.AutoSize = true;
            this.lbPersonType.Location = new System.Drawing.Point(80, 109);
            this.lbPersonType.Name = "lbPersonType";
            this.lbPersonType.Size = new System.Drawing.Size(77, 12);
            this.lbPersonType.TabIndex = 9;
            this.lbPersonType.Text = "[PersonType]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "人员类别：";
            // 
            // lbIdentityCard
            // 
            this.lbIdentityCard.AutoSize = true;
            this.lbIdentityCard.Location = new System.Drawing.Point(299, 84);
            this.lbIdentityCard.Name = "lbIdentityCard";
            this.lbIdentityCard.Size = new System.Drawing.Size(89, 12);
            this.lbIdentityCard.TabIndex = 7;
            this.lbIdentityCard.Text = "[IdentityCard]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "身份证号：";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(56, 85);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(35, 12);
            this.lbSex.TabIndex = 5;
            this.lbSex.Text = "[Sex]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别：";
            // 
            // lbShareholderNumber
            // 
            this.lbShareholderNumber.AutoSize = true;
            this.lbShareholderNumber.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShareholderNumber.Location = new System.Drawing.Point(107, 44);
            this.lbShareholderNumber.Name = "lbShareholderNumber";
            this.lbShareholderNumber.Size = new System.Drawing.Size(206, 24);
            this.lbShareholderNumber.TabIndex = 3;
            this.lbShareholderNumber.Text = "[ShareholderNumber]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "股东号：";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(7, 11);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(98, 21);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "[lbName]";
            // 
            // nudShareOwnership
            // 
            this.nudShareOwnership.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudShareOwnership.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudShareOwnership.Location = new System.Drawing.Point(141, 187);
            this.nudShareOwnership.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudShareOwnership.Name = "nudShareOwnership";
            this.nudShareOwnership.Size = new System.Drawing.Size(260, 31);
            this.nudShareOwnership.TabIndex = 16;
            this.nudShareOwnership.ThousandsSeparator = true;
            this.nudShareOwnership.Validating += new System.ComponentModel.CancelEventHandler(this.nudShareOwnership_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "申请受让股权数量：";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(342, 248);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(449, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ApplyForShares
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(536, 298);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudShareOwnership);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ApplyForShares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入受让股权数量";
            this.Load += new System.EventHandler(this.ApplyForShares_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShareOwnership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.NumericUpDown nudShareOwnership;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
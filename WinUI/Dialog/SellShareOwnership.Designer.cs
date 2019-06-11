namespace WinUI.Dialog
{
    partial class SellShareOwnership
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbShareholderNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSharePrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbSharesTotals = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbShareholder = new System.Windows.Forms.Label();
            this.tbShareOwnership = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股东号：";
            // 
            // tbShareholderNumber
            // 
            this.errorProvider1.SetError(this.tbShareholderNumber, "该股东不存在。");
            this.errorProvider1.SetIconPadding(this.tbShareholderNumber, 5);
            this.tbShareholderNumber.Location = new System.Drawing.Point(151, 69);
            this.tbShareholderNumber.Name = "tbShareholderNumber";
            this.tbShareholderNumber.Size = new System.Drawing.Size(179, 21);
            this.tbShareholderNumber.TabIndex = 1;
            this.tbShareholderNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbShareholderNumber_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "请确认当前股价，若不正确，请到分红管理配置分红参数。";
            // 
            // lbSharePrice
            // 
            this.lbSharePrice.AutoSize = true;
            this.lbSharePrice.Location = new System.Drawing.Point(124, 16);
            this.lbSharePrice.Name = "lbSharePrice";
            this.lbSharePrice.Size = new System.Drawing.Size(89, 12);
            this.lbSharePrice.TabIndex = 18;
            this.lbSharePrice.Text = "[lbSharePrice]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "当前股价(元/股)：";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.CausesValidation = false;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(74, 241);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "退出股权数量：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbSharesTotals
            // 
            this.lbSharesTotals.AutoSize = true;
            this.lbSharesTotals.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSharesTotals.Location = new System.Drawing.Point(149, 134);
            this.lbSharesTotals.Name = "lbSharesTotals";
            this.lbSharesTotals.Size = new System.Drawing.Size(12, 12);
            this.lbSharesTotals.TabIndex = 22;
            this.lbSharesTotals.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "当前可退出总股权数： ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "股东：";
            // 
            // lbShareholder
            // 
            this.lbShareholder.AutoSize = true;
            this.lbShareholder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbShareholder.Location = new System.Drawing.Point(149, 105);
            this.lbShareholder.Name = "lbShareholder";
            this.lbShareholder.Size = new System.Drawing.Size(45, 12);
            this.lbShareholder.TabIndex = 25;
            this.lbShareholder.Text = "[股东]";
            // 
            // tbShareOwnership
            // 
            this.tbShareOwnership.Location = new System.Drawing.Point(151, 175);
            this.tbShareOwnership.Name = "tbShareOwnership";
            this.tbShareOwnership.Size = new System.Drawing.Size(177, 21);
            this.tbShareOwnership.TabIndex = 26;
            this.tbShareOwnership.Validating += new System.ComponentModel.CancelEventHandler(this.tbShareOwnership_Validating);
            // 
            // SellShareOwnership
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(446, 276);
            this.Controls.Add(this.tbShareOwnership);
            this.Controls.Add(this.lbShareholder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSharesTotals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbSharePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbShareholderNumber);
            this.Controls.Add(this.label1);
            this.Name = "SellShareOwnership";
            this.Text = "股权退出对话框";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbShareholderNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSharePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbSharesTotals;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbShareholder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbShareOwnership;
    }
}
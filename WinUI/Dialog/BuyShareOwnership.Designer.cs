namespace WinUI.Dialog
{
    partial class BuyShareOwnership
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nudShareOwnership = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSharePrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudShareOwnership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(205, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(76, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nudShareOwnership
            // 
            this.nudShareOwnership.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudShareOwnership.Location = new System.Drawing.Point(119, 91);
            this.nudShareOwnership.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudShareOwnership.Name = "nudShareOwnership";
            this.nudShareOwnership.Size = new System.Drawing.Size(180, 21);
            this.nudShareOwnership.TabIndex = 5;
            this.nudShareOwnership.ThousandsSeparator = true;
            this.nudShareOwnership.ValueChanged += new System.EventHandler(this.nudShareOwnership_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "认购股权数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "当前股价(元/股)：";
            // 
            // lbSharePrice
            // 
            this.lbSharePrice.AutoSize = true;
            this.lbSharePrice.Location = new System.Drawing.Point(125, 58);
            this.lbSharePrice.Name = "lbSharePrice";
            this.lbSharePrice.Size = new System.Drawing.Size(89, 12);
            this.lbSharePrice.TabIndex = 9;
            this.lbSharePrice.Text = "[lbSharePrice]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "缴纳受让款(元)：";
            // 
            // tbMoney
            // 
            this.errorProvider1.SetError(this.tbMoney, "输入必须为数字格式！");
            this.tbMoney.Location = new System.Drawing.Point(119, 128);
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.Size = new System.Drawing.Size(180, 21);
            this.tbMoney.TabIndex = 11;
            this.tbMoney.Text = "0.00";
            this.tbMoney.Validating += new System.ComponentModel.CancelEventHandler(this.tbMoney_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "请确认当前股价，若不正确，请到分红管理配置分红参数。";
            // 
            // BuyShareOwnership
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CancelButton = this.btnCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(357, 231);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSharePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudShareOwnership);
            this.Controls.Add(this.label1);
            this.Name = "BuyShareOwnership";
            this.Text = "购买股权";
            ((System.ComponentModel.ISupportInitialize)(this.nudShareOwnership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nudShareOwnership;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSharePrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMoney;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
    }
}
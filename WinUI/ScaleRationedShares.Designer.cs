namespace WinUI
{
    partial class ScaleRationedShares
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTotalSharesAfter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalShares = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPeigu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSharePrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbIssueNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRationScale = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(648, 55);
            this.textBox1.TabIndex = 7;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "　　该窗口主要实现派股的功能。\r\n　　按比例给所有持股的股东派股，如每100股配发8股，则派股比例填0.08。股值为股权交易当期的股价。\r\n\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbRationScale);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnPeigu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbSharePrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbIssueNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 224);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按持股比例派股";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbTotalSharesAfter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbTotalShares);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(316, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 187);
            this.panel1.TabIndex = 14;
            // 
            // lbTotalSharesAfter
            // 
            this.lbTotalSharesAfter.AutoSize = true;
            this.lbTotalSharesAfter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalSharesAfter.Location = new System.Drawing.Point(133, 59);
            this.lbTotalSharesAfter.Name = "lbTotalSharesAfter";
            this.lbTotalSharesAfter.Size = new System.Drawing.Size(161, 19);
            this.lbTotalSharesAfter.TabIndex = 6;
            this.lbTotalSharesAfter.Text = "[lbTotalSharesAfter]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "派股后股权总数为：";
            // 
            // lbTotalShares
            // 
            this.lbTotalShares.AutoSize = true;
            this.lbTotalShares.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalShares.Location = new System.Drawing.Point(133, 8);
            this.lbTotalShares.Name = "lbTotalShares";
            this.lbTotalShares.Size = new System.Drawing.Size(125, 19);
            this.lbTotalShares.TabIndex = 4;
            this.lbTotalShares.Text = "[lbTotalShares]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "派股前股权总数为：";
            // 
            // btnPeigu
            // 
            this.btnPeigu.Location = new System.Drawing.Point(138, 162);
            this.btnPeigu.Name = "btnPeigu";
            this.btnPeigu.Size = new System.Drawing.Size(100, 23);
            this.btnPeigu.TabIndex = 13;
            this.btnPeigu.Text = "点击完成派股";
            this.btnPeigu.UseVisualStyleBackColor = true;
            this.btnPeigu.Click += new System.EventHandler(this.btnPeigu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "元/股";
            // 
            // tbSharePrice
            // 
            this.tbSharePrice.Location = new System.Drawing.Point(138, 114);
            this.tbSharePrice.Name = "tbSharePrice";
            this.tbSharePrice.Size = new System.Drawing.Size(100, 21);
            this.tbSharePrice.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "当期股权交易价格：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "派股比例：";
            // 
            // cbbIssueNumber
            // 
            this.cbbIssueNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIssueNumber.FormattingEnabled = true;
            this.cbbIssueNumber.Location = new System.Drawing.Point(138, 20);
            this.cbbIssueNumber.Name = "cbbIssueNumber";
            this.cbbIssueNumber.Size = new System.Drawing.Size(100, 20);
            this.cbbIssueNumber.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "股权交易期数：";
            // 
            // tbRationScale
            // 
            this.tbRationScale.Location = new System.Drawing.Point(138, 67);
            this.tbRationScale.Name = "tbRationScale";
            this.tbRationScale.Size = new System.Drawing.Size(100, 21);
            this.tbRationScale.TabIndex = 15;
            // 
            // ScaleRationedShares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 399);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "ScaleRationedShares";
            this.Text = "按比例派股";
            this.Load += new System.EventHandler(this.ScaleRationedShares_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbIssueNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSharePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPeigu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotalSharesAfter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotalShares;
        private System.Windows.Forms.TextBox tbRationScale;
    }
}
namespace WinUI.Print
{
    partial class PrintPreview
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
            this.ppcIC = new System.Windows.Forms.PrintPreviewControl();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPageCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ppcIC
            // 
            this.ppcIC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ppcIC.AutoZoom = false;
            this.ppcIC.Location = new System.Drawing.Point(12, 41);
            this.ppcIC.Name = "ppcIC";
            this.ppcIC.Size = new System.Drawing.Size(530, 330);
            this.ppcIC.TabIndex = 0;
            this.ppcIC.Zoom = 1D;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "总页数：";
            // 
            // lbPageCount
            // 
            this.lbPageCount.AutoSize = true;
            this.lbPageCount.Location = new System.Drawing.Point(190, 17);
            this.lbPageCount.Name = "lbPageCount";
            this.lbPageCount.Size = new System.Drawing.Size(71, 12);
            this.lbPageCount.TabIndex = 3;
            this.lbPageCount.Text = "lbPageCount";
            // 
            // PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 386);
            this.Controls.Add(this.lbPageCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.ppcIC);
            this.Name = "PrintPreview";
            this.Text = "出资证明书打印预览";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl ppcIC;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPageCount;
    }
}
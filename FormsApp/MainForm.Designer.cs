namespace FormsApp
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Post = new System.Windows.Forms.Button();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Post
            // 
            this.btn_Post.Location = new System.Drawing.Point(12, 12);
            this.btn_Post.Name = "btn_Post";
            this.btn_Post.Size = new System.Drawing.Size(75, 23);
            this.btn_Post.TabIndex = 0;
            this.btn_Post.Text = "POST";
            this.btn_Post.UseVisualStyleBackColor = true;
            this.btn_Post.Click += new System.EventHandler(this.btn_Post_Click);
            // 
            // txt_Result
            // 
            this.txt_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Result.Location = new System.Drawing.Point(12, 41);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.Size = new System.Drawing.Size(530, 243);
            this.txt_Result.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 296);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.btn_Post);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Post;
        private System.Windows.Forms.TextBox txt_Result;
    }
}


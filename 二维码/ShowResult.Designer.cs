namespace 二维码
{
    partial class ShowResult
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
            this.result_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openwebsite_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result_textBox
            // 
            this.result_textBox.Location = new System.Drawing.Point(13, 29);
            this.result_textBox.Multiline = true;
            this.result_textBox.Name = "result_textBox";
            this.result_textBox.Size = new System.Drawing.Size(284, 73);
            this.result_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "二维码识别结果：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "复制";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openwebsite_button
            // 
            this.openwebsite_button.Location = new System.Drawing.Point(179, 117);
            this.openwebsite_button.Name = "openwebsite_button";
            this.openwebsite_button.Size = new System.Drawing.Size(75, 23);
            this.openwebsite_button.TabIndex = 3;
            this.openwebsite_button.Text = "打开网址->";
            this.openwebsite_button.UseVisualStyleBackColor = true;
            this.openwebsite_button.Click += new System.EventHandler(this.openwebsite_button_Click);
            // 
            // ShowResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 152);
            this.Controls.Add(this.openwebsite_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result_textBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Result";
            this.Load += new System.EventHandler(this.ShowResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox result_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button openwebsite_button;
    }
}
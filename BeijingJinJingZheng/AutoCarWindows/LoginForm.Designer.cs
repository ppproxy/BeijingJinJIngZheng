namespace AutoCarWindows
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_phonenum = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.panel_code = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.panel_code.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号码:";
            // 
            // textBox_phonenum
            // 
            this.textBox_phonenum.Location = new System.Drawing.Point(92, 28);
            this.textBox_phonenum.Name = "textBox_phonenum";
            this.textBox_phonenum.Size = new System.Drawing.Size(143, 21);
            this.textBox_phonenum.TabIndex = 1;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(30, 122);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(287, 28);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "验证并登录";
            this.button_login.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_login.UseVisualStyleBackColor = true;
            // 
            // panel_code
            // 
            this.panel_code.Controls.Add(this.button_send);
            this.panel_code.Controls.Add(this.textBox_code);
            this.panel_code.Controls.Add(this.label2);
            this.panel_code.Location = new System.Drawing.Point(30, 56);
            this.panel_code.Name = "panel_code";
            this.panel_code.Size = new System.Drawing.Size(287, 60);
            this.panel_code.TabIndex = 3;
            this.panel_code.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "验证码:";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(64, 21);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(100, 21);
            this.textBox_code.TabIndex = 1;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(170, 21);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 2;
            this.button_send.Text = "发送验证码";
            this.button_send.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 195);
            this.Controls.Add(this.panel_code);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_phonenum);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "登录";
            this.panel_code.ResumeLayout(false);
            this.panel_code.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_phonenum;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Panel panel_code;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_send;
    }
}
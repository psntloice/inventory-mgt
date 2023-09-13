namespace Postgreconn
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.tbpasswd = new System.Windows.Forms.TextBox();
            this.btsignin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btlogin = new System.Windows.Forms.Button();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.btexit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpasswd
            // 
            this.tbpasswd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbpasswd.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbpasswd.Location = new System.Drawing.Point(123, 73);
            this.tbpasswd.Margin = new System.Windows.Forms.Padding(5);
            this.tbpasswd.MaxLength = 20;
            this.tbpasswd.Name = "tbpasswd";
            this.tbpasswd.PasswordChar = '●';
            this.tbpasswd.Size = new System.Drawing.Size(194, 33);
            this.tbpasswd.TabIndex = 13;
            this.tbpasswd.UseSystemPasswordChar = true;
            this.tbpasswd.Click += new System.EventHandler(this.tbpasswd_Click);
            this.tbpasswd.Enter += new System.EventHandler(this.tbpasswd_Enter);
            // 
            // btsignin
            // 
            this.btsignin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btsignin.BackgroundImage")));
            this.btsignin.Location = new System.Drawing.Point(19, 132);
            this.btsignin.Margin = new System.Windows.Forms.Padding(5);
            this.btsignin.Name = "btsignin";
            this.btsignin.Size = new System.Drawing.Size(95, 53);
            this.btsignin.TabIndex = 12;
            this.btsignin.Text = "Employee Login";
            this.btsignin.UseVisualStyleBackColor = true;
            this.btsignin.Click += new System.EventHandler(this.btsignin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(26, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "UserID";
            // 
            // btlogin
            // 
            this.btlogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btlogin.BackgroundImage")));
            this.btlogin.Location = new System.Drawing.Point(146, 132);
            this.btlogin.Margin = new System.Windows.Forms.Padding(5);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(96, 53);
            this.btlogin.TabIndex = 8;
            this.btlogin.Text = "Admin Login";
            this.btlogin.UseVisualStyleBackColor = true;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // tbusername
            // 
            this.tbusername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbusername.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbusername.Location = new System.Drawing.Point(123, 21);
            this.tbusername.Margin = new System.Windows.Forms.Padding(5);
            this.tbusername.Multiline = true;
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(194, 39);
            this.tbusername.TabIndex = 7;
            // 
            // btexit
            // 
            this.btexit.BackColor = System.Drawing.Color.Transparent;
            this.btexit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btexit.BackgroundImage")));
            this.btexit.Location = new System.Drawing.Point(275, 132);
            this.btexit.Margin = new System.Windows.Forms.Padding(5);
            this.btexit.Name = "btexit";
            this.btexit.Size = new System.Drawing.Size(79, 53);
            this.btexit.TabIndex = 14;
            this.btexit.Text = "Exit";
            this.btexit.UseVisualStyleBackColor = false;
            this.btexit.Click += new System.EventHandler(this.btexit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel2.Controls.Add(this.tbusername);
            this.panel2.Controls.Add(this.tbpasswd);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btlogin);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btsignin);
            this.panel2.Controls.Add(this.btexit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 209);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 79);
            this.panel1.TabIndex = 16;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbpasswd;
        private System.Windows.Forms.Button btsignin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.Button btexit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
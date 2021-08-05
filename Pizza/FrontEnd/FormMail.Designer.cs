namespace Pizza
{
    partial class FormMail
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tSender = new System.Windows.Forms.TextBox();
            this.tRecipient = new System.Windows.Forms.TextBox();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bZapisz = new System.Windows.Forms.Button();
            this.bZamkni = new System.Windows.Forms.Button();
            this.tSmtp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adres e-mail nadawcy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adres e-mail odbiorcy";
            // 
            // tNadawca
            // 
            this.tSender.Location = new System.Drawing.Point(16, 27);
            this.tSender.Name = "tNadawca";
            this.tSender.Size = new System.Drawing.Size(194, 20);
            this.tSender.TabIndex = 2;
            // 
            // tOdbiorca
            // 
            this.tRecipient.Location = new System.Drawing.Point(273, 27);
            this.tRecipient.Name = "tOdbiorca";
            this.tRecipient.Size = new System.Drawing.Size(194, 20);
            this.tRecipient.TabIndex = 3;
            // 
            // tHaslo
            // 
            this.tPassword.Location = new System.Drawing.Point(16, 78);
            this.tPassword.Name = "tHaslo";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(194, 20);
            this.tPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hasło";
            // 
            // bZapisz
            // 
            this.bZapisz.Location = new System.Drawing.Point(16, 162);
            this.bZapisz.Name = "bZapisz";
            this.bZapisz.Size = new System.Drawing.Size(194, 47);
            this.bZapisz.TabIndex = 6;
            this.bZapisz.Text = "Zapisz";
            this.bZapisz.UseVisualStyleBackColor = true;
            this.bZapisz.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // bZamkni
            // 
            this.bZamkni.Location = new System.Drawing.Point(273, 162);
            this.bZamkni.Name = "bZamkni";
            this.bZamkni.Size = new System.Drawing.Size(194, 47);
            this.bZamkni.TabIndex = 8;
            this.bZamkni.Text = "Zamkni";
            this.bZamkni.UseVisualStyleBackColor = true;
            this.bZamkni.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // tSmtp
            // 
            this.tSmtp.Location = new System.Drawing.Point(16, 125);
            this.tSmtp.Name = "tSmtp";
            this.tSmtp.Size = new System.Drawing.Size(100, 20);
            this.tSmtp.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "smtp";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(127, 125);
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(83, 20);
            this.tPort.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Port";
            // 
            // FormMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 222);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tSmtp);
            this.Controls.Add(this.bZamkni);
            this.Controls.Add(this.bZapisz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.tRecipient);
            this.Controls.Add(this.tSender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMail";
            this.Text = "FormMail";
            this.Load += new System.EventHandler(this.FormMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tSender;
        private System.Windows.Forms.TextBox tRecipient;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bZapisz;
        private System.Windows.Forms.Button bZamkni;
        private System.Windows.Forms.TextBox tSmtp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tPort;
        private System.Windows.Forms.Label label5;
    }
}
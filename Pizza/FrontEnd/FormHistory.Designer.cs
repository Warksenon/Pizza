namespace Pizza
{
    partial class FormHistory
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
            this.button1 = new System.Windows.Forms.Button();
            this.LVDishes = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Danie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dodatki = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bText = new System.Windows.Forms.Button();
            this.bSql = new System.Windows.Forms.Button();
            this.bTxtToSQL = new System.Windows.Forms.Button();
            this.bSQLToTxt = new System.Windows.Forms.Button();
            this.LVcena = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1152, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 64);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zamknij";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // LVdania
            // 
            this.LVDishes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Danie,
            this.Cena,
            this.Dodatki});
            this.LVDishes.FullRowSelect = true;
            this.LVDishes.HideSelection = false;
            this.LVDishes.Location = new System.Drawing.Point(625, 12);
            this.LVDishes.Name = "LVdania";
            this.LVDishes.Size = new System.Drawing.Size(604, 299);
            this.LVDishes.TabIndex = 44;
            this.LVDishes.UseCompatibleStateImageBehavior = false;
            this.LVDishes.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 39;
            // 
            // Danie
            // 
            this.Danie.Text = "Danie";
            this.Danie.Width = 237;
            // 
            // Cena
            // 
            this.Cena.Text = "Cena";
            this.Cena.Width = 114;
            // 
            // Dodatki
            // 
            this.Dodatki.Text = "Dodatki";
            this.Dodatki.Width = 212;
            // 
            // bText
            // 
            this.bText.Location = new System.Drawing.Point(17, 317);
            this.bText.Name = "bText";
            this.bText.Size = new System.Drawing.Size(241, 64);
            this.bText.TabIndex = 46;
            this.bText.Text = "Historia z pliku txt";
            this.bText.UseVisualStyleBackColor = true;
            this.bText.Click += new System.EventHandler(this.ButtonTextList_Click);
            // 
            // bSql
            // 
            this.bSql.BackColor = System.Drawing.Color.LawnGreen;
            this.bSql.Location = new System.Drawing.Point(330, 317);
            this.bSql.Name = "bSql";
            this.bSql.Size = new System.Drawing.Size(271, 64);
            this.bSql.TabIndex = 47;
            this.bSql.Text = "Historia z SQL";
            this.bSql.UseVisualStyleBackColor = false;
            this.bSql.Click += new System.EventHandler(this.ButtonSqlList_Click);
            // 
            // bTxtToSQL
            // 
            this.bTxtToSQL.Location = new System.Drawing.Point(625, 317);
            this.bTxtToSQL.Name = "bTxtToSQL";
            this.bTxtToSQL.Size = new System.Drawing.Size(271, 64);
            this.bTxtToSQL.TabIndex = 48;
            this.bTxtToSQL.Text = "Kopjuj historie z txt do SQL";
            this.bTxtToSQL.UseVisualStyleBackColor = true;
            this.bTxtToSQL.Click += new System.EventHandler(this.ButtonTxtToSql);
            // 
            // bSQLToTxt
            // 
            this.bSQLToTxt.Location = new System.Drawing.Point(923, 317);
            this.bSQLToTxt.Name = "bSQLToTxt";
            this.bSQLToTxt.Size = new System.Drawing.Size(223, 64);
            this.bSQLToTxt.TabIndex = 49;
            this.bSQLToTxt.Text = "Kopjuj historie z SQL do txt";
            this.bSQLToTxt.UseVisualStyleBackColor = true;
            this.bSQLToTxt.Click += new System.EventHandler(this.bSQLToTxt_Click);
            // 
            // LVcena
            // 
            this.LVcena.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LVcena.FullRowSelect = true;
            this.LVcena.HideSelection = false;
            this.LVcena.Location = new System.Drawing.Point(17, 12);
            this.LVcena.Name = "LVcena";
            this.LVcena.Size = new System.Drawing.Size(584, 299);
            this.LVcena.TabIndex = 51;
            this.LVcena.UseCompatibleStateImageBehavior = false;
            this.LVcena.View = System.Windows.Forms.View.Details;
            this.LVcena.SelectedIndexChanged += new System.EventHandler(this.ListViewDishes_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 39;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data";
            this.columnHeader2.Width = 188;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cena";
            this.columnHeader3.Width = 114;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Uwagi";
            this.columnHeader4.Width = 241;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
           
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 393);
            this.Controls.Add(this.LVcena);
            this.Controls.Add(this.bSQLToTxt);
            this.Controls.Add(this.bTxtToSQL);
            this.Controls.Add(this.bSql);
            this.Controls.Add(this.bText);
            this.Controls.Add(this.LVDishes);
            this.Controls.Add(this.button1);
            this.Name = "FormHistory";
            this.Text = "FormHistory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHistory_FormClosing);
            this.Load += new System.EventHandler(this.FormHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView LVDishes;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Danie;
        private System.Windows.Forms.ColumnHeader Cena;
        private System.Windows.Forms.ColumnHeader Dodatki;
        private System.Windows.Forms.Button bText;
        private System.Windows.Forms.Button bSql;
        private System.Windows.Forms.Button bTxtToSQL;
        private System.Windows.Forms.Button bSQLToTxt;
        private System.Windows.Forms.ListView LVcena;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
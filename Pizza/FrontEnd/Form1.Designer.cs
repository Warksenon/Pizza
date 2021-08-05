using System;

namespace Pizza
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lMenuInfo = new System.Windows.Forms.Label();
            this.bPizza = new System.Windows.Forms.Button();
            this.bMainDish = new System.Windows.Forms.Button();
            this.bSoups = new System.Windows.Forms.Button();
            this.textViewDishes = new System.Windows.Forms.TextBox();
            this.bAddDish = new System.Windows.Forms.Button();
            this.bRemoveAllListBox = new System.Windows.Forms.Button();
            this.panelDania = new System.Windows.Forms.Panel();
            this.listViewDish = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chListBoxSideDishes = new System.Windows.Forms.CheckedListBox();
            this.bRemoveListBox = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ListViewOrder = new System.Windows.Forms.ListView();
            this.Danie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dodatki = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cenal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lPrice = new System.Windows.Forms.Label();
            this.tComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bDrinks = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bOrder = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelDania.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lMenuInfo
            // 
            this.lMenuInfo.AutoSize = true;
            this.lMenuInfo.Location = new System.Drawing.Point(11, 7);
            this.lMenuInfo.Name = "lMenuInfo";
            this.lMenuInfo.Size = new System.Drawing.Size(32, 13);
            this.lMenuInfo.TabIndex = 0;
            this.lMenuInfo.Text = "Pizza";
            // 
            // bPizza
            // 
            this.bPizza.Location = new System.Drawing.Point(5, 5);
            this.bPizza.Name = "bPizza";
            this.bPizza.Size = new System.Drawing.Size(123, 59);
            this.bPizza.TabIndex = 14;
            this.bPizza.Text = "Pizza";
            this.bPizza.UseVisualStyleBackColor = true;
            this.bPizza.Click += new System.EventHandler(this.ButtonPizza_Click);
            // 
            // bMainDish
            // 
            this.bMainDish.Location = new System.Drawing.Point(5, 70);
            this.bMainDish.Name = "bMainDish";
            this.bMainDish.Size = new System.Drawing.Size(123, 54);
            this.bMainDish.TabIndex = 15;
            this.bMainDish.Text = "Dania główne";
            this.bMainDish.UseVisualStyleBackColor = true;
            this.bMainDish.Click += new System.EventHandler(this.ButtonMainDish_Click);
            // 
            // bSoups
            // 
            this.bSoups.Location = new System.Drawing.Point(5, 130);
            this.bSoups.Name = "bSoups";
            this.bSoups.Size = new System.Drawing.Size(123, 58);
            this.bSoups.TabIndex = 16;
            this.bSoups.Text = "Zupy";
            this.bSoups.UseVisualStyleBackColor = true;
            this.bSoups.Click += new System.EventHandler(this.ButtonSoup_Click);
            // 
            // textViewDishes
            // 
            this.textViewDishes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textViewDishes.Location = new System.Drawing.Point(14, 201);
            this.textViewDishes.Name = "textViewDishes";
            this.textViewDishes.Size = new System.Drawing.Size(75, 20);
            this.textViewDishes.TabIndex = 17;
            // 
            // bAddDish
            // 
            this.bAddDish.Location = new System.Drawing.Point(95, 199);
            this.bAddDish.Name = "bAddDish";
            this.bAddDish.Size = new System.Drawing.Size(241, 22);
            this.bAddDish.TabIndex = 25;
            this.bAddDish.Text = "ok";
            this.bAddDish.UseVisualStyleBackColor = true;
            this.bAddDish.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // bRemoveAllListBox
            // 
            this.bRemoveAllListBox.Location = new System.Drawing.Point(17, 232);
            this.bRemoveAllListBox.Name = "bRemoveAllListBox";
            this.bRemoveAllListBox.Size = new System.Drawing.Size(151, 28);
            this.bRemoveAllListBox.TabIndex = 34;
            this.bRemoveAllListBox.Text = "Usuń wszystko";
            this.bRemoveAllListBox.UseVisualStyleBackColor = true;
            this.bRemoveAllListBox.Click += new System.EventHandler(this.ButtonRemoveAllListBox_Click);
            // 
            // panelDania
            // 
            this.panelDania.Controls.Add(this.listViewDish);
            this.panelDania.Controls.Add(this.chListBoxSideDishes);
            this.panelDania.Controls.Add(this.bAddDish);
            this.panelDania.Controls.Add(this.textViewDishes);
            this.panelDania.Controls.Add(this.lMenuInfo);
            this.panelDania.Location = new System.Drawing.Point(173, 0);
            this.panelDania.Name = "panelDania";
            this.panelDania.Size = new System.Drawing.Size(696, 246);
            this.panelDania.TabIndex = 35;
            
            // 
            // listViewDish
            // 
            this.listViewDish.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewDish.HideSelection = false;
            this.listViewDish.Location = new System.Drawing.Point(14, 33);
            this.listViewDish.Name = "listViewDish";
            this.listViewDish.Size = new System.Drawing.Size(322, 154);
            this.listViewDish.TabIndex = 34;
            this.listViewDish.UseCompatibleStateImageBehavior = false;
            this.listViewDish.View = System.Windows.Forms.View.Details;
            this.listViewDish.SelectedIndexChanged += new System.EventHandler(this.ListViewDish_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danie";
            this.columnHeader1.Width = 205;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cena";
            this.columnHeader2.Width = 112;
            // 
            // chListBoxSideDishes
            // 
            this.chListBoxSideDishes.FormattingEnabled = true;
            this.chListBoxSideDishes.Location = new System.Drawing.Point(362, 33);
            this.chListBoxSideDishes.Name = "chListBoxSideDishes";
            this.chListBoxSideDishes.Size = new System.Drawing.Size(290, 154);
            this.chListBoxSideDishes.TabIndex = 33;
            // 
            // bRemoveListBox
            // 
            this.bRemoveListBox.Location = new System.Drawing.Point(387, 232);
            this.bRemoveListBox.Name = "bRemoveListBox";
            this.bRemoveListBox.Size = new System.Drawing.Size(161, 28);
            this.bRemoveListBox.TabIndex = 38;
            this.bRemoveListBox.Text = "Usuń";
            this.bRemoveListBox.UseVisualStyleBackColor = true;
            this.bRemoveListBox.Click += new System.EventHandler(this.ButtonRemoveListBox_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ListViewOrder);
            this.panel3.Controls.Add(this.lPrice);
            this.panel3.Controls.Add(this.bRemoveListBox);
            this.panel3.Controls.Add(this.bRemoveAllListBox);
            this.panel3.Location = new System.Drawing.Point(266, 252);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(603, 282);
            this.panel3.TabIndex = 40;
            // 
            // ListViewOrder
            // 
            this.ListViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Danie,
            this.Dodatki,
            this.Cenal});
            this.ListViewOrder.FullRowSelect = true;
            this.ListViewOrder.HideSelection = false;
            this.ListViewOrder.Location = new System.Drawing.Point(17, 28);
            this.ListViewOrder.Name = "ListViewOrder";
            this.ListViewOrder.Size = new System.Drawing.Size(567, 184);
            this.ListViewOrder.TabIndex = 40;
            this.ListViewOrder.UseCompatibleStateImageBehavior = false;
            this.ListViewOrder.View = System.Windows.Forms.View.Details;
            this.ListViewOrder.SelectedIndexChanged += new System.EventHandler(this.ListViDania_SelectedIndexChanged);
            // 
            // Danie
            // 
            this.Danie.Text = "Danie";
            this.Danie.Width = 187;
            // 
            // Dodatki
            // 
            this.Dodatki.Text = "Dodatki";
            this.Dodatki.Width = 223;
            // 
            // Cenal
            // 
            this.Cenal.Text = "Cena";
            this.Cenal.Width = 333;
            // 
            // lPrice
            // 
            this.lPrice.AutoSize = true;
            this.lPrice.Location = new System.Drawing.Point(14, 12);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(53, 13);
            this.lPrice.TabIndex = 39;
            this.lPrice.Text = "Cena: 0zł";
            // 
            // tComments
            // 
            this.tComments.Location = new System.Drawing.Point(15, 40);
            this.tComments.Multiline = true;
            this.tComments.Name = "tComments";
            this.tComments.Size = new System.Drawing.Size(217, 174);
            this.tComments.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Uwagi do zmówienia";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tComments);
            this.panel4.Location = new System.Drawing.Point(12, 298);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 236);
            this.panel4.TabIndex = 43;
            // 
            // bDrinks
            // 
            this.bDrinks.BackColor = System.Drawing.SystemColors.Control;
            this.bDrinks.Location = new System.Drawing.Point(5, 194);
            this.bDrinks.Name = "bDrinks";
            this.bDrinks.Size = new System.Drawing.Size(123, 53);
            this.bDrinks.TabIndex = 44;
            this.bDrinks.Text = "Napoje";
            this.bDrinks.UseVisualStyleBackColor = false;
            this.bDrinks.Click += new System.EventHandler(this.ButtonDrinks_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bDrinks);
            this.panel5.Controls.Add(this.bSoups);
            this.panel5.Controls.Add(this.bMainDish);
            this.panel5.Controls.Add(this.bPizza);
            this.panel5.Location = new System.Drawing.Point(12, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(134, 259);
            this.panel5.TabIndex = 45;
            // 
            // bOrder
            // 
            this.bOrder.BackColor = System.Drawing.SystemColors.Control;
            this.bOrder.Location = new System.Drawing.Point(12, 540);
            this.bOrder.Name = "bOrder";
            this.bOrder.Size = new System.Drawing.Size(857, 68);
            this.bOrder.TabIndex = 46;
            this.bOrder.Text = "Złóż zamówienie";
            this.bOrder.UseVisualStyleBackColor = false;
            this.bOrder.Click += new System.EventHandler(this.ButtonOrder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressEmailToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // addressEmailToolStripMenuItem
            // 
            this.addressEmailToolStripMenuItem.Name = "addressEmailToolStripMenuItem";
            this.addressEmailToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addressEmailToolStripMenuItem.Text = "Adres E-mail";
            this.addressEmailToolStripMenuItem.Click += new System.EventHandler(this.AddressEmailToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.historyToolStripMenuItem.Text = "Historia";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.HistoryToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker2_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker2_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 619);
            this.Controls.Add(this.bOrder);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelDania);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panelDania.ResumeLayout(false);
            this.panelDania.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.Label lMenuInfo;
        private System.Windows.Forms.Button bPizza;
        private System.Windows.Forms.Button bMainDish;
        private System.Windows.Forms.Button bSoups;
        private System.Windows.Forms.TextBox textViewDishes;
        private System.Windows.Forms.Button bAddDish;
        private System.Windows.Forms.Button bRemoveAllListBox;
        private System.Windows.Forms.Panel panelDania;
        private System.Windows.Forms.Button bRemoveListBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bDrinks;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button bOrder;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ListView ListViewOrder;
        private System.Windows.Forms.ColumnHeader Danie;
        private System.Windows.Forms.ColumnHeader Dodatki;
        private System.Windows.Forms.ColumnHeader Cenal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView listViewDish;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckedListBox chListBoxSideDishes;
    }
}


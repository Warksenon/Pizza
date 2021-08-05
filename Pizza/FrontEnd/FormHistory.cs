using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Pizza
{
    public partial class FormHistory : Form
    {

        LoadOrder load = new LoadOrder();
        
        public FormHistory()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }
        
        List<Order> orderList;
        LoadOrder laod = new LoadOrder();

        private void FormHistory_Load(object sender, EventArgs e)
        {
            orderList = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Sql);
            LoadLVPriceAll();
        }

        public enum Button
        {
            HistSQL,
            HistTXT,
            SqlToTxt,
            TxtToSql
        }
  
      

        


        private void ButtonColorChange (Button p)
        {
            switch (p)
            {
                case Button.HistSQL:  bSql.BackColor = Color.LawnGreen;      bText.BackColor = SystemColors.Control; break;
                case Button.HistTXT:  bSql.BackColor = SystemColors.Control; bText.BackColor = Color.LawnGreen; break;
                case Button.SqlToTxt: bSql.BackColor = SystemColors.Control; bText.BackColor = SystemColors.Control; bSQLToTxt.BackColor = Color.Firebrick; break;
                case Button.TxtToSql: bSql.BackColor = SystemColors.Control; bText.BackColor = SystemColors.Control; bTxtToSQL.BackColor = Color.Firebrick; break;
            }
       
        }

        private void ClearAllList()
        {
            LVDishes.Items.Clear();
            LVcena.Items.Clear();
            orderList.Clear();  
        }

        private void LoadLVPriceAll()
        {
            foreach (var price in orderList)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(price.PriceAll.ID));
                lvi.SubItems.Add(price.PriceAll.Date);
                lvi.SubItems.Add(price.PriceAll.Price);        
                lvi.SubItems.Add(price.PriceAll.Comments);
                LVcena.Items.Add(lvi);
            }

        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
                this.Close();   
        }

        private bool CheckBackgroundWorker1End()
        {
            if (backgroundWorker1.IsBusy == true) return false;
            else return true;
        }


        private void MassageBoxDataProcessing()
        {
            MessageBox.Show("Przetwarzanie danych proszę czekać", "Przetwarzanie danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


       
        private void ButtonTextList_Click(object sender, EventArgs e)
        {

            if (CheckBackgroundWorker1End())
            {               
                ClearAllList();           
                orderList = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Txt);
                LoadLVPriceAll();
                ButtonColorChange(Button.HistTXT);
            }
            else
            {
                MassageBoxDataProcessing();
            }
        }

        private void ButtonSqlList_Click(object sender, EventArgs e)
        {
            if (CheckBackgroundWorker1End())
            {
                
                ClearAllList();
                SqlLite.InsertAndQuestionSQL sqlInsertAndQuestion = new SqlLite.InsertAndQuestionSQL();
                orderList = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Sql);
                LoadLVPriceAll();
                ButtonColorChange(Button.HistSQL);
            }
            else
            {
                MassageBoxDataProcessing();
            }

        }

   
        private void ButtonTxtToSql(object sender, EventArgs e)
        {           
            if (CheckBackgroundWorker1End())
            {            
                ButtonColorChange(Button.TxtToSql);
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MassageBoxDataProcessing();
            }
        }

        private void ListViewDishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LVDishes.Items.Clear();
            foreach (var dish in orderList[LVcena.FocusedItem.Index].ListDishes)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(dish.IdPrice));
                lvi.SubItems.Add(dish.Name);
                lvi.SubItems.Add(dish.Price);               
                lvi.SubItems.Add(dish.SidesDishes);
                LVDishes.Items.Add(lvi);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Save save = new Save();
            List<Order> listOrder = new List<Order>();
            SqlLite.InsertAndQuestionSQL sql = new SqlLite.InsertAndQuestionSQL();
            
            if (bSQLToTxt.BackColor == Color.Firebrick)
            {               
                listOrder = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Sql);
                save.SaveOrderList(Save.ChoiceSaveOrder.Txt, listOrder);
            }
            if (bTxtToSQL.BackColor == Color.Firebrick)
            {
                listOrder = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Sql);
                save.SaveOrderList(Save.ChoiceSaveOrder.Sql, listOrder);
            }
  
        }

        private void bSQLToTxt_Click(object sender, EventArgs e)
        {
            
            if (CheckBackgroundWorker1End())
            {              
                ButtonColorChange(Button.SqlToTxt);
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MassageBoxDataProcessing();
            }

        }

      
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadToList();
            
            string stTxtToSQL = "Kopjuj historie z txt do SQL ";
            string stSqlToTxt = "Kopjuj historie z SQL do pliku txt";

            if (e.Cancelled == true)
            {
                bTxtToSQL.Text = stTxtToSQL;
                bSQLToTxt.Text = stSqlToTxt;
            }
            else if (e.Error != null)
            {
                bTxtToSQL.Text = stTxtToSQL;
                bSQLToTxt.Text = stSqlToTxt;
            }
            else
            {
                bTxtToSQL.Text = stTxtToSQL;
                bSQLToTxt.Text = stSqlToTxt;
            }
        }

        private void LoadToList()
        {
            if (bSQLToTxt.BackColor == Color.Firebrick)
            {
                ClearAllList();              
                orderList = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Txt);
                LoadLVPriceAll();
                ButtonColorChange(Button.HistTXT);
            }
            if (bTxtToSQL.BackColor == Color.Firebrick)
            {
                ClearAllList();               
                orderList = load.LoadOrderList(LoadOrder.ChoiceLoadOrder.Sql);
                LoadLVPriceAll();
                ButtonColorChange(Button.HistSQL);
            }

            bSQLToTxt.BackColor = SystemColors.Control;
            bTxtToSQL.BackColor = SystemColors.Control;
        }

        private void FormHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (CheckBackgroundWorker1End())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                MassageBoxDataProcessing();
            }
         
        }
    }
    
}

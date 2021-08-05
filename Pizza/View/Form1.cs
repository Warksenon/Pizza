using Pizza.Presenters;
using Pizza.Presenters.PresenterForm1.VisableElements.Button;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Pizza
{

    
        public partial class Form1 : Form , IForm1ListViewDishesAndCheckedListBoxSideDish, IForm1Order
    {
        public Form1 form1;

        public Form1()
        { 
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;            
        }

        private Form1OrderPresenters orderPresenters ;
        private Form1LoadDishesPresenters loadDishesAndSides;
        private void Form1_Load_1(object sender, EventArgs e)
        {
            orderPresenters = new Form1OrderPresenters(this, this);
            loadDishesAndSides = new Form1LoadDishesPresenters(this);
            PizzaButtonSettings();
            loadDishesAndSides.LoadPizza();          
            SetVisibleButtonRemoveAll();
            SetVisibleButtonRemove();
            form1 = this;

           // SqlLite.CreateTabeles createTabeles = new SqlLite.CreateTabeles();
           // createTabeles.CreateSQLiteTables();        
        }
      
        public ListView ListViewDishes { get => listViewDish; set => listViewDish = value; }
        public CheckedListBox CheckedListBoxSideDish { get => chListBoxSideDishes; set => chListBoxSideDishes = value; }

        public TextBox TextBoxQuantityDishes { get => textBoxQuantityDishes; set => textBoxQuantityDishes = value; }
        public ListView ListViewOrder { get => listViewOrder; set => listViewOrder = value; }
        public Label LabelPrice { get => lPrice; set => lPrice = value; }
        public BackgroundWorker BackgroundWorker { get => backgroundWorker1; set => backgroundWorker1 = value; }
        public TextBox TextBoxComments { get => tComments; set => tComments = value; }
    
        private void ClearColorButton()
        {
            bPizza.BackColor = SystemColors.Control;
            bMainDish.BackColor = SystemColors.Control;
            bSoups.BackColor = SystemColors.Control;
            bDrinks.BackColor = SystemColors.Control;
        }

    

        private void ButtonPizza_Click(object sender, EventArgs e)
        {
            PizzaButtonSettings();
            loadDishesAndSides.LoadPizza();  
        }

        private void PizzaButtonSettings()
        {
            bPizza.BackColor = Color.LawnGreen;
            ChengeNameLabelMenuInfo("Pizza");
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void ChengeNameLabelMenuInfo(string infoMenu)
        {
            lMenuInfo.Text = infoMenu;
        }

        private void ButtonMainDish_Click(object sender, EventArgs e)
        {
            MainDishButtonSettings();
            loadDishesAndSides.LoadMainDish();         
        }

        private void MainDishButtonSettings()
        {
            bMainDish.BackColor = Color.LawnGreen;
            ChengeNameLabelMenuInfo("Dania główne");
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void ButtonDrinks_Click(object sender, EventArgs e)
        {
            DrinkseButtonSettings();
            loadDishesAndSides.LoadDrinks();          
        }

        private void DrinkseButtonSettings()
        {
            bDrinks.BackColor = Color.LawnGreen;
            ChengeNameLabelMenuInfo("Napoje");
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void ButtonSoup_Click(object sender, EventArgs e)
        {
            SoupsButtonSettings();
            loadDishesAndSides.LoadSoups();            
        }

        private void SoupsButtonSettings()
        {
            bSoups.BackColor = Color.LawnGreen;
            ChengeNameLabelMenuInfo("Zupy");
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }


        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            orderPresenters.SubmitOrder();            
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            orderPresenters.AddDishesToListViewOrder();
            SetVisibleButtonRemoveAll();
            orderPresenters.LabelPrice();
            SelectColorbOrder();
        }

        private void SelectColorbOrder()
        {
            if((listViewOrder.Items.Count > 0)|| (backgroundWorker1.IsBusy == true))
            {
                if (listViewOrder.Items.Count > 0) bOrder.BackColor = Color.LawnGreen;
                if (backgroundWorker1.IsBusy == true) bOrder.BackColor = Color.Firebrick;
            }          
            else bOrder.BackColor = SystemColors.Control;
        }

        private void ButtonRemoveListBox_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count == 0) return;
            listViewOrder.SelectedItems[0].Remove();
            orderPresenters.LabelPrice();           
            SetVisibleButtonRemoveAll();
            SetVisibleButtonRemove();
            bRemoveListBox.Visible = false;
            SelectColorbOrder();
        }

        private void ButtonRemoveAllListBox_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            orderPresenters.LabelPrice();
            SelectColorbOrder();
            SetVisibleButtonRemoveAll();
            SetVisibleButtonRemove();
        }

        private void AddressEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMail fm = new FormMail();
            fm.ShowDialog();
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if (backgroundWorker1.IsBusy != true)
            {
                FormHistory fm = new FormHistory();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Historia jeszcze nie gotowa", "Przetwarzanie danych");
            }
           
        }
      
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {        
            SelectColorbOrder();
           // orderPresenters.SendEmailAndSaveOrder();          
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SelectColorbOrder();
        }

        private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void ListViDania_SelectedIndexChanged(object sender, EventArgs e)
        {
           SetVisibleButtonRemove();
        }

        private void SetVisibleButtonRemove()
        {
            if (CheckingListOrderIfEmpty())
            {
                bRemoveListBox.Visible = true;
            }
            else bRemoveListBox.Visible = false;
        }

        private void SetVisibleButtonRemoveAll()
        {
            if (CheckingListOrderIfEmpty())
            {
                bRemoveAllListBox.Visible = true;
            }
            else bRemoveAllListBox.Visible = false;
        }

        private bool CheckingListOrderIfEmpty()
        {
            if (listViewOrder.Items.Count > 0) return true;
            else return false;
        }

        private void ListViewDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibleButtonDishesOK(true);
            SetVisibleTextViewDishesQuantity(true);     
        }

        private void SetVisibleButtonDishesOK(bool visable)
        {
            if (visable) bAddDish.Visible = true;
            else
            {
                CleaningTextViewDishesQuantity();
                bAddDish.Visible = false;
            }         
        }

        private void SetVisibleTextViewDishesQuantity(bool visalbe)
        {
            if (visalbe) textBoxQuantityDishes.Visible = true;            
            else
            {
                CleaningTextViewDishesQuantity();
                textBoxQuantityDishes.Visible = false;
            }
        }

        private void CleaningTextViewDishesQuantity()
        {
            textBoxQuantityDishes.Text = "1";
        }

    }
}

using Pizza.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Pizza
{

    public partial class Form1 : Form , IForm1ListViewDishesAndCheckedListBoxSideDish
    {


        public Form1 form1;
       

        AddOrderFromForm1 addOrder = new AddOrderFromForm1();
        public Form1()
        { 
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
            Start(ButtonMenu.Pizza);
            SetVisibleButtonRemoveAll();
            SetVisibleButtonRemove();
            form1 = this;

            SqlLite.CreateTabeles createTabeles = new SqlLite.CreateTabeles();
            createTabeles.CreateSQLiteTables();        
        }
      
        public ListView ListViewDishes { get => listViewDish; set => listViewDish = value; }
        public CheckedListBox CheckedListBoxSideDish { get => chListBoxSideDishes; set => chListBoxSideDishes = value; }

        public enum ButtonMenu
        {
            Pizza,
            MainDish,
            Soups,
            Drinks
        }

        private void Start(ButtonMenu en)
        {
            ClearColorButton();
            switch (en)
            {
                case ButtonMenu.Pizza: PizzaButtonSettings(en);
                    break;
                case ButtonMenu.MainDish: MainDishButtonSettings(en);
                    break;
                case ButtonMenu.Soups: SoupsButtonSettings(en);
                    break;
                case ButtonMenu.Drinks: DrinkseButtonSettings(en);
                    break;
            }
        }

        private void PizzaButtonSettings(ButtonMenu en)
        {
            bPizza.BackColor = Color.LawnGreen;
            VisibleSideDishe(en);          
            ChengeNameLabelMenuInfo(en);
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void MainDishButtonSettings(ButtonMenu en)
        {
            bMainDish.BackColor = Color.LawnGreen;
            VisibleSideDishe(en);          
            ChengeNameLabelMenuInfo(en);
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void SoupsButtonSettings(ButtonMenu en)
        {
            bSoups.BackColor = Color.LawnGreen;
            VisibleSideDishe(en);          
            ChengeNameLabelMenuInfo(en);
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void DrinkseButtonSettings(ButtonMenu en)
        {
            bDrinks.BackColor = Color.LawnGreen;
            VisibleSideDishe(en);          
            ChengeNameLabelMenuInfo(en);
            SetVisibleButtonDishesOK(false);
            SetVisibleTextViewDishesQuantity(false);
        }

        private void VisibleSideDishe(ButtonMenu en)
        {
            LoadListOfSideDishes loadListOfSideDishes = new LoadListOfSideDishes();
            chListBoxSideDishes.Visible = true;

            switch (en)
            {
                case ButtonMenu.MainDish:
                    LoadCheckListBoxSideDishe(loadListOfSideDishes.LoadSideMainDish()); break;
                case ButtonMenu.Pizza:
                    LoadCheckListBoxSideDishe(loadListOfSideDishes.LoadSidePizza()); break;
                default:
                    ClearCheckListBoxSideDishe();
                    chListBoxSideDishes.Visible = false;
                    break;
            }
        }

        private void LoadCheckListBoxSideDishe(List<string> sideDishes)
        {          
            chListBoxSideDishes.Items.Clear();
            foreach (var st in sideDishes)
            {
                chListBoxSideDishes.Items.Add(st);
            }
        }

        private void ClearCheckListBoxSideDishe()
        {
            chListBoxSideDishes.Items.Clear();
        }

        private List<Dish> listDisch = new List<Dish>();
        private Form1LoadDishesPresenters loadListViewDishes;
        private void LoadListViewDishes(ButtonMenu en)
        {           
            loadListViewDishes = new Form1LoadDishesPresenters(this);

            switch (en)
            {
                case ButtonMenu.Pizza: loadListViewDishes.LoadPizza(); 
                    break;
                case ButtonMenu.MainDish:
                    loadListViewDishes.LoadMainDish(); 
                    break;
                case ButtonMenu.Soups:
                    loadListViewDishes.LoadSoups();
                    break;
                case ButtonMenu.Drinks:loadListViewDishes.LoadDrinks(); 
                    break;
            }         
        }

        private void ClearColorButton()
        {
            bPizza.BackColor = SystemColors.Control;
            bMainDish.BackColor = SystemColors.Control;
            bSoups.BackColor = SystemColors.Control;
            bDrinks.BackColor = SystemColors.Control;
        }

        private void ChengeNameLabelMenuInfo(ButtonMenu en)
        {
            switch (en)
            {
                case ButtonMenu.Pizza: lMenuInfo.Text = "Pizza"; 
                    break;
                case ButtonMenu.MainDish: lMenuInfo.Text = "Dania główne"; 
                    break;
                case ButtonMenu.Soups: lMenuInfo.Text = "Zupy"; 
                    break;
                case ButtonMenu.Drinks: lMenuInfo.Text = "Napoje"; 
                    break;
            }
        }


        private void ButtonPizza_Click(object sender, EventArgs e)
        {
            Start(ButtonMenu.Pizza);
            LoadListViewDishes(ButtonMenu.Pizza);
        }

        private void ButtonMainDish_Click(object sender, EventArgs e)
        {
           Start(ButtonMenu.MainDish);
           LoadListViewDishes(ButtonMenu.MainDish);

        }

        private void ButtonDrinks_Click(object sender, EventArgs e)
        {
           Start(ButtonMenu.Drinks);
           LoadListViewDishes(ButtonMenu.Drinks);
        }

        private void ButtonSoup_Click(object sender, EventArgs e)
        {
            Start(ButtonMenu.Soups);
            LoadListViewDishes(ButtonMenu.Soups);
        }

        private void LabelPrice()
        {
            
            lPrice.Text = "Cena: " + addOrder.PriceCalculation(ListViewOrder).ToString() + "zł";
        }

       
        private string sendMesseg;

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
           
            if (ChceckListViewOrderIsNotEpmty())
            {
               
                addOrder.SetCommentsAndDate(tComments.Text);
                addOrder.SetListDenmark(ListViewOrder);         
                EmailMessage messeg = new EmailMessage(addOrder.GetOrder());              
                sendMesseg = messeg.WriteBill();
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Przetwarzanie danych proszę czekać", "Przetwarzanie danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
            else
            {
                MessageBox.Show("Proszę wybrać produkt", "Brak produktu na liście", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool ChceckListViewOrderIsNotEpmty()
        {
            if (ListViewOrder.Items.Count > 0) return true;
            else return false;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {            
            AddDishesToListViewOrder();
            SetVisibleButtonRemoveAll();
            LabelPrice();
        }

        private void AddDishesToListViewOrder()
        {
            if (CheckNumberTextViewDishes()>0)
            {
                Dish dish = listDisch[CheckListDishesSelectedItem()];
               
                for (int i = 0; i < CheckNumberTextViewDishes(); i++)
                {
                    ListViewItem lvi; 
                    if (CheckSelecktSideDishes().Equals(""))
                    {
                        lvi = new ListViewItem(dish.Name);                       
                        lvi.SubItems.Add(CheckSelecktSideDishes());
                        lvi.SubItems.Add(dish.Price);
                    }
                    else
                    {
                        lvi = new ListViewItem(dish.Name +" -"+ dish.Price);                
                        lvi.SubItems.Add(CheckSelecktSideDishes());
                        lvi.SubItems.Add(PriceDisheAndSide(dish.Price));
                    }
                    ListViewOrder.Items.Add(lvi);
                }
            }
        }

        private string CheckSelecktSideDishes()
        {
            string side = "";
            foreach (object item in chListBoxSideDishes.CheckedItems)
            {
                if (side.Equals(""))
                {
                    side += item.ToString();
                }
                else
                {
                    side += ", ";
                    side += item.ToString();
                }
            }
            if (side.Equals("")) return side;
            else return side + ".";
        }

        private string PriceDisheAndSide(string priceDish)
        {        
            string priceSide;
            int priceAll = addOrder.FindsPrice(priceDish);

            foreach (object item in chListBoxSideDishes.CheckedItems)
            {
                priceSide = item.ToString();
                priceAll += addOrder.FindsPrice(priceSide);
            }
            return  priceAll + "zł";
        }



        private int CheckListDishesSelectedItem()
        {
            return listViewDish.FocusedItem.Index;
        }

        private int CheckNumberTextViewDishes()
        {
            int number = CheckTextIsNumber(textViewDishes.Text);
            if (number > 0) return number;
            else return number;
        }

        private int CheckTextIsNumber(string textNumber)
        {
            int number = 0;
            try
            {
                number = Convert.ToUInt16(textNumber);
            }
            catch
            {
                MessageBox.Show("Podana ilość produktów nie jest prawidłowa", "Podaj ilość produktów", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return number;
        }

        private void ButtonRemoveListBox_Click(object sender, EventArgs e)
        {
            if (ListViewOrder.SelectedItems.Count == 0) return;
            ListViewOrder.SelectedItems[0].Remove();
            LabelPrice();
           
            SetVisibleButtonRemoveAll();
            SetVisibleButtonRemove();
            bRemoveListBox.Visible = false;
        }

        private void ButtonRemoveAllListBox_Click(object sender, EventArgs e)
        {
            ListViewOrder.Items.Clear();
            LabelPrice();
            bOrder.BackColor = SystemColors.Control;
            SetVisibleButtonRemoveAll();
            SetVisibleButtonRemove();
        }

        private void AddressEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMail fm = new FormMail(form1);
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
                MessageBox.Show("Historia jeszcze nie gotowa", "Przetwarzanie danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        Save save = new Save();

       

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            bOrder.BackColor = Color.Firebrick;
           
            if (SendEmail(sendMesseg))
            {
                
                save.SaveOrder(Save.ChoiceSaveOrder.Txt,addOrder.GetOrder());
                save.SaveOrder(Save.ChoiceSaveOrder.Sql, addOrder.GetOrder());               
            }
            else
            {
                MessageBox.Show("Wysłanie wiadomości nie powiodło się. Problem z adres e-mail lub z połaczeniem internetowym","Wysłanie zamówienia nie powiodło się", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool SendEmail (string message)
        {
            Email email = new Email();                   
            return email.SendEmail(message);
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bOrder.BackColor = SystemColors.Control;
            if (ListViewOrder.Items.Count > 0) bOrder.BackColor = Color.LawnGreen;
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
            if (ListViewOrder.Items.Count > 0) return true;
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
            if (visalbe) textViewDishes.Visible = true;            
            else
            {
                CleaningTextViewDishesQuantity();
                textViewDishes.Visible = false;
            }
        }

        private void CleaningTextViewDishesQuantity()
        {
            textViewDishes.Text = "1";
        }

      
    }
}

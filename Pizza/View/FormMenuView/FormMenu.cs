using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Pizza.Models.FilesTXT;
using Pizza.Models.Registry;
using Pizza.Models.SqlLite;
using Pizza.Presenters.Email;
using Pizza.Presenters.PresenterFormMenu;
using Pizza.SqlLite;
using Pizza.View.Form1;
using Pizza.View.Form1View.ViewSettings.ButtonMenu;
using Pizza.View.FormMenuView.InterfaceFormMenu;


namespace Pizza
{

    public partial class FormMenu : Form, IForm1ListViewDishes, IForm1ListViewOrder, IFormMenuButtonMenu,
                                     IForm1ChecedListBoxSides, IForm1AddButton, IForm1QuantityTextBox, IFrom1InfoLabel,
                                     IFormMenuLabelPrice, IButtonRemove, IButtonSend, ITextBoxComments, IFormMenuBackgroundWorker
    {
        public FormMenu ()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private IPrice _price;
        IListSet<Dish> _setDishes;
        IListSet<string> _setSides;
        ButtonMenuView _buttonMnuView;
        MenuDishes<ListDishes,ListSides> _menu;


        private void Form1_Load_1 ( object sender, EventArgs e )
        {
            _setDishes = new DishesListView( this );
            _setSides = new SidesCheckListBox( this );
            _price = new OrderListView( this );
            _buttonMnuView = new ButtonMenuView( this );
            _menu = new MenuDishes<ListDishes, ListSides>( new ListDishes(), new ListSides() );
            _menu.CreateMenuPizza( new DishesListView( this ), new SidesCheckListBox( this ) );
            new CreateSQLiteTables().CreateSqliteTables();
            new ButtonMenuView( this ).PizzaButtonSettings();
            new ButtonRemoveView( this ).RemoveAll();
        }

        public ListView ListViewDishes { get => listViewDish; set => listViewDish = value; }
        public CheckedListBox CheckedListBoxSide { get => chListBoxSideDishes; set => chListBoxSideDishes = value; }
        public TextBox TextBoxQuantityDishes { get => textBoxQuantityDishes; set => textBoxQuantityDishes = value; }
        public ListView ListViewOrder { get => listViewOrder; set => listViewOrder = value; }
        public BackgroundWorker BackgroundWorker { get => backgroundWorker1; set => backgroundWorker1 = value; }
        public TextBox TextBoxComments { get => tComments; set => tComments = value; }
        public Button PizzzaButton { get => bPizza; set => bPizza = value; }
        public Button MainButton { get => bMainDish; set => bMainDish = value; }
        public Button SoupButton { get => bSoups; set => bSoups = value; }
        public Button DrinksButton { get => bDrinks; set => bDrinks = value; }
        public Button AddButton { get => bAddDish; set => bAddDish = value; }
        public TextBox QTextbox { get => textBoxQuantityDishes; set => textBoxQuantityDishes = value; }
        public Label LabelMenu { get => lMenuInfo; set => lMenuInfo = value; }
        public Label LabelPrice { get => lPrice; set => lPrice = value; }
        public Button ButtonRemoveOne { get => bRemoveListBox; set => bRemoveListBox = value; }
        public Button ButtonRemoveAll { get => bRemoveAllListBox; set => bRemoveAllListBox = value; }
        public Button ButtonSubmitOrder { get => bOrder; set => bOrder = value; }

        private void ButtonPizza_Click ( object sender, EventArgs e )
        {
            _menu.CreateMenuPizza( _setDishes, _setSides );
            _buttonMnuView.PizzaButtonSettings();
        }

        private void ButtonMainDish_Click ( object sender, EventArgs e )
        {
            _menu.CreateMenuMainDishes( _setDishes, _setSides );
            _buttonMnuView.MainDishButtonSettings();
        }

        private void ButtonDrinks_Click ( object sender, EventArgs e )
        {
            _menu.CreateMenuDrinks( _setDishes, _setSides );
            _buttonMnuView.DrinkseButtonSettings();
        }

        private void ButtonSoup_Click ( object sender, EventArgs e )
        {
            _menu.CreateMenuSoups( _setDishes, _setSides );
            _buttonMnuView.SoupsButtonSettings();
        }

        private void ButtonOrder_Click ( object sender, EventArgs e )
        {
            var order = new OrderListView(this);
            var sendOrder = new ButtonPlaceOrderLogic( this, new DialogBox());
            var loadDataEmail = new LoadRegistry();
            var email = new EmailSend(loadDataEmail);
            sendOrder.SetOrder( order, email );
            sendOrder.SaveOrder( new SaveOrderSQL() );
            sendOrder.SaveOrder( new SaveFilesOrder() );
        }

        private void ButtonOk_Click ( object sender, EventArgs e )
        {
            new ButtonOkView( this ).ViewSetting();
            var listOrder = new OrderListView(this);
            var dish = new DishesListView( this );
            var sides = new SidesCheckListBox(this);
            new AddOrder( this, listOrder ).SetOrder( dish, sides );
            new Form1LabelPricePresenter( this ).SetTextLabelPrice( _price );
        }

        private void ListViewDish_SelectedIndexChanged ( object sender, EventArgs e )
        {
            new ListViewDishes( this ).ViewSetting();
        }

        private void ListViewOrder_SelectedIndexChanged ( object sender, EventArgs e )
        {
            bRemoveListBox.Visible = true;
        }

        private void ButtonRemoveListBox_Click ( object sender, EventArgs e )
        {
            new RemovePresenter( this ).RemoveOne();
            new ButtonRemoveView( this ).RemoveOne();
        }

        private void ButtonRemoveAllListBox_Click ( object sender, EventArgs e )
        {
            new ButtonRemoveView( this ).RemoveAll();
            new RemovePresenter( this ).RemoveAll();
        }

        private void AddressEmailToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FormMail fm = new FormMail();
            fm.ShowDialog();
            fm.Close();
        }

        private void HistoryToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            if (backgroundWorker1.IsBusy != true)
            {
                FormHistory fm = new FormHistory();
                fm.ShowDialog();
                fm.Close();
            }
            else
            {
                MessageBox.Show( "Historia jeszcze nie gotowa", "Przetwarzanie danych" );
            }
        }

        private void BackgroundWorker1_DoWork ( object sender, DoWorkEventArgs e )
        {
            ButtonSubmitOrder.BackColor = Color.Firebrick;
        }

        private void BackgroundWorker1_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e )
        {
            ButtonSubmitOrder.BackColor = Color.LawnGreen;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Pizza
{

  

    public class LoadingFilesTxt : ILoadHistoryOrders
    {     
        const string folderDatabase = @"c:\SQL\Konsola\sqlite\Historia zamówień.txt";
        Name name = new Name();

        private class Text
        {
            public string loadText;
            public string newText;
            public string orderText;
        }

        private List<Order> LoadOrderListFromTxt()
        {
            Text text = Load();
            List<Order> orderList = new List<Order>();
            int id = 0;

            HelpFinding help = new HelpFinding();
            if (help.CheckStringIsNotEmpty(text.loadText)) text.newText = text.loadText;
            while (help.CheckStringIsNotEmpty(text.newText))
            {
                    text = FindinSingleOrder(text);
                    if (help.CheckStringIsEmpty(text.orderText))
                    {
                        break;
                    }
                    else
                    {
                        id++;            
                        Order order = new Order();                       
                        CreateOrder(text.orderText, order,id);                      
                        orderList.Add(order);
                    }               
            }
            return orderList;
        }

        private Text Load()
        {
            Text text = new Text() { loadText = ""};

            try
            {
                using (StreamReader streamR = new StreamReader(folderDatabase))
                {
                    text.loadText = streamR.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show("Problem z odczytem pliku", "Wczytywanie pliku txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return text;
        }

        private Text FindinSingleOrder(Text orderText)
        {
                int beginIndexOrder, endIndexOrder;            
                beginIndexOrder = orderText.newText.IndexOf(name.BeginningOfOrderCode);               
                endIndexOrder = orderText.newText.IndexOf(name.EndOfOrderCode);
                if (beginIndexOrder < 0)
                {                    
                    orderText.orderText = "";
                }
                else
                {              
                orderText.orderText = LoadOrderText(beginIndexOrder, endIndexOrder, orderText.newText);               
                orderText.newText = RemoveOrderFromNowyText(beginIndexOrder, endIndexOrder, orderText.newText);
                }
            
            return orderText;
        }

        private string LoadOrderText (int beginer, int end, string newText)
        {
           return newText.Substring(beginer + name.BeginningOfOrderCode.Length, end - beginer - name.EndOfOrderCode.Length);
        }

        private string RemoveOrderFromNowyText (int beginer, int end, string newText)
        {
            return newText.Remove(beginer, name.BeginningOfOrderCode.Length + end - beginer);
        }

        private void CreateOrder(string textOrder, Order order,int id)
        {          
            order.PriceAll.ID = id;
            AddPriceAll(textOrder, order.PriceAll);
            textOrder=FindTextPriceAndRemove(textOrder);
            AddDisheToList(order,textOrder,id);
        }

        private string FindTextPriceAndRemove(string textOrder)
        {
            int indexEnd = textOrder.IndexOf(name.PriceAllEnd) + name.PriceAllEnd.Length;
            return textOrder.Remove(0, indexEnd);
        }

        private void AddPriceAll(string order, PriceAll priceAll)
        {
            try
            {
                int idexEnd = order.IndexOf(name.PriceAllEnd);
                string stPriceAll = order.Substring(0, idexEnd);
                int indexComments = stPriceAll.IndexOf(name.Comments) + name.Comments.Length;
                int indexCommentsRemove = stPriceAll.IndexOf(name.Comments);
                int indexData = stPriceAll.IndexOf(name.Date) + name.Date.Length;
                int indexDataRemove = stPriceAll.IndexOf(name.Date);
                int indexPriceAll = stPriceAll.IndexOf(name.PriceAll) + name.PriceAll.Length;

                priceAll.Comments = RemoveWhiteChar(stPriceAll.Substring(indexComments));
                stPriceAll = RemoveWorkAndTextToEnd(stPriceAll, indexCommentsRemove);
                priceAll.Date = RemoveWhiteChar(stPriceAll.Substring(indexData));
                stPriceAll = RemoveWorkAndTextToEnd(stPriceAll, indexDataRemove);
                priceAll.Price = RemoveWhiteChar(stPriceAll.Substring(indexPriceAll));

            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "AddPriceAll");
            }
        }  

        private string RemoveWorkAndTextToEnd(string priceAll, int index)
        {
            return priceAll.Remove(index);
        }

        private string RemoveWhiteChar (string text)
        {
            return text.Trim();
        }

        private void AddDisheToList(Order order,string textDishes, int id)
        {
            HelpFinding help = new HelpFinding();
            while (help.CheckStringIsNotEmpty(textDishes))
            {               
                string oneDish = FindOneDishAndReturn(textDishes);
                Dish dish = AddDishWithText(CreationNewDishObject(id), oneDish);
                order.AddDishToListDisch(dish);
                textDishes = FindDishAndRemove(textDishes);
                textDishes = RemoveWhiteChar(textDishes);
            }
        }

        private Dish CreationNewDishObject (int id)
        {
            Dish dish = new Dish() { IdPrice = id };
            return dish;
        }

        private string FindDishAndRemove (string textDishes)
        {
            int indexEnd = textDishes.IndexOf(name.DishEnd);
            if (indexEnd < 0) return textDishes.Remove(0);
            else
            {
                indexEnd = indexEnd + name.DishEnd.Length;
                return textDishes.Remove(0, indexEnd);
            }
        }

        private string FindOneDishAndReturn(string textDishes)
        {
            string dish;
            int indexDishStart = textDishes.IndexOf(name.DishBeginning)+name.DishBeginning.Length;
            int indexDishEnd = textDishes.IndexOf(name.DishEnd);
            int lenghtTextDish = indexDishEnd - indexDishStart;

            if (indexDishEnd < 0) 
            { 
                return dish=""; 
            }
            else
            {
                dish = textDishes.Substring(indexDishStart, lenghtTextDish);
                dish = RemoveWhiteChar(dish);
                return dish;
            }           
        }

        private Dish AddDishWithText(Dish dish, string textDish)
        {
 
            try
            {
                int indexSidesDishes = textDish.IndexOf(name.SidesDishes) + name.SidesDishes.Length;
                int indexSidesDishessRemove = textDish.IndexOf(name.SidesDishes);
                int indexPrice = textDish.IndexOf(name.Price) + name.Price.Length;
                int indexPriceRemove = textDish.IndexOf(name.Price);
                int indexName = textDish.IndexOf(name.Dish) + name.Dish.Length;

                dish.SidesDishes = RemoveWhiteChar(textDish.Substring(indexSidesDishes));
                textDish = RemoveWorkAndTextToEnd(textDish, indexSidesDishessRemove);
                dish.Price = RemoveWhiteChar(textDish.Substring(indexPrice));
                textDish = RemoveWorkAndTextToEnd(textDish, indexPriceRemove);
                dish.Name = RemoveWhiteChar(textDish.Substring(indexName));
            }

            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "AddPriceAll");
            }

            return dish;
        }

        public List<Order> LoadHistory()
        {
            return LoadOrderListFromTxt();
        }
    }

   

  



}

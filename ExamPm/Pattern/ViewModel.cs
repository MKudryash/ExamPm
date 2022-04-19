using DllCulculationDiscount;
using ExamPm.FolderClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExamPm.Pattern
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //получение списка из базы данных
        static List<Books> AllBooks = BaseConnect.BaseModel.Books.ToList();
        CalculationDiscount calculationDiscount = new CalculationDiscount();

        ObservableCollection<Books> BooksCollection = new ObservableCollection<Books>(AllBooks);


        public ObservableCollection<Books> GetBooks
        {
            get
            {
                return BooksCollection;
            }
        }
       
        //перменные для подсчета цены, скидки и колчиества
        public int PriceOrder { get; set; } = 0;
        public int CountBookBasket { get { return basketStructure.Count; } set { } }
        public int DiscountUser
        {
            get => calculationDiscount.CalculationsDiscount(CountBookBasket, PriceOrder);
        }
        public string priceOrderTwo { get; set; } = "";

        public bool discointHave
        {
            get 
            {
                if (DiscountUser > 0)
                {
                   
                    priceOrderTwo = Convert.ToString(Math.Truncate((decimal)(PriceOrder - PriceOrder / 100 * DiscountUser)-1));
                    
                    PropertyChanged(this, new PropertyChangedEventArgs("priceOrderTwo"));
                    return true;
                }
                else return false;

            }
        }

        public bool isEnableBookAdd;
        public bool IsEnableBookAdd
        {
            get
            {
                if (Book == null || (bookss.Single(x => x == Book).CountMarket == 0 && bookss.Single(x => x == Book).CountStock == 0))
                    return false;
                else return true;

            }
        }


        //передавыемые объекты из Листа
        public BasketStructure basket;
        public BasketStructure Basket
        {
            get {
                
                return basket; }
            set { basket = value; }
        }

        public Books book;
        public List<Books> bookss = BaseConnect.BaseModel.Books.ToList();
        public Books Book
        {
            get {return book; }
            set
            {
                book = value;
            }
        }
        static List<BasketStructure> basketStructure { get; set; } = new List<BasketStructure>();

        ObservableCollection<BasketStructure> BasketCollection = new ObservableCollection<BasketStructure>(basketStructure.ToList());


        public ObservableCollection<BasketStructure> GetBasket
        {
            get
            {
                return new ObservableCollection<BasketStructure>(basketStructure.ToList());
            }
        }



        //добавление книги в корзину
        public RoutedCommand AddBookBasketCommand { get; } = new RoutedCommand();
        public CommandBinding AddBookBasketBinding;


        public RoutedCommand EndOrderCommand { get; } = new RoutedCommand();
        public CommandBinding EndOrderBinding;

        public ViewModel()
        {
            AddBookBasketBinding = new CommandBinding(AddBookBasketCommand);
            AddBookBasketBinding.Executed += AddBookBasketBinding_Executed;


            EndOrderBinding = new CommandBinding(EndOrderCommand);
            EndOrderBinding.Executed += EndOrderBinding_Executed;
        }

        private void EndOrderBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (bookss.FirstOrDefault(x => x.CountStock > 0).BookOrder.Count > 0)
                MessageBox.Show($"Номер заказа: 001\n Количество книг:{bookss.Count}\n Цена со скидкой: {PriceOrder}\n Скидка: {DiscountUser}\n Заказ можно забрать{DateTime.Now}\n Со склада:{DateTime.Now.AddDays(3)} \n Срок резервации:{DateTime.Now.AddDays(7)}");
            else
            {
                MessageBox.Show($"Номер заказа: 001\n Количество книг:{bookss.Count}\n Цена со скидкой: {PriceOrder}\n Скидка: {DiscountUser}\n Заказ можно забрать{DateTime.Now}\n Срок резервации:{DateTime.Now.AddDays(7)}");

            }
            PriceOrder = 0;
            CountBookBasket = 0;
            basketStructure.Clear();
            GetBasket.Clear();
            PropertyChanged(this,new PropertyChangedEventArgs("GetBasket"));
            PropertyChanged(this, new PropertyChangedEventArgs("PriceOrder"));
            PropertyChanged(this, new PropertyChangedEventArgs("CountBookBasket"));
            PropertyChanged(this, new PropertyChangedEventArgs("DiscountUser"));
            PropertyChanged(this, new PropertyChangedEventArgs("discointHave"));
        }

        private void AddBookBasketBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("IsEnableBookAdd"));


            if (Book!=null&&bookss.Single(x => x == Book).CountMarket > 0 || bookss.Single(x => x == Book).CountStock > 0)
            {
                if (!basketStructure.Any(x => x.BookBasket == Book))
                {
                   BasketStructure order = new BasketStructure() { BookBasket = Book };
                    if (Book.CountMarket != order.CountBook && Book.CountMarket > 0)
                    {
                        order.CountBook++;
                        order.CountMarket++;
                        PriceOrder += Convert.ToInt32( Book.Price);
                        CountBookBasket = basketStructure.Count();
                        PropertyChanged(this, new PropertyChangedEventArgs("PriceOrder"));
                        PropertyChanged(this, new PropertyChangedEventArgs("CountBookBasket"));
                        PropertyChanged(this, new PropertyChangedEventArgs("DiscountUser"));
                        PropertyChanged(this, new PropertyChangedEventArgs("discointHave"));
                    }
                    else
                    {
                        if (Book.CountStock != order.CountBook && Book.CountStock > 0)
                        {
                            order.CountBook++;
                            order.CountStock++;
                            PriceOrder += Convert.ToInt32(Book.Price);
                            CountBookBasket = basketStructure.Count();
                            PropertyChanged(this, new PropertyChangedEventArgs("PriceOrder"));
                            PropertyChanged(this, new PropertyChangedEventArgs("CountBookBasket"));
                            PropertyChanged(this, new PropertyChangedEventArgs("DiscountUser"));
                            PropertyChanged(this, new PropertyChangedEventArgs("discointHave"));

                        }
                    }
                    basketStructure.Add(order);
                    CountBookBasket = basketStructure.Count();
                    PropertyChanged(this, new PropertyChangedEventArgs("PriceOrder"));
                    PropertyChanged(this, new PropertyChangedEventArgs("CountBookBasket"));
                    PropertyChanged(this, new PropertyChangedEventArgs("DiscountUser"));
                    PropertyChanged(this, new PropertyChangedEventArgs("discointHave"));
                }
                else
                {
                    BasketStructure selectBook = basketStructure.Single(x => x.BookBasket == Book);
                    if (Book.CountMarket != selectBook.CountBook && Book.CountMarket > 0)
                    {
                        selectBook.CountBook++;
                        selectBook.CountMarket++;
                        PriceOrder += Convert.ToInt32(Book.Price);
                        CountBookBasket = basketStructure.Count();
                        PropertyChanged(this, new PropertyChangedEventArgs("PriceOrder"));
                        PropertyChanged(this, new PropertyChangedEventArgs("CountBookBasket"));
                        PropertyChanged(this, new PropertyChangedEventArgs("DiscountUser"));
                        PropertyChanged(this, new PropertyChangedEventArgs("discointHave"));
                    }
                    else
                    {
                        if (Book.CountStock != selectBook.CountBook && Book.CountStock > 0)
                        {
                            selectBook.CountBook++;
                            selectBook.CountStock++;
                            PriceOrder += Convert.ToInt32(Book.Price);
                            CountBookBasket = basketStructure.Count();
                            PropertyChanged(this, new PropertyChangedEventArgs("PriceOrder"));
                            PropertyChanged(this, new PropertyChangedEventArgs("CountBookBasket"));
                            PropertyChanged(this, new PropertyChangedEventArgs("DiscountUser"));
                            PropertyChanged(this, new PropertyChangedEventArgs("discointHave"));
                        }
                    }
                }
            }
        }

     
      
    }
}

using ExamPm.FolderClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPm.Pattern
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        static List<Books> AllBooks = BaseConnect.BaseModel.Books.ToList();

        ObservableCollection<Books> BooksCollection = new ObservableCollection<Books>(AllBooks);


        public ObservableCollection<Books> GetBooks
        {
            get
            {
                return BooksCollection;
            }
        }

    }
}

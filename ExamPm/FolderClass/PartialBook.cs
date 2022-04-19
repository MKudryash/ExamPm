using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPm.FolderClass
{
    public partial class Books
    {
        public string GetImage
        {
            get
            {
                if (Cover == "")
                    return "";
                else
                    return Environment.CurrentDirectory +"\\"+ Cover;
            }
        }

        public string CountMatrket
        {
            get
            {
                if (CountMarket == 0) return "Нет";
                if (CountMarket > 5) return "Много";
                return CountMarket.ToString();
            }
        }
        public string CountStocks
        {
            get
            {
                if (CountStock == 0) return "Нет";
                if (CountStock > 5) return "Много";
                return CountStock.ToString();
            }
        }
    }
}

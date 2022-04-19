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
                    return Environment.CurrentDirectory + Cover;
            }
        }
    }
}

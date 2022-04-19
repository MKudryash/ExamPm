using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCulculationDiscount
{
   public class CalculationDiscount
    {
        public  int CalculationsDiscount(int count, int price)
        {
            int discountUser = 0;
            if (count >= 3)
            {
                discountUser = 5;
            };
            if (count >= 5)
            {
                discountUser = 10;
            };
            if (count >= 10)
            {
                discountUser = 15;
            };
            int k = (int)Math.Truncate((decimal)(price / 500));
            discountUser += k;
            return discountUser;
        }
    }
}

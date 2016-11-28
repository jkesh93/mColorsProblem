using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backNapObject
{
    public class BackNap
    {
        int maxProfit = 0;
        int numbest = 0;

        public BackNap(int numItems, int index, int profit, int weight, int ksWeight)
        {
            // If we're in the specified weight Range AND the profit is greater than our current best --> add this item;
            if(weight <= ksWeight && profit > maxProfit)
            {
                maxProfit = profit;
                numbest = index;
                

            }
        }


    }
}

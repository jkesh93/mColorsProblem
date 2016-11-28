using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backNapObject
{
    public class BackNap
    {
        // arrays
        int[] weights;
        int[] profits;
        float[] priceWeight;

        // general figures
        int maxProfit = 0;
        bool[] bestSet;
        int index = 0;
        String[] data;

        // item variables
        int profit;
        int weight;
        

        // store variables
        int numItems;
        
        // knapSack variable
        int WeightCap;

      



        public BackNap(int numItems, int index, int weight, String[] data)
        {
            // we're going to use numItems here for other things so set class variable to passed in variable;
            this.numItems = numItems;

            // give us an index to start out with;
            this.index = index;

            // hold our weight capacity;
            WeightCap = weight;

            // build our weights and profits array to be the correct size;
            weights = new int[numItems];
            profits = new int[numItems];

            // configure our data;
            this.data = data;
        }

        public void solve()
        {
            dataSort(data);
        }

        public void knapSack(int i, int profit, int weight)
        {

        }

        public void dataSort(String[] data)
        {
            // Special thanks to http://stackoverflow.com/questions/8866414/how-to-sort-2d-array-in-c-sharp Marc Gravell for his
            // post on how to sort 2D arrays

            String[] dataRow;


            for(int i = 1; i < (data.Length); i++)
            {
                // split the current row we're working on into weight(sub-i), profit(sub-i);
                dataRow = data[i].Split(' ');

                // convert to an int array;
                int[] rowResult = Array.ConvertAll<String, int>(dataRow, int.Parse);

                // put data into the correct arrays
                weights[i] = rowResult[0];
                profits[i] = rowResult[1];

            }

            priceWeight = new float[data.Length];
            
            for(int i = 1; i < (data.Length); i++)
            {
                priceWeight[i] = profits[i] / weights[i];
            }

            
            Array.Sort(profits, priceWeight);
            Array.Sort(weights, priceWeight);
            Array.Sort(priceWeight);

            viewProfits();
            viewWeights();
            viewPriceWeight();


        }

        public void viewProfits()
        {
            Console.WriteLine("\nProfits");
            for (int i = 1; i < (data.Length); i++)
            {
                Console.WriteLine(profits[i]);
            }
        }

        public void viewWeights()
        {
            Console.WriteLine("\nWeights");
            for (int i = 1; i < (data.Length); i++)
            {
                Console.WriteLine(weights[i]);
            }
        }

        public void viewPriceWeight()
        {
            Console.WriteLine("\nPrice Weight Ratio");
            for (int i = 1; i < (data.Length); i++)
            {
                Console.WriteLine(priceWeight[i]);
            }
        }



    }


    
}

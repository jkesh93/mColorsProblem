using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapSackObject
{
    public class NapSack
    {
        // Global Variables;

        // item variables;
        int weight;
        int profit;
        
        // general variables
        int maxProfit;
        int W;
        int index = 0;
        int n;

        // arrays;
        int[] profits;
        int[] weights;
        bool[] tryin;
        bool[] bestset;
        string[] data;
        float[] priceWeight;
        bool[] resultArray;




        public NapSack(int index, int numItems, int W, int weight, int profit, string[] data)
        {
            // initialize values;
            this.index = index;
            this.W = W;
            this.weight = weight;
            this.profit = profit;
            this.data = data;
            n = numItems;

            // initialize arrays;
            profits = new int[n];
            weights = new int[n];
            tryin = new bool[n];
            bestset = new bool[n];
            priceWeight = new float[n];
            resultArray = new bool[n];
        }

        // The function which solves it all. This will be the "main" of this class. 
        public void solve()
        {
            stepOne();
            stepTwo();
        }

        public void stepOne()
        {
            // Sorts the data since the algorithm only works with the data sorted by price/weight ratio;
            sortData(data);
        }

        public void stepTwo()
        {
            // Calls the actual knapSack algorithm and displays its output;
            knapSack(index, profit, weight);
            writeSolution();
        }

        public void knapSack(int index, int profit, int weight)
        {
            // Update our variables;
            this.profit = profit;
            this.weight = weight;

            // if the weight is within range and the profit exceeds our current record --> update our maxProfit and our array which holds our solution;
            if(weight <= W && profit > maxProfit)
            {
                maxProfit = profit;
                resultArray = (bool[])tryin.Clone(); // We have to clone the array so that when the function goes "back" it doesn't undo our changes. This is a common issue with setting something equal by reference.
            }

            if (promising(index))
            {
                tryin[index + 1] = true;
                knapSack(index + 1, profit + profits[index + 1], weight + weights[index + 1]);
                tryin[index + 1] = false;
                knapSack(index + 1, profit, weight);
            }
        }

        // knapSack helper function Promising;

            public bool promising(int index)
        {
            int j, k;
            int totWeight;
            float bound;

            if(weight >= W)
            {
                // If our weight exceeds W then we know this to be false;
                return false;
            }
            else
            {
                j = index + 1;
                bound = profit;
                totWeight = weight;
                while( j < n && (totWeight + weights[j]) <= W)
                {
                    // while our 'look-ahead' j is less than n (input size) and our total weigh + the weight of the next item is less than our weightCap;
                    totWeight = totWeight + weights[j];
                    bound = bound + profits[j];
                    j++;
                }
                k = j; // our k stores the highest point we've reached;
                if(k < n)
                {
                    // if our k is within our item count, we add it to the bound;
                    bound = (bound + (W - totWeight)) * (profits[k] / weights[k]);
                }

                return bound > maxProfit; // if our bound exceeds what we're currently making -- we know this node is promising;
            }
        }

        public void sortData(string[] data)
        {
            // Special thanks to http://stackoverflow.com/questions/8866414/how-to-sort-2d-array-in-c-sharp Marc Gravell for his
            // post on how to sort 2D arrays

            String[] dataRow;

            // Put data into the arrays;
            for (int i = 1; i < (data.Length); i++)
            {
                dataRow = data[i].Split(' ');

                // convert to an int array;
                int[] rowResult = Array.ConvertAll<String, int>(dataRow, int.Parse);

                // make sure the rows line up;
                weights[i - 1] = rowResult[0];
                profits[i - 1] = rowResult[1];

            }

            
            for (int i = 0; i < (n); i++)
            {
                priceWeight[i] = profits[i] / weights[i];
            }

            float[] temp = priceWeight;
            

            Console.WriteLine("Sorting arrays");
            Array.Sort(priceWeight, profits);
            Array.Sort(temp, weights);
            Array.Reverse(profits);
            Array.Reverse(priceWeight);

            Console.WriteLine("Completed sorting the arrays");

            // View the data ordered neatly;
            viewNeat();
        }

        public void viewNeat()
        {
            Console.WriteLine("\n\n \tPrice \t Weight \t Price/Weight Ratio");
            for (int i = 0; i < (data.Length - 1); i++)
            {
                Console.Write((i + 1));
                Console.Write("\t " + profits[i] + " \t   " + weights[i] + "\t\t\t" + priceWeight[i] + "\n");
            }
        }

        public void writeSolution()
        {
            int localProfit = 0;
            int localWeight = 0;
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.WriteLine("Include item " + (i + 1) + "?" + " " + resultArray[i]);
                if (resultArray[i])
                {
                    localProfit += profits[i];
                    localWeight += weights[i];
                }
                Console.WriteLine("Profit: " + localProfit + "\t Weight: " + localWeight);
            }
            Console.ReadKey();
        }


    }
}

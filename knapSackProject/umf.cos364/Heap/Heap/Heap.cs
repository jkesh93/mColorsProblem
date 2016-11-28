using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umf.cos364
{
    public class Heap
    {
        /////////////////////////
        // CLASS VARIABLES     //
        /////////////////////////

        public int[] H;
        public int bottom;


        /////////////////////////
        // CONSTRUCTOR METHOD  //
        /////////////////////////

        public Heap(int size)
        {
            H = new int[size + 1];
            bottom = 0;
        }

        /////////////////////////
        //     CLASS METHODS   //
        /////////////////////////

        public void upHeap()
        {
            int k, p;   // p is the parent of k
            int temp;
            k = bottom;
            p = (int)Math.Floor((double)(k / 2)); // why is this like this?? so that when k is 1 (bottom of heap)
                                                  // it won't trigger the heap to be "sorted" but when k is 2 and above
                                                  // it will trigger p to be something else.

            // debugging
            while ((p > 0) && (H[p] < H[k]))
            {
                Console.WriteLine("\nSwapping: H[" + p + "] and H[" + k + "] since H[" + p + "] = " + H[p] + " and H[" + k + "] = " + H[k]);
                temp = H[p];
                H[p] = H[k];
                H[k] = temp;
                Console.WriteLine("H[" + p + "]" + " = " + H[p] + "\nH[" + k + "]" + " = " + H[k]);
                k = p;
                p = (int)Math.Floor((double)(k / 2));
            }

        } // end upHeap;

        public void enHeap(int item)
        {
            int k;
            bottom++; // increment the bottom since we're adding an item to it.
            k = bottom;
            H[k] = item;
            Console.WriteLine("\nAdded: " + item + " to the heap at index: " + k + "\n Heap size: " + k);
            upHeap();
        } // end enHeap;

        public void downHeap()
        {
            int k, p, temp;
            k = bottom;
            p = 1;
            temp = 2;

            while (temp <= bottom)
            {
                if(H[p] < H[temp])
                {
                    int tempHolder;
                    tempHolder = H[p];
                    H[p] = H[temp];
                    H[temp] = tempHolder;
                }

                temp++;
            }
        }

        public int removeTop()
        {
            // removes the top of the heap
            // by taking the top top off, replacing it with the bottom of the heap;
            // it then sifts the top of the heap by 
            int k, t, temp;

            k = bottom; // sets k to equal the bottom of the heap
            temp = H[1];
            H[1] = H[k];
            downHeap();
            bottom -= 1;
            Console.WriteLine("Adding " + temp + " to the array");
            return temp;

        }

        public bool empty()
        {
            if(bottom == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}


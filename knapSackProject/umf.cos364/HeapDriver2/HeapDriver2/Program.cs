using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umf.cos364;  // do this and add Heap to References for HeapDriver

namespace HeapDriver2
{
    class Program
    {
        public static int[] myList = { 20, 21, 18, 25, 22, 26, 29, 14, 15, 17};
        static void Main(string[] args)
        {
            Heap myHeap = new Heap(30);

            for (int i = 0; i < myList.Length; i++)
                myHeap.enHeap(myList[i]);

            int[] sortedList = new int[myList.Length + 1];

            int j = myList.Length;
            Console.WriteLine();
            Console.WriteLine();
            while (!myHeap.empty())
                sortedList[j--] = myHeap.removeTop();


            Console.WriteLine("The sorted array in increasing order:\n");

            for (int i = 1; i < sortedList.Length; i++)
                Console.Write(sortedList[i] + "  ");

            Console.WriteLine();
            Console.ReadKey();

        }
    }
}

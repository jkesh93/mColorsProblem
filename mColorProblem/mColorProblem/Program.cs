using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using colorAlgo;

namespace mColorProblem
{
    class Program
    {
        // get the data;
        static String[] linesDataSet = System.IO.File.ReadAllLines("nodes.txt");
        static int inputSize = 0;
        static int[] dataSetInt;
        static int[] lineNArray;
        static int[,] colorArray;

        // object
        static mColorAlgo colorObject;

        static void Main(string[] args)
        {
            stepOne();
            viewColorArray();
            stepTwo();
            colorObject.viewSolutions();
        }

        static void stepOne()
        {
            // sets the input size;
            getFirstLine(convertStringToIntArray(linesDataSet));
            buildColorArray();
        }

        static void stepTwo()
        {
            colorObject = new mColorAlgo(colorArray, inputSize);
            colorObject.algoRun(-1);
        }

        // Converts String Array to Int Array;
        static int[] convertStringToIntArray(String[] stringArray)
        {
            string[] result = linesDataSet[0].Split(' ');
            int[] resultInt = Array.ConvertAll<string, int>(result, Int32.Parse);
            dataSetInt = resultInt;
            return resultInt;
        }

        // Set inputSize;
        static int[] getFirstLine(int[] data)
        {
            string lineN = linesDataSet[0];
            string[] lineSNArray = lineN.Split(' ');
            lineNArray = Array.ConvertAll<string, int>(lineSNArray, int.Parse);

            inputSize = lineNArray[0];
            return lineNArray;
        }

        // build array;
        static int[,] buildColorArray()
        {
            // the color array to return;
            colorArray = new int[(inputSize), (inputSize)];

            // initialize the array so we see which values are which;


            // building the array W as referenced on page 228;
            for(int i = 0; i <= (inputSize); i++)
            {
                // get the line as an array; eg. 0 1 6 7 = 0th vertex is attached to vertex 1 6 7;
                string[] lineNums = linesDataSet[i].Split(' ');
                int[] lineNumsInt = Array.ConvertAll<string, int>(lineNums, int.Parse);

                // j is jth vertex; That is the ROW;
                int j = lineNumsInt[0];

                // find all the things it is attached to;
                // that is, k will be the start of the line, and it will go through each number and
                // build the array;
                for(int k = 1; k < lineNumsInt.Length; k++)
                {
                    // set those to be true;
                    colorArray[j, lineNumsInt[k]] = 1;
                }

            }

            return colorArray;
        }

        static void viewColorArray()
        {
            Console.WriteLine("Row/Col");
            Console.Write("  ");
            for(int i = 0; i < inputSize; i++)
            {
                Console.Write("   " + i);
            }
            Console.WriteLine();
            for(int i = 0; i < (inputSize); i++)
            {
                Console.Write(i);
                for(int j = 0; j < (inputSize); j++)
                {
                    if (j == 0 && i < 10) { Console.Write(" "); }
                    Console.Write("   " + colorArray[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}

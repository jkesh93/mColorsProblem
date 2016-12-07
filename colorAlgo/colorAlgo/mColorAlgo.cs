using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colorAlgo
{

    public class mColorAlgo
    {
        int numberOfNodes = 0;
        int colorSize = 0;
        int[] vColor;
        int color = 0;
        int n;
        int[,] dataW;
        int m = 4;
        List<int[]> solutionArray;


        public mColorAlgo(int[,] data, int nSize)
        {
            dataW = data;
            n = (nSize-1);
            vColor = new int[nSize];
            solutionArray = new List<int[]>();
        }

        public void algoRun(int i)
        {
            int color = 0;
            

            // for each child u of v;
            for (color = 0; color < m; color++)
            {
               
                if(i == (vColor.Length-1))
                {
                   // Console.WriteLine("Complete");
                    copySolution(vColor);
                    break;
                }
                else
                {
                    // set the color of our next item to color; But we won't pass it.
                    vColor[i + 1] = color;

                    // if this is promising we'll pass it;
                    if (promising(i+1))
                    {
                        algoRun(i + 1);
                    }
                }
               
            }


        }

        public bool promising(int i)
        {
            bool tester = true;
            if (i == 0)
            {
                return tester;
            }
            else
            {
                int j = 0;
                while( j < i && tester)
                {
                    // if connected and same color -- not promising
                    if(dataW[i,j] == 1 && vColor[i] == vColor[j])
                    {
                        tester = false;
                    }
                    j++;
                }
            }

            return tester;

        }

        public void copySolution(int[] solutionToCopy)
        {
            int[] solutionClone = (int[]) solutionToCopy.Clone();
            solutionArray.Add(solutionClone);
        }

        public void viewSolutions()
        {
            Console.WriteLine("Solutions");
            for(int i = 0; i < solutionArray.Count; i++)
            {
                Console.Write("Solution " + (i+1) + "::");
                for(int j = 0; j < solutionArray[i].Length; j++)
                {
                    Console.Write(" " + (solutionArray[i].ElementAt(j)+1));
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

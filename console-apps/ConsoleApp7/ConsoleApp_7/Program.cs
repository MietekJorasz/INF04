using System.Diagnostics.Metrics;

namespace ConsoleApp_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ile wygenerować losowań?");
            int n = int.Parse( Console.ReadLine() );

            int[,] arr = new int[n, 6];

            arr = FillArray(arr);

            ShowResults(arr);

        }

        static void ShowResults(int[,] arr)
        {
            Console.WriteLine("Zestawy wylosowanych liczb: ");

			for (int i = 0; i < arr.GetLength(0); i++)
			{
				Console.Write("\nLosowanie "+(i + 1)+": ");
				for (int j = 0; j < arr.GetLength(1); j++)
				{
                    Console.Write(arr[i, j] + " ");
				}	
			}

            for(int c = 1; c <= 49; c++)
            {
				for (int i = 0; i < arr.GetLength(0); i++)
				{
					int counter = 0;
					for (int j = 0; j < arr.GetLength(1); j++)
					{
						if (arr[i, j] == c)
						{
							counter++;
						}
					}
					Console.Write("\nWystąpienia liczby " + c + ": " + counter);
				}
			}


        }
        static int[,] FillArray(int[,] arr)
        {
            Random random = new Random();

			int[] temp = new int[49];
			for (int i = 0; i < temp.Length; i++)
			{
                temp[i] = i + 1;
			}

			for (int i = 0; i < arr.GetLength(0); i++) 
            {

                for (int j = temp.Length - 1; j > 0; j--)
                {
                    int k = random.Next(j + 1);
                    (temp[j], temp[k]) = (temp[k], temp[j]);
                }

                for (int j = 0; j < 6; j++)
                {
                    arr[i, j] = temp[j];
                    
                }
                
            }


            return arr;
        }
    }
}

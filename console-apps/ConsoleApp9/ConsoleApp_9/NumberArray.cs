using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_9
{
	internal class NumberArray
	{
		public int[] Arr { set; get; }
		
		public NumberArray(int[] arr)
		{
			Arr = arr;
		}

		public void SortNumberArray()
		{
			for (int i = 0; i < Arr.Length; i++)
			{
				int j = MaxNumIndex(i);
				(Arr[i], Arr[j]) = (Arr[j], Arr[i]);
			}

			Console.WriteLine("\nPosortowana tablica: ");

			foreach (var item in Arr)
			{
				Console.Write(item + " ");
			}
		}

		private int MaxNumIndex(int start)
		{
			int MaxNumIndex = start;

			for(int i = start; i < Arr.Length; i++)
			{
				if (Arr[i] > Arr[MaxNumIndex])
				{
					MaxNumIndex = i;
				}
			}

			return MaxNumIndex;
		}


	}
}

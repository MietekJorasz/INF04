namespace ConsoleApp_1
{
    internal class Program
    {
        public class Array
        {
            private int[] Arr {  get; set; }
            private int Size {  get; set; }

            public Array(int size) { 
                this.Size = size;

                Arr = new int[Size];

                Random rand = new Random();

                for (int i = 0; i < Size; i++) {
				    Arr[i] = rand.Next(1, 1000);
				}
			}

            public void ShowArray() {
				for (int i = 0; i < Size; i++)
				{
					Console.WriteLine(i+": "+Arr[i]);
				}
			}

			public int SearchArray(int search)
			{
				for (int i = 0; i < Size; i++)
				{
                    if (Arr[i] == search)
                    {
                        return i;
                    }
				}
                return -1;
			}

			public int OddNums()
			{
                int count = 0;
				for (int i = 0; i < Size; i++)
				{
					if (Arr[i] % 2 != 0)
					{
                        Console.WriteLine(Arr[i]);
                        count++;
					}
				}
				return count;
			}

			public float Avg()
			{
				int sum = 0;
				for (int i = 0; i < Size; i++)
				{
					sum += Arr[i]; 
				}

				return (sum / Size);
			}

		}
        static void Main(string[] args)
        {
            Array arr1 = new Array(21);

            Console.WriteLine("Tablica: ");
            arr1.ShowArray();

            Console.Write("Podaj wartość, aby wyszukać jej index: ");
            int search = Int32.Parse(Console.ReadLine());
            int searchInd = arr1.SearchArray(search);

			if(searchInd > -1)
			{
				Console.WriteLine("Wyszukana wartość ma index: " + searchInd);
			}

            int OddNumsCount = arr1.OddNums();
			Console.WriteLine("Razem nieparzystych: " + OddNumsCount);

			float ArrayAvg = arr1.Avg();
			Console.WriteLine("Średnia wszystkich elementów: " + ArrayAvg);
		}
    }
}

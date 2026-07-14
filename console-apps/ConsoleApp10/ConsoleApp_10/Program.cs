namespace ConsoleApp_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[51];

            Console.Write("Podaj wartość do wyszukwania: ");
            int search = int.Parse(Console.ReadLine());

            arr = FillArray(arr);

            int index = SearchIndex(arr, search);

            Console.WriteLine("Tablica 50-elementowa: ");
			foreach (var item in arr)
			{
                Console.Write(item + ", ");
			}

			if (index != arr.Length - 1)
			{
				Console.WriteLine("Wyszukany index: " + index);
			}
			else
			{
				Console.WriteLine("Nie znaleziono indexu: ");
			}


		}

        static int SearchIndex(int[] arr, int search)
        {
            int i = 0;
            int watcher = arr.Length - 1;
			arr[watcher] = search;

            while (search != arr[i])
            {
                i++;
            }

            return i;
        }

        static int[] FillArray(int[] arr)
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = random.Next(1, 100);
            }

            return arr;
        }
    }
}

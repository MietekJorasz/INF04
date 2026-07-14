namespace ConsoleApp_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++) 
            {
                arr[i] = random.Next(1,1000);
            }

            SortArray(arr);

            Console.WriteLine("Posortowana tablica: ");

            foreach (int i in arr)
            {
                Console.Write(i+", ");
            }
        }

        static void SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
            { 
                for(int j = 1; j < arr.Length-i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
                    }
                }
            }
        }

    }
}

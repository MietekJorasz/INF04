namespace ConsoleApp_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = new int[10];
            int index = 0;
            int output;

            Console.WriteLine("Wypełnij tablicę liczbami całkowitymi.\n");

            try
            {
				do
				{
					index++;
					Console.Write("Podaj " + index + " element tablicy: ");
					output = int.Parse(Console.ReadLine());
                    numbersArray[index - 1] = output;
				} while (numbersArray.Length != index);
			}
            catch (Exception ex)
            {
                Console.WriteLine("Podaj liczbę całkowitą.");
            }

            NumberArray numberArray = new NumberArray(numbersArray);

            numberArray.SortNumberArray();
        }
    }
}

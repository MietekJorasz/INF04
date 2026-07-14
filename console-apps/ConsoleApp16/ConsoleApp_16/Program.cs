namespace ConsoleApp_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char continueGame;
			int x; // liczba kosci do rzucenia

			do
			{
				Console.WriteLine("Ile kostek chcesz rzucić?(3 - 10)");
				x = int.Parse(Console.ReadLine());
			} while (x < 3 && x > 10);

			int[] tab = new int[x]; // tablica do przechowania wylosowanych wartosci

			do
            {
				tab = Draw(x, tab);
				Console.WriteLine("Liczba uzyskanych punktów: "+CountPoints(tab));
				Console.WriteLine("Jeszcze raz? (t/n)");
				continueGame = char.Parse(Console.ReadLine());
			} while (continueGame == 't');
            
        }

		static int[] Draw(int x, int[] tab)
		{
			Random random = new Random();

			for (int i = 0; i < x; i++)
			{
				tab[i] = random.Next(1, 6);
				Console.WriteLine("Kostka " + (i + 1) + ": " + tab[i]);
			}

			return tab;
		}

		static int CountPoints(int[] tab)
		{
			int points = 0;
			int counter = 0;

			for(int i = 1; i <= 6; i++)
			{
				for (int j = 0; j < tab.Length; j++)
				{
					if (i == tab[j])
					{
						counter++;
					}
				}

				if(counter >= 2)
				{
					points += i * counter;
				}

				counter = 0;
			}
			return points;
		}
    }
}

namespace ConsoleApp_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;

			Console.WriteLine("Algorytm euklidesa - NWD(a, b): ");

			try
			{
				do
				{
					Console.Write("Podaj liczbe dodatnia calkowita a: ");
					a = Int32.Parse(Console.ReadLine());
					Console.Write("Podaj liczbe dodatnia calkowita b: ");
					b = Int32.Parse(Console.ReadLine());
				} while (a<0 || b<0);

				Console.WriteLine("NWD(" + a + ", " + b + "): " + NWD(a, b));
			}
            catch (Exception ex) {
				Console.WriteLine("Podaj liczbe całkowita!");
			}


        }

		// *********************************************************************
		// nazwa funkcji:       NWD
		// opis funkcji:        Funkcja oblicza największy wspólny dzielnik 
		//                      dwóch liczb całkowitych dodatnich metodą
		//                      algorytmu Euklidesa.
		// parametry:           a - pierwsza liczba całkowita dodatnia
		//                      b - druga liczba całkowita dodatnia
		// zwracany typ i opis: int, zwracany jest największy wspólny dzielnik
        //                      liczb a i b
		// autor:               00000000000
		// *********************************************************************
		static int NWD(int a, int b)
        {
            while(a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }

            }

            return a;
        }
    }
}

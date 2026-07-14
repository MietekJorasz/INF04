namespace ConsoleApp_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string pesel = "55030101193";

            Console.Write("Podaj numer pesel: ");
            string pesel = Console.ReadLine();

            if (CheckGender(pesel) == 'K')
            {
                Console.WriteLine("Kobieta");
            }
            else
            {
				Console.WriteLine("Mężczyzna");
			}

            if (CheckId(pesel))
            {
                Console.WriteLine("Pesel jest zgodny");
            }
            else
            {
				Console.WriteLine("Pesel jest nie zgodny");
			}

        }


		// *****************************************************************************
		// nazwa funkcji:           CheckGender
		// opis funkcji:            Funkcja sprawdza płeć na podstawie dziesiątej cyfry
		//                          podanego numeru pesel. Jeśli jest parzysty funkcja
		//                          zwraca 'K' (kobieta), a jak jest nieparzysty
		//                          funkcja zwraca 'M' (mężczyzna).
		// parametry:               p - numer pesel
		// zwracany typ i opis:     typ znakowy - zwraca wartość 'K' dla kobiety 
		//                                        lub 'M' dla mężczyzny
		// autor:                   00000000000
		// *****************************************************************************
		static char CheckGender(string p)
        {
            if (int.Parse(p[9].ToString()) % 2 == 0)
            {
                return 'K';
            }
            else
            {
                return 'M';
            }

        }

        static bool CheckId(string p)
        {
            int checkSum = Int32.Parse(p[10].ToString());
            int sum = 0;
            int[] multiplyers = [1, 3, 7, 9, 1, 3, 7, 9, 1, 3];

            for(int i = 0; i < p.Length - 1; i++)
            {
                sum += int.Parse(p[i].ToString()) * multiplyers[i];
            }

            sum %= 10;

            if (sum != 0) 
            {
                sum = 10 - sum;

            }
            
            if(sum == checkSum)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

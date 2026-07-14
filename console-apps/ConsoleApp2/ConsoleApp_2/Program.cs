namespace ConsoleApp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liczba zarejestrowanych osób to "+Osoba.counter);

			Osoba osoba1 = new Osoba();

            Console.Write("Podaj ID: ");
            int id = Int32.Parse(Console.ReadLine());

			Console.Write("Podaj imię: ");
            string name = Console.ReadLine();

			Osoba osoba2 = new Osoba(id, name);

            Osoba osoba3 = new Osoba(osoba2);

            osoba1.ShowPerson("Jan");
			osoba2.ShowPerson("Jan");
			osoba3.ShowPerson("Jan");

			Console.WriteLine("Liczba zarejestrowanych osób to " + Osoba.counter);
		}
    }
}

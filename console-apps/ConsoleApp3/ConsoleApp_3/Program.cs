namespace ConsoleApp_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wypożyczalnia filmów: ");

            Film film1 = new Film();

            Console.WriteLine("Film o tytule \"" + film1.GetTitle() + "\" został wypożyczony " + film1.GetNumberOfRentals() + " razy.");

            film1.SetTitle("Fight club");

			Console.WriteLine("Film o tytule \"" + film1.GetTitle() + "\" został wypożyczony " + film1.GetNumberOfRentals() + " razy.");

			Console.WriteLine("Przed wypożyczeniem, film o tytule \"" + film1.GetTitle() + "\" został wypożyczony " + film1.GetNumberOfRentals() + " razy.");
			
            film1.RentFilm();
			
            Console.WriteLine("Po wypożyczeniu, film o tytule \"" + film1.GetTitle() + "\" został wypożyczony " + film1.GetNumberOfRentals() + " razy.");



		}
    }
}

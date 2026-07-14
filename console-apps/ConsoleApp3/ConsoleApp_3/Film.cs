using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_3
{
	//***************************************************************************************
	//	nazwa klasy: Film
	//
	//	pola:		 Title - tytuł filmu
	//				 NumberOfRentals - liczbę wypożyczeń
	//
	//	metody:		 Film, nic nie zwraca -
	//				 konstruktor klasy Film
	//
	//				 SetTitle, nic nie zwraca -
	//				 metoda ustawiająca tytuł z parametru nie większy niż 20 znaków
	//
	//				 GetTitle, zwraca tytuł -
	//				 metoda pobieracjąca tytuł
	//
	//				 GetNumberOfRentals, zwraca liczbę wypożyczeń -
	//				 metoda pobierająca liczbę wypożyczeń
	//
	//				 RentFilm, nic nie zwraca -
	//				 metoda realizującą inkrementację pola przechowującego liczbę wypożyczeń
	//
	//	informacje:  Klasa Film przechowuje tytuł filmu oraz liczbę jego wypożyczeń
	//				 i udostępnia metody do zarządzania tymi danymi.
	//
	//  autor:		 00000000000
	//***************************************************************************************
	internal class Film
	{
		protected string Title;
		protected int NumberOfRentals;

		public Film()
		{
			Title = "";
			NumberOfRentals = 0;
		}

		public void SetTitle(string title)
		{
			if (0 < title.Length && title.Length <= 20)
			{
				Title = title;
			}
			else
			{
				Console.WriteLine("Tytuł może mieć maksymalnie 20 znaków.");
			}
		}

		public string GetTitle() { 
			return Title;
		}

		public int GetNumberOfRentals()
		{
			return NumberOfRentals;
		}

		public void RentFilm()
		{
			NumberOfRentals++;
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_2
{
	internal class Osoba
	{
		private int Id { get; set; }
		private string Fname { get; set; }

		static public int counter = 0;

		public Osoba()
		{
			this.Id = 0;
			this.Fname = "";
			counter++;
		}

		public Osoba(int id, string fName)
		{
			this.Id = id;
			this.Fname = fName;
			counter++;
		}

		public Osoba(Osoba os)
		{
			this.Id = os.Id;
			this.Fname = os.Fname;
			counter++;
		}

		public void ShowPerson(string name)
		{
			if (this.Fname  == "")
				Console.WriteLine("Brak danych");
			else
				Console.WriteLine("Cześć " + name + ", mam na imię " + this.Fname);

		}

	}
}

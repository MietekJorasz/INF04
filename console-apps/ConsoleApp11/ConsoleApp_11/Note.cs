using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_11
{
	internal class Note
	{
		private static int NoteCounter = 0;
		private int Id;
		protected string Title;
		protected string Description;

		public Note(string title, string description)
		{
			NoteCounter++;

			Title = title;
			Description = description;
			Id = NoteCounter;
		}

		public void ShowNote()
		{
			Console.WriteLine("\nTytuł notatki:\n"+Title+"\n\nTreść notatki:\n"+Description);
		}

		public void ExportNote()
		{
			Console.WriteLine(NoteCounter + ";" + Id + ";" + Title + ";" + Description.Trim());
		}

	}
}

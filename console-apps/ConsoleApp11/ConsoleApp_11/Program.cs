namespace ConsoleApp_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Note[] notes = { new Note("Grocery shopping list", "- 2x Tomato\n- 1x Cucamber\n- 20dag Ham"), new Note("To do list", "- do shopping\n- do dishes") };

            int num = 1;
			foreach (var item in notes)
			{
                Console.WriteLine("\nNote no. " + num);
                item.ShowNote();

                Console.WriteLine("\nExported note no. " + num);
                item.ExportNote();

                num++;
			}

		}
    }
}

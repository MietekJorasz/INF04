namespace ConsoleApp_13
{
    internal class Program
    {
        public static class Tool
        {
            public static int countVowels(string text)
            {
				string vowels = "aąeęiouóyAĄEĘIOUÓY";
				int vowelsCount = 0;

				if (text != "")
				    foreach (var item in text)
                        for (int i = 0; i < vowels.Length; i++)
                            if(item == vowels[i])
                            {
								vowelsCount++;
                                break;
							}
                                
                            

				return vowelsCount;
            }

			public static string eraseRepeats(string text)
			{
                string textCorrected = "";

				if (text != "")
					textCorrected = text[0].ToString();
                

				for (int i = 1; i < text.Length; i++)
				{
				    if(text[i - 1] != text[i])
                    {
                        textCorrected += text[i];
                    }	
				}

				return textCorrected;
			}

		}
        static void Main(string[] args)
        {
            Console.Write("Napisz coś: ");
            string text = Console.ReadLine();

            Console.WriteLine("Liczba samogłosek: " + Tool.countVowels(text));
            Console.WriteLine("Poprawiony tekst: " + Tool.eraseRepeats(text));
            
            
        }
    }
}

namespace ConsoleApp_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj tekst do zaszyfrowania: ");
            string text = Console.ReadLine();
            Console.Write("Podaj klucz do zaszyfrowania: ");
            int key = int.Parse(Console.ReadLine());

            string encryptedText = CaesarEncryption(text, key);

			Console.WriteLine(encryptedText);


		}

        static string CaesarEncryption(string text, int key) 
        {
            if(key == 0)
            {
                return text;
            }

			string encryptedText = "";
            string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            char letter;

			bool temp = true; 

			if (key > 0)
            {
				for (int i = 0; i < text.Length; i++)
				{
					temp = true;
                    for(int j = 0; j < smallLetters.Length; j++)
                    {
                        if (text[i] == smallLetters[j])
                        {
							temp = false;
                            if ((j + key) > 25)
                            {
								letter = smallLetters[j + key - 26];
								encryptedText += letter;
							}
                            else
                            {
								letter = smallLetters[j + key];
								encryptedText += letter;
							}
						}
                    }
					if (temp)
					{
						encryptedText += " ";
					}

				}

				return encryptedText;
            }
            else
            {
				for (int i = 0; i < text.Length; i++)
				{
					temp = true;
					for (int j = 0; j < smallLetters.Length; j++)
					{
						if (text[i] == smallLetters[j])
						{
							temp = false;
							if ((j + key) < 0)
							{
								letter = smallLetters[26 + (j + key)];
								encryptedText += letter;
							}
							else
							{
								letter = smallLetters[j + key];
								encryptedText += letter;
							}
						}

					}
					if (temp)
					{
						encryptedText += " ";
					}
				}

				return encryptedText;
			}
        }
    }
}

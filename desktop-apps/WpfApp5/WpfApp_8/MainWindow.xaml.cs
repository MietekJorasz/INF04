using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		static string CaesarEncryption(string text, int key)
		{
			if (key == 0)
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
					for (int j = 0; j < smallLetters.Length; j++)
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
						encryptedText += text[i];
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
						encryptedText += text[i];
					}
				}

				return encryptedText;
			}
		}

		private void encrypt_Btn_Click(object sender, RoutedEventArgs e)
		{
			string encryptedText = "";

			if(text_TextBox.Text != "" && key_TextBox.Text != "")
			{
				try
				{
					encryptedText = CaesarEncryption(text_TextBox.Text, int.Parse(key_TextBox.Text));
				}
				catch (Exception ex)
				{
					encryptedText = CaesarEncryption(text_TextBox.Text, 0);
				}

				encryptedText_TextBlock.Text = encryptedText;
			}



		}

		private void saveEncryption_Btn_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.ShowDialog();

			File.WriteAllLines(saveFileDialog.FileName, encryptedText_TextBlock.Text.Split("\n"));
			
		}
	}
}
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

namespace WpfApp_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		string password = "";
		public MainWindow()
        {
            InitializeComponent();
        }

		private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
		{
            string lowerCase = "qwertyuiopasdfghjklzxcvbnm";
			string upperCase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string numbers = "1234567890";
            string specialSigns = "!@#$%^&*()_+-=";

			int n = Int32.Parse(passwordLengthTxt.Text);

            Random random = new Random();

			password = "";

			if(n > 3)
			{
				if (upperCase_cb.IsChecked == true)
				{
					password += upperCase[random.Next(0, upperCase.Length - 1)];
				}
				if (numbers_cb.IsChecked == true)
				{
					password += numbers[random.Next(0, numbers.Length - 1)];
				}
				if (specialSigns_cb.IsChecked == true)
				{
					password += specialSigns[random.Next(0, specialSigns.Length - 1)];
				}

				n -= password.Length;

				for (int i = 0; i < n; i++)
				{
					password += lowerCase[random.Next(0, lowerCase.Length - 1)];
				}

				MessageBox.Show(password);
			}
			else
			{
				MessageBox.Show("Hasło musi mieć minimum 4 znaki.");
			}
		}

		private void confirmBtn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Dane pracownika: "+fname.Text+" "+lname.Text+" "+((ComboBoxItem) position.SelectedItem).Content.ToString()+" Hasło: "+password);
		}
	}
}
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		string[] images = ["pocztowka.png", "list.png", "paczka.png"];
        string[] prices = ["Cena: 1 zł", "Cena: 1,5 zł", "Cena: 10 zł"];

        public MainWindow()
        {
            InitializeComponent();

			SetImage(0);

        }

		private void SetImage(int index)
		{
			BitmapImage img = new BitmapImage();

			img.BeginInit();

			img.UriSource = new Uri(images[index], UriKind.RelativeOrAbsolute);

			img.CacheOption = BitmapCacheOption.OnLoad;
			img.EndInit();

			packageImg.Source = img;
			priceTxt.Text = prices[index];
		}

		private void checkPriceBtn_Click(object sender, RoutedEventArgs e)
		{
            if (postcard.IsChecked == true)
				SetImage(0);

			if (list.IsChecked == true)
				SetImage(1);

			if (parcel.IsChecked == true)
				SetImage(2);

		}

		private void submitBtn_Click(object sender, RoutedEventArgs e)
		{
			string regex1 = @"^[0-9]{2}-[0-9]{3}$";
			string regex2 = @"[A-Z,a-z]";

			if (Regex.IsMatch(postNum.Text, regex1))
			{
				MessageBox.Show("Dane przesyłki zostały wprowadzone");
			}
			else
			{
				if (Regex.IsMatch(postNum.Text, regex2))
				{
					MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
				}

				if(postNum.Text.Length != 6)
				{
					MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym");
				}
			}





		}
	}
}
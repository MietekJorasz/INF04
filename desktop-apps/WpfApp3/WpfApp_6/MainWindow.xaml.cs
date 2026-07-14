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

namespace WpfApp_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetProfileImage("000-zdjecie.jpg");

            SetFingerPrintImage("000-odcisk.jpg");
        }

        private void SetProfileImage(string path)
        {
            BitmapImage img = new BitmapImage();

            img.BeginInit();
            
            img.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);

            img.CacheOption = BitmapCacheOption.OnLoad;

            img.EndInit();

            profileImage.Source = img;
        }

		private void SetFingerPrintImage(string path)
		{
			BitmapImage img = new BitmapImage();

			img.BeginInit();

			img.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);

			img.CacheOption = BitmapCacheOption.OnLoad;

			img.EndInit();

            fingerPrintImage.Source = img;
		}

		private void submitBtn_Click(object sender, RoutedEventArgs e)
		{
            string eyeColor = "";

            if (blueRadioBtn.IsChecked == true)
                eyeColor = (string) blueRadioBtn.Content;

			if (greenRadioBtn.IsChecked == true)
				eyeColor = (string) greenRadioBtn.Content;

			if (brownRadioBtn.IsChecked == true)
				eyeColor = (string) brownRadioBtn.Content;


			if (fNameTextBox.Text != "" && lNameTextBox.Text != "" && eyeColor != "") 
            {
			    MessageBox.Show(fNameTextBox.Text + " " + lNameTextBox.Text + " kolor oczu " + eyeColor);
            }
            else
            {
                MessageBox.Show("Wprowadź dane");
            }
		}

		private void numberTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
            string profileImgPath = numberTextBox.Text + "-zdjecie.jpg";
            string fingerPrintImgPath = numberTextBox.Text + "-odcisk.jpg";

            if (File.Exists(profileImgPath) && File.Exists(fingerPrintImgPath)) {
				SetProfileImage(profileImgPath);
				SetFingerPrintImage(fingerPrintImgPath);
            }
            else
            {
                profileImage.Source = new BitmapImage();
				fingerPrintImage.Source = new BitmapImage();
			}
		}
	}
}
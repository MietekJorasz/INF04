
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

namespace WpfApp_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		bool ready = false;
        public MainWindow()
        {
            InitializeComponent();

			ready = true;
        }

		private void redSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (ready)
			{
				previewRect.Fill = new SolidColorBrush(Color.FromRgb((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value));
				redLabel.Content = ((byte) redSlider.Value).ToString();

			}
		}
		private void greenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (ready)
			{
				previewRect.Fill = new SolidColorBrush(Color.FromRgb((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value));
				greenLabel.Content = ((byte) greenSlider.Value).ToString();

			}
		}

		private void blueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (ready)
			{
				previewRect.Fill = new SolidColorBrush(Color.FromRgb((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value));
				blueLabel.Content = ((byte) blueSlider.Value).ToString();

			}
		}

		private void submitBtn_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.ShowDialog();
			File.WriteAllText(saveFileDialog.FileName, redLabel.Content + ", " + greenLabel.Content + ", " + blueLabel.Content);

			colorRGBLabel.Content = redLabel.Content + ", "+ greenLabel.Content + ", " + blueLabel.Content;
			colorRGBLabel.Background = new SolidColorBrush(Color.FromRgb((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value));
		}
	}
}
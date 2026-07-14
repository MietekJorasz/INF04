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

namespace WpfApp_14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public static List<Album> albumList = new List<Album>();
		public static int index = 0;
		public class Album
		{
			public string Artist { set; get; }
			public string AlbumName { set; get; }
			public int SongsNumber { set; get; }
			public int Year { set; get; }
			public Int32 DownloadNumber { set; get; }

			public Album(string artist, string albumName, int songsNumber, int year, Int32 downloadNumber)
			{
				Artist = artist;
				AlbumName = albumName;
				SongsNumber = songsNumber;
				Year = year;
				DownloadNumber = downloadNumber;
			}

			public void ShowAlbum()
			{
				Console.WriteLine(Artist + "\n" + AlbumName + "\n" + SongsNumber + "\n" + Year + "\n" + DownloadNumber + "\n");
			}
		}

		public static void DownloadData()
		{
			
			string path = "Data.txt";
			string content = File.ReadAllText(path);

			string[] items = content.Split("\n");

			for (int i = 0; i < items.Length; i += 6)
			{
				albumList.Add(new Album(items[i].Trim(), items[i + 1].Trim(), int.Parse(items[i + 2]), int.Parse(items[i + 3]), int.Parse(items[i + 4])));
			}
		}

		public MainWindow()
        {
            InitializeComponent();

			DownloadData();

            previousImg.Source = ShowImage("obraz3.png");
            nextImg.Source = ShowImage("obraz2.png");
            vinyl.Source = ShowImage("obraz.png");

			artistName.Text = albumList[index].Artist;
			albumName.Text = albumList[index].AlbumName;
			songNum.Text = albumList[index].SongsNumber.ToString();
			year.Text = albumList[index].Year.ToString();
			downloads.Text = albumList[index].DownloadNumber.ToString();
		}

        public static BitmapImage ShowImage(string path)
        {
			BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
		}

		private void nextBtn_Click(object sender, RoutedEventArgs e)
		{
			if(index == albumList.Count - 1)
			{
				index = 0;
			}
			else
			{
				index++;
			}

			artistName.Text = albumList[index].Artist;
			albumName.Text = albumList[index].AlbumName;
			songNum.Text = albumList[index].SongsNumber.ToString();
			year.Text = albumList[index].Year.ToString();
			downloads.Text = albumList[index].DownloadNumber.ToString();
		}

		private void previosBtn_Click(object sender, RoutedEventArgs e)
		{
			if (index == 0)
			{
				index = albumList.Count - 1;
			}
			else
			{
				index--;
			}

			artistName.Text = albumList[index].Artist;
			albumName.Text = albumList[index].AlbumName;
			songNum.Text = albumList[index].SongsNumber.ToString();
			year.Text = albumList[index].Year.ToString();
			downloads.Text = albumList[index].DownloadNumber.ToString();
		}

		private void downloadBtn_Click(object sender, RoutedEventArgs e)
		{
			downloads.Text = (++albumList[index].DownloadNumber).ToString();
		}
	}
}
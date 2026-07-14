namespace ConsoleApp_14
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
            List<Album> albumList = new List<Album>();   
            string path = "Data.txt";
            string content = File.ReadAllText(path);

            string[] items = content.Split("\n");

            for (int i = 0; i < items.Length; i+=6) 
            {
                albumList.Add(new Album(items[i], items[i + 1], int.Parse(items[i + 2]), int.Parse(items[i + 3]), int.Parse(items[i + 4])));
            }

			foreach (var item in albumList)
			{
                item.ShowAlbum();
			}

		}
    }
}

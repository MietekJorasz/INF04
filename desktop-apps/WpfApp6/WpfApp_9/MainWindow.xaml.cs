using System.Collections.ObjectModel;
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

namespace WpfApp_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Person
        {
            public string Name { set; get; }
            public int Age { set; get; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        ObservableCollection<Person> Persons = new ObservableCollection<Person>();



        public MainWindow()
        {
            InitializeComponent();

            Persons.Add(new Person("Mietek", 18));
			Persons.Add(new Person("Wladek", 16));
			Persons.Add(new Person("Ewa", 42));
			Persons.Add(new Person("Marcin", 50));

			list.ItemsSource = Persons;
        }
    }
}
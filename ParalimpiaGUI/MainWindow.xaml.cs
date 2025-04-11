using System;
using System.Data;
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

namespace ParalimpiaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Paralimpia> adatok = new List<Paralimpia>();
        public int index;
        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in File.ReadAllLines(@"..\..\..\src\ermek.txt").Skip(1))
            {
                var x = item.Split("\t");
                adatok.Add(new Paralimpia(
                    int.Parse(x[0]),
                    x[1],
                    x[2],
                    int.Parse(x[3]),
                    int.Parse(x[4]),
                    int.Parse(x[5]),
                    int.Parse(x[6])
                    ));
            }

            eremtablazat.ItemsSource = adatok;

        }

        private void orszagvagyvaros_TextChanged(object sender, TextChangedEventArgs e)
        {
            eremtablazat.ItemsSource = adatok.Where(a => a.Orszag.StartsWith(orszagvagyvaros.Text) || a.Varos.StartsWith(orszagvagyvaros.Text));
        }

        private void eremtablazat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = eremtablazat.SelectedItem as Paralimpia;
            if (selected == null) return;

            evLabel.Content = selected.Ev;
            aranyTextbox.Text = selected.Arany.ToString();
            ezustTextbox.Text = selected.Ezust.ToString();
            bronzTextbox.Text = selected.Bronz.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (evLabel.Content.ToString() == "####") return;
            var selected = eremtablazat.SelectedItem as Paralimpia;
            var res = MessageBox.Show($"Valóban javaslatot tesz a(z) {selected.Ev}. évi paralimpia éremszámaira?", "Megerősítés", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                using var sw = new StreamWriter("../../../src/javaslat.txt", true, Encoding.UTF8);
                sw.WriteLine($"{DateTime.Now}\tId:{selected.Id}\tÉrmék:\t{aranyTextbox.Text}\t{ezustTextbox.Text}\t{bronzTextbox.Text}");
            }
        }
    }
}
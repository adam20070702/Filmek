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

namespace Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Film
        {
            public string Cím { get; set; }
            public string Műfaj { get; set; }
            public int Hossz { get; set; }
            public double Értékelés { get; set; }

            public Film(string cim, string mufaj, int hossz, double ertekeles)
            {
                Cím = cim;
                Műfaj = mufaj;
                Hossz = hossz;
                Értékelés = ertekeles;
            }
        }
        List<Film> lista = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void betolt_Click(object sender, RoutedEventArgs e)
        {
            lista.Clear();
            lista.Add(new Film("Csillagok háborúja", "sci-fi", 121, 10));
            lista.Add(new Film("Titanic", "dráma", 195, 7.8));
            lista.Add(new Film("A Gyűrűk Ura", "fantasy", 201, 8.8));
            lista.Add(new Film("Mátrix", "sci-fi", 136, 8.7));
            lista.Add(new Film("Shrek", "animáció", 90, 7.9));
            tabla.ItemsSource = lista;
        }

        private void hossz_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve a filmek");
                return;
            }
            Film leghosszabb = lista[0];
            foreach (Film f in lista)
            {
                if (f.Hossz > leghosszabb.Hossz)
                {
                    leghosszabb = f;
                }
            }
            MessageBox.Show("A leghosszabb film: " + leghosszabb.Cím + " (" + leghosszabb.Hossz + " perc)");
        }
        private void atlag_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Nincs betöltve film.");
                return;
            }

            double osszeg = 0;
            foreach (Film f in lista)
            {
                osszeg += f.Értékelés;
            }
            double atlag = osszeg / lista.Count;
            MessageBox.Show("Átlag értékelés: " + Math.Round(atlag,2));
        }

        private void scifi_Click(object sender, RoutedEventArgs e)
        {
            List<Film> uj = new List <Film>();
            foreach (Film f in lista)
            {
                if (f.Műfaj == "sci-fi")
                {
                    uj.Add(f);
                }
            }
            tabla.ItemsSource = uj;
        }

        //private void csakfilm_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void csakcim_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve a filmek.");
                return;
            }

            tabla.ItemsSource = null;
            tabla.ItemsSource = lista.Select(f => new { Cím = f.Cím }).ToList();
        }

        private void rendez_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve a filmek.");
                return;
            }
            tabla.ItemsSource = null;
            tabla.ItemsSource = lista.OrderBy(f => f.Cím).ToList();
        }

        private void filmdarab_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltve a filmek.");
                return;
            }

            MessageBox.Show("Filmek száma:" + lista.Count + "db");
        }
    }
}
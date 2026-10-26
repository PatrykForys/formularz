using System.Windows;
using WpfApp4;

namespace AnkietaWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (KobietaRadio.IsChecked != true &&
                MezczyznaRadio.IsChecked != true)
            {
                MessageBox.Show("Wybierz płeć.");
                return;
            }

            DaneAnkiety dane = new DaneAnkiety
            {
                Plec = KobietaRadio.IsChecked == true ? "K" : "M"
            };

            WiekKolorWindow okno = new WiekKolorWindow(dane);
            okno.Show();
            Close();
        }
    }
}
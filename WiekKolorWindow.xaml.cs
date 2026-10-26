using System.Windows;
using WpfApp4;

namespace AnkietaWPF
{
    public partial class WiekKolorWindow : Window
    {
        private readonly DaneAnkiety _dane;

        public WiekKolorWindow(DaneAnkiety dane)
        {
            InitializeComponent();
            _dane = dane;
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(WiekTextBox.Text, out int wiek) ||
                wiek < 1 || wiek > 120)
            {
                MessageBox.Show("Podaj prawidłowy wiek od 1 do 120.");
                return;
            }

            if (KolorComboBox.SelectedItem is not System.Windows.Controls.ComboBoxItem wybranyKolor)
            {
                MessageBox.Show("Wybierz kolor.");
                return;
            }

            _dane.Wiek = wiek;
            _dane.Kolor = wybranyKolor.Content.ToString() ?? "";

            PodsumowanieWindow okno = new PodsumowanieWindow(_dane);
            okno.Show();
            Close();
        }
    }
}
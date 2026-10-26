using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace AnkietaWPF
{
    public partial class PodsumowanieWindow : Window
    {
        private readonly DaneAnkiety _dane;

        public PodsumowanieWindow(DaneAnkiety dane)
        {
            InitializeComponent();

            _dane = dane;

            StatystykiAnkiety.DodajGlos(_dane);

            OdswiezStatystyki();
        }

        private void OdswiezStatystyki()
        {
            List<DaneAnkiety> glosy = StatystykiAnkiety.PobierzGlosy();

            StatystykiTextBox.Text =
                StatystykiAnkiety.GenerujPodsumowanie(glosy);
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<DaneAnkiety> glosy =
                    StatystykiAnkiety.PobierzGlosy();

                StatystykiAnkiety.ZapiszPodsumowanie(glosy);

                string folder = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "AnkietaWPF");

                MessageBox.Show(
                    $"Zapisano {glosy.Count} głosów.\n\n" +
                    $"Plik: {Path.Combine(folder, "podsumowanie.txt")}",
                    "Zapis zakończony",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu: {ex.Message}");
            }
        }

        private void Zakoncz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
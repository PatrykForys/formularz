using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace AnkietaWPF
{
    public static class StatystykiAnkiety
    {
        private static readonly string Folder =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "AnkietaWPF");

        private static readonly string PlikGlosow =
            Path.Combine(Folder, "glosy.json");

        private static readonly string PlikPodsumowania =
            Path.Combine(Folder, "podsumowanie.txt");

        public static List<DaneAnkiety> PobierzGlosy()
        {
            Directory.CreateDirectory(Folder);

            if (!File.Exists(PlikGlosow))
                return new List<DaneAnkiety>();

            string json = File.ReadAllText(PlikGlosow, Encoding.UTF8);

            return JsonSerializer.Deserialize<List<DaneAnkiety>>(json)
                   ?? new List<DaneAnkiety>();
        }

        public static void DodajGlos(DaneAnkiety dane)
        {
            List<DaneAnkiety> glosy = PobierzGlosy();

            glosy.Add(new DaneAnkiety
            {
                Plec = dane.Plec,
                Wiek = dane.Wiek,
                Kolor = dane.Kolor
            });

            Directory.CreateDirectory(Folder);

            string json = JsonSerializer.Serialize(
                glosy,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(PlikGlosow, json, Encoding.UTF8);

            ZapiszPodsumowanie(glosy);
        }

        public static string GenerujPodsumowanie(
            List<DaneAnkiety> glosy)
        {
            int razem = glosy.Count;
            int kobiety = glosy.Count(x => x.Plec == "K");
            int mezczyzni = glosy.Count(x => x.Plec == "M");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("STATYSTYKI ANKIETY");
            sb.AppendLine("==================");
            sb.AppendLine($"Liczba wszystkich głosów: {razem}");
            sb.AppendLine($"Kobiety (K): {kobiety} ({Procent(kobiety, razem):F1}%)");
            sb.AppendLine($"Mężczyźni (M): {mezczyzni} ({Procent(mezczyzni, razem):F1}%)");
            sb.AppendLine();

            if (razem > 0)
            {
                sb.AppendLine($"Średni wiek: {glosy.Average(x => x.Wiek):F1}");
                sb.AppendLine($"Najmłodszy uczestnik: {glosy.Min(x => x.Wiek)}");
                sb.AppendLine($"Najstarszy uczestnik: {glosy.Max(x => x.Wiek)}");
                sb.AppendLine();

                sb.AppendLine("STATYSTYKI KOLORÓW");
                sb.AppendLine("==================");

                foreach (var grupa in glosy
                    .GroupBy(x => x.Kolor)
                    .OrderByDescending(g => g.Count())
                    .ThenBy(g => g.Key))
                {
                    sb.AppendLine(
                        $"{grupa.Key}: {grupa.Count()} głosów " +
                        $"({Procent(grupa.Count(), razem):F1}%)");
                }

                sb.AppendLine();
            }

            sb.AppendLine("WSZYSTKIE GŁOSY");
            sb.AppendLine("===============");

            for (int i = 0; i < glosy.Count; i++)
            {
                sb.AppendLine($"Głos nr {i + 1}");
                sb.AppendLine($"Płeć: {glosy[i].Plec}");
                sb.AppendLine($"Wiek: {glosy[i].Wiek}");
                sb.AppendLine($"Kolor: {glosy[i].Kolor}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static void ZapiszPodsumowanie(
            List<DaneAnkiety> glosy)
        {
            Directory.CreateDirectory(Folder);

            File.WriteAllText(
                PlikPodsumowania,
                GenerujPodsumowanie(glosy),
                Encoding.UTF8);
        }

        private static double Procent(int liczba, int razem)
        {
            return razem == 0 ? 0 : liczba * 100.0 / razem;
        }
    }
}
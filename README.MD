# AnkietaWPF

## Opis projektu

AnkietaWPF to aplikacja desktopowa napisana w C# z wykorzystaniem technologii WPF (Windows Presentation Foundation). Aplikacja umożliwia zbieranie odpowiedzi ankietowych w kilku etapach, prezentowanie statystyk oraz zapisywanie wyników do plików.

Każdy etap ankiety jest wyświetlany w osobnym oknie.

## Funkcjonalności

- **Etap 1 – wybór płci:** użytkownik wybiera K lub M.
- **Etap 2 – dane uczestnika:** użytkownik podaje wiek i wybiera ulubiony kolor.
- **Etap 3 – podsumowanie:** aplikacja wyświetla statystyki wszystkich zebranych głosów.
- **Zliczanie głosów:** każdy ukończony formularz jest zapisywany jako osobny głos.
- **Statystyki płci:** liczba i procent odpowiedzi K oraz M.
- **Statystyki wieku:** średni wiek, najmłodszy i najstarszy uczestnik.
- **Statystyki kolorów:** liczba głosów i procent dla każdego wybranego koloru.
- **Historia odpowiedzi:** wyświetlanie wszystkich zapisanych głosów.
- **Trwały zapis danych:** wyniki są zachowywane po zamknięciu aplikacji i mogą być uzupełniane kolejnymi odpowiedziami.

## Wymagania

- System operacyjny Windows.
- Visual Studio z obsługą programowania w C#.
- .NET obsługujący WPF oraz `System.Text.Json`.
- Zainstalowany pakiet .NET Desktop Development w Visual Studio.

## Struktura projektu

text

```
AnkietaWPF/
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── WiekKolorWindow.xaml
├── WiekKolorWindow.xaml.cs
├── PodsumowanieWindow.xaml
├── PodsumowanieWindow.xaml.cs
├── DaneAnkiety.cs
└── StatystykiAnkiety.cs
```

## Przebieg ankiety

1. Użytkownik uruchamia aplikację.
2. W pierwszym oknie wybiera płeć.
3. W drugim oknie podaje wiek i wybiera kolor.
4. W trzecim oknie aplikacja zapisuje nowy głos i wyświetla aktualne statystyki.
5. Użytkownik może zapisać podsumowanie do pliku.
6. Po kolejnych wypełnieniach ankiety statystyki uwzględniają również wcześniejsze odpowiedzi.

## Zapis danych

Aplikacja przechowuje dane w katalogu:

text

```
%LOCALAPPDATA%\AnkietaWPF\
```

W katalogu znajdują się dwa pliki:

| Plik | Zawartość |
| --- | --- |
| `glosy.json` | Wszystkie zebrane odpowiedzi w formacie JSON |
| `podsumowanie.txt` | Statystyki zbiorcze i lista wszystkich głosów |

Plik `glosy.json` stanowi bazę odpowiedzi wykorzystywaną do ponownego obliczania statystyk. Plik `podsumowanie.txt` jest aktualizowany na podstawie zapisanych głosów.

## Uruchomienie projektu

1. Otwórz projekt `AnkietaWPF` w Visual Studio.
2. Upewnij się, że projekt ma skonfigurowany odpowiedni framework .NET obsługujący WPF.
3. Ustaw `AnkietaWPF` jako projekt startowy.
4. Uruchom aplikację przyciskiem **Start** lub klawiszem `F5`.
5. Wypełnij ankietę i przejdź do ekranu podsumowania.

## Walidacja danych

- Wybór płci jest wymagany.
- Wiek musi być liczbą całkowitą z zakresu od 1 do 120.
- Wybór koloru jest wymagany.
- Głos jest zapisywany po przejściu do ekranu podsumowania.

## Technologie

- C#
- WPF
- XAML
- .NET
- JSON
- `System.IO`
- `System.Text.Json`

## Możliwe rozszerzenia

- Dodanie kolejnych pytań ankietowych.
- Eksport wyników do CSV lub Excel.
- Wizualizacja statystyk na wykresach.
- Filtrowanie wyników według wieku, płci i koloru.
- Panel administratora.
- Możliwość resetowania zebranych głosów.

## Autor

Projekt edukacyjny prezentujący tworzenie aplikacji okienkowych w WPF, obsługę formularzy, walidację danych, serializację JSON i analizę wyników ankiet.
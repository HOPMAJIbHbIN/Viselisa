using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Viselisa.Manage;

namespace Viselisa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DrawVis _drawVis;
        private readonly WordsCheck _wordsCheck;
        private readonly Vocaburary _vocaburary;


        public MainWindow()
        {
            InitializeComponent();
            _drawVis = new DrawVis(DrawGrid, CanvEllips, ProcherkGrid, ProcherkCanvas);
            _wordsCheck = new WordsCheck(PorajStack, PobedaStack, Letter1, Letter2, Letter3, Letter4,
                Letter5, Letter6, Letter7, Letter8, Letter9, Letter10, Letter11, Letter12, Letter13, Letter14);
            _vocaburary = new Vocaburary(AddWord);
        }
        //мин.Букв = 4; макс.Букв = 14 мб 15
        string word, words;
        int count = 0;
        bool check;
        List<char> arrayLetter = new List<char>();

        //Сложность
        public void Dificulte()
        {
            if (this.EasyDifficulte.IsChecked == true)
            {
                count++;
                _drawVis.DrawViselica(count);
                ErBlock.Text = "Количество возможных ошибок: " + Convert.ToString(_wordsCheck.MistakeCheck(count, check));
            }
            if (this.MiddleDifficulte.IsChecked == true)
            {
                for (int i = 0; i < 2; i++)
                {
                    count++;
                    _drawVis.DrawViselica(count);
                    ErBlock.Text = "Количество возможных ошибок: " + Convert.ToString(_wordsCheck.MistakeCheck(count, check));
                }
            }
            if (this.HardDifficulte.IsChecked == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    count++;
                    _drawVis.DrawViselica(count);
                    ErBlock.Text = "Количество возможных ошибок: " + Convert.ToString(_wordsCheck.MistakeCheck(count, check));
                }
            }
            if (this.UnrealDifficulte.IsChecked == true)
            {
                for (int i = 0; i < 15; i++)
                {
                    count++;
                    _drawVis.DrawViselica(count);
                    _wordsCheck.MistakeCheck(count, check);
                    ErBlock.Text = "Количество возможных ошибок: " + 0;
                }
            }

        }

        //Конопки
        #region
        private void One_button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            check = _wordsCheck.Verification(arrayLetter, button.Content.ToString().ToLower()[0]);
            if (check == false)
            {
                Dificulte();
            }
            button.IsEnabled = false;
        }
        private void PlayBut_Click(object sender, RoutedEventArgs e)
        {
            this.MenuGrid.Visibility = Visibility.Hidden;
            this.GameGrid.Visibility = Visibility.Visible;
        }
        private void ExitBut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void RepidButton_Click(object sender, RoutedEventArgs e)
        {
            Repid();
        }
        private void WordsBut_Click(object sender, RoutedEventArgs e)
        {
            this.MenuGrid.Visibility = Visibility.Hidden;
            this.WordsGrid.Visibility = Visibility.Visible;
        }
        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            _vocaburary.WriteWord();
            AddWord.Text = "";
            Repid();
            MessageBox.Show("Слово успешно добавлено");

        }
        private void AddFinishButton_Click(object sender, RoutedEventArgs e)
        {
            Repid();
        }
        #endregion

        public void Repid()
        {
            MainWindow newGame = new MainWindow();
            Application.Current.MainWindow = newGame;
            newGame.Show();
            this.Close();

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            words = _vocaburary.ReadWords(words);
            string[] wordSplit = words.Split(" ");

            for (int i = 0; i < wordSplit.Length; i++)
                WordsList.Items.Add(wordSplit[i]);
            word = wordSplit[new Random().Next(0, wordSplit.Length)];
            arrayLetter = _wordsCheck.LetterList(word);
            _wordsCheck.InsertWord(arrayLetter);
            _drawVis.DrawLetters(arrayLetter.Count);
        }
    }
}

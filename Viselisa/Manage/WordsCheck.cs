using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Viselisa.Manage
{
    class WordsCheck
    {
        //Конструктор
        #region
        private Grid _loseGrid;
        private Grid _winGrid;
        private TextBlock[] _textBlocks;


        public WordsCheck(Grid LoseGrid, Grid WinGrid, params TextBlock[] Letter)
        {
            _loseGrid = LoseGrid;
            _winGrid = WinGrid;
            _textBlocks = Letter;
        }
        #endregion

        //Методы
        public List<char> LetterList(string word)
        {
            var Letters = new List<char>();
            foreach (var letter in word)
            {
                Letters.Add(letter);
            }
            return Letters;
        }
        public void InsertWord(List<char> mas)
        {
            for (int i = 0; i < mas.Count; i++)
            {
                _textBlocks[i].Text = mas[i].ToString();
            }

        }
        int a = 0;
        public bool Verification(List<char> letters, char A)
        {
            bool check = false;
            for (int i = 0; i < letters.Count; i++)
            {
                if (A == letters[i])
                {
                    _textBlocks[i].Visibility = System.Windows.Visibility.Visible;
                    check = true;
                    a++;
                    if (a == letters.Count)
                        _winGrid.Visibility = System.Windows.Visibility.Visible;
                }
            }
            return check;
        }

        int errLeft = 14;
        public int MistakeCheck(int count, bool check)
        {
            if (check == false)
            {
                errLeft -= 1;
                if (errLeft < 0)
                {
                    _loseGrid.Visibility = Visibility.Visible;
                }
            }
            return errLeft;
        }
    }
}

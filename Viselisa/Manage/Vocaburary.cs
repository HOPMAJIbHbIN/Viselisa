using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Viselisa.Manage
{
    class Vocaburary
    {
        String line;
       // string words;

        public void WriteWord(TextBox text)
        {
            try
            {

                StreamWriter sw = new StreamWriter("Words.txt", true, Encoding.ASCII);
                sw.Write(text + " ");
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public string ReadWords(string words)
        {
            try
            {
                StreamReader sr = new StreamReader("Words.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    words += line;
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return words;
        }
    }
}

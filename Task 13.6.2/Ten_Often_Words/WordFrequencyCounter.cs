using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_Often_Words
{
    internal class WordFrequencyCounter
    {
        public string text;

        public WordFrequencyCounter(string text)
        {
            this.text = text;
        }

        private string RemovePunctuation()
        {
            return new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
        }

        /// <summary>
        /// Подсчёт количества слов
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> CountWords()
        {
            // Избавляемся от знаков пунктуации и приводим к верхнему регистру
            string noPunctuationTextUpper = RemovePunctuation().ToUpper();

            // Формируем список слов, учитывая "пустые" символы (пробел, перенос строки и т.п.)
            char[] emptyChar = { '\u0020', '\u0000', '\u2063', '\u000A', '\u000B', '\u000C', '\u000D', '\u0085', '\u2028', '\u2029', '\u00A0', '\u00B6', '\t', '\n'};
            List<string> allWords = noPunctuationTextUpper.Split(emptyChar).ToList();

            // Производим подсчёт уникальных слов, добавляя результаты в словарь
            var wordQuantity = new Dictionary<string, int>();
            foreach (string word in allWords)
            {
                if (wordQuantity.ContainsKey(word))
                {
                    wordQuantity[word] = wordQuantity[word] + 1;
                }
                else
                {
                   wordQuantity.Add(word, 1);
                }
            }

            // Выполним сортировку по значениям
            wordQuantity = wordQuantity.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            return wordQuantity;
        }

        /// <summary>
        /// Формирование топ-списка
        /// </summary>
        /// <param name="topAmount"></param>
        /// <returns></returns>
        private LinkedList<KeyValuePair<string, int>> TopRepeatedWords (int topAmount)
        {
            var topWords = new LinkedList<KeyValuePair<string, int>>();
            var countedWords = CountWords();
            foreach (var word in countedWords)
            {
                if (topAmount <= 0)
                {
                    if (word.Value == topWords.Last().Value) 
                    {
                        // Добавление в случае, если несколько слов встречаются одинаковое
                        // количество раз и одно из них занимает последнюю строчку в топе
                        topWords.AddLast(word);
                    }
                    else { break; }
                }
                else { topWords.AddLast(word); topAmount--; }
            }
            return topWords;
        }

        public void ShowTop (int topAmount)
        {
            if(topAmount > 0)
            {
                var topList = TopRepeatedWords(topAmount);
                Console.WriteLine($"Список {topAmount} наиболее часто встречающихся слов:");
                int i = 0;
                foreach (var position in topList)
                {
                    if (i == topAmount) { Console.WriteLine("Также одинаково часто встречаются:"); }
                    Console.WriteLine($"\t({position.Value})\t{position.Key}");
                    i++;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTCDictionary
{
    public class LanguageDictionary : ILanguageDictionary
    {
        private Dictionary<string, string> list;

        public LanguageDictionary(Dictionary<string, string> list)
        {
            this.list = list;
        }

        /// <summary>
        /// Determines if `word` is in the dictionary for `language`
        /// </summary>
        /// <param name="language"></param>
        /// <param name="word"></param>
        /// <returns>If it is, it returns `true`, if it's not, it will return `false`.</returns>
        public bool Check(string language, string word)
        {
            string wordAlreadyInserted = string.Empty;

            if (!string.IsNullOrEmpty(language) && list.TryGetValue(language, out wordAlreadyInserted))
            {
                return wordAlreadyInserted.Equals(word);
            }

            return false;
        }

        /// <summary>
        /// Adds a language and a word to the dictionary. It is not possible to have more than one word per dictionary
        /// </summary>
        /// <param name="language"></param>
        /// <param name="word"></param>
        /// <returns>True if the language and word were successfully added</returns>
        public bool Add(string language, string word)
        {
            if (string.IsNullOrEmpty(language) || list.Any(i => i.Key.Equals(language)))
            {
                return false;
            }

            list.Add(language, word);

            return true;
        }

        /// <summary>
        /// Finds words in all languages that start with the `word`.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public IEnumerable<string> Search(string word)
        {
            List<string> wordsFound = new List<string>();

            if (!string.IsNullOrEmpty(word))
            {
                wordsFound = list.Where(i => i.Value.StartsWith(word)).Select(i => i.Value).ToList<string>();
            }

            return wordsFound;
        }
    }
}

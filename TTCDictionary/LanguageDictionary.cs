﻿using System;
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

        public bool Check(string language, string word)
        {
            throw new NotImplementedException();
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

        public IEnumerable<string> Search(string word)
        {
            throw new NotImplementedException();
        }
    }
}

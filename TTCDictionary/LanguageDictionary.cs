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

        public bool Check(string language, string word)
        {
            throw new NotImplementedException();
        }

        public bool Add(string language, string word)
        {
            if (list.Any(i => i.Key == language && i.Value == word))
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

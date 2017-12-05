using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day4
{
    public class PassphraseValidator
    {
        public bool IsPassphraseValid(string passphrase)
        {
            return isPassphraseValid(passphrase.Split(' '));
        }

        public bool IsPassphraseValid2(string passphrase)
        {
            var sortedWords = passphrase.Split(' ').Select(w => string.Concat(w.OrderBy(c => c)));
            return isPassphraseValid(sortedWords);
        }

        public int GetValidPassphraseCount(List<string> passphraseList, Func<string, bool> validator)
        {
            return passphraseList.Count(p => validator(p));
        }

        private bool isPassphraseValid(IEnumerable<string> words)
        {
            return !words.GroupBy(w => w).Any(g => g.Count() > 1);
        }
    }
}

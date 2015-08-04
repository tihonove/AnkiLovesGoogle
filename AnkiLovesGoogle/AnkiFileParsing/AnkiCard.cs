using System.Text.RegularExpressions;

using JetBrains.Annotations;

namespace TSoft.AnkiLovesGoogle.AnkiFileParsing
{
    public class AnkiCard
    {
        public AnkiCard([NotNull] string front, [CanBeNull] string back)
        {
            Front = front;
            Back = back;
            PlainWord = ExtractPlainWord(front);
        }

        [NotNull]
        public string Front { get; private set; }

        [CanBeNull]
        public string Back { get; private set; }

        [CanBeNull]
        private string ExtractPlainWord([NotNull] string front)
        {
            var regex = new Regex("<span .*?>.*?</span>(?<word>.*?)<");
            var match = regex.Match(front);
            if(match.Success)
                return CutVerbPrefix(match.Groups["word"].Captures[0].Value.Trim());
            return null;
        }

        private string CutVerbPrefix(string str)
        {
            if(str.StartsWith("to "))
                return str.Substring(3);
            return str;
        }

        [CanBeNull]
        public string PlainWord { get; private set; }

        [NotNull]
        public string FormatAsString()
        {
            return Front + "\t" + Back;
        }
    }
}
using JetBrains.Annotations;

namespace TSoft.AnkiLovesGoogle.AnkiFileParsing
{
    public class AnkiStringParser
    {
        [NotNull]
        public AnkiCard ParseString([NotNull] string ankiString)
        {
            var splitString = ankiString.Split(new[] {'\t'}, 2);
            return new AnkiCard(
                splitString[0],
                splitString.Length == 2 ? splitString[1] : null
                );
        }
    }
}
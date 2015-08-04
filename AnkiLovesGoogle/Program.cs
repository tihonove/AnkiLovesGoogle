using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using JetBrains.Annotations;

using TSoft.AnkiLovesGoogle.AnkiFileParsing;
using TSoft.AnkiLovesGoogle.GoogleTranslate;

namespace TSoft.AnkiLovesGoogle
{
    internal static class Program
    {
        private static void Main([NotNull] string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("  AnkiLovesGoogle.exe {anki_output_file}");
                return;
            }
            var ankiStringParser = new AnkiStringParser();
            var googleTranslateApi = new GoogleTranslateApi();
            File.WriteAllLines(
                GetOutputFileName(args[0]),
                File
                    .ReadAllLines(args[0])
                    .Select(ankiStringParser.ParseString)
                    .Select(x => new AnkiCard(x.Front, FormatGoogleDefinitions(googleTranslateApi.GetDefinitions(x.PlainWord))))
                    .Select(x => x.FormatAsString())
                );
        }

        private static string GetOutputFileName(string fileName)
        {
            return Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + "_google_defs" + Path.GetExtension(fileName));
        }

        [NotNull]
        private static string FormatGoogleDefinitions([NotNull] Dictionary<string, string[]> getDefinitions)
        {
            return string.Join("<br />",
                               getDefinitions
                                   .Select(x => string.Format("{0}<br />{1}", x.Key, string.Join("<br />", x.Value))));
        }
    }
}
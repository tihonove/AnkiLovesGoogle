using FluentAssertions;

using NUnit.Framework;

using TSoft.AnkiLovesGoogle.AnkiFileParsing;

namespace TSoft.AnkiLovesGoogle.Tests
{
    public class TestAnkiFormatParser
    {
        [Test]
        public void ParseAnkiStringWithNoun()
        {
            const string ankiStringWithNoun = @"<span style=""color: #aaa;"">(adj.)</span> motionless<br/><span style=""color: #666;"">/ˈmoʊʃənləs/</span><br/><br/>The landscape hung <b>motionless</b> below him.<br/>He felt a tiny lurch, evidence of the minutest lack of synchrony between the shutting down of the fusion rockets and the drives, but then all was <b>motionless</b>.<br/>The figure was crouched down by the shore of sea, <b>motionless</b>, as if caught in some reverie that had interrupted an otherwise innocent examination of the tide pools and their fauna.	неподвижный";
            var parser = new AnkiStringParser();
            var wordInfo = parser.ParseString(ankiStringWithNoun);
            wordInfo.Should().NotBeNull();
            wordInfo.PlainWord.Should().Be("motionless");
        }
        
        [Test]
        public void ParseAnkiStringWithVerb()
        {
            const string ankiStringWithNoun = @"<span style=""color: #aaa;"">(adj.)</span> to blame<br/><span style=""color: #666;"">/ˈmoʊʃənləs/</span><br/><br/>The landscape hung <b>motionless</b> below him.<br/>He felt a tiny lurch, evidence of the minutest lack of synchrony between the shutting down of the fusion rockets and the drives, but then all was <b>motionless</b>.<br/>The figure was crouched down by the shore of sea, <b>motionless</b>, as if caught in some reverie that had interrupted an otherwise innocent examination of the tide pools and their fauna.	неподвижный";
            var parser = new AnkiStringParser();
            var wordInfo = parser.ParseString(ankiStringWithNoun);
            wordInfo.Should().NotBeNull();
            wordInfo.PlainWord.Should().Be("blame");
        }
    }
}
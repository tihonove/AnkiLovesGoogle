using System;

using FluentAssertions;

using NUnit.Framework;

using TSoft.AnkiLovesGoogle.GoogleTranslate;

namespace TSoft.AnkiLovesGoogle.Tests
{
    public class GoogleTranslateApiTest
    {
        [Test]
        public void TestWordDefinitions()
        {
            var googleTranslateApi = new GoogleTranslateApi();
            var definitions = googleTranslateApi.GetDefinitions("blame");
            definitions.Should().NotBeNull();
            definitions["verb"].Should().ContainSingle().Which.Should().Be("assign responsibility for a fault or wrong.");
            definitions["noun"].Should().ContainSingle().Which.Should().Be("responsibility for a fault or wrong.");
        }
    }
}
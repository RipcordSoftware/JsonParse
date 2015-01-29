using NUnit.Framework;
using System;

using RipcordSoftware.JsonParse;

namespace JsonParseTest
{
    [TestFixture()]
    public class TestMalformed
    {
        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON1()
        {
            var json = "{x:10}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON2()
        {
            var json = "{\"x\":abc}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON3()
        {
            var json = "{\"x\":10 \"y\":20}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON4()
        {
            var json = "{\"x:10}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON5()
        {
            var json = "{\"x\":10, \"y\":\"abc}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON6()
        {
            var json = "{\"x\":10, \"y\" \"abc\"}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON7()
        {
            var json = "{\"x\":10, \"y\":\"abc\", \"z\":[}";
            JsonParse.Parse(json, string.Empty);
        }   

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestMalformedJSON8()
        {
            var json = "{\"x\":10, \"y\":\"abc\", \"z\":\"pqr\"";
            JsonParse.Parse(json, string.Empty);
        }   
    }
}


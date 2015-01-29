using NUnit.Framework;
using System;

using RipcordSoftware.JsonParse;

namespace JsonParseTest
{
    [TestFixture()]
    public class ParseTest
    {
        [Test()]
        public void TestEmptyObject()
        {
            var json = "{}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        public void TestEmptyString()
        {
            var json = "";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON1()
        {
            var json = "{x:10}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON2()
        {
            var json = "{\"x\":abc}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON3()
        {
            var json = "{\"x\":10 \"y\":20}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON4()
        {
            var json = "{\"x:10}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON5()
        {
            var json = "{\"x\":10, \"y\":\"abc}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON6()
        {
            var json = "{\"x\":10, \"y\" \"abc\"}";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        [ExpectedException(typeof(JsonParseException))]
        public void TestEmptyMalformedJSON7()
        {
            var json = "{\"x\":10, \"y\":\"abc\", \"z\":[}";
            JsonParse.Parse(json, string.Empty);
        }            
    }
}
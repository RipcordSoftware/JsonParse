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
    }
}
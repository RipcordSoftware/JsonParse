using System;
using NUnit.Framework;

using RipcordSoftware.JsonParse;

namespace JsonParseTest
{
    [TestFixture()]
    public class TestExamples
    {
        [Test()]
        public void TestExample1()
        {
            JsonParse.Parse(Examples.exampleJson1, string.Empty);
        }

        [Test()]
        public void TestExample2()
        {
            JsonParse.Parse(Examples.exampleJson2, string.Empty);
        }

        [Test()]
        public void TestExample3()
        {
            JsonParse.Parse(Examples.exampleJson3, string.Empty);
        }

        [Test()]
        public void TestExample4()
        {
            JsonParse.Parse(Examples.exampleJson4, string.Empty);
        }

        [Test()]
        public void TestExample5()
        {
            JsonParse.Parse(Examples.exampleJson5, string.Empty);
        }

        [Test()]
        public void TestExample5SelectIdentity()
        {
            var extents = JsonParse.Parse(Examples.exampleJson5, "/menu/items/*", "id");
            Assert.AreEqual(18, extents.Count);
            Assert.AreEqual(@"{""id"": ""Open""}", extents[0].ToString());
            Assert.AreEqual(@"Open", extents[0].Value);
            Assert.AreEqual(@"OpenNew", extents[1].Value);
            Assert.AreEqual(@"ZoomIn", extents[2].Value);
            Assert.AreEqual(@"About", extents[17].Value);
        }
    }
}


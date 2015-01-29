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
    }
}


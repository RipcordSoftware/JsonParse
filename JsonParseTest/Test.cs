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
        public void TestEmptyArray()
        {
            var json = "[]";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        public void TestEmptyString()
        {
            var json = "";
            JsonParse.Parse(json, string.Empty);
        }

        [Test()]
        public void TestSimpleObject1()
        {
            var json = @"{""a"":1,""b"":2,""c"":3}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":1", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""c"":3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject2()
        {
            var json = @"{""c"":3,""b"":2,""a"":1}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""c"":3", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""a"":1", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject3()
        {
            var json = @"{""a"":1.1,""b"":2.2,""c"":3.3}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":1.1", extents[0].ToString());
            Assert.AreEqual(@"""b"":2.2", extents[1].ToString());
            Assert.AreEqual(@"""c"":3.3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject4()
        {
            var json = @"{""a"":""1.1"",""b"":""2.2"",""c"":""3.3""}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":""1.1""", extents[0].ToString());
            Assert.AreEqual(@"""b"":""2.2""", extents[1].ToString());
            Assert.AreEqual(@"""c"":""3.3""", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject5()
        {
            var json = @"{""a"":true,""b"":false,""c"":true}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":true", extents[0].ToString());
            Assert.AreEqual(@"""b"":false", extents[1].ToString());
            Assert.AreEqual(@"""c"":true", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject6()
        {
            var json = @"{""a"":{},""b"":[],""c"":{}}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":{}", extents[0].ToString());
            Assert.AreEqual(@"""b"":[]", extents[1].ToString());
            Assert.AreEqual(@"""c"":{}", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject7()
        {
            var json = @"{""child"":{""a"":1,""b"":2,""c"":3}}";
            var extents = JsonParse.Parse(json, "/child/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":1", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""c"":3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject8()
        {
            var json = @"{""child"":[{""a"":1,""b"":2,""c"":3}]}";
            var extents = JsonParse.Parse(json, "/child/[0]/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":1", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""c"":3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject9()
        {
            var json = @"{""child"":[1,2,3]}";
            var extents = JsonParse.Parse(json, "/child/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"1", extents[0].ToString());
            Assert.AreEqual(@"2", extents[1].ToString());
            Assert.AreEqual(@"3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject10()
        {
            var json = @"{""child"":[[1,2,3]]}";
            var extents = JsonParse.Parse(json, "/child/[0]/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"1", extents[0].ToString());
            Assert.AreEqual(@"2", extents[1].ToString());
            Assert.AreEqual(@"3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleObject11()
        {
            var json = @"{""child"":[[{""a"":1,""b"":2,""c"":3}]]}";
            var extents = JsonParse.Parse(json, "/child/[0]/[0]/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":1", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""c"":3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleArray1()
        {
            var json = @"[{""a"":1,""b"":2,""c"":3}]";
            var extents = JsonParse.Parse(json, "/[0]/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":1", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""c"":3", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleArray2()
        {
            var json = @"[{""c"":3,""b"":2,""a"":1}]";
            var extents = JsonParse.Parse(json, "/[0]/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""c"":3", extents[0].ToString());
            Assert.AreEqual(@"""b"":2", extents[1].ToString());
            Assert.AreEqual(@"""a"":1", extents[2].ToString());
        }

        [Test()]
        public void TestSimpleArray3()
        {
            var json = @"[0,1,2,3,4,5,6,7,8,9]";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(10, extents.Count);
            Assert.AreEqual(@"0", extents[0].ToString());
            Assert.AreEqual(@"1", extents[1].ToString());
            Assert.AreEqual(@"2", extents[2].ToString());
            Assert.AreEqual(@"9", extents[9].ToString());
        }

        [Test()]
        public void TestSimpleArray4()
        {
            var json = @"[9,8,7,6,5,4,3,2,1,0]";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(10, extents.Count);
            Assert.AreEqual(@"9", extents[0].ToString());
            Assert.AreEqual(@"8", extents[1].ToString());
            Assert.AreEqual(@"7", extents[2].ToString());
            Assert.AreEqual(@"0", extents[9].ToString());
        }

        [Test()]
        public void TestSimpleArray5()
        {
            var json = @"[{""abc"":123},8,7,6,5,4,3,2,1,{""pi"":3.14}]";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(10, extents.Count);
            Assert.AreEqual(@"{""abc"":123}", extents[0].ToString());
            Assert.AreEqual(@"8", extents[1].ToString());
            Assert.AreEqual(@"7", extents[2].ToString());
            Assert.AreEqual(@"{""pi"":3.14}", extents[9].ToString());
        }

        [Test()]
        public void TestNegativeNumbers()
        {
            var json = @"{""a"":-1,""b"":-2,""c"":-3}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":-1", extents[0].ToString());
            Assert.AreEqual(@"""b"":-2", extents[1].ToString());
            Assert.AreEqual(@"""c"":-3", extents[2].ToString());
        }

        [Test()]
        public void TestExponentNumbers()
        {
            var json = @"{""a"":-1e8,""b"":-2e11,""c"":-3E2}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(3, extents.Count);
            Assert.AreEqual(@"""a"":-1e8", extents[0].ToString());
            Assert.AreEqual(@"""b"":-2e11", extents[1].ToString());
            Assert.AreEqual(@"""c"":-3E2", extents[2].ToString());
        }

        [Test()]
        public void TestLongStringWithUnicodeChars()
        {
            var lorem = @"Jelly dragée lemon drops jelly beans gummi bears chocolate cake pastry apple pie marshmallow. Ice cream caramels topping dragée liquorice lollipop toffee jelly-o cheesecake. Gummies muffin bear claw halvah caramels cake cookie jujubes.";
            var json = @"{""lorem"":""" + lorem + @"""}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(1, extents.Count);
            Assert.AreEqual(@"""lorem"":""" + lorem + @"""", extents[0].ToString());
        }

        [Test()]
        public void TestQuotedString()
        {
            var lorem = @"\""quoted string\""";
            var json = @"{""quoted_string"":""" + lorem + @"""}";
            var extents = JsonParse.Parse(json, "/*");
            Assert.AreEqual(1, extents.Count);
            Assert.AreEqual(@"""quoted_string"":""" + lorem + @"""", extents[0].ToString());
        }
    }
}
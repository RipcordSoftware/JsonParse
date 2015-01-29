using System;

using RipcordSoftware.JsonParse;

namespace JsonParseExample
{
    class MainClass
    {
        private static string json = 
            @"{""menu"": { ""id"": ""file"", ""value"": ""File"", ""popup"": { ""menuitem"": [
                {""value"": ""New"", ""onclick"": ""CreateNewDoc()""},
                {""value"": ""Open"", ""onclick"": ""OpenDoc()""},
                {""onclick"": ""HelpDoc()""},
                {""value"": ""Close"", ""onclick"": ""CloseDoc()""}
            ]}}}";

        public static void Main(string[] args)
        {
            var parser = new JsonParse<JsonExtent>("/menu/popup/menuitem/*", "value");
            parser.Parse(json);

            foreach (var extent in parser.MatchedExtents)
            {
                var identity = extent as JsonIdentityExtent;

                Console.WriteLine("Extent: <{0}>, Identity: <{1}>, IdentityValue: <{2}>", 
                    extent, identity != null ? identity.IdentityExent : "null", identity != null ? identity.Value : "null");
            }

            Console.WriteLine("\nExtents found: {0}", parser.ExtentCount);
            Console.WriteLine("Identity extents found: {0}", parser.IdentityExtentCount);
        }
    }
}
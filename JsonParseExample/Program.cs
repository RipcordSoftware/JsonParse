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
                {""value"": ""Close"", ""onclick"": ""CloseDoc()""}
            ]}}}";

        public static void Main(string[] args)
        {
            var parser = new JsonParse("/menu/popup/menuitem/*", "value");
            parser.Parse(json);

            foreach (JsonIdentityExtent extent in parser.MatchedExtents)
            {
                Console.WriteLine("Extent: {0}, Identity: {1}", extent, extent.IdentityExent);
            }
        }
    }
}
[![Build Status](https://travis-ci.org/RipcordSoftware/JsonParse.svg?branch=master)](https://travis-ci.org/RipcordSoftware/JsonParse)

JsonParse
=========

JsonParse is a very-very simple JSON parser for Mono (and .NET). If you want full CLR types serialized to/from JSON then you are in the wrong place. JsonParse parses JSON in a .NET string and emits `extents` which match its simple query language. The end result is very low memory overhead and fast performance.

JsonParse is useful for when:
* You don't want full CLR types
* You want to keep memory overhead low
* You want speed over everything else
* You don't need advanced queries

What is an extent?
------------------
JsonParser parses the JSON data stored in a CLR string. The parser will emit `extents` when a query match is found. An extent is just the start and end indexes of the JSON object in the original string. For example:
```JSON
{"menu": {
  "id": "file",
  "value": "File",
  "popup": {
    "menuitem": [
      {"value": "New", "onclick": "CreateNewDoc()"},
      {"value": "Open", "onclick": "OpenDoc()"},
      {"value": "Close", "onclick": "CloseDoc()"}
    ]
  }
}}
```
If we were interested in the `menuitem` entries then the parser would emit three extents, one for each of the menuitem[] children. Each extent would contain the start index and (string) length of the object. So extent 0 would contain `{"value": "New", "onclick": "CreateNewDoc()"}`. The extent object returned by the parser does not contain the string data itself, it only contains the indexes so emitting extents have minimal additional memory and performance overhead.

The Query Language
------------------
The query language is very simple, it is similar to XPath or JSONPath. It supports:
* selecting a document by name
* selecting children of a named document
* selecting array children by index

The following queries are valid for the example JSON above:
* "/menu"
* "/menu/popup"
* "/menu/popup/menuitem/[2]"
* "/menu/popup/menuitem/*"

The last query here will emit three extents, one for each of the array items in `menuitem`.

### Identity Extents
In addition to emitting extents JsonParse can also emit identity information about the JSON object. In the example JSON text above the `menuitem` array children all have a `value` field. You can ask JsonParse to include information about this field in the emitted extent, for example extent 0 would contain:
```
{"value": "New", "onclick": "CreateNewDoc()"} 
*AND*
"value": "New"
```

### Example Code
The following code comes from the JsonParseExample project in this repo:
```C#
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
```
Will yield the following output:
```
Extent: <{"value": "New", "onclick": "CreateNewDoc()"}>, Identity: <"value": "New">, IdentityValue: <New>
Extent: <{"value": "Open", "onclick": "OpenDoc()"}>, Identity: <"value": "Open">, IdentityValue: <Open>
Extent: <{"onclick": "HelpDoc()"}>, Identity: <null>, IdentityValue: <null>
Extent: <{"value": "Close", "onclick": "CloseDoc()"}>, Identity: <"value": "Close">, IdentityValue: <Close>

Extents found: 4
Identity extents found: 3
```
There are also a static `Parse` method on JsonParse to simplify invokation, for example:
```C#
  var extents = JsonParse.Parse(json, match, id);
```

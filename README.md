JsonParse
=========

JsonParse is a very-very simple JSON parser for .NET. If you want full CLR types serialized to/from JSON then you are in the wrong place.
JsonParse parses JSON in a .NET string and emits `extents` which match its simple query language. The end result is very low memory overhead
and fast performance.

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
If we were interested in the `menuitem` entries then the parser would emit three extents, one for each of the menuitem[] children. Each extent would contain the start index and (string) length of the object. So extent 0 would contain `{"value": "New", "onclick": "CreateNewDoc()"}`.

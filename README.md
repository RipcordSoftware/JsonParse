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

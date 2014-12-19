using System;

namespace RipcordSoftware.JsonParse
{
    public class JsonParseException : ApplicationException
    {
        public JsonParseException(string msg) : base(msg) {}
    }
}


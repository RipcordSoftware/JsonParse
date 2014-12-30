using System;

namespace RipcordSoftware.JsonParse
{
    [Serializable]
    public class JsonParseException : ApplicationException
    {
        public JsonParseException(string msg) : base(msg) {}
    }
}


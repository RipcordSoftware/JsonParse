using System;

namespace RipcordSoftware.JsonParse
{
    public class JsonExtent
    {
        protected readonly string json;
        protected readonly int start;
        protected readonly int length;

        public JsonExtent() {}

        public JsonExtent(string json, int start, int length)
        {
            this.json = json;
            this.start = start;
            this.length = length;
        }

        public static implicit operator string(JsonExtent jstr)
        {
            return jstr.json.Substring(jstr.start, jstr.length);
        }

        public override string ToString()
        {
            return (string)this;
        }
    }

    public class JsonIdentityExtent : JsonExtent
    {
        private readonly JsonExtent identityExtent;

        public JsonIdentityExtent(string json, int start, int length, JsonExtent identityExtent) : base(json, start, length)
        {
            this.identityExtent = identityExtent;
        }

        public JsonExtent IdentityExent { get { return identityExtent; } }
    }

    public class JsonString : JsonExtent
    {
        public JsonString(string json, int start, int length) : base(json, start, length) {}

        public static implicit operator string(JsonString js)
        {
            return js.ToString();
        }
    }
}


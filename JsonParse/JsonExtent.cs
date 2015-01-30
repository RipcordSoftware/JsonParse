using System;

namespace RipcordSoftware.JsonParse
{
    public class JsonExtent : IComparable<JsonExtent>
    {
        #region Protected fields
        protected readonly string json;
        protected readonly int start;
        protected readonly int length;
        #endregion

        #region Constructors
        public JsonExtent() {}

        public JsonExtent(string json, int start, int length)
        {
            this.json = json;
            this.start = start;
            this.length = length;
        }
        #endregion

        #region Public methods
        public string Substring(int startIndex)
        {
            return Substring(startIndex, this.length - startIndex);
        }

        public string Substring(int startIndex, int count)
        {
            return json.Substring(this.start + startIndex, Math.Min(this.length - startIndex, count));
        }

        public int IndexOf(char ch)
        {
            return IndexOf(ch, 0, length);
        }

        public int IndexOf(char ch, int startIndex)
        {
            return IndexOf(ch, startIndex, this.length - startIndex);
        }

        public int IndexOf(char ch, int startIndex, int count)
        {
            var index = json.IndexOf(ch, this.start + startIndex, Math.Min(this.length - startIndex, count));
            if (index >= 0)
            {
                index -= this.start;
            }
            return index;
        }

        public override string ToString()
        {
            return json.Substring(start, length);
        }
        #endregion

        #region Public overrides
        public static implicit operator string(JsonExtent jstr)
        {
            return jstr.ToString();
        }
        #endregion

        #region Public properties
        public int StartIndex { get { return start; } }
        public int EndIndex { get { return length > 0 ? (start + length - 1) : start; } }
        public int Length { get { return length; } }
        #endregion

        #region IComparable implementation
        public int CompareTo(JsonExtent other)
        {
            var diff = 0;

            if (other == null)
            {
                diff = 1;
            }
            else
            {
                diff = string.CompareOrdinal(json, start, other.json, other.start, Math.Min(length, other.length));
                if (diff == 0)
                {
                    diff = length - other.length;
                }
            }

            return diff;
        }
        #endregion
    }

    public class JsonIdentityExtent : JsonExtent, IComparable<JsonIdentityExtent>
    {
        #region Private fields
        private readonly JsonExtent identityExtent;
        private readonly int valueStart;
        private readonly int valueLength;
        private string value = null;
        #endregion

        #region Constructor
        public JsonIdentityExtent(string json, int start, int length, JsonExtent identityExtent) : base(json, start, length)
        {
            this.identityExtent = identityExtent;

            var colonIndex = this.identityExtent.IndexOf(':');
            var quoteIndex = this.identityExtent.IndexOf('"', colonIndex + 1);

            valueStart = quoteIndex + 1;
            valueLength = identityExtent.Length - valueStart - 1;
        }
        #endregion

        #region Public properties
        public JsonExtent IdentityExent { get { return identityExtent; } }

        public string Value
        {
            get
            {
                if (value == null)
                {
                    value = identityExtent.Substring(valueStart, valueLength);
                }

                return value;
            }
        }
        #endregion

        #region IComparable implementation
        public int CompareTo(JsonIdentityExtent other)
        {
            var diff = 0;

            if (other == null)
            {
                diff = 1;
            }
            else
            {
                diff = string.CompareOrdinal(base.json, start + valueStart, other.json, other.start + other.valueStart, Math.Min(valueLength, other.valueLength));
                if (diff == 0)
                {
                    diff = valueLength - other.valueLength;
                }
            }

            return diff;
        }
        #endregion
    }

    public class JsonString : JsonExtent
    {
        #region Constructor
        public JsonString(string json, int start, int length) : base(json, start, length) {}
        #endregion

        #region Public overrides
        public static implicit operator string(JsonString js)
        {
            return js.ToString();
        }
        #endregion
    }
}


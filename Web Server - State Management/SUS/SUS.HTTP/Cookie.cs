namespace SUS.HTTP
{
    public class Cookie
    {
        public Cookie(string cookiesAsString)
        {
            var cookieParts = cookiesAsString.Split(new char[] { '=' }, 2);

            Name = cookieParts[0];
            Value = cookieParts[1];
        }

        public Cookie(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
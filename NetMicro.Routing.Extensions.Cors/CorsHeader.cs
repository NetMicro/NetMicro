namespace NetMicro.Routing.Extensions.Cors
{
    internal class CorsHeader
    {
        private string[] _values;
        public bool IsSet { get; private set; }

        public string[] Values
        {
            get => _values;
            set
            {
                IsSet = true;
                _values = value;
            }
        }
    }
}
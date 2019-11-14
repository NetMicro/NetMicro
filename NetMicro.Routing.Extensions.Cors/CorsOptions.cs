using System;

namespace NetMicro.Routing.Extensions.Cors
{
    public class CorsOptions
    {
        public static CorsOptions GetCorsOptions(Action<CorsOptions> setOptions)
        {
            if (setOptions == null)
                return Default();
            
            var corsOptions = new CorsOptions();
            setOptions(corsOptions);
            return corsOptions;
        }

        private static CorsOptions Default()
        {
            return new CorsOptions()
                .SetAllowCredentials()
                .SetAllowHeaders()
                .SetAllowMethods()
                .SetAllowOrigin();
        }
        
        private readonly string[] _allowAll = { "*" };
        
        internal readonly CorsHeader AllowOrigin = new CorsHeader();
        internal readonly CorsHeader AllowCredentials = new CorsHeader();
        internal readonly CorsHeader AllowMethods = new CorsHeader();
        internal readonly CorsHeader AllowHeaders = new CorsHeader();

        public CorsOptions SetAllowOrigin(params string[] values)
        {
            
            AllowOrigin.Values = values.Length == 0 ? _allowAll : values;

            return this;
        }
        
        public CorsOptions SetAllowCredentials()
        {
            AllowCredentials.Values = new[] {"true"};

            return this;            
        }
        
        public CorsOptions SetAllowMethods(params string[] values)
        {
            AllowMethods.Values = values.Length == 0 ? _allowAll : values;

            return this;            
        }
        
        public CorsOptions SetAllowHeaders(params string[] values)
        {
            AllowHeaders.Values = values.Length == 0 ? _allowAll : values;

            return this;
        }
    }
}
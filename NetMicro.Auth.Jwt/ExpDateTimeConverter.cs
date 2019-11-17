using System;

namespace NetMicro.Auth.Jwt
{
    public static class ExpDateTimeConverter
    {
        public static DateTime ToDateTime(long exp)
        {
            return DateTime.UnixEpoch.AddSeconds(exp);
        }
        
        public static long ToExp(DateTime dateTime)
        {
            return (long)(dateTime - DateTime.UnixEpoch).TotalSeconds;
        }
    }
}
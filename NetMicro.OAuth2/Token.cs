using System;

namespace NetMicro.OAuth2
{
    public interface IAuthResponse
    {
        string AccessToken { get; }
        DateTime Expire { get; }
    }
}
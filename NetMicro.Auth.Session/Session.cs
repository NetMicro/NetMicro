namespace NetMicro.Auth.Session
{
    public class Session
    {
        public string UserName { get; }
        
        public SessionData Data = new SessionData();

        public Session(string userName)
        {
            UserName = userName;
        }
    }
}
namespace NetMicro.Presenters
{
    public interface IPresenterFactory
    {
        string ContentType { get; }
        IHttpPresenter GetPresenter();
    }
}
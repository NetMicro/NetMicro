using System;

namespace NetMicro.Presenters.Autofac
{
    public class PresenterFactory<TPresenter> : IPresenterFactory where TPresenter : IHttpPresenter
    {
        private readonly Lazy<TPresenter> _presenter;

        public PresenterFactory(string contentType, Lazy<TPresenter> presenter)
        {
            ContentType = contentType;
            _presenter = presenter;
        }

        public string ContentType { get; }
        public IHttpPresenter GetPresenter() => _presenter.Value;
    }
}
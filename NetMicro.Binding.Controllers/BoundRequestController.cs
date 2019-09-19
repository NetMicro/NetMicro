using System.Net;
using System.Threading.Tasks;
using NetMicro.Controllers;
using NetMicro.Routing;
using NetMicro.Routing.Binding;

namespace NetMicro.Binding.Controllers
{
    public class BoundRequestController<TRequestController, TContent> : IRequestController
        where TRequestController : IRequestController<TContent>
    {
        private readonly IContentParser _contentParser;
        private readonly Context _context;
        private readonly TRequestController _requestController;

        public BoundRequestController(
            Context context,
            TRequestController requestController,
            IContentParser contentParser)
        {
            _requestController = requestController;
            _context = context;
            _contentParser = contentParser;
        }

        public async Task Execute()
        {
            if (_contentParser == null)
            {
                await Task.Run(() => _context.Response.StatusCode = HttpStatusCode.BadRequest);
                return;
            }

            await _requestController.Execute(
                _contentParser.Parse<TContent>(_context.Request.Body)
            );
        }
    }
}
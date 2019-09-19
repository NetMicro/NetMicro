using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using NetMicro.Http;
using NSubstitute;
using Xunit;

namespace NetMicro.Routing.Tests
{
    public class RouterTest
    {
        public RouterTest()
        {
            _handlerFunc = Substitute.For<IHandlerFuncSubstitute>();
            _sut = new Router();
        }

        private readonly Router _sut;
        private readonly IHandlerFuncSubstitute _handlerFunc;

        private static Request PrepareRequest(string method, string path)
        {
            return new Request(
                LocalHttpUrl(method, path),
                new Dictionary<string, IEnumerable<string>>(),
                Stream.Null
            );
        }

        private static Url LocalHttpUrl(string method, string path)
        {
            return new Url(method, "http", "localhost", null, path, "");
        }

        [Fact]
        public async Task HandleAsync_ShouldReturnNotFound_IfNoMatchingRegistration()
        {
            var response = Substitute.For<IResponse>();
            await _sut.HandleAsync(
                PrepareRequest("GET", "/"),
                response
            );

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Router_ShouldCallHandlerFunc()
        {
            _sut.Add("GET", "home", "/", _handlerFunc.Handle);

            var request = PrepareRequest("GET", "/");
            await _sut.HandleAsync(request, Substitute.For<IResponse>());

            await _handlerFunc.Received().Handle(Arg.Any<Context>());
        }

        [Fact]
        public async Task Router_ShouldCallHandlerFunc_IfPathContainsArguments()
        {
            _sut.Add("GET", "home", "/part1/:arg1/:arg2/", _handlerFunc.Handle);

            var request = PrepareRequest("GET", "/part1/part2/part3");
            await _sut.HandleAsync(request, Substitute.For<IResponse>());

            await _handlerFunc.Received().Handle(Arg.Any<Context>());
        }

        [Fact]
        public async Task Router_ShouldCallHandlerFunc_IfPathContainsMultipleParts()
        {
            _sut.Add("GET", "home", "/part1/part2/part3/", _handlerFunc.Handle);

            var request = PrepareRequest("GET", "/part1/part2/part3");
            await _sut.HandleAsync(request, Substitute.For<IResponse>());

            await _handlerFunc.Received().Handle(Arg.Any<Context>());
        }

        [Fact]
        public async Task Router_ShouldCallHandlerFunc_IfRegisteredWithoutEndingSeparator()
        {
            _sut.Add("GET", "home", "", _handlerFunc.Handle);

            var request = PrepareRequest("GET", "/");
            await _sut.HandleAsync(request, Substitute.For<IResponse>());

            await _handlerFunc.Received().Handle(Arg.Any<Context>());
        }

        [Fact]
        public async Task Router_ShouldCallHandlerFunc_IfRequestPathNotContainEndingSeparator()
        {
            _sut.Add("GET", "home", "/", _handlerFunc.Handle);

            var request = PrepareRequest("GET", "");
            await _sut.HandleAsync(request, Substitute.For<IResponse>());

            await _handlerFunc.Received().Handle(Arg.Any<Context>());
        }

        [Fact]
        public async Task Router_ShouldPassArgumentValuesInRequest_IfPathContainsArguments()
        {
            _sut.Add("GET", "home", "/part1/:arg1/:arg2/", _handlerFunc.Handle);

            var request = PrepareRequest("GET", "/part1/argument1/argument2/");
            await _sut.HandleAsync(request, Substitute.For<IResponse>());


            await _handlerFunc.Received().Handle(
                Arg.Is<Context>(ctx =>
                    ctx.SelectedRoute.UriParams["arg1"] == "argument1" &&
                    ctx.SelectedRoute.UriParams["arg2"] == "argument2"
                )
            );
        }
    }
}
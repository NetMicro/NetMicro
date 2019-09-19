using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace NetMicro.Routing.Tests
{
    public class MiddlewareManagerTest
    {
        public MiddlewareManagerTest()
        {
            _handlerFunc = Substitute.For<IHandlerFuncSubstitute>();
            _sut = new MiddlewareManager();
        }

        private readonly MiddlewareManager _sut;
        private readonly IHandlerFuncSubstitute _handlerFunc;

        [Fact]
        public async Task Invoke_ShouldCallMiddleware()
        {
            var middleware = Substitute.For<IMiddlewareSubstitute>();

            middleware
                .Handle(Arg.Any<Context>(), Arg.Any<RouteFuncAsync>())
                .ReturnsForAnyArgs(info =>
                    ((RouteFuncAsync) info[1]).Invoke((Context) info[0])
                );

            _sut.Use(middleware.Handle);
            await _sut.GetRuntime(_handlerFunc.Handle).Invoke(null);

            await middleware.Received().Handle(Arg.Any<Context>(), Arg.Any<RouteFuncAsync>());
        }

        [Fact]
        public async Task Invoke_ShouldCallMiddlewareInOrder()
        {
            var callOrder = new List<string>();
            var middleware = Substitute.For<IMiddlewareSubstitute>();
            var middleware2 = Substitute.For<IMiddlewareSubstitute>();

            middleware
                .Handle(Arg.Any<Context>(), Arg.Any<RouteFuncAsync>())
                .ReturnsForAnyArgs(info =>
                    ((RouteFuncAsync) info[1]).Invoke((Context) info[0])
                )
                .AndDoes(info => callOrder.Add("m1"));

            middleware2
                .Handle(Arg.Any<Context>(), Arg.Any<RouteFuncAsync>())
                .ReturnsForAnyArgs(info =>
                    ((RouteFuncAsync) info[1]).Invoke((Context) info[0])
                )
                .AndDoes(info => callOrder.Add("m2"));

            _sut.Use(middleware.Handle);
            _sut.Use(middleware2.Handle);
            await _sut.GetRuntime(_handlerFunc.Handle).Invoke(null);

            Assert.Equal(new[] {"m1", "m2"}, callOrder.ToArray());
        }

        [Fact]
        public async Task Invoke_ShouldCallRunMethod()
        {
            await _sut.GetRuntime(_handlerFunc.Handle).Invoke(null);

            await _handlerFunc.Received().Handle(Arg.Any<Context>());
        }

        [Fact]
        public async Task Invoke_ShouldNotCallHandlerWHenMiddlewareDontCallNextMiddleware()
        {
            var middleware = Substitute.For<IMiddlewareSubstitute>();

            middleware
                .Handle(Arg.Any<Context>(), Arg.Any<RouteFuncAsync>())
                .ReturnsForAnyArgs(info => Task.Run(() => { }));

            _sut.Use(middleware.Handle);
            await _sut.GetRuntime(_handlerFunc.Handle).Invoke(null);

            await _handlerFunc.DidNotReceive().Handle(null);
        }
    }
}
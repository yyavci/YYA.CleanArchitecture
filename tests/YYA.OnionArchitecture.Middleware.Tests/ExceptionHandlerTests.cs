using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using YYA.OnionArchitecture.Middlewares;

namespace YYA.OnionArchitecture.Middleware.Tests
{
    public class ExceptionHandlerTests
    {

        Mock<RequestDelegate> nextMock;
        Mock<ILogger<ExceptionHandler>> loggerMock;


        [SetUp]
        public void Setup()
        {
            nextMock = new Mock<RequestDelegate>();
            loggerMock = new Mock<ILogger<ExceptionHandler>>();
        }

        [Test]
        public async Task Invoke_ShouldThrowException_IfMethodThrowsAnException()
        {
            nextMock.Setup(f => f.Invoke(It.IsAny<HttpContext>())).Throws(new Exception("Test Exception"));
            Mock<HttpContext> mockContext = new Mock<HttpContext>();

            ExceptionHandler handler = new ExceptionHandler(nextMock.Object, loggerMock.Object);
            var action = async () => await handler.Invoke(mockContext.Object);

            await action.Should().ThrowAsync<Exception>();

        }


        [Test]
        public async Task Invoke_ShouldLogException_IfMethodThrowsAnException()
        {
            nextMock.Setup(f => f.Invoke(It.IsAny<HttpContext>())).Throws(new Exception("Test Log Exception"));
            Mock<HttpContext> contextMock = new Mock<HttpContext>();

            ExceptionHandler handler = new ExceptionHandler(nextMock.Object, loggerMock.Object);
            var action = async () => await handler.Invoke(contextMock.Object);

            await action.Should().ThrowAsync<Exception>();
            //we can only verify that like below because it logger.LogError is extension method. you cannot mock extension methods.
            loggerMock.Verify(
                x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => true),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));

        }
    }
}
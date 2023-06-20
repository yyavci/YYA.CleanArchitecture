using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using YYA.OnionArchitecture.Application.Features.Products.Commands.CreateProduct;
using YYA.OnionArchitecture.Application.Repositories;

namespace YYA.OnionArchitecture.Application.Tests.Products.Commands.CreateProduct
{
    public class CreateProductTests
    {
        Mock<IProductRepository> repositoryMock;
        Mock<IValidator<CreateProductCommand>> validatorMock;
        Mock<IMapper> mapperMock;


        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IProductRepository>();
            validatorMock = new Mock<IValidator<CreateProductCommand>>();
            mapperMock = new Mock<IMapper>();
        }



        [Test]
        public async Task CreateProductHandler_ShouldThrowNullException_WithNullRequest()
        {
            CreateProductCommandHandler commandHandler = new CreateProductCommandHandler(validatorMock.Object, mapperMock.Object, repositoryMock.Object);

            var action = async () => await commandHandler.Handle(null, default);

            await action.Should().ThrowAsync<ArgumentNullException>();

        }

        [Test]
        public async Task CreateProductHandler_ShouldReturnFalseResponse_WithEmptyNameParam()
        {
            validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FluentValidation.Results.ValidationResult()
            { 
                Errors = new List<FluentValidation.Results.ValidationFailure>() 
                {
                    new FluentValidation.Results.ValidationFailure(){ ErrorMessage = "qweqwe" }
                } 
            });

            CreateProductCommandHandler commandHandler = new CreateProductCommandHandler(validatorMock.Object, mapperMock.Object, repositoryMock.Object);

            CreateProductCommand request = new CreateProductCommand();
            request.Name = "";

            var response = await commandHandler.Handle(request, default);

            response.Success.Should().BeFalse();

        }

    }
}
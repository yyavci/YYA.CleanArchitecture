using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using YYA.CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using YYA.CleanArchitecture.Application.Repositories;

namespace YYA.CleanArchitecture.Application.Tests.Products.Commands.CreateProduct
{
    public class CreateProductTests
    {
        Mock<IProductRepository> mockRepository;
        Mock<IValidator<CreateProductCommand>> mockValidator;
        Mock<IMapper> mockMapper;


        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IProductRepository>();
            mockValidator = new Mock<IValidator<CreateProductCommand>>();
            mockMapper = new Mock<IMapper>();
        }



        [Test]
        public async Task CreateProductHandler_ShouldThrowNullException_WithNullRequest()
        {
            CreateProductCommandHandler commandHandler = new CreateProductCommandHandler(mockValidator.Object, mockMapper.Object, mockRepository.Object);

            var action = async () => await commandHandler.Handle(null, default);

            await action.Should().ThrowAsync<ArgumentNullException>();

        }

        [Test]
        public async Task CreateProductHandler_ShouldReturnFalseResponse_WithEmptyNameParam()
        {
            mockValidator.Setup(x => x.ValidateAsync(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FluentValidation.Results.ValidationResult()
            { 
                Errors = new List<FluentValidation.Results.ValidationFailure>() 
                {
                    new FluentValidation.Results.ValidationFailure(){ ErrorMessage = "qweqwe" }
                } 
            });

            CreateProductCommandHandler commandHandler = new CreateProductCommandHandler(mockValidator.Object, mockMapper.Object, mockRepository.Object);

            CreateProductCommand request = new CreateProductCommand();
            request.Name = "";

            var response = await commandHandler.Handle(request, default);

            response.Success.Should().BeFalse();

        }

    }
}
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Features.Products.Queries.GetAllProducts;
using YYA.OnionArchitecture.Application.Repositories;

namespace YYA.OnionArchitecture.Application.Tests.Products.Queries.GetAllProducts
{
    public class GetAllProductsTests
    {
        Mock<IProductRepository> repositoryMock;
        Mock<IMapper> mapperMock;


        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IProductRepository>();
            mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task CreateProductHandler_ShouldThrowNullException_WithNullRequest()
        {
            GetAllProductsQueryHandler queryHandler = new GetAllProductsQueryHandler(repositoryMock.Object, mapperMock.Object);

            var action = async () => await queryHandler.Handle(null, default);

            await action.Should().ThrowAsync<ArgumentNullException>();

        }
    }
}

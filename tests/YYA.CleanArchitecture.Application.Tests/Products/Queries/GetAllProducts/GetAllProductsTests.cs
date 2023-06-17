using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.CleanArchitecture.Application.Features.Products.Queries.GetAllProducts;
using YYA.CleanArchitecture.Application.Repositories;

namespace YYA.CleanArchitecture.Application.Tests.Products.Queries.GetAllProducts
{
    public class GetAllProductsTests
    {
        Mock<IProductRepository> mockRepository;
        Mock<IMapper> mockMapper;


        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IProductRepository>();
            mockMapper = new Mock<IMapper>();
        }

        [Test]
        public async Task CreateProductHandler_ShouldThrowNullException_WithNullRequest()
        {
            GetAllProductsQueryHandler queryHandler = new GetAllProductsQueryHandler(mockRepository.Object,mockMapper.Object);

            var action = async () => await queryHandler.Handle(null, default);

            await action.Should().ThrowAsync<ArgumentNullException>();

        }
    }
}

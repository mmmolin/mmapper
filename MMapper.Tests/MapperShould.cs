using System;
using Xunit;
using MMapper.Application;
using MMapper.Tests.TestClasses;

namespace MMapper.Tests
{
    public class MapperShould
    {
        [Fact]
        public void Map_EntityToModel_HasPropertyValue()
        {
            var entity = new BookTestEntity
            {
                Author = "Terry",
                Title = "Soul Music",
                Created = new DateTime(1978, 03, 20)
            };

            var model = Mapper.Map<BookTestModel>(entity);

            Assert.Equal(entity.Author, model.Author);
        }

        [Fact]
        public void Map_EntityToModel_HasDefaultValue()
        {
            var entity = new BookTestEntity
            {
                Author = "Terry",
                Title = "Soul Music",
                Created = new DateTime(1978, 03, 20)
            };

            var model = Mapper.Map<ApiTestConfiguration>(entity);

            Assert.Null(model.Address);
        }
    }
}

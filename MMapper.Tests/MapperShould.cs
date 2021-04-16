using System;
using Xunit;
using MMapper.Application;
using MMapper.Tests.TestClasses;
using System.Collections.Generic;

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
        public void Map_EntityToModel_IsNull()
        {
            var entity = new BookTestEntity
            {
                Author = "Terry",
                Title = "Soul Music",
                Created = new DateTime(1978, 03, 20)
            };

            var model = Mapper.Map<ApiTestConfiguration>(entity);

            Assert.Null(model);
        }

        [Fact]
        public void Map_EntityToModel_ReturnPopulatedList()
        {
            var entities = new List<BookTestEntity>
            {
                new BookTestEntity
                {
                    Author = "Terry",
                    Title = "Soul Music",
                    Created = new DateTime(1978, 03, 20)
                },
                new BookTestEntity
                {
                    Author = "Terry",
                    Title = "Night watch",
                    Created = new DateTime(1986, 03, 14)
                }
            };

            var models = Mapper.Map<BookTestModel>(entities);

            Assert.Equal(2, models.Count);
        }

        [Fact]
        public void Map_EntityToModel_ReturnEmptyList()
        {
            var entities = new List<BookTestEntity>
            {
                new BookTestEntity
                {
                    Author = "Terry",
                    Title = "Soul Music",
                    Created = new DateTime(1978, 03, 20)
                },
                new BookTestEntity
                {
                    Author = "Terry",
                    Title = "Night watch",
                    Created = new DateTime(1986, 03, 14)
                }
            };

            var models = Mapper.Map<ApiTestConfiguration>(entities);

            Assert.Equal(0, models.Count);
        }
    }
}

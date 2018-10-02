// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using Xunit;

namespace Corenet.Core.Tests
{
    public class Entity_Tests
    {
        [Fact]
        public void EntityWithKeyEquals_EntitiesWithSameValueButDifferentKey_ShouldReturnFalse()
        {
            EntityWithKeyMock entity1 = new EntityWithKeyMock(Guid.NewGuid(), "value");
            EntityWithKeyMock entity2 = new EntityWithKeyMock(Guid.NewGuid(), "value");
            bool actual = entity1.Equals(entity2);

            Assert.False(actual);
        }

        [Fact]
        public void EntityWithKeyEquals_EntitiesWithSameValueAndKey_ShouldReturnTrue()
        {
            Guid guid = Guid.NewGuid();
            EntityWithKeyMock entity1 = new EntityWithKeyMock(guid, "value");
            EntityWithKeyMock entity2 = new EntityWithKeyMock(guid, "value");
            bool actual = entity1.Equals(entity2);

            Assert.True(actual);
        }

        [Fact]
        public void EntityWithKeyEquals_EntitiesWithSameKeyButDifferentValue_ShouldReturnTrue()
        {
            Guid guid = Guid.NewGuid();
            EntityWithKeyMock entity1 = new EntityWithKeyMock(guid, "value");
            EntityWithKeyMock entity2 = new EntityWithKeyMock(guid, "value 2");
            bool actual = entity1.Equals(entity2);

            Assert.True(actual);
        }

        [Fact]
        public void EntityWithoutKeyEquals_EntitiesWithSameValueButDifferentKey_ShouldReturnFalse()
        {
            EntityWithoutKeyMock entity1 = new EntityWithoutKeyMock("key", "prefix", 10);
            EntityWithoutKeyMock entity2 = new EntityWithoutKeyMock("key2", "prefix", 10);
            bool actual = entity1.Equals(entity2);

            Assert.False(actual);
        }

        [Fact]
        public void EntityWithoutKeyEquals_EntitiesWithSameValueAndKey_ShouldReturnTrue()
        {
            EntityWithoutKeyMock entity1 = new EntityWithoutKeyMock("key", "prefix", 10);
            EntityWithoutKeyMock entity2 = new EntityWithoutKeyMock("key", "prefix", 10);
            bool actual = entity1.Equals(entity2);

            Assert.True(actual);
        }

        [Fact]
        public void EntityWithoutKeyEquals_EntitiesWithSameKeyButDifferentValue_ShouldReturnTrue()
        {
            EntityWithoutKeyMock entity1 = new EntityWithoutKeyMock("key", "prefix", 10);
            EntityWithoutKeyMock entity2 = new EntityWithoutKeyMock("key", "prefix", 15);
            bool actual = entity1.Equals(entity2);

            Assert.True(actual);
        }
    }

    internal class EntityWithKeyMock : Entity<Guid>
    {
        public EntityWithKeyMock(Guid id, string value)
        {
            Id = id;
            Value = value;
        }

        public string Value { get; set; }
    }

    internal class EntityWithoutKeyMock : Entity
    {
        public EntityWithoutKeyMock(string key, string prefix, int value)
        {
            Key = key;
            Prefix = prefix;
            Value = value;
        }

        public string Key { get; set; }
        public string Prefix { get; set; }
        public int Value { get; set; }

        public override object[] GetKeyValues() => new object[] { Key, Prefix };
    }
}

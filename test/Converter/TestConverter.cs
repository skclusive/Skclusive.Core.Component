using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Skclusive.Extensions.DependencyInjection;
using Xunit;

namespace Skclusive.Core.Component
{
    public interface ITestObject
    {
        string Name { set; get; }

        int Value { set; get; }
    }

    public interface ITestContainer<T>
    {
        public IDictionary<T, ITestObject> Map { set; get; }
    }

    public class TestObject : ITestObject
    {
        public string Name { set; get; }

        public int Value { set; get; }
    }

    public class TestContainer<T> : ITestContainer<T>
    {
        public IDictionary<T, ITestObject> Map { set; get; }
    }

    public class TestConverter
    {
        [Fact]
        public void TestContainerInt()
        {
            var container = new TestContainer<int>
            {
                Map = new Dictionary<int, ITestObject>
                {
                    {  1, new TestObject { Name = "1x", Value = 1 } },
                    {  2, new TestObject { Name = "2x", Value = 2 } },
                }
            };

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            options.Converters.Add(new JsonTypeConverter<ITestContainer<int>, TestContainer<int>>());
            options.Converters.Add(new JsonTypeConverter<ITestObject, TestObject>());
            options.Converters.Add(new JsonIntDictionaryConverter<ITestObject>());

            var json = JsonSerializer.Serialize(container, options);

            var dcontainer = JsonSerializer.Deserialize<TestContainer<int>>(json, options);

            Assert.NotNull(dcontainer);
            Assert.Equal(2, dcontainer.Map.Count);

            Assert.Equal("1x", dcontainer.Map[1].Name);
            Assert.Equal(1, dcontainer.Map[1].Value);

            Assert.Equal("2x", dcontainer.Map[2].Name);
            Assert.Equal(2, dcontainer.Map[2].Value);
        }

        [Fact]
        public void TestContainerString()
        {
            var container = new TestContainer<string>
            {
                Map = new Dictionary<string, ITestObject>
                {
                    {  "1", new TestObject { Name = "1x", Value = 1 } },
                    {  "2", new TestObject { Name = "2x", Value = 2 } },
                }
            };

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            options.Converters.Add(new JsonTypeConverter<ITestContainer<string>, TestContainer<string>>());
            options.Converters.Add(new JsonTypeConverter<ITestObject, TestObject>());
            options.Converters.Add(new JsonIntDictionaryConverter<ITestObject>());

            var json = JsonSerializer.Serialize(container, options);

            var dcontainer = JsonSerializer.Deserialize<TestContainer<string>>(json, options);

            Assert.NotNull(dcontainer);
            Assert.Equal(2, dcontainer.Map.Count);

            Assert.Equal("1x", dcontainer.Map["1"].Name);
            Assert.Equal(1, dcontainer.Map["1"].Value);

            Assert.Equal("2x", dcontainer.Map["2"].Name);
            Assert.Equal(2, dcontainer.Map["2"].Value);
        }
    }
}
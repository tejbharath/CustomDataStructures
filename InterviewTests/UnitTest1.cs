using System;
using System.Collections.Generic;
using System.Linq;
using TechInterviewOne.Solution;
using Xunit;

namespace InterviewTests
{
    public class UnitTest1
    {
        private readonly MultiValueDictionary<string, string> _target;

        public UnitTest1()
        {
            _target = new MultiValueDictionary<string, string>();
        }

        [Fact]
        public void Add_ShouldAddNewItem()
        {
            _target.Add("A", "B");

            var result = _target["A"];

            Assert.Equal("B", result.First());
        }

        [Fact]
        public void Add_ShouldThrowInvalidOperationExceptionIfValueExistsForKey()
        {
            _target.Add("A", "B");

            Assert.Throws<InvalidOperationException>(() =>
            {
                _target.Add("A", "B");
            });
        }

        [Fact]
        public void Remove_ShouldRemoveTheSpecifiedValueFromTheMultiValueCollection()
        {
            _target.Add("A", "B");
            _target.Add("A", "C");

            _target.Remove("A", "B");

            var result = _target["A"];

            Assert.Contains("C", result);
            Assert.DoesNotContain("B", result);
        }

        [Fact]
        public void Remove_ShouldRemoveTheKeyIfNoMoreValuesExist()
        {
            _target.Add("A", "B");
            _target.Remove("A", "B");

            Assert.False(_target.ContainsKey("A"));
        }

        [Fact]
        public void Remove_ShouldReturnTrueIfTheKeyValueExists()
        {
            _target.Add("A", "B");

            var result = _target.Remove("A", "B");

            Assert.True(result);
        }

        [Fact]
        public void Remove_ShouldReturnFalseIfTheKeyValueDoesntExist()
        {
            _target.Add("A", "B");
            
            var result = _target.Remove("A", "C");

            Assert.False(result);
        }

        [Fact]
        public void Remove_ShouldReturnFalseIfTheKeyDoesntExist()
        {
            _target.Add("A", "B");

            var result = _target.Remove("X", "B");

            Assert.False(result);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveAllValuesAndTheKey()
        {
            _target.Add("A", "B");
            _target.Add("A", "C");

            _target.RemoveAll("A");

            Assert.False(_target.ContainsKey("A"));
        }

        [Fact]
        public void RemoveAll_ShouldReturnTrueIfTheKeyWasFound()
        {
            _target.Add("A", "C");

            var result = _target.RemoveAll("A");

            Assert.True(result);
        }

        [Fact]
        public void RemoveAll_ShouldReturnFalseIfKeyWasNotFound()
        {
            _target.Add("A", "B");

            var result = _target.RemoveAll("C");

            Assert.False(result);
        }

        [Fact]
        public void Clear_ShouldRemoveAllValues()
        {
            _target.Add("A", "A");
            _target.Add("A", "B");
            _target.Add("B", "A");
            _target.Add("B", "B");

            _target.Clear();

            var result = _target.ContainsKey("A") || _target.ContainsKey("B");

            Assert.False(result);
        }

        [Fact]
        public void ContainsKey_ReturnsTrueIfKeyExists()
        {
            _target.Add("A", "B");

            var result = _target.ContainsKey("A");

            Assert.True(result);
        }

        [Fact]
        public void ContainsKey_ReturnsFalseIfKeyDoesNotExist()
        {
            _target.Add("A", "B");

            var result = _target.ContainsKey("C");

            Assert.False(result);
        }

        [Fact]
        public void ContainsValue_ReturnsTrueIfKeyValueCombinationExists()
        {
            _target.Add("A", "B");

            var result = _target.ContainsValue("A", "B");

            Assert.True(result);
        }

        [Fact]
        public void ContainsValue_ReturnsFalseIfKeyDoesNotExist()
        {
            _target.Add("A", "B");

            var result = _target.ContainsValue("B", "B");

            Assert.False(result);
        }

        [Fact]
        public void ContainsValue_ReturnsFalseIfValueDoesNotExist()
        {
            _target.Add("A", "B");

            var result = _target.ContainsValue("A", "C");

            Assert.False(result);
        }

        [Fact]
        public void Keys_ReturnsCollectionOfKeys()
        {
            var sourceKeys = new[] { "A", "B", "C" };

            _target.Add(sourceKeys[0], "B");
            _target.Add(sourceKeys[1], "C");
            _target.Add(sourceKeys[2], "D");

            var keys = _target.Keys();

            Assert.All(keys, key => sourceKeys.Contains(key));
            Assert.All(sourceKeys, key => keys.Contains(key));
        }

        [Fact]
        public void Keys_ReturnsEmptyCollectionIfNoKeysExist()
        {
            var result = _target.Keys();

            Assert.Empty(result);
        }

        [Fact]
        public void Values_ReturnsAllValues()
        {
            var sourceValues = new[] { "X", "Y", "Z" };

            _target.Add("A", sourceValues[0]);
            _target.Add("A", sourceValues[1]);
            _target.Add("B", sourceValues[2]);

            var values = _target.Values();

            Assert.All(values, value => sourceValues.Contains(value));
            Assert.All(sourceValues, value => values.Contains(value));
        }

        [Fact]
        public void Values_ReturnsEmptyCollectionIfNoKeysExist()
        {
            var result = _target.Values();

            Assert.Empty(result);
        }

        [Fact]
        public void Items_ReturnsKeyValuePairForEveryItemInTheMultiValueDictionary()
        {
            var source = new[]
            {
                new KeyValuePair<string, string>("A", "A"),
                new KeyValuePair<string, string>("A", "B"),
                new KeyValuePair<string, string>("A", "C"),
                new KeyValuePair<string, string>("B", "A"),
                new KeyValuePair<string, string>("B", "B"),
                new KeyValuePair<string, string>("C", "A")
            };

            foreach(var kvp in source)
            {
                _target.Add(kvp.Key, kvp.Value);
            }

            var result = _target.Items();

            Assert.All(result, itm => source.Contains(itm));
            Assert.All(source, itm => result.Contains(itm));
        }

        [Fact]
        public void Items_ReturnsEmptyCollectionIfNoKeyValuesExistInMultiValueDictionary()
        {
            var result = _target.Items();

            Assert.Empty(result);
        }
    }
}

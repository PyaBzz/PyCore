using Xunit;
using Baz.Core;
using System.Collections.Generic;

namespace Test
{
    public class Collections
    {
        [Fact]
        public void OrEmpty_ReturnsEmpty_IfNull()
        {
            IEnumerable<int> unInitialised = null;
            Assert.Empty(unInitialised.OrEmpty());
        }
        [Fact]
        public void OrEmpty_ReturnsItself_IfNotEmpty()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.Same(list, list.OrEmpty());
        }
        [Fact]
        public void ToString_GetsEmpty_IfEmpty()
        {
            var list = new List<int>();
            Assert.Same(string.Empty, list.ToString("Separator"));
        }
        [Fact]
        public void ToString_AddsNoSeparator_IfSingleElem()
        {
            var myList = new List<int> { 1 };
            Assert.Same("1", myList.ToString("Separator"));
        }
    }
}

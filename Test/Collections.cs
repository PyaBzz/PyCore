using Xunit;
using Baz.Core;
using System.Collections.Generic;

namespace Test
{
    public class Collections
    {
        [Fact]
        public void OrEmpty_Returns_Empty_if_Null()
        {
            IEnumerable<int> unInitialised = null;
            Assert.Empty(unInitialised.OrEmpty());
        }
        [Fact]
        public void OrEmpty_Returns_Itself_if_NotEmpty()
        {
            var myList = new List<int> { 1, 2, 3 };
            Assert.Same(myList, myList.OrEmpty());
        }
    }
}

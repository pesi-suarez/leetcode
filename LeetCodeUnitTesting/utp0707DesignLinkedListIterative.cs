using p707DesignLinkedListIterative;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0707DesignLinkedListIterative
    {
        [Fact]
        public void ListOperations()
        {
            Solution myList = new Solution();
            myList.AddAtHead(2);
            myList.AddAtHead(5);
            myList.AddAtTail(1);
            myList.DeleteAtIndex(0);
            Assert.Equal(2, myList.Get(0));
            Assert.Equal(1, myList.Get(1));
        }
    }
}

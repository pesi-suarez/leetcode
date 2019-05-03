using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p707DesignLinkedListIterative;
using System.Collections.Generic;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp707DesignLinkedListIterative
    {
        [TestMethod]
        public void ListOperations()
        {
            Solution myList = new Solution();
            myList.AddAtHead(2);
            myList.AddAtHead(5);
            myList.AddAtTail(1);
            myList.DeleteAtIndex(0);
            Assert.AreEqual(2, myList.Get(0));
            Assert.AreEqual(1, myList.Get(1));
        }
    }
}

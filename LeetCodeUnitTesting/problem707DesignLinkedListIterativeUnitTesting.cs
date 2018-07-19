using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeClassLibrary;
using System.Collections.Generic;
using LeetCodeClassLibrary;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class problem707DesignLinkedListIterativeUnitTesting
    {
        [TestMethod]
        public void ListOperations()
        {
            problem707DesignLinkedListIterative myList = new problem707DesignLinkedListIterative();
            myList.AddAtHead(2);
            myList.AddAtHead(5);
            myList.AddAtTail(1);
            myList.DeleteAtIndex(0);
            Assert.AreEqual(2, myList.Get(0));
            Assert.AreEqual(1, myList.Get(1));
        }
    }
}

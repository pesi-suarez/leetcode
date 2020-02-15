using Microsoft.VisualStudio.TestTools.UnitTesting;
using p146LruCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp0146LruCache
    {
        [TestMethod]
        public void Descriptiontests()
        {
            LRUCache cache = new LRUCache(2 /* capacity */ );
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(1, cache.Get(1));       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Assert.AreEqual(-1, cache.Get(2));       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            Assert.AreEqual(-1, cache.Get(1));       // returns -1 (not found)
            Assert.AreEqual(3, cache.Get(3));       // returns 3
            Assert.AreEqual(4, cache.Get(4));       // returns 4
        }

        [TestMethod]
        public void UpdateKey()
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(2, 2);
            Assert.AreEqual(2, cache.Get(2));
            cache.Put(1, 1);
            cache.Put(4, 1);
            Assert.AreEqual(-1, cache.Get(2));
        }
    }
}

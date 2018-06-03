using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using twolist;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PusitiveUnitTest1OfAddAfterEvenMetod()
        {
            DoubleLinkList actual = new DoubleLinkList();
            actual.AddEnd(1);
            actual.AddEnd(2);
            actual.AddEnd(3);
            actual.AddEnd(4);
            actual.AddEnd(5);
            actual.AddEnd(6);
            actual.AddAfterEven(7);
            DoubleLinkList expected = new DoubleLinkList();
            expected.AddEnd(1);
            expected.AddEnd(2);
            expected.AddEnd(7);
            expected.AddEnd(3);
            expected.AddEnd(4);
            expected.AddEnd(7);
            expected.AddEnd(5);
            expected.AddEnd(6);
            expected.AddEnd(7);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}

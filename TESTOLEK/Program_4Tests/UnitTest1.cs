using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program_4;
using System.Collections.Generic;

namespace Program_4Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            var list = new string[] { "test.h", "test1.h" };
            files s;
            s = new files();

            var x = s.Reader(list);            
            Assert.IsNotNull(x);
            Assert.AreEqual(x.Count, 2);
            Assert.IsTrue(x.ContainsKey("test.h"));

            Assert.IsTrue(x.ContainsKey("test1.h"));
        }
    }
}

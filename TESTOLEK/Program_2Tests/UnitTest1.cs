using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
namespace Program_2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = new string[] { "test.h" };
            Program.files t = new Program.files();
            var x = t.Reader(list);

            Assert.IsNotNull(x);
            Assert.IsFalse(x.ContainsKey("test.h"));

            Assert.AreEqual(7, x.Count);
        }
    }
}

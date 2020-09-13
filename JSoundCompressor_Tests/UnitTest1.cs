using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSoundCompressor;

namespace JSoundCompressor_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParseArgs_AllValid_returnTrue()
        {
            string[] stringArray = {"  ",  " "};

            var result = ParseArgs(stringArray);
        }
    }
}

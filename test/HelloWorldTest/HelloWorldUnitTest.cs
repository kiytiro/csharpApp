using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldUnitTest
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void RunMain()
        {
            // Arrange
            string expected = "Hello World!";

            // Act

            // Represents a multable string of characters.
            StringBuilder sb = new StringBuilder();

            // Implements a TextWriter for writing information to a string.
            StringWriter sw = new StringWriter(sb);

            // Set the Console.out to a specified TextWriter object
            Console.SetOut(sw);

            
            HelloWorld.Program.Main(new[] { "Test" });

            // Assert
            Assert.AreEqual(expected.ToString(), sw.ToString().Trim());
        }

        [TestMethod]
        public void Passthrough_ReturnsTheGivenValue()
        {
            // Arrange
            var value = 42;

            // Act
            var actual = HelloWorld.Program.Passthrough(value);

            // Assert
            Assert.AreEqual(actual, value);
        }
    }
}

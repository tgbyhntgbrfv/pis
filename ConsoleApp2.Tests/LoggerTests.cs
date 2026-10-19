using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp2.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void Instance_ReturnsSameObject()
        {
            var a = Logger.Instance;
            var b = Logger.Instance;
            Assert.Same(a, b);  
        }

        [Fact]
        public void Instance_IsNotNull()
        {
            Assert.NotNull(Logger.Instance);
        }

    }
}

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using LogAn.Classes;

namespace LogAnTests
{
    [TestFixture]
    public class AsyncAwaitTests
    {
        [Test]
        public void Divide_FourByTwo_ReturnTwo()
        {
            var task = AsyncAwait.Divide(4, 2);
            Assert.AreEqual(2, task.Result);
        }

        [Test]
        public void Divide_FourByZero_RaiseDivideByZeroException()
        {
            var task = AsyncAwait.Divide(4, 2);
            Assert.Throws<DivideByZeroException>(() => { throw new DivideByZeroException(); });

        }

        [Test]
        public void ParseWebsiteUrlAsync_WhenCalled_ReturnString()
        {
            var task = AsyncAwait.ParseWebsiteUrlAsync("https://www.dominos.co.uk/store");

            var restult  = task.Result;

            Assert.NotNull(task.Result);


        }

    }
}

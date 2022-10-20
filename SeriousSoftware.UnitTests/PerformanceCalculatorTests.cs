using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeriousSoftware.Services;
using SeriousSoftware.Services.Models;
using System.Collections.Generic;

namespace SeriousSoftware.UnitTests
{
    [TestClass]
    public class PerformanceCalculatorTests
    {
        [TestMethod]
        public void CalculatePerformance_Success()
        {
            // Arrange
            var service = new PerformanceCalculator();
            var prices = new List<PriceModel>
            {
                new PriceModel{ Price = 100, Time = new System.DateTimeOffset(new System.DateTime(2022, 11, 1))},
                new PriceModel{ Price = 110, Time = new System.DateTimeOffset(new System.DateTime(2022, 11, 2))},
                new PriceModel{ Price = 121, Time = new System.DateTimeOffset(new System.DateTime(2022, 11, 3))},
                new PriceModel{ Price = 78, Time = new System.DateTimeOffset(new System.DateTime(2022, 11, 4))},
                new PriceModel{ Price = 95, Time = new System.DateTimeOffset(new System.DateTime(2022, 11, 5))},
                new PriceModel{ Price = 112, Time = new System.DateTimeOffset(new System.DateTime(2022, 11, 6))}
            };


            // Act

            var actual = service.CalculatePerformance(prices);

            // Assert

            Assert.AreEqual(actual.Count, prices.Count);

            var expected = new List<StockPerformance> {
                new StockPerformance() { Performance = 0 },
                new StockPerformance() { Performance = 10 },
                new StockPerformance() { Performance = 21 },
                new StockPerformance() { Performance = -22 },
                new StockPerformance() { Performance = -5 },
                new StockPerformance() { Performance = 12 }
            };

            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Performance, actual[i].Performance);
            }
        }
    }
}
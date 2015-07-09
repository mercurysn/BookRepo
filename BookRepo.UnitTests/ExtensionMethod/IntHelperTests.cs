using BookRepo.Helpers.ExtensionMethods;
using NUnit.Framework;

namespace BookRepo.UnitTests.ExtensionMethod
{
    [TestFixture]
    public class IntHelperTests
    {
        [Test]
        public void Test_ToHourMinute()
        {
            const int INPUT_MINUTES_GREATER_THAN_60 = 320;
            const int INPUT_MINUTES_LESS_THAN_60 = 20;
            const int INPUT_MINUTES_EXACTLY_60 = 60;
            const int INPUT_MINUTES_GREATER_THAN_1DAY = 2960;


            string resultGreaterThan60 = INPUT_MINUTES_GREATER_THAN_60.ToHourMinuteDisplay();
            string resultLessThan60 = INPUT_MINUTES_LESS_THAN_60.ToHourMinuteDisplay();
            string resultExactly60 = INPUT_MINUTES_EXACTLY_60.ToHourMinuteDisplay();
            string resultGreaterThan1Day = INPUT_MINUTES_GREATER_THAN_1DAY.ToHourMinuteDisplay();

            Assert.AreEqual("5h 20m", resultGreaterThan60);
            Assert.AreEqual("20m", resultLessThan60);
            Assert.AreEqual("60m", resultExactly60);
            Assert.AreEqual("49h 20m", resultGreaterThan1Day);
        }
    }
}

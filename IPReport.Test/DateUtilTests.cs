using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IPReport.Util;

using NUnit.Framework;

namespace IPReport.Test
{
    [TestFixture]
    public class DateUtilTests
    {
        [Test]
        public void TestOctober()
        {
            DateTime startDate = new DateTime(2012, 10, 12);

            DateTime start = DateUtil.FirstDayOfMonthFromDateTime(startDate);
            DateTime end = DateUtil.LastDayOfMonthFromDateTime(startDate);

            DateTime expectedStartDate = new DateTime(2012, 10, 1);
            DateTime expectedEndDate = new DateTime(2012, 10, 31, 23, 59, 59);

            Assert.AreEqual(expectedStartDate, start);
            Assert.AreEqual(expectedEndDate, end);
        }

        [Test]
        public void TestOctoberFormat()
        {
            DateTime startDate = new DateTime(2012, 10, 12);

            DateTime start = DateUtil.FirstDayOfMonthFromDateTime(startDate);
            DateTime end = DateUtil.LastDayOfMonthFromDateTime(startDate);

            string startDateFormat = DateUtil.FormatDate(start);
            string endDateFormat = DateUtil.FormatDate(end);

            Assert.AreEqual("2012-10-01T00:00:00", startDateFormat);
            Assert.AreEqual("2012-10-31T23:59:59", endDateFormat);
        }
    }
}

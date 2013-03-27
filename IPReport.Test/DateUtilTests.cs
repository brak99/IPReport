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

        [Test]
        public void TestParseDate()
        {
            string date = "2013-03-24T13:08:11";

            DateTime parsedDate = DateUtil.ParseDate(date);

            Assert.AreEqual(2013, parsedDate.Year);
            Assert.AreEqual(3, parsedDate.Month);
            Assert.AreEqual(24, parsedDate.Day);
            Assert.AreEqual(13, parsedDate.Hour);
            Assert.AreEqual(8, parsedDate.Minute);
            Assert.AreEqual(11, parsedDate.Second);

        }
    }
}

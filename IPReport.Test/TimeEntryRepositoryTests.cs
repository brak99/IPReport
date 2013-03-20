using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.DataAccess;
using System.Xml;

namespace IPReport.Test
{
    public class TestTimeEntryRepository : TimeEntryRepository
    {
        public static XmlDocument CallTimeEntryRequest(DateTime startDate, DateTime endDate)
        {
            return TimeEntriesRequest(startDate, endDate);
        }
        public static XmlDocument CallTimeEntryRequest(DateTime startDate, DateTime endDate, int store)
        {
            return TimeEntriesRequest(startDate, endDate, store);
        }
    }

    [TestFixture]
    public class TimeEntryRepositoryTests
    {
        [Test]
        public void TestQuery()
        {
            DateTime start = new DateTime(2013, 1, 1);
            DateTime end = new DateTime(2013,1,2);

            XmlDocument doc = TestTimeEntryRepository.CallTimeEntryRequest(start, end);

            Assert.Greater(doc.ChildNodes.Count, 0);

            string expectedQuery = @"<?xml version=""1.0"" encoding=""utf-8""?><?qbposxml version=""3.0""?><QBPOSXML><QBPOSXMLMsgsRq onError=""stopOnError""><TimeEntryQueryRq><ClockInTimeRangeFilter><FromClockInTime>2013-01-01T00:00:00</FromClockInTime><ToClockInTime>2013-01-02T00:00:00</ToClockInTime></ClockInTimeRangeFilter><ClockOutTimeRangeFilter><FromClockOutTime>2013-01-01T00:00:00</FromClockOutTime><ToClockOutTime>2013-01-02T00:00:00</ToClockOutTime></ClockOutTimeRangeFilter></TimeEntryQueryRq></QBPOSXMLMsgsRq></QBPOSXML>";

            Assert.AreEqual(expectedQuery, doc.InnerXml);

        }

        [Test]
        public void TestQueryWithStore()
        {
            DateTime start = new DateTime(2013, 1, 1);
            DateTime end = new DateTime(2013, 1, 2);

            XmlDocument doc = TestTimeEntryRepository.CallTimeEntryRequest(start, end, 1);

            Assert.Greater(doc.ChildNodes.Count, 0);

            string expectedQuery = @"<?xml version=""1.0"" encoding=""utf-8""?><?qbposxml version=""3.0""?><QBPOSXML><QBPOSXMLMsgsRq onError=""stopOnError""><TimeEntryQueryRq><ClockInTimeRangeFilter><FromClockInTime>2013-01-01T00:00:00</FromClockInTime><ToClockInTime>2013-01-02T00:00:00</ToClockInTime></ClockInTimeRangeFilter><ClockOutTimeRangeFilter><FromClockOutTime>2013-01-01T00:00:00</FromClockOutTime><ToClockOutTime>2013-01-02T00:00:00</ToClockOutTime></ClockOutTimeRangeFilter><StoreNumberFilter><MatchNumericCriterion>Equal</MatchNumericCriterion><StoreNumber>1</StoreNumber></StoreNumberFilter></TimeEntryQueryRq></QBPOSXMLMsgsRq></QBPOSXML>";

            Assert.AreEqual(expectedQuery, doc.InnerXml);
        }
    }
}

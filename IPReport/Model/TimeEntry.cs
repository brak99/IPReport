using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPReport.Model
{
    public class TimeEntry : QBDataItem
    {
        public string ListID { get { return GetNodeInnerText("ListID"); } }
        public string ClockInTime { get { return GetNodeInnerText("ClockInTime"); } }
        public string ClockOutTime { get { return GetNodeInnerText("ClockInTime"); } }
        public string EmployeeListID { get { return GetNodeInnerText("EmployeeListID"); } }
        public string EmployeeLoginName { get { return GetNodeInnerText("EmployeeLoginName"); } }
        public string FirstName { get { return GetNodeInnerText("FirstName"); } }
        public string LastName { get { return GetNodeInnerText("LastName"); } }
        public string StoreNumber { get { return GetNodeInnerText("StoreNumber"); } }

        public TimeEntry(XmlNode node)
			: base(node)
		{
        }
    }
}

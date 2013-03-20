using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.DataAccess;
using System.Xml;

namespace IPReport.Test
{
	[TestFixture]
	public class TransferRepositoryTests
	{
		[Test]
		public void TestFromStore()
		{
			XmlNodeList list = TransferRepository.GetTransfersForMonthFromStore(DateTime.Now, 1);
		}
	}
}

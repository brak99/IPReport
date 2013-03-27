using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IPReport.Util
{
	class TestResponses
	{
		public static string DepartmentResponse = @"<?xml version=""1.0"" encoding=""windows-1252""?>
			<QBPOSXML>
				<QBPOSXMLMsgsRs>
					<DepartmentQueryRs retCount=""6"" statusCode=""0"" statusMessage=""Status OK"" statusSeverity=""Info"">
						<DepartmentRet>
							<ListID>-9159787098314735359</ListID>
							<TimeCreated>2010-01-02T16:12:35-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:46:41-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>CCC</DepartmentCode>
							<DepartmentName>Classes Classes Classes</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Non</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-9067282939145977599</ListID>
							<TimeCreated>2010-01-27T14:29:02-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:42:52-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AAH</DepartmentCode>
							<DepartmentName>Apparel Accessories Hair</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-9026255433551150847</ListID>
							<TimeCreated>2010-02-07T15:49:50-06:00</TimeCreated>
							<TimeModified>2010-02-07T15:49:50-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>SFX</DepartmentCode>
							<DepartmentName>Store Fixture</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Non</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-8927243042012888831</ListID>
							<TimeCreated>2010-03-03T08:11:34-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:51:57-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GCA</DepartmentCode>
							<DepartmentName>Gear Car Seats Accessories</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-8561939146401218303</ListID>
							<TimeCreated>2010-06-08T18:48:19-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:58:07-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDT</DepartmentCode>
							<DepartmentName>Gear Diapers AI2</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-8024558202471415551</ListID>
							<TimeCreated>2010-10-29T14:19:27-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:10:32-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GSS</DepartmentCode>
							<DepartmentName>Gear Strollers Strollers</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591177075380551423</ListID>
							<TimeCreated>2011-11-12T20:44:38-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:44:38-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ACB</DepartmentCode>
							<DepartmentName>Apparel Childrens Bottoms</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591176246426697471</ListID>
							<TimeCreated>2011-11-12T20:45:00-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:45:00-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ACS</DepartmentCode>
							<DepartmentName>Apparel Childrens Socks</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591175275755699967</ListID>
							<TimeCreated>2011-11-12T20:45:15-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:45:15-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ACP</DepartmentCode>
							<DepartmentName>Apparel Childrens Pajamas</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591173149721722623</ListID>
							<TimeCreated>2011-11-12T20:46:03-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:46:03-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AOA</DepartmentCode>
							<DepartmentName>Apparel Outdoor Adult</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591172608539066111</ListID>
							<TimeCreated>2011-11-12T20:46:18-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:46:18-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AOC</DepartmentCode>
							<DepartmentName>Apparel Outdoor Childrens</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591169408780041983</ListID>
							<TimeCreated>2011-11-12T20:47:34-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:47:34-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>EBC</DepartmentCode>
							<DepartmentName>Entertainment Books Childrens</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591165916946464511</ListID>
							<TimeCreated>2011-11-12T20:48:53-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:48:53-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ETO</DepartmentCode>
							<DepartmentName>Entertainment Toys Over 3</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591161192474050303</ListID>
							<TimeCreated>2011-11-12T20:50:43-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:50:43-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAT</DepartmentCode>
							<DepartmentName>Gear Bath Tubs</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591159551771377407</ListID>
							<TimeCreated>2011-11-12T20:51:29-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:51:29-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GES</DepartmentCode>
							<DepartmentName>Gear Bedding Swaddles</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591157369911213823</ListID>
							<TimeCreated>2011-11-12T20:52:14-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:52:14-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GCB</DepartmentCode>
							<DepartmentName>Gear Car Seats Boosters</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591156656938254079</ListID>
							<TimeCreated>2011-11-12T20:52:49-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:52:49-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GCC</DepartmentCode>
							<DepartmentName>Gear Car Seats Convertibles</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591151094938828543</ListID>
							<TimeCreated>2011-11-12T20:54:48-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:54:48-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAS</DepartmentCode>
							<DepartmentName>Gear Carriers Slings</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591150029761773311</ListID>
							<TimeCreated>2011-11-12T20:55:10-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:55:10-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAO</DepartmentCode>
							<DepartmentName>Gear Carriers Soft Structured</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591149110621994751</ListID>
							<TimeCreated>2011-11-12T20:55:23-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:55:23-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAW</DepartmentCode>
							<DepartmentName>Gear Carriers Wraps</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591127992251023103</ListID>
							<TimeCreated>2011-11-12T21:03:40-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:03:40-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GFD</DepartmentCode>
							<DepartmentName>Gear Feeding Dishes</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591127189075361535</ListID>
							<TimeCreated>2011-11-12T21:04:00-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:04:00-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GFS</DepartmentCode>
							<DepartmentName>Gear Feeding Sippy Cups</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591122507552620287</ListID>
							<TimeCreated>2011-11-12T21:05:49-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:05:49-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GMP</DepartmentCode>
							<DepartmentName>Gear Mama Postpartum</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591078617256656639</ListID>
							<TimeCreated>2011-11-12T21:23:16-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:23:16-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GFA</DepartmentCode>
							<DepartmentName>Gear Feeding Accessories</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6591018625128300287</ListID>
							<TimeCreated>2011-11-12T21:46:07-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:46:07-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ACD</DepartmentCode>
							<DepartmentName>Apparel Childrens Dresses</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6590981933189136127</ListID>
							<TimeCreated>2011-11-12T22:00:15-06:00</TimeCreated>
							<TimeModified>2011-11-12T22:00:15-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AAT</DepartmentCode>
							<DepartmentName>Apparel Accessories Hats</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6590954320810835711</ListID>
							<TimeCreated>2011-11-12T22:11:14-06:00</TimeCreated>
							<TimeModified>2011-11-12T22:11:14-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAA</DepartmentCode>
							<DepartmentName>Gear Carriers Accessories</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6587657713352802047</ListID>
							<TimeCreated>2011-11-13T19:30:14-06:00</TimeCreated>
							<TimeModified>2011-11-13T19:30:14-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAH</DepartmentCode>
							<DepartmentName>Gear Bath Health</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6587629645691191039</ListID>
							<TimeCreated>2011-11-13T19:41:12-06:00</TimeCreated>
							<TimeModified>2011-11-13T19:41:12-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAP</DepartmentCode>
							<DepartmentName>Gear Bath Potties</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>-6047098538033250047</ListID>
							<TimeCreated>2012-04-04T11:34:50-06:00</TimeCreated>
							<TimeModified>2012-04-04T11:34:50-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentName>Gear Bedding Sheets</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>1000000001</ListID>
							<TimeCreated>2009-06-12T22:28:48-06:00</TimeCreated>
							<TimeModified>2009-06-12T22:28:48-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>SYS</DepartmentCode>
							<DepartmentName>System</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8519785162043457793</ListID>
							<TimeCreated>2009-06-12T22:30:35-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:26:58-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>HDP</DepartmentCode>
							<DepartmentName>Home Decor Apparel</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8519785162060235009</ListID>
							<TimeCreated>2009-06-12T22:30:35-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:16:27-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>HUC</DepartmentCode>
							<DepartmentName>Home Supplies Cleaning</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8519785162152509697</ListID>
							<TimeCreated>2009-06-12T22:30:35-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:09:02-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AAS</DepartmentCode>
							<DepartmentName>Apparel Accessories Shoes</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8519785162177675521</ListID>
							<TimeCreated>2009-06-12T22:30:35-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:15:00-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>HSC</DepartmentCode>
							<DepartmentName>Home Stationary Cards</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8519785162202841345</ListID>
							<TimeCreated>2009-06-12T22:30:35-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:48:38-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ETU</DepartmentCode>
							<DepartmentName>Entertainment Toys Under 3</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523097998958166273</ListID>
							<TimeCreated>2009-06-13T19:56:08-06:00</TimeCreated>
							<TimeModified>2009-06-13T19:56:08-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentName>QuickBooks Financial Software</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523123433863545089</ListID>
							<TimeCreated>2009-06-13T20:06:26-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:00:43-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDO</DepartmentCode>
							<DepartmentName>Gear Diapers Pockets OS</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523124537686917377</ListID>
							<TimeCreated>2009-06-13T20:06:39-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:00:16-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDZ</DepartmentCode>
							<DepartmentName>Gear Diapers Pocket Sized</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523125100352798977</ListID>
							<TimeCreated>2009-06-13T20:06:52-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:01:09-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDR</DepartmentCode>
							<DepartmentName>Gear Diapers Prefolds/Flats</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523125658706936065</ListID>
							<TimeCreated>2009-06-13T20:07:23-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:57:45-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDI</DepartmentCode>
							<DepartmentName>Gear Diapers AIO</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523126981573640449</ListID>
							<TimeCreated>2009-06-13T20:07:39-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:59:47-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDF</DepartmentCode>
							<DepartmentName>Gear Diapers Fitted</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523129322364371201</ListID>
							<TimeCreated>2009-06-13T20:08:57-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:59:06-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDC</DepartmentCode>
							<DepartmentName>Gear Diaper Covers PUL</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523131006016717057</ListID>
							<TimeCreated>2009-06-13T20:09:17-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:59:28-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDW</DepartmentCode>
							<DepartmentName>Gear Diaper Covers Wool</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523132406209609985</ListID>
							<TimeCreated>2009-06-13T20:09:49-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:56:06-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDA</DepartmentCode>
							<DepartmentName>Gear Diapers Accessories</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523133248039977217</ListID>
							<TimeCreated>2009-06-13T20:10:48-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:54:24-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAM</DepartmentCode>
							<DepartmentName>Gear Carriers Mei Tais</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523136121398264065</ListID>
							<TimeCreated>2009-06-13T20:11:24-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:44:19-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>ACT</DepartmentCode>
							<DepartmentName>Apparel Childrens Tops</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523137315415949569</ListID>
							<TimeCreated>2009-06-13T20:11:45-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:45:50-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AWI</DepartmentCode>
							<DepartmentName>Apparel Womens Intimate</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523138230269149441</ListID>
							<TimeCreated>2009-06-13T20:12:03-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:49:36-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GBD</DepartmentCode>
							<DepartmentName>Gear Bags Diaper Bags</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523138994790105345</ListID>
							<TimeCreated>2009-06-13T20:12:51-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:01:48-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDT</DepartmentCode>
							<DepartmentName>Gear Diapers Training Pants</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523141077857632513</ListID>
							<TimeCreated>2009-06-13T20:13:01-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:01:26-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GDS</DepartmentCode>
							<DepartmentName>Gear Diapers Swim</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523141498789593345</ListID>
							<TimeCreated>2009-06-13T20:13:52-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:17:24-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>SCC</DepartmentCode>
							<DepartmentName>Skin Care Childrens Childrens</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523143697829626113</ListID>
							<TimeCreated>2009-06-13T20:14:11-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:17:03-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>SAA</DepartmentCode>
							<DepartmentName>Skin Care Adult Adult</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523144483817029889</ListID>
							<TimeCreated>2009-06-13T20:14:51-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:04:33-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GMM</DepartmentCode>
							<DepartmentName>Gear Mama Menstrual</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523146206124081409</ListID>
							<TimeCreated>2009-06-13T20:15:23-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:12:19-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GMB</DepartmentCode>
							<DepartmentName>Gear Mama Breastfeeding</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523151639282876673</ListID>
							<TimeCreated>2009-06-13T20:17:05-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:48:05-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>EMM</DepartmentCode>
							<DepartmentName>Entertainment Music Music</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523151952832266497</ListID>
							<TimeCreated>2009-06-13T20:17:15-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:47:17-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>EBA</DepartmentCode>
							<DepartmentName>Entertainment Books Adult</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8523155122551685377</ListID>
							<TimeCreated>2009-06-13T20:18:34-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:03:21-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GFB</DepartmentCode>
							<DepartmentName>Gear Feeding Bottles</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8573570198093594881</ListID>
							<TimeCreated>2009-06-27T10:22:06-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:51:07-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GEB</DepartmentCode>
							<DepartmentName>Gear Bedding Blankets</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8600910387975454977</ListID>
							<TimeCreated>2009-07-03T19:11:28-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:14:06-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>HUU</DepartmentCode>
							<DepartmentName>Home Furniture Furniture</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8603544527044509953</ListID>
							<TimeCreated>2009-07-04T12:13:46-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:02:55-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>AAJ</DepartmentCode>
							<DepartmentName>Apparel Accessories Jewelry</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8614604292084367617</ListID>
							<TimeCreated>2009-07-07T11:45:24-06:00</TimeCreated>
							<TimeModified>2011-11-12T20:50:25-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GAL</DepartmentCode>
							<DepartmentName>Gear Bath Linen</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8629230115512811777</ListID>
							<TimeCreated>2009-07-11T10:20:57-06:00</TimeCreated>
							<TimeModified>2009-07-11T10:20:57-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentName>Shipping</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8630191331181756673</ListID>
							<TimeCreated>2009-07-11T16:34:02-06:00</TimeCreated>
							<TimeModified>2011-11-14T21:37:28-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GBO</DepartmentCode>
							<DepartmentName>Gear Bags Other</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8655510217598861569</ListID>
							<TimeCreated>2009-07-18T12:19:01-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:05:29-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>GMR</DepartmentCode>
							<DepartmentName>Gear Mama Pregnancy</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8659420557386612993</ListID>
							<TimeCreated>2009-07-19T13:36:28-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:19:02-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>UUU</DepartmentCode>
							<DepartmentName>Used Used Used</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Non</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>8985854289813340417</ListID>
							<TimeCreated>2009-10-14T12:49:25-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:13:13-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>HFT</DepartmentCode>
							<DepartmentName>Homes Food Teas</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>
						<DepartmentRet>
							<ListID>9071052346519093505</ListID>
							<TimeCreated>2009-11-06T11:50:32-06:00</TimeCreated>
							<TimeModified>2011-11-12T21:11:27-06:00</TimeModified>
							<DefaultMarginPercent>0</DefaultMarginPercent>
							<DefaultMarkupPercent>0</DefaultMarkupPercent>
							<DepartmentCode>HDA</DepartmentCode>
							<DepartmentName>Home Decor Artwork</DepartmentName>
							<StoreExchangeStatus>Modified</StoreExchangeStatus>
							<TaxCode>Tax</TaxCode>
						</DepartmentRet>

					</DepartmentQueryRs>
				</QBPOSXMLMsgsRs>
			</QBPOSXML>";

		public static string InventoryResponse = @"<?xml version=""1.0"" encoding=""windows-1252""?>
<QBPOSXML>
    <QBPOSXMLMsgsRs>
        <ItemInventoryQueryRs retCount=""4"" statusCode=""0"" statusMessage=""Status OK"" statusSeverity=""Info"">
            <ItemInventoryRet>
                <ListID>-9219886962259885823</ListID>
                <TimeCreated>2009-12-17T11:32:31-06:00</TimeCreated>
                <TimeModified>2012-08-31T17:42:49-06:00</TimeModified>
                <ALU>2238-White</ALU>
                <Attribute>White</Attribute>
                <COGSAccount>Cost of Goods Sold</COGSAccount>
                <Cost>24.39</Cost>
                <DepartmentCode>GAT</DepartmentCode>
                <DepartmentListID>-6591161192474050303</DepartmentListID>
                <Desc1>Puj Tub</Desc1>
                <IncomeAccount>Merchandise Sales</IncomeAccount>
                <IsBelowReorder>False</IsBelowReorder>
                <IsEligibleForCommission>True</IsEligibleForCommission>
                <IsEligibleForRewards>True</IsEligibleForRewards>
                <IsPrintingTags>True</IsPrintingTags>
                <IsUnorderable>False</IsUnorderable>
                <IsWebItem>False</IsWebItem>
                <ItemNumber>3188</ItemNumber>
                <ItemType>Inventory</ItemType>
                <Keywords>Puj, Tub</Keywords>
                <LastReceived>2012-03-26</LastReceived>
                <MarginPercent>39</MarginPercent>
                <MarkupPercent>64</MarkupPercent>
                <MSRP>0.00</MSRP>
                <OnHandStore01>0.00</OnHandStore01>
                <OnHandStore02>4.00</OnHandStore02>
                <OrderCost>21.99</OrderCost>
                <Price1>39.99</Price1>
                <Price2>39.99</Price2>
                <Price3>39.99</Price3>
                <Price4>39.99</Price4>
                <Price5>39.99</Price5>
                <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
                <QuantityOnHand>4.00</QuantityOnHand>
                <QuantityOnOrder>0.00</QuantityOnOrder>
                <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
                <ReorderPoint>1.00</ReorderPoint>
                <ReorderPointStore01>0.00</ReorderPointStore01>
                <ReorderPointStore02>0.00</ReorderPointStore02>
                <SerialFlag>Optional</SerialFlag>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
                <UPC>0854702002004</UPC>
                <VendorListID>-9219888096139640575</VendorListID>
                <WebPrice>39.99</WebPrice>
                <Weight>0.00</Weight>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>1</StoreNumber>
                </AvailableQty>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>2</StoreNumber>
                </AvailableQty>
                <UnitOfMeasure1>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure1>
                <UnitOfMeasure2>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure2>
                <UnitOfMeasure3>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure3>
                <VendorInfo2>
    <OrderCost>0.00</OrderCost>
                </VendorInfo2>
                <VendorInfo3>
    <OrderCost>0.00</OrderCost>
                </VendorInfo3>
                <VendorInfo4>
    <OrderCost>0.00</OrderCost>
                </VendorInfo4>
                <VendorInfo5>
    <OrderCost>0.00</OrderCost>
                </VendorInfo5>
            </ItemInventoryRet>
            <ItemInventoryRet>
                <ListID>-8963436493188202239</ListID>
                <TimeCreated>2010-02-24T14:07:10-06:00</TimeCreated>
                <TimeModified>2012-08-20T20:25:24-06:00</TimeModified>
                <COGSAccount>Cost of Goods Sold</COGSAccount>
                <Cost>22.05</Cost>
                <DepartmentCode>GAT</DepartmentCode>
                <DepartmentListID>-6591161192474050303</DepartmentListID>
                <Desc1>Spa Baby Eco Tub</Desc1>
                <IncomeAccount>Merchandise Sales</IncomeAccount>
                <IsBelowReorder>False</IsBelowReorder>
                <IsEligibleForCommission>True</IsEligibleForCommission>
                <IsEligibleForRewards>True</IsEligibleForRewards>
                <IsPrintingTags>True</IsPrintingTags>
                <IsUnorderable>False</IsUnorderable>
                <IsWebItem>False</IsWebItem>
                <ItemNumber>3644</ItemNumber>
                <ItemType>Inventory</ItemType>
                <Keywords>Baby, Eco, Spa, Tub</Keywords>
                <LastReceived>2012-08-07</LastReceived>
                <MarginPercent>56</MarginPercent>
                <MarkupPercent>127</MarkupPercent>
                <MSRP>0.00</MSRP>
                <OnHandStore01>3.00</OnHandStore01>
                <OnHandStore02>6.00</OnHandStore02>
                <OrderCost>21.50</OrderCost>
                <Price1>49.99</Price1>
                <Price2>49.99</Price2>
                <Price3>49.99</Price3>
                <Price4>49.99</Price4>
                <Price5>49.99</Price5>
                <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
                <QuantityOnHand>9.00</QuantityOnHand>
                <QuantityOnOrder>0.00</QuantityOnOrder>
                <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
                <ReorderPoint>2.00</ReorderPoint>
                <ReorderPointStore01>0.00</ReorderPointStore01>
                <ReorderPointStore02>0.00</ReorderPointStore02>
                <SerialFlag>Optional</SerialFlag>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
                <UPC>0838521000021</UPC>
                <VendorListID>-8963441075960250111</VendorListID>
                <WebPrice>49.99</WebPrice>
                <Weight>0.00</Weight>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>1</StoreNumber>
                </AvailableQty>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>2</StoreNumber>
                </AvailableQty>
                <UnitOfMeasure1>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure1>
                <UnitOfMeasure2>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure2>
                <UnitOfMeasure3>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure3>
                <VendorInfo2>
    <OrderCost>0.00</OrderCost>
                </VendorInfo2>
                <VendorInfo3>
    <OrderCost>0.00</OrderCost>
                </VendorInfo3>
                <VendorInfo4>
    <OrderCost>0.00</OrderCost>
                </VendorInfo4>
                <VendorInfo5>
    <OrderCost>0.00</OrderCost>
                </VendorInfo5>
            </ItemInventoryRet>
            <ItemInventoryRet>
                <ListID>-6104968207158836991</ListID>
                <TimeCreated>2009-12-17T11:32:31-06:00</TimeCreated>
                <TimeModified>2012-08-28T12:42:43-06:00</TimeModified>
                <ALU>2238-Aqua</ALU>
                <Attribute>Aqua</Attribute>
                <COGSAccount>Cost of Goods Sold</COGSAccount>
                <Cost>24.44</Cost>
                <DepartmentCode>GAT</DepartmentCode>
                <DepartmentListID>-6591161192474050303</DepartmentListID>
                <Desc1>Puj Tub</Desc1>
                <IncomeAccount>Merchandise Sales</IncomeAccount>
                <IsBelowReorder>False</IsBelowReorder>
                <IsEligibleForCommission>True</IsEligibleForCommission>
                <IsEligibleForRewards>True</IsEligibleForRewards>
                <IsPrintingTags>True</IsPrintingTags>
                <IsUnorderable>False</IsUnorderable>
                <IsWebItem>False</IsWebItem>
                <ItemNumber>8178</ItemNumber>
                <ItemType>Inventory</ItemType>
                <Keywords>Puj, Tub</Keywords>
                <LastReceived>2012-03-26</LastReceived>
                <MarginPercent>39</MarginPercent>
                <MarkupPercent>64</MarkupPercent>
                <MSRP>0.00</MSRP>
                <OnHandStore01>4.00</OnHandStore01>
                <OnHandStore02>2.00</OnHandStore02>
                <OrderCost>24.00</OrderCost>
                <Price1>39.99</Price1>
                <Price2>39.99</Price2>
                <Price3>39.99</Price3>
                <Price4>39.99</Price4>
                <Price5>39.99</Price5>
                <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
                <QuantityOnHand>6.00</QuantityOnHand>
                <QuantityOnOrder>0.00</QuantityOnOrder>
                <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
                <ReorderPoint>1.00</ReorderPoint>
                <ReorderPointStore01>0.00</ReorderPointStore01>
                <ReorderPointStore02>0.00</ReorderPointStore02>
                <SerialFlag>Optional</SerialFlag>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
                <VendorListID>-9219888096139640575</VendorListID>
                <WebPrice>39.99</WebPrice>
                <Weight>0.00</Weight>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>1</StoreNumber>
                </AvailableQty>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>2</StoreNumber>
                </AvailableQty>
                <UnitOfMeasure1>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure1>
                <UnitOfMeasure2>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure2>
                <UnitOfMeasure3>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure3>
                <VendorInfo2>
    <OrderCost>0.00</OrderCost>
                </VendorInfo2>
                <VendorInfo3>
    <OrderCost>0.00</OrderCost>
                </VendorInfo3>
                <VendorInfo4>
    <OrderCost>0.00</OrderCost>
                </VendorInfo4>
                <VendorInfo5>
    <OrderCost>0.00</OrderCost>
                </VendorInfo5>
            </ItemInventoryRet>
            <ItemInventoryRet>
                <ListID>-6104968082588008191</ListID>
                <TimeCreated>2009-12-17T11:32:31-06:00</TimeCreated>
                <TimeModified>2012-08-28T12:42:54-06:00</TimeModified>
                <ALU>2238-Kiwi</ALU>
                <Attribute>Kiwi</Attribute>
                <COGSAccount>Cost of Goods Sold</COGSAccount>
                <Cost>24.39</Cost>
                <DepartmentCode>GAT</DepartmentCode>
                <DepartmentListID>-6591161192474050303</DepartmentListID>
                <Desc1>Puj Tub</Desc1>
                <IncomeAccount>Merchandise Sales</IncomeAccount>
                <IsBelowReorder>False</IsBelowReorder>
                <IsEligibleForCommission>True</IsEligibleForCommission>
                <IsEligibleForRewards>True</IsEligibleForRewards>
                <IsPrintingTags>True</IsPrintingTags>
                <IsUnorderable>False</IsUnorderable>
                <IsWebItem>False</IsWebItem>
                <ItemNumber>8179</ItemNumber>
                <ItemType>Inventory</ItemType>
                <Keywords>Puj, Tub</Keywords>
                <LastReceived>2012-03-26</LastReceived>
                <MarginPercent>39</MarginPercent>
                <MarkupPercent>64</MarkupPercent>
                <MSRP>0.00</MSRP>
                <OnHandStore01>4.00</OnHandStore01>
                <OnHandStore02>3.00</OnHandStore02>
                <OrderCost>21.99</OrderCost>
                <Price1>39.99</Price1>
                <Price2>39.99</Price2>
                <Price3>39.99</Price3>
                <Price4>39.99</Price4>
                <Price5>39.99</Price5>
                <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
                <QuantityOnHand>7.00</QuantityOnHand>
                <QuantityOnOrder>0.00</QuantityOnOrder>
                <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
                <ReorderPoint>1.00</ReorderPoint>
                <ReorderPointStore01>0.00</ReorderPointStore01>
                <ReorderPointStore02>0.00</ReorderPointStore02>
                <SerialFlag>Optional</SerialFlag>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
                <VendorListID>-9219888096139640575</VendorListID>
                <WebPrice>39.99</WebPrice>
                <Weight>0.00</Weight>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>1</StoreNumber>
                </AvailableQty>
                <AvailableQty>
    <QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>
    <QuantityOnOrder>0.00</QuantityOnOrder>
    <QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>
    <StoreNumber>2</StoreNumber>
                </AvailableQty>
                <UnitOfMeasure1>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure1>
                <UnitOfMeasure2>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure2>
                <UnitOfMeasure3>
    <MSRP>0.00</MSRP>
    <NumberOfBaseUnits>1.00</NumberOfBaseUnits>
    <Price1>0.00</Price1>
    <Price2>0.00</Price2>
    <Price3>0.00</Price3>
    <Price4>0.00</Price4>
    <Price5>0.00</Price5>
                </UnitOfMeasure3>
                <VendorInfo2>
    <OrderCost>0.00</OrderCost>
                </VendorInfo2>
                <VendorInfo3>
    <OrderCost>0.00</OrderCost>
                </VendorInfo3>
                <VendorInfo4>
    <OrderCost>0.00</OrderCost>
                </VendorInfo4>
                <VendorInfo5>
    <OrderCost>0.00</OrderCost>
                </VendorInfo5>
            </ItemInventoryRet>
        </ItemInventoryQueryRs>
    </QBPOSXMLMsgsRs>
</QBPOSXML>";

		public static string VoucherQueryResponse
		{
			get
			{
				string returnValue = "";

				FileStream stream = new FileStream("voucher.xml", FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader(stream);

				returnValue = sr.ReadToEnd();

				sr.Close();

				return returnValue;
			}
		}

		public static string SalesReceiptResponse
		{
			get
			{
				string returnValue = "";

				FileStream stream = new FileStream("salesreceipt.xml", FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader(stream);

				returnValue = sr.ReadToEnd();

				sr.Close();

				return returnValue;
			}
		}

		public static string TransferFromStoreResponse
		{
			get
			{
				string returnValue = "";

				FileStream stream = new FileStream("transferfromstore.xml", FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader(stream);

				returnValue = sr.ReadToEnd();

				sr.Close();

				return returnValue;
			}
		}

        public static string ReceiptRequestResponseRanged
        {
            get
            {
                string returnValue = "";

                FileStream stream = new FileStream("ReceiptRequestResponse.xml", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(stream);

                returnValue = sr.ReadToEnd();

                sr.Close();

                return returnValue;
            }
        }

        public static string TimeEntryResponseRanged
        {
            get
            {
                string returnValue = "";

                FileStream stream = new FileStream("TimeEntryQueryResponse.xml", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(stream);

                returnValue = sr.ReadToEnd();

                sr.Close();

                return returnValue;
            }
        }
	}
}

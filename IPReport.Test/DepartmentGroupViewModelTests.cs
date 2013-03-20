using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.ViewModel;
using IPReport.Model;
using IPReport.DataAccess;

namespace IPReport.Test
{
	[TestFixture]
	public class DepartmentGroupViewModelTests
	{
		[Test]
		public void TestGroups()
		{
			DepartmentGroup dg = DepartmentGroupsRepository.Instance.Groups[1];

			DepartmentGroupViewModel vm = DepartmentGroupViewModel.GetInstance(dg);

			DepartmentViewModel aah = new DepartmentViewModel(1);
			aah.Code = "AAH";
			DepartmentViewModel acs = new DepartmentViewModel(1);
			acs.Code = "ACS";
			DepartmentViewModel aat = new DepartmentViewModel(1);
			aat.Code = "AAT";
			DepartmentViewModel aas = new DepartmentViewModel(1);
			aas.Code = "AAS";
			DepartmentViewModel aaj = new DepartmentViewModel(1);
			aaj.Code = "AAJ";
			DepartmentViewModel wtf = new DepartmentViewModel(1);
			wtf.Code = "WTF";


			vm.TryAddDepartment(aah);
			vm.TryAddDepartment(acs);
			vm.TryAddDepartment(aat);
			vm.TryAddDepartment(aas);
			vm.TryAddDepartment(aaj);
			vm.TryAddDepartment(wtf);

			Assert.AreEqual(5, vm.Departments.Count);
		}
	}
}

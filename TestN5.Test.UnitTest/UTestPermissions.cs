using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestN5.Core.Entities;
using TestN5.Core.Interfaces;
using TestN5.Data.Dto;

namespace TestN5.Test.UnitTest
{
    [TestClass]
    public class UTestPermissions
    {
        private readonly IServicePermissions _iServicePermissions;

        public UTestPermissions(IServicePermissions iServicePermissions)
        {
            _iServicePermissions = iServicePermissions;
        }

        [TestMethod]
        public async Task TestSavePermissions()
        {

            DtoPermissions obj = new DtoPermissions();
            obj.PermissionDate = DateTime.Now;
            obj.PermissionType = 1;
            obj.EmployeeSurname = "Perez";
            obj.EmployeeForname = "Pepito";

            Permissions objPermissions = new Permissions
            {
                EmployeeForname = obj.EmployeeForname,
                EmployeeSurname = obj.EmployeeSurname,
                PermissionType = obj.PermissionType,
                PermissionDate = obj.PermissionDate
            };

            bool response = _iServicePermissions.RequestPermission(objPermissions);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public async Task TestGetPermissions()
        {

            List<Permissions> ltPermissions = _iServicePermissions.GetPermissions();

            Assert.IsNotNull(ltPermissions);
        }

        [TestMethod]
        public async Task TestUpdatePermissions()
        {

            DtoPermissions obj = new DtoPermissions();
            obj.PermissionDate = DateTime.Now;
            obj.PermissionType = 1;
            obj.EmployeeSurname = "Perez";
            obj.EmployeeForname = "Pepito";
            obj.Id = 1;

            Permissions objPermissions = new Permissions
            {
                EmployeeForname = obj.EmployeeForname,
                EmployeeSurname = obj.EmployeeSurname,
                PermissionType = obj.PermissionType,
                PermissionDate = obj.PermissionDate,
                Id = obj.Id
            };

            bool response = _iServicePermissions.ModifyPermission(objPermissions);

            Assert.IsTrue(response);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using TestN5.Core.Entities;
using TestN5.Core.Interfaces;
using TestN5.Data.Data;

namespace TestN5.Data.Repositories
{
    public class PermissionsRepository : IPermissions
    {
        private readonly TestN5Context _testN5Context;

        public PermissionsRepository(TestN5Context testN5Context)
        {
            _testN5Context = testN5Context;
        }

        public List<Permissions> GetPermissions()
        {
            List<Permissions> ltPermissions = _testN5Context.Permissions.ToList();

            return ltPermissions;
        }

        public Permissions GetPermissionsById(int Id)
        {
            Permissions objPermissions = _testN5Context.Permissions.Where(x => x.Id == Id).FirstOrDefault();
            return objPermissions;
        }

        public bool ModifyPermission(Permissions obj)
        {
            var objPermissions = _testN5Context.Permissions.Where(x => x.Id == obj.Id).FirstOrDefault();

            if (objPermissions != null)
            {
                objPermissions.PermissionDate = obj.PermissionDate;
                objPermissions.PermissionType = obj.PermissionType;
                objPermissions.EmployeeForname = obj.EmployeeForname;
                objPermissions.EmployeeSurname = obj.EmployeeSurname;
                ;

                int rowAfectted = _testN5Context.SaveChanges();

                if (rowAfectted > 0) return true;
                else return false;
            }
            else
                return false;
        }

        public bool RequestPermission(Permissions obj)
        {
            _testN5Context.Add(obj);
            _testN5Context.SaveChanges();

            int NewId = obj.Id;

            if (NewId > 0) return true;
            else return false;

        }
    }
}

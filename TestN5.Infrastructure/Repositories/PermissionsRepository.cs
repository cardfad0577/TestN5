using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using TestN5.Core.Entities;
using TestN5.Core.Interface;
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
    }
}

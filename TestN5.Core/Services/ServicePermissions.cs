using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestN5.Core.Entities;
using TestN5.Core.Exceptions;
using TestN5.Core.Interfaces;

namespace TestN5.Core.Services
{
    public class ServicePermissions : IServicePermissions
    {
        private readonly IPermissions _iPermissions;
        public ServicePermissions(IPermissions iPermissions)
        {
            _iPermissions = iPermissions;
        }

        public List<Permissions> GetPermissions()
        {
            List<Permissions> response = _iPermissions.GetPermissions();
            return response;
        }

        public bool ModifyPermission(Permissions obj)
        {

            Permissions objPermissions = _iPermissions.GetPermissionsById(obj.Id);
            if (objPermissions == null)
                throw new BusinessException("El permiso no existe");

            bool response = _iPermissions.ModifyPermission(obj);
            return response;
        }

        public bool RequestPermission(Permissions obj)
        {
            bool response = _iPermissions.RequestPermission(obj);
            return response;
        }

    }
}

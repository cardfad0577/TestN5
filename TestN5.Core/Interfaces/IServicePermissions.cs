using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestN5.Core.Entities;

namespace TestN5.Core.Interfaces
{
    public interface IServicePermissions
    {

        List<Permissions> GetPermissions();
        bool RequestPermission(Permissions obj);
        bool ModifyPermission(Permissions obj);
    }

}

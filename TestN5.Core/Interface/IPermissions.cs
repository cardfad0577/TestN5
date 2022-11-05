using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestN5.Core.Entities;

namespace TestN5.Core.Interface
{
    public interface IPermissions
    {
        List<Permissions> GetPermissions();
    }
}

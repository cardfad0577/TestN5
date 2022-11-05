using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestN5.Core.Entities;
using TestN5.Core.Interface;
using TestN5.Data.Repositories;

namespace TestN5.API.Controllers
{
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissions _iPermissions;

        public PermissionsController(IPermissions iPermissions)
        {
            _iPermissions = iPermissions;
        }

        [Route("GetPermissions")]
        [HttpGet]
        public IActionResult GetPermissions()
        {
            List<Permissions> ltPermissions = _iPermissions.GetPermissions();
            return Ok(ltPermissions);
        }

    }
}

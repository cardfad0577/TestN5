using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestN5.Core.Entities;
using TestN5.Core.Interface;
using TestN5.Data.Dto;
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
            List<DtoPermissions> ltDtoPermissions = ltPermissions.Select(x => new DtoPermissions
            {
                Id = x.Id,
                EmployeeForname = x.EmployeeForname,
                EmployeeSurname = x.EmployeeSurname,
                PermissionType = x.PermissionType,
                PermissionDate = x.PermissionDate
            }).ToList();

            return Ok(ltDtoPermissions);
        }

        [Route("RequestPermission")]
        [HttpPost]
        public IActionResult RequestPermission(DtoPermissions obj)
        {
            if (!ModelState.IsValid) return BadRequest();

            Permissions objPermissions = new Permissions
            {
                EmployeeForname = obj.EmployeeForname,
                EmployeeSurname = obj.EmployeeSurname,
                PermissionType = obj.PermissionType,
                PermissionDate = obj.PermissionDate
            };

            bool response = _iPermissions.RequestPermission(objPermissions);
            if (response) return Ok("Se registro correctamente");
            else return Ok("x");
        }

        [Route("ModifyPermission")]
        [HttpPatch]
        public IActionResult ModifyPermission()
        {
            List<Permissions> ltPermissions = _iPermissions.GetPermissions();
            return Ok(ltPermissions);
        }

    }
}

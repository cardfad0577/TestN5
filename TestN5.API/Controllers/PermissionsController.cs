using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestN5.Core.Entities;
using TestN5.Core.Exceptions;
using TestN5.Core.Interfaces;
using TestN5.Data.Dto;
using TestN5.Data.Repositories;

namespace TestN5.API.Controllers
{
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IServicePermissions _iServicePermissions;
        private readonly ILogger<PermissionsController> _logger;
        DateTime thisDay = DateTime.Today;

        public PermissionsController(IServicePermissions iServicePermissions, ILogger<PermissionsController> logger)
        {
            _iServicePermissions = iServicePermissions;
            _logger = logger;
        }

        [Route("GetPermissions")]
        [HttpGet]
        public IActionResult GetPermissions()
        {
            _logger.LogInformation("Request svc GetPermissions date " + thisDay.ToString());

            List<Permissions> ltPermissions = _iServicePermissions.GetPermissions();
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
            _logger.LogInformation("Request svc RequestPermission date " + thisDay.ToString());

            if (!ModelState.IsValid) return BadRequest();

            Permissions objPermissions = new Permissions
            {
                EmployeeForname = obj.EmployeeForname,
                EmployeeSurname = obj.EmployeeSurname,
                PermissionType = obj.PermissionType,
                PermissionDate = obj.PermissionDate
            };

            bool response = _iServicePermissions.RequestPermission(objPermissions);
            if (response) return Ok("Se registro correctamente");
            else return Ok("No se registro, intente nuevamente");
        }

        [Route("ModifyPermission")]
        [HttpPut]
        public IActionResult ModifyPermission(DtoPermissions obj)
        {
            _logger.LogInformation("Request svc ModifyPermission date " + thisDay.ToString());
            if (!ModelState.IsValid) return BadRequest();

            Permissions objPermissions = new Permissions
            {
                Id = obj.Id,
                EmployeeForname = obj.EmployeeForname,
                EmployeeSurname = obj.EmployeeSurname,
                PermissionType = obj.PermissionType,
                PermissionDate = obj.PermissionDate
            };

            bool response = _iServicePermissions.ModifyPermission(objPermissions);
            if (response) return Ok("Se actualizo correctamente");
            else throw new BusinessException("No se actualizo, intente nuevamente");
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestN5.Data.Dto
{
    public class DtoPermissions
    {
        private int id;
        private string employeeForname;
        private string employeeSurname;
        private int permissionType;
        private DateTime permissionDate;

        [Required]
        public string EmployeeForname { get => employeeForname; set => employeeForname = value; }
        [Required]
        public int PermissionType { get => permissionType; set => permissionType = value; }
        [Required]
        public DateTime PermissionDate { get => permissionDate; set => permissionDate = value; }
        [Required]
        public string EmployeeSurname { get => employeeSurname; set => employeeSurname = value; }
        public int Id { get => id; set => id = value; }
    }
}

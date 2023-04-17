
namespace TestN5.Core.Entities
{
    public class Permissions
    {
        public int Id { get; set; }
        public string EmployeeForname { get; set; } = null!;
        public string EmployeeSurname { get; set; } = null!;
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }

        public virtual PermissionType PermissionTypeDescription { get; set; } = null!;

    }
}


namespace TestN5.Core.Entities
{
    public class PermissionType
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permissions>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}


namespace DadayaAPI.Data
{
    using Microsoft.AspNetCore.Identity;

    public class PermissionsInRole
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public string IdentityRoleId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }
    }
}

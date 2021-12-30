//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.Account
{
    partial class IdentityXRole
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public SnQPoolIot.Logic.Entities.Persistence.Account.Identity Identity
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("RoleId")]
        public SnQPoolIot.Logic.Entities.Persistence.Account.Role Role
        {
            get;
            set;
        }
    }
}

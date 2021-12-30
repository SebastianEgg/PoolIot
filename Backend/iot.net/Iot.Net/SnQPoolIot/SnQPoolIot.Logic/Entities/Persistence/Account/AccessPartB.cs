//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.Account
{
    partial class Access
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public SnQPoolIot.Logic.Entities.Persistence.Account.Identity Identity
        {
            get;
            set;
        }
    }
}

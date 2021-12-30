//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.Account
{
    partial class User
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public SnQPoolIot.Logic.Entities.Persistence.Account.Identity Identity
        {
            get;
            set;
        }
    }
}

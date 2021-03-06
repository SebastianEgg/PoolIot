//@CodeCopy
//MdStart
#if ACCOUNT_ON
using CommonBase.Attributes;

namespace SnQPoolIot.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IIdentityXRole : IVersionable, ICopyable<IIdentityXRole>
    {
        int IdentityId { get; set; }
        int RoleId { get; set; }
    }
}
#endif
//MdEnd

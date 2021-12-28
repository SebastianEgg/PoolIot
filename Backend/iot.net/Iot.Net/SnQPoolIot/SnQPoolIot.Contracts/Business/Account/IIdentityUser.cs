//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQPoolIot.Contracts.Persistence.Account;

namespace SnQPoolIot.Contracts.Business.Account
{
    public partial interface IIdentityUser : IOneToAnother<IIdentity, IUser>, ICopyable<IIdentityUser>
    {
    }
}
#endif
//MdEnd

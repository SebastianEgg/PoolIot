//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQPoolIot.Contracts.Persistence.Account;

namespace SnQPoolIot.Contracts.Business.Account
{
    public partial interface IAppAccess : IOneToMany<IIdentity, IRole>, ICopyable<IAppAccess>
    {

    }
}
#endif
//MdEnd

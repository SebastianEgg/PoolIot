//@CodeCopy
//MdStart
#if ACCOUNT_ON
using CommonBase.Attributes;
using System;

namespace SnQPoolIot.Contracts.Persistence.Account
{
    [ContractInfo]
    public partial interface IActionLog : IVersionable, ICopyable<IActionLog>
    {
        int IdentityId { get; set; }
        DateTime Time { get; set; }
        string Subject { get; set; }
        string Action { get; set; }
        string Info { get; set; }
    }
}
#endif
//MdEnd

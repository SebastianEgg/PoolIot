//@CodeCopy
//MdStart
#if ACCOUNT_ON
using CommonBase.Attributes;

namespace SnQPoolIot.Contracts.Persistence.Account
{
    [ContractInfo]
    public interface IAccess : IIdentifiable, ICopyable<IAccess>
    {
        int IdentityId { get; set; }
        [ContractPropertyInfo(Required = true, HasIndex = true, IsUnique = true, MaxLength = 512)]
        string Key { get; set; }
        [ContractPropertyInfo(MaxLength = 4096, DefaultValue = "string.Empty")]
        string Value { get; set; }
    }
}
#endif
//MdEnd

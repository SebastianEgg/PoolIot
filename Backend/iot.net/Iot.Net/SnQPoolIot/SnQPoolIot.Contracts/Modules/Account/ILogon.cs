﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace SnQPoolIot.Contracts.Modules.Account
{
    public partial interface ILogon
    {
        string Email { get; set; }
        string Password { get; set; }
        string OptionalInfo { get; set; }
    }
}
#endif
//MdEnd

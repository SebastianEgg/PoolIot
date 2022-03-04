using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBase.Attributes;

namespace SnQPoolIot.Contracts.Persistence.PoolIot
{
    public interface ISensor: IVersionable,ICopyable<ISensor>
    {
        [ContractPropertyInfo(IsUnique = true, MaxLength = 128)]
        string Name { get; set; }
    }
}

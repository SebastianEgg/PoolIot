using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBase.Attributes;

namespace SnQPoolIot.Contracts.Persistence.PoolIot
{
    public interface ISensorList: IVersionable,ICopyable<ISensorList>
    {
        [ContractPropertyInfo(IsUnique = true, MaxLength = 128)]
        string Name { get; set; }
    }
}

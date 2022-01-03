using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBase.Attributes;

namespace SnQPoolIot.Contracts.Persistence.PoolIot
{
    public interface ISensorData: IVersionable,ICopyable<ISensorData>
    {
        [ContractPropertyInfo(Required = true, IsUnique = false, MaxLength = 256)]
        string Value { get; set; }

        int SensorListId { get; set; }

        [ContractPropertyInfo(Required = true, IsUnique = false)]
        string Timestamp { get; set; }

    }
}

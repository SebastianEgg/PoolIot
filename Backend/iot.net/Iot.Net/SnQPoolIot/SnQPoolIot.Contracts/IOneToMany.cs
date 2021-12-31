//@CodeCopy
//MdStart
using System.Collections.Generic;

namespace SnQPoolIot.Contracts
{
    public partial interface IOneToMany<TOne, TMany> : IIdentifiable
        where TOne : IIdentifiable
        where TMany : IIdentifiable
    {
        TOne OneItem { get; }
        IEnumerable<TMany> ManyItems { get; }

        void ClearManyItems();
        TMany CreateManyItem();
        void AddManyItem(TMany manyItem);
        void RemoveManyItem(TMany manyItem);
    }
}
//MdEnd

//@CodeCopy
//MdStart
using SnQPoolIot.Contracts;

namespace SnQPoolIot.Logic.Entities
{
    internal abstract partial class IdentityEntity : EntityObject, IIdentifiable
	{
		public virtual int Id { get; set; }
    }
}
//MdEnd

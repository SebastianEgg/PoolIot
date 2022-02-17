//MdStart
using SnQPoolIot.Contracts;

namespace SnQPoolIot.Logic.Entities
{
    public abstract partial class IdentityEntity : EntityObject, IIdentifiable
	{
		public virtual int Id { get; set; }
    }
}
//MdEnd

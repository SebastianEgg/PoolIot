//@CodeCopy

using SnQPoolIot.Contracts;

namespace SnQPoolIot.Logic.Entities
{
	internal abstract partial class VersionEntity : IdentityEntity, IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}

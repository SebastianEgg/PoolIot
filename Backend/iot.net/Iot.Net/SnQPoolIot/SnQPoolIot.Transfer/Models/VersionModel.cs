//@CodeCopy

namespace SnQPoolIot.Transfer.Models
{
    public partial class VersionModel : IdentityModel, Contracts.IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}

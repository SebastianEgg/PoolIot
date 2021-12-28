//@CodeCopy
//MdStart
namespace SnQPoolIot.AspMvc.Models
{
    public class VersionModel : IdentityModel, Contracts.IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}
//MdEnd

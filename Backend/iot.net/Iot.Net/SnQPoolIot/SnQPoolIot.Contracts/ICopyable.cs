//@CodeCopy

namespace SnQPoolIot.Contracts
{
	public partial interface ICopyable<T>
	{
		void CopyProperties(T other);
	}
}

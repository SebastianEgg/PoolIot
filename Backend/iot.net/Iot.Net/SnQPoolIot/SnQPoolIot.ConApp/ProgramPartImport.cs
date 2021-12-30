using System.Threading.Tasks;

namespace SnQPoolIot.ConApp
{
    internal partial class Program
    {
        private static Task ImportDataAsync()
        {
            return Task.Delay(2000);
        }
    }
}

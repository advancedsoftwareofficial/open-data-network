using System.Threading.Tasks;
using ODN.Package.Entity;

namespace ODN.Package.Definitions
{
    public interface IDataPoolStorageService
    {
        Task<DataPoolStorage> Add(DataPoolStorage item);
    }
}
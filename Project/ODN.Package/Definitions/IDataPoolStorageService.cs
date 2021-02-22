using System.Threading.Tasks;
using ODN.Package.Entity;

namespace ODN.Package.Definitions
{
    public interface IDataPoolStorageService
    {
        Task<DataPoolStorage> Add(DataPoolStorage item);
        Task<bool> Delete(int rowId);
        Task<T> OdataQuery<T>(string query);
        Task<DataPoolStorage> Update(DataPoolStorage item);
    }
}
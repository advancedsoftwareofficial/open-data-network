using System.Threading.Tasks;

namespace ODN.Package.Definitions
{
    public interface IBaseODNService<T>
    {
        Task<T> Add(T item);
        Task<TResult> OdataQuery<TResult>(string query);
        Task<bool> Delete(int rowId);
        Task<T> Update(T item);
    }
}
using SupplierManagementApi.Models;

namespace SupplierManagementApi.Data.Stores.Suppliers
{
    public interface ISupplierStore
    {
        Task<Database.Tables.Supplier> Add(Database.Tables.Supplier model, CancellationToken cancellationToken);
        Task<int> GenberateNewCode(CancellationToken cancellationToken);
        Task<List<Database.Tables.Supplier>> Get(Query query, CancellationToken cancellationToken);
    }
}
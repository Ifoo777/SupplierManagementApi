using Microsoft.EntityFrameworkCore;
using SupplierManagementApi.Database;
using SupplierManagementApi.Database.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Data.Stores.Suppliers
{
    public class SupplierStore : ISupplierStore
    {
        private readonly DBContext context;

        public SupplierStore(DBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Using the generic query a filter and skip specified records and take a cerain amount of records.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Supplier>> Get(Models.Query query, CancellationToken cancellationToken) => await
            context.Suppliers.Where(c => string.IsNullOrWhiteSpace(query.Filter) || c.Name.Trim().ToLower().Contains(query.Filter.Trim().ToLower()))
            .Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken) ?? new List<Supplier>();

        public async Task<Supplier> Add(Supplier model, CancellationToken cancellationToken)
        {
            await context.Suppliers.AddAsync(model, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return model;
        }

        public async Task<int> GenberateNewCode(CancellationToken cancellationToken)
        {
            var lastSupplierCode = await context.Suppliers.OrderByDescending(c => c.Code).FirstAsync(cancellationToken);
            var currentCodeInt = int.Parse(lastSupplierCode.Code, CultureInfo.InvariantCulture);
            return currentCodeInt++;
        }

    }
}

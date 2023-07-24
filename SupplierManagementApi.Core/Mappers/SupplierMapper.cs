
using SupplierManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Mappers
{
    internal static class SupplierMapper
    {
        internal static List<Supplier> Map(this List<Database.Tables.Supplier> models) => models == default ? new List<Supplier>() : models.Select(c => c.Map()).ToList();
        internal static Supplier Map(this Database.Tables.Supplier model) => model == default ? new Supplier() : new Supplier()
        {
            Name = model.Name ?? "",
            TelephoneNumber = model.TelephoneNumber ?? ""
        };

        internal static Database.Tables.Supplier Map(this Supplier model, int code) => model == default ? new Database.Tables.Supplier() : new Database.Tables.Supplier()
        {
            Name = model.Name ?? "",
            TelephoneNumber = model.TelephoneNumber ?? "",
            Code = code.ToString()
        };
    }
}

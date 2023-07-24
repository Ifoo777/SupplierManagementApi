using SupplierManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Requests
{
    public class GetSupplierResponse : BaseResponse
    {
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}

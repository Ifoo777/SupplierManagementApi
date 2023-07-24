using MediatR;
using SupplierManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Requests
{
    public class AddSupplierRequest : IRequest<AddSupplierResponse>
    {
        public Supplier Supplier { get; set; } = new Supplier();
    }
}

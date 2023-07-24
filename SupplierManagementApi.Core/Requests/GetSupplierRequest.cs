using MediatR;
using SupplierManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Requests
{
    public class GetSupplierRequest : IRequest<GetSupplierResponse>
    {
        public Query Query { get; set; } = new Query();
    }
}

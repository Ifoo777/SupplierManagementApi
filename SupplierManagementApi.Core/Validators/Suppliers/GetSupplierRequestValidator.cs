using FluentValidation;
using SupplierManagementApi.Core.Requests;
using SupplierManagementApi.Core.Validators.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Validators.Suppliers
{
    public class GetSupplierRequestValidator : AbstractValidator<GetSupplierRequest>
    {
        public GetSupplierRequestValidator()
        {
            RuleFor(c => c.Query).SetValidator(new QueryValidator());
        }
    }
}

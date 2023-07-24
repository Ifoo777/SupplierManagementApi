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
    public class AddSupplierRequestValidator : AbstractValidator<AddSupplierRequest>
    {
        public AddSupplierRequestValidator()
        {
            RuleFor(c => c.Supplier).SetValidator(new AddSupplierValidator());
        }
    }
}

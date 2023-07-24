using FluentValidation;
using SupplierManagementApi.Core.Requests;
using SupplierManagementApi.Core.Validators.Queries;
using SupplierManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Validators.Suppliers
{
    public class AddSupplierValidator : AbstractValidator<Supplier>
    {
        public AddSupplierValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.TelephoneNumber).NotEmpty();
        }
    }
}

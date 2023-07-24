using FluentValidation;
using SupplierManagementApi.Core.Requests;
using SupplierManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Validators.Queries
{
    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator()
        {
            RuleFor(c => c.Skip).GreaterThan(-1);
            RuleFor(c => c.Take).GreaterThan(0);
        }
    }
}

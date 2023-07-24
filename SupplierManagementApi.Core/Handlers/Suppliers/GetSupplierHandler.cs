using Azure;
using MediatR;
using Microsoft.Extensions.Logging;
using SupplierManagementApi.Core.Mappers;
using SupplierManagementApi.Core.Requests;
using SupplierManagementApi.Core.Validators.Suppliers;
using SupplierManagementApi.Data.Stores.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Handlers.Suppliers
{
    public class GetSupplierHandler : IRequestHandler<GetSupplierRequest, GetSupplierResponse>
    {
        private readonly ISupplierStore supplierStore;
        private readonly ILogger<GetSupplierHandler> logger;

        public GetSupplierHandler(ISupplierStore supplierStore, ILogger<GetSupplierHandler> logger)
        {
            this.supplierStore = supplierStore;
            this.logger = logger;
        }

        async Task<GetSupplierResponse> IRequestHandler<GetSupplierRequest, GetSupplierResponse>.Handle(GetSupplierRequest request, CancellationToken cancellationToken)
        {
            GetSupplierResponse response = new();

            try
            {
                var validator = new GetSupplierRequestValidator();
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    response.Errors.AddRange(validationResult.Errors.Select(c => c.ErrorMessage));
                    response.Message = "Operation failed validation.";
                    response.StatusCode = Enums.StatusCode.ValidationsFailure;
                    return response;
                }

                var result = await supplierStore.Get(request.Query, cancellationToken);
                response.Suppliers = result.Map();

                response.Message = "Operation completed successfuly.";
                response.StatusCode = Enums.StatusCode.Success;
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                response.Message = "Operation completed with an error.";
                response.StatusCode = Enums.StatusCode.Error;
                return response;
            }
        }
    }
}

using Azure;
using FluentValidation;
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
    public class AddSupplierHandler : IRequestHandler<AddSupplierRequest, AddSupplierResponse>
    {
        private readonly ISupplierStore supplierStore;
        private readonly ILogger<GetSupplierHandler> logger;

        public AddSupplierHandler(ISupplierStore supplierStore, ILogger<GetSupplierHandler> logger)
        {
            this.supplierStore = supplierStore;
            this.logger = logger;
        }

        public async Task<AddSupplierResponse> Handle(AddSupplierRequest request, CancellationToken cancellationToken)
        {
            AddSupplierResponse response = new();

            try
            {
                var validator = new AddSupplierRequestValidator();
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    response.Errors.AddRange(validationResult.Errors.Select(c => c.ErrorMessage));
                    response.Message = "Operation failed validation.";
                    response.StatusCode = Enums.StatusCode.ValidationsFailure;
                    return response;
                }

                var codeNew = await supplierStore.GenberateNewCode(cancellationToken);
                var supplierMapped = request.Supplier.Map(codeNew);
                var result = await supplierStore.Add(supplierMapped, cancellationToken);
                if (result.Id == default)
                {
                    response.Message = "Operation completed with an error : Failed to add supplier.";
                    response.StatusCode = Enums.StatusCode.Error;
                    return response;
                }

                response.Success = true;
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

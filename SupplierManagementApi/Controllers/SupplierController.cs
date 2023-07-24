using MediatR;
using Microsoft.AspNetCore.Mvc;
using SupplierManagementApi.Core.Requests;
using SupplierManagementApi.Models;

namespace SupplierManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator mediator;

        public SupplierController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{skip:int}/{take:int}")]
        public async Task<GetSupplierResponse> Get([FromRoute]int skip, [FromRoute]int take, [FromQuery]string? filter)
        {
            GetSupplierRequest request = new()
            {
                Query = new Models.Query()
                {
                    Filter = filter,
                    Skip = skip,
                    Take = take
                }
            };

            return await mediator.Send(request);
        }

        [HttpPost]
        public async Task<AddSupplierResponse> Add([FromBody] Supplier model)
        {
            AddSupplierRequest request = new()
            { 
                Supplier = model
            };

            return await mediator.Send(request);
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplierManagementApi.Data.Stores.Suppliers;
using SupplierManagementApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Core.Extensions
{
    public static class SupplierManagementApiExtensions
    {
        public static WebApplicationBuilder AddSupplierManagementApiExtensions(this WebApplicationBuilder webApplicationBuilder)
        {
            //connection to DB
            webApplicationBuilder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection")));

            webApplicationBuilder.Services.AddScoped<ISupplierStore, SupplierStore>();

            webApplicationBuilder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return webApplicationBuilder;
        }
    }
}

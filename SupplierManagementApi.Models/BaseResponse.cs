using SupplierManagementApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Models
{
    public class BaseResponse
    {
        public string Message { get; set; } = "";
        public List<string> Errors { get; set; } = new List<string>();
        public StatusCode StatusCode { get; set; } = StatusCode.Error;
    }
}

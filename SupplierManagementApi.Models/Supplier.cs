using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementApi.Models
{
    public class Supplier
    {
        public string Name { get; set; } = "";
        public string TelephoneNumber { get; set; } = "";
    }
}

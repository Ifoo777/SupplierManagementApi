namespace SupplierManagementApi.Models
{
    public class Query
    {
        public string? Filter { get; set; }
        public int Take { get; set; } = 100;
        public int Skip { get; set; } = 0;
    }
}
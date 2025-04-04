namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public List<GetSaleItemResponse> Items { get; set; } = new();
    }
}

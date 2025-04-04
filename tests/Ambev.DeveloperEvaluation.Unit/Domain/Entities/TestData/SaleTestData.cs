using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleTestData
    {
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(s => s.SaleDate, f => f.Date.Past(1))
            .RuleFor(s => s.TotalAmount, f => f.Finance.Amount(1, 1000))
            .RuleFor(s => s.BranchId, f => Guid.NewGuid())
            .RuleFor(s => s.Status, f => f.PickRandom(SaleStatus.Active, SaleStatus.Unknown))
            .RuleFor(s => s.SaleItems, f => new List<SaleItem>
            {
                SaleItemTestData.GenerateValidSaleItem()
            });

        public static Sale GenerateValidSale()
        {
            return SaleFaker.Generate();
        }

        


    }
}

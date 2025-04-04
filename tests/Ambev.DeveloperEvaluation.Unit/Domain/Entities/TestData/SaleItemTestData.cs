using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleItemTestData
    {
        private static readonly Faker<SaleItem> _faker = new Faker<SaleItem>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.SaleId, f => Guid.NewGuid())
            .RuleFor(s => s.ProductId, f => Guid.NewGuid())
            .RuleFor(s => s.Quantity, f => f.Random.Int(1, 100))
            .RuleFor(s => s.UnitPrice, f => f.Random.Decimal(1.0m, 1000.0m))
            .RuleFor(s => s.Discount, f => f.Random.Decimal(0.0m, 100.0m));

        public static SaleItem GenerateValidSaleItem()
        {
            return _faker.Generate();
        }


    }
}

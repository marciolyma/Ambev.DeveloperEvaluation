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
            .RuleFor(s => s.Quantity, f => 5)
            .RuleFor(s => s.UnitPrice, f => f.Random.Decimal(1.0m, 1000.0m))
            .RuleFor(s => s.Discount, f => f.Random.Decimal(0.0m, 1000.0m))
            .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(1.0m, 1000.0m))
            .RuleFor(s => s.Sale, f => new Sale())
            .RuleFor(s => s.Product, f => new Product());


        public static SaleItem GenerateValidSaleItem()
        {
            return _faker.Generate();
        }

        public static SaleItem GenerateSaleItemWithInvalidQuantity()
        {
            return _faker
                .RuleFor(s => s.Quantity, f => f.Random.Int(-100, -1))
                .Generate();
        }

        public static SaleItem GenerateSaleItemWithInvalidUnitPrice()
        {
            return _faker
                .RuleFor(s => s.UnitPrice, f => f.Random.Decimal(-1000, -1))
                .Generate();
        }

        public static SaleItem GenerateSaleItemWithInvalidDiscount()
        {
            return _faker
                .RuleFor(s => s.Discount, f => f.Random.Decimal(-1000, -1))
                .Generate();
        }

        public static SaleItem GenerateSaleItemWithInvalidTotalAmount()
        {
            return _faker
                .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(-1000, -1))
                .Generate();
        }

        public static SaleItem GenerateSaleItemWithInvalidProductId()
        {
            return _faker
                .RuleFor(s => s.ProductId, f => Guid.Empty)
                .Generate();
        }

        public static SaleItem GenerateSaleItemWithInvalidSaleId()
        {
            return _faker
                .RuleFor(s => s.SaleId, f => Guid.Empty)
                .Generate();
        }
    }
}

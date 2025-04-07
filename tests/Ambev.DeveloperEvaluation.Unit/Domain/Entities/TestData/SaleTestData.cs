using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleTestData
    {
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(s => s.SaleDate, f => f.Date.Past(1))
            .RuleFor(s => s.SaleNumber, f => f.Random.String2(10))
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

        public static Sale GenerateValidSaleWithItems(int itemCount)
        {
            return SaleFaker
                .RuleFor(s => s.SaleItems, f => f.Make(itemCount, () => SaleItemTestData.GenerateValidSaleItem()))
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidDate()
        {
            return SaleFaker
                .RuleFor(s => s.SaleDate, f => f.Date.Future())
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidTotalAmount()
        {
            return SaleFaker
                .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(-1000, -1))
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidBranchId()
        {
            return SaleFaker
                .RuleFor(s => s.BranchId, f => Guid.Empty)
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidStatus()
        {
            return SaleFaker
                .RuleFor(s => s.Status, f => (SaleStatus)f.Random.Int(100, 200))
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidSaleNumber()
        {
            return SaleFaker
                .RuleFor(s => s.SaleNumber, f => f.Random.String2(101))
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidSaleItems()
        {
            return SaleFaker
                .RuleFor(s => s.SaleItems, f => new List<SaleItem>
                {
                    SaleItemTestData.GenerateValidSaleItem()
                })
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidSaleItemCount(int itemCount)
        {
            return SaleFaker
                .RuleFor(s => s.SaleItems, f => f.Make(itemCount, () => SaleItemTestData.GenerateValidSaleItem()))
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidSaleItemQuantity()
        {
            return SaleFaker
                .RuleFor(s => s.SaleItems, f => new List<SaleItem>
                {
                    SaleItemTestData.GenerateValidSaleItem()
                })
                .Generate();
        }

        public static Sale GenerateSaleWithInvalidSaleItemUnitPrice()
        {
            return SaleFaker
                .RuleFor(s => s.SaleItems, f => new List<SaleItem>
                {
                    SaleItemTestData.GenerateValidSaleItem()
                })
                .Generate();
        }

    }
}

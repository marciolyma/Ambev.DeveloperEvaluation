namespace Ambev.DeveloperEvaluation.Domain.Seed
{
    public static class DiscountCalculator
    {
        public static decimal CalculateDiscount(int quantity, decimal unitPrice)
        {
            if (quantity < 4)
                return 0;

            if (quantity >= 4 && quantity < 10)
                return 0.1m * (quantity * unitPrice);  // 10% discount

            if (quantity >= 10 && quantity <= 20)
                return 0.2m * (quantity * unitPrice);  // 20% discount

            return 0; // No discount for more than 20 items
        }
    }
}

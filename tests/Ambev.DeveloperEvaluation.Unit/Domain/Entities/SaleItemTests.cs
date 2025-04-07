using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Fact]
        public void Given_ValidSaleItem_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
        [Fact]
        public void Given_NegativeQuantity_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            saleItem.Quantity = -1;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
        [Fact]
        public void Given_ZeroQuantity_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            saleItem.Quantity = 0;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
        [Fact]
        public void Given_NegativeUnitPrice_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            saleItem.UnitPrice = -1;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
        [Fact]
        public void Given_ZeroUnitPrice_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            saleItem.UnitPrice = 0;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
        [Fact]
        public void Given_NegativeDiscount_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateSaleItemWithInvalidQuantity();
            saleItem.Discount = -1;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
        [Fact]
        public void Given_Quantity_greater_than_twenty_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            saleItem.Quantity = 21;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
    }
}

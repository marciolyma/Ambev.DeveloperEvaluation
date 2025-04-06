using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            saleItem.Discount = -1;
            // Act
            var result = saleItem.Validate();
            // Assert
            Assert.False(result.IsValid);
        }
        [Fact]
        public void Given_Quantity_When_Validated_Then_ShouldReturnInvalid()
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

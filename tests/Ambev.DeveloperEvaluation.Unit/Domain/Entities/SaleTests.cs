using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act
            var result = sale.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Sale status should change to Suspended when suspended")]
        public void Given_ActiveSale_When_Suspended_Then_StatusShouldBeSuspended()
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();
            user.Status = UserStatus.Active;

            // Act
            user.Suspend();

            // Assert
            Assert.Equal(UserStatus.Suspended, user.Status);
        }
    }
}

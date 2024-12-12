using ConsoleApp1.Models;

namespace TestProject1
{
    public class calculatorTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        [InlineData(-1, -1)]
        public void AddShouldReturnResult(int a , int b )
        {
            Calculator calculator = new Calculator();


            int result= calculator.Add(5, 3);


            Assert.Equal(8, result);
          
        }

        [Theory]
        [InlineData(6, 2)]         
        [InlineData(-6, 2)]       
        [InlineData(5, 2)]       
        public void DivideShouldReturnResult(int a, int b)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.Divide(4,1);

            // Assert
            Assert.Equal( result,4);
        }

        [Fact]
        public void DivideShouldThrowDivideByZeroException_WhenDividingByZero()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
        }
    }
}
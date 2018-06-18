using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParcelValidator.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void IsSuitableCorner()
        {
            // Arrange
            var calc = new Calculator();
            var parcel = new ParcelSize
            {
                Length = 100,
                Width = 35
            };

            var elbow = new PipeCorner
            {
                Inlet = 75,
                Outlet = 50
            };

            // Act
            var result = calc.IsSuitableCorner(parcel, elbow);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotSuitableCorner()
        {
            // Arrange
            var calc = new Calculator();
            var parcel = new ParcelSize
            {
                Length = 60,
                Width = 120
            };

            var elbow = new PipeCorner
            {
                Inlet = 100,
                Outlet = 75
            };

            // Act
            var result = calc.IsSuitableCorner(parcel, elbow);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

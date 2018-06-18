using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParcelValidator.Tests
{
    [TestClass]
    public class InspectorTest
    {
        [TestMethod]
        public void InspectPassableCorners()
        {
            // Arrange
            var calculatorMock = new Mock<ICalculator>();
            calculatorMock
                .Setup(x => x.IsSuitableCorner(It.IsAny<ParcelSize>(), It.IsAny<PipeCorner>()))
                .Returns(() => true);
            var inspector = new CornerInspector(calculatorMock.Object);
            var parcel = new ParcelSize
            {
                Length = 100,
                Width = 35
            };
            var cornerArgs = new[] { "1", "2", "3", "4", "5", "6" };
            var corners = inspector.ParseCorners(cornerArgs);
            
            // Act
            var result = inspector.InspectPipeCorners(parcel, corners);

            // Assert
            CollectionAssert.AreEqual(new[] {true, true, true}, result);
        }
    }
}

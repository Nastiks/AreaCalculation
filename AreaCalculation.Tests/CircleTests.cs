using AreaCalculation.Core;

namespace AreaCalculation.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void IsCircle_WithRadiusNull_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsCircle_WithRadiusPositiveValue_ReturnSuccess()
        {
            Circle circle = new Circle(5);
            double expected = 28.141592653589793;
            Assert.That(circle.Area, Is.EqualTo(expected));
        }

        [Test]
        public void IsCircle_WithRadiusNegativeValue_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-8));
            Assert.That(exception, Is.Not.Null);
        }
    }
}
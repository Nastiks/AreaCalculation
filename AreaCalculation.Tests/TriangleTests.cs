using AreaCalculation.Core;

namespace AreaCalculation.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void IsTriangle_WitnNullSides_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(0, 0, 0));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsTriangle_WitnCorrectSides_ReturnSuccess()
        {
            Triangle triangle = new Triangle(10, 9, 8);
            double expected = 34.197039345533994;
            Assert.That(triangle.Area, Is.EqualTo(expected));
        }

        [Test]
        public void IsTriangle_WitnNegativeSide_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(1, -3, 5));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsTriangle_WitnNegativeSides_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(-1, -3, -5));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsTriangle_WitNonexistentSides_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(1, 3, 5));
            Assert.That(exception, Is.Not.Null);
        }
    }
}
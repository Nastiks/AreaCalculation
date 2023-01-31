using AreaCalculation.Core.Figures;

namespace AreaCalculation.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        const double tolerance = 0.000000001;
        [Test]
        public void IsTriangle_WitnNullSides_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, 0));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsTriangle_WitnCorrectSides_ReturnSuccess()
        {
            Triangle triangle = new Triangle(10, 9, 8);
            double expected = 34.197039345533994;
            double res = Math.Abs(expected - triangle.Area);
            Assert.That(res, Is.LessThan(tolerance));
        }

        [Test]
        public void IsTriangle_WitnNegativeSide_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, -3, 5));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsTriangle_WitnNegativeSides_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, -3, -5));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsTriangle_WitNonexistentSides_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(1, 3, 5));
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void IsRightTriangle_WitnCorrectSides_ReturnSuccess()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Assert.That(triangle.IsRight, Is.EqualTo(true));
        }

        [Test]
        public void IsRightTriangle_WitnIncorrectSides_ReturnSuccess()
        {
            Triangle triangle = new Triangle(10, 9, 8);
            Assert.That(triangle.IsRight, Is.EqualTo(false));
        }
    }
}
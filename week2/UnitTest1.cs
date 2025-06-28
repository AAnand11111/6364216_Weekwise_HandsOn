using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            // Initialize calculator before each test
            calculator = new SimpleCalculator();
            Console.WriteLine("Test setup completed - Calculator initialized");
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup after each test
            calculator.AllClear();
            Console.WriteLine("Test cleanup completed - Calculator cleared");
        }

        [Test]
        public void Addition_ValidInputs_ReturnsCorrectSum()
        {
            // Arrange
            double a = 5.0;
            double b = 3.0;
            double expected = 8.0;

            // Act
            double actual = calculator.Addition(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 2, 3)]
        [TestCase(10, 5, 15)]
        [TestCase(-1, -2, -3)]
        [TestCase(0, 0, 0)]
        [TestCase(1.5, 2.5, 4.0)]
        public void Addition_ParameterizedTests_ReturnsCorrectSum(double a, double b, double expected)
        {
            // Act
            double actual = calculator.Addition(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Subtraction_ValidInputs_ReturnsCorrectDifference()
        {
            // Arrange
            double a = 10.0;
            double b = 4.0;
            double expected = 6.0;

            // Act
            double actual = calculator.Subtraction(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(10, 5, 5)]
        [TestCase(0, 5, -5)]
        [TestCase(-3, -2, -1)]
        [TestCase(7.5, 2.5, 5.0)]
        public void Subtraction_ParameterizedTests_ReturnsCorrectDifference(double a, double b, double expected)
        {
            // Act
            double actual = calculator.Subtraction(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiplication_ValidInputs_ReturnsCorrectProduct()
        {
            // Arrange
            double a = 4.0;
            double b = 5.0;
            double expected = 20.0;

            // Act
            double actual = calculator.Multiplication(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 6)]
        [TestCase(0, 5, 0)]
        [TestCase(-2, 3, -6)]
        [TestCase(2.5, 4, 10.0)]
        public void Multiplication_ParameterizedTests_ReturnsCorrectProduct(double a, double b, double expected)
        {
            // Act
            double actual = calculator.Multiplication(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ValidInputs_ReturnsCorrectQuotient()
        {
            // Arrange
            double a = 10.0;
            double b = 2.0;
            double expected = 5.0;

            // Act
            double actual = calculator.Division(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(15, 3, 5)]
        [TestCase(-6, 2, -3)]
        [TestCase(7.5, 2.5, 3.0)]
        public void Division_ParameterizedTests_ReturnsCorrectQuotient(double a, double b, double expected)
        {
            // Act
            double actual = calculator.Division(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            // Arrange
            double a = 10.0;
            double b = 0.0;

            // Act & Assert
            Assert.That(() => calculator.Division(a, b),
                       Throws.TypeOf<ArgumentException>()
                       .With.Message.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void GetResult_AfterAddition_ReturnsLastResult()
        {
            // Arrange
            double a = 3.0;
            double b = 4.0;
            double expected = 7.0;

            // Act
            calculator.Addition(a, b);
            double actual = calculator.GetResult;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AllClear_ResetsResult_ToZero()
        {
            // Arrange
            calculator.Addition(5, 3); // Result should be 8

            // Act
            calculator.AllClear();
            double actual = calculator.GetResult;

            // Assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        [Ignore("This test is ignored for demonstration purposes")]
        public void IgnoredTest_WillNotRun()
        {
            // This test will be skipped during execution
            Assert.Fail("This test should not run");
        }
    }
}
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
        public void SetUp()
        {
            // Create a new calculator instance before each test
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        // Addition 
        [TestCase(1, 2, 3)]
        [TestCase(-5, 5, 0)]
        [TestCase(0, 0, 0)]
        public void Addition_ValidInputs_ReturnsSum(double a, double b, double expected)
        {
            double result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(calculator.GetResult, Is.EqualTo(expected));
        }

        // Subtraction 
        [TestCase(5, 3, 2)]
        [TestCase(3, 5, -2)]
        public void Subtraction_ValidInputs_ReturnsDifference(double a, double b, double expected)
        {
            double result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(calculator.GetResult, Is.EqualTo(expected));
        }

        // Multiplication 
        [TestCase(3, 4, 12)]
        [TestCase(-2, -3, 6)]
        [TestCase(7, 0, 0)]
        public void Multiplication_ValidInputs_ReturnsProduct(double a, double b, double expected)
        {
            double result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(calculator.GetResult, Is.EqualTo(expected));
        }

        // Division 
        [TestCase(10, 2, 5)]
        [TestCase(7, 2, 3.5)]
        public void Division_ValidInputs_ReturnsQuotient(double a, double b, double expected)
        {
            double result = calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(calculator.GetResult, Is.EqualTo(expected));
        }

        // Division by zero 
        [TestCase(5, 0)]
        public void Division_ByZero_ThrowsArgumentException(double a, double b)
        {
            Assert.That(() => calculator.Division(a, b),
                Throws.TypeOf<ArgumentException>()
                      .With.Message.EqualTo("Second Parameter Can't be Zero"));
        }

        // AllClear should reset the result to zero
        [Test]
        public void AllClear_AfterOperations_ResetsResultToZero()
        {
            calculator.Addition(10, 5);
            Assert.That(calculator.GetResult, Is.EqualTo(15));  // sanity check before clearing
            calculator.AllClear();
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }

        // Initial state: GetResult should start at 0
        [Test]
        public void GetResult_InitialValue_IsZero()
        {
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }
    }
}

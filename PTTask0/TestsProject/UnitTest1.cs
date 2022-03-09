using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorNamespace;

namespace TestsProject
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestSum()
		{
			int firstNumber = 10;
			int secondNumber = 5;
			int expectedResult = 15;
			Calculator calculator = new Calculator();

			int actualResult = calculator.sum(firstNumber, secondNumber);
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void TestSubstract()
		{
			int firstNumber = 20;
			int secondNumber = 30;
			int expectedResult = -10;
			Calculator calculator = new Calculator();

			int actualResult = calculator.substract(firstNumber, secondNumber);
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void TestMultiply()
		{
			int firstNumber = 3;
			int secondNumber = 12;
			int expectedResult = 36;
			Calculator calculator = new Calculator();

			int actualResult = calculator.multiply(firstNumber, secondNumber);
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}

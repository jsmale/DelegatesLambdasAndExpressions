using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
	[TestClass]
	public class DelegateTests
	{
		Delegates delegates;
		bool testVoidActionExecuted;
		int testDelegateArg;
		int noArgFunctionReturnValue;
		int argument;

		public void TestVoidAction()
		{
			testVoidActionExecuted = true;
		}

		public void TestVoidActionWithArg(int value)
		{
			testDelegateArg = value;
		}

		public int TestNoArgFunction()
		{
			return noArgFunctionReturnValue;
		}

		public int TestFunctionWithArg(int value)
		{
			return value;
		}

		[TestInitialize]
		public void Init()
		{
			delegates = new Delegates();
			testVoidActionExecuted = false;
			argument = (new Random()).Next(10, int.MaxValue);
			testDelegateArg = 0;
			noArgFunctionReturnValue = (new Random()).Next(10, int.MaxValue);
		}

		[TestMethod]
		public void VoidNoArgDelegate()
		{
			delegates.ExecuteAction(TestVoidAction);
			Assert.IsTrue(testVoidActionExecuted);
		}

		[TestMethod]
		public void VoidWithArgDelegate()
		{
			delegates.ExecuteAction(TestVoidActionWithArg, argument);
			Assert.AreEqual(argument, testDelegateArg);
		}

		[TestMethod]
		public void FunctionNoArgDelegate()
		{
			var returnValue = delegates.ExecuteFunction(TestNoArgFunction);
			Assert.AreEqual(noArgFunctionReturnValue, returnValue);
		}

		[TestMethod]
		public void FunctionWithArgDelegate()
		{
			var returnValue = delegates.ExecuteFunction(TestFunctionWithArg, argument);
			Assert.AreEqual(argument, returnValue);
		}
	}
}

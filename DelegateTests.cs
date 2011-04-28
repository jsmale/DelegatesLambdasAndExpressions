using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesLambdasAndExpressions
{
	[TestClass]
	public class DelegateTests
	{
        public delegate void VoidAction();
        bool testVoidActionExecuted;

		[TestMethod]
		public void VoidNoArgDelegate()
		{
		    testVoidActionExecuted = false;
		    VoidAction voidAction = null;
            voidAction();
			Assert.IsTrue(testVoidActionExecuted);
		}

        public delegate void VoidActionWithArg(int value);
        int testDelegateArg;

		[TestMethod]
		public void VoidWithArgDelegate()
		{
            testDelegateArg = 0;
            var argument = (new Random()).Next(10, int.MaxValue);
		    VoidActionWithArg voidActionWithArg = null; 
		    voidActionWithArg(argument);
			Assert.AreEqual(argument, testDelegateArg);
		}

        public delegate int NoArgFunction();
        int noArgFunctionReturnValue;

		[TestMethod]
		public void FunctionNoArgDelegate()
		{
            noArgFunctionReturnValue = (new Random()).Next(10, int.MaxValue);
		    NoArgFunction noArgFunction = null;
            var returnValue = noArgFunction();
			Assert.AreEqual(noArgFunctionReturnValue, returnValue);
		}

        public delegate int FunctionWithArg(int value);

		[TestMethod]
		public void FunctionWithArgDelegate()
        {
            var argument = (new Random()).Next(10, int.MaxValue);
		    FunctionWithArg functionWithArg = null;
			var returnValue = functionWithArg(argument);
			Assert.AreEqual(argument, returnValue);
		}
	}
}
